using System;
using System.Security.Permissions;
using System.Threading;
using System.Security.Claims;
using System.IdentityModel.Services;

namespace ClaimsBasedAuthorizationCA
{
    /// <summary>
    /// Program illustrates using Claims-based authorization
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ProtectedMethod();
            //
            // Method 1. Simple access check using static method. 
            // Expect this to be most common method.
            //
            ClaimsPrincipalPermission.CheckAccess("resource", "action");

            //
            // Method 2. Programmatic check using the permission class
            // Follows model found at http://msdn.microsoft.com/en-us/library/system.security.permissions.principalpermission.aspx
            //
            var cpp = new ClaimsPrincipalPermission("resource", "action");
            cpp.Demand();

            //
            // Method 3. Access check interacting directly with the authorization manager.
            //   
            var cam = new AuthorizationManager();
            var principal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var result = cam.CheckAccess(new AuthorizationContext(principal, "000resource", "000action"));

            //
            // Method 4. Call a method that is protected using the permission attribute class
            //
                ProtectedMethod();

            Console.WriteLine("Press [Enter] to continue.");
            Console.ReadLine();
        }

        //
        // Declarative access check using the permission class. The caller must satisfy both demands.
        //
        [ClaimsPrincipalPermission(SecurityAction.Demand, Resource = "00resource", Operation = "00action")]
        [ClaimsPrincipalPermission(SecurityAction.Demand, Resource = "00resource1", Operation = "00action1")]
        static void ProtectedMethod()
        {
            Console.WriteLine("Protected Method is called");
        }
    }

    public class AuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            return base.CheckAccess(context);
        }
    }

    public class Authenticationmanager : ClaimsAuthenticationManager
    {
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            return base.Authenticate(resourceName, incomingPrincipal);
        }
    }
}
