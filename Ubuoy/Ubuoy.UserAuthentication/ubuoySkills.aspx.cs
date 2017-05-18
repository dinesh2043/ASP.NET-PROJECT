using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ubuoy.UserAuthentication.Model;
using Ubuoy.UserAuthentication.BusinessLayer;

namespace Ubuoy.UserAuthentication
{
    public partial class uBuoySkills : System.Web.UI.Page
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
        User _user;
        int count = 0;
        IEnumerable<Category> _category;
        IEnumerable<string> ParentCat;
        IEnumerable<Skill> _skills;
        IEnumerable<Skill> categorySkill = null;


        //IEnumerable<UsersTask> _userTask;
        //to put the litral inside of user info
        String skillDescription;
        protected void Page_Load(object sender, EventArgs e)
        {
            //skills according to category
            // users information related to same skill in same panel

            var categoryBusinessObj = new BusinessLayer.CategoryBusinessObjects();
            _category = categoryBusinessObj.GetCategoryAccordingToParent(string.Empty);

            ParentCat = categoryBusinessObj.GetDetailCategoryAccordingToParent(string.Empty);

            getParentCategory();

        }
        private void getParentCategory()
        {

            foreach (var parent in ParentCat)
            {
                Panel ParentCategory = new Panel();
                ParentCategory.CssClass = "tile-group tile-drag";

                Categories.Controls.Add(ParentCategory);
                Literal ParentCatHeader = new Literal();
                ParentCatHeader.Text = "<h3>" + parent + "</h3>";
                System.Diagnostics.Debug.Write("Parant category" + parent);
                ParentCategory.Controls.Add(ParentCatHeader);


                getCategory(parent, ParentCategory);
            }
        }

        private void getCategory(string parentCategory, Panel parPnl)
        {
            var skillBussinessObj = new BusinessLayer.SkillBusinessObjects();

            foreach (var Category in _category)
            {
                categorySkill = skillBussinessObj.GetSkillByCategoryId(Category.categoryId);
                //foreach (var catTask in categoryTask)
                //{
                if ((parentCategory == Category.parent) && categorySkill != null)
                {

                    Panel categoryPnl = new Panel();

                    categoryPnl.ID = "" + (Guid)Category.categoryId;

                    categoryPnl.CssClass = "tile double bg-color-ubuoy border-color-LightGrey";
                    categoryPnl.Attributes.Add("data-param-period", "3000");
                    categoryPnl.Attributes.Add("data-param-direction", "up");
                    categoryPnl.Attributes.Add("data-role", "tile-slider");
                    System.Diagnostics.Debug.Write("category" + Category.Name);

                    HyperLink skillLink = new HyperLink();
                    //~/Demo.aspx?+_projectOrganization.orginizationId + ProjectId
                    skillLink.NavigateUrl = "~/ubuoySkillDetail.aspx?id=" + Category.categoryId;

                    parPnl.Controls.Add(skillLink);


                    parPnl.Controls.Add(categoryPnl);
                    skillLink.Controls.Add(categoryPnl);



                    //Panel TaskContentPanel = new Panel();
                    //TaskContentPanel.CssClass = "tile-content bg-color-green";
                    //categoryPnl.Controls.Add(TaskContentPanel);
                    //
                    // getTask(TaskContentPanel, Category.categoryId);

                    getSkill(categoryPnl, Category.categoryId);

                    Panel brandPanel = new Panel();
                    brandPanel.CssClass = "brand bg-color-darken fg-color-white";
                    categoryPnl.Controls.Add(brandPanel);

                    Label categoryNameLabel = new Label();
                    categoryNameLabel.CssClass = "text fg-color-white";
                    categoryNameLabel.Text = Category.Name;
                    brandPanel.Controls.Add(categoryNameLabel);

                    Panel skillCount = new Panel();
                    skillCount.CssClass = "badge fg-color-white";
                    Literal taskCountText = new Literal();
                    taskCountText.Text = "" + count;
                    brandPanel.Controls.Add(skillCount);
                    skillCount.Controls.Add(taskCountText);

                    //}
                }
            }

        }

        private void getSkill(Panel categoryPnl, Guid guid)
        {

            var taskBussinessObj = new BusinessLayer.SkillBusinessObjects();
            _skills = taskBussinessObj.GetSkillByCategoryId(guid);
            count = _skills.Count();
            foreach (var skill in _skills)
            {


                Panel SkillContentPanel = new Panel();
                SkillContentPanel.CssClass = "tile-content bg-color-green";
                categoryPnl.Controls.Add(SkillContentPanel);
                SkillContentPanel.ID = "" + count;

                //string taskCategoryIdString = "" + (Guid)task.categoryId;
                //Literal descTask = new Literal();
                //descTask.Text = "<p class=\"fg-color-white\">" + task.description + "</p>";
                //TaskContentPanel.Controls.Add(descTask);
                skillDescription = "<p class=\"fg-color-white\">" + skill.description + "</p>";
                getUserInfo(SkillContentPanel, (Guid)skill.userId);

                System.Diagnostics.Debug.Write("\nSkill Description" + skill.description + "\n");


            }

        }
        private void getUserInfo(Panel TaskContent, Guid userId)
        {
            var userBusinessObj = new BusinessLayer.UserBusinessObjects();
            _user = userBusinessObj.GetUserById(userId);
            System.Diagnostics.Debug.Write("User Info:" + _user.firstName + _user.lastName + _user.email + _user.image);
            Image TaskCreatorImage = new Image();
            TaskCreatorImage.CssClass = "place-right";
            TaskCreatorImage.Attributes.Add("style","background-color:#fff;");
            TaskCreatorImage.Height = 80;
            TaskCreatorImage.Width = 80;
            TaskCreatorImage.ImageUrl = _user.image;
            TaskContent.Controls.Add(TaskCreatorImage);

            Literal userNameText = new Literal();
            userNameText.Text = "<h4 class=\"fg-color-white\">" + _user.firstName + " " + _user.lastName + "</h4>";
            TaskContent.Controls.Add(userNameText);

            Literal descTask = new Literal();
            descTask.Text = "<p class=\"fg-color-white\">" + skillDescription + "</p>";
            TaskContent.Controls.Add(descTask);

            Literal userEmail = new Literal();
            userEmail.Text = "<h5 class=\"fg-color-white\">" + _user.email + "</h5>";
            TaskContent.Controls.Add(userEmail);

        }
    }
}