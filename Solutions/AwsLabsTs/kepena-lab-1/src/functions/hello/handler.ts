import type { ValidatedEventAPIGatewayProxyEvent } from '@libs/apiGateway';
import { formatJSONResponse } from '@libs/apiGateway';
import { middyfy } from '@libs/lambda';

import schema from './schema';

const hello: ValidatedEventAPIGatewayProxyEvent<typeof schema> = async (event) => {
  try {
    let username = event && event.username ? event.username.trim() : process.env.USERNAME;
    console.log(`${username} says Hello World at ` + new Date().toISOString());
    return formatJSONResponse({
      message: `${username} says Hello World at ` + new Date().toISOString(),
      // event,
    });
  } catch (err) {
    console.log(`${err} Internal Server Error`);
    return formatJSONResponse({
      statusCode: 500,
      body: 'Internal Server Error'
    });
  }
}

export const main = middyfy(hello);
