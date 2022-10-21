import { errorMsg } from '@functions/helpers/errorMsg';

it('should return a http 500 error object', async () => {
    let testRet = errorMsg('test');
    expect(testRet).toHaveProperty('statusCode')
    expect(testRet).toHaveProperty('body',  'Internal Server Error')
})