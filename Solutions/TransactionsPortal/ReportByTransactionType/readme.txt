under Solutions\TransactionsPortal\ReportByTransactionType

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=C:\Users\fmen\TestCoverage\cobertura.coverage.xml --settings:Report.TransactionType.Service.UnitTests/unit.runsettings
reportgenerator -reports:"C:\Users\fmen\TestCoverage\cobertura.coverage.xml" -targetdir:"C:\Users\fmen\TestCoverage\Report" -reporttypes:Html


dotnet lambda deploy-function --function-layers arn:aws:lambda:us-west-2:638844603513:layer:aws-sdk-api-dynamodb-sqs-libs-optimized:5 --msbuild-parameters -p:PublishReadyToRun=true