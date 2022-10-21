//import { v4 as uuidv4 } from 'uuid';
const AWS = require('aws-sdk');
AWS.config.update({region:'us-west-2'});
const sqs = new AWS.SQS({ apiVersion: '2012-11-05' });
import settings from '../list-greeting/handlerSettings';
const sqsURL = settings.environment.SQS_URL;
const username = settings.environment.USERNAME;
const date = new Date().toISOString();

async function postSQSMsg(event) {
    const id  = event.pathParameters.greetingId;
    const params = {
        DelaySeconds: 10,
        MessageAttributes: {
            "ID": {
                DataType: "String",
                StringValue: id
            },
            "Username": {
                DataType: "String",
                StringValue: username
            },
            "Greeting": {
                DataType: "String",
                StringValue: "Archive Greeting"
            },
            "Timestamp": {
                DataType: "String",
                StringValue: date
            }
        },
        MessageBody: `Archive record of username:${username} from id:${id}. Time: ${date}`,
        QueueUrl: sqsURL
    };

    sqs.sendMessage(params, function (err, data) {
        if (err) {
            console.log("Error", err);
        } else {
            console.log("Success", data);
        }
    });
}

export default {postSQSMsg};