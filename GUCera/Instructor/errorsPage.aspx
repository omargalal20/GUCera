<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errorsPage.aspx.cs" Inherits="GUCera.errorsPage" %>

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
            <p style="margin-left: 560px">
                Please Check your input carefly&nbsp;&nbsp;&nbsp; </p>
            <p style="margin-left: 0px">
                your might be enterd a invalid values </p>
            <p style="margin-left: 0px">
                Or Add a course that already exist or the instructor ID does not exsists</p>
            <p style="margin-left: 560px">
                &nbsp;</p>
            <p style="margin-left: 680px">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" CssClass="button" />
            </p>
        </div>
    </form>
</body>
</html>
