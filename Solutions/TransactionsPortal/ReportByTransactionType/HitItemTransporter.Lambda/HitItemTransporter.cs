using Amazon.Lambda.Core;
using Amazon.Lambda.S3Events;
using Amazon.XRay.Recorder.Handlers.AwsSdk;
using Newtonsoft.Json;
using System.Threading.Tasks;
using static Amazon.S3.Util.S3EventNotification;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace HitItemTransporter.Lambda
{
    public class HitItemTransporter
    {

        public HitItemTransporter()
        {
            AWSSDKHandler.RegisterXRayForAllServices();
        }

        public async Task TransportHitItem(S3Event s3Event, ILambdaContext context)
        {
            S3EventNotificationRecord record = s3Event.Records[0];
            await Task.Run(() => { context.Logger.Log(JsonConvert.SerializeObject(record)); });
        }
    }
}
