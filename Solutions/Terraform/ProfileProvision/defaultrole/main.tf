provider "aws" {
  region  = "us-west-2"
  profile = "TMCT_programmatic"  
}

resource "aws_iam_role" "role" {
  
  name                 = "TMCT_role"
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
    type = "AWS"
    identifiers = ["arn:aws:iam::638844603513:role/FirstAm_TMCT-N-1_AppDevRole",
    "arn:aws:iam::638844603513:role/FirstAm_TMCT-N-1_ProgrammaticRole"]
  }
}
}

resource "aws_iam_policy" "this" { 
  name        = "tmct-role-policy"
  description = "tmct-role-policy"
  policy =  data.aws_iam_policy_document.this.json

}
 
 resource "aws_iam_role_policy_attachment" "attach_policy" {
  role       = "${aws_iam_role.role.name}"
  policy_arn = "${aws_iam_policy.this.arn}"
 }
 
 data "aws_iam_policy_document" "this" {
  statement {
    sid    = "AllowApprovedResources"
    effect = "Allow"
    actions = [
"ec2:*",
"s3:*",
"kms:*",
"dynamodb:*",
"iam:*",
"elasticloadbalancing:*",
"acm:*",
"rds:*",
"lambda:*","elasticbeanstalk:*","cloudformation:*","logs:*","cloudwatch:*","apigateway:*","sts:AssumeRole"
    ]
    resources = ["*"]
  }
 
}
  
