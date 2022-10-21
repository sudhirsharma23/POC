SET AZURE_TENANT_ID=%AZURE_TENANT_ID%
SET AZURE_DEFAULT_DURATION_HOURS=%AZURE_DEFAULT_DURATION_HOURS%

SET "AZURE_DEFAULT_PASSWORD=%~1"

aws configure set azure_default_password %AZURE_DEFAULT_PASSWORD% --profile %AWS_PROG_PROFILE%

@ECHO ON
aws configure set azure_tenant_id %AZURE_TENANT_ID% --profile %AWS_PROG_PROFILE%
aws configure set azure_app_id_uri %AZURE_APP_ID_URI% --profile %AWS_PROG_PROFILE%
aws configure set azure_default_username %AZURE_DEFAULT_USERNAME% --profile %AWS_PROG_PROFILE%
aws configure set azure_default_role_arn %AZURE_DEFAULT_ROLE_ARN% --profile %AWS_PROG_PROFILE%
aws configure set azure_default_duration_hours %AZURE_DEFAULT_DURATION_HOURS% --profile %AWS_PROG_PROFILE%
rem configure assumed role
aws configure set role_arn %AWS_ASSUMED_ROLE_ARN% --profile %AWS_ASSUMED_PROFILE%
aws configure set source_profile %AWS_PROG_PROFILE% --profile %AWS_ASSUMED_PROFILE%
aws configure set region "us-west-2" --profile %AWS_ASSUMED_PROFILE%
cmd /C aws-azure-login --no-prompt --profile %AWS_PROG_PROFILE%
rem clear the password
aws configure set azure_default_password '' --profile %AWS_PROG_PROFILE%
setlocal EnableDelayedExpansion
@ECHO ON

rem show the identity after login

aws sts get-caller-identity --profile %AWS_PROG_PROFILE%

aws sts get-caller-identity --profile %AWS_ASSUMED_PROFILE%