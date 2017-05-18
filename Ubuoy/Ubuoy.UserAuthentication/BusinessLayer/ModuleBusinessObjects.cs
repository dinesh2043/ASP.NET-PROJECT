using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.Model;


namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class ModuleBusinessObjects
    {
        private GenericRepository<Module> moduleRepository;
        public List<string> ValidationSummary { get; set; }
   
     public ModuleBusinessObjects()
        {
            this.moduleRepository = new GenericRepository<Module>();
            this.ValidationSummary = new List<string>();
        }
     public Module GetModuleOfUserId(Guid id)
     {
         return moduleRepository.Single(x => x.moduleId.Equals(id));
     }
    }
}