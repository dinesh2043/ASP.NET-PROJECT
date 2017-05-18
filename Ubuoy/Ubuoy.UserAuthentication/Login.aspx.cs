using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ubuoy.UserAuthentication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            var email = tbEmail.Text;
            var password = tbPassword.Text;
            var UbuoyAuthentication = new BusinessLayer.UserBusinessObjects();
            if (email != null && password != null)
            {
                if (UbuoyAuthentication.UserExists(email, password))
                {
                    var user = UbuoyAuthentication.GetUserByEmailAndPassword(email, password);
                    Session["LoggedIn"] = true;
                    Session.Timeout = 6000;
                    Session["UserId"] = user.userId;
                    Session["UserRole"] = user.Roles.SourceRoleName;
                    //System.Diagnostics.Debug.WriteLine("userRole" + Session["UserRole"] + Session["UserId"]);
                    //var redirectString = "~/Profile.aspx?UserId="+user.userId;
                    var redirectString = "~/Profile.aspx";
                    Response.Redirect(Server.HtmlEncode(redirectString));
                }
                else
                {
                    lblLoginFail.Text = "Wrong Credentials";
                    pnlError.Visible = true;
                }
            }
            else
            {
                lblLoginFail.Text = "Type email and password to logIn";
                pnlError.Visible = true;
            }
        }

       
    }
}