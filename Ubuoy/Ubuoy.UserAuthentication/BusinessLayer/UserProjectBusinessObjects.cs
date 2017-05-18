using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class UserProjectBusinessObjects
    {
        private GenericRepository<UserProject> userProjectRepository;
        public List<string> ValidationSummary { get; set; }

        public UserProjectBusinessObjects()
        {
            userProjectRepository = new GenericRepository<UserProject>();
            this.ValidationSummary = new List<String>();
        }
        public IEnumerable<UserProject> GetUserProjectsById(Guid id)
        {
           // return userProjectRepository.Find(x => (x.priority.Equals(true) && x.userId.Equals(id)));
            return userProjectRepository.Find(x =>x.userId.Equals(id));
            
        }
        public bool AddUsersProject(Guid userId, Guid projectId, bool por)
        {
            if (userId != null && projectId != null)
            {
                //Todo: Call the repository method to add and then to save
                userProjectRepository.Add(new Model.UserProject() { projectId = projectId, userId = userId, priority=por, userProjectId = Guid.NewGuid() });
                userProjectRepository.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}