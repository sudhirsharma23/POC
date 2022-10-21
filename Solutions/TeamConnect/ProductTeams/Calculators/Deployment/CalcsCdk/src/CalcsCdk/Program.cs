using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalcsCdk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new CalcsCdkStack(app, "CalcsCdkStack", new StackProps
            {
                Tags = new Dictionary<string, string>
                {
                   {Compliance.BAN_TAG, Compliance.BAN_TAG_VALUE },
                   {Compliance.ASN_TAG, Compliance.ASN_TAG_VALUE },
                   {Compliance.APP_TAG, Compliance.APP_TAG_VALUE }
                }
            };
            var permissionsBoundaryArn = System.Environment.GetEnvironmentVariable("PermissionsBoundaryArn");
            Aspects.Of(app).Add(new PermissionsBoundary(permissionsBoundaryArn));
            _ = app.Synth();
        }
    }
}
