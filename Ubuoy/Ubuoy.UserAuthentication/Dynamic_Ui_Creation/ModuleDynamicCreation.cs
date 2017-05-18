using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ubuoy.UserAuthentication.Model;
using Ubuoy.UserAuthentication.BusinessLayer;
using System.Web.UI.WebControls;

namespace Ubuoy.UserAuthentication.Dynamic_Ui_Creation
{
    public class ModuleDynamicCreation
    {
        private Module _userModules;
        private int count2 = 0;
        private int count = 0;

        public HyperLink ModuleCreation(Guid usersModuleId, bool priority, string fgColor, string bgColor)
        {
            var ModuleObj = new BusinessLayer.ModuleBusinessObjects();

            //to get a module with userId
            _userModules = ModuleObj.GetModuleOfUserId(usersModuleId);

            //main panel
            HyperLink ModuleContent = new HyperLink();

            ModuleContent.Attributes.Add("onclick", "event.preventDefault();");
            ModuleContent.Attributes.Add("oncontextmenu", "return false; event.preventDefault();");

            ModuleContent.ID = "qq";
            //?id=" + Category.categoryId
            ModuleContent.NavigateUrl = "#";

            //get panel for the project according to prority and bg color
            mainPanelByPriority(priority, bgColor, ModuleContent);

            //Module image tile creation panel
            Panel moduleImagePanel = new Panel();

            //creating contents for image panel
            panelImageTile(moduleImagePanel);

            //Adding module image panel to main panel 
            ModuleContent.Controls.Add(moduleImagePanel);
            
            //creating moduleBrand panel
            Panel moduleBrandPanel = new Panel();

            //getting module brand and all its contains with forground color
            panelModuleBrandAndContains(moduleBrandPanel, fgColor);

            //adding brand and its containt to main panel
            ModuleContent.Controls.Add(moduleBrandPanel);
          return ModuleContent;
        }
        public void mainPanelByPriority(bool priority, string bgColor, HyperLink modCont)
        {
            if (priority == true)
            {
                count++;
                //<div class="tile double double-vertical icon bg-color-ubuoy border-color-LightGrey" data-role="tile-slider" data-param-period="3000">
                modCont.CssClass = "tile double double-vertical icon bg-color-" + bgColor + " border-color-LightGrey";
                modCont.ID = "ModuleContentTrue" + count;

            }
            else
            {
                count2++;
                modCont.CssClass = "tile icon bg-color-" + bgColor + " border-color-LightGrey";
                modCont.ID = "ModuleContentFalse" + count2;
            }
            
        }
        public void panelImageTile(Panel moduleImagePanel)
        {
            moduleImagePanel.CssClass = "tile-content";

            //Module image creation
            Image moduleImage = new Image();
            moduleImage.ImageUrl = "UI/" + _userModules.icon;
            moduleImage.ID = _userModules.name;
            moduleImagePanel.Controls.Add(moduleImage);

        }
        public void panelModuleBrandAndContains(Panel brandAndContains, string fgColor)
        {
            brandAndContains.CssClass = "brand";
            //creating moduleBadge panel
            Panel moduleBadge = new Panel();
            moduleBadge.CssClass = "badge fg-color-" + fgColor;

            Literal badgeText = new Literal();
            badgeText.Text = "23";
            moduleBadge.Controls.Add(badgeText);

            brandAndContains.Controls.Add(moduleBadge);

            Label ModuleName = new Label();
            ModuleName.CssClass = "name fg-color-" + fgColor;
            ModuleName.Text = _userModules.name;

            brandAndContains.Controls.Add(ModuleName);

        }
    }


}


