using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

using Newtonsoft.Json;

using FilesAPI;
using CP.DTO;
using CP.Core.User.Impl;

namespace FilesAPI.Tests
{
    public class ValuesControllerTests
    {

        [Fact]
        public void TestGet()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/ValuesController-Get.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var context = new TestLambdaContext();
            APIGatewayProxyResponse response = lambdaFunction.FunctionHandlerAsync(request, context).GetAwaiter().GetResult();

            Assert.Equal(200, response.StatusCode);
            Assert.Equal("[\"value1\",\"value2\"]", response.Body);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);

        }

        [Fact]
        public void CanDeserializeConsumerFileDto()
        {
            var json = "{\"fastRegion\":\"QA SANDPOINT REGION\",\"regionID\":189,\"consumerFileId\":62149,\"fastFileId\":41453981,\"fastFileNumber\":\"289174\",\"firstName\":\"Feng\",\"middleName\":\"\",\"lastName\":\"Men\",\"userNameSuffix\":null,\"email\":\"FMen @firstam.com\",\"consumerType\":1,\"consumerTypeId\":0,\"businessSegment\":null,\"businessPrograms\":\"Commercial Connect -Direct,EagleStatus,Interest Bearing Account Form, Proactive Notification Activated, Target Client,Vesting,VIP,No P&C Quote Request\",\"fastBusinessSegmentID\":839,\"fileOpenDate\":null,\"transactionType\":\"Sale / Cash\",\"buyerSellerType\":48,\"escrowOfficeName\":\"QA SECURE PORTAL OFFICE\",\"isPrimary\":true,\"consumerFileStatus\":3,\"adminFileStatus\":null,\"historyId\":0,\"principalId\":80536309,\"createdOn\":\"0001 - 01 - 01T00: 00:00Z\",\"fileClosedOn\":null,\"fastFileStatus\":0,\"workPhone\":null,\"homePhone\":null,\"buisnessPhoneExtension\":null,\"mobilePhone\":null,\"existingIdaasUserStatusId\":0,\"faxNumber\":null,\"authSignatureID\":0,\"notificationPreference\":\"Email\",\"fastBuyerSellerTypeId\":48,\"eulaDate\":null,\"fileCreatedDate\":\"2018 - 06 - 20T09: 19:18Z\",\"estSettlementDate\":null,\"isFileExpired\":false,\"propertyAddressDescription\":\", AZ\",\"propertyCounty\":null,\"propertyAddressLine1\":\"\",\"propertyCity\":null,\"propertyState\":\"AZ\",\"seqNum\":1,\"identityId\":\"a8e44a66-db6e-4ec5-b0c3-8bf3c3772ac9\",\"buid\":14098,\"state\":\"AZ\",\"lastProfileUpdateDate\":\"2018-06-20T10:53:30.81\",\"accountCreatedDate\":\"2018-06-20T10:53:30.81\",\"showSecondaryESign\":false,\"showFeedback\":false,\"documentName\":null,\"envelopeToBeESigned\":null,\"role\":\"Buyer\",\"unreadDocCount\":-1,\"unreadMsgCount\":-1,\"secEsignCount\":-1,\"cssClass\":\"First - American - brand\",\"viewStatus\":\"Open\",\"fileType\":null,\"isAutoRegistrationEligible\":false,\"registrationType\":0,\"isReAgent\":false,\"loggedInUserConsumerFileId\":0,\"fileBusinessPartyID\":null,\"dateOfRegistration\":null,\"busOrgId\":null,\"contactId\":null,\"isAdHocContact\":null,\"lastFileAccessDate\":\"2021-09-16T02:06:47.58\",\"shortName\":null,\"additionalContactId\":null,\"qaCompleted\":false,\"qaDisabled\":false,\"name\":\"Men\",\"landedToDashBoard\":8,\"loggedInUserFirstName\":\"Feng\",\"gabCode\":null,\"dataCollectionStarted\":false,\"createdBy\":null,\"dupeConsumerFile\":0,\"achOptOut\":false}";

            var obj = JsonConvert.DeserializeObject<ConsumerFileDto>(json);

            Assert.Equal("QA SANDPOINT REGION", obj.FASTRegion);

            var array = Mock.GetConsumerFileDtoList();

            Assert.True(array.Count() > 1);
            Assert.Equal("QA SANDPOINT REGION", array[0].FASTRegion);
        }
    }
}
