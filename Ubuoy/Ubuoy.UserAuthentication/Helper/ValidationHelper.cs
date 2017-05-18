using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ubuoy.UserAuthentication.Helper
{
    public static class ValidationHelper
    {

        public static string GetValidationMessage(List<string> list)
        {
            int counter = 0;
            string completeValidation = string.Empty;
            foreach(string val in list)
            {
                completeValidation += list.ElementAt(counter) + "\n";
                counter++;
            }
            return completeValidation;
        }
    }
}