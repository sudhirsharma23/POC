let AWS = require('aws-sdk');
let s3 = new AWS.S3({
    apiVersion: '2006-03-01',
});
const s3API = {
    uploadFilePromise: (filePath:string, bucketName:string, keyName:string) => {
        return new Promise(async function (resolve, reject) {
            var fs = require('fs');
            const file = fs.createReadStream(filePath);
            // Setting up S3 upload parameters
            const uploadParams = {
                Bucket: bucketName, // Bucket into which you want to upload file
                Key: keyName, // Name by which you want to save it
                Body: file // Local file 
            };
            await s3.putObject(uploadParams, function (err:any, data:any) {
                if (err) {
                    reject( err );
                  } else {
                    resolve( data );
                  }
            });
        });
    },
};
export default s3API;