using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.BusinessLayer.Interfaces;
using Ubuoy.UserAuthentication.Model;
using Ubuoy.UserAuthentication.DataLayer;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class ApplicationBusinessObjects: IValidation
    {
        private GenericRepository<Application> applicationRepository;
        public List<String> ValidationSummary { get; set; }

        public ApplicationBusinessObjects()
        {
            this.applicationRepository = new GenericRepository<Application>();
            this.ValidationSummary = new List<string>();
        }
        public bool IsHavingValidInputs(params object[] inputs)
        {
            //Todo: Check that euro amount is greater than or equla to zero and that it is of decimal type
            bool isValid = true;
            var requiredElements = new object[] { inputs[0], inputs[1], inputs[2]};

            if (!RequiredElementsInPlace(requiredElements))
            {
                ValidationSummary.Add("All fields are required");
                isValid = false;
            }
            if (!IsInDecimal(inputs[2].ToString()))
            {
                ValidationSummary.Add("Amount should be decimal value");
                isValid = false;
            }

            return isValid;
        }

        private bool IsInDecimal(string p)
        {
            decimal euro = Convert.ToDecimal(p);
            
            if (euro>=0)
            {
                return true;
            }else
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
        public bool AddApplication(Guid userId, Guid taskId, Guid projectId, string euros)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(userId, taskId, euros))
            {
                //Todo: Call the repository method to add and then to save
                applicationRepository.Add(new Model.Application() {userId=userId, taskId=taskId, projectId=projectId, euro_Hr = euros, applicationId=Guid.NewGuid() });
                applicationRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }
        public bool UpdateApplication(Guid userId, Guid taskId, Guid projectId, string euros)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(userId, taskId, euros))
            {
                //Todo: Call the repository method to add and then to save
                applicationRepository.Attach(new Model.Application() { userId=userId, taskId=taskId, projectId = projectId, euro_Hr = euros });
                applicationRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }
        public void DeleteApplicationById(Guid id)
        {
            applicationRepository.Delete(x => x.applicationId.Equals(id));
            applicationRepository.SaveChanges();
        }
        public Application GetApplicationForUser(Guid userId)
        {
            //Todo: First get the Users AddressId, then get the address using that address Id
            if (userId != null)
            {
                var application = applicationRepository.Single(x => x.userId.Equals(userId));
                return application;
            }
            else return null;

        }

        
        }
}