import { handlerPath } from '@libs/handlerResolver';

export default {
  handler: `${handlerPath(__dirname)}/handler.main`,
  name: "Kevin-Lab1-TS",
  description: "Deploying a lambda with serverless to s3",
  environment: {
    USERNAME: "kepena"
  },
  events: [
    {
      http: {
        method: 'get',
        path: 'greeting'
      }
    }
  ]
}
