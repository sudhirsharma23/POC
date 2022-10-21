using Amazon.CDK;
using System.Collections.Generic;

namespace TcCloudMapCdk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            _ = new TcCloudMapCdkStack(app, "TcCloudMapCdkStack", new StackProps
            {
                Env = new Environment
                {
                    Region = System.Environment.GetEnvironmentVariable("Region"),
                    Account = System.Environment.GetEnvironmentVariable("Account")
                },
                Tags = new Dictionary<string, string>
                {
                   {Compliance.BAN_TAG, Compliance.BAN_TAG_VALUE },
                   {Compliance.ASN_TAG, Compliance.ASN_TAG_VALUE },
                   {Compliance.APP_TAG, Compliance.APP_TAG_VALUE }
                }
            });
            var permissionsBoundaryArn = System.Environment.GetEnvironmentVariable("PermissionsBoundaryArn");
            Aspects.Of(app).Add(new PermissionsBoundary(permissionsBoundaryArn));
            _ = app.Synth();
        }
    }
}
