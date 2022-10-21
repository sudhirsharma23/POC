provider "aws" {
  region = var.provideRegion
  profile = var.provideProfile
}

resource "aws_dynamodb_table" "dynamodb-big-table" {
  name           = var.tableName
  billing_mode   = var.billingMode         // We recommend using PAY_PER_REQUEST for unpredictable workloads
  hash_key       = var.partitionkeyNameCol // Partition key: String type
  range_key      = var.sortkeyNameCol      // Sort key: String type
  tags           = var.applicationTag      // Tags to identify the application

  attribute {
    name = var.partitionkeyNameCol
    type = "S"
  }
  attribute {
    name = var.sortkeyNameCol
    type = "S"
  }
}