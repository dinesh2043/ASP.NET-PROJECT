using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.BusinessLayer.Interfaces;
using Ubuoy.UserAuthentication.DataLayer;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class HonorsBusinessObjects: IValidation
    {
        private GenericRepository<Honor> honorRepository;
        public List<string> ValidationSummary { get; set; }

        public HonorsBusinessObjects()
        {
            this.honorRepository = new GenericRepository<Honor>();
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
        public bool AddHonor(string name, string description, string image)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(name, description, image))
            {
                //Todo: Call the repository method to add and then to save
                honorRepository.Add(new Model.Honor() { name = name, description = description, image = image });
                honorRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }
        public bool UpdateHonor(string name, string description, string image)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(name, description, image))
            {
                //Todo: Call the repository method to add and then to save
                honorRepository.Attach(new Model.Honor() { name = name, description = description, image = image });
                honorRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }
        public void DeleteHonorById(Guid id)
        {
            honorRepository.Delete(x => x.honorId.Equals(id));
            honorRepository.SaveChanges();
        }
        public Honor GetHonorById(Guid honorId)
        {
            if (honorId != null)
            {
                var honor = honorRepository.Single(x => x.honorId.Equals(honorId));
                return honor;
            }
            else return null;

        }
    }
}