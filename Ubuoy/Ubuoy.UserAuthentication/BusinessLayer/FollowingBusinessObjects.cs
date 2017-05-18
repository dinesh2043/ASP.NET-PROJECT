using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.BusinessLayer.Interfaces;
using Ubuoy.UserAuthentication.DataLayer;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class FollowingBusinessObjects: IValidation
    {
        private GenericRepository<Following> followingRepository;
        public List<string> ValidationSummary { get; set; }

        public FollowingBusinessObjects()
        {
            this.followingRepository = new GenericRepository<Following>();
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
        public bool AddFollowing(Guid organizationId, Guid projectId, Guid userId)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(organizationId, projectId, userId))
            {
                //Todo: Call the repository method to add and then to save
                followingRepository.Add(new Model.Following() { organizationId=organizationId, projectId=projectId, userId=userId });
                followingRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }
        public bool UpdateFollowing(Guid organizationId, Guid projectId, Guid userId)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(organizationId, projectId, userId))
            {
                //Todo: Call the repository method to add and then to save
                followingRepository.Attach(new Model.Following() { organizationId = organizationId, projectId = projectId, userId = userId });
                followingRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }
        public void DeleteFollowingById(Guid id)
        {
            followingRepository.Delete(x => x.followingId.Equals(id));
            followingRepository.SaveChanges();
        }
        public Following GetFollowingforUser(Guid userId)
        {
            if (userId != null)
            {
                var following = followingRepository.Single(x => x.userId.Equals(userId));
                return following;
            }
            else return null;

        }
        
    }
}