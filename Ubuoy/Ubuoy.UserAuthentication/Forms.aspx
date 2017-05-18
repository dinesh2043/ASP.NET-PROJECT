<%@ Page Title="" Language="C#" MasterPageFile="~/FormsMaster.Master" AutoEventWireup="true" CodeBehind="Forms.aspx.cs" Inherits="Ubuoy.UserAuthentication.Forms" %>
<%@ MasterType virtualpath="~/FormsMaster.Master" %>

<%@ Register Src="~/UsersControl/addProject.ascx" TagPrefix="uc1" TagName="addProject" %>
<%@ Register Src="~/UsersControl/addSkill.ascx" TagPrefix="uc1" TagName="addSkill" %>
<%@ Register Src="~/UsersControl/editUserInfo.ascx" TagPrefix="uc1" TagName="editUserInfo" %>
<%@ Register Src="~/UsersControl/addTask.ascx" TagPrefix="uc1" TagName="addTask" %>



<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <div class="page-region-content">
        <uc1:addproject runat="server" visible="false" id="addProject" />
        <uc1:addskill runat="server" visible="false" id="addSkill" />
        <uc1:edituserinfo runat="server" visible="false" id="editUserInfo" />
        <uc1:addTask runat="server" visible="false" ID="addTask" />
    </div>
</asp:Content>
