namespace Owin.Run
{
    public static class ConfigurationManager
    {
        public static string Url
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Url"] ?? "http://localhost:12345";
            }
        }

        public static string ClientFolder
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ClientFolder"] ?? "./ui";
            }
        }
    }
}
