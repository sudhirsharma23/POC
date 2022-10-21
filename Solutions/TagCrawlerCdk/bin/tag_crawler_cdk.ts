#!/usr/bin/env node
import 'source-map-support/register';
import * as cdk from 'aws-cdk-lib';
import { TagCrawlerCdkStack } from '../lib/tag_crawler_cdk-stack';
import { PermissionsBoundary } from '../lib/permissionBoundary';
import { Aspects } from 'aws-cdk-lib';


const app = new cdk.App();
new TagCrawlerCdkStack(app, 'TagCrawlerCdkStack', {
    tags: {
        ApplicationServiceNumber: "AS0000001863",
        BusinessApplicationNumber: "APM0001802",
        TagCrawlerReport: "tag-crawler-reports-bucket"
    }
});
Aspects.of(app).add(new PermissionsBoundary("arn:aws:iam::638844603513:policy/CAVM/FirstAm-GlobalPermissionsBoundary"));
app.synth();