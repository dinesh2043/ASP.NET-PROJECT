<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="addOrganization.ascx.cs" Inherits="Ubuoy.UserAuthentication.UsersControl.addOrganization" %>
<%@ Register Src="~/UsersControl/Address.ascx" TagPrefix="uc1" TagName="Address" %>


<asp:PlaceHolder ID="PlaceHolder1" runat="server">
    To add a organization:
<asp:Panel ID="Panel1" runat="server">
    <asp:Label ID="lbl_OrganizationName" runat="server" Text="Organization Name"></asp:Label><br />
    <asp:TextBox ID="tbx_OrgName" runat="server"></asp:TextBox><br />
    <asp:Label ID="lbl_OrgDescription" runat="server" Text="Organization Description"></asp:Label><br />
    <textarea ID="tar_OrgDescription" runat="server" cols="20" rows="2"></textarea><br />
    <asp:Label ID="lbl_WebAddress" runat="server" Text="Organization WebPage"></asp:Label><br />
    <asp:TextBox ID="tbx_WebAddress" runat="server"></asp:TextBox><br />
    <asp:Label ID="lbl_OrgFgColor" runat="server" Text="Forground Color"></asp:Label><br />
    <asp:DropDownList ID="ddl_OrgBgColor" runat="server" DataSourceID="OrganizationDataSourceBg" DataTextField="OrgBgColor" DataValueField="OrgBgColor"></asp:DropDownList><br />
    <asp:Label ID="lbl_OrgBgColor" runat="server" Text="BackGround Color"></asp:Label><br />
    <asp:DropDownList ID="ddl_OrgFgColor" runat="server" DataSourceID="OrganizationDataSourceFg" DataTextField="OrgFgColor" DataValueField="OrgFgColor"></asp:DropDownList><br />
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
    <input id="btn_SaveOrg" type="button" value="Save Organization" onserverclick="SaveOrg" runat="server" />
    <%--<asp:Button ID="btn_SaveOrg" runat="server" Text="Save Organization" OnClick="btn_SaveOrg_Click" />--%>
</asp:Panel>
</asp:PlaceHolder>
    <%--<asp:Button ID="btn_organizationImage" runat="server" Text="Organization Image" /><br />
    <asp:Button ID="btn_orgLogo" runat="server" Text="Organization Logo" /><br />--%>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    

<asp:EntityDataSource ID="OrganizationDataSourceBg" runat="server" ConnectionString="name=Ubuoy_DB_ModelEntities" DefaultContainerName="Ubuoy_DB_ModelEntities" EnableFlattening="False" EntitySetName="Orginizations" Select="it.[orgBgColor]">
</asp:EntityDataSource>
<asp:EntityDataSource ID="OrganizationDataSourceFg" runat="server" ConnectionString="name=Ubuoy_DB_ModelEntities" DefaultContainerName="Ubuoy_DB_ModelEntities" EnableFlattening="False" EntitySetName="Orginizations" Select="it.[orgFgColor]">
</asp:EntityDataSource>
