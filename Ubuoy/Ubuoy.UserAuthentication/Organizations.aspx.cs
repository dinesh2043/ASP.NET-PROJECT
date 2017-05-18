using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ubuoy.UserAuthentication
{
    public partial class Organizations : System.Web.UI.Page
    {
        void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {

            }
            else
            {
                MasterPageFile = "~/uBuoyMasterNA.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}