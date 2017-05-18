using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ubuoy.UserAuthentication
{
    public partial class uBuoyMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Search_Event(object sender, EventArgs e)
        {
            Response.Redirect("~/Search.aspx?phrase=" + tbx_search.Value);
        }

        protected void addSkillRedirect(object sender, EventArgs e)
        {
            //Response.Redirect("~/Forms.aspx?formId=AddSkill");
        }
    }
}