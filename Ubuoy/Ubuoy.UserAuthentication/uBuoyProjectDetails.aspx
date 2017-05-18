<%@ Page Title="" Language="C#" MasterPageFile="~/uBuoyMaster.Master" AutoEventWireup="true" CodeBehind="uBuoyProjectDetails.aspx.cs" Inherits="Ubuoy.UserAuthentication.uBuoyProjectDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageRegionContent" runat="server">

    <div class="page-region-content">
        <asp:PlaceHolder ID="ProjectContent" runat="server">
                    This is ubuoy Project Detail Page
            
        </asp:PlaceHolder>
        <input id="btn_follow" type="button" value="Follow Project" onserverclick="follow" runat="server" />
    </div>
</asp:Content>
