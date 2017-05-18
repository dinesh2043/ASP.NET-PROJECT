<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="addTask.ascx.cs" Inherits="Ubuoy.UserAuthentication.UsersControl.addTask" %>

Add a task:<br />
<%--<asp:Label ID="Label1" runat="server" Text="Start Date: "></asp:Label>
<asp:TextBox ID="tbx_StartDate" runat="server"></asp:TextBox><asp:Label ID="Label8" runat="server" Text="30/01/2013"></asp:Label><br />--%>

<asp:Label ID="Label3" runat="server" Text="Deadline"></asp:Label>
<asp:TextBox ID="tbx_deadline" runat="server"></asp:TextBox><asp:Label ID="Label10" runat="server" Text="30/01/2013"></asp:Label><br />
<asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
<textarea id="ta_description" cols="20" rows="2" runat="server"></textarea><br />
    
<asp:Label ID="Label5" runat="server" Text="Category:"></asp:Label>
<asp:DropDownList ID="ddl_category" runat="server" DataSourceID="CategoryDataSource" DataTextField="Name" DataValueField="categoryId"></asp:DropDownList>
<asp:EntityDataSource ID="CategoryDataSource" runat="server" ConnectionString="name=Ubuoy_DB_ModelEntities" DefaultContainerName="Ubuoy_DB_ModelEntities" EnableFlattening="False" EntitySetName="Categories" Select="it.[Name], it.[categoryId]">
</asp:EntityDataSource>
<br />

<asp:Label ID="Label6" runat="server" Text="Skill:"></asp:Label>
<asp:DropDownList ID="ddl_skill" runat="server" DataSourceID="SkillDataSource" DataTextField="skillName" DataValueField="skillId"></asp:DropDownList>
<asp:EntityDataSource ID="SkillDataSource" runat="server" ConnectionString="name=Ubuoy_DB_ModelEntities" DefaultContainerName="Ubuoy_DB_ModelEntities" EnableFlattening="False" EntitySetName="Skills" Select="it.[skillId], it.[skillName]">
</asp:EntityDataSource>
<br />

<asp:Label ID="Label7" runat="server" Text="Task Price:"></asp:Label>
<asp:TextBox ID="tbx_price" runat="server"></asp:TextBox><asp:Label ID="Label1" runat="server" Text="€"></asp:Label><br />

<input id="btn_addTask" type="button" value="Add a task" onserverclick="SaveTask" runat="server" /><br />
<asp:Label ID="Label2" runat="server" Text=""></asp:Label>