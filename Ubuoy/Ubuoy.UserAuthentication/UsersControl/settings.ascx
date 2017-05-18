<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="settings.ascx.cs" Inherits="Ubuoy.UserAuthentication.UsersControl.settings" %>
<div class="charms" id="setting-charms" style="border-left: 2px solid lightGrey; z-index: 1000; background-color: #fff;">
    <div class="user-login-charms" style="width: 250px; height: 62px; position: relative;">
        <a onclick="window.location='Profile.aspx';" class="">
            <div class="name-charms" style="position: absolute; top: 0px; right: 80px;">

                <asp:Label CssClass="first-name-charms" ID="lbl_Set_FirstName_charms" runat="server" Text=""></asp:Label>
                <asp:Label CssClass="last-name-charms" ID="lbl_Set_LastName_charms" runat="server" Text=""></asp:Label>
            </div>

            <div class="avatar-charms" style="position: absolute; top: 0px; right: 0px;">
                <asp:Image ID="img_Set_charms" runat="server" BackColor="White"></asp:Image>
            </div>
        </a>
    </div>
    <!--close the session and logout-->
    <%--<asp:LinkButton ID="btn_Logout" runat="server"><i class="icon-exit" style="line-height: 40px; font-size: 40px;"></i>LOGOUT</asp:LinkButton>--%>
    <br />
    <br />

    <a class="closeCharm" style="position: absolute; top: 10px; left: 10px;" href="#"><i class="icon-arrow-left-3" style="line-height: 40px; font-size: 40px;"></i></a>
    <div style="position: absolute; bottom: 10px; left: 20px;">
        <button id="btn_Setting_Logout" onserverclick="logOut" runat="server">
            LogOut
        </button>
    </div>

    <!-- to display the user Information -->

</div>
