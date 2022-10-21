'use strict';

const Authorizer = require('./authorizer');

exports.handler = async function(event, context, callback) {
    let authToken = (event.authorizationToken.replace(/Bearer/i, '')).trim();
    try {
        Authorizer.init();
        await Authorizer.validateToken(authToken);
        console.log('jwt is valid');
        callback(null, Authorizer.generateAllowPolicy('user', event.methodArn));
    } catch(e) {
        let err = e.message ? e.message : e;
        console.error(err);
        callback("Unauthorized");
    }
};
