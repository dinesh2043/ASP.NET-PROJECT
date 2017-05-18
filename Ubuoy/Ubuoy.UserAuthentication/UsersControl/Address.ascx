<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Address.ascx.cs" Inherits="Ubuoy.UserAuthentication.UsersControl.Address" %>
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">
    <asp:Label ID="lbl_country" runat="server" Text="Country"></asp:Label><br />
    <asp:TextBox ID="tbx_country" runat="server"></asp:TextBox><br />
    <asp:Label ID="lbl_city" runat="server" Text="City"></asp:Label><br />
    <asp:TextBox ID="tbx_city" runat="server"></asp:TextBox><br />
    <asp:Label ID="lbl_postalCode" runat="server" Text="Postal Code"></asp:Label><br />
    <asp:TextBox ID="tbx_postalCode" runat="server"></asp:TextBox><br />
    <asp:Label ID="lbl_streetAdress" runat="server" Text="Street Adress"></asp:Label><br />
    <asp:TextBox ID="tbx_streetAdress" runat="server"></asp:TextBox><br />
    <asp:Label ID="lbl_phone" runat="server" Text="Phone"></asp:Label><br />
    <asp:TextBox ID="tbx_phone" runat="server"></asp:TextBox><br />
    <asp:Label ID="lbl_email" runat="server" Text="Email"></asp:Label><br />
    <asp:TextBox ID="tbx_email" runat="server"></asp:TextBox><br />

</asp:Panel>
</asp:PlaceHolder>
<asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />