<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WordFinder.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WordFinder</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="Letters" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Go" OnClick="Go_Click" />
        <br/>
        <asp:TextBox ID="FoundWords" runat="server" Height="321px" TextMode="MultiLine" Width="597px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
