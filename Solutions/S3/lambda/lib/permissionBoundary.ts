import * as cdk from 'aws-cdk-lib';
import { Construct, IConstruct } from 'constructs';

export class PermissionsBoundary implements cdk.IAspect {
  private readonly permissionsBoundaryArn: string;

  constructor(permissionBoundaryArn: string) {
      this.permissionsBoundaryArn = permissionBoundaryArn;
  }

  public visit(node: IConstruct): void {
      if (cdk.CfnResource.isCfnResource(node) && node.cfnResourceType === 'AWS::IAM::Role') {
          node.addPropertyOverride('PermissionsBoundary', this.permissionsBoundaryArn);
      }
  }
}