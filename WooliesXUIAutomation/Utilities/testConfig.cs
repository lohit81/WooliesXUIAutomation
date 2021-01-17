using System.Configuration;


namespace WooliesXUIAutomation.Utilities
{
    public class testConfig
    {
        public static string envUrl, envType;

        static string UrlProperty
        {
            get
            {
                return envType;
            }
            set
            {
                envType = value;
            }
        }

        //private static string UserName { get; set; }
        //private static string Password { get; set; }

        /// <summary>
        /// To get environemnt and select the URL
        /// </summary>
        /// <returns></returns>
        public string getBaseUrl()
        {
            //var baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            envType = ConfigurationManager.AppSettings["envName"];

            if (UrlProperty == "uat")
            {
                envUrl = "https://responsivefight.herokuapp.com/";

            }
            else if (UrlProperty == "preProd")
            {
                envUrl = "https://responsivefight.herokuapp.com/prePROD"; // dummy link show pre production link
                return envUrl;
            }
            else
            {
                envUrl = "https://responsivefight.herokuapp.com/dev"; // dummy link shows DEV env
            }

            return envUrl;
        }



    }
}

