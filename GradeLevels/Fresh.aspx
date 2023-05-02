<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Fresh.aspx.cs" Inherits="CareerPlanning.GradeLevels.Fresh" %>
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
                                    <td style="height: 100px; width: 49px;"><a href="https://www.linkedin.com" target="_blank"><img src="../images/linkedin.jpg" style="width: 62px; height: 59px; margin-right: 0px" /></a></td>
                                    <td style="height: 100px; width: 50px;">button</td>
                                </tr>
                                <tr>
                                    <td style="height: 100px; width: 49px;">button</td>
                                    <td style="height: 100px; width: 50px;">button</td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="cbFr1" runat="server" Text="Set up account on Handshake" />
                                        </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="cbFr2" runat="server" Text="Set-up a LinkedIn profile" />
                                        <br />
                                        </td>
                                </tr>
                                <tr>
                                    <td style="height: 24px">
                                        <asp:CheckBox ID="cbFr3" runat="server" Text="Create a resume" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="cdFr4" runat="server" Text="Business Etiquette Activities" />
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
