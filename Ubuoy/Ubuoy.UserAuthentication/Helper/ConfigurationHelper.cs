using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.IO;

namespace Ubuoy.UserAuthentication.Helper
{
    public static class ConfigurationHelper
    {
        public static string ReadFromWebConfiguration(string fileLink)
        {
            fileLink = WebConfigurationManager.AppSettings[fileLink].ToString();
            return fileLink;
        }

        public static void AddImageToFile(Byte[] bytes, string path)
        {
            if (bytes != null)
            {
                File.WriteAllBytes(path, bytes);
            }
        }
    }
}