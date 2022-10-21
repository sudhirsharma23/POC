// Doc: https://docs.aws.amazon.com/AWSJavaScriptSDK/latest/top-level-namespace.html
let AWS = require('aws-sdk');
import utils from '@functions/helpers/utils'
import settings from '../tagger/handlerSettings';

let tagsNames = settings.environment.ADD_TAGS.split(",")
let tagsValues = settings.environment.ADD_TAGS_VALUES.split(",")
let DEBUG = settings.environment.DEBUG;

const taggerAPI = {

  tag: (paramsObj) => {
    let roleName = paramsObj.roleName;
    let typeName = paramsObj.type;
    let resName = paramsObj.arn;
    let tags = paramsObj.tags;
    let retTagResult;

    if (typeName === 'ec2') {
      typeName = utils.getRersourceSubtype(paramsObj.arrArn)
    }

    switch (typeName) {
      case 'ec2-instance':
      case 'ec2-internet-gateway':
      case 'ec2-route-table':
      case 'ec2-prefix-list':
      case 'ec2-network-interface':
      case 'ec2-volume':
      case 'ec2-network-acl':
      case 'ec2-dhcp-options':
      case 'ec2-vpc':
      case 'ec2-security-group':
      case 'ec2-subnet':
        retTagResult = taggerAPI.ec2(paramsObj.arrArn, tags)
        break;
      case 'iam':
        retTagResult = taggerAPI.iam(roleName, tags)
      case 'lambda':
        retTagResult = taggerAPI.lambda(resName, tags)
        break;
      case 'apigateway':
        retTagResult = taggerAPI.apigateway(resName, tags)
        break;
      case 'dynamodb':
        retTagResult = taggerAPI.dynamodb(resName, tags)
        break;
      case 'sqs':
        retTagResult = taggerAPI.sqs(resName, tags)
        break;
      case 'logs':
        retTagResult = taggerAPI.logs(resName, tags)
        break;
      case 'rds':
        retTagResult = taggerAPI.rds(resName, tags)
        break;
      case 'sns':
        retTagResult = taggerAPI.sns(resName, tags)
        break;
      case 'cloudfront':
        retTagResult = taggerAPI.cloudfront(resName, tags)
        break;
      case 'kms':
        retTagResult = taggerAPI.kms(resName, tags)
        break;
      case 's3':
        retTagResult = taggerAPI.s3(resName, tags)
        break;
      case 'cloudformation': // ??
        retTagResult = taggerAPI.cloudformation(resName, tags)
        break;
      case 'cloudwatch':
        // retTagResult = taggerAPI.cloudwatch(resName, tags)
        break;
      default:
        console.log(paramsObj)
        return `the tag type is not valid -> ${typeName}`;
    }
    if (DEBUG) {
      console.log("DEBUG : retTagResult ", retTagResult)
    }
    return retTagResult;
  },
  ec2: (resName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let id = resName[5].split("/")[1]
      let params = {
        Resources: [id],
        Tags: utils.arrayTagParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1])),
      };
      let ec2 = new AWS.EC2({ apiVersion: '2016-11-15' });
      await ec2.createTags(params, function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          resolve({ d: data, arn: resName });
        }
      });
    })
  },
  // aws iam tag-role --role-name "TagCrawlerCdkStack-LambdaRoletagger3437AE65-RA6KXJ3I7Q3H" --tags '{\"Key\": \"test\", \"Value\": \"myke\"}'
  iam: (roleName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        RoleName: roleName,
        Tags: utils.arrayTagParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1]))
      };
      let iam = new AWS.IAM({ apiVersion: '2010-05-08' });
        await iam.tagRole(params, function (err, data) {
          if (err) {
             return ({ e: err, arn: roleName });
          } else {
             resolve({ d: data, arn: roleName });
          }
        });
    })
  },
  apigateway: (resName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        resourceArn: resName,
        tags: utils.objTagParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1]))
      };
      let apigateway = new AWS.APIGateway({
        apiVersion: '2015-07-09'
      });
      await apigateway.tagResource(params, function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          resolve({ d: data, arn: resName });
        }
      })
    })
  },
  lambda: (resName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        Resource: resName,
        Tags: utils.objTagParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1])),
      };
      let lambda = new AWS.Lambda({ apiVersion: '2015-03-31' });
      await lambda.tagResource(params, function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          resolve({ d: data, arn: resName });
        }
      })
    });
  },
  dynamodb: (resName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        ResourceArn: resName,
        Tags: utils.arrayTagParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1])),
      };
      let dynamodb = new AWS.DynamoDB({ apiVersion: '2012-08-10' });
      await dynamodb.tagResource(params, function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          resolve({ d: data, arn: resName });
        }
      });
    });

  },
  sqs: (resName, tags) => { // idk need to re-test
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        QueueName: resName.split(":")[5],
      };
      let sqs = new AWS.SQS({ apiVersion: '2012-11-05' });
      await sqs.getQueueUrl(params, async function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          // resolve(data);
          let paramsData = {
            QueueUrl: data.QueueUrl,
            Tags: utils.objTagParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1])),
          }
          await sqs.tagQueue(paramsData, function (err, data) {
            if (err) {
              reject(err);
            } else {
              resolve({ d: data, arn: resName });
            }
          });
        }
      });
    });
  },
  logs: (resName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        logGroupName: resName.split(":")[6],
        tags: utils.objTagParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1])),
      };
      let logs = new AWS.CloudWatchLogs({ apiVersion: '2014-03-28' });
      await logs.tagLogGroup(params, function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          resolve({ d: data, arn: resName });
        }
      });
    });
  },
  rds: (resName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        ResourceName: resName,
        Tags: utils.arrayTagParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1])),
      };
      let rds = new AWS.RDS({ apiVersion: '2014-10-31' });
      await rds.addTagsToResource(params, function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          resolve({ d: data, arn: resName });
        }
      });
    });
  },
  sns: (resName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        ResourceArn: resName,
        Tags: utils.arrayTagParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1])),
      };
      let sns = new AWS.SNS({ apiVersion: '2010-03-31' });
      await sns.tagResource(params, function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          resolve({ d: data, arn: resName });
        }
      });
    });
  },
  cloudfront: (resName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        Resource: resName,
        Tags: utils.objTagItemsParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1])),
      };
      let cloudfront = new AWS.CloudFront({ apiVersion: '2020-05-31' });
      await cloudfront.tagResource(params, function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          resolve({ d: data, arn: resName });
        }
      });
    });
  },
  kms: (resName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        KeyId: resName,
        Tags: utils.arrayTagKeyParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1])),
      };
      let kms = new AWS.KMS({ apiVersion: '2014-11-01' });
      await kms.tagResource(params, function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          resolve({ d: data, arn: resName });
        }
      });
    });
  },
  s3: (resName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        Bucket: resName.split(":")[5],
        Tagging: utils.objTagSetParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1]))
      };
      let s3 = new AWS.S3({
        apiVersion: '2006-03-01',
      });
      await s3.putBucketTagging(params, function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          resolve({ d: data, arn: resName });
        }
      });
    });
  },
  cloudwatch: (resName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        ResourceARN: resName,
        Tags: utils.arrayTagParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1]))
      };
      let s3 = new AWS.CloudWatch({ apiVersion: '2010-08-01' });

      await s3.tagResource(params, function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          resolve({ d: data, arn: resName });
        }
      });
    });
  },
  // https://stackoverflow.com/questions/48088948/is-it-possible-to-just-add-tags-to-cloudformation-stack-after-it-is-created
  cloudformation: (resName, tags) => {
    return new Promise(async function (resolve, reject) {
      let oldTags = utils.returnTagsStrArr(tags)
      let params = {
        StackName: resName,
        Tags: utils.arrayTagParameter(tagsNames.concat(oldTags[0]), tagsValues.concat(oldTags[1]))
      };
      let cloudformation = new AWS.CloudFormation({ apiVersion: '2010-05-15' });
      await cloudformation.updateStack(params, function (err, data) {
        if (err) {
          reject({ e: err, arn: resName });
        } else {
          resolve({ d: data, arn: resName });
        }
      });
    });
  },
};
export default taggerAPI;