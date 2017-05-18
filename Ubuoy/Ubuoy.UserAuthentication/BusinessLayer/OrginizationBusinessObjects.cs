using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.DataLayer;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class OrginizationBusinessObjects
    {
        
    private GenericRepository<Orginization> organizationRepository;
        public List<string> ValidationSummary { get; set; }

        public OrginizationBusinessObjects()
        {
            organizationRepository = new GenericRepository<Orginization>();
            this.ValidationSummary = new List<String>();
        }
        public Orginization GetOrganizationOfProjectsById(Guid id)
        {
            return organizationRepository.Single(x =>x.orginizationId.Equals(id));
        }
        public Orginization GetOrganizationById(Guid id)
        {
            return organizationRepository.Single(x => x.orginizationId.Equals(id));
        }
        public bool AddOrganization(string Name, string Description,string webAddress, string OrgBgColor, string OrgFgColor, string Country, string City, Int32 PostalCode, string StreetAddress, string Email, string Phone)
        {
           // var validation = string.Empty;
            //if (this.IsHavingValidInputs(country, city, postalCode, streetAddress, phone, email))
            //{
                //Todo: Call the repository method to add and then to save
                organizationRepository.Add(new Model.Orginization() { name = Name, description = Description, link = webAddress, orgBgColor = OrgBgColor, orgFgColor = OrgFgColor, orginizationId=Guid.NewGuid(), country = Country, city = City, postalCode= PostalCode, streetAdress=StreetAddress, email=Email, phone=Phone});
                organizationRepository.SaveChanges();
                return true;
            //}
            //else
            //{
               // ValidationSummary.Add(validation);
               // return false;
           // }
        }
    }
        
    }
