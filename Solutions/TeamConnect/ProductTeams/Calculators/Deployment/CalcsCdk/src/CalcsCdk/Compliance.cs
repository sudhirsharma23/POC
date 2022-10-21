using Constructs;

namespace CalcsCdk
{
    public class Compliance
    {
        public const string BAN_TAG = "BusinessApplicationNumber";
        public const string BAN_TAG_VALUE = "APM0001802";
        public const string ASN_TAG = "ApplicationServiceNumber";
        public const string ASN_TAG_VALUE = "AS0000001863";
        public const string APP_TAG = "ApplicationName";
        public const string APP_TAG_VALUE = "TeamConnect Website";

        public static void Tag(IConstruct construct)
        {
            Amazon.CDK.Tags.Of(construct).Add(BAN_TAG, BAN_TAG_VALUE);
            Amazon.CDK.Tags.Of(construct).Add(ASN_TAG, ASN_TAG_VALUE);
            Amazon.CDK.Tags.Of(construct).Add(APP_TAG, APP_TAG_VALUE);
        }
    }
}
