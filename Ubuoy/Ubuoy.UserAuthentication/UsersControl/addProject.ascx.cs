using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ubuoy.UserAuthentication.BusinessLayer;

namespace Ubuoy.UserAuthentication.UsersControl
{
    public partial class addProject : System.Web.UI.UserControl
    {
        Guid orgId;
        string description;
        DateTime startedOn;
        DateTime endedOn;
        Int64 budget;
        Int64 recived;
        DateTime updateDate;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveProject(object sender, EventArgs e)
        {
            
            orgId = new Guid(ddl_Organization.SelectedValue.ToString());
            description = ta_Description.Value;
            budget = Convert.ToInt64(tbx_Budget.Text);
            recived = Convert.ToInt64(tbx_Recived.Text);
            
            startedOn = DateTime.Parse(tbx_StartedOn.Text);
            
            endedOn = DateTime.Parse(tbx_EndedOn.Text);
            updateDate = DateTime.Now;
            //System.Diagnostics.Debug.Write("All the values for project"+updateDate.Date+startedOn.Date+endedOn.Date+description);
         
            var projObj = new ProjectBussinessObjects();
            bool projectAdded = projObj.AddProject(description, startedOn.Date, endedOn.Date, budget, recived, orgId, updateDate.Date);
            
            if(projectAdded)
            {     
            Label1.Text = "Successfully inserted";
            }
            else
             {
                 Label1.Text = "Something went wrong, Exception message: ";
             }     
        }
    }
}