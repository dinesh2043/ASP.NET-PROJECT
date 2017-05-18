<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="followOrganizationOrProjectOrUser.ascx.cs" Inherits="Ubuoy.UserAuthentication.UsersControl.followOrganizationOrProjectOrUser" %>
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
    To follow organization uaser and projects:
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="lbl_OrgName" runat="server" Text="Organization Name"></asp:Label><br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="OrganizationDataSource" DataTextField="name" DataValueField="name"></asp:DropDownList>
        <asp:Label ID="lbl_ProjInfo" runat="server" Text="Project Info"></asp:Label><br />
        <asp:GridView ID="gvProject" runat="server" DataSourceID="ProjectDataSource">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
    </Columns>
</asp:GridView><br />
        <asp:Label ID="lbl_UserInfo" runat="server" Text="User Info"></asp:Label><br />
        <asp:GridView ID="gvUser" runat="server" DataSourceID="UserDataSource">
</asp:GridView><br />
    </asp:Panel>
</asp:PlaceHolder>

<asp:EntityDataSource ID="OrganizationDataSource" runat="server" ConnectionString="name=Ubuoy_DB_ModelEntities" DefaultContainerName="Ubuoy_DB_ModelEntities" EnableFlattening="False" EntitySetName="Orginizations" Select="it.[name]">
</asp:EntityDataSource>

<asp:EntityDataSource ID="ProjectDataSource" runat="server" ConnectionString="name=Ubuoy_DB_ModelEntities" DefaultContainerName="Ubuoy_DB_ModelEntities" EnableFlattening="False" EntitySetName="Projects" Select="it.[description], it.[startedOn], it.[endOn]">
</asp:EntityDataSource>

<asp:EntityDataSource ID="UserDataSource" runat="server" ConnectionString="name=Ubuoy_DB_ModelEntities" DefaultContainerName="Ubuoy_DB_ModelEntities" EnableFlattening="False" EntitySetName="Users" Select="it.[firstName], it.[lastName]">
</asp:EntityDataSource>
