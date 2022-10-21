const AWS = require('aws-sdk');

const getAllResources = async () => {
    let allData = [];
    let pageData;
    let objData = await getResources();
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
    }
}

const getResources = (p={}) => {
    return new Promise(async function (resolve, reject) {
        let resourcegroupstaggingapi = new AWS.ResourceGroupsTaggingAPI();
        await resourcegroupstaggingapi.getResources(p, function (err, data) {
            if (err) {
                reject(err);
            } else {
                resolve(data);
            }
        })
    }); // end of the promise
}
export default getAllResources;