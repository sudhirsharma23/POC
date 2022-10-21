import { handlerPath } from '../helpers/handlerResolver';

export default {
  handler: `${handlerPath(__dirname)}/handler.main`,
  name: "tag-enforcer",
  description: "add the missing tag(s) to resources",
  environment: {
    PROFILE:   "tmct_n1_default_devops",
    REGION:    "us-west-2",
    USERNAME:  "kepena",
    S3_BUCKET: "tag-crawler-reports-bucket-ts",
    PROJECT_NAME: "tagger",

    TAGS:      "ApplicationServiceNumber,BusinessApplicationNumber",
    TAGS_VALUES: "AS0000001863,APM0001802",
    
    ADD_TAGS:      "ApplicationServiceNumber,BusinessApplicationNumber,TagCrawlerReport",
    ADD_TAGS_VALUES: "AS0000001863,APM0001802,tag-crawler-reports-bucket",
    
    TMP_DIR: "/tmp",
    ALL_RESOURCES_FILENAME: "all-resources.json",
    FIXED_RESOURCES_FILENAME: "corrected-resources.json",

    DEBUG:"",
    DEBUG_TMP_DIR: "C:/Users/kepena/git/TeamConnect/Solutions/TagCrawler/src/functions/reports"
  }
}
