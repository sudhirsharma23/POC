// Credentials
variable "provideRegion" {
  type    = string
  default = "us-west-2"
}

variable "provideProfile" {
  type = string
  default = ""
}

variable "applicationTag" {
  type = map(string)
  default =  {
    ApplicationServiceNumber  = "AS0000001863"
    BusinessApplicationNumber = "APM0001802"
  }
}

// table settigns
variable "tableName" {
  type = string
  default = "big-table"
}

variable "billingMode" {
  type = string
  default = "PAY_PER_REQUEST"
}

variable "partitionkeyNameCol" {
  type = string
  default = "PK"
}

variable "sortkeyNameCol" {
  type = string
  default = "SK"
}

variable "msgNameCol" {
  type = string
  default = "greetings"
}
