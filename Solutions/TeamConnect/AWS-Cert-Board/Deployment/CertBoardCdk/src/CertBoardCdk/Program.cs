using Amazon.CDK;

namespace CertBoardCdk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            _ = new CertBoardCdkStack(app, "CertBoardCdkStack", new StackProps
            {
            });
            var permissionsBoundaryArn = System.Environment.GetEnvironmentVariable("PermissionsBoundaryArn");

            Aspects.Of(app).Add(new PermissionsBoundary(permissionsBoundaryArn));
            _ = app.Synth();
        }
    }
}
