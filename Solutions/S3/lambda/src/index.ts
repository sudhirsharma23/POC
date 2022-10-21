import s3Helper from './controllers/s3Utils'
const AWS = require('aws-sdk');
const s3 = new AWS.S3({ apiVersion: '2006-03-01', region: process.env.REGION});
let encrypFlag:any = process.env.ENABLE_ENCRYPTION;
let logFlag:any = process.env.ENABLE_LOGGING;
let loggingBucket:any = process.env.S3_BUCKET_LOG;

async function main() {

    if (encrypFlag === "yes" || logFlag === "yes") {

        // Get the bucket list name
        let data = await s3.listBuckets({}).promise();

        let encryptPromises: any = [];
        let loggingPromises: any = [];
        data.Buckets.forEach(async function (arrayItem: any) {
            if (encrypFlag === "yes") {
                encryptPromises.push(s3Helper.util({ 'type': 'getEncryption', 'name': arrayItem.Name })) // collecting promises
            }
            if (logFlag === "yes") {
                loggingPromises.push(s3Helper.util({ 'type': 'getLogging', 'name': arrayItem.Name })) // collecting promises
            }
        });

        // Run encryption promises's array
        if (encrypFlag === "yes") {
            let enableEncryptPromises: any = [];
            await (Promise as any).allSettled(encryptPromises).then(async (result: any) => {
                result.forEach(function (p: any) {
                    if (p.status == "fulfilled") {
                    } else {
                        enableEncryptPromises.push(s3Helper.util({ 'type': 'enableEncryptionBucket', 'name': p.reason.name }));
                    }
                })
            })
            await (Promise as any).allSettled(enableEncryptPromises).then(async (arr: any) => {
                arr.forEach(function (i: any) {
                    console.log("enable encrytion ", i)
                })
            })
        }

        // Run logging promises's array
        if (logFlag === "yes") {
            let enableLoggingPromises: any = [];
            await (Promise as any).allSettled(loggingPromises).then(async (result: any) => {
                result.forEach(function (p: any) {
                    if (p.status == "fulfilled") {
                        if (Object.keys(p.value.d).length == 0) {
                            enableLoggingPromises.push(s3Helper.util({ 'type': 'enableloggingBucket', 'name': p.value.name, 'target': loggingBucket }));
                        }
                    }
                })
            })
            await (Promise as any).allSettled(enableLoggingPromises).then(async (arr: any) => {
                arr.forEach(function (i: any) {
                    console.log("enable access logging ", i)
                })
            })
        }
        return "done"
    } else {
        return "set at least one enviroment flag to do some work (ENABLE_ENCRYPTION or ENABLE_LOGGING)"
    }
}
module.exports = { main };