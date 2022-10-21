import { APIGatewayEvent, APIGatewayProxyResult } from 'aws-lambda';
import { formatJSONResponse } from '@libs/apiGateway';
import settings from '../list-greeting/handlerSettings';
const dynamodb = require('../dynamoDB/dynamoAPI');
const tablename = settings.environment.DATABASE;

async function get(event: APIGatewayEvent): Promise<APIGatewayProxyResult> {
  try {
    const recordId  = event.pathParameters.greetingId;
    return formatJSONResponse({
        statusCode: 200,
        body: await dynamodb.get(
            recordId, 
            tablename
          )
      });
  } catch (err) {
    return formatJSONResponse({
        statusCode: 404,
        body: "Not Found",
        error: err
      });
  }
}
export default get;
