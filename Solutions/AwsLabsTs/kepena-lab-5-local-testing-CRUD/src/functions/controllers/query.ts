import { APIGatewayEvent, APIGatewayProxyResult } from 'aws-lambda';
import { formatJSONResponse } from '@libs/apiGateway';
import settings from '../list-greeting/handlerSettings';
const dynamodb = require('../dynamoDB/dynamoAPI');
const tablename = settings.environment.DATABASE;
const username = settings.environment.USERNAME;

async function query(event: APIGatewayEvent): Promise<APIGatewayProxyResult> {
  try {
    const colName  = event.queryStringParameters.colName || "Username-index";
    const colValue  = event.queryStringParameters.colValue || username;
    return formatJSONResponse({
        statusCode: 200,
        body: await dynamodb.query({
              tableName: tablename,
              index: `${colName}-index`,
              queryKey: colName,
              queryValue: colValue
        })
      });
  } catch (err) {
    return formatJSONResponse({
        statusCode: 404,
        body: "Not Found",
        error: err
      });
  }
}
export default query;
