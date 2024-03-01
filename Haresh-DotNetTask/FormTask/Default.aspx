<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="width: 100%; display: flex; flex-direction: column; align-items: center; border: 1px solid red;">
            <h1 style="text-align: center; margin-bottom: 20px;">Registration Form</h1>

            <table class="nav-justified" style="width: 700px; height: 392px; overflow:hidden; font-size: 18px;">
            <tr>
                <td>
                    <asp:Label ID="lblfname" runat="server" Text="First Name"></asp:Label>
                </td>
                <td style="width: 100%; height: 60px; display: flex; align-items: center;">
                    <asp:TextBox ID="txtFname" runat="server" Width="380px" style="padding: 5px; margin: 0"></asp:TextBox> &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtFname" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbllname" runat="server" Text="Last Name"></asp:Label>
            </td>
            <td style="width: 100%; height: 60px; display: flex; align-items: center;">
                <asp:TextBox ID="txtLname" runat="server" Width="380px" style="padding: 5px; margin: 0" TabIndex="1"></asp:TextBox> &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtLname" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblemail" runat="server" Text="Email"></asp:Label>
            </td>
            <td style="width: 100%; height: 60px; display: flex; align-items: center;">
                <asp:TextBox ID="txtEmail" runat="server" Width="380px" style="padding: 5px; margin: 0" TabIndex="2"></asp:TextBox> &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator> &nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid email" ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblpass" runat="server" Text="Password"></asp:Label>
            </td>
            <td style="width: 100%; height: 60px; display: flex; align-items: center;">
                <asp:TextBox ID="txtPass" runat="server" Width="380px" style="padding: 5px; margin: 0" TabIndex="3"></asp:TextBox> &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtPass" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblcontact" runat="server" Text="Contact Number"></asp:Label>
            </td>
            <td style="width: 100%; height: 60px; display: flex; align-items: center;">
                <asp:TextBox ID="txtContact" runat="server" Width="380px" style="padding: 5px; margin: 0" TabIndex="4"></asp:TextBox> &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtContact" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblgender" runat="server" Text="Gender"></asp:Label>
            </td>
            <td style="width: 100%; height: 80px; display: flex; align-items: center;">
                <asp:RadioButtonList ID="radioBtnGender" runat="server" TabIndex="5">
                    <asp:ListItem Value="1"> &nbsp; Male</asp:ListItem>
                    <asp:ListItem Value="0"> &nbsp; Female</asp:ListItem>
                </asp:RadioButtonList>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="radioBtnGender" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
                <tr>
            <td>
                <asp:CheckBoxList ID="chkBox" runat="server" ValidateRequestMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="chkBox_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td style="width: 100%; height: 60px; display: flex; align-items: center;"">
                <asp:Label ID="lblterms" runat="server" Text="Agree With the Terms and Conditions"></asp:Label>&nbsp;
            <asp:Label ID="chkValidate" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
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
     <asp:GridView ID="GridView1" runat="server" DataKeyNames="USER_ID" EmptyDataText="No Records Found." OnRowEditing="EditData" OnRowDeleting="DeleteData" AutoGenerateDeleteButton="True" OnRowDataBound="BoundData" AutoGenerateEditButton="True" BorderStyle="Solid" CellSpacing="-1"></asp:GridView>
     <br /><br /><br /><br /><br />
    </div>




</asp:Content>

        <%--<tr>
            <td style="width: 184px">
                <asp:Label ID="Label4" runat="server" Text="STREET"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Width="271px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="Label5" runat="server" Text="CITY"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Width="271px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="Label6" runat="server" Text="PINCODE"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" Width="271px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="Label7" runat="server" Text="STATE"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" Width="271px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="Label8" runat="server" Text="COUNTRY"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server" Width="271px"></asp:TextBox>
            </td>
        </tr>--%>