<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="sen.aspx.cs" Inherits="CareerPlanning.GradeLevels.sen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

    <table align="center">
        <tr>
            <td>&nbsp;</td>
            <td>
                <table>
                    <tr>
                        <td>IMAGE</td>
                        <td>IMAGE</td>
                        <td>IMAGE</td>
                        <td>image</td>
                        <td>image</td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>button</td>
                                    <td>button</td>
                                </tr>
                                <tr>
                                    <td>button</td>
                                    <td>button</td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="cbSn1" runat="server" Text="Attend career fairs" />
                                        <br />
                                        </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="cbSn2" runat="server" Text="Internships related to major" />
                                        </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="cbSn3" runat="server" Text="Data Analytics for Business" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="cbSn4" runat="server" Text="Apply for career positions" />
                                        <br />
                                        </td>
                                </tr>
                                </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
