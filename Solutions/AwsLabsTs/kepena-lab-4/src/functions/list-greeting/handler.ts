import type { ValidatedEventAPIGatewayProxyEvent } from '@libs/apiGateway';
import { formatJSONResponse } from '@libs/apiGateway';
import { middyfy } from '@libs/lambda';
import schema from './schema';
import settings from './handlerSettings';

const dynamodb = require('../dynamoDB/dynamoAPI');
const tablename = settings.environment.DATABASE;
const username = settings.environment.USERNAME;

const getList: ValidatedEventAPIGatewayProxyEvent<typeof schema> = async () => {  
  try {
    const records = await dynamodb.query({
      tableName: tablename,
      index: 'Username-index',
      queryKey: 'Username',
      queryValue: username
    });

    return formatJSONResponse({
      statusCode: 200,
      message: `Returns the list of users from a dynamoDb Table named: ${tablename}`,
      body: records
    });

  // error handling
  } catch (err) {
    return formatJSONResponse({
      statusCode: 500,
      body: 'Internal Server Error',
      error: err
    });
  }
}

export const main = middyfy(getList);
