import type { AWS } from '@serverless/typescript';

import greetAPI from '@functions/list-greeting/handlerSettings';

const serverlessConfiguration: AWS = {
  service: 'kepena-lab-4',
  frameworkVersion: '2',
  plugins: [
    'serverless-esbuild',
    'serverless-dynamodb-local',
    'serverless-offline'
  ],
  provider: {
    name: 'aws',
    runtime: 'nodejs14.x',
    region: 'us-west-2',    
//    profile: 'TMCT_master_role',
    profile: 'TMCT_programmatic',
    iam: {
      role: 'arn:aws:iam::638844603513:role/TMCT_role',
    },
    deploymentBucket: {
      name: 'kepena-labs-bucket'
    },
    // apiGateway: {
    //   minimumCompressionSize: 1024,
    //   shouldStartNameWithService: true,
    // },
    environment: {
      AWS_NODEJS_CONNECTION_REUSE_ENABLED: '1',
      // NODE_OPTIONS: '--enable-source-maps --stack-trace-limit=1000',
    },
    lambdaHashingVersion: '20201221',
  },
  // import the function via paths
  functions: { greetAPI },
  package: { individually: true },
  custom: {
    esbuild: {
      bundle: true,
      minify: false,
      sourcemap: true,
      exclude: ['aws-sdk'],
      target: 'node14',
      define: { 'require.resolve': undefined },
      platform: 'node',
      concurrency: 10,
    },
  },
  // DynamoDB
  resources: {
    Resources: {
      FileTable: {
        Type: 'AWS::DynamoDB::Table',
        DeletionPolicy: 'Retain',
        Properties: {
          TableName: 'KepenaGreetings',
          AttributeDefinitions: [
            {
              AttributeName: 'ID',
              AttributeType: 'S'
            }
          ],
          KeySchema: [
            {
              AttributeName: 'ID',
              KeyType: 'HASH'
            }
          ],
          ProvisionedThroughput: {
            ReadCapacityUnits: 1,
            WriteCapacityUnits: 1
          }
        }
      }
    }
  }
};

module.exports = serverlessConfiguration;
