using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ubuoy.UserAuthentication.UsersControl
{
    public partial class Address : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            var saveAdress = new BusinessLayer.AddressBusinessObjects();
            bool addressSave = saveAdress.AddAddress(tbx_country.Text, tbx_city.Text, Convert.ToInt32(tbx_postalCode.Text), tbx_streetAdress.Text, tbx_phone.Text, tbx_email.Text);

            if (addressSave)
            {

                //pnlSuccess.Visible = true;
            }
            else
            {
                //lblValidation.Text =  ValidationHelper.GetValidationMessage(ubuoyAuth.ValidationSummary);
                //pnlError.Visible = true;
            }
        }
    }
}