// import settings from '../tagger/handlerSettings';
// import utils from '@functions/helpers/utils'
// let tagArray = settings.environment.TAGS.split(",");
// let tagCount = tagArray.length;

function parseRole(obj:any) {
    let array = obj;
    let currentItem;
    let allRoles:any = [];
    array.forEach(function (i:any) {
        currentItem = i.Arn.split(":")
        allRoles.push({
            "arrArn": i.Arn.split(":"),
            "type": currentItem[2],
            "arn": i.Arn,
            "roleId": i.RoleId,
            "roleName": i.RoleName,
            "tags": []
        });
    }) // end of the loop
    return allRoles;
}

export default parseRole;