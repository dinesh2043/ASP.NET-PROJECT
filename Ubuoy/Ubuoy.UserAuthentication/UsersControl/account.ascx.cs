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
    public partial class userInfo : System.Web.UI.UserControl
    {
        Guid userId;
        User _currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            userId=(Guid)Session["UserId"];
            var userObj = new UserBusinessObjects();
            _currentUser = userObj.GetUserById(userId);
            userInfoAccount();
            lbl_email.Text = _currentUser.email;
            lbl_dob.Text = _currentUser.DOB.ToString();
            lbl_gender.Text = _currentUser.gender;
            if (_currentUser.phoneNumber != null)
            {
                pnl_userContactInfo.Visible = true;
                lbl_phone.Text = _currentUser.phoneNumber;
                lbl_city.Text = _currentUser.city;
                lbl_country.Text = _currentUser.country;
                lbl_postalCode.Text = _currentUser.postalCode.ToString();
                lbl_streetAdress.Text = _currentUser.streetAddress;
            }
            else
            {
                btn_addAddress.Visible = true;
            }


        }


        public void userInfoAccount()
        {
            lbl_Acc_FirstName_charms.Text = _currentUser.firstName;
            lbl_Acc_LastName_charms.Text = _currentUser.lastName;

            img_Acc_charms.ImageUrl = "~/" + _currentUser.image;
        }

        protected void editUserInfoForm(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms.aspx?formId=EditUserInfo");
        }
    }
}