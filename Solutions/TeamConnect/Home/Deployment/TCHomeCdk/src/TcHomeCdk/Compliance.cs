using Constructs;

namespace TcHomeCdk
{
    public class Compliance
    {
        private const string BAN_TAG = "BusinessApplicationNumber";
        private const string BAN_TAG_VALUE = "APM0001802";
        private const string ASN_TAG = "ApplicationServiceNumber";
        private const string ASN_TAG_VALUE = "AS0000001863";
        private const string APP_TAG = "ApplicationName";
        private const string APP_TAG_VALUE = "TeamConnect App";

        public static void Tag(IConstruct construct)
        {
            Amazon.CDK.Tags.Of(construct).Add(BAN_TAG, BAN_TAG_VALUE);
            Amazon.CDK.Tags.Of(construct).Add(ASN_TAG, ASN_TAG_VALUE);
            Amazon.CDK.Tags.Of(construct).Add(APP_TAG, APP_TAG_VALUE);
        }
    }
}
