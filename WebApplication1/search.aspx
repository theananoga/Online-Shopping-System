<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Panel ID="Panel1" runat="server">
                Search:<br /> Goods:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                (ID)<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="number only" ValidationExpression="[0-9]*" ForeColor="Red"></asp:RegularExpressionValidator>
&nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="Order">Order</asp:ListItem>
                    <asp:ListItem Value="Cart">Cart</asp:ListItem>
                </asp:RadioButtonList>
                &nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Buy" />
                <br />
                <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="e" Text="Edit" />
                        <asp:ButtonField ButtonType="Button" CommandName="del" Text="Delete" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                <br />
                <asp:Panel ID="Panel2" runat="server" Visible="False">
                    Goods:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <br />
                    Payment Method:<asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem Value="1">Credit Card</asp:ListItem>
                        <asp:ListItem Value="2">Cash on Delivery</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    Delivery:<asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource1" DataTextField="tName" DataValueField="tId">
                    </asp:DropDownList>
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [tName], [tId] FROM [Transport]"></asp:SqlDataSource>
                    <br />
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="check" />
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" Visible="False">
                    Number:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Check" />
                </asp:Panel>
                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Log Out" />
                <br />
            </asp:Panel>
            
            <br />
        </div>
    </form>
</body>
</html>
