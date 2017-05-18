using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class UsersTaskBusinessObjects
    {
        private GenericRepository<UsersTask> userTaskRepository;
        public List<string> ValidationSummary { get; set; }

        public UsersTaskBusinessObjects()
        {
            userTaskRepository = new GenericRepository<UsersTask>();
            this.ValidationSummary = new List<String>();
        }
        public IEnumerable<UsersTask> GetUserTaskById(Guid id)
        {
           // return userProjectRepository.Find(x => (x.priority.Equals(true) && x.userId.Equals(id)));
            return userTaskRepository.Find(x => x.taskId.Equals(id));
            
        }
        public UsersTask GetAUserTaskById(Guid id)
        {
            // return userProjectRepository.Find(x => (x.priority.Equals(true) && x.userId.Equals(id)));
            return userTaskRepository.Single(x => x.taskId.Equals(id));

        }
        public bool AddUsersTask(Guid userId, Guid taskId)
        {
            if (userId != null && taskId != null)
            {
                //Todo: Call the repository method to add and then to save
                userTaskRepository.Add(new Model.UsersTask() { taskId = taskId, userId = userId, userTaskId = Guid.NewGuid() });
                userTaskRepository.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}