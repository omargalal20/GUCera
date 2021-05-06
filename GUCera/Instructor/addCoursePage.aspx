<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCoursePage.aspx.cs" Inherits="GUCera.addCoursePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 170px;
        }
        #TextArea2 {
            height: 176px;
        }
        #desInput {
            height: 128px;
        }
        #contentInput {
            height: 132px;
            margin-bottom: 74px;
        }
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
            Instructor ID:<br />
            <asp:TextBox ID="instID" runat="server"></asp:TextBox>
            <br />
            <br />
            Course
            Name:
        <br />
        <p>
            <asp:TextBox ID="cName" runat="server" ></asp:TextBox>
        </p>
        <p>
            Credit hours:</p>
        <p>
            <asp:TextBox ID="creditHours" runat="server"></asp:TextBox>
        </p>
        <p>
            Description:</p>
        <p>
            <asp:TextBox ID="descInput" runat="server"></asp:TextBox>
        </p>
        <p>
            Content:</p>
        <p>
            <asp:TextBox ID="contentInput" runat="server"></asp:TextBox>
        </p>
        <p>
            Price:</p>
        <p>
            <asp:TextBox ID="price" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Course" CssClass="button" />
        </p>

        </div>
    </form>
</body>
</html>
