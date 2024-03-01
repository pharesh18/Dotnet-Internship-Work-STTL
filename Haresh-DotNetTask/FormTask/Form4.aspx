<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Form4.aspx.cs" Inherits="Form4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/CSS/Form4.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="title">Employee Data Form</h1>
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
                            <asp:Label ID="LblPhone" runat="server" Text="Phone Number"></asp:Label>
                        </td>
                        <td class="table-right" style="display: flex">
                            <asp:TextBox ID="TxtPhone" CssClass="inputCont" TextMode="Number" MaxLength="10" runat="server"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Phone is Required" ForeColor="Red" ControlToValidate="TxtPhone" Text="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid phone" ForeColor="Red" ControlToValidate="TxtPhone" Text="*" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblUpload" runat="server" Text="Passport Size Photo"></asp:Label>
                        </td>
                        <td class="table-right" style="margin-bottom: 20px;">
                            <asp:FileUpload CssClass="inputCont" ID="FileUploadPhoto" runat="server" /><br />
                            <asp:Button ID="BtnUpload" runat="server" Text="Upload" CssClass="btn" CausesValidation="false" OnClick="BtnUpload_Click" />
                            <asp:Label ID="LblMsg" runat="server" Text="" Visible="true" CssClass="msg"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblDropDownCity" runat="server" Text="City"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:DropDownList ID="DropDownListCity" CssClass="inputCont" runat="server">
                                <asp:ListItem Text="-- Select --" Value="" Disabled="true" Selected></asp:ListItem>
                                <asp:ListItem Text="Ahmedabad" Value="Ahmedabad"></asp:ListItem>
                                <asp:ListItem Text="Surat" Value="Surat"></asp:ListItem>
                                <asp:ListItem Text="Rajkot" Value="Rajkot"></asp:ListItem>
                            </asp:DropDownList>
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
                            </asp:CheckBoxList>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblDept" runat="server" Text="Department"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:RadioButtonList ID="RadioBtnDept" CssClass="inputCont" runat="server">
                                <asp:ListItem>Marketing</asp:ListItem>
                                <asp:ListItem>Sales</asp:ListItem>
                                <asp:ListItem>Technical</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>


                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblSalary" runat="server" Text="Salary"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:TextBox ID="TxtSalary" CssClass="inputCont" runat="server" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Salary is Required" ForeColor="Red" ControlToValidate="TxtSalary" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblDate" runat="server" Text="Job Starting Date"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:TextBox ID="txtDate" CssClass="inputCont" runat="server" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Date is Required" ForeColor="Red" ControlToValidate="txtDate" Text="*"></asp:RequiredFieldValidator>
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
                <asp:GridView ID="GridView1" DataKeyNames="EMP_ID" runat="server" AutoGenerateColumns="false" EmptyDataText="No records has been added."
                    PageSize="3" AllowPaging="true" OnPageIndexChanging="OnPaging">
                    <Columns>
                        <asp:TemplateField HeaderText="EMP_ID" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblEMP_ID" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EMP_NAME" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblEMP_NAME" runat="server" Text='<%# Eval("EMP_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EMP_PHONE" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblEMP_PHONE" runat="server" Text='<%# Eval("EMP_PHONE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EMP_CITY" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblEMP_CITY" runat="server" Text='<%# Eval("EMP_CITY") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EMP_INTEREST" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblEMP_INTEREST" runat="server" Text='<%# Eval("EMP_INTEREST") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EMP_IMAGE" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblEMP_IMAGE" runat="server" Text='<%# Eval("EMP_IMAGE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EMP_DEPARTMENT" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblEMP_DEPARTMENT" runat="server" Text='<%# Eval("EMP_DEPT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EMP_SALARY" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblEMP_SALARY" runat="server" Text='<%# Eval("EMP_SALARY") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="JOB_STARTING_DATE" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblJOB_STARTING_DATE" runat="server" Text='<%# Eval("EMP_START_DATE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </form>
</body>
</html>
