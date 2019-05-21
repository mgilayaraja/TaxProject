using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using WebApiProject.Models;
using System.Web.Mvc;
using TaxProject.Core.IService;
using TaxProject.Core.Models;

namespace WebApiProject.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var _userService = DependencyResolver.Current.GetService<IUserService>();
            bool isValidUser = _userService.IsValidUser(context.UserName, context.Password);

            if (isValidUser)
            {
                Users users = _userService.GetUsersDetailsByUserName(context.UserName);

                if (users != null)
                {
                    users.Password = string.Empty;

                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("userId", users.UserId.ToString()));
                    identity.AddClaim(new Claim("username", context.UserName));
                    identity.AddClaim(new Claim("password", context.Password));
                    await Task.Run(() => context.Validated(identity));
                }
                else
                {
                    context.SetError("You are not registered with us.");
                    return;
                }
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}