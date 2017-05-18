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
    public partial class EditUserInfo : System.Web.UI.UserControl
    {
        Guid userId;
        User _currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = (Guid)Session["UserId"];
            var userObj = new UserBusinessObjects();
            _currentUser = userObj.GetUserById(userId);
            tbx_email.Text = _currentUser.email;
            tbx_firstName.Text = _currentUser.firstName;
            tbx_lastName.Text = _currentUser.lastName;
            tbx_Phone.Text = _currentUser.phoneNumber;
            tbx_City.Text = _currentUser.city;
            tbx_country.Text = _currentUser.country;
            tbx_postalCode.Text =Convert.ToString(_currentUser.postalCode);
            tbx_streetAddress.Text = _currentUser.streetAddress;
            tbx_DOB.Text = Convert.ToString(_currentUser.DOB);
            

        }

        protected void Save(object sender, EventArgs e)
        {
            var UserObj = new Model.GenericRepository<User>();
            var user = UserObj.Single(x => x.userId.Equals(userId));
            user.firstName = tbx_firstName.Text;
            user.lastName = tbx_lastName.Text;
            user.email = tbx_email.Text;
            user.phoneNumber = tbx_Phone.Text;
            user.country = tbx_country.Text;
            user.city = tbx_City.Text;
            user.DOB = Convert.ToDateTime(tbx_DOB.Text);
            user.postalCode =Convert.ToInt16(tbx_postalCode.Text);
            user.streetAddress = tbx_streetAddress.Text;
            UserObj.SaveChanges();
            Response.Redirect("~/UbuoyIndex.aspx");

        }
    }
}