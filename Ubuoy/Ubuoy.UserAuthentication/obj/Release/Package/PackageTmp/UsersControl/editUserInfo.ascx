<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editUserInfo.ascx.cs" Inherits="Ubuoy.UserAuthentication.UsersControl.EditUserInfo" %>

<asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
<asp:TextBox ID="tbx_email" runat="server"></asp:TextBox><br />

<asp:Label ID="Label2" runat="server" Text="DOB:"></asp:Label>
<asp:TextBox ID="tbx_DOB" runat="server"></asp:TextBox><br />

<asp:Label ID="Label3" runat="server" Text="Phone Number:"></asp:Label>
<asp:TextBox ID="tbx_Phone" runat="server"></asp:TextBox><br />

<asp:Label ID="Label4" runat="server" Text="Country:"></asp:Label>
<asp:TextBox ID="tbx_country" runat="server"></asp:TextBox><br />

<asp:Label ID="Label5" runat="server" Text="City:"></asp:Label>
<asp:TextBox ID="tbx_City" runat="server"></asp:TextBox><br />

<asp:Label ID="Label6" runat="server" Text="PostalCode:"></asp:Label>
<asp:TextBox ID="tbx_postalCode" runat="server"></asp:TextBox><br />

<asp:Label ID="Label7" runat="server" Text="Street Address:"></asp:Label>
<asp:TextBox ID="tbx_streetAddress" runat="server"></asp:TextBox><br />

<asp:Label ID="Label8" runat="server" Text="First Name:"></asp:Label>
<asp:TextBox ID="tbx_firstName" runat="server"></asp:TextBox><br />

<asp:Label ID="Label9" runat="server" Text="Last Name:"></asp:Label>
<asp:TextBox ID="tbx_lastName" runat="server"></asp:TextBox><br />



<input id="btn_Save" type="button" value="Save" runat="server" onserverclick="Save" /><br />
