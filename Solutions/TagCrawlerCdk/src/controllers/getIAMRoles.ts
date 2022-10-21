const AWS = require('aws-sdk');

const getAllRoles = async () => {
    let allData:any = [];
    let pageData:any;
    let objData:any = await getIAMroles();

    // console.log("iam roles" , objData)
     // First Page
    let markerToken = objData.Marker;
    allData.concat(objData.Roles)
    try {
        do {
            pageData = await getIAMroles({
                MaxItems: 100,
                Marker: markerToken
            });
            markerToken = pageData.Marker;
            allData.push(...pageData.Roles)
        } while (markerToken === undefined);
        return allData
    } catch (e) {
        console.log("error: ", e)
        return e;
    }
}

const getIAMroles = (p={}) => {
    return new Promise(async function (resolve, reject) {
        let iam = new AWS.IAM();
        await iam.listRoles(p, function (err:any, data:any) {
            if (err) {
                reject(err);
            } else {
                resolve(data);
            }
        })
    }); // end of the promise
}
export default getAllRoles;