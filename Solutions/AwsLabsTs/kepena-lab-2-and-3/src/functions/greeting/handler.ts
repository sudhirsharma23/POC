import type { ValidatedEventAPIGatewayProxyEvent } from '@libs/apiGateway';
import { formatJSONResponse } from '@libs/apiGateway';
import { middyfy } from '@libs/lambda';
import { v4 as uuidv4 } from 'uuid';


import schema  from './schema';
import settings from './handlerSettings';
import { errorMsg } from '@functions/helpers/errorMsg';
import { getGreetingTime, getTimestamp} from '@functions/helpers/datetime';
import { updateDBGreetingTime } from '@functions/helpers/dynamoDB';

const greeting: ValidatedEventAPIGatewayProxyEvent<typeof schema> = async (event, context, callback) => {
  try{
    // get the greeting function for Lab 1
    let greet = getGreetingTime();

    // update the database for Lab 2
    await updateDBGreetingTime({
      "ID": uuidv4(),
      "Greeting":  `Hello world, ` + greet,
      "Timestamp": getTimestamp() + '',
      "Username":  settings.environment.USERNAME,
    });

    // return the greeting message
    return formatJSONResponse({
      statusCode: 200,
      message: `Hello world, ` + greet,
    });
  // error handling
  } catch (err) {
    return errorMsg(err);
  }
}

export const main = middyfy(greeting);