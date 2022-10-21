import { formatJSONResponse } from '@libs/apiGateway';
import settings from '@functions/greeting/handlerSettings';
const dynamodb = require('./dynamoAPI');

export async function updateDBGreetingTime(paramItemsObj?) {
    try {
        return await dynamodb.write(paramItemsObj, settings.environment.DATABASE);
    } catch (err) {
        return  formatJSONResponse({
            statusCode: 500,
            body: err
        })
    }
}
