//import type { ValidatedEventAPIGatewayProxyEvent } from '@libs/apiGateway';
import { formatJSONResponse } from '@libs/apiGateway';
import { APIGatewayProxyResult } from 'aws-lambda';

import getAllItems from '@functions/controllers/getList';
import get from '@functions/controllers/get';
import create from '@functions/controllers/create';
import update from '@functions/controllers/update'
import deleteRecord from '@functions/controllers/delete';
import query from '@functions/controllers/query';
import sqs from '@functions/sqs/archiveMsg';


export const main = async (event?: any) : Promise<APIGatewayProxyResult> => {
  try {
    let reqRoute = '';
    if (!event.httpMethod) {
      reqRoute = "Request Not Found";
    } else {
      reqRoute = event.httpMethod + ' ' + event.resource;
    }

    // CRUD operations
    switch (reqRoute) {
      case 'GET /greeting':
        return await getAllItems();

      case 'GET /greeting/{greetingId}':
        return await get(event);

      case 'GET /greeting/query':
        return await query(event);

      case 'POST /greeting':
        return await create(event);

      case 'PUT /greeting/{greetingId}':
        return await update(event);

      case 'DELETE /greeting/{greetingId}':
        await sqs.postSQSMsg(event); // Lab archive the deleted record
        return await deleteRecord(event);

      default:
        return formatJSONResponse({
          statusCode: 401,
          body: `Invalid Route: ${reqRoute}`,
          eventMsg: event
        });
    }

  } catch (err) {
    return formatJSONResponse({
      statusCode: 500,
      body: 'Internal Server Error',
      error: err
    });
  }
}