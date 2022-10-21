import { APIGatewayEvent, APIGatewayProxyResult } from 'aws-lambda';
import { formatJSONResponse } from '@libs/apiGateway';
import settings from '../list-greeting/handlerSettings';
const dynamodb = require('../dynamoDB/dynamoAPI');
const tablename = settings.environment.DATABASE;

async function deleteRecord(event: APIGatewayEvent): Promise<APIGatewayProxyResult> {
  try {
    const recordId  = event.pathParameters.greetingId;
    return formatJSONResponse({
        statusCode: 200,
        body: await dynamodb.deleteItem(recordId, tablename)
    });
  } catch (err) {
    return formatJSONResponse({
        statusCode: 500,
        body: "Internal Server Error",
        error: err
      });
  }
}
export default deleteRecord;
