using Amazon.CDK;
using System;
using System.Collections.Generic;

namespace TransactionPortalCdk
{
    internal sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            _ = new TransactionPortalCdkStack(app, "TransactionPortalCdkStack", new StackProps
            {
                Tags = new Dictionary<string, string>
                {
                    { CommonValues.ASN_TAG, CommonValues.ASN_TAG_VALUE },
                    { CommonValues.BAN_TAG, CommonValues.BAN_TAG_VALUE }
                }
            });


            Aspects.Of(app).Add(new PermissionsBoundary(string.Empty));

            _ = app.Synth();

            Console.WriteLine(System.Environment.GetEnvironmentVariable("HitItemTransporterLambdazip"));
        }
    }
}
