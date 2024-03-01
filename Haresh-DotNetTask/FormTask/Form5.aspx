<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Form5.aspx.cs" Inherits="Form5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/CSS/Form5.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="title">Student Form</h1>
            <div class="middle-cont">
                <table class="table">
                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:TextBox CssClass="inputCont" ID="TxtName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is Required" ForeColor="Red" ControlToValidate="TxtName" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td class="table-right" style="display: flex">
                            <asp:TextBox ID="TxtEmail" CssClass="inputCont" TextMode="Email" runat="server"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email is Required" ForeColor="Red" ControlToValidate="TxtEmail" Text="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid email" ForeColor="Red" ControlToValidate="TxtEmail" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblDropDownList" runat="server" Text="College Year"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:DropDownList ID="DropDownListYear" CssClass="inputCont" runat="server">
                                <asp:ListItem Text="-- Select --" Value="" Disabled="true" Selected></asp:ListItem>
                                <asp:ListItem Text="1st Year" Value="1st Year"></asp:ListItem>
                                <asp:ListItem Text="2nd Year" Value="2nd Year"></asp:ListItem>
                                <asp:ListItem Text="3rd Year" Value="3rd Year"></asp:ListItem>
                                <asp:ListItem Text="4th Year" Value="4th Year"></asp:ListItem>
                                <asp:ListItem Text="5th Year" Value="5th Year"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Year is Required" ForeColor="Red" Text="*" ControlToValidate="DropDownListYear"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LabelInterest" runat="server" Text="Interest"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:CheckBoxList ID="CheckBoxListInterest" CssClass="inputCont" runat="server" CausesValidation="False">
                                <asp:ListItem Text="Reading" Value="Reading"></asp:ListItem>
                                <asp:ListItem Text="Writing" Value="Writing"></asp:ListItem>
                                <asp:ListItem Text="Singing" Value="Singing"></asp:ListItem>
                                <asp:ListItem Text="Cricket" Value="Cricket"></asp:ListItem>
                                <asp:ListItem Text="Travelling" Value="Travelling"></asp:ListItem>
                                <asp:ListItem Text="Dancing" Value="Dancing"></asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblDivision" runat="server" Text="Divison"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:RadioButtonList ID="RadioBtnDivision" CssClass="inputCont" runat="server">
                                <asp:ListItem>A</asp:ListItem>
                                <asp:ListItem>B</asp:ListItem>
                                <asp:ListItem>C</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Division is Required" ForeColor="Red" Text="*" ControlToValidate="RadioBtnDivision"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblDob" runat="server" Text="Date of Birth"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:TextBox ID="txtDob" CssClass="inputCont" runat="server" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="DOB is Required" ForeColor="Red" ControlToValidate="txtDob" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblAddress" runat="server" Text="Address"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:TextBox ID="txtAddress" CssClass="inputCont" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Address is Required" ForeColor="Red" Text="*" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left"></td>
                        <td class="table-right">
                            <asp:Button ID="BtnAdd" CssClass="btn" runat="server" Text="Add" ValidateRequestMode="Enabled" OnClick="btnAdd_Click" />
                            <asp:Button ID="BtnReset" CssClass="btn" runat="server" Text="Reset" CausesValidation="False" OnClick="BtnReset_Click" ValidateRequestMode="Disabled" />
                        </td>
                    </tr>
                </table>

                <div class="validation-cont">
                    <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" Font-Size="Larger" runat="server" />
                </div>
            </div>

            <div class="gridView">
                <asp:GridView ID="GridView1" DataKeyNames="STU_ID" runat="server" AutoGenerateColumns="false" EmptyDataText="No records has been added." OnRowDataBound="OnRowDataBound"
                    OnRowEditing="OnRowEditing" OnRowDeleting="OnRowDeleting" PageSize="3" AllowPaging="true" OnPageIndexChanging="OnPaging">
                    <Columns>
                        <asp:TemplateField HeaderText="lblSTU_ID" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="STU_ID" runat="server" Text='<%# Eval("STU_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STU_NAME" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblSTU_NAME" runat="server" Text='<%# Eval("STU_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STU_EMAIL" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblSTU_EMAIL" runat="server" Text='<%# Eval("STU_EMAIL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STU_YEAR" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblSTU_YEAR" runat="server" Text='<%# Eval("STU_YEAR") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STU_INTEREST" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblSTU_INTEREST" runat="server" Text='<%# Eval("STU_INTEREST") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STU_DIVISION" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblSTU_DIVISION" runat="server" Text='<%# Eval("STU_DIVISION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STU_DOB" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblSTU_DOB" runat="server" Text='<%# Eval("STU_DOB") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STU_ADDRESS" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblSTU_ADDRESS" runat="server" Text='<%# Eval("STU_ADDRESS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                            ItemStyle-Width="150" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>

    </form>
</body>
</html>
