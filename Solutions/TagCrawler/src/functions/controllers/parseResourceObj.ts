import settings from '../tagger/handlerSettings';
import utils from '@functions/helpers/utils'

let tagArray = settings.environment.TAGS.split(",");
let tagCount = tagArray.length;

function parse(obj) {
    let arrNoTags = [];
    let arrWithTags = [];
    let allAllTags =[];
    let array = obj;
    let resourceName = "";
    let resourceTags;

    // loop throught every resources to figure which resources need to be tagged
    array.forEach(function (item) {
        resourceName = item.ResourceARN;
        resourceTags = item.Tags;
        allAllTags.push({
          "resourceName": resourceName,
          "resourceTags": resourceTags
        })
        if (item.hasOwnProperty("Tags") && item.Tags.length > 0) {
            let count = 0; // reset the count
            item.Tags.forEach(function (i) {      
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

function mapper(arr){
    let resultArrObject = [];
    let currentItem = "";
    arr.forEach(function (i) {
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