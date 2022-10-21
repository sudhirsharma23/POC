import { Stack, StackProps } from 'aws-cdk-lib';
import { Construct } from 'constructs';
import { Function, Code, Runtime } from 'aws-cdk-lib/aws-lambda';
import * as path from 'path';
import * as iam from 'aws-cdk-lib/aws-iam';
import * as cdk from 'aws-cdk-lib';

export class LambdaStack extends Stack {
  constructor(scope: Construct, id: string, props?: StackProps) {
    super(scope, id, props);

    // Create a Role with service Pricipal Lambda
    const lambdaRole = new iam.Role(this, "S3_Lambda_Role_", {
      assumedBy: new iam.ServicePrincipal("lambda.amazonaws.com"),
    });

    // Attach Inline Polices to role
    lambdaRole.attachInlinePolicy(
      new iam.Policy(this, "Lambda_Policy_", {
        statements: [
          new iam.PolicyStatement({
            actions: [
              // "s3:GetObject",
              // "s3:PutObject", 
              // "s3:ListBucket",
              "s3:*",
            ],
            resources: [
              "*"
            ],
          }),
        ],
      })
    );

    // Create the lambda
    const lambdaFn = new Function(this, "S3_Lambda_Function_", {
      runtime: Runtime.NODEJS_14_X, // execution environment
      code: Code.fromAsset(`${path.resolve(__dirname)}/../src`), // code loaded from the "lambda-fns" directory,
      handler: 'index.main', // file is "index", function is "handler"
      environment: {
        PROFILE: "tmct_n1_default_devops",
        REGION: "us-west-2",
        S3_BUCKET_LOG: "638844603513-s3-access-logs-us-west-2",
        ENABLE_ENCRYPTION : "no",
        ENABLE_LOGGING: "no",
        TAGS: "ApplicationServiceNumber,BusinessApplicationNumber",
        TAGS_VALUES: "AS0000001863,APM0001802"
      },
      role: lambdaRole,
      timeout: cdk.Duration.minutes(5),
    });
  }
}