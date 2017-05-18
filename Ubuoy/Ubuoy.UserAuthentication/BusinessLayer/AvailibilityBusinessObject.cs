using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.BusinessLayer.Interfaces;
using Ubuoy.UserAuthentication.Model;
using Ubuoy.UserAuthentication.DataLayer;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class AvailibilityBusinessObject: IValidation
    {
        private GenericRepository<Availibility> availibilityRepository;
        public List<String> ValidationSummary {get; set;}

        public AvailibilityBusinessObject()
        {
            this.availibilityRepository = new GenericRepository<Availibility>();
            this.ValidationSummary = new List<string>();
        }
        public bool IsHavingValidInputs(params object[] inputs)
        {
            bool isValid = true;
            var requiredElements = new object[] { inputs[0], inputs[1], inputs[2], inputs[3] };

            if (!RequiredElementsInPlace(requiredElements))
            {
                ValidationSummary.Add("All fields are required");
                isValid = false;
            }
            if(!DateIsValid(inputs[1].ToString(),inputs[2].ToString()))
            {
                ValidationSummary.Add("Date should be greater then or equal to current date");
                isValid = false;
            }

            return isValid;
        }

        private bool DateIsValid(string p1, string p2)
        {
            if (Convert.ToDateTime(p1) >= DateTime.Now && Convert.ToDateTime(p2) >= DateTime.Now)
            {
                return true;
            }
            else 
            {
                return false;
            }

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
        public bool AddAvailibility(Guid userId, Guid skillId, DateTime from, DateTime to)
        {
            var validation = string.Empty;
            //Todo: Make sure that both dates are greater than today and that from is greater than or equal to "to"
            if (this.IsHavingValidInputs(userId, skillId, from, to))
            {
                //Todo: Call the repository method to add and then to save
                availibilityRepository.Add(new Model.Availibility() {userId=userId, skillId=skillId, from=from, to=to });
                availibilityRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }
        public bool UpdateAvailibility(Guid userId, Guid skillId, DateTime from, DateTime to)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(userId, skillId, from, to))
            {
                //Todo: Call the repository method to add and then to save
                availibilityRepository.Attach(new Model.Availibility() { userId = userId, skillId = skillId, from = from, to = to });
                availibilityRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }
        public void DeleteAvailibilityById(Guid id)
        {
            availibilityRepository.Delete(x => x.availibilityId.Equals(id));
            availibilityRepository.SaveChanges();
        }
        public Availibility GetAvailibilityOfUser(Guid userId)
        {
            if (userId != null)
            {
                var availibility = availibilityRepository.Single(x => x.userId.Equals(userId));
                return availibility;
            }
            else return null;

        }
    }
}