<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Certificate.aspx.cs" Inherits="GUCera.Certificate" %>

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
            Certificates:<br />
            <br />
            Course ID:<br />
            <asp:TextBox ID="cidInput" runat="server"></asp:TextBox>
            <br />
            Student ID:<br />
            <asp:TextBox ID="sidInput" runat="server"></asp:TextBox>
            <br />
            Instructor ID:<br />
            <asp:TextBox ID="insIdInput" runat="server"></asp:TextBox>
            <br />
            Issue Date:<br />
            <asp:TextBox ID="dateInput" runat="server"></asp:TextBox>
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Issue" OnClick="Button1_Click" CssClass="button"/>
            <br />
        </div>
    </form>
</body>
</html>
