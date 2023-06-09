﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LogOn.aspx.cs" Inherits="CareerPlanning.LogOn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

    <h1 align="center"><b>PLEASE SIGN IN</b></h1>

        
            <table align="center">
                <tr>
                    <td width="150px"></td>
                    <td align="right">
                        <label for="inputENumber">E-Number:&nbsp;</label>
                    </td>
                    <td>
                        <label for="inputENumber">
                        <asp:TextBox ID="inputENumber" runat="server"></asp:TextBox>
                        </label>
                    </td>
                    <td width="150px">
                        <!-- Requires that the ENumber field is filled out and follows the format of an ENumber -->
                        &nbsp;<asp:RequiredFieldValidator ID="logInENum" runat="server" ControlToValidate="inputENumber" CssClass="error" Display="Dynamic" ErrorMessage="e-number is required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="LogIneNumRegX" runat="server" ErrorMessage="Incorrect Format" CssClass="error" ControlToValidate="inputENumber" ValidationExpression="^(e\d{7})$" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <label for="inputENumber">Password:&nbsp;</label>
                    </td>
                    <td>
                        <asp:TextBox ID="signInPass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <!-- Requires that the password field is filled -->
                        <asp:RequiredFieldValidator ID="reqlogInPass" runat="server" ControlToValidate="signInPass" CssClass="error" Display="Dynamic" ErrorMessage="password is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>


            <p align ="center">
                <asp:Label ID="lbInvalidLogIn" runat="server" Text="Invalid eNumber or password" CssClass="error"></asp:Label>
                <br />
                <asp:Button ID="btnSignIn" runat="server" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnSignIn_Click" Text="Sign in" BackColor="#1D376C" BorderColor="#1D376C" />
                <br />
                
                <br />
                <!-- redirects to Sign up for students who do not have an account -->
                Don't have an account? <asp:HyperLink ID="hlCreateOne" runat="server" NavigateUrl="http://careers.elmcsis.com/signup.aspx">Create One</asp:HyperLink>
            </p>
    
</asp:Content>
