<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GUCera.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="Css\RegisterCss.css?t=<%= DateTime.Now.Ticks %>" rel="stylesheet" type="text/css" media="screen"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <h1>Register</h1>
        <p>Choose which type of user you are</p>
            <asp:Panel ID="registerPanel" runat="server">
        <asp:DropDownList ID="IorS" runat="server">
             <asp:ListItem Value="">Please Select</asp:ListItem>  
            <asp:ListItem Value="0">Instructor</asp:ListItem>  
            <asp:ListItem Value="1">Student</asp:ListItem>  
        </asp:DropDownList>
        <p>Enter first name: </p>
        <asp:TextBox ID="firstname" runat="server"></asp:TextBox>
        <p>Enter Last name:</p>
        <asp:TextBox ID="lastname" runat="server"></asp:TextBox>
        <p>Enter password:</p>
         <asp:TextBox ID="password" type="password" runat="server"></asp:TextBox>
        <p>Enter email:</p>
        <asp:TextBox ID="email" runat="server"></asp:TextBox>
            <p>Enter gender:</p>
        <asp:DropDownList ID="gender" runat="server">
            <asp:ListItem Value="">Please Select</asp:ListItem>  
            <asp:ListItem Value="0">Male</asp:ListItem> 
            <asp:ListItem Value="1">Female</asp:ListItem>  
        </asp:DropDownList>
        <p>Enter address:</p>
        <asp:TextBox ID="address" runat="server"></asp:TextBox>
                </asp:Panel>
        <br/>
            <asp:Label ID="error" runat="server"></asp:Label>
        <br/>
        <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" CssClass="btn-2"/>
    </div>
    </form>
</body>
</html>
