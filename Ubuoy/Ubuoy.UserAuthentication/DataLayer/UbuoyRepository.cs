using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ubuoy.UserAuthentication.DataLayer
{
    public class UbuoyRepository
    {
    //    public int UserExists(string userEmail, string userPassword)
    //    {
    //        using(var context = new ModelDataContext())
    //        {
    //            var authentication = context.GetTable<User>();
    //            var result = from row in authentication
    //                         where row.email.Equals(userEmail) && row.password.Equals(userPassword)
    //                         select row;
    //            return result.Count();
    //        }
    //    }

    //    public int RegisterUser(string Email, string Password, string FirstName, string LastName, string DOB, string Phone, string StreetAddress, string Zip, string City, string Country)
    //    {
    //        using (var context = new ModelDataContext())
    //        {
    //            var userRegitration = context.GetTable<User>();
    //            var newUser = new User()
    //                                {
    //                                      userId = Guid.NewGuid(),
    //                                      email = Email,
    //                                      password = Password,
    //                                      firstName = FirstName,
    //                                      lastName = LastName,
    //                                      DOB = DateTime.Parse(DOB),
    //                                      phoneNumber = Phone
    //                                };
    //                                     /** userStreetAddress = StreetAddress,
    //                                      userZip = Zip,
    //                                      userCity = City,
    //                                      userCountry = Country**/
                                         
                                    

    //            userRegitration.InsertOnSubmit(newUser);
    //            context.SubmitChanges();
    //            return 1;
                
    //        }

    //        return -1;   
    //    }
    //
    }
}
