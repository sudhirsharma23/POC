const AWS = require('aws-sdk');

const getAllResources = async () => {
    let allData: any[] = new Array();
    // let allData = [];
    let pageData:any;
    let objData :any = await getResources();
     // First Page
    let paginationToken = objData.PaginationToken;
    allData.concat(objData.ResourceTagMappingList)
    try {
        do {
            pageData = await getResources({
                ResourcesPerPage: 100,
                PaginationToken: paginationToken
            });
            paginationToken = pageData.PaginationToken;
            allData.push(...pageData.ResourceTagMappingList)
        } while (paginationToken != "");
        return allData
    } catch (e) {
        console.log("error: ", e)
        return e
    }
}

const getResources = (p={}) => {
    return new Promise(async function (resolve, reject) {
        let resourcegroupstaggingapi = new AWS.ResourceGroupsTaggingAPI();
        await resourcegroupstaggingapi.getResources(p, function (err: any, data: any) {
            if (err) {
                reject(err);
            } else {
                resolve(data);
            }
        })
    }); // end of the promise
}
export default getAllResources;