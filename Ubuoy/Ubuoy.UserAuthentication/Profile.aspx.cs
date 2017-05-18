using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ubuoy.UserAuthentication.BusinessLayer;
using Ubuoy.UserAuthentication.Model;
using System.Web.UI.HtmlControls;
using System.Data;
using Ubuoy.UserAuthentication.Dynamic_Ui_Creation;

namespace Ubuoy.UserAuthentication
{
    public partial class Profile : System.Web.UI.Page
    {
        private User _currentUser;
        IEnumerable<UserProject> userProjects = null;
        IEnumerable<UserModule> userModules = null;

        //constructor of ProjectDynamicCreation classes 
        ProjectDynamicCreation projDynamicCreation = new ProjectDynamicCreation();
        ModuleDynamicCreation modDynamicCreation = new ModuleDynamicCreation();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                var userId = (Guid)Session["UserId"];
                var userobj = new BusinessLayer.UserBusinessObjects();
                _currentUser = userobj.GetUserById(userId);

                // to get users information in profile page
                //userInfoForProfile();

                //to get users information for users own information
                //userInfo();

                //constructor for user project business object
                var userProject = new BusinessLayer.UserProjectBusinessObjects();

                //constructor for user Module business object
                var userModule = new BusinessLayer.UserModulesBusinessObjects();

                //for getting projects in which a user is involved
                userProjects = userProject.GetUserProjectsById(_currentUser.userId);

                // for getting all projects in which user is involved
                getUserProject(userProjects);

                //for creating panel for Add a project
                //tileGroupProject.Controls.Add(projDynamicCreation.addProject());

                //for getting modules in which a user is involved
                userModules = userModule.GetUserModuleByUserId(_currentUser.userId);

                //for getting individual module of user
                getUserModule(userModules);


                Page.Title = _currentUser.firstName + " " + _currentUser.lastName;
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }


        }
        /**
        
        public void userInfoForProfile()
        {
            lbl_FirstName.Text = _currentUser.firstName;
            lbl_LastName.Text = _currentUser.lastName;
            imgProfile.ImageUrl = _currentUser.image;

            profileTitle.Text = _currentUser.firstName + " " + _currentUser.lastName;
        
        }
        **/
        public void getUserProject(IEnumerable<UserProject> userProj)
        {
            foreach (var Project in userProj)
            {
                //HyperLink ProjContentLink = new HyperLink();
                //ProjContentLink.Attributes.Add("data-param-period", "3000");

                //var ProjObj = new BusinessLayer.ProjectBussinessObjects();
                if (Project.priority.Equals(true))
                {

                    //ProjContentLink.ID = "ProjContentTrueLink";
                    //ProjContentLink.CssClass = "tile quadro double-vertical image border-color-LightGrey";

                    //for getting the project with prority true
                    //projectWithProrityTrue.Controls.Add(ProjContentLink);
                    //
                    //ProjContentLink.NavigateUrl = "~/Demo.aspx?+_projectOrganization.orginizationId + ProjectId";


                    projectWithProrityTrue.Controls.Add(projDynamicCreation.projectCreation((Guid)Project.projectId, (bool)Project.priority));

                }
                else
                {
                    //ProjContentLink.ID = "ProjContentFalseLink";
                    //projectWithProrityFalse.Controls.Add(ProjContentLink);
                    //ProjContentLink.NavigateUrl = "~/Demo.aspx";


                    //for getting the project with prority false
                    projectWithProrityFalse.Controls.Add(projDynamicCreation.projectCreation((Guid)Project.projectId, (bool)Project.priority));
                }

            }
        }
        public void getUserModule(IEnumerable<UserModule> userMod)
        {
            foreach (var Module in userMod)
            {
                //HyperLink ModuleContentLink = new HyperLink();
                //var ProjObj = new BusinessLayer.ProjectBussinessObjects();
                if (Module.prority.Equals(true))
                {
                    //ModuleContentLink.ID = "ProjContentTrueLink";


                    //for getting the project with prority true
                    //moduleWithProrityTrue.Controls.Add(ModuleContentLink);
                    //
                    //ModuleContentLink.NavigateUrl = "~/Demo.aspx?+ModuleId + UserId";
                    //for getting the module with prority true
                    moduleWithProrityTrue.Controls.Add(modDynamicCreation.ModuleCreation(Module.userModuleId, (bool)Module.prority, Module.moduleFgColor, Module.moduleBgColor));
                }
                else
                {
                    //ModuleContentLink.ID = "ProjContentTrueLink";


                    //for getting the project with prority true
                    //            moduleWithProrityFalse.Controls.Add(ModuleContentLink);
                    //
                    //             ModuleContentLink.NavigateUrl = "~/Demo.aspx?+ModuleId + UserId";
                    //for getting the module with prority false
                    moduleWithProrityFalse.Controls.Add(modDynamicCreation.ModuleCreation(Module.userModuleId, (bool)Module.prority, Module.moduleFgColor, Module.moduleBgColor));

                }
            }
        }
    }
}