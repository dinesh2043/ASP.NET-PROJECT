using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Ubuoy.UserAuthentication.BusinessLayer;
using Ubuoy.UserAuthentication.Model;

namespace Ubuoy.UserAuthentication
{
    public partial class UbuoyIndex : System.Web.UI.Page
    {
        private IEnumerable<Project> _projectCollection;
        private IEnumerable<Skill> _skillCollection;
        private IEnumerable<Task> _taskCollection;
        private UsersTask _userTask;
        private User _user;
        private List<string> colorCollection = new List<string> { "treePoppy", "teal", "shiraz", "selectiveYellow", "scienceBlue", "scarlet", "royalBlue", "rose", "robinsEggBlue", "purple", "pumpkin", "pistachio", "persianGreen", "nutmegWoodFinish", "milanoRed", "malibu", "malachite", "lipstick", "limeade", "japaneseLaurel", "hotPink", "heliotrope", "dodgerBlue", "corn", "blueGem" };

        private List<string> images;
        private int count;
        private string taskDescription;
        static Random rnd = new Random();
        Guid UserID;

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

            var projObject = new ProjectBussinessObjects();
            _projectCollection = projObject.GetLatestSixProject(string.Empty);



            foreach (var project in _projectCollection)
            {
                //get the project
                projectHyperLinkCreation(project);

            }

            var skillObj = new SkillBusinessObjects();
            _skillCollection = skillObj.GetLatestSixSkills(string.Empty);

            foreach (var skill in _skillCollection)
            {
                int r = rnd.Next(colorCollection.Count);

                HyperLink skillTileLink = new HyperLink();
                skillTileLink.NavigateUrl = "~/ubuoySkillDetail.aspx?id=" + skill.skillId;
                skillTileLink.CssClass = "tile double bg-color-ubuoy border-color-LightGrey";

                Panel SkillContentPanel = new Panel();
                SkillContentPanel.CssClass = "tile-content bg-color-" + (string)colorCollection[r] + "";
                skillTileLink.Controls.Add(SkillContentPanel);
                LatestSkills.Controls.Add(skillTileLink);
                SkillContentPanel.ID = "" + count;

                taskDescription = "<p class=\"fg-color-white\">" + skill.description + "</p>";
                UserID = (Guid)skill.userId;
                //for getting users info
                getUserFromSkill(SkillContentPanel, UserID);

                Panel brandPanel = new Panel();
                brandPanel.CssClass = "brand opacity bg-color-darken fg-color-white";
                SkillContentPanel.Controls.Add(brandPanel);

                Label categoryNameLabel = new Label();
                categoryNameLabel.CssClass = "text fg-color-white";
                categoryNameLabel.Text = skill.Category.Name;
                brandPanel.Controls.Add(categoryNameLabel);

                Panel updateDate = new Panel();
                updateDate.CssClass = "place-right padding5 tertiary-text fg-color-white";
                Literal taskCountText = new Literal();
                taskCountText.Text = "" + skill.updateDate;
                brandPanel.Controls.Add(updateDate);
                updateDate.Controls.Add(taskCountText);


            }


            var taskObj = new TaskBusinessObjects();
            _taskCollection = taskObj.GetLatestSixTask(string.Empty);


            foreach (var task in _taskCollection)
            {
                int r = rnd.Next(colorCollection.Count);
                HyperLink taskTileLink = new HyperLink();
                taskTileLink.NavigateUrl = "~/ubuoyTaskDetails.aspx?id=" + task.taskId;
                taskTileLink.CssClass = "tile double bg-color-ubuoy border-color-LightGrey";

                Panel TaskContentPanel = new Panel();
                TaskContentPanel.CssClass = "tile-content bg-color-" + (string)colorCollection[r] + "";
                taskTileLink.Controls.Add(TaskContentPanel);
                LatestTasks.Controls.Add(taskTileLink);
                TaskContentPanel.ID = "" + count;

                taskDescription = "<p class=\"fg-color-white\">" + task.description + "</p>";

                //for getting users info
                getUsersTask(TaskContentPanel, task.taskId);

                Panel brandPanel = new Panel();
                brandPanel.CssClass = "brand opacity bg-color-darken fg-color-white";
                TaskContentPanel.Controls.Add(brandPanel);

                Label categoryNameLabel = new Label();
                categoryNameLabel.CssClass = "text fg-color-white";
                categoryNameLabel.Text = task.Category.Name;
                brandPanel.Controls.Add(categoryNameLabel);

                Panel updateDate = new Panel();
                updateDate.CssClass = "place-right padding5 tertiary-text fg-color-white";
                Literal taskCountText = new Literal();
                taskCountText.Text = "" + task.updateDate;
                brandPanel.Controls.Add(updateDate);
                updateDate.Controls.Add(taskCountText);


            }

        }

        private void getUserFromSkill(Panel SkillContentPanel, Guid userId)
        {
            var userBusinessObj = new BusinessLayer.UserBusinessObjects();
            _user = userBusinessObj.GetUserById(userId);
            System.Diagnostics.Debug.Write("User Info:" + _user.firstName + _user.lastName + _user.email + _user.image);
            Image TaskCreatorImage = new Image();
            TaskCreatorImage.CssClass = "place-right";
            TaskCreatorImage.Attributes.Add("style", "background-color:#fff;");
            TaskCreatorImage.Height = 80;
            TaskCreatorImage.Width = 80;
            TaskCreatorImage.ImageUrl = _user.image;
            SkillContentPanel.Controls.Add(TaskCreatorImage);

            Literal userNameText = new Literal();
            userNameText.Text = "<h4 class=\"fg-color-white\">" + _user.firstName + " " + _user.lastName + "</h4>";
            SkillContentPanel.Controls.Add(userNameText);

            Literal descTask = new Literal();
            descTask.Text = "<p class=\"fg-color-white\">" + taskDescription + "</p>";
            SkillContentPanel.Controls.Add(descTask);

            Literal userEmail = new Literal();
            userEmail.Text = "<h5 class=\"fg-color-white\">" + _user.email + "</h5>";
            SkillContentPanel.Controls.Add(userEmail);

        }
        private void getUsersTask(Panel TaskContent, Guid guid)
        {
            var userTaskBusinessObj = new BusinessLayer.UsersTaskBusinessObjects();

            _userTask = userTaskBusinessObj.GetAUserTaskById(guid);


            getUserInfo((Guid)_userTask.userId, TaskContent);


        }
        private void getUserInfo(Guid guid, Panel TaskContent)
        {
            var userBusinessObj = new BusinessLayer.UserBusinessObjects();
            _user = userBusinessObj.GetUserById(guid);
            System.Diagnostics.Debug.Write("User Info:" + _user.firstName + _user.lastName + _user.email + _user.image);
            Image TaskCreatorImage = new Image();
            TaskCreatorImage.CssClass = "place-right";
            TaskCreatorImage.Attributes.Add("style", "background-color:#fff;");
            TaskCreatorImage.Height = 80;
            TaskCreatorImage.Width = 80;
            TaskCreatorImage.ImageUrl = _user.image;
            TaskContent.Controls.Add(TaskCreatorImage);

            Literal userNameText = new Literal();
            userNameText.Text = "<h4 class=\"fg-color-white\">" + _user.firstName + " " + _user.lastName + "</h4>";
            TaskContent.Controls.Add(userNameText);

            Literal descTask = new Literal();
            descTask.Text = "<p class=\"fg-color-white\">" + taskDescription + "</p>";
            TaskContent.Controls.Add(descTask);

            Literal userEmail = new Literal();
            userEmail.Text = "<h5 class=\"fg-color-white\">" + _user.email + "</h5>";
            TaskContent.Controls.Add(userEmail);


        }

        public void projectHyperLinkCreation(Project proj)
        {
            if (proj.endOn > DateTime.Now)
            {
                
                //for getting projects image from image package table
                images = new List<string> { proj.ImagePackage.image1, proj.ImagePackage.image2, proj.ImagePackage.image3, proj.ImagePackage.image4, proj.ImagePackage.image5, proj.ImagePackage.image6, proj.ImagePackage.image7, proj.ImagePackage.image8, proj.ImagePackage.image9, proj.ImagePackage.image10 };

                //main panel
                HyperLink ProjContent = new HyperLink();
                ProjContent.Attributes.Add("onclick", "event.preventDefault();");

                //oncontextmenu="return false;"

                //?id=" + Category.categoryId
                ProjContent.NavigateUrl = "~/uBuoyProjectDetails.aspx?progId=" + proj.projectId;

                //add this hyperlink to main place holder in aspx page
                IndexProject.Controls.Add(ProjContent);
                //getting main panel content for project with priority
                projectMainPanel(proj, ProjContent);

                //getting image content in main panel
                projectImagesPanel(proj, ProjContent);

                //getting badge and brand panel
                projectBrandAndBadgePanel(proj, ProjContent);
            }


        }

        public void projectMainPanel(Project proj, HyperLink mainContent)
        {

            count++;
            mainContent.CssClass = "tile double image border-color-LightGrey";
            //mainContent.ID = "ProjContentFalse" + count2;
            mainContent.Attributes.Add("data-role", "tile-slider");
            mainContent.Attributes.Add("data-param-period", "3000");
            mainContent.ID = "Project" + count + "";
            mainContent.Attributes.Add("oncontextmenu", "return false; event.preventDefault();");
        }

        public void projectImagesPanel(Project proj, HyperLink mainContent)
        {
            foreach (string image in images)
            {
                if (image == null)
                {
                    //do not do any thing
                }
                else
                {
                    count++;
                    //looping project image tile creation
                    Panel tileContentImage = new Panel();
                    tileContentImage.CssClass = "tile-content";

                    //looping project image creation
                    Image projectImage = new Image();
                    projectImage.ImageUrl = "UI/" + image;
                    projectImage.ID = "projectImage" + count;
                    tileContentImage.Controls.Add(projectImage);

                    //add main panel with image panel
                    mainContent.Controls.Add(tileContentImage);


                }
            }

        }
        public void projectBrandAndBadgePanel(Project proj, HyperLink mainContent)
        {
            decimal projectProcent = ((decimal)proj.recived * 100) / (decimal)proj.budget;
            decimal formatedProcent = Math.Round(Convert.ToDecimal(projectProcent), 0);

            Label badgelabel = new Label();
            badgelabel.CssClass = "badge fg-color-" + proj.Orginization.orgFgColor;
            badgelabel.Text = formatedProcent + "%";
            //brand div of the project creation
            Panel brandOrg = new Panel();
            brandOrg.CssClass = "brand bg-color-" + proj.Orginization.orgBgColor;

            Panel progressBar = new Panel();
            progressBar.CssClass = "progress-bar";
            brandOrg.Controls.Add(progressBar);
            Panel progBarDone = new Panel();
            progBarDone.CssClass = "bar bg-color-green";
            progBarDone.Attributes.Add("style", "width:" + formatedProcent + "%");
            Panel progBarToGo = new Panel();
            progBarToGo.CssClass = "bar bg-color-yellow";
            progBarToGo.Attributes.Add("style", "width:" + (100 - formatedProcent) + "%");
            progressBar.Controls.Add(progBarDone);
            progressBar.Controls.Add(progBarToGo);
            //badge div of the project creation
            Panel projBadge = new Panel();
            projBadge.CssClass = "badge";
            projBadge.Controls.Add(badgelabel);
            //orgLogo image of the project creation
            Image orgLogoImg = new Image();
            orgLogoImg.CssClass = "icon";
            orgLogoImg.ImageUrl = "UI/" + proj.Orginization.orgLogo;


            mainContent.Controls.Add(brandOrg);
            brandOrg.Controls.Add(orgLogoImg);

            Literal discLiteral = new Literal();
            discLiteral.Text = "<p class=\"text fg-color-" + proj.Orginization.orgFgColor + "\"> " + proj.description + "</p>";
            brandOrg.Controls.Add(discLiteral);
            brandOrg.Controls.Add(projBadge);

        }


    }
}
