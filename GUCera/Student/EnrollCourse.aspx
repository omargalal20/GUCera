<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrollCourse.aspx.cs" Inherits="GUCera.EnrollCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enroll</title>
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

.courseinfo,.enroll{
    margin:20px;
}

.addmobile .button,.navbar .button,.enroll .button{
    border-radius: 5px;
    padding: 10px;
    height:40px;
    margin:10px;
}
.enroll .button:hover, .navbar .button:hover {
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
        <div class="courseinfo">
            <asp:Panel ID="infoPanel" runat="server">

            </asp:Panel>
        </div>
                 <br />
                 <br />
        <div class="enroll">
            <asp:Label ID="Label1" runat="server" Text="Write the id of the instructor who you would like to be with"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />

            <asp:Button ID="Button1" runat="server" Text="Enroll" OnClick="enroll_Click" CssClass="button"/>
        </div>
    </form>
</body>
</html>
