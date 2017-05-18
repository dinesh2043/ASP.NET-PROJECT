using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ubuoy.UserAuthentication.BusinessLayer;
using Ubuoy.UserAuthentication.Model;
using System.Web.UI.HtmlControls;

namespace Ubuoy.UserAuthentication
{
    public partial class uBuoyProjects : System.Web.UI.Page
    {
        void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {

            }
            else
            {
                MasterPageFile = "~/uBuoyMasterNA.Master";
            }
        }
        private IEnumerable<Project> _projectCollection;
        private List<string> images;
        private int count;

        protected void Page_Load(object sender, EventArgs e)
        {
            var projObject = new ProjectBussinessObjects();
            _projectCollection = projObject.GetAllProject(string.Empty);

            foreach (var project in _projectCollection)
            {
                projectHyperLinkCreation(project);

            }

        }
        public void projectHyperLinkCreation(Project proj)
        {
            if (proj.endOn > DateTime.Now)
            {
                //for getting projects image from image package table
                images = new List<string> { proj.ImagePackage.image1, proj.ImagePackage.image2, proj.ImagePackage.image3, proj.ImagePackage.image4, proj.ImagePackage.image5, proj.ImagePackage.image6, proj.ImagePackage.image7, proj.ImagePackage.image8, proj.ImagePackage.image9, proj.ImagePackage.image10 };

                //main panel
                HyperLink ProjContent = new HyperLink();
                ProjContent.Attributes.Add("onclick", "event.preventDefault();");

                //oncontextmenu="return false;"

                //?id=" + Category.categoryId
                ProjContent.NavigateUrl = "~/uBuoyProjectDetails.aspx?progId=" + proj.projectId;

                //add this hyperlink to main place holder in aspx page
                Projects.Controls.Add(ProjContent);
                //getting main panel content for project with priority
                projectMainPanel(proj, ProjContent);

                //getting image content in main panel
                projectImagesPanel(proj, ProjContent);

                //getting badge and brand panel
                projectBrandAndBadgePanel(proj, ProjContent);
            }


        }

        public void projectMainPanel(Project proj, HyperLink mainContent)
        {

            count++;
            mainContent.CssClass = "tile double image border-color-LightGrey";
            //mainContent.ID = "ProjContentFalse" + count2;
            mainContent.Attributes.Add("data-role", "tile-slider");
            mainContent.Attributes.Add("data-param-period", "3000");
            mainContent.ID = "ProjectFalse" + count + "";
            mainContent.Attributes.Add("oncontextmenu", "return false; event.preventDefault();");
        }

        public void projectImagesPanel(Project proj, HyperLink mainContent)
        {
            foreach (string image in images)
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
        public void projectBrandAndBadgePanel(Project proj, HyperLink mainContent)
        {
            decimal projectProcent = ((decimal)proj.recived * 100) / (decimal)proj.budget;
            decimal formatedProcent = Math.Round(Convert.ToDecimal(projectProcent), 0);

            Label badgelabel = new Label();
            badgelabel.CssClass = "badge fg-color-" + proj.Orginization.orgFgColor;
            badgelabel.Text = formatedProcent + "%";
            //brand div of the project creation
            Panel brandOrg = new Panel();
            brandOrg.CssClass = "brand bg-color-" + proj.Orginization.orgBgColor;
            Panel progressBar = new Panel();
            progressBar.CssClass = "progress-bar";
            brandOrg.Controls.Add(progressBar);
            Panel progBarDone = new Panel();
            progBarDone.CssClass = "bar bg-color-green";
            progBarDone.Attributes.Add("style", "width:" + formatedProcent + "%");
            Panel progBarToGo = new Panel();
            progBarToGo.CssClass = "bar bg-color-yellow";
            progBarToGo.Attributes.Add("style", "width:" + (100 - formatedProcent) + "%");
            progressBar.Controls.Add(progBarDone);
            progressBar.Controls.Add(progBarToGo);
            //badge div of the project creation
            Panel projBadge = new Panel();
            projBadge.CssClass = "badge";
            projBadge.Controls.Add(badgelabel);
            //orgLogo image of the project creation
            Image orgLogoImg = new Image();
            orgLogoImg.CssClass = "icon";
            orgLogoImg.ImageUrl = "UI/" + proj.Orginization.orgLogo;


            mainContent.Controls.Add(brandOrg);
            brandOrg.Controls.Add(orgLogoImg);

            Literal discLiteral = new Literal();
            discLiteral.Text = "<p class=\"text fg-color-" + proj.Orginization.orgFgColor + "\"> " + proj.description + "</p>";
            brandOrg.Controls.Add(discLiteral);
            brandOrg.Controls.Add(projBadge);

        }

    }
}