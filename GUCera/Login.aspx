
 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUCera.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link href="~/Css\LoginCss.css?t=<%= DateTime.Now.Ticks %>" rel="stylesheet" type="text/css" media="screen" runat="server"/>
</head>
<body>
    <form id="form1" runat="server">
         <div class ="Logo">
             <asp:Label ID="Label1" runat="server" Text="Welcome To GUCera" Height="100px"  CssClass="label"></asp:Label>
         </div>
        <div class ="login-box">
            Please Log In
            <br /> 
            <p>UserId:</p>
            <br />
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br />
            <p>Password:</p><br/>
            <asp:TextBox ID="password" type="password" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="signin" runat="server" Text="Log In" OnClick="login_Click" />
            <br />
            <asp:Label ID="error" runat="server"></asp:Label>
            <br />
            <asp:Button ID="register" runat="server" Text="Register" OnClick="register_Click" />
        </div>
    </form>
</body>
</html>
