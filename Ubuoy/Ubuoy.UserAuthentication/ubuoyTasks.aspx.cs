using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ubuoy.UserAuthentication.Model;
using System.Web.UI.HtmlControls;

namespace Ubuoy.UserAuthentication
{
    public partial class uBuoyTasks : System.Web.UI.Page

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
        Guid userId;
        User _user;
        int count = 0;
        IEnumerable<Category> _category;
        IEnumerable<string> ParentCat;
        IEnumerable<Task> _task;
        IEnumerable<Task> categoryTask = null;
        IEnumerable<UsersTask> _userTask;
        //to put the litral inside of user info
        String taskDescription;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            var taskBussinessObj = new BusinessLayer.TaskBusinessObjects();

            foreach (var Category in _category)
            {
                categoryTask = taskBussinessObj.GetTaskByCategoryId(Category.categoryId);
                //foreach (var catTask in categoryTask)
                //{
                if ((parentCategory == Category.parent) && categoryTask != null)
                {

                    Panel categoryPnl = new Panel();

                    categoryPnl.ID = "" + (Guid)Category.categoryId;

                    categoryPnl.CssClass = "tile double bg-color-ubuoy border-color-LightGrey";
                    categoryPnl.Attributes.Add("data-param-period", "3000");
                    categoryPnl.Attributes.Add("data-param-direction", "up");
                    categoryPnl.Attributes.Add("data-role", "tile-slider");
                    System.Diagnostics.Debug.Write("category" + Category.Name);

                    HyperLink taskLink = new HyperLink();
                    //~/Demo.aspx?+_projectOrganization.orginizationId + ProjectId
                    taskLink.NavigateUrl = "~/tasksCategory.aspx?id=" + Category.categoryId;

                    parPnl.Controls.Add(taskLink);


                    parPnl.Controls.Add(categoryPnl);
                    taskLink.Controls.Add(categoryPnl);



                    //Panel TaskContentPanel = new Panel();
                    //TaskContentPanel.CssClass = "tile-content bg-color-green";
                    //categoryPnl.Controls.Add(TaskContentPanel);
                    //
                    // getTask(TaskContentPanel, Category.categoryId);

                    getTask(categoryPnl, Category.categoryId);

                    Panel brandPanel = new Panel();
                    brandPanel.CssClass = "brand bg-color-darken fg-color-white";
                    categoryPnl.Controls.Add(brandPanel);

                    Label categoryNameLabel = new Label();
                    categoryNameLabel.CssClass = "text fg-color-white";
                    categoryNameLabel.Text = Category.Name;
                    brandPanel.Controls.Add(categoryNameLabel);

                    Panel taskCount = new Panel();
                    taskCount.CssClass = "badge fg-color-white";
                    Literal taskCountText = new Literal();
                    taskCountText.Text = "" + count;
                    brandPanel.Controls.Add(taskCount);
                    taskCount.Controls.Add(taskCountText);

                    //}
                }
            }

        }

        private void getTask(Panel categoryPnl, Guid guid)
        {

            var taskBussinessObj = new BusinessLayer.TaskBusinessObjects();
            _task = taskBussinessObj.GetTaskByCategoryId(guid);
            count = _task.Count();
            foreach (var task in _task)
            {

                Panel TaskContentPanel = new Panel();
                TaskContentPanel.CssClass = "tile-content bg-color-green";
                categoryPnl.Controls.Add(TaskContentPanel);
                TaskContentPanel.ID = "" + count;

                //string taskCategoryIdString = "" + (Guid)task.categoryId;
                //Literal descTask = new Literal();
                //descTask.Text = "<p class=\"fg-color-white\">" + task.description + "</p>";
                //TaskContentPanel.Controls.Add(descTask);
                taskDescription = "<p class=\"fg-color-white\">" + task.description + "</p>";
                getUsersTask(TaskContentPanel, task.taskId);

                System.Diagnostics.Debug.Write("\nTask Description" + task.description + "\n");


            }

        }

        private void getUsersTask(Panel TaskContent, Guid guid)
        {
            var userTaskBusinessObj = new BusinessLayer.UsersTaskBusinessObjects();

            _userTask = userTaskBusinessObj.GetUserTaskById(guid);
            foreach (var userstask in _userTask)
            {


                System.Diagnostics.Debug.Write("Userid" + userstask.userId);
                userId = (Guid)userstask.userId;
                getUserInfo(userId, TaskContent);
            }

        }



        private void getUserInfo(Guid guid, Panel TaskContent)
        {
            var userBusinessObj = new BusinessLayer.UserBusinessObjects();
            _user = userBusinessObj.GetUserById(guid);
            System.Diagnostics.Debug.Write("User Info:" + _user.firstName + _user.lastName + _user.email + _user.image);
            Image TaskCreatorImage = new Image();
            TaskCreatorImage.CssClass = "place-right";
            TaskCreatorImage.Attributes.Add("style", "background-color:#fff;");
            TaskCreatorImage.Height = 80;
            TaskCreatorImage.Width = 80;
            TaskCreatorImage.ImageUrl = _user.image;
            TaskContent.Controls.Add(TaskCreatorImage);

            Literal userNameText = new Literal();
            userNameText.Text = "<h4 class=\"fg-color-white\">" + _user.firstName + " " + _user.lastName + "</h4>";
            TaskContent.Controls.Add(userNameText);

            Literal descTask = new Literal();
            descTask.Text = "<p class=\"fg-color-white\">" + taskDescription + "</p>";
            TaskContent.Controls.Add(descTask);

            Literal userEmail = new Literal();
            userEmail.Text = "<h5 class=\"fg-color-white\">" + _user.email + "</h5>";
            TaskContent.Controls.Add(userEmail);

        }

    }
}