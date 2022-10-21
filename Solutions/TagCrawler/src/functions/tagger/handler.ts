import type { ValidatedEventAPIGatewayProxyEvent } from '@libs/apiGateway';
import { formatJSONResponse } from '@libs/apiGateway';
import { middyfy } from '@libs/lambda';
import schema from './schema';
import settings from './handlerSettings';
// Controllers
import taggerAPI from '@functions/controllers/taggerAPI'
import getAllResources from '@functions/controllers/getResources'
import getAllRoles from '@functions/controllers/getIAMRoles'
import parseResourceObj from '@functions/controllers/parseResourceObj'
import parseRolesObj from '@functions/controllers/parseRolesObj'
import s3API from '@functions/controllers/s3API'
import utils from '@functions/helpers/utils'

const tagger: ValidatedEventAPIGatewayProxyEvent<typeof schema> = async () => {
  let objData, objRoleData;
  try {
    // 1) Getting the resources list
    objData = await getAllResources();
    objRoleData = await getAllRoles();

    if (objData.length > 0) {

      // 2) Parse the return object data
      // [arrNoTags, arrWithTags, arrAllTags];
      let resourceParseArray = parseResourceObj(objData);
      let rolesParseArray = parseRolesObj(objRoleData)
      resourceParseArray[0].push(...rolesParseArray)

      // 3) Tag the resources
      let taggedResources = [];
      let promises = [];
      resourceParseArray[0].forEach(function (item) {
        promises.push(taggerAPI.tag(item)) // collecting promises
      });

      // Run promises array
      await Promise.allSettled(promises).then(async (result) => {
        result.forEach(function (p) {
          if (p.status === "fulfilled") {
            taggedResources.push({
              "data": p.value,
              "tagged": p.status
            })
          } else {
            taggedResources.push({
              "err": p.reason,
              "tagged": p.status
            })
          }
        })

        // 4) store/convert the results in JSON format
        let fixedResourcesJSON = {}
        let fixedFilename = settings.environment.TMP_DIR + "/" + settings.environment.FIXED_RESOURCES_FILENAME;
        fixedResourcesJSON = Object.assign({}, taggedResources);
        await utils.createFilePromise(fixedResourcesJSON, fixedFilename)
        // console.log("corrected-resources.json ", fixedResourcesJSON);

        let allResorcesJSON = {};
        let allResourceFilename = settings.environment.TMP_DIR + "/" + settings.environment.ALL_RESOURCES_FILENAME;
        allResorcesJSON = Object.assign({}, resourceParseArray[2]);
        await utils.createFilePromise(allResorcesJSON, allResourceFilename)
        // console.log("all-resources.json ", allResorcesJSON);

        // 5) upload the results to an s3 bucket
        let bucketName = settings.environment.S3_BUCKET;
        let timeStamp = new Date();
        await s3API.uploadFilePromise(fixedFilename, bucketName, timeStamp.toISOString() + "-" + settings.environment.FIXED_RESOURCES_FILENAME);
        await s3API.uploadFilePromise(allResourceFilename, bucketName, timeStamp.toISOString() + "-" + settings.environment.ALL_RESOURCES_FILENAME);
      })
    } else {
      return formatJSONResponse({
        statusCode: 500,
        message: "Internal Server Error",
        body: objData // the data return was not in the right format
      });
    }
  } catch (err) {
    return formatJSONResponse({
      statusCode: 500,
      message: "Internal Server Error",
      body: err // the data return was not in the right format
    });
  }
}
export const main = middyfy(tagger);