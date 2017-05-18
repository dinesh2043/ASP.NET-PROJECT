<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="addSkill.ascx.cs" Inherits="Ubuoy.UserAuthentication.UsersControl.addSkill" %>
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="lbl_SkillName" runat="server" Text="Skill"></asp:Label><br />
        <asp:TextBox ID="tbx_SkillName" runat="server"></asp:TextBox><br /><br />

        <asp:Label ID="lbl_SkillDescription" runat="server" Text="Description"></asp:Label><br />
        <asp:TextBox id="tb_SkillDesc" runat="server" TextMode="MultiLine"></asp:TextBox><br /><br />

        <asp:Label ID="lbl_Category" runat="server" Text="Category"></asp:Label><br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="CategoryDataSource" DataTextField="Name" DataValueField="categoryId"></asp:DropDownList><br />
    </asp:Panel>
</asp:PlaceHolder><br />

<asp:EntityDataSource ID="CategoryDataSource" runat="server" ConnectionString="name=Ubuoy_DB_ModelEntities" DefaultContainerName="Ubuoy_DB_ModelEntities" EnableFlattening="False" EntitySetName="Categories" Select="it.[Name], it.[categoryId]">
</asp:EntityDataSource>
<p>
    <input id="btnAddSkill" type="button" value="Add skill" onserverclick="btnAddSkill_Click" runat="server"/>
    <%--<asp:Button ID="btnAddSkill" runat="server" Text="Add skill" OnClick="btnAddSkill_Click" />--%>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</p>

