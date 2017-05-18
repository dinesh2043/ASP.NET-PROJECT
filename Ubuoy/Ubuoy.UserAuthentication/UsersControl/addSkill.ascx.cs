using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ubuoy.UserAuthentication.Helper;
using Ubuoy.UserAuthentication.Model;


namespace Ubuoy.UserAuthentication.UsersControl
{
    public partial class addSkill : System.Web.UI.UserControl
    {
        User _currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                Guid userId = (Guid)Session["UserId"];
                var userobj = new BusinessLayer.UserBusinessObjects();
                _currentUser = userobj.GetUserById(userId);
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        }

        protected void btnAddSkill_Click(object sender, EventArgs e)
        {
            try
            {
                Label1.Text = string.Empty;
                var categoryName = DropDownList1.SelectedValue.ToString();
                var userId = (Guid)Session["UserId"];
                var categoryService = new BusinessLayer.CategoryBusinessObjects();

                var selectedCategory = categoryService.GetCategoryById(new Guid(categoryName));
                
                var skillService = new BusinessLayer.SkillBusinessObjects(); 
                var category = categoryService.GetCategoryById(new Guid(categoryName));
                DateTime updateDate = DateTime.Now;

                System.Diagnostics.Debug.Write("current date time"+updateDate);
                
                skillService.AddSkill(tbx_SkillName.Text, tb_SkillDesc.Text, new Guid(categoryName), userId, selectedCategory.image,updateDate);

                Label1.Text = "Successfully inserted";
                Response.Redirect("~/UbuoyIndex.aspx");
            
            
            }
            catch (Exception ex)
            {
                Label1.Text = "Something wen wrong, Exception message: " + ex.Message;
            }            
        }

        
    }
}

/*

 * 
 * var filePath = ConfigurationHelper.ReadFromWebConfiguration("FileLink");
            var path = filePath + @"\" + imgUpload.FileName; //Guid of the skill.jpg
            var bytes = imgUpload.FileBytes;
            ConfigurationHelper.AddImageToFile(bytes, path);
*/