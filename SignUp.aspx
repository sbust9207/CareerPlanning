<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CareerPlanning.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

    <h1 align="center"><b>CREATE AN ACCOUNT</b></h1>

            <table align="center"> 
                <tr>
                    <td align="right">
                        <label for="inputENumber">E-Number:&nbsp;</label>
                    </td>
                    <td>
                        <asp:TextBox ID="inputENumber" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <label for="inputENumber">Password:&nbsp;</label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">Grade Level:&nbsp;
                    </td>
                    <td>
                        <asp:DropDownList ID="createGradeLevel" runat="server" OnSelectedIndexChanged="createGradeLevel_SelectedIndexChanged">
                            <asp:ListItem>Fr</asp:ListItem>
                            <asp:ListItem>So</asp:ListItem>
                            <asp:ListItem>Jr</asp:ListItem>
                            <asp:ListItem>Sn</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                </table>
            <br />
            <p align ="center">
                <button id="btnSignUp" class="btn btn-lg btn-primary btn-block" type="submit" OnClick="btnSignUp_Changed">Sign Up</button>
                <br />
                Already have an account? <asp:HyperLink ID="hlSignIn" runat="server" NavigateUrl="http://careers.elmcsis.com/logon.aspx">Sign In</asp:HyperLink>
            </p>

</asp:Content>
