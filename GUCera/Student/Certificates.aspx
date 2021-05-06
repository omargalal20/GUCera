<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Certificates.aspx.cs" Inherits="GUCera.Certificates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Certificate</title>
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

.courseinfo{
    margin:20px;
}

.navbar .button{
    border-radius: 5px;
    padding: 10px;
    height:40px;
    margin:10px;
}
.navbar .button:hover {
    background-color: burlywood;
    border-radius: 5px;
}
    </style>
</head>
    
<body>
    <form id="form1" runat="server">
        <div>
             <div class="navbar">
                     <asp:Button ID="home" runat="server" Text="Home" OnClick="Home_Click" Width="81px" CssClass="button" />
                     &nbsp;
                     <asp:Button ID="profile" runat="server" Text="Profile" OnClick="Profile_Click" Width="89px" CssClass="button" />
        </div>
        <div class="courseinfo">
            <asp:Panel ID="infoPanel" runat="server">
                <asp:Label ID="Label1" runat="server" ></asp:Label>
            </asp:Panel>
        </div>
        </div>
    </form>
</body>
</html>
