import { Stack, StackProps } from 'aws-cdk-lib';
import { Construct } from 'constructs';
import { Schedule, Rule } from 'aws-cdk-lib/aws-events'
import { LambdaFunction } from 'aws-cdk-lib/aws-events-targets'
import * as s3 from 'aws-cdk-lib/aws-s3';
import * as cdk from 'aws-cdk-lib';
import { Function, Code, Runtime } from 'aws-cdk-lib/aws-lambda';
import * as path from 'path';
import * as iam from 'aws-cdk-lib/aws-iam';
import settings from '../src/settings/settings';

export class TagCrawlerCdkStack extends Stack {
  constructor(scope: Construct, id: string, props?: StackProps) {
    super(scope, id, props);

    // Create the s3.bucket to store the JSON reports
    let myBucket = new s3.Bucket(this, "S3_Bucket_" + settings.environment.PROJECT_NAME, {
      bucketName: settings.environment.S3_BUCKET,
      removalPolicy: cdk.RemovalPolicy.DESTROY,
      autoDeleteObjects: true,
    });

    // Create a Role with service Pricipal Lambda
    const lambdaRole = new iam.Role(this, "Lambda_Role_" + settings.environment.PROJECT_NAME, {
      assumedBy: new iam.ServicePrincipal("lambda.amazonaws.com"),
    });

    // Create the lambda
    const lambdaFn = new Function(this, "Lambda_Function_" + settings.environment.PROJECT_NAME, {
      runtime: Runtime.NODEJS_14_X, // execution environment
      code: Code.fromAsset(`${path.resolve(__dirname)}/../src`), // code loaded from the "lambda-fns" directory,
      handler: 'index.main', // file is "index", function is "handler"
      environment: {
        REGION: settings.environment.REGION
      },
      role: lambdaRole,
      timeout: cdk.Duration.minutes(5),
    });

    // Attach Inline Polices to role
    lambdaRole.attachInlinePolicy(
      new iam.Policy(this, "Lambda_Policy_" + settings.environment.PROJECT_NAME, {
        statements: [
          new iam.PolicyStatement({
            actions: [
              "tag:GetResources",
              "s3:PutObject",
              "s3:GetBucket",
              "s3:GetObject*",
              "iam:TagRole",
              "iam:ListRoles"
            ],
            resources: ["*"],
          }),
        ],
      })
    );

    // Create EventBridge rule that will execute our Lambda daily
    const schedule = new Rule(this, 'EventBridge_daily_' + settings.environment.PROJECT_NAME, {
      schedule: Schedule.rate(cdk.Duration.days(1)),
    });
    // Set the target of our EventBridge rule to our Lambda function
    schedule.addTarget(new LambdaFunction(lambdaFn));
  }
}
