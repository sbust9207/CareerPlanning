﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CareerPlanning.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

    <h1 align="center"><b>CREATE AN ACCOUNT</b></h1>

            <table align="center"> 
                <tr>
                    <td width="125px"></td>
                    <td align="right">
                        <label for="inputENumber">E-Number:&nbsp;</label>
                    </td>
                    <td>
                        <asp:TextBox ID="cAinputENumber" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="createENum" runat="server" ControlToValidate="cAinputENumber" CssClass="error" Display="Dynamic" ErrorMessage="E-number is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right">
                        <label for="inputENumber">Password:&nbsp;</label>
                    </td>
                    <td>
                        <asp:TextBox ID="cAPassword" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="createPassword" runat="server" ControlToValidate="cAPassword" CssClass="error" Display="Dynamic" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="125px"></td>
                    <td align="right">Grade Level:&nbsp;
                    </td>
                    <td>
                        <asp:DropDownList ID="createGradeLevel" runat="server" OnSelectedIndexChanged="createGradeLevel_SelectedIndexChanged">
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem>Fr</asp:ListItem>
                            <asp:ListItem>So</asp:ListItem>
                            <asp:ListItem>Jr</asp:ListItem>
                            <asp:ListItem>Sn</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                </table>
            <br />
            <p align ="center">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-lg btn-primary btn-block" OnClick="Button1_Click" Text="Create Account" />
                <br />
                Already have an account? <asp:HyperLink ID="hlSignIn" runat="server" NavigateUrl="http://careers.elmcsis.com/logon.aspx">Sign In</asp:HyperLink>
            </p>

</asp:Content>
