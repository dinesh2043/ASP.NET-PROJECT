using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.BusinessLayer
{
    public class ImagePackageBusinessObjects
    {
    private GenericRepository<ImagePackage> imagePackageRepository;
        public List<string> ValidationSummary { get; set; }

        public ImagePackageBusinessObjects()
        {
            imagePackageRepository = new GenericRepository<ImagePackage>();
            this.ValidationSummary = new List<String>();
        }
        public ImagePackage GetImagesOfProjectsById(Guid id)
        {
            return imagePackageRepository.Single(x =>x.imageId.Equals(id));
        }
    }
}