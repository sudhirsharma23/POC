export function errorMsg(err) {
    const response = {
        statusCode: 500,
        body: 'Internal Server Error',
        error: err
    };
    return response;
}