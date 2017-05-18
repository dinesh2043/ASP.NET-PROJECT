using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class UbuoyAuthentication
    {
        //creates an interface of a related class
       
        public bool UserExists(string Email, string Password)
        {
            //var repository = new DataLayer.UbuoyRepository();
            //if (repository.UserExists(Email, Password) == 1)
            //{
            //    return true;
            //}
            return false;
        }


        public bool RegisterUser(string Email, string Password, string FirstName, string LastName, string DOB, string Phone, string StreetAddress, string Zip, string City, string Country)
            
        {
            //var ubuoyRepository = new DataLayer.UbuoyRepository();
            //var result = ubuoyRepository.RegisterUser(Email, Password, FirstName, LastName, DOB, Phone, StreetAddress, Zip, City, Country);
            //if (result > 0) return true;
            //else return false;

            return false;
        }

        
    }
}