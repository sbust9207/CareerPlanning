<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CareerPlanning.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

    <h1 align="center"><b>CREATE AN ACCOUNT</b></h1>

            <table align="center"> 
                <tr>
                    <td width="150px"></td>
                    <td align="right">
                        <label for="inputENumber">E-Number:&nbsp;</label>
                    </td>
                    <td>
                        <asp:TextBox ID="cAinputENumber" runat="server"></asp:TextBox>
                    </td>
                    <td width="150px">
                        <!-- Requires that the ENumber field is filled out and follows the format of an ENumber -->
                        <asp:RequiredFieldValidator ID="createENum" runat="server" ControlToValidate="cAinputENumber" CssClass="error" Display="Dynamic" ErrorMessage="E-number is required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="cAeNumRegX" runat="server" ErrorMessage="Incorrect Format" CssClass="error" ControlToValidate="cAinputENumber" ValidationExpression="^(e\d{7})$" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right">
                        <label for="inputENumber">Password:&nbsp;</label>
                    </td>
                    <td>
                        <asp:TextBox ID="cAPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <!-- Requires that the password field is filled out -->
                        <asp:RequiredFieldValidator ID="createPassword" runat="server" ControlToValidate="cAPassword" CssClass="error" Display="Dynamic" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right">Grade Level:&nbsp;
                    </td>
                    <td>
                        <asp:DropDownList ID="createGradeLevel" runat="server">
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem>Fr</asp:ListItem>
                            <asp:ListItem>So</asp:ListItem>
                            <asp:ListItem>Jr</asp:ListItem>
                            <asp:ListItem>Sn</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="valGradeLevel" runat="server" Text="Grade level required" CssClass="error"></asp:Label></td>
                </tr>
                </table>
            <br />
            <p align ="center">
                <asp:Button ID="btnCreateAccount" runat="server" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnCreateAccount_Click" Text="Create Account" BackColor="#1D376C" BorderColor="#1D376C" />
            </p>
            
            <!-- Redirects to LogOn.aspx for students who navigated to sign up by mistake -->
            <p align="center">Already have an account? <asp:HyperLink ID="hlSignIn" runat="server" NavigateUrl="http://careers.elmcsis.com/logon.aspx">Sign In</asp:HyperLink></p>
</asp:Content>
