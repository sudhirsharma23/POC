using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using AwsServiceDiscovery;
using Report.TransactionType.Common;
using System;
using System.Threading.Tasks;

namespace Report.TransactionType.Repo.Impl
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class TransactionTypeReportDynamoDBRepo : ITransactionTypeReportRepo
    {
        private AmazonDynamoDBClient client;
        private AWSCredentials AWSCredentials;
        private readonly string tableName;

        public TransactionTypeReportDynamoDBRepo()
        {
            //IServiceDiscovery sd = new CloudMapAdapter();
            //ServiceDiscoveryResponse response = sd.DiscoverAsync(new ServiceDiscoveryRequest("teamconnect::backend::items-table")).GetAwaiter().GetResult();
            //tableName = response.Rid;
            //Console.WriteLine($"tableName:{tableName}");
            tableName = Environment.GetEnvironmentVariable("Report_Table_Name");
            client = GetClient();
        }

        private AmazonDynamoDBClient GetClient()
        {
#if DEBUG
            var sharedFile = new SharedCredentialsFile();
            sharedFile.TryGetProfile(Environment.GetEnvironmentVariable("Programmatic_Role"), out CredentialProfile basicProfile);
            AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out AWSCredentials);

            client = new AmazonDynamoDBClient(AWSCredentials, RegionEndpoint.USWest2);

#else
            client = new AmazonDynamoDBClient();
#endif
            return client;
        }

        public async Task<ReportItem> GetReportItemByDateAsync(DateTime date)
        {
            var dateKey = Helper.GetDateKey(date);
            var table = Amazon.DynamoDBv2.DocumentModel.Table.LoadTable(client, tableName);
            Amazon.DynamoDBv2.DocumentModel.Document item = await table.GetItemAsync(dateKey, dateKey);
            DocumentReportItem docItem = item == null ? null : Newtonsoft.Json.JsonConvert.DeserializeObject<DocumentReportItem>(item.ToJson());
            return docItem?.Item;
        }

        //public async Task<ReportItem> GetReportItemByDateAsync_2(DateTime date)
        //{
        //    var dateKey = Helper.GetDateKey(date);
        //    var key = new Dictionary<string, AttributeValue>
        //    {
        //        {"ID", new AttributeValue{ S=dateKey} }
        //    };
        //    var request = new GetItemRequest()
        //    {
        //        TableName = tableName,
        //        Key = key
        //    };
        //    GetItemResponse resp = await client.GetItemAsync(request);
        //    foreach(KeyValuePair<string, AttributeValue> kv in resp.Item)
        //    {
        //        if (kv.Key.Equals("Item"))
        //        {
        //            DocumentReportItem docItem = new DocumentReportItem();
        //            docItem.ID = dateKey;
        //            docItem.Item = new ReportItem
        //            {
        //                Title = kv.Value.M["Title"].S,
        //                DataItems = kv.Value.M["DataItems"].SS
        //            }
        //            DocumentReportItem docItem = Newtonsoft.Json.JsonConvert.DeserializeObject<DocumentReportItem>(kv.Value.M);
        //            return docItem.Item;
        //        }

        //    }

        //    throw new Exception($"Item {dateKey} is not found");
        //}
    }
}
