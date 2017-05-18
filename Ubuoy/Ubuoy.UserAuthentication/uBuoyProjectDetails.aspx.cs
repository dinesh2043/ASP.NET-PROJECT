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
    public partial class uBuoyProjectDetails : System.Web.UI.Page
    {
        Guid userId;
        Guid ProjectId;
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

        Project _project;
        

        // this page will display single project info passed from the id of project
        protected void Page_Load(object sender, EventArgs e)
        {
        // panelProject
            // label 
            //
            var projectId = Request.QueryString["progId"].ToString();
            

            ProjectId = new Guid(projectId);

            var projObj = new ProjectBussinessObjects();
            _project = projObj.GetProjectById(ProjectId);
            
            

                Panel projectPanel = new Panel();
                ProjectContent.Controls.Add(projectPanel);
                Literal projectDetail = new Literal();
                projectDetail.Text = "Budget: " + _project.budget + "<br />"  + "Description: " + _project.description + "<br />" + "EndOn: " + _project.endOn + "<br />" + "Recived: " + _project.recived + "<br />" + "Started On: " + _project.startedOn;
                projectPanel.Controls.Add(projectDetail);
                Literal organizationDetail = new Literal();
                organizationDetail.Text = "city: " + _project.Orginization.city + "<br />" + "country: " + _project.Orginization.country + "<br />" + "description: " + _project.Orginization.description + "<br />" + "email: " + _project.Orginization.email + "<br />" + "link: " + _project.Orginization.link + "<br />" + "name: " + _project.Orginization.name + "<br />" + "BGcolor: " + _project.Orginization.orgBgColor + "<br />" + "FgColor: " + _project.Orginization.orgFgColor + "<br />" + "orgLogo: " + _project.Orginization.orgLogo + "<br />" + "phone: " + _project.Orginization.phone + "<br />" + "postalCode: " + _project.Orginization.postalCode + "<br />" + "streetAddress: " + _project.Orginization.streetAdress + "<br />";
                projectPanel.Controls.Add(organizationDetail);
                Literal imageOFProject = new Literal();
                for (int i=0; i <= 10; i++)
                {
            //project image loop with non empty panel
                imageOFProject.Text = _project.ImagePackage.image1 + "<br />" + _project.ImagePackage.image2 + "<br />" + _project.ImagePackage.image3 + "<br />" + _project.ImagePackage.image4 + "<br />" + _project.ImagePackage.image5 + "<br />" + _project.ImagePackage.image6 + "<br />" + _project.ImagePackage.image7 + "<br />" + _project.ImagePackage.image8 + "<br />" + _project.ImagePackage.image9 + "<br />" + _project.ImagePackage.image10;

                projectPanel.Controls.Add(imageOFProject);
            //organization image loop 
                }
    }

        protected void follow(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                userId = (Guid)Session["UserId"];
                var usersProjectObject = new UserProjectBusinessObjects();
                bool prority = false;
                bool followProject = usersProjectObject.AddUsersProject(userId,ProjectId,prority);
                if (followProject)
                {
                    Response.Redirect("~/Profile.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
}
}