<%@ Page Title="" Language="C#" MasterPageFile="~/uBuoyMaster.Master" AutoEventWireup="true" CodeBehind="uBuoyTaskDetails.aspx.cs" Inherits="Ubuoy.UserAuthentication.uBuoyTaskDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageRegionContent" runat="server">
    <div class="page-region-content">
        <div id="taskWraper" style="background-color: #fff; border:1px solid lightGrey; padding:20px; width:700px;">
            <asp:PlaceHolder ID="taskDitails" runat="server">

                <asp:Label ID="Label3" runat="server" Text="Task Description:"></asp:Label><asp:Label ID="lbl_description" runat="server" Text="Label"></asp:Label><br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Task Owner:"></asp:Label><asp:Label ID="lbl_owner" runat="server" Text="Label"></asp:Label><br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Deadline:"></asp:Label><asp:Label ID="lbl_deadline" runat="server" Text="Label"></asp:Label><br />
                <br />
                <asp:Label ID="Label6" runat="server" Text="Price of Task:"></asp:Label><asp:Label ID="lbl_price" runat="server" Text="Label"></asp:Label><br />
                <br />
                <input id="btn_ApplyTask" type="button" value="Apply For Task" onserverclick="ApplyTask" runat="server" />

                <asp:Panel ID="pnl_Apply" Visible="false" runat="server">
                    <asp:Label ID="Label1" runat="server" Text="Select Project For Donation:"></asp:Label><br />
                    <asp:DropDownList ID="ddl_Project" runat="server" DataSourceID="ProjectDataSource" DataTextField="description" DataValueField="projectId"></asp:DropDownList><br />
                    <asp:Label ID="lbl_Organization" runat="server" Text=""></asp:Label><br />
                    <asp:EntityDataSource ID="ProjectDataSource" runat="server" ConnectionString="name=Ubuoy_DB_ModelEntities" DefaultContainerName="Ubuoy_DB_ModelEntities" EnableFlattening="False" EntitySetName="Projects" Select="it.[description], it.[projectId]">
                    </asp:EntityDataSource>
                    <input id="btn_MakeDonation" type="button" value="button" onserverclick="MakeDonation" runat="server" /><br />
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label><br />
                </asp:Panel>
            </asp:PlaceHolder>
            <br />
        </div>
    </div>
</asp:Content>
