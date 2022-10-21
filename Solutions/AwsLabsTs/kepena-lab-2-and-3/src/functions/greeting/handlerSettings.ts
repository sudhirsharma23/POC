import { handlerPath } from '@libs/handlerResolver';

export default {
  handler: `${handlerPath(__dirname)}/handler.main`,
  name: "kepena-lab2-TS",
  description: "A greeting API that returns the correct greet based on timestamp",
  environment: {
    PROFILE:  'TMCT_programmatic',
    USERNAME: "kepena",
    DATABASE: "KepenaGreetings"
  },
  events: [
    {
      http: {
        method: 'get',
        path: 'greetings'
      }
    }
  ]
}
