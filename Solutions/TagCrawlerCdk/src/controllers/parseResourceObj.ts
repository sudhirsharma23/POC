import settings from '../settings/settings';
import utils from '../helpers/utils'

let tagArray = settings.environment.TAGS.split(",");
let tagCount = tagArray.length;

function parse(obj:any) {
    let arrNoTags:any = [];
    let arrWithTags:any = [];
    let allAllTags:any =[];
    let array = obj;
    let resourceName = "";
    let resourceTags;

    // loop throught every resources to figure which resources need to be tagged
    array.forEach(function (item:any) {
        resourceName = item.ResourceARN;
        resourceTags = item.Tags;
        allAllTags.push({
          "resourceName": resourceName,
          "resourceTags": resourceTags
        })
        if (item.hasOwnProperty("Tags") && item.Tags.length > 0) {
            let count = 0; // reset the count
            item.Tags.forEach(function (i:any) {      
              if ( utils.arrayContains(i.Key, tagArray) ) {
                count++
              }
            });
            if (count !== tagCount) {
              arrNoTags.push({
                "resourceName": resourceName,
                "resourceTags": resourceTags
              })
            } else {
                // array with all the correct tags
                arrWithTags.push({
                  "resourceName": resourceName,
                  "resourceTags": resourceTags
                });
            }
        } else {
          arrNoTags.push({
            "resourceName": resourceName,
            "resourceTags": resourceTags
          })
        }
    }) // end of the loop

    return [mapper(arrNoTags), arrWithTags, allAllTags];
}

function mapper(arr:any){
    let resultArrObject:any = [];
    let currentItem = "";
    arr.forEach(function (i:any) {
        currentItem = i.resourceName.split(":")
        resultArrObject.push({
            "arrArn": i.resourceName.split(":"),
            "type": currentItem[2],
            "arn": i.resourceName,
            "tags": i.resourceTags
        });
    }) // end of the loop
    return resultArrObject;
}

export default parse;