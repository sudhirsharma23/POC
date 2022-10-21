import * as cdk from 'aws-cdk-lib';
import { Template } from 'aws-cdk-lib/assertions';
import * as TagCrawlerCdk from '../lib/tag_crawler_cdk-stack';

test('test resource >>> S3 bucket', () => {
    const app = new cdk.App();
    const stack = new TagCrawlerCdk.TagCrawlerCdkStack(app, 'MyTestStack');
    const template = Template.fromStack(stack);
    template.hasResourceProperties('AWS::S3::Bucket', {
    BucketName: "cdk-tag-crawler-reports-bucket"
    });
});

test('test resource >>> IAM role', () => {
    const app = new cdk.App();
    const stack = new TagCrawlerCdk.TagCrawlerCdkStack(app, 'MyTestStack');
    const template = Template.fromStack(stack);
    template.hasResourceProperties('AWS::IAM::Role', {});
});

test('test resource >>> IAM Policy', () => {
    const app = new cdk.App();
    const stack = new TagCrawlerCdk.TagCrawlerCdkStack(app, 'MyTestStack');
    const template = Template.fromStack(stack);
    template.hasResourceProperties('AWS::IAM::Policy', {});
});

test('test resource >>> Function', () => {
    const app = new cdk.App();
    const stack = new TagCrawlerCdk.TagCrawlerCdkStack(app, 'MyTestStack');
    const template = Template.fromStack(stack);
    template.hasResourceProperties('AWS::Lambda::Function', {});
});

test('test resource >>> EventBridge', () => {
    const app = new cdk.App();
    const stack = new TagCrawlerCdk.TagCrawlerCdkStack(app, 'MyTestStack');
    const template = Template.fromStack(stack);
    template.hasResourceProperties('AWS::Events::Rule', {});
});