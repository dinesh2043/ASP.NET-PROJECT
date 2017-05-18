using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ubuoy.UserAuthentication
{
    public partial class Forms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userControlName = Request.QueryString["formId"].ToString();

            switch (userControlName)
            {
                case "AddProject":
                    addProject.Visible = true;
                    Page.Title = "Add a Project";
                    Label formHaderLabel = (Label)Master.FindControl("formHaderLabel");
                    formHaderLabel.Text = "| Add a Project";

                    break;

                case "AddSkill":
                    addSkill.Visible = true;
                    Page.Title = "Add a Skill";
                    Label formHaderLabel2 = (Label)Master.FindControl("formHaderLabel");
                    formHaderLabel2.Text = "| Add a Skill";

                    break;
                case "AddTask":
                    addTask.Visible = true;
                    Page.Title = "Add a Task";
                    Label formHaderLabel3 = (Label)Master.FindControl("formHaderLabel");
                    formHaderLabel3.Text = "| Add a Task";
                    break;
                case "EditUserInfo":
                    editUserInfo.Visible = true;
                    Page.Title = "Edit User Info";
                    Label formHaderLabel4 = (Label)Master.FindControl("formHaderLabel");
                    formHaderLabel4.Text = "| Edit User Info";

                    break;
            }


        }
    }
}