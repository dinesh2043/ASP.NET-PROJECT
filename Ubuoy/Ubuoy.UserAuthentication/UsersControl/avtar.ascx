<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="avtar.ascx.cs" Inherits="Ubuoy.UserAuthentication.UsersControl.avtar" %>
<div class="user-login" style="width: 250px; height: 62px; position: relative;">
    <a onclick="window.location='Profile.aspx';" class="">
        <div class="name" style="position: absolute; top: 0px; right: 70px;">
            <asp:Label CssClass="first-name-charms" ID="lbl_FirstName" runat="server" Text="Label"></asp:Label>
            <asp:Label CssClass="last-name-charms" ID="lbl_LastName" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="avatar" style="position: absolute; top: 0px; right: 0px;">
            <asp:Image ID="imgProfile" BackColor="White" runat="server" />
        </div>
    </a>

</div>
