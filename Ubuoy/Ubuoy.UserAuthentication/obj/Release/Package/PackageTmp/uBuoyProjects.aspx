<%@ Page Title="" Language="C#" MasterPageFile="~/uBuoyMaster.Master" AutoEventWireup="true" CodeBehind="uBuoyProjects.aspx.cs" Inherits="Ubuoy.UserAuthentication.uBuoyProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageRegionContent" runat="server">
    <div class="page-region-content tiles">
        <div class="tile-group tile-drag" id="tileGroupProject" runat="server">
            <h3>uBuouy Projects ></h3>
            <asp:PlaceHolder ID="Projects" runat="server"></asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
