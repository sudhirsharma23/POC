namespace AwsServiceDiscovery
{
    public class ServiceDiscoveryResponse
    {
        public ServiceDiscoveryResponse(string rid, Dictionary<string, string> atttributes)
        {
            Rid = rid;
            Attributes = atttributes;
        }

        public string Rid;
        public Dictionary<string, string> Attributes;
    }
}
