import settings from './settings/settings'
import utils from './helpers/utils'
import gr from './controllers/getResources'
import pr from './controllers/parseResourceObj'
import groles from './controllers/getIAMRoles'
import proles from './controllers/parseRolesObj'
import taggerAPI from './controllers/taggerAPI'
import s3API from './controllers/s3API'

async function main() {

  let objData:any, objRoleData:any;
  try {
    // 1) Getting the resources list
    objData = await gr();
    objRoleData = await groles();

    if (objData.length > 0) {

      // 2) Parse the return object data
      // [arrNoTags, arrWithTags, arrAllTags];
      let resourceParseArray = pr(objData);
      let rolesParseArray = proles(objRoleData)
      resourceParseArray[0].push(...rolesParseArray)

      // 3) Tag the resources
      let taggedResources:any = [];
      let promises:any = [];
      resourceParseArray[0].forEach(function (item:any) {
        promises.push(taggerAPI.tag(item)) // collecting promises
      });

      // Run promises array
      await (Promise as any).allSettled(promises).then(async (result:any) => {
        result.forEach(function (p:any) {
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

      console.log("Done reports has been  upload to ", bucketName)
      return "Done reports has been  upload to "+bucketName
    } else {
      return {
        statusCode: 500,
        message: "Internal Server Error 1",
        body: objData // the data return was not in the right format
      }
    }
  } catch (err) {
    return {
      statusCode: 500,
      message: "Internal Server Error 2",
      body: err // the data return was not in the right format
    };
  }

}
module.exports = { main };