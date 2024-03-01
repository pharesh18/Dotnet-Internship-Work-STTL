<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <table class="nav-justified" style="width: 576px; height: 392px;">
    <tr>
        <td style="width: 184px">
            <asp:Label ID="lblfname" runat="server" Text="First Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtFname" runat="server" AutoPostBack="false" Width="271px" style="margin-left: 0"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 184px">
            <asp:Label ID="lbllname" runat="server" Text="Last Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtLname" runat="server" AutoPostBack="false" Width="271px" TabIndex="1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 184px">
            <asp:Label ID="lblemail" runat="server" Text="Email"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" AutoPostBack="false" Width="271px" TabIndex="2"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 184px">
            <asp:Label ID="lblpass" runat="server" Text="Password"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPass" runat="server" AutoPostBack="false" Width="271px" TabIndex="3"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 184px; height: 44px;">
            <asp:Label ID="lblcontact" runat="server" Text="Contact Number"></asp:Label>
        </td>
        <td style="height: 44px">
            <asp:TextBox ID="txtContact" runat="server" AutoPostBack="false" Width="271px" TabIndex="4"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 184px; height: 44px;">
            <asp:Label ID="lblgender" runat="server" Text="Gender"></asp:Label>
        </td>
        <td style="height: 44px">
            <asp:RadioButtonList ID="radioBtnGender" runat="server" AutoPostBack="false" TabIndex="5">
                <asp:ListItem Value="1"> &nbsp; Male</asp:ListItem>
                <asp:ListItem Value="0"> &nbsp; Female</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td style="width: 184px">
            &nbsp;</td>
        <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" Text="Update" AutoPostBack="true" TabIndex="8" OnClick="btnUpdate_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnReset" runat="server" Text="RESET" TabIndex="8" OnClick="btnReset_Click" />
        </td>
    </tr>
</table>
</div>
    </form>
</body>
</html>
