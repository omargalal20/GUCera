<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="GUCera.StudentHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
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

.container1,.container2 {
    margin:20px;
}
.container1 .button,.container2 .button, .navbar .button{
    border-radius: 5px;
    padding: 10px;
    height:40px;
    margin:10px;
}
.container1 .button:hover,.container2 .button:hover, .navbar .button:hover {
    background-color: burlywood;
    border-radius: 5px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
             
                 <div class="navbar">
                     <asp:Label ID="Label1" runat="server"></asp:Label>
                     <asp:Button ID="profile" runat="server" Text="Profile" OnClick="Profile_Click" CssClass="button" />
                 </div>
                 <div class="container1">
                 <asp:Label ID="Label2" runat="server" Height="40px" Width="229px">Courses to enroll in : </asp:Label>
                 <br />
                 <br />
                 <asp:Panel ID="Panel1" runat="server" Height="214px" Width="445px" style="margin-top: 0px">
                 </asp:Panel>
                  </div>
                 <br />
                 <br />
                 <div class="container2">
                 <asp:Label ID="Label3" runat="server" Height="40px" Width="229px">Courses you're enrolled in</asp:Label>
                 <br />
                 <br />
                 <asp:Panel ID="Panel2" runat="server" Height="214px" Width="445px" style="margin-top: 0px">
                 </asp:Panel>
                 </div>
    </form>
</body>
</html>
