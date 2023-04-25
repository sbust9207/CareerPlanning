<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LogOn.aspx.cs" Inherits="CareerPlanning.LogOn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

    <body>
    <form id="frmLogin" runat="server" class="form-signin">
        <div class="form-group pb-2">
            <table align="center" class="w-100">
                <tr>
                    <td>&nbsp;</td>
                    <td align="center"><b>PLEASE SIGN IN</b></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <label for="inputENumber">E-Number:
                        <asp:TextBox ID="inputENumber" runat="server"></asp:TextBox>
                        </label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <label for="inputENumber">Password:
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <button id="btnSubmit" class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>
                        <br />
                        <br />
                        Need to update grade level?
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>Fr</asp:ListItem>
                            <asp:ListItem>So</asp:ListItem>
                            <asp:ListItem>Jr</asp:ListItem>
                            <asp:ListItem>Sn</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <p align ="center">Don't have an account?<asp:HyperLink ID="hlCreateOne" runat="server">Create One</asp:HyperLink>
            </p>
        </div>
    </form>
</body>

</asp:Content>
