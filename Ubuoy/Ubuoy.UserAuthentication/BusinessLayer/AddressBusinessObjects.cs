using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.Model;
using Ubuoy.UserAuthentication.BusinessLayer.Interfaces;
using System.Text.RegularExpressions;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class AddressBusinessObjects: IValidation
    {
        private GenericRepository<Address> addressRepository;
        public List<string> ValidationSummary { get; set; }


        public AddressBusinessObjects()
        {
            this.addressRepository = new GenericRepository<Address>();
            this.ValidationSummary = new List<string>();
        }

        public bool AddAddress(string country, string city, Int32 postalCode, string streetAddress, string phone, string email)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(country, city, postalCode, streetAddress, phone, email))
            {
                //Todo: Call the repository method to add and then to save
                addressRepository.Add(new Model.Address() { country = country, city = city, postalCode = postalCode, streetAddress = streetAddress, phone = phone, email = email,addressId=Guid.NewGuid() });
                addressRepository.SaveChanges();
                return true;
            }
            else
            {
                ValidationSummary.Add(validation);
                return false;
            }
        }
        public void DeleteAddressById(Guid id)
        {
            addressRepository.Delete(x => x.addressId.Equals(id));
            addressRepository.SaveChanges();
        }
        public bool UpdateAddress(string country, string city, Int32 postalCode, string streetAddress, string phone)
        {
            var validation = string.Empty;
            if (this.IsHavingValidInputs(country, city, postalCode, streetAddress, phone))
            {
                //Todo: Call the repository method to add and then to save
                addressRepository.Attach(new Model.Address() { country = country, city = city, postalCode = postalCode, streetAddress = streetAddress, phone = phone });
                addressRepository.SaveChanges();
                return true;
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

            if (!RequiredElementsInPlace(requiredElements))
            {
                ValidationSummary.Add("All fields are required");
                isValid = false;
            }
            if(!PhoneIsInteger(inputs[4].ToString()))
            {
                ValidationSummary.Add("Phone number should be with in this format '+358-446-777205'");
                isValid = false;
            }
            if (!PostalCodeIsInteger(inputs[2].ToString()))
            {
                ValidationSummary.Add("Should be an integer");
                isValid = false;
            }

            return isValid;
        }

        private bool PostalCodeIsInteger(string postalCode)
        {
            Regex regxPostal = new Regex(@"^[0-9]{5}$");
            if (regxPostal.IsMatch(postalCode))
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

        private bool PhoneIsInteger(string phone)
        {
            Regex regexObj = new Regex(@"^\(?((\+)[0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{6})$");
            if ((phone.Contains("+"))&&(regexObj.IsMatch(phone)))
            {
                    return true;
            }
            else
            {
                return false;
            }
        }

        public Address GetAddressForUser(Guid userId)
        {
            //Todo: First get the Users AddressId, then get the address using that address Id
            var user = new UserBusinessObjects().GetUserById(userId);
            //var addressId = user.addressId;
            //if (addressId != null)
            //{
               // var address = addressRepository.Single(x=>x.addressId.Equals(addressId));
                //return address;
           // }
            //else return null;
            return null;

        }
        
    }
}