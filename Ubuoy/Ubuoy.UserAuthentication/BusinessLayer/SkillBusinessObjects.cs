using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.DataLayer;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class SkillBusinessObjects
    {
        private GenericRepository<Skill> skillRepository;
        public List<string> ValidationSummary { get; set; }

        public SkillBusinessObjects()
        {
            skillRepository = new GenericRepository<Skill>();
            this.ValidationSummary = new List<String>();
        }
    

        public IEnumerable<string> GetListOfSkills(string p)
        {
        return skillRepository.Find(x => !string.IsNullOrEmpty(x.skillName)).OrderByDescending(x => x.skillName).Select(x => x.skillName).Distinct();

        }
        public IEnumerable<Skill> GetLatestSixSkills(string p)
        {
            return skillRepository.Find(x => !string.IsNullOrEmpty(x.skillName)).OrderByDescending(x => x.updateDate).Take(6);

        }

      
        //public List<Skill> GetSkill()
        //{
          //  skillRepository = new GenericRepository<Skill>();
          //  this.ValidationSummary = new List<String>();
        //}

        public IEnumerable<Skill> GetSkillsById(Guid id)
        {
            return skillRepository.Find(x => x.categoryId.Equals(id));
        }

        public bool AddSkill(string skillName, string description, Guid categoryId, Guid userId, string image,DateTime upDate)
        {
            //Todo: Call the repository method to add and then to save
            skillRepository.Add(new Model.Skill() { skillName = skillName, description = description, categoryId = categoryId, userId = userId, image = image, updateDate = upDate,skillId = Guid.NewGuid() });
            skillRepository.SaveChanges();
            return true;
            
        }

        internal IEnumerable<Skill> GetSkillByCategoryId(Guid categoryId)
        {
            if (categoryId != null)
            {
                //return categoryRepository.Find(x=> !string.IsNullOrEmpty(x.parent)).OrderBy(x=>x.parent);
                return skillRepository.Find(x => x.categoryId.Equals(categoryId));
            }
            else return null;
        }
        public Skill GetTaskByUpdateDate(DateTime upDate)
        {
            if (upDate != null)
            {
                var skill = skillRepository.Single(x => x.updateDate.Equals(upDate));
                return skill;
            }
            else return null;

        }
    }
}