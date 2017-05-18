using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ubuoy.UserAuthentication.Model;
using System.Web.UI.HtmlControls;

namespace Ubuoy.UserAuthentication.UsersControl
{
    public partial class addOrganization : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveOrg(object sender, EventArgs e)
        {
            try
            {
                Label1.Text = string.Empty;
            var saveOrganization = new BusinessLayer.OrginizationBusinessObjects();
            string desc = tar_OrgDescription.Value;
            bool organizationSave = saveOrganization.AddOrganization(tbx_OrgName.Text, desc, tbx_WebAddress.Text, ddl_OrgBgColor.Text, ddl_OrgFgColor.Text, tbx_country.Text, tbx_city.Text, Convert.ToInt32(tbx_postalCode.Text), tbx_streetAdress.Text, tbx_phone.Text, tbx_email.Text);
            Label1.Text = "Successfully inserted";
            }
            catch (Exception ex)
            {
                Label1.Text = "Something went wrong, Exception message: " + ex.Message;
            } 

        }

        
    }
}