<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assingment.aspx.cs" Inherits="GUCera.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        * {
    margin: 0;
    padding: 0;
    font-family: 'Yellowtail', cursive;
    background-color: lightblue;
}
     .content .button{
            border-radius: 5px;
    padding: 10px;
    margin:10px;
}
.content .button:hover{
    background-color: burlywood;
    border-radius: 5px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            Submitted Assignments by Students:<br />
            <br />
            Instructor Id:<br />
            <asp:TextBox ID="insID" runat="server"></asp:TextBox>
            <br />
            Course Id:<br />
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="View" CssClass="button" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
