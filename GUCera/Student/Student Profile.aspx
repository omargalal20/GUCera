<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student Profile.aspx.cs" Inherits="GUCera.Student_Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
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

.info,.addmobile ,.addcredit ,.navbar ,.promo{
    margin:20px;
}

.addmobile .button,.addcredit .button, .navbar .button,.promo .button{
    border-radius: 5px;
    padding: 10px;
    height:40px;
    margin:10px;
}
.addmobile .button:hover,.addcredit .button:hover, .navbar .button:hover,.promo .button:hover {
    background-color: burlywood;
    border-radius: 5px;
}
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="navbar">
                     <asp:Label ID="Label1" runat="server"></asp:Label>
                     <asp:Button ID="home" runat="server" Text="Home" OnClick="Home_Click" CssClass="button"/>
                 </div>
        <div class="info">
            <asp:Label ID="infolabel" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Panel ID="infoPanel" runat="server" Height="128px" Width="698px">
                <br />
                <br />
            </asp:Panel>

        </div>
        <br />
        <div class="addmobile">
            <asp:Label ID="addmobilelabel" runat="server" Text="Press add button to add boxes to fill in multiple numbers"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="addmobilebutton" runat="server" Height="29px" Text="Add MobileBox" OnClick="addmobile_Click" CssClass="button"/>
            <asp:Button ID="savemobile" runat="server" Height="29px" Text="Save" OnClick="savemobile_Click" CssClass="button"/>
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="mobilesPanel" runat="server" Width="350px">
            </asp:Panel>
        </div>
       <div class="addcredit">
           <asp:Panel ID="creditPanel" runat="server" Width="455px">
             <asp:Label ID="addcreditlabel" runat="server" Text="Credit Card Info"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="addcreditbutton" runat="server" Height="29px" Text="addcredit"  OnClick="addcredit_Click" CssClass="button"/>
            <asp:Label ID="error" runat="server" Width="200px"></asp:Label>
            <br />
            <br />
            <p>Enter Card Number:</p>
            <asp:TextBox ID="number" runat="server"></asp:TextBox>
            <p>Enter Card Holder Name:</p>
            <asp:TextBox ID="cardholdername" runat="server"></asp:TextBox>
            <p>Enter Expiry Date:</p>
            <asp:TextBox ID="expirydate" type="Date" runat="server"></asp:TextBox>
            <p>Enter cvv:</p>
            <asp:TextBox ID="cvv" runat="server"></asp:TextBox>
          </asp:Panel>
       </div>
       <div class="promo">
           <asp:Label ID="promolabel" runat="server" Text="PromoCodes"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="promobutton" runat="server" Height="29px" Text="Show Promo Codes" OnClick="viewpromo_Click" CssClass="button"/>
            <br />
            <br />
            <asp:Panel ID="promoPanel" runat="server" Height="189px" Width="184px">
                <br />
            </asp:Panel>
       </div>
    </form>
</body>
</html>
