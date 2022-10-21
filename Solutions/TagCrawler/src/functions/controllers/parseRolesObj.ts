function parseRole(obj) {
    let array = obj;
    let currentItem;
    let allRoles = [];
    array.forEach(function (i) {
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