<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LogOn.aspx.cs" Inherits="CareerPlanning.LogOn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

    <h1 align="center"><b>PLEASE SIGN IN</b></h1>

        
            <table align="center">
                <tr>
                    <td align="right">
                        <label for="inputENumber">E-Number:&nbsp;</label>
                    </td>
                    <td>
                        <label for="inputENumber">
                        <asp:TextBox ID="inputENumber" runat="server"></asp:TextBox>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <label for="inputENumber">Password:&nbsp;</label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>


            <p align ="center">
                <br />
                <button id="btnSubmit" class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>
                <br />
                Need to update grade level?
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>Fr</asp:ListItem>
                    <asp:ListItem>So</asp:ListItem>
                    <asp:ListItem>Jr</asp:ListItem>
                    <asp:ListItem>Sn</asp:ListItem>
                </asp:DropDownList>
                <br />
                Don't have an account? <asp:HyperLink ID="hlCreateOne" runat="server" NavigateUrl="http://careers.elmcsis.com/signup.aspx">Create One</asp:HyperLink>
            </p>
    
</asp:Content>
