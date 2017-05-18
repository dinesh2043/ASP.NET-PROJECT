<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="applyForTask.ascx.cs" Inherits="Ubuoy.UserAuthentication.UsersControl.applyForTask" %>
<asp:Label ID="lbl_SelectSkill" runat="server" Text="Skills"></asp:Label><br />
<asp:DropDownList ID="dd_list" AutoPostBack="true" OnSelectedIndexChanged="dd_list_SelectedIndexChanged" runat="server" DataSourceID="skillDatasource" DataTextField="SkillName" DataValueField="SkillId"></asp:DropDownList>
<asp:EntityDataSource ID="skillDatasource" runat="server" ConnectionString="name=Ubuoy_DB_ModelEntities" DefaultContainerName="Ubuoy_DB_ModelEntities" EnableFlattening="False" EntitySetName="Skills" EntityTypeFilter="Skill" Select="it.[skillId], it.[skillName]">
</asp:EntityDataSource>
<br />
<asp:Label ID="Label2" runat="server" Text="Task according to skills"></asp:Label><br />
<asp:GridView ID="gv_Task" runat="server"></asp:GridView>

<asp:DropDownList ID="ddl_task" runat="server">
</asp:DropDownList>
<br />
<asp:Button ID="Button1" runat="server" Text="Application" />
