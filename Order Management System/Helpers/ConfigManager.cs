using System;
using System.Configuration;

namespace Order_Management_System.Helpers
{
    public static class ConfigManager
    {
        public static string EmailToMultipleRecepient
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailToMultipleRecepient"].ToString();
            }
        }
    }
}
