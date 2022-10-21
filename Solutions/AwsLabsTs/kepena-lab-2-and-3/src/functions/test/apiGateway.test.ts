import { formatJSONResponse } from '@libs/apiGateway';

it('should return json format response ', async () => {
    let testRet = formatJSONResponse({});
    expect(testRet).toHaveProperty('statusCode')
    expect(testRet).toHaveProperty('body',  "{}")
})