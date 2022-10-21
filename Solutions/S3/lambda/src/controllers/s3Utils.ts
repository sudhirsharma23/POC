let AWS = require('aws-sdk');
const s3 = new AWS.S3({ apiVersion: '2006-03-01', region: 'us-west-2' });

const s3API = {
  util: (paramsObj: any) => {
    let typeName = paramsObj.type;
    let resName = paramsObj.name;
    let targetName = paramsObj.target; 
    let retTagResult;

    switch (typeName) {
      case 'getEncryption':
        retTagResult = s3API.getEncryption(resName)
        break;
      case 'enableEncryptionBucket':
        retTagResult = s3API.enableEncryptionBucket(resName)
        break;
      case 'getLogging':
        retTagResult = s3API.getLogging(resName)
        break;
      case 'enableloggingBucket':
        retTagResult = s3API.enableloggingBucket(resName, targetName)
        break;
      default:
        return `the util type is not valid -> ${typeName}`;
    }
    return retTagResult;
  },
  getEncryption: (resName: any) => {
    return new Promise(async function (resolve, reject) {
      let params = {
        Bucket: resName, /* required */
      };
      await s3.getBucketEncryption(params, function (err: any, data: any) {
        if (err) {
          return reject({ e: err, name: resName });
        } else {
          return resolve({ d: data, name: resName });
        }
      });
    })
  },
  enableEncryptionBucket: (bucketName: string) => {
    return new Promise(async function (resolve, reject) {
      const params = {
        Bucket: bucketName,
        ServerSideEncryptionConfiguration: {
          Rules: [
            {
              ApplyServerSideEncryptionByDefault: {
                SSEAlgorithm: "AES256",
              },
            },
          ]
        },
      };
      await s3.putBucketEncryption(params, function (err: any, data: any) {
        if (err) {
          reject(err);
        } else {
          resolve(data);
        }
      });
    });
  },
  getLogging: (resName: any) => {
    return new Promise(async function (resolve, reject) {
      let params = {
        Bucket: resName, /* required */
      };
      await s3.getBucketLogging(params, function (err: any, data: any) {
        if (err) {
          return reject({ e: err, name: resName });
        } else {
          return resolve({ d: data, name: resName });
        }
      });
    })
  },
  enableloggingBucket: (bucketName: string, targetLogginBucket: string) => {
    return new Promise(async function (resolve, reject) {
      const params = {
        Bucket: bucketName,
        BucketLoggingStatus: {
          LoggingEnabled: {
            TargetBucket: targetLogginBucket,
            TargetPrefix: ""
          }
        }
      };
      await s3.putBucketLogging(params, function (err: any, data: any) {
        if (err) {
          reject(err);
        } else {
          resolve(data);
        }
      });
    });
  },
}; // the end
export default s3API;