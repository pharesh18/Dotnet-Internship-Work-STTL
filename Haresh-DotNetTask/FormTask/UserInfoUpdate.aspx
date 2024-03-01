<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfoUpdate.aspx.cs" Inherits="UserInfoUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        .table {
            width: 580px;
            /*border: 1px solid red;*/
            box-shadow: 0px 0px 2px 1px rgba(0,0,0,0.5);
            margin: auto;
            text-align: left;
            padding: 20px 15px;
        }

        .middle-cont {
            width: 900px;
            display: flex;
            align-items: start;
            margin: auto;
            margin-bottom: 50px;
        }

        .validation-cont {
            width: 200px;
        }

        .table-left {
            width: 230px;
        }

        .table-right {
            width: 350px;
        }

        .container {
            width: 100%;
            /*border: 1px solid red;*/
            min-height: 100vh;
            text-align: center;
            font-size: 20px;
        }

        .title {
            margin-bottom: 20px;
        }

        .inputCont {
            width: 300px;
            padding: 5px;
            margin-bottom: 10px;
            font-size: 18px;
        }

        .btn {
            padding: 6px 20px;
            font-size: 18px;
            margin-top: 20px;
        }

        .btnConts {
            padding: 4px 10px;
            font-size: 16px;
            margin: 5px;
        }

        .btn:nth-child(1) {
            margin-right: 20px;
        }

        .gridView {
            width: fit-content;
            margin: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="title">User Info Update Form</h1>
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

                    <%--<tr>
                        <td class="table-left">
                            <asp:Label ID="LblUpload" runat="server" Text="Passport Size Photo"></asp:Label>
                        </td>
                        <td class="table-right" style="margin-bottom: 20px;">
                            <asp:FileUpload CssClass="inputCont" ID="FileUploadPhoto" runat="server" /><br />
                            <asp:Button ID="BtnUpload" runat="server" Text="Upload" CssClass="btn" CausesValidation="false" OnClick="BtnUpload_Click" />
                            <asp:Label ID="LblMsg" runat="server" Text="" Visible="true" CssClass="msg"></asp:Label>
                        </td>
                    </tr>--%>

                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblDropDownList" runat="server" Text="Language"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:DropDownList ID="DropDownListLang" CssClass="inputCont" runat="server">
                                <asp:ListItem Text="-- Select --" Value="" Disabled="true" Selected></asp:ListItem>
                                <asp:ListItem Text="DotNet" Value="DotNet"></asp:ListItem>
                                <asp:ListItem Text="Python" Value="Python"></asp:ListItem>
                                <asp:ListItem Text="Node" Value="Node"></asp:ListItem>
                                <asp:ListItem Text="Java" Value="Java"></asp:ListItem>
                                <asp:ListItem Text="PHP" Value="PHP"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left">
                            <asp:Label ID="LblHobby" runat="server" Text="Hobby"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:ListBox ID="ListBoxHobby" CssClass="inputCont" SelectionMode="Multiple" runat="server">
                                <asp:ListItem>Cricket</asp:ListItem>
                                <asp:ListItem>Reading</asp:ListItem>
                                <asp:ListItem>Drawing</asp:ListItem>
                                <asp:ListItem>Travelling</asp:ListItem>
                                <asp:ListItem>Writing</asp:ListItem>
                                <asp:ListItem>Singing</asp:ListItem>
                                <asp:ListItem>Dancing</asp:ListItem>
                            </asp:ListBox>
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
                            <asp:Label ID="LblFeedback" runat="server" Text="Your Feedback"></asp:Label>
                        </td>
                        <td class="table-right">
                            <asp:TextBox ID="txtFeedback" CssClass="inputCont" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="table-left"></td>
                        <td class="table-right">
                            <asp:Button ID="BtnUpdate" CssClass="btn" runat="server" Text="Update" ValidateRequestMode="Enabled" OnClick="btnUpdate_Click" />
                            <asp:Button ID="BtnReset" CssClass="btn" runat="server" Text="Reset" CausesValidation="False" OnClick="BtnReset_Click" ValidateRequestMode="Disabled" />
                        </td>
                    </tr>
                </table>

                <div class="validation-cont">
                    <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" Font-Size="Larger" runat="server" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
