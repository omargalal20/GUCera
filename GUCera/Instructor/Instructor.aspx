<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instructor.aspx.cs" Inherits="GUCera.Instructor" %>

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
        .content{
             margin:20px;
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
            add course:
            <br />
        <asp:Button ID="Button1" runat="server" Text="Add Course" OnClick="addCoruse" CssClass="button" />
        <br />
        <br />
        Assignments:<br />
        <asp:Button ID="Button2" runat="server" OnClick="aepView_Click" Text="View" CssClass="button" />
        <br />
        <br />
        feedbacks:<p>
            <asp:Button ID="Button3" runat="server" OnClick="feedBacksView_Click" Text="View" CssClass="button" />
        </p>
        <p>
            Issue Certificates:</p>
        <p>
            <asp:Button ID="Button4" runat="server" OnClick="certificatesissue_Click" Text="Issue" CssClass="button"/>
        </p>

        </div>
    </form>
</body>
</html>
