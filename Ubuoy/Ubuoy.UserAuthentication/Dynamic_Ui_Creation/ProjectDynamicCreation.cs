using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.BusinessLayer;
using Ubuoy.UserAuthentication.Model;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Ubuoy.UserAuthentication.Dynamic_Ui_Creation
{
    public class ProjectDynamicCreation
    {
        Guid projectsImagePackageId;
        Guid organizationOfProjectID;
        private ImagePackage userImagePackage = null;
        private Orginization _projectOrganization;
        private Project _userProjects;
        private int count2 = 0;
        public List<string> imageList;
        int count = 0;

      
        public HyperLink projectCreation(Guid usersProjectId, bool prority)
        {
            var ProjObj = new BusinessLayer.ProjectBussinessObjects();
            _userProjects = ProjObj.GetProjectById(usersProjectId);

            //for getting project images
            projectsImagePackageId = (Guid)_userProjects.imagePackageId;

            var images = new BusinessLayer.ImagePackageBusinessObjects();

            userImagePackage = images.GetImagesOfProjectsById(projectsImagePackageId);

            imageList = new List<string> { userImagePackage.image1, userImagePackage.image2, userImagePackage.image3, userImagePackage.image4, userImagePackage.image5, userImagePackage.image6, userImagePackage.image7, userImagePackage.image8, userImagePackage.image9, userImagePackage.image10 };
            

            //getting organization logo
            organizationOfProjectID = (Guid)_userProjects.organizationId;

            var currentOrganization = new BusinessLayer.OrginizationBusinessObjects();

            _projectOrganization = currentOrganization.GetOrganizationOfProjectsById(organizationOfProjectID);

            

            //main panel
            HyperLink ProjContent = new HyperLink();
            ProjContent.Attributes.Add("onclick", "event.preventDefault();");
            
            //oncontextmenu="return false;"
            
            //?id=" + Category.categoryId
            ProjContent.NavigateUrl = "~/uBuoyProjectDetails.aspx?progId=" + usersProjectId;
            //getting main panel content for project with priority
            projectMainPanel(prority, ProjContent);

            //getting image content in main panel
            projectImagesPanel(ProjContent);

            //getting badge and brand panel
            projectBrandAndBadgePanel(ProjContent);
            
            return ProjContent;
        }
        /**public HyperLink addProject()
        {
            HyperLink ProjAdd = new HyperLink();
            ProjAdd.Attributes.Add("onclick", "event.preventDefault();");
            ProjAdd.NavigateUrl = "~/Forms.aspx?formId=AddProject" ;
            ProjAdd.CssClass = "tile double icon bg-color-ubuoy border-color-LightGrey";



            ProjAdd.ID = "AddProject";
            ProjAdd.Attributes.Add("oncontextmenu", "return false; event.preventDefault();");

            Panel ProjAddContent = new Panel();
            ProjAddContent.CssClass = "tile-content";
            Literal addProjLiteral = new Literal();
            addProjLiteral.Text = "<i class=\"icon icon-plus fg-color-white\"></i>";
            Panel addProjBrand = new Panel();
            addProjBrand.CssClass = "brand";
            Label addProjBrandLable = new Label();
            addProjBrandLable.Text = "Add a project";
            addProjBrandLable.CssClass = "name fg-color-white";

            ProjAdd.Controls.Add(ProjAddContent);
            ProjAddContent.Controls.Add(addProjLiteral);
            ProjAdd.Controls.Add(addProjBrand);


            addProjBrand.Controls.Add(addProjBrandLable);
            return ProjAdd;
        }**/
        public void projectMainPanel(bool priority, HyperLink mainContent)
        {
            if (priority == true)
            {

                mainContent.CssClass = "tile quadro double-vertical image border-color-LightGrey";
                //mainContent.ID = "ProjContentTrue";
               mainContent.Attributes.Add("data-role", "tile-slider");
                mainContent.Attributes.Add("data-param-period", "3000");
                mainContent.Attributes.Add("data-param-direction", "left");
                mainContent.ID = "ProjectTrue"+count+"";
                mainContent.Attributes.Add("oncontextmenu", "return false; event.preventDefault();");
            }
            else
            {
                count2++;
                mainContent.CssClass = "tile double image border-color-LightGrey";
                //mainContent.ID = "ProjContentFalse" + count2;
                mainContent.Attributes.Add("data-role", "tile-slider");
                mainContent.Attributes.Add("data-param-period", "3000");
                mainContent.ID = "ProjectFalse" + count2 + "";
                mainContent.Attributes.Add("oncontextmenu", "return false; event.preventDefault();");
            }

        }
        public void projectImagesPanel(HyperLink mainContent)
        {
            foreach (string image in imageList)
            {
                if (image == null)
                {
                    //do not do any thing
                }
                else
                {
                    count++;
                    //looping project image tile creation
                    Panel tileContentImage = new Panel();
                    tileContentImage.CssClass = "tile-content";

                    //looping project image creation
                    Image projectImage = new Image();
                    projectImage.ImageUrl = "UI/" + image;
                    projectImage.ID = "projectImage" + count;
                    tileContentImage.Controls.Add(projectImage);

                    //add main panel with image panel
                    mainContent.Controls.Add(tileContentImage);


                }
            }

        }
        public void projectBrandAndBadgePanel(HyperLink mainContent)
        {
            decimal projectProcent = ((decimal)_userProjects.recived * 100) /(decimal)_userProjects.budget;
            decimal formatedProcent = Math.Round(Convert.ToDecimal(projectProcent), 0);

            Label badgelabel = new Label();
            badgelabel.CssClass = "badge fg-color-" + _projectOrganization.orgFgColor;
            badgelabel.Text = formatedProcent + "%";
            //brand div of the project creation
            Panel brandOrg = new Panel();
            brandOrg.CssClass = "brand bg-color-" + _projectOrganization.orgBgColor;
            //progress bar div
            Panel progressBar = new Panel();
            progressBar.CssClass = "progress-bar";
            brandOrg.Controls.Add(progressBar);
            Panel progBarDone = new Panel();
            progBarDone.CssClass = "bar bg-color-green";
            progBarDone.Attributes.Add("style", "width:"+formatedProcent+"%");
            Panel progBarToGo = new Panel();
            progBarToGo.CssClass = "bar bg-color-yellow";
            progBarToGo.Attributes.Add("style", "width:" +(100 - formatedProcent) + "%");
            progressBar.Controls.Add(progBarDone);
            progressBar.Controls.Add(progBarToGo);
                
            //badge div of the project creation
            Panel projBadge = new Panel();
            projBadge.CssClass = "badge";
            projBadge.Controls.Add(badgelabel);
            //orgLogo image of the project creation
            Image orgLogoImg = new Image();
            orgLogoImg.CssClass = "icon";
            orgLogoImg.ImageUrl = "UI/" + _projectOrganization.orgLogo;


            mainContent.Controls.Add(brandOrg);
            brandOrg.Controls.Add(orgLogoImg);

            Literal discLiteral = new Literal();
            discLiteral.Text = "<p class=\"text fg-color-" + _projectOrganization.orgFgColor + "\"> " + _userProjects.description + "</p>";
            brandOrg.Controls.Add(discLiteral);
            brandOrg.Controls.Add(projBadge);

        }

        
    }
}