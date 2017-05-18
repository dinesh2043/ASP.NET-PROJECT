using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ubuoy.UserAuthentication
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if(!Page.IsPostBack)
            //    {
            //      var categoryBusinessObj = new BusinessLayer.CategoryBusinessObjects();
            //        DropDownList1.DataSource = categoryBusinessObj.GetCategoryAccordingToParent(string.Empty);
            //        DropDownList1.DataBind();
            //    }
            
           
        }

        //protected void OnSelected(object sender, EventArgs e)
        //{
        //    var categoryBusinessObj = new BusinessLayer.CategoryBusinessObjects();
        //    var test = categoryBusinessObj.GetDetailCategoryAccordingToParent(DropDownList1.SelectedValue);
        //    DropDownList2.DataSource = test;
        //    DropDownList2.DataBind();

        //}
    }
}