<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addingAssi.aspx.cs" Inherits="GUCera.WebForm3" %>

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
            Instructor ID:<br />
            <asp:TextBox ID="insIdInput" runat="server"></asp:TextBox>
            <br />
            Course ID:<br />
            <asp:TextBox ID="courseIdInput" runat="server"></asp:TextBox>
            <br />
            Assignment Number:<br />
            <asp:TextBox ID="assiNumbInput" runat="server"></asp:TextBox>
            <br />
            Type:<br />
            <asp:DropDownList ID="typeInput" runat="server">
                <asp:ListItem Value="">Please Select</asp:ListItem>
                <asp:ListItem Value="exam">Exam</asp:ListItem>
                <asp:ListItem Value="euiz">Quiz</asp:ListItem>
                <asp:ListItem Value="project">Project</asp:ListItem>
            </asp:DropDownList>
            <br />
            Full Grade:<br />
            <asp:TextBox ID="fGradeInput" runat="server"></asp:TextBox>
            <br />
            Weight:<br />
            <asp:TextBox ID="weightInput" runat="server"></asp:TextBox>
            <br />
            Deadline:<br />
            <asp:TextBox ID="deadLineInput" runat="server"></asp:TextBox>
            <br />
            <asp:Calendar ID="deadLineCalender" runat="server" OnSelectionChanged="deadLineCalender_SelectionChanged" ></asp:Calendar>
            Content:<br />
            <asp:TextBox ID="contentInput" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" CssClass="button" />
            <br />
        </div>
    </form>
</body>
</html>
