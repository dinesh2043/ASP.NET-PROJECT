<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ubuoy.UserAuthentication.Login" %>

<!DOCTYPE html>
<!-- paulirish.com/2008/conditional-stylesheets-vs-css-hacks-answer-neither/ -->
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <!-- Always force latest IE rendering engine (even in intranet) & Chrome Frame -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- Mobile viewport optimized: h5bp.com/viewport -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

    <title>Login</title>



    <!-- remove or comment this line if you want to use the local fonts 
   <link href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700' rel='stylesheet' type='text/css'>-->

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

</head>
<body>
    <div class="container" >

        <div class="form-wrap" style="width: 410px; margin-left: auto; margin-right: auto; background: white; position: relative;">
            <img src="images/ubuoy.png" style="position: absolute; top: 20px; right: 40px;" />
            <br />
            <h2 style="border-bottom: 2px solid lightGrey; padding-bottom: 20px;"><span class="login-header">login</span></h2>
            <br />
            <asp:Label ID="lblError" runat="server">
                <asp:Panel ID="pnlError" runat="server" Visible="false">
                    <div class="alert">
                        <button class="close" data-dismiss="alert" type="button"></button>
                        <strong><asp:Label ID="lblLoginFail" runat="server" ></asp:Label></strong>
                        Check your email and password.
                    </div>
                    
                </asp:Panel>

            </asp:Label>

            <form id="form1" runat="server" class="form-horizontal">

                <div class="input-div">
                    <div class="input-prepend">
                        <span class="add-on">@</span>
                        <asp:TextBox ID="tbEmail" runat="server" TextMode="SingleLine" placeholder="E-mail" CssClass="span2"></asp:TextBox>
                    </div>

                </div>



                <div class="input-div">
                    <div class="input-prepend" style="float: left;">
                        <span class="add-on" style="float: left;">*</span>
                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="span2" Style="float: left;"></asp:TextBox>
                    </div>
                    <span style="float: left; margin-left: 8px;">
                        <span style="color: inherit;">| </span>
                        <a href="#" style="color: inherit;">Forgot your passoword?</a></span>
                </div>


                <br />
                <div class="input-div" style="clear: both;">
                    <label class="checkbox">
                        <div class="input-append">
                            <asp:CheckBox ID="CheckBox1" runat="server" /><span class="metro-checkbox"></span>
                            <span class="add-on">Remember me</span>
                        </div>
                    </label>
                </div>

                <div class="input-div">
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-large btn-primary" OnClick="btnLogin_Click" Text="Login" />

                    <span style="color: inherit; margin-left: 5px;">| </span>
                    <a href="UserRegistration.aspx" style="color: inherit;">Register</a>
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