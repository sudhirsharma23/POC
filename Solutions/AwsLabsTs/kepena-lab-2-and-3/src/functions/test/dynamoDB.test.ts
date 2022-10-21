import AWS from "aws-sdk";
import { v4 as uuidv4 } from 'uuid';
import { updateDBGreetingTime } from '@functions/helpers/dynamoDB';
import { getTimestamp} from '@functions/helpers/datetime';
import settings from '../greeting/handlerSettings';

it('should add a record to AWS dynamoDB table', async() => {
  jest.useFakeTimers();
  const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'put');
  spy.mockImplementation(() => {
    return {
        promise () {
          return {};
          },
    } as any as AWS.Request <AWS.DynamoDB.DocumentClient.PutItemOutput, AWS.AWSError>;
  });
  const result = await updateDBGreetingTime({
    "ID":        uuidv4(),
    "Greeting":  `Hello world` ,
    "Timestamp": getTimestamp() + '' ,
    "Username":  settings.environment.USERNAME 
  });
  expect(result).toMatchObject({});
});

it('error write() - Should return an error: missing ID', async() => {
  try {
      const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'put');
      spy.mockImplementation(() => {
          throw new Error("no ID on the data");
      });
      const user = {
          "ID": "", 
      };
      await updateDBGreetingTime(user);
      spy.mockRestore();
  } catch (e) {
      expect(e.message).toBe('no ID on the data');
  }
});

it('error write() - Should return an error: missing data', async() => {
  try {
      const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'put');
      spy.mockImplementation(() => {
          throw new Error("ResourceNotFoundException: Requested resource not found");
      });
      const user = {
          "ID": "YUP", 
      };
      await updateDBGreetingTime(user);
      spy.mockRestore();
  } catch (e) {
      expect(e.message).toBe("Error: ResourceNotFoundException: Requested resource not found");
  }
});