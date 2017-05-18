using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.DataLayer;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq.Expressions;
using Ubuoy.UserAuthentication.Model;
using Ubuoy.UserAuthentication.BusinessLayer.Interfaces;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class UserBusinessObjects : IValidation
    {
        private GenericRepository<User> userRepository;
        public List<string> ValidationSummary { get; set; }

        public UserBusinessObjects()
        {
            userRepository = new GenericRepository<User>();
            this.ValidationSummary = new List<String>();
        }

        public bool RegisterUser(string email, string password, string password2, string firstName, string lastName, string gander, DateTime dob,string image)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(email, password,password2, firstName, lastName, gander, dob))
            {
                if (!UserEmailExists(email))
                {
                    userRepository.Add(new Model.User() { email = email, password = password, firstName = firstName, lastName = lastName, gender = gander, DOB=dob, image=image, userId = Guid.NewGuid() });
                    userRepository.SaveChanges();
                    return true;
                }
                else return false;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }

        public bool IsHavingValidInputs(params object[] inputs)
        {
            bool isValid = true;
            var requiredElements = new object[] { inputs[0], inputs[1], inputs[2], inputs[3], inputs[4] };

            if (!PasswordsMatch(inputs[1].ToString(), inputs[2].ToString()))
            {
                ValidationSummary.Add("Passwords do not match");
                isValid = false;
            }
            if (!EmailIsInCorrectFormat(inputs[0].ToString()))
            {
                ValidationSummary.Add("Email not in correct format");
                isValid = false;
            }            
            if (!RequiredElementsInPlace(requiredElements))
            {
                ValidationSummary.Add("All fields are required");
                isValid = false;
            }

            return isValid;
        }

        private bool RequiredElementsInPlace(object[] inputs)
        {
            foreach(var input in inputs)
            {
                if (string.IsNullOrEmpty(input.ToString()))
                    return false;
            }
            return true;
        }

        private bool EmailIsInCorrectFormat(string p)
        {
            if (p.Contains("@"))
            {
                var halfEmail = p.Split('@')[1];
                return halfEmail.Contains(".");
            }
            return false;
         
        }

        private bool PasswordsMatch(string password1, string password2)
        {
            return password1.Equals(password2);
        }

        public bool UserEmailExists(string userName)
        {
            var exists = userRepository.Find(x => x.email.Equals(userName));
            if (exists.Count() > 0)
            {
                ValidationSummary.Add("The user with this email already exists");
                return true;
            }
            else
            {
               return false;
            }
        }
       
        public bool UserExists(string userName,  string password)
        {
            var exists = userRepository.Find(x => x.email.Equals(userName) && x.password.Equals(password));
            return exists.Count() > 0;
           
        }

        public User GetUserById(Guid id)
        {
            return userRepository.Single(x => x.userId.Equals(id));
        }


        public User GetUserByEmailAndPassword(string email, string password)
        {
            return userRepository.Single(x => x.email.Equals(email) && x.password.Equals(password));
        }
        public void DeleteUserByID(Guid id){
            userRepository.Delete(x=> x.userId.Equals(id));
            userRepository.SaveChanges();
        }

        public bool editUser(string email, string password, string password2, string firstName, string lastName)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(email, password,password2, firstName, lastName))
            {
                if (!UserEmailExists(email))
                {
                 userRepository.Attach(new Model.User() { email = email, password = password, firstName = firstName, lastName = lastName, userId = Guid.NewGuid() });
                 userRepository.SaveChanges();
                 return true;
                }
                else return false;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }

    }
}