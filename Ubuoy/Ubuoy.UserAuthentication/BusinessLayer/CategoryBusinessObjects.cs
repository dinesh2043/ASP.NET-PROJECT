using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.BusinessLayer.Interfaces;
using Ubuoy.UserAuthentication.DataLayer;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class CategoryBusinessObjects: IValidation
    {
        private GenericRepository<Category> categoryRepository;
        public List<String> ValidationSummary { get; set; }

        public CategoryBusinessObjects()
        {
            this.categoryRepository = new GenericRepository<Category>();
            this.ValidationSummary = new List<string>();
        }
        public bool IsHavingValidInputs(params object[] inputs)
        {
            bool isValid = true;
            var requiredElements = new object[] { inputs[0], inputs[1], inputs[2] };

            if (!RequiredElementsInPlace(requiredElements))
            {
                ValidationSummary.Add("All fields are required");
                isValid = false;
            }

            return isValid;
        }
        private bool RequiredElementsInPlace(object[] inputs)
        {
            foreach (var input in inputs)
            {
                if (string.IsNullOrEmpty(input.ToString()))
                    return false;
            }
            return true;
        }
        public bool AddCategory(string name, string description, string image)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(name, description, image))
            {
                //Todo: Call the repository method to add and then to save
                categoryRepository.Add(new Model.Category() { Name=name, Description=description, image = image });
                categoryRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }
        public bool UpdateCategory(string name, string description, string image)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(name, description, image))
            {
                //Todo: Call the repository method to add and then to save
                categoryRepository.Attach(new Model.Category() { Name = name, Description = description, image = image });
                categoryRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }
        public void DeleteCategoryById(Guid id)
        {
            categoryRepository.Delete(x => x.categoryId.Equals(id));
            categoryRepository.SaveChanges();
        }
        public Category GetCategoryById(Guid categoryId)
        {
            if (categoryId != null)
            {
                var category = categoryRepository.Single(x => x.categoryId.Equals(categoryId));
                return category;
            }
            else return null;

        }
        public IEnumerable<Category> GetCategoryAccordingToParent(string parent)
        {
            // return userProjectRepository.Find(x => (x.priority.Equals(true) && x.userId.Equals(id)));
            //return categoryRepository.Find(x => !string.IsNullOrEmpty(x.parent)).Select(x=>x.parent).Distinct();
            return categoryRepository.Find(x=> !string.IsNullOrEmpty(x.parent)).OrderBy(x=>x.parent);
        }
        
        public IEnumerable<string> GetDetailCategoryAccordingToParent(string p)
        {
            return categoryRepository.Find(x => !string.IsNullOrEmpty(x.parent)).OrderBy(x=>x.parent).Select(x => x.parent).Distinct();

        }
    }
    }
