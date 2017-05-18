using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ubuoy.UserAuthentication.Model;
using Ubuoy.UserAuthentication.BusinessLayer;

namespace Ubuoy.UserAuthentication.UsersControl
{
    public partial class settings : System.Web.UI.UserControl
    {
        User _currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = (Guid)Session["UserId"];
            var userobj = new BusinessLayer.UserBusinessObjects();
            _currentUser = userobj.GetUserById(userId);
            userInfo();
        }
        public void userInfo()
        {
            
            lbl_Set_FirstName_charms.Text = _currentUser.firstName;
            lbl_Set_LastName_charms.Text = _currentUser.lastName;

            img_Set_charms.ImageUrl = "~/" + _currentUser.image;
             
        }
        protected void logOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/UbuoyIndex.aspx");
        }
    }
}