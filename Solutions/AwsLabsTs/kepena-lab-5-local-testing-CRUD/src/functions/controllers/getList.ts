import { APIGatewayProxyResult } from 'aws-lambda';
import { formatJSONResponse } from '@libs/apiGateway';
import settings from '../list-greeting/handlerSettings';
const dynamodb = require('../dynamoDB/dynamoAPI');
const tablename = settings.environment.DATABASE;

async function getList(): Promise<APIGatewayProxyResult> {
  try {
    return formatJSONResponse({
        statusCode: 200,
        body: await dynamodb.scan(
                tablename
            )
      });
  } catch (err) {
    return formatJSONResponse({
        statusCode: 500,
        body: "Internal Server Error",
        error: err
      });
  }
}
export default getList;
