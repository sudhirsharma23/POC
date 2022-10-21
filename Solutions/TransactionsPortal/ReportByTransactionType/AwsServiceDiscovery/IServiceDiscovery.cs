namespace AwsServiceDiscovery
{
    public interface IServiceDiscovery
    {
        Task<ServiceDiscoveryResponse> DiscoverAsync(ServiceDiscoveryRequest request);

        //srn: "teamconnect::backendservice::hit-item-lambda"
        Task<ServiceDiscoveryResponse> DiscoverAsync(string srn);
    }
}
