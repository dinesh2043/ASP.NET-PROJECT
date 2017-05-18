<%@ Page Title="" Language="C#" MasterPageFile="~/FormsMaster.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Ubuoy.UserAuthentication.Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FormContent" runat="server">
    <div class="page-region-content">
        <span>The phrase you entered is </span>
    <asp:Label ID="lbl_phrase" runat="server" Text="Label"></asp:Label>
        <br /><br />
        <label class="input-control checkbox">
            <input type="checkbox">
            <span class="helper">Organization</span>
        </label>

        <label class="input-control checkbox">
            <input type="checkbox">
            <span class="helper">Project</span>
        </label>

        <label class="input-control checkbox">
            <input type="checkbox">
            <span class="helper">Skill</span>
        </label>

        <label class="input-control checkbox">
            <input type="checkbox">
            <span class="helper">Task</span>
        </label>
    </div>
</asp:Content>
