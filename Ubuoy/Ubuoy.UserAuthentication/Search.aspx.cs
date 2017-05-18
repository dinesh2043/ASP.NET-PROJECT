using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ubuoy.UserAuthentication
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var searchPhrase = Request.QueryString["phrase"].ToString();
            lbl_phrase.Text = searchPhrase;
            Page.Title = "Search";
            Label formHaderLabel = (Label)Master.FindControl("formHaderLabel");
            formHaderLabel.Text = "| Detailed Search";
        }
    }
}