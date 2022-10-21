import type { AWS } from '@serverless/typescript';

import hello from '@functions/hello/handlersSettings';

const serverlessConfiguration: AWS = {
  service: 'aws-typescript-test',
  frameworkVersion: '2',
  plugins: ['serverless-esbuild'],
  provider: {
    name: 'aws',
    runtime: 'nodejs14.x',
    region: 'us-west-2',    
    // profile: 'TMCT_master_role',
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
  functions: { hello },
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
};

module.exports = serverlessConfiguration;
