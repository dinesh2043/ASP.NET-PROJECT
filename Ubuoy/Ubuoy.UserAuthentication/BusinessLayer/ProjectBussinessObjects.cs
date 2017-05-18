using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.BusinessLayer.Interfaces;
using Ubuoy.UserAuthentication.DataLayer;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class ProjectBussinessObjects
    {
        private GenericRepository<Project> projectRepository;
        public List<string> ValidationSummary { get; set; }

        public ProjectBussinessObjects()
        {
            projectRepository = new GenericRepository<Project>();
            this.ValidationSummary = new List<String>();
        }
        public Project GetProjectById(Guid id)
        {
            return projectRepository.Single(x => x.projectId.Equals(id));
        }
        public IEnumerable<Project> GetAllProject(string p)
        {
            return projectRepository.Find(x => !string.IsNullOrEmpty(x.description)).OrderByDescending(x => x.updateDate);
        }
        public IEnumerable<Project> GetLatestSixProject(string p)
        {
            return projectRepository.Find(x => !string.IsNullOrEmpty(x.description)).OrderByDescending(x => x.updateDate).Take(6);
        }
        public bool AddProject(string description, DateTime startDate, DateTime endDate, Int64 budget, Int64 recived, Guid orgId, DateTime upDate)
        {
                //Todo: Call the repository method to add and then to save
                projectRepository.Add(new Model.Project() { description = description, startedOn = startDate , endOn = endDate, budget = budget, recived = recived, organizationId = (Guid) orgId,updateDate = upDate, projectId = Guid.NewGuid()});
                projectRepository.SaveChanges();
                return true;
        }
        public bool UpdateProject(Project project)
        {
            //Todo: Call the repository method to add and then to save
            projectRepository.Attach(project);
            projectRepository.SaveChanges();
            return true;
        }
            
        }
        
    }
