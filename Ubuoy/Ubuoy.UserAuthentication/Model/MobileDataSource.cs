using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Services;
using System.Data;
using System.Configuration;


namespace Ubuoy.UserAuthentication.Model
{

    public class MobileDataSource
    {
        public IQueryable<User> Users 
        {
            get
            {
                return new GenericRepository<User>().Fetch().AsQueryable();
            }
        
        }
       
    }
    
}