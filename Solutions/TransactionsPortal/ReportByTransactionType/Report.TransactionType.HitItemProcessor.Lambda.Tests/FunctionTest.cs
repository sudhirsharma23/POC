using Xunit;
using Amazon.Lambda.TestUtilities;

namespace Report.TransactionType.HitItemProcessor.Lambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {
            // Invoke the lambda function and confirm the string was upper cased.
            var function = new HitItemProcessor();
            var context = new TestLambdaContext();
            function.ProcessHitItem(new Amazon.Lambda.SQSEvents.SQSEvent(), context).GetAwaiter().GetResult();
        }
    }
}
