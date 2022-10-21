import { APIGatewayEvent, APIGatewayProxyResult } from 'aws-lambda';
import { formatJSONResponse } from '@libs/apiGateway';
import settings from '../list-greeting/handlerSettings';
const dynamodb = require('../dynamoDB/dynamoAPI');
const tablename = settings.environment.DATABASE;
const username = settings.environment.USERNAME;
const updateTextMsg = `Record updated by ${username}`;

async function update(event: APIGatewayEvent): Promise<APIGatewayProxyResult> {
  try {
    const recordId  = event.pathParameters.greetingId;
    const body = JSON.parse(event.body);
    return formatJSONResponse({
        statusCode: 200,
        body: await dynamodb.update({
          tableName: tablename,
          primaryKey: "ID",
          primaryKeyValue: recordId,
          updateKey: "Username",
          updateValue: body.Username || updateTextMsg
        })
    });
  } catch (err) {
    return formatJSONResponse({
        statusCode: 400,
        body: "Bad Request",
        error: err
      });
  }
}
export default update;
