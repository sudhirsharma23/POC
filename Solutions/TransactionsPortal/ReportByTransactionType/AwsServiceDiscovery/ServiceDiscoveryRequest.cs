namespace AwsServiceDiscovery
{
    public class ServiceDiscoveryRequest
    {
        // srn sample: teamconnect::backend::hit-item-lambda
        public ServiceDiscoveryRequest(string srn) : this(srn, new Dictionary<string, string>())
        {

        }

        public ServiceDiscoveryRequest(string srn, Dictionary<string, string> parameter)
        {
            if (string.IsNullOrEmpty(srn))
            {
                throw new ArgumentException("Namesapce is Required");
            }
            ServiceResourceName = srn;
            var srnArray = srn.Split("::");
            if (srnArray.Length <= 1)
            {
                throw new ArgumentException("Service Name is Required");
            }
            Namespace = srnArray[0];
            ServiceName = srnArray[1];
            if (srnArray.Length > 2)
            {
                Instance = srnArray[2];
            }
            queryParameters = parameter;
        }
        public string ServiceResourceName;
        public string Namespace;
        public string? ServiceName;
        public string? Instance;
        public Dictionary<string, string> queryParameters;
    }
}