<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%; display: flex; flex-direction: column; align-items: center; border: 1px solid red;">
            <h1 style="text-align: center; margin-bottom: 20px;">Product Page</h1>

            <table class="nav-justified" style="width: 700px; height: 392px; overflow:hidden; font-size: 18px;">
            <tr>
                <td>
                    <asp:Label ID="lblPname" runat="server" Text="Product Name"></asp:Label>
                </td>
                <td style="width: 100%; margin-bottom: 20px; display: flex; align-items: center;">
                    <asp:TextBox ID="txtPname" runat="server" Width="380px" style="padding: 5px; margin: 0"></asp:TextBox> &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtpname" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
            <td>
                <asp:Label ID="lblPdetails" runat="server" Text="Product Details"></asp:Label>
            </td>
            <td style="width: 100%; margin-bottom: 20px; display: flex; align-items: center;">
                <asp:TextBox ID="txtPdetails" runat="server" Width="380px" style="padding: 5px; margin: 0" TabIndex="1"></asp:TextBox> &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtPdetails" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
            </td>
            <td style="width: 100%; margin-bottom: 20px; display: flex; align-items: center;">
                <asp:TextBox ID="txtPrice" runat="server" Width="380px" style="padding: 5px; margin: 0" TabIndex="2"></asp:TextBox> &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtPrice" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblQty" runat="server" Text="Quantity"></asp:Label>
            </td>
            <td style="width: 100%; margin-bottom: 20px; display: flex; align-items: center;">
                <asp:TextBox ID="txtQty" runat="server" Width="380px" style="padding: 5px; margin: 0" TabIndex="3"></asp:TextBox> &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtQty" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblManDate" runat="server" Text="Manufacture Date"></asp:Label>
            </td>
            <td style="width: 100%; margin-bottom: 20px; display: flex; align-items: center;">
                <asp:Calendar ID="calManDate" runat="server"></asp:Calendar>&nbsp;
                <asp:Label ID="chkManDate" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>      
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblExpDate" runat="server" Text="Expiry Date"></asp:Label>
            </td>
            <td style="width: 100%; margin-bottom: 20px; display: flex; align-items: center;">
                <asp:Calendar ID="calExpDate" runat="server"></asp:Calendar>&nbsp;

                <asp:Label ID="chkExpDate" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPtype" runat="server" Text="Product Type"></asp:Label>
            </td>
            <td style="width: 100%; margin-bottom: 20px; display: flex; align-items: center;">
                &nbsp;<asp:DropDownList ID="dropDownProductType" runat="server">
                    <asp:ListItem>Electronics</asp:ListItem>
                    <asp:ListItem>Food</asp:ListItem>
                    <asp:ListItem>Materialistic</asp:ListItem>
                </asp:DropDownList>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="dropDownProductType" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="height: 100px;">
                <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" TabIndex="7" Height="35px" Width="100px"  />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" Text="RESET" TabIndex="8" OnClick="btnReset_Click" CausesValidation="false" Height="35px" Width="100px" />
            </td>
        </tr>
    </table>
     &nbsp; &nbsp; &nbsp; 
     <br /><br /><br /><br /><br /><br />
     <asp:GridView ID="GridView1" runat="server" DataKeyNames="PRODUCT_ID" EmptyDataText="No Records Found." OnRowEditing="EditData" OnRowDeleting="DeleteData" AutoGenerateDeleteButton="True" OnRowDataBound="BoundData" AutoGenerateEditButton="True" BorderStyle="Solid" CellSpacing="-1"></asp:GridView>
     <br /><br /><br /><br /><br />
    </div>
    </form>
</body>
</html>
