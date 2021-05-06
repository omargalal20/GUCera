<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAssignment.aspx.cs" Inherits="GUCera.StudentAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment</title>
    <style type="text/css">    
* {
    margin: 0;
    padding: 0;
    font-family: 'Yellowtail', cursive;
    background-color: lightblue;
}
.panel{
    margin:20px;
}
.navbar {
    float: right;
    margin-left:20px;
}
.assigninfo
{
    margin:20px;
}
.assigninfo .button, .navbar .button{
    border-radius: 5px;
    padding: 10px;
    margin:10px;
}
.assigninfo .button:hover, .navbar .button:hover {
    background-color: burlywood;
    border-radius: 5px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
                     <asp:Button ID="home" runat="server" Text="Home" OnClick="Home_Click" Width="81px" CssClass="button" />
                     &nbsp;
                     <asp:Button ID="profile" runat="server" Text="Profile" OnClick="Profile_Click" Width="89px" CssClass="button" />
        </div>
        <div class="assigninfo">
            <asp:Label ID="error" runat="server"></asp:Label>
            <asp:Panel ID="Panel1" runat="server" Width="450px" CssClass="panel"></asp:Panel>
        </div>
    </form>
</body>
</html>
