'use strict';

const https = require('https');
let jwt = require('jsonwebtoken');
var jwkToPem = require('jwk-to-pem');
const util = require('util');
let LRU = require('lru-cache');
const { URL } = require('url');

const IDaaSUrl = 'https://login.microsoftonline.com/%s/v2.0/.well-known/openid-configuration';

let cache;

class Authorizer {
    static init(jwtIn, lruIn) {
        LRU = lruIn ? lruIn : LRU;
        if(lruIn || !cache) {
            cache = new LRU({
                max: 10,
                maxAge: 1000 * 60 * 20
            });
        }
        if(jwtIn) {
            jwt = jwtIn;    
        }
    }
    static async validateToken(jwToken) {
        // Decode jwt to retrieve tenant id and id of public key being used to sign jwt
        let decoded = jwt.decode(jwToken, {complete: true});
        Authorizer.validateClaims(decoded, process.env)
        let kid = decoded.header.kid;
        let tenantId = decoded.payload.tid;
        let jwkUrl = await Authorizer.getJwkUrl(tenantId);
        let jwkPubkey = await Authorizer.getJwkPubKey(kid, jwkUrl, tenantId);
        // Verify jwt (jwkToken) with public key (jwkPubKey). Validates jwt signature.
        let jwkPem = jwkToPem(jwkPubkey);
        jwt.verify(jwToken, jwkPem, { algorithms: ['RS256'] });
    }

    static validateClaims(decodedClaims, envVars) {
        if(Authorizer.isEmptyObject(decodedClaims)) {
            throw new Error('Could not decode jwt')
        }
        if(Authorizer.isEmptyObject(decodedClaims.header) || Authorizer.isEmptyObject(decodedClaims.payload)) {
            throw new Error('jwt header or payload missing');
        }
        if(!decodedClaims.header.kid) {
            throw new Error('kid is missing from header');
        }
        let claimsPayload = decodedClaims.payload;
        if(claimsPayload.tid!==envVars.TenantId) {
            throw new Error('Invalid TenantId');
        }
        if(claimsPayload.iss!==envVars.Issuer) {
            throw new Error('Invalid Issuer');
        }
        if(claimsPayload.aud!==envVars.Audience) {
            throw new Error('Invalid Audience');
        }
        let roles = claimsPayload.roles || [];
        if(!roles.find((r)=>r===envVars.Role)) {
            throw new Error('Invalid Role');
        }
    }
    
    static async getJwkUrl(tenantId) {
        let jwkUrlCacheKey = 'jwk-url-' + encodeURIComponent(tenantId);
        let jwkUrl = cache.get(jwkUrlCacheKey);
        if(!jwkUrl) {
            // Request IDaaS to retrieve jwk url

            let formattedUrl = util.format(IDaaSUrl, tenantId);
            let jwkData = await Authorizer.makeRequest(formattedUrl);
            if(!jwkData) {
                throw new Error('Could not retrieve jwk data');
            }
            jwkUrl = jwkData.jwks_uri;
            cache.set(jwkUrlCacheKey, jwkUrl);
            console.log('JWK Url retrieved from IDaaS');
        } else {
            console.log('JWK Url retrieved from cache');
        }
        return jwkUrl;
    }

    static async getJwkPubKey(kid, jwkUrl, tenantId) {
        let pkCacheKey = 'public-key-' + encodeURIComponent(tenantId);
        let publicKeys = cache.get(pkCacheKey);
        let jwk;
        if(!publicKeys) {
            // Request IDaaS to retrieve list of public keys
            let publicKeys = await Authorizer.makeRequest(jwkUrl);
            jwk = Authorizer.getPublicKey(publicKeys, kid);
            cache.set(pkCacheKey, publicKeys);
            console.log('Public keys retrieved from IDaaS');
        } else {
            console.log('Public keys retrieved from cache');
            jwk = Authorizer.getPublicKey(publicKeys, kid);
        }
        return jwk;
    }

    static getPublicKey(publicKeys, kid) {
        if(!publicKeys) {
            throw new Error('Could not retrieve public keys.');
        }
        // Find public key being used for current jwt
        let jwk = publicKeys.keys.find((key)=>key.kid == kid);
        if(!jwk) {
            throw new Error('Could not find public key in keys list.');
        }
        return jwk
    }

    static makeRequest(reqUrl) {
        let parsedUrl = new URL(reqUrl);
        return Authorizer.httpsRequest({
            method: 'GET',
            hostname: parsedUrl.host,
            path: parsedUrl.pathname,
            port: 443
        });
    }

    static httpsRequest(options) {
        return new Promise((resolve, reject)=>{
            try {
                let respBody = '';
                const req = https.request(options, (res) => {
                    res.setEncoding('utf8');
                    res.on('data', (chunk) => {
                        respBody += chunk;
                    });
                    res.on('end', () => {
                        resolve(respBody);
                    });
                });
                
                req.on('error', (e) => {
                    reject(e.message);
                });
                                
                req.end();
            } catch(err) {
                reject(err.message);
            }
        })
        .then((resp)=>{
            return resp==null || resp==='' ? null : JSON.parse(resp);
        })
    }

    static generateAllowPolicy(principalId, resource) {
        var authResponse = {};
        authResponse.principalId = principalId;
        if (resource) {
            var policyDocument = {};
            policyDocument.Version = '2012-10-17'; // default version
            policyDocument.Statement = [];
            var statementOne = {};
            statementOne.Action = 'execute-api:Invoke'; // default action
            statementOne.Effect = 'Allow';
            statementOne.Resource = "*";
            policyDocument.Statement[0] = statementOne;
            authResponse.policyDocument = policyDocument;
        }
        return authResponse;
    }

    static resetCache() {
        cache.reset();
    }
    
    static isEmptyObject(obj) {
        obj = obj==null ? {} : obj;
        return !Object.keys(obj).length;
    }
}

module.exports = Authorizer;