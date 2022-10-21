// https://stackoverflow.com/questions/35665903/how-to-write-helper-class-in-typescript/40547841
export default class Utils {

    static getRersourceSubtype(arr: string[]) {
        return arr[2] + "-" + arr[5].split("/")[0];
    }
    static arrayContains(str: string, arr: string[]) {
        return (arr.indexOf(str) > -1);
    }
    static createFilePromise(obj: object, fileName: string) {
        return new Promise(async function (resolve, reject) {
            let json = JSON.stringify(obj);
            let fs = require('fs');
            await fs.writeFile(fileName, json, 'utf8',
                function (err, data) {
                    if (err) {
                        reject(err);
                    } else {
                        resolve(data);
                    }
                }
            );
        });
    }
    static createFile(obj: object, fileName: string) {
        let json = JSON.stringify(obj);
        let fs = require('fs');
        fs.writeFile(fileName, json, 'utf8',
            function (err) {
                if (err) {
                    return err;
                } else {
                    return 'complete';
                }
            }
        );
    }
    static arrayTagParameter(names, values) {
        let arrOfObjs = [];
        for (var i = 0; i < names.length; i++) {
            arrOfObjs.push({ "Key": names[i], "Value": values[i] });
        }
        return arrOfObjs;
    }
    static arrayTagLowerCaseParameter(names, values) {
        let arrOfObjs = [];
        for (var i = 0; i < names.length; i++) {
            arrOfObjs.push({ "key": names[i], "value": values[i] });
        }
        return arrOfObjs;
    }
    static arrayTagKeyParameter(names, values) {
        let arrOfObjs = [];
        for (var i = 0; i < names.length; i++) {
            arrOfObjs.push({ "TagKey": names[i], "TagValue": values[i] });
        }
        return arrOfObjs;
    }
    static objTagParameter(names, values) {
        let jsonObj = {};
        for (var i = 0; i < names.length; i++) {
            jsonObj[names[i]] = values[i]
        }
        return jsonObj;
    }
    static objTagSetParameter(names, values) {
        let jsonObj = { "TagSet": [] };
        for (var i = 0; i < names.length; i++) {
            jsonObj.TagSet.push({ "Key": names[i], "Value": values[i] })
        }
        return jsonObj;
    }
    static objTagItemsParameter(names, values) {
        let jsonObj = { "Items": [] };
        for (var i = 0; i < names.length; i++) {
            jsonObj.Items.push({ "Key": names[i], "Value": values[i] })
        }
        return jsonObj;
    }
    // NOTE:
    // To add tags the name can not contain semicolon (:) within the name
    static returnTagsStrArr(oldTags){
        let keys = [], values = [];
        oldTags.forEach(function (item) {
            keys.push(item.Key)
            values.push(item.Value)
        });
        return [keys, values]
    }
} // end of the class