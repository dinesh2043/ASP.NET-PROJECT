<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="addProject.ascx.cs" Inherits="Ubuoy.UserAuthentication.UsersControl.addProject" %>
<%--<meta charset="utf-8">
<script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.min.js"></script>

<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.16/jquery-ui.min.js"></script>

<link type="text/css" rel="Stylesheet" href="http://ajax.microsoft.com/ajax/jquery.ui/1.8.16/themes/redmond/jquery-ui.css" />

<script type="text/javascript">

    $().ready(

    function () {

        $('#<%=tbx_StartedOn.ClientID%>').datepicker();
            $('#<%=tbx_EndedOn.ClientID%>').datepicker();

        });


</script>--%>

To add a project:<br />


<asp:Label ID="lbl_Description" runat="server" Text="Description"></asp:Label>
<textarea id="ta_Description" rows="2" cols="20" runat="server"></textarea><br />


<asp:Label ID="lbl_StartedOn" runat="server" Text="Starts On:"></asp:Label>
<asp:TextBox ID="tbx_StartedOn" runat="server"></asp:TextBox><asp:Label ID="Label8" runat="server" Text="30/01/2013"></asp:Label><br />


<asp:Label ID="lbl_EndedOn" runat="server" Text="Ends On:"></asp:Label>
<asp:TextBox ID="tbx_EndedOn" runat="server"></asp:TextBox><asp:Label ID="Label3" runat="server" Text="30/01/2013"></asp:Label><br />

<asp:Label ID="lbl_Budget" runat="server" Text="Budget:"></asp:Label>
<asp:TextBox ID="tbx_Budget" runat="server"></asp:TextBox><asp:Label ID="Label4" runat="server" Text="€"></asp:Label><br />


<asp:Label ID="lbl_Recived" runat="server" Text="Recived Amount"></asp:Label>
<asp:TextBox ID="tbx_Recived" runat="server"></asp:TextBox><asp:Label ID="Label5" runat="server" Text="€"></asp:Label><br />

<asp:Label ID="Label2" runat="server" Text="Select Organization:"></asp:Label>
<asp:DropDownList ID="ddl_Organization" runat="server" DataSourceID="OrganizationDataSource" DataTextField="name" DataValueField="orginizationId"></asp:DropDownList>

<asp:EntityDataSource ID="OrganizationDataSource" runat="server" ConnectionString="name=Ubuoy_DB_ModelEntities" DefaultContainerName="Ubuoy_DB_ModelEntities" EnableFlattening="False" EntitySetName="Orginizations" Select="it.[name], it.[orginizationId]">
</asp:EntityDataSource>
<br />

<input id="btn_SaveProject" type="button" value="Save a Project" onserverclick="SaveProject" runat="server" />
<%--<asp:Button ID="btn_SaveProject" runat="server" OnClick="SaveProject" Text="Save a Project" /><br />--%>





<asp:Label ID="Label1" runat="server" Text=""></asp:Label>




