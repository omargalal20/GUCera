<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errAddAssiPage.aspx.cs" Inherits="GUCera.WebForm5" %>

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
            Please check your Inputs<br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back to Adding" CssClass="button" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back to viewing" CssClass="button" />
        </div>
    </form>
</body>
</html>
