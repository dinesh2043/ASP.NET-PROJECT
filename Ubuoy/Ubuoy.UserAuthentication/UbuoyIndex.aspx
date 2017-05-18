<%@ Page Title="" Language="C#" MasterPageFile="~/uBuoyMaster.Master" AutoEventWireup="true" CodeBehind="UbuoyIndex.aspx.cs" Inherits="Ubuoy.UserAuthentication.UbuoyIndex" %>

<asp:Content ID="uBuoyIndex" ContentPlaceHolderID="PageRegionContent" runat="server">

    <div class="page-region-content tiles">

        <div class="tile-group tile-drag" id="LatestNews" runat="server">

            <a href="ubuoyNews.aspx" onclick="window.location='ubuoyNews.aspx';">
                <h3>News ></h3>
            </a>

            <a id="A11" class="tile quadro double-vertical image border-color-LightGrey" onclick="event.preventDefault();" oncontextmenu="return false; event.preventDefault();" href="#">

                <div class="tile-content">
                    <img id="Img54" src="UI/images/organizations/79177e2c-b980-4040-bda6-2e525424231c/projects/2dcb18a7-a231-45c2-aac2-a18dbe432090/image3.jpg">
                </div>
                <div class="brand bg-color-white">
                    <img class="icon" src="UI/images/organizations/79177e2c-b980-4040-bda6-2e525424231c/79177e2c-b980-4040-bda6-2e525424231c.png">
                    <p class="text fg-color-black">Red Cross has opened new office in Helsinki</p>
                </div>
            </a>
            <a id="A12" class="tile double image border-color-LightGrey" onclick="event.preventDefault();" oncontextmenu="return false; event.preventDefault();" href="#">


                <div class="tile-content">
                    <img id="Img60" src="UI/images/organizations/01219744-042e-4d1f-a44d-dccb517749d1/projects/59216ab9-e47e-4b8b-bb48-ef229da544de/image5.jpg">
                </div>
                <div class="brand bg-color-white">
                    <img class="icon" src="UI/images/organizations/01219744-042e-4d1f-a44d-dccb517749d1/01219744-042e-4d1f-a44d-dccb517749d1.png">
                    <p class="text fg-color-black">UNICEF has hired 20 new workers for the summer project</p>

                </div>
            </a>
            <a id="A13" class="tile double image border-color-LightGrey" onclick="event.preventDefault();" oncontextmenu="return false; event.preventDefault();" href="#">

                <div class="tile-content">
                    <img id="Img70" src="UI/images/organizations/b5e6d10d-43c0-4670-8215-35a0b216055b/projects/c5384f36-748c-4086-9295-038937992120/image3.jpg">
                </div>
                <div class="brand bg-color-worldvision">
                    <img class="icon" src="UI/images/organizations/b5e6d10d-43c0-4670-8215-35a0b216055b/b5e6d10d-43c0-4670-8215-35a0b216055b.png">
                    <p class="text fg-color-white">WorldVision has raised 30,000 euro using uBuoy</p>
                </div>
            </a>
            <a id="A14" class="tile double image border-color-LightGrey" onclick="event.preventDefault();" oncontextmenu="return false; event.preventDefault();" href="#">
                <div style="position: absolute; left: 0px; top: -148px;" class="tile-content">
                    <img id="Img73" src="UI/images/organizations/b3be8058-66fa-4199-8a82-5d438b713e7c/projects/ac2c45f4-3331-4b81-8df6-0a04e2ed7676/image2.jpg">
                </div>
                <div class="tile-content">
                    <img id="Img74" src="UI/images/organizations/b3be8058-66fa-4199-8a82-5d438b713e7c/projects/ac2c45f4-3331-4b81-8df6-0a04e2ed7676/image3.jpg">
                </div>
                <div class="brand bg-color-goal">
                    <img class="icon" src="UI/images/organizations/b3be8058-66fa-4199-8a82-5d438b713e7c/b3be8058-66fa-4199-8a82-5d438b713e7c.png">
                    <p class="text fg-color-white">GOAL sent 1000 kilogramm of rice to the remote vilage in Afganistan</p>
                </div>
            </a>
            <a id="A15" class="tile double image border-color-LightGrey" onclick="event.preventDefault();" oncontextmenu="return false; event.preventDefault();" href="#">
                <div class="tile-content">
                    <img id="Img78" src="UI/images/organizations/0ca27bef-3af0-475e-ade1-537b300fd3c2/projects/9fad58ac-516c-4486-b471-322fe92a98b9/image4.jpg">
                </div>
                <div class="brand bg-color-lasten">
                    <img class="icon" src="UI/images/organizations/0ca27bef-3af0-475e-ade1-537b300fd3c2/0ca27bef-3af0-475e-ade1-537b300fd3c2.png">
                    <p class="text fg-color-white">LASTENSUOJELUN KESKUSLIITTO started a new project</p>

                </div>
            </a>

        </div>

        <div class="tile-group tile-drag" id="LatestProjects" runat="server">
            <a href="uBuoyProjects.aspx" onclick="window.location='uBuoyProjects.aspx';">
                <h3>Projects ></h3>
            </a>
            <asp:PlaceHolder ID="IndexProject" runat="server"></asp:PlaceHolder>

        </div>

        <div class="tile-group tile-drag" id="LatestTasks" runat="server">
            <a href="ubuoyTasks.aspx" onclick="window.location='ubuoyTasks.aspx';">
                <h3>Tasks ></h3>
            </a>


        </div>
        <div class="tile-group tile-drag" id="LatestSkills" runat="server">
            <a href="ubuoySkills.aspx" onclick="window.location='ubuoySkills.aspx';">
                <h3>Skills ></h3>
            </a>


        </div>
    </div>

</asp:Content>
