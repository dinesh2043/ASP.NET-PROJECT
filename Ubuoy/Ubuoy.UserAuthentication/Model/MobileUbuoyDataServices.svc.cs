//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace Ubuoy.UserAuthentication.Model
{
    public class MobileUbuoyDataServices : DataService<Ubuoy_DB_ModelEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            config.SetEntitySetAccessRule("User", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("User", EntitySetRights.AllWrite);

            config.SetServiceOperationAccessRule("MobileUbuoyDataServices", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;

            config.MaxResultsPerCollection = 100;
            config.MaxExpandDepth = 2;
            config.DataServiceBehavior.AcceptCountRequests = false;
            
        }

        [WebGet]
        public IQueryable<User> GetUsers()
        {
            return new MobileDataSource().Users;
        } 

        [WebInvoke]
        public bool InsertOrUpadateSomething()
        {
            return false;
        }
        
    }
}
