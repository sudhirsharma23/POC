import type { AWS } from '@serverless/typescript';
import greetAPI from '@functions/list-greeting/handlerSettings';

const serverlessConfiguration: AWS = {
  service: 'kepena-lab-CRUD',
  frameworkVersion: '2',
  plugins: [
    'serverless-esbuild',
    'serverless-dynamodb-local',
    'serverless-offline',
  ],
  provider: {
    name: 'aws',
    runtime: 'nodejs14.x',
    region: 'us-west-2',
     profile: 'tmct_n1_default_devops',
     iam: {
       role: 'arn:aws:iam::638844603513:role/tmct-n-1-tmct-dev-lambda-role',
     },
    deploymentBucket: {
      name: 'kepena-labs-bucket'
    },
    apiGateway: {
      minimumCompressionSize: 1024,
      shouldStartNameWithService: true,
    },
    environment: {
      AWS_NODEJS_CONNECTION_REUSE_ENABLED: '1',
      AWS_SDK_LOAD_CONFIG: '1',
      NODE_OPTIONS: '--enable-source-maps --stack-trace-limit=1000'
    },
    lambdaHashingVersion: '20201221',
  },
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
    'serverless-offline': {
      httpPort: 3003
    },
    dynamodb: {
      start: {
        port: 5000,
        inMemory: true,
        migrate: true
      },
      stages: ['dev']
    }
  },
  resources: {
    Resources: {
      MemosListTable: {
        Type: 'AWS::DynamoDB::Table',
        Properties: {
          TableName: 'KepenaGreetings',
          AttributeDefinitions: [{
            AttributeName: 'ID',
            AttributeType: 'S'
          }],
          GlobalSecondaryIndexes: [{
                    IndexName: "Username-Index",
                    KeySchema: [
                        {AttributeName: "ID", KeyType: "HASH"},  //Partition key
                    ],
                    Projection: {
                        "ProjectionType": "ALL"
                    },
                    ProvisionedThroughput: {
                      ReadCapacityUnits: 10,
                      WriteCapacityUnits: 10
                  }
            }],
        KeySchema: [{
            AttributeName: 'ID',
            KeyType: 'HASH'
          }],
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