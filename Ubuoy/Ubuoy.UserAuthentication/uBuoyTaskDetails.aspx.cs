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
    public partial class uBuoyTaskDetails : System.Web.UI.Page
    {
        Orginization _org;
        
        int price;
        decimal projPrice;
        User _currentUser;
        Guid userId;
        Guid orgId;
        Guid projectId;

        void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                userId = (Guid)Session["UserId"];
                var userobj = new BusinessLayer.UserBusinessObjects();
                _currentUser = userobj.GetUserById(userId);

            }
            else
            {
                MasterPageFile = "~/uBuoyMasterNA.Master";
            }
        }

        //User _user;
        //Guid userId;
        Task _task;
        protected void Page_Load(object sender, EventArgs e)
        {


            var catId = Request.QueryString["id"].ToString();
            System.Diagnostics.Debug.Write("id test:" + catId);
            Guid id = new Guid(catId);
            var taskObj = new TaskBusinessObjects();
            _task = taskObj.GetTaskByTaskId(id);

            lbl_deadline.Text = Convert.ToString(_task.deadline);
            lbl_description.Text = _task.description;
            lbl_owner.Text = _task.owner;
            lbl_price.Text = Convert.ToString(_task.money);

            /**
                Panel taskPanel = new Panel();
                taskDitails.Controls.Add(taskPanel);
                Label taskDescription = new Label();
       
                taskDescription.Text = _task.description + ", " + _task.owner + ", " + _task.doer + ", " + _task.deadline+","+_task.money;
                taskPanel.Controls.Add(taskDescription);
                //Image taskImage = new Image();
             * **/
        }

        protected void ApplyTask(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
            pnl_Apply.Visible = true;
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void MakeDonation(object sender, EventArgs e)
        {
            projectId = new Guid(ddl_Project.SelectedValue.ToString());

            //var projObj = new ProjectBussinessObjects();
            var projObj = new Model.GenericRepository<Project>();
            var project = projObj.Single(x => x.projectId.Equals(projectId));
            
            var orgObj = new OrginizationBusinessObjects();
            orgId = (Guid)project.organizationId;
            _org=orgObj.GetOrganizationById(orgId);

            lbl_Organization.Text ="Organization Name:" + _org.name;
           
            var appObject = new ApplicationBusinessObjects();
            bool application = appObject.AddApplication(userId,_task.taskId, projectId,_task.money);

            price = Convert.ToInt32(_task.money);
            
            //projPrice = (decimal)price / 100;
            projPrice = price + (decimal)project.recived;
            System.Diagnostics.Debug.Write("money:" + projPrice);
            
            project.recived = projPrice;
            projObj.SaveChanges();
            
            if (application)
            {
                Label2.Text = "Sucessfully applied";
                Response.Redirect("~/UbuoyIndex.aspx");
            }
            else
            {
                Label2.Text = "Unable to apply";
            }

        }
      
    }
}