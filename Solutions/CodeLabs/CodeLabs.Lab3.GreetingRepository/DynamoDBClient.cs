using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Newtonsoft.Json;

namespace CodeLabs.Lab3.GreetingRepository
{
    public class DynamoDBClient
    {
        private AmazonDynamoDBClient client;
        private AWSCredentials AWSCredentials;
        public DynamoDBClient()
        {
#if DEBUG
            CredentialProfile basicProfile;
            var sharedFile = new SharedCredentialsFile();
            sharedFile.TryGetProfile("ESSC_N_programmatic", out basicProfile);
            AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out AWSCredentials);

            client = new AmazonDynamoDBClient(AWSCredentials, RegionEndpoint.USWest2);
#else
            client = new AmazonDynamoDBClient();
#endif
        }

        public void CreateGreetingDetails(string tableName, GreetingDetails greetingDetails)
        {
            var table = Table.LoadTable(client, tableName);
            var jsonInput = JsonConvert.SerializeObject(greetingDetails);
            var document = Document.FromJson(jsonInput);
            var resp = table.PutItemAsync(document).GetAwaiter().GetResult();
            var test = resp;
        }
    }
}
