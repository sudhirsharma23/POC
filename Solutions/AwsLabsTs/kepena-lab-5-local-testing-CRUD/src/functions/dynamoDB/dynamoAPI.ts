import setttings from '../list-greeting/handlerSettings';
const AWS = require('aws-sdk');

const awsCredentials = new AWS.SharedIniFileCredentials({
    profile: setttings.environment.PROFILE
});
AWS.config.update({
    region: awsCredentials.region || 'us-west-2', 
    accessKeyId: awsCredentials.accessKeyId,
    secretAccessKey: awsCredentials.secretAccessKey,
    sessionToken : awsCredentials.sessionToken
});


const documentClient = new AWS.DynamoDB.DocumentClient();
const Dynamo = {
    async get(ID, TableName) {
        const params = {
            TableName,
            Key: { ID },
        };
        try {
            const data = await documentClient.get(params).promise();
            return data.Item;
        } catch(err){
            throw Error(err);
        }
    },

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

    update: async ({ tableName, primaryKey, primaryKeyValue, updateKey, updateValue }) => {
        const params = {
            TableName: tableName,
            Key: { [primaryKey]: primaryKeyValue },
            UpdateExpression: `set ${updateKey} = :updateValue`,
            ExpressionAttributeValues: {
                ':updateValue': updateValue,
            },
        };
        try {
            return await documentClient.update(params).promise();
        } catch(err) {
            throw Error(err);
        }
    },

    query: async ({ tableName, index, queryKey, queryValue }) => {
        const params = {
            TableName: tableName,
            IndexName: index,
            KeyConditionExpression: `${queryKey} = :hkey`,
            ExpressionAttributeValues: {
                ':hkey': queryValue,
            },
        };
        try {
            const res = await documentClient.query(params).promise();
            return res.Items;
        } catch(err) {
            throw Error(err);
        }
    },
    async scan(tableName){
        try {
            const res = await documentClient.scan({
                TableName: tableName
              }).promise();
            return res.Items;
        } catch(err) {
            throw Error(err);
        }
    },
    async deleteItem(id, tableName) {
        const params = {
          TableName: tableName,
          Key: { "ID": id }
        }
        try {
          return await documentClient.delete(params).promise()
        } catch (err) {
            throw Error(err);
        }
      }
};
module.exports = Dynamo;