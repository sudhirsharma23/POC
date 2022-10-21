
import AWS from "aws-sdk";
import serttings from '@functions/list-greeting/handlerSettings'
jest.mock("axios");
const dynamodb = require('../functions/dynamoDB/dynamoAPI');

const tablename = serttings.environment.DATABASE;
const username = serttings.environment.USERNAME;
const idTestRecord = "91f9e6c6-a66d-4953-a84c-bbd593e1b071";
const idTestRecordUpdate = "bb96d6de-19f9-475d-9cf5-51efd7719bad";
const greetTestMsg = "Hello there from testing";
const datetimeTestText = new Date()+"";

/* 
 * Valid input part 
*/
it('get(id) - get one record ', async() => {
        const users = {
            "Greeting": "Hello world, good afternoon", 
            "ID": idTestRecord, 
            "Timestamp": "Mon Nov 29 2021 15:46:14 GMT-0800 (Pacific Standard Time)", 
            "Username": username
        };
        const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'get');
        spy.mockImplementation(()=>{
            return {
                promise(){
                    return{
                        Item: users
                    };
                },
            } as any as AWS.Request<AWS.DynamoDB.DocumentClient.GetItemOutput, AWS.AWSError>;
        });
        const result = await dynamodb.get(
            idTestRecord, 
            tablename
        );
        expect(result).toEqual(users);
        spy.mockRestore();
});


it('write(id) - update a record by passing an ID', async() => {
    const user = {
        "Greeting":greetTestMsg, 
        "ID": idTestRecordUpdate, 
        "Timestamp": datetimeTestText, 
        "Username": username
    };

    const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'put');
    spy.mockImplementation(() => {
        return {
            promise () {
            return {};
            },
        } as any as AWS.Request <AWS.DynamoDB.DocumentClient.PutItemOutput, AWS.AWSError>;
    });
    const result = await dynamodb.write(user, tablename);
    expect(result).toMatchObject({});
    spy.mockRestore();

});

it('update(id) - update a record on the Database  ', async() => {
    const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'update');
    spy.mockImplementation(() => {
    return {
        promise () {
        return {};
        },
    } as any as AWS.Request <AWS.DynamoDB.DocumentClient.PutItemOutput, AWS.AWSError>;
    });
    const result = await dynamodb.update({
        tableName: tablename,
        primaryKey: "ID",
        primaryKeyValue: idTestRecordUpdate,
        updateKey: "Username",
        updateValue: username+"-updated-2"
    });
    expect(result).toMatchObject({});
    spy.mockRestore();
});

it('update() - if ID not provided create a new record ', async() => {
    const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'update');
    spy.mockImplementation(() => {
        return {
            promise () {
            return {};
            },
        } as any as AWS.Request <AWS.DynamoDB.DocumentClient.PutItemOutput, AWS.AWSError>;
    });
    const result = await dynamodb.update({
        tableName: tablename,
        primaryKey: "ID",
        primaryKeyValue: idTestRecordUpdate+"+updateNewRecord",
        updateKey: "Username",
        updateValue: username+"-updated-2"
    });
    expect(result).toMatchObject({});
    spy.mockRestore();
});

it('query(obj) - list of records based on the username  ', async() => {
    const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'query');
    spy.mockImplementation(() => {
    return {
        promise () {
            return {
                Items: [{ },{ }]
            };
        },
    } as any as AWS.Request <AWS.DynamoDB.DocumentClient.QueryOutput, AWS.AWSError>;
    });
    const result = await dynamodb.query({
        tableName: tablename,
        index: 'Username-index',
        queryKey: 'Username',
        queryValue: username
    });
    expect(result).toEqual(expect.any(Array));
    expect(result.length).toBeGreaterThan(1);
    spy.mockRestore();
});

/* 
 * Wrong input part 
*/

it('error get() - Should return an error: missing data', async() => {
    expect.assertions(1);
    try {
        const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'get');
        spy.mockImplementation(() => {
            throw new Error("ValidationException: The provided key element does not match the schema");
        });
        await dynamodb.get(
            {}, 
            tablename
        );
        spy.mockRestore();
    } catch (e) {
        expect(e.message).toBe("Error: ValidationException: The provided key element does not match the schema");
    }
});

it('error write() - Should return an error: missing ID', async() => {
    expect.assertions(1);
    try {
        const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'put');
        spy.mockImplementation(() => {
            throw new Error("no ID on the data");
        });
        // mockedAxios.get.mockResolvedValueOnce({});
        const user = {
            "ID": "", 
        };
        await dynamodb.write(user, tablename);
        spy.mockRestore();

    } catch (e) {
        expect(e.message).toBe('no ID on the data');
    }
});

it('error write() - Should return an error: missing data', async() => {
    expect.assertions(1);
    try {
        const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'put');
        spy.mockImplementation(() => {
            throw new Error("ResourceNotFoundException: Requested resource not found");
        });
        const user = {
            "ID": "YUP", 
        };
        await dynamodb.write(user, tablename+"-wrongTableName");
        spy.mockRestore();
    } catch (e) {
        expect(e.message).toBe("Error: ResourceNotFoundException: Requested resource not found");
    }
});

it('error update() - Should return an error: update a record fails ', async() => {
    expect.assertions(1);
    try {
        const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'update');
        spy.mockImplementation(() => {
            throw new Error("Interal Server Error");
        });        
        await dynamodb.update({
            tableName: tablename,
            primaryKey: "ID",
            // primaryKeyValue: idTestRecordUpdate+"1--",
            // updateKey: "Username",
            // updateValue: username+"-updated-2"
        });
        spy.mockRestore();
    } catch (e) {
        expect(e.message).toEqual(expect.any(String))
    }
});

it('error query() - Should return an error: missing paramenter(s) like username', async() => {
    expect.assertions(1);
    try {
        const spy = jest.spyOn(AWS.DynamoDB.DocumentClient.prototype, 'query');
        spy.mockImplementation(() => {
            throw new Error("Interal Server Error");
        }); 
        await dynamodb.query({
            tableName: tablename,
            // index: 'Username-index',
            // queryKey: 'Username',
            // queryValue: username
        });
        spy.mockRestore();
    } catch (e) {
        expect(e.message).toEqual(expect.any(String))
    }
});