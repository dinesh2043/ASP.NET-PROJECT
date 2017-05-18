using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.BusinessLayer.Interfaces;
using Ubuoy.UserAuthentication.DataLayer;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class NewsFeedBussinessObjects: IValidation
    {
        private GenericRepository<NewsFeed> newsFeedRepository;
        public List<string> ValidationSummary { get; set; }

        public NewsFeedBussinessObjects() 
        {
            this.newsFeedRepository = new GenericRepository<NewsFeed>();
            this.ValidationSummary = new List<string>();
        }
        public bool IsHavingValidInputs(params object[] inputs)
        {
            bool isValid = true;
            var requiredElements = new object[] { inputs[0], inputs[1], inputs[2], inputs[3], inputs[4] };

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
        public bool AddNewsFeed(Guid organizationId, Guid projectId, DateTime date, string feed, Guid followingId)
        {
            //Todo date should be greater than today
            // TODO: Datetime always in Finnish for now
            var validation = string.Empty;
            if (this.IsHavingValidInputs(organizationId, projectId, date, feed, followingId))
            {
                //Todo: Call the repository method to add and then to save
                newsFeedRepository.Add(new Model.NewsFeed() { organizationId = organizationId, projectId = projectId, date = date, followingId=followingId });
                newsFeedRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }

        public bool UpdateNewsFeed(Guid organizationId, Guid projectId, DateTime date, string feed, Guid followingId)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(organizationId, projectId, date, feed, followingId))
            {
                //Todo: Call the repository method to add and then to save
                newsFeedRepository.Attach(new Model.NewsFeed() { organizationId = organizationId, projectId = projectId, date = date, followingId = followingId });
                newsFeedRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }
        public void DeleteNewsFeedById(Guid id)
        {
            newsFeedRepository.Delete(x => x.newsFeedId.Equals(id));
            newsFeedRepository.SaveChanges();
        }
        public NewsFeed GetHonorById(Guid newsFeedId)
        {
            if (newsFeedId != null)
            {
                var newsFeed = newsFeedRepository.Single(x => x.newsFeedId.Equals(newsFeedId));
                return newsFeed;
            }
            else return null;

        }

        
    }
}