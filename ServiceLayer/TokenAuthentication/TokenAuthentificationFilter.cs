using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServiceLayer.TokenAuthentication
{
    public class TokenAuthentificationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _tokenManager = (ITokenManager)context.HttpContext.RequestServices.GetService(typeof(ITokenManager));
            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                var token = context.HttpContext.Request.Headers.First(cookie => cookie.Key == "Authorization").Value;
                var ClaimPrinciple = _tokenManager.GetPrincipal(token.ToString().Split(" ")[1]);
                var claimList = ClaimPrinciple.Claims.ToList();
                context.HttpContext.Items["role"] = claimList[2].Value;
                context.HttpContext.Items["userId"] = claimList[1].Value;
                context.HttpContext.Items["email"] = claimList[0].Value;
                
            }
            else
            {
                context.ModelState.AddModelError("unauthorized", "Missing token");
            }
        }
    }
}
