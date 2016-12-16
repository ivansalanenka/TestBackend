using System.Configuration;

namespace Owin.Authentication.Helpers
{
    public static class ConfigurationHelper
    {
        public static string DefaultUserName
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultUserName"] ?? "";
            }
        }

        public static bool IsAuthenticationEnabled
        {
            get
            {
                return ConfigurationManager.AppSettings["IsAuthenticationEnabled"] == null ? false : bool.Parse(ConfigurationManager.AppSettings["IsAuthenticationEnabled"]);
            }
        }

        public static string SsoUrl
        {
            get
            {
                return (ConfigurationManager.AppSettings["SsoUrl"] == null ? "" : ConfigurationManager.AppSettings["SsoUrl"].ToString());
            }
        }

        public static string ServerUrl
        {
            get
            {
                return (ConfigurationManager.AppSettings["ServerUrl"] == null ? "" : ConfigurationManager.AppSettings["ServerUrl"].ToString());
            }
        }
    }
}
