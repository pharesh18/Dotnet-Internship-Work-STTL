<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="form2.aspx.cs" Inherits="form2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <div>
            <table class="nav-justified" style="width: 700px; height: 392px; overflow:hidden;">
        <tr>
            <td style="width: 120px">
                <asp:Label ID="lblfname" runat="server" Text="First Name"></asp:Label>
            </td>
            <td style="width: 155px">
                <asp:TextBox ID="txtFname" runat="server" Width="271px" style="margin-left: 0"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="First name is required" ControlToValidate="txtFname" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 120px">
                <asp:Label ID="lbllname" runat="server" Text="Last Name"></asp:Label>
            </td>
            <td style="width: 155px">
                <asp:TextBox ID="txtLname" runat="server" AutoPostBack="true" Width="271px" TabIndex="1"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last name is required" ControlToValidate="txtLname" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 120px">
                <asp:Label ID="lblemail" runat="server" Text="Email"></asp:Label>
            </td>
            <td style="width: 155px">
                <asp:TextBox ID="txtEmail" runat="server" AutoPostBack="true" Width="271px" TabIndex="2"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email is required" ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                &nbsp;<br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid email" ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 120px; height: 42px;">
                <asp:Label ID="lblpass" runat="server" Text="Password"></asp:Label>
            </td>
            <td style="width: 155px; height: 42px;">
                <asp:TextBox ID="txtPass" runat="server" AutoPostBack="true" Width="271px" TabIndex="3"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPass" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 120px; height: 44px;">
                <asp:Label ID="lblcontact" runat="server" Text="Contact Number"></asp:Label>
            </td>
            <td style="height: 44px; width: 155px;">
                <asp:TextBox ID="txtContact" runat="server" AutoPostBack="true" Width="271px" TabIndex="4"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Contact number is required" ControlToValidate="txtContact" ForeColor="Red" Width="278px"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 120px; height: 44px;">
                <asp:Label ID="lblgender" runat="server" Text="Gender"></asp:Label>
            </td>
            <td style="height: 44px; width: 155px">
                <asp:RadioButtonList Width="184px" ID="radioBtnGender" runat="server" AutoPostBack="true" TabIndex="5">
                    <asp:ListItem Value="1"> &nbsp; Male</asp:ListItem>
                    <asp:ListItem Value="0"> &nbsp; Female</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Gender is required" ControlToValidate="radioBtnGender" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
                <tr>
            <td style="width: 120px; height: 44px;">
                <asp:CheckBox ID="chkBox" runat="server" AutoPostBack="true" TabIndex="6" />
            </td>
            <td style="height: 44px; width: 155px;">
                <asp:Label ID="lblterms" runat="server" Text="Agree With the Terms and Conditions"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Agree with the terms and conditions" ControlToValidate="txtFname" ForeColor="Red" Width="278px"></asp:RequiredFieldValidator>
            &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 120px">
                &nbsp;</td>
            <td style="width: 155px">
                <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" TabIndex="7" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" Text="RESET" TabIndex="8" />
            </td>
        </tr>
    </table>
     &nbsp; &nbsp; &nbsp; 
     <br /><br /><br /><br /><br /><br />
     <asp:GridView ID="GridView1" runat="server" DataKeyNames="USER_ID" EmptyDataText="No Records Found." OnRowEditing="EditData" OnRowDeleting="DeleteData" AutoGenerateDeleteButton="True" OnRowDataBound="BoundData" AutoGenerateEditButton="True"></asp:GridView>
     <br /><br /><br /><br /><br />
    </div>
        </div>
    </form>
</body>
</html>--%>
