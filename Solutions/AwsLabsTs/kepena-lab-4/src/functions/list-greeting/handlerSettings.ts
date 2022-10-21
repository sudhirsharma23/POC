import schema from './schema';
import { handlerPath } from '@libs/handlerResolver';

export default {
  handler: `${handlerPath(__dirname)}/handler.main`,
  name: "kepena-lab4-TS",
  description: "greeting API provide the getList method",
  environment: {
    PROFILE:  'TMCT_programmatic',
    USERNAME: "kepena",
    DATABASE: "KepenaGreetings"
  },
  events: [
    {
      http: {
        method: 'get',
        path: 'list-greeting',
        request: {
          schemas: {
            'application/json': schema
          }
        }
      }
    }
  ]
}
