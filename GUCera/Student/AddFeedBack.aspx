<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFeedBack.aspx.cs" Inherits="GUCera.AddFeedBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddFeedBack</title>
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
}
.navbar #Label1{
    height:60px;
    padding: 10px;
}

.cinfo,.feedback {
    margin:20px;
}
.feedback .button, .navbar .button{
    border-radius: 5px;
    padding: 10px;
    margin:10px;
}
.feedback .button:hover, .navbar .button:hover {
    background-color: burlywood;
    border-radius: 5px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
                     <asp:Button ID="home" runat="server" Text="Home" OnClick="Home_Click" CssClass="button"/>
                     <asp:Button ID="profile" runat="server" Text="Profile" OnClick="Profile_Click" CssClass="button"/>
                     <br />
                     <br />
                 </div>
        <div class="cinfo">
            <asp:Panel ID="Panel1" runat="server" Height="214px" Width="445px" style="margin-top: 0px">
                 </asp:Panel>
            <br />
        </div>
        <div class="feedback">
            <asp:Label ID="Label1" runat="server" Text="Write FeedBack"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="feedback" runat="server" Text="Add FeedBack" OnClick="addfeedback_Click" CssClass="button" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="error" runat="server" Width="120px" Height="42px"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="361px" Width="463px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
