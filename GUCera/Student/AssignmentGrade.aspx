<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignmentGrade.aspx.cs" Inherits="GUCera.AssignmentGrade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AssignmentGrade</title>
    <style type="text/css">
      * {
    margin: 0;
    padding: 0;
    font-family: 'Yellowtail', cursive;
    background-color: lightblue;
}
.navbar {
    float: right;
    margin-left:20px;
}.navbar .button{
    border-radius: 5px;
    padding: 10px;
    margin:10px;
}
    .navbar .button:hover {
    background-color: burlywood;
    border-radius: 5px;
}
    .courseinfo{
    margin:20px;
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
        <div class="courseinfo">
            <asp:Panel ID="Panel1" runat="server" Width="450px" CssClass="panel"></asp:Panel>
            <asp:Label ID="Label1" runat="server" Height="64px" Width="186px"></asp:Label>
        </div>
    </form>
</body>
</html>
