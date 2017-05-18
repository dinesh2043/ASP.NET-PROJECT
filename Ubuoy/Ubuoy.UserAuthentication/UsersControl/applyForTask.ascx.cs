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
    public partial class applyForTask : System.Web.UI.UserControl
    {
        string output;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
            
            
        }

        protected void dd_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid skillId = new Guid(dd_list.SelectedValue);
            var taskObj = new TaskBusinessObjects();
            gv_Task.DataSource = taskObj.GetTaskBySkillId(skillId);
            gv_Task.DataBind();
            /**if (gv_Task.Columns.Count > 0)
            {
                gv_Task.Columns[0].Visible = false;
                gv_Task.Columns[7].Visible = false;
                gv_Task.Columns[9].Visible = false;

            }
            else
            { **/
                gv_Task.HeaderRow.Cells[0].Visible = false;
                gv_Task.HeaderRow.Cells[7].Visible = false;
                gv_Task.HeaderRow.Cells[9].Visible = false;
                foreach (GridViewRow gvr in gv_Task.Rows)
                {
                    gvr.Cells[0].Visible = false;
                    gvr.Cells[7].Visible = false;
                    gvr.Cells[9].Visible = false;
                    CheckBox cb = new CheckBox();
                    //cb = (CheckBox)gvr.FindControl("CheckBox1");

                    if ((cb != null) && (cb.Checked == true))
                    {
                        output += gvr.Cells[1].Text.ToString() + ",";
                    }
                }
                System.Diagnostics.Debug.Write("This is checked: "+output);
            }
            
        }

        
    }
