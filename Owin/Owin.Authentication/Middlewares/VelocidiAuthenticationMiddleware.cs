using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Owin.Authentication;
using Owin.Authentication.Helpers;
using Owin.Authentication.VelocidiAuthService;
using Microsoft.Owin;


namespace Owin.Authentication.Middlewares
{
    public class VelocidiAuthenticationMiddleware : OwinMiddleware
    {
        private readonly string SSO_URL_PATTERN = "{0}?finalUrl={1}";
        private readonly string AUTHSERVICE_URL_PATTERN = "{0}/_vti_bin/AuthService.asmx";

        private readonly string AUTHETICATION_COOKIES_NAME = "capUser";
        private readonly string AUTHORIZATION_COOKIES_NAME = "capAuthorized";

        public VelocidiAuthenticationMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            if (context.Request.Headers.ContainsKey("GetItFree"))
            {
                context.Environment.Add("CapUserName", Uri.UnescapeDataString(context.Request.Headers["UserName"]));
                return Next.Invoke(context);
            }
            if (ConfigurationHelper.IsAuthenticationEnabled)
            {
                var cookie = context.Request.Headers["Cookie"];

                if (cookie != null)
                {
                    var cookieString = context.Request.Headers.GetValues("Cookie").FirstOrDefault();
                    if (GetAuthCookieValue(AUTHETICATION_COOKIES_NAME, ref cookieString))
                    {
                        ScoutSSOCommon.UserInfo userInfo = ScoutSSODecode.ScoutSSODecode.GetUserInfo(cookieString);

                        if (userInfo != null)
                        {
                            if (IsSharepointAuthorized(context, userInfo))
                            {
                                context.Environment.Add("CapUserName", userInfo.Username);
                                return Next.Invoke(context);
                            }
                            else
                            {
                                return context.Response.WriteAsync("unauthorized");
                            }
                        }
                    }
                }

                return Redirect(context);
            }
            else
            {
                context.Environment.Add("CapUserName", ConfigurationHelper.DefaultUserName);
                return Next.Invoke(context);
            }
        }

        private bool IsSharepointAuthorized(IOwinContext context, ScoutSSOCommon.UserInfo userInfo)
        {
            var oldCookie = context.Request.Cookies[AUTHORIZATION_COOKIES_NAME];
            var newCookie = GetAuthorizationCookieValue();

            if (string.IsNullOrEmpty(oldCookie) && newCookie == oldCookie)
            {
                return true;
            }
            else
            {
                var strURI = ConfigurationHelper.ServerUrl;

                AuthService objAuthService = new AuthService();
                objAuthService.Url = String.Format(AUTHSERVICE_URL_PATTERN, strURI);

                if (objAuthService.IsAuthorized(userInfo.ClaimsUsername, context.Request.Uri.AbsoluteUri))
                {
                    context.Response.Cookies.Append(AUTHORIZATION_COOKIES_NAME, newCookie);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private string GetAuthorizationCookieValue()
        {
            SHA256 SHA256 = SHA256Managed.Create();
            byte[] bArray = BitConverter.GetBytes(DateTime.Now.Date.Ticks);
            var hash = SHA256.ComputeHash(bArray);

            return System.Text.Encoding.Default.GetString(hash);
        }

        private void RedirectToSsoPage(IOwinContext context)
        {
            var redirectTo = ConfigurationHelper.SsoUrl;
            var finalUrl = context.Request.Uri;
            context.Response.Redirect(string.Format(SSO_URL_PATTERN, redirectTo, finalUrl));
        }

        private Task Redirect(IOwinContext context)
        {
            RedirectToSsoPage(context);
            return context.Response.WriteAsync("Redirecting..");
        }

        private bool GetAuthCookieValue(string capUserCookieName, ref string cookie)
        {
            string[] strCookies = cookie.Split(';');

            foreach (string strItem in strCookies)
            {

                int iIndex = strItem.IndexOf(String.Format("{0}=", capUserCookieName));
                if (iIndex >= 0)
                {
                    cookie = strItem.Substring(iIndex + 8, (strItem.Length - iIndex) - 8);
                    return true;
                }
            }
            return false;
        }
    }
}
