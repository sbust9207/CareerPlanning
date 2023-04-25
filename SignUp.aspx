<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CareerPlanning.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">


        <div class="form-group pb-2">
            <table align="center" class="w-100">
                <tr>
                    <td>&nbsp;</td>
                    <td align="center" size="16px"><b>CREATE AN ACCOUNT<br />
                        </b></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 35px"></td>
                    <td align="center" style="height: 35px">
                        <label for="inputENumber">E-Number:
                        <asp:TextBox ID="inputENumber" runat="server"></asp:TextBox>
                        </label>
                    </td>
                    <td style="height: 35px"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <label for="inputENumber">Password:&nbsp;
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 35px"></td>
                    <td align="center" style="height: 35px">Enter Grade Level:
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>Fr</asp:ListItem>
                            <asp:ListItem>So</asp:ListItem>
                            <asp:ListItem>Jr</asp:ListItem>
                            <asp:ListItem>Sn</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="height: 35px"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <button id="btnSignUp" class="btn btn-lg btn-primary btn-block" type="submit">Sign Up</button>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <p align ="center">Already have an account? <asp:HyperLink ID="hlSignIn" runat="server">Sign In</asp:HyperLink>
            </p>
        </div>

</asp:Content>
