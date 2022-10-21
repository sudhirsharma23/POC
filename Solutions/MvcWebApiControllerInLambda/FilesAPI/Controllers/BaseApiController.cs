using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace FilesAPI
{
    public abstract class BaseApiController : ControllerBase
    {
        public Guid IdentityAsGuid => Guid.Parse(Identity);

        public string Identity
        {
            get
            {
                if(ClaimsPrincipal.Current == null)
                {
                    return "a8e44a66-db6e-4ec5-b0c3-8bf3c3772ac9";
                }

                var identity = (ClaimsIdentity)ClaimsPrincipal.Current.Identity;
                if (identity != null && identity.Claims != null)
                {
                    Debug.WriteLine(identity.BootstrapContext);
                    var claimIdentity = identity.Claims.FirstOrDefault(x => x.Type.CompareTo(@"AzureObjectID") == 0);
                    if (null != claimIdentity)
                    {
                        return claimIdentity.Value;
                    }

                    //employee sign in
                    var idaaSID = identity.Claims.FirstOrDefault(x => x.Type.CompareTo(@"IDaaSID") == 0);
                    if (idaaSID != null)
                    {
                        return idaaSID.Value;
                    }
                }
                return null;
            }
        }

        public string Username
        {
            get
            {
                if(ClaimsPrincipal.Current == null)
                {
                    return "local-tester";
                }

                var identity = (ClaimsIdentity)ClaimsPrincipal.Current.Identity;                
                if (identity != null && identity.Claims != null)
                {
                    Debug.WriteLine(identity.BootstrapContext);
                    var userName = identity.Claims.FirstOrDefault(x => x.Type.CompareTo(@"UserName") == 0);
                    if (null != userName)
                    {
                        return userName.Value;
                    }
                }
                return null;
            }
        }

        public bool IsNewUser
        {
            get
            {
                bool isNewUser = ClaimsPrincipal.Current.HasClaim(c => c.Type.CompareTo("newUser") == 0)
                    && ClaimsPrincipal.Current.FindFirst("newUser")?.Value?.CompareTo("true") == 0;
                return isNewUser;
            }
        }

        protected string CheckAvailable()
        {
            return "API IS UP AND RUNNING !!!";
        }
    }
}