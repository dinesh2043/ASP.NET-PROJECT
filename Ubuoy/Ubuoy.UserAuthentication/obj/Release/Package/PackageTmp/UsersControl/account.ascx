<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="account.ascx.cs" Inherits="Ubuoy.UserAuthentication.UsersControl.userInfo" %>


<div class="charms" id="account-charms" style="border-left: 2px solid lightGrey; z-index: 1000; background-color: #fff;">
    <div class="user-login-charms" style="width: 250px; height: 62px; position: relative;">
        <a onclick="window.location='Profile.aspx';" class="">
            <div class="name-charms" style="position: absolute; top: 0px; right: 80px;">

                <asp:Label CssClass="first-name-charms" ID="lbl_Acc_FirstName_charms" runat="server" Text="Label"></asp:Label>
                <asp:Label CssClass="last-name-charms" ID="lbl_Acc_LastName_charms" runat="server" Text="Label"></asp:Label>
            </div>
            
            <div class="avatar-charms" style="position: absolute; top: 0px; right: 0px;">
                <asp:Image ID="img_Acc_charms" runat="server" BackColor="White"></asp:Image>
            </div>
        </a>
    </div>
    <!--close the session and logoutfghfghghfgh-->
    <%--<asp:LinkButton ID="btn_Logout" runat="server"><i class="icon-exit" style="line-height: 40px; font-size: 40px;"></i>LOGOUT</asp:LinkButton>--%>
    <br />
    <br />

    <a class="closeAccCharm" style="position: absolute; top: 10px; left: 10px;" href="#"><i class="icon-arrow-left-3" style="line-height: 40px; font-size: 40px;"></i></a>


    <!-- to display the user Information -->
    <br />
    <br />
    <br />
    <br />
    <br />
    <div style="margin-left:20px;">
    <address>
        <asp:Panel ID="pnl_userBasicInfo" runat="server">
            <asp:Literal ID="email" runat="server">Email:</asp:Literal>
            <asp:Label ID="lbl_email" runat="server" Text="Text"></asp:Label><br />

            <asp:Literal ID="gender" runat="server">Gender:</asp:Literal>
            <asp:Label ID="lbl_gender" runat="server" Text="Text"></asp:Label><br />

            <asp:Literal ID="dob" runat="server">Date Of Birth:</asp:Literal>
            <asp:Label ID="lbl_dob" runat="server" Text="Text"></asp:Label><br />

        </asp:Panel>

    </address>
    <asp:Button ID="btn_addAddress" runat="server" Text="Add Address" Visible="false" />
    <address>
        <asp:Panel ID="pnl_userContactInfo" Visible="false" runat="server">
            <asp:Literal ID="phone" runat="server">Phone Number:</asp:Literal>
            <asp:Label ID="lbl_phone" runat="server" Text="Text"></asp:Label><br />

            <asp:Literal ID="country" runat="server">Country:</asp:Literal>
            <asp:Label ID="lbl_country" runat="server" Text="Text"></asp:Label><br />

            <asp:Literal ID="city" runat="server">City:</asp:Literal>
            <asp:Label ID="lbl_city" runat="server" Text="Text"></asp:Label><br />

            <asp:Literal ID="postalCode" runat="server">PostalCode:</asp:Literal>
            <asp:Label ID="lbl_postalCode" runat="server" Text="Text"></asp:Label><br />

            <asp:Literal ID="streetAddress" runat="server">StreetAddress:</asp:Literal>
            <asp:Label ID="lbl_streetAdress" runat="server" Text="Text"></asp:Label><br />
        </asp:Panel>
    </address>
        </div>
    <div style="position: absolute; bottom: 10px; left: 20px;">
        <button id="btn_Setting_Logout" onserverclick="editUserInfoForm" runat="server">
            Edit User Info
        </button>
    </div>
</div>



