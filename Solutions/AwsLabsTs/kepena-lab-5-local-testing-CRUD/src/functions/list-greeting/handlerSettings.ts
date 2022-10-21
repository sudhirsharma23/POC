//import schema from './schema';
import { handlerPath } from '@libs/handlerResolver';
export default {
  handler: `${handlerPath(__dirname)}/handler.main`,
  name: "kepena-lab-CRUD",
  description: "greeting API",
  environment: {
    PROFILE:  'TMCT_programmatic',
    USERNAME: "kepena",
    DATABASE: "KepenaGreetings",
    SQS_URL: "https://sqs.us-west-2.amazonaws.com/638844603513/KepenaGreetingsArchiveQueue",
    SQS_ARN: "arn:aws:sqs:us-west-2:638844603513:KepenaGreetingsArchiveQueue"
  },
  events: [
    {
      http: {
        method: 'get',
        path: 'greeting'
      }
    },
    {
      http: {
        method: 'get',
        path: 'greeting/query'
      }
    },
    {
      http: {
        method: 'get',
        path: 'greeting/{greetingId}'
      }
    },
    {
      http: {
        method: 'post',
        path: 'greeting'
      }
    },
    {
      http: {
        method: 'put',
        path: 'greeting/{greetingId}'
      }
    },
    {
      http: {
        method: 'delete',
        path: 'greeting/{greetingId}'
      }
    }
  ],
}
