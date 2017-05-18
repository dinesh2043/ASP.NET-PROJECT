<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="Ubuoy.UserAuthentication.UserRegistration" %>

<!DOCTYPE html>
<!-- paulirish.com/2008/conditional-stylesheets-vs-css-hacks-answer-neither/ -->
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <!-- Always force latest IE rendering engine (even in intranet) & Chrome Frame -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- Mobile viewport optimized: h5bp.com/viewport -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
    <!--For implementing date picker-->
    <link type="text/css" href="css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="css/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="css/jquery-ui-1.8.19.custom.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#tbx_DOB").datepicker({dateFormat:'dd/mm/yy'});
        });
    </script>
    <style type="text/css">
    .ui-datepicker { font-size:8pt !important}
    </style>


   

    <title>Registration</title>



    <!-- remove or comment this line if you want to use the local fonts -->
   <link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" type="text/css" href="content/css/bootstrap.css"/>
    <link rel="stylesheet" type="text/css" href="content/css/bootstrap-responsive.css"/>
    <link rel="stylesheet" type="text/css" href="content/css/bootmetro.css"/>
    <link rel="stylesheet" type="text/css" href="content/css/bootmetro-tiles.css"/>
    <link rel="stylesheet" type="text/css" href="content/css/bootmetro-charms.css"/>
    <link rel="stylesheet" type="text/css" href="content/css/metro-ui-light.css"/>
    <link rel="stylesheet" type="text/css" href="content/css/icomoon.css"/>
    <link rel="stylesheet" type="text/css" href="content/css/datepicker.css"/>
    <link rel="stylesheet" type="text/css" href="content/css/daterangepicker.css"/>
    <link rel="stylesheet" type="text/css" href="content/css/metro-ui-ubuoy.css"/>


    <!-- All JavaScript at the bottom, except for Modernizr and Respond.
      Modernizr enables HTML5 elements & feature detects; Respond is a polyfill for min/max-width CSS3 Media Queries
      For optimal performance, use a custom Modernizr build: www.modernizr.com/download/ -->
    <script src="scripts/modernizr-2.6.1.min.js"></script>

    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>

</head>
<body>
    <div class="container" >

        <div class="form-wrap" style="margin-top: 50px; width: 410px; margin-left: auto; margin-right: auto; background: white; position: relative;">
            <img src="images/ubuoy.png" style="position: absolute; top: 20px; right: 40px;" />
            <br />
            <h2 style="border-bottom: 2px solid lightGrey; padding-bottom: 20px;"><span class="login-header">registration</span></h2>
            <br />

                <asp:Panel ID="pnlError" runat="server" Visible="false">
                    <div class="alert">
                        <button class="close" data-dismiss="alert" type="button"></button>
                        <strong><asp:Label ID="lblValidation" runat="server"></asp:Label></strong>
                        All fields are required.
                    </div>

                </asp:Panel>
            <asp:Panel ID="pnlSuccess" runat="server" Visible="false">
                    <div class="alert alert-success">
                        <button class="close" data-dismiss="alert" type="button"></button>
                        <strong>Well done!</strong>
                        You successfully regestered to ubuoy.
                    </div>

                </asp:Panel>


    <form id="form1" runat="server">
        
    <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbPassword"  runat="server" TextMode="Password"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbPassword2" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="FirstName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label6" runat="server" Text="LastName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Gender"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dDLGender"  OnSelectedIndexChanged="SelectGender" runat="server">
                        
                    </asp:DropDownList>
                        
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label7" runat="server" Text="Date of Birth"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbx_DOB" runat="server"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-large btn-primary" OnClick="RegisterUser" Text="Register" />
                   
                    <span style="color: inherit; margin-left: 5px;">| </span>
                    <a href="Login.aspx" style="color: inherit;">Login</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</div>

    </div>
    <!-- Grab Google CDN's jQuery. fall back to local if necessary -->
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script>window.jQuery || document.write("<script src='scripts/jquery-1.8.2.min.js'>\x3C/script>")</script>

    <script type="text/javascript" src="scripts/google-code-prettify/prettify.js"></script>
    <script type="text/javascript" src="scripts/jquery.mousewheel.js"></script>
    <script type="text/javascript" src="scripts/jquery.scrollTo.js"></script>
    <script type="text/javascript" src="scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="scripts/bootmetro.js"></script>
    <script type="text/javascript" src="scripts/bootmetro-charms.js"></script>
    <script type="text/javascript" src="scripts/demo.js"></script>
    <script type="text/javascript" src="scripts/holder.js"></script>
    <script type="text/javascript" src="scripts/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="scripts/daterangepicker.js"></script>

    <script type="text/javascript">
        $(".metro").metro();
    </script>
</body>
</html>

