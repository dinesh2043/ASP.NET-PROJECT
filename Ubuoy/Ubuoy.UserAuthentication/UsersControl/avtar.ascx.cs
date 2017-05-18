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
    public partial class avtar : System.Web.UI.UserControl
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
            lbl_FirstName.Text = _currentUser.firstName;
            lbl_LastName.Text = _currentUser.lastName;
            
            imgProfile.ImageUrl = "~/"+_currentUser.image;
        }
    }
}