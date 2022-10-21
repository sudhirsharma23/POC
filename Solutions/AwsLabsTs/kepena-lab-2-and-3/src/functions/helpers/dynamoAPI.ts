import settings from '@functions/greeting/handlerSettings';
const AWS = require('aws-sdk');
const awsCredentials = new AWS.SharedIniFileCredentials({
    profile: settings.environment.PROFILE
});
AWS.config.update({
    region: awsCredentials.region || 'us-west-2', 
    accessKeyId: awsCredentials.accessKeyId,
    secretAccessKey: awsCredentials.secretAccessKey,
    sessionToken : awsCredentials.sessionToken
});


const documentClient = new AWS.DynamoDB.DocumentClient();
const Dynamo = {
    async write(data, TableName) {
        if (!data.ID) {
            throw Error('no ID on the data');
        }
        const params = {
            TableName,
            Item: data,
        };
        try {
            return await documentClient.put(params).promise();
        } catch(err){
            throw Error(err);
        }
    },

};
module.exports = Dynamo;