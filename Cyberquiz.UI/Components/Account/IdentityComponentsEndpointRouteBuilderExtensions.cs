using Cyberquiz.UI.Components.Account.Pages;
using Cyberquiz.UI.Components.Account.Pages.Manage;
using Cyberquiz.UI.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace Microsoft.AspNetCore.Routing
{
    internal static class IdentityComponentsEndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapAdditionalIdentityEndpoints(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            var accountGroup = endpoints.MapGroup("/Account");

            // ✅ LÄGG TILL: Logout endpoint med redirect till home
            accountGroup.MapPost("/Logout", async (
                ClaimsPrincipal user,
                SignInManager<ApplicationUser> signInManager,
                [FromForm] string returnUrl) =>
            {
                await signInManager.SignOutAsync();
                
                // ✅ Redirect till home eller login efter logout
                return TypedResults.LocalRedirect("/");  // eller "/login"
            });

            // Övriga endpoints...
            return accountGroup;
        }
    }
}
