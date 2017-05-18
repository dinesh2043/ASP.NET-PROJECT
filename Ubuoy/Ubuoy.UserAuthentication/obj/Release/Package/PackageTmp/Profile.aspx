<%@ Page Title="" Language="C#" MasterPageFile="~/uBuoyMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Ubuoy.UserAuthentication.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageRegionContent" runat="server">
    <div class="page-region-content tiles">

        <div class="tile-group tile-drag" id="tileGroupProject" runat="server">
            <a href="#"><h3>My Ubouy Projects ></h3></a>
            <asp:PlaceHolder ID="projectWithProrityTrue" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="projectWithProrityFalse" runat="server"></asp:PlaceHolder>

        </div>

        <div class="tile-group tile-drag" id="moduleGroup" runat="server">
            <a href="#"><h3>My Ubouy Modules ></h3></a>
            <asp:PlaceHolder ID="moduleWithProrityTrue" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="moduleWithProrityFalse" runat="server"></asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
