<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            UserName :
            <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="UserName must be filled!" Display="Dynamic" ForeColor="Red" ControlToValidate="tbUserName"></asp:RequiredFieldValidator>--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbUserName" ErrorMessage="please input" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            Password :
            <asp:TextBox ID="tbPass" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbPass" ErrorMessage="please input" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="in" runat="server" OnClick="in_Click" Text="Login" />
            &nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Button ID="clear" runat="server" OnClick="clear_Click" Text="Clear" />
        </div>
    </form>
</body>
</html>
