using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.DataLayer;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class TaskBusinessObjects
    {
        private GenericRepository<Task> taskRepository;
        public List<string> ValidationSummary { get; set; }

        public TaskBusinessObjects()
        {
            taskRepository = new GenericRepository<Task>();
            this.ValidationSummary = new List<String>();
        }
        public IEnumerable<Task> GetTaskBySkillId(Guid skillId)
        {
            if(skillId!=null){
            //return categoryRepository.Find(x=> !string.IsNullOrEmpty(x.parent)).OrderBy(x=>x.parent);
            return taskRepository.Find(x =>x.skillId.Equals(skillId));
            }else return null;
        
        }
        public IEnumerable<Task> GetTaskByCategoryId(Guid categoryId)
        {
            if (categoryId != null)
            {
                //return categoryRepository.Find(x=> !string.IsNullOrEmpty(x.parent)).OrderBy(x=>x.parent);
                return taskRepository.Find(x => x.categoryId.Equals(categoryId));
            }
            else return null;

        }

        public Task GetTaskByTaskId(Guid taskId)
        {
            if (taskId != null)
            {
                var task = taskRepository.Single(x => x.taskId.Equals(taskId));
                return task;
            }
            else return null;

        }
        public IEnumerable<Task> GetAllTsak(string parent)
        {
            if (parent != null)
            {
                // return userProjectRepository.Find(x => (x.priority.Equals(true) && x.userId.Equals(id)));
                //return categoryRepository.Find(x => !string.IsNullOrEmpty(x.parent)).Select(x=>x.parent).Distinct();
                return taskRepository.Find(x => !string.IsNullOrEmpty(x.owner)).OrderByDescending(x => x.owner);
            }
            else return null;
        }
        public IEnumerable<Task> GetLatestSixTask(string parent)
        {
            
                // return userProjectRepository.Find(x => (x.priority.Equals(true) && x.userId.Equals(id)));
                //return categoryRepository.Find(x => !string.IsNullOrEmpty(x.parent)).Select(x=>x.parent).Distinct();
                return taskRepository.Find(x => !string.IsNullOrEmpty(x.owner)).OrderByDescending(x => x.updateDate).Take(6);
           
        }
        public bool AddTask(string description, string price, DateTime endDate, Guid categoryId, Guid skillId, string userName, DateTime upDate)
        {
            //Todo: Call the repository method to add and then to save
            taskRepository.Add(new Model.Task() {description=description,money=price, deadline=endDate, categoryId=categoryId, skillId=skillId, owner=userName,updateDate=upDate, taskId = Guid.NewGuid() });
            taskRepository.SaveChanges();
            return true;
        }
        public Task GetTaskByUpdateDate(DateTime upDate)
        {
            if (upDate != null)
            {
                var task = taskRepository.Single(x => x.updateDate.Equals(upDate));
                return task;
            }
            else return null;

        }
        
       
    }
}