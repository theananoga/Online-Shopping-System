<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buy.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cart" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand"  AutoGenerateColumns="False">
                <Columns>
                    <asp:ButtonField Text="add to cart" ButtonType="Button" CommandName="add" />
                    <asp:BoundField DataField="gId" HeaderText="Goods Id" />
                    <asp:BoundField DataField="gName" HeaderText="Name" />
                    <asp:BoundField DataField="Sales" HeaderText="Sales" />
                    <asp:TemplateField HeaderText="Picture">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%#Eval("gPic") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField DataField="gdescribe" HeaderText="Describe" />
                </Columns>
                </asp:GridView>
            <asp:GridView ID="GridView2" runat="server" Visible="False">
            </asp:GridView>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back" Visible="False" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Buy" Visible="False" />
            <br />
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <asp:GridView ID="GridView3" runat="server" Visible="False">
                </asp:GridView>
                <br />
                Payment Method:<asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="1">Credit Card</asp:ListItem>
                    <asp:ListItem Value="2">Cash on Delivery</asp:ListItem>
                </asp:DropDownList>
                <br />
                Delivery:<asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="tName" DataValueField="tId">
                </asp:DropDownList>
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [tName], [tId] FROM [Transport]"></asp:SqlDataSource>
                <br />
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Check" />
                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Home" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
