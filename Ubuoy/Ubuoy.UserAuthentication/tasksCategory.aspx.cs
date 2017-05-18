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
    public partial class tasksCategory : System.Web.UI.Page
    {
        IEnumerable<UsersTask> _userTask;
        User _user;
        Guid userId;
        IEnumerable<Task> _task;
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
        protected void Page_Load(object sender, EventArgs e)
        {


            var catId = Request.QueryString["id"].ToString();
            System.Diagnostics.Debug.Write("id test:" + catId);
            Guid id = new Guid(catId);
            var taskObj = new TaskBusinessObjects();
            _task = taskObj.GetTaskByCategoryId(id);
            foreach (var task in _task)
            {

                Panel taskPanel = new Panel();
                categoryTasks.Controls.Add(taskPanel);
                Label taskDescription = new Label();
                taskDescription.Text = task.description + ", " + task.owner + ", " + task.doer + ", " + task.deadline;
                taskPanel.Controls.Add(taskDescription);
                Image taskImage = new Image();

                getUsersTask(task.taskId, taskPanel);

            }

            var userTaskObj = new UsersTaskBusinessObjects();

        }
        private void getUsersTask(Guid guid, Panel TaskPanel)
        {
            var userTaskBusinessObj = new BusinessLayer.UsersTaskBusinessObjects();

            _userTask = userTaskBusinessObj.GetUserTaskById(guid);
            foreach (var userstask in _userTask)
            {


                System.Diagnostics.Debug.Write("Userid" + userstask.userId);
                userId = (Guid)userstask.userId;
                getUserInfo(userId, TaskPanel);
            }

        }



        private void getUserInfo(Guid guid, Panel TaskContent)
        {
            var userBusinessObj = new BusinessLayer.UserBusinessObjects();
            _user = userBusinessObj.GetUserById(guid);
            System.Diagnostics.Debug.Write("User Info:" + _user.firstName + _user.lastName + _user.email + _user.image);
            Image TaskCreatorImage = new Image();
            TaskCreatorImage.CssClass = "place-right";
            TaskCreatorImage.Height = 80;
            TaskCreatorImage.Width = 80;
            TaskCreatorImage.ImageUrl = _user.image;
            TaskContent.Controls.Add(TaskCreatorImage);
            Literal userNameText = new Literal();
            userNameText.Text = "<h4 class=\"fg-color-white\">" + _user.firstName + " " + _user.lastName + "</h4>";
            TaskContent.Controls.Add(userNameText);


            Literal userEmail = new Literal();
            userEmail.Text = "<h5 class=\"fg-color-white\">" + _user.email + "</h5>";
            TaskContent.Controls.Add(userEmail);

        }
    }
}