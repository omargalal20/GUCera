<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AEP.aspx.cs" Inherits="GUCera.WebForm1" %>

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
            Add Assignment:<br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" CssClass="button"/>
            <br />
            <br />
            View submitted Assignments and Grading:<br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="View" CssClass="button"/>
        </div>
    </form>
</body>
</html>
