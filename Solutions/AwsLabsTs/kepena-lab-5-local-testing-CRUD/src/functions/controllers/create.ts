import { APIGatewayEvent, APIGatewayProxyResult } from 'aws-lambda';
import { formatJSONResponse } from '@libs/apiGateway';
import { v4 as uuidv4 } from 'uuid';
import settings from '../list-greeting/handlerSettings';
const dynamodb = require('../dynamoDB/dynamoAPI');
const tablename = settings.environment.DATABASE;
const username = settings.environment.USERNAME;
const idTestRecord = uuidv4() || "SomeIdToTestaNewRecord";
const greetTestMsg = "Hello there from testing";
const datetimeTestText = new Date().toISOString();

async function create(event: APIGatewayEvent): Promise<APIGatewayProxyResult> {
  try {
    const body = JSON.parse(event.body);
    const newUser = {
        "ID": idTestRecord,
        "Timestamp": datetimeTestText, 
        "Username": username,
        "Greeting": body.Greeting || greetTestMsg, 
    };
    return formatJSONResponse({
        statusCode: 200,
        body: await dynamodb.write(newUser, tablename)
    });
  } catch (err) {
    return formatJSONResponse({
        statusCode: 400,
        body: "Bad Request",
        error: err
      });
  }
}
export default create;
