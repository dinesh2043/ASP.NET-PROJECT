<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="Ubuoy.UserAuthentication.Demo" %>

<%@ Register src="UsersControl/addProject.ascx" tagname="addProject" tagprefix="uc1" %>
<%@ Register Src="~/UsersControl/addProject.ascx" TagPrefix="uc2" TagName="addProject" %>
<%@ Register Src="~/UsersControl/addOrganization.ascx" TagPrefix="uc1" TagName="addOrganization" %>

<%@ Register Src="~/UsersControl/followOrganizationOrProjectOrUser.ascx" TagPrefix="uc1" TagName="followOrganizationOrProjectOrUser" %>
<%@ Register Src="~/UsersControl/Address.ascx" TagPrefix="uc1" TagName="Address" %>
<%@ Register Src="~/UsersControl/applyForTask.ascx" TagPrefix="uc1" TagName="applyForTask" %>
<%@ Register Src="~/UsersControl/addSkill.ascx" TagPrefix="uc1" TagName="addSkill" %>
<%@ Register Src="~/UsersControl/addTask.ascx" TagPrefix="uc1" TagName="addTask" %>










<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="target-densitydpi=device-dpi, width=device-width, initial-scale=1.0, maximum-scale=1">
    <meta name="description" content="Modern UI CSS">
    <meta name="author" content="Sergey Pimenov">
    <meta name="keywords" content="windows 8, modern style, modern ui, style, modern, css, framework">

    <link href="UI/css/modern.css" rel="stylesheet">
   <!-- <link href="css/theme-dark.css" rel="stylesheet">-->
    <link href="UI/css/modern-responsive.css" rel="stylesheet">
 <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
  <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.5/jquery.min.js"></script>
  <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
    <script src="UI/public/js/assets/jquery-1.8.2.min.js"></script>
    <script src="UI/public/js/assets/google-analytics.js"></script>
    <script src="UI/public/js/assets/jquery.mousewheel.min.js"></script>
    <script src="UI/public/js/assets/github.info.js"></script>
    <script src="UI/public/js/modern/tile-slider.js"></script>
    <script src="UI/public/js/modern/start-menu.js"></script>
    <script src="UI/public/js/modern/tile-drag.js"></script>

    <title><asp:Literal ID="profileTitle" runat="server"></asp:Literal></title>
	<script type="text/javascript">

	    $(document).ready(function () {

	        $(".charms").hide();
	        $(".show_hide").show();

	        $('.show_hide').click(function () {
	            $(".charms").slideToggle();
	        });

	    });

</script>
    <style>
        body {
            background-image: url("UI/images/bg.png");
			background-repeat: repeat;
        }
 
.show_hide {
    display:none;
}
    </style>
    
</head>

<body class="metrouicss">


    
	
        
	
<div class="page secondary fixed-header">
    <div class="page-header ">
        <div class="page-header-content">
         

            <h1 class="fg-color-black"><img src="UI/images/ubuoy.png">  </h1>
        </div>
    </div>
    
    <div class="page-region">
        <div class="page-region-content">

                  <form id="form1" runat="server">

        <uc2:addProject runat="server" ID="addProject" /><br />
        <br />
        <br />
        <uc1:addOrganization runat="server" ID="addOrganization" />
        <br />
        <br />
        <uc1:addSkill runat="server" ID="addSkill" />
        <br />
        <br />
        <uc1:addTask runat="server" ID="addTask" />
        <%--<uc1:followOrganizationOrProjectOrUser runat="server" id="followOrganizationOrProjectOrUser" /><br />
        <uc1:applyForTask runat="server" id="applyForTask" />

        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="OnSelected" AutoPostBack="true">
            <asp:ListItem Enabled="true" Text="Choose Category" Value="value" ></asp:ListItem>
        </asp:DropDownList>--%>

    </div>
</div>
        <a href='http://hit.ua/?x=19154' target='_blank'>
            <script language="javascript" type="text/javascript"><!--
    Cd = document; Cr = "&" + Math.random(); Cp = "&s=1";
    Cd.cookie = "b=b"; if (Cd.cookie) Cp += "&c=1";
    Cp += "&t=" + (new Date()).getTimezoneOffset();
    if (self != top) Cp += "&f=1";
    //--></script>
            <script language="javascript1.1" type="text/javascript"><!--
    if (navigator.javaEnabled()) Cp += "&j=1";
    //--></script>
            <script language="javascript1.2" type="text/javascript"><!--
    if (typeof (screen) != 'undefined') Cp += "&w=" + screen.width + "&h=" +
            screen.height + "&d=" + (screen.colorDepth ? screen.colorDepth : screen.pixelDepth);
    //--></script>
            <script language="javascript" type="text/javascript"><!--
    Cd.write("<img src='http://c.hit.ua/hit?i=19154&g=0&x=2" + Cp + Cr +
            "&r=" + escape(Cd.referrer) + "&u=" + escape(window.location.href) +
            "' border='0' wi" + "dth='1' he" + "ight='1'/>");
    //--></script>
            <noscript>
                <img src='http://c.hit.ua/hit?i=19154&amp;g=0&amp;x=2' border='0'/>
            </noscript></a>
<!-- / hit.ua -->
    </div>
    </form>

</body>
</html>
    

