using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Ubuoy.UserAuthentication
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        public string gender;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack){
            String[] genderValues = new String[2];
            genderValues[0] = "Male";
            genderValues[1] = "Female";
            pnlSuccess.Visible = false;
            pnlError.Visible = false;
            dDLGender.DataSource = genderValues;
            dDLGender.DataBind();
            }
        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            gender = dDLGender.SelectedItem.Text;
            //System.Diagnostics.Debug.Write("Selected Value:"+tbx_DOB.Text);
            string date = tbx_DOB.Text;
            string[] split = date.Split('/');
            string properDate = split[1] + "/" + split[0] + "/" + split[2];
            DateTime dt = DateTime.Parse(properDate);

            string defaultImage = "UI/images/profile/icon-ubuoy2.png";
            //System.Diagnostics.Debug.Write("Date in finish format" + dt.Date);
            
            var ubuoyAuth = new BusinessLayer.UserBusinessObjects();
            bool userRegistered = ubuoyAuth.RegisterUser(tbEmail.Text, tbPassword.Text, tbPassword2.Text, tbFirstName.Text, tbLastName.Text, gender, dt.Date, defaultImage);

            if (userRegistered)
            {
                pnlSuccess.Visible = true;                
            }
            else
            {
                //lblValidation.Text =  ValidationHelper.GetValidationMessage(ubuoyAuth.ValidationSummary);
                pnlError.Visible = true;
            }
        }

        protected void SelectGender(object sender, EventArgs e)
        {
            gender = dDLGender.SelectedItem.Text;

        }

       
    }

}