using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class UserModulesBusinessObjects
    {
        private GenericRepository<UserModule> userModuleRepository;
        public List<string> ValidationSummary { get; set; }

        public UserModulesBusinessObjects()
        {
            this.userModuleRepository = new GenericRepository<UserModule>();
            this.ValidationSummary = new List<string>();
        }
        public IEnumerable<UserModule> GetUserModuleByUserId(Guid id)
        {
            // return userProjectRepository.Find(x => (x.priority.Equals(true) && x.userId.Equals(id)));
            return userModuleRepository.Find(x => x.userId.Equals(id));

        }
    }
}