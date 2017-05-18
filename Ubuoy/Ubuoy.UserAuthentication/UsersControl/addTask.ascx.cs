using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ubuoy.UserAuthentication.BusinessLayer;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication.UsersControl
{
    public partial class addTask : System.Web.UI.UserControl
    {
        
        string description;
        string price;
        User _currentUser;
        //DateTime startDate;
        DateTime endDate;
        DateTime updateDate;
        Guid userId;
        string userName;
        UsersTask _usersTask;
        Task _task;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                userId = (Guid)Session["UserId"];
                var userobj = new BusinessLayer.UserBusinessObjects();
                _currentUser = userobj.GetUserById(userId);
                userName = _currentUser.firstName;
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        }

        protected void SaveTask(object sender, EventArgs e)
        {
           var categoryName = ddl_category.SelectedValue.ToString();
           var skillName = ddl_skill.SelectedValue.ToString();
            description = ta_description.Value;

            //startDate = DateTime.Parse(tbx_StartDate.Text);

            endDate = DateTime.Parse(tbx_deadline.Text);
            updateDate = DateTime.Now;
            price = tbx_price.Text;
            System.Diagnostics.Debug.Write("All the values for project"+updateDate.Date+endDate.Date+description);
            
            var taskObj = new TaskBusinessObjects();
            bool projectAdded = taskObj.AddTask(description, price, endDate, new Guid(categoryName),new Guid(skillName),userName, updateDate);

            if (projectAdded)
            {
                _task = taskObj.GetTaskByUpdateDate(updateDate);
                //System.Diagnostics.Debug.Write("user and task id:" + _currentUser.userId + _task.taskId);
                var userTaskObj = new UsersTaskBusinessObjects();
                bool addUsersTask = userTaskObj.AddUsersTask(_currentUser.userId,_task.taskId);
                if (addUsersTask)
                {
                    //Label2.Text = "Successfully inserted";
                    Response.Redirect("~/UbuoyIndex.aspx");
                }
            }
            else
            {
                Label2.Text = "Something went wrong, Exception message: ";
            }     


        }
    }
}