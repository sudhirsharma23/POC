provider "aws" {
  region  = "us-west-2"
  profile = "TMCT_role"
}

resource "aws_iam_role" "Lambdarole" {

  name                 = "TMCT_LambdaDynamoDBSQS"
  permissions_boundary = "arn:aws:iam::638844603513:policy/CAVM/FirstAm-GlobalPermissionsBoundary"
  assume_role_policy   = data.aws_iam_policy_document.this_role_assume_role_policy.json
  tags = {
    ApplicationId   = "APP0005161"
    ApplicationName = "TMCT"
    EnvironmentName = "Dev"
  }
}

data "aws_iam_policy_document" "this_role_assume_role_policy" {
  statement {
    actions = ["sts:AssumeRole"]

    principals {
      type        = "Service"
      identifiers = ["lambda.amazonaws.com","apigateway.amazonaws.com"]
    }
   

  }
}

 resource "aws_iam_role_policy_attachment" "role-policy-attachment" {
  role       = "${aws_iam_role.Lambdarole.name}"
  count      = "${length(var.Lambda_iam_policy_arn)}"
  policy_arn = "${var.Lambda_iam_policy_arn[count.index]}"
}

variable "Lambda_iam_policy_arn"{}
 