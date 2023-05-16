﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="sophomores.aspx.cs" Inherits="CareerPlanning.GradeLevels.sophomore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">
    
    <br />

    <h1 align="center">Sophomore Dashboard</h1>

    <div style="text-align: center">
    <asp:ListView ID="lstAchievements" runat="server" OnItemDataBound="lstAchievements_ItemDataBound" OnPagePropertiesChanging="lstAchievements_PagePropertiesChanging">
            <LayoutTemplate>
                <div style="display: flex; justify-content: center; align-items: center;">
                    <ul class="list-group list-group-horizontal">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </ul>
                </div>
                <asp:DataPager ID="pgrAchievements" runat="server" PagedControlID="lstAchievements" PageSize="4">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowNextPageButton="false" ShowPreviousPageButton="true" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <li class="list-group-item">
                    <div class="img-wrapper">
                        <div ID="achieveLockedOverlay" class="img-overlay" runat="server" visible="false"></div>
                        <div class="img-child">
                            <asp:HyperLink ID="achievementLink" runat="server">
                                <asp:Image ID="medalToDisplay" runat="server"  Width="150" Height="150" />
                            </asp:HyperLink>
                        </div>
                    </div>

                </li>
            </ItemTemplate>
        </asp:ListView>
        </div>
    
    <br />

    <div class="container text-center">
        <div class="row">
            <div class="col-md-5">
                <h2 align="right">Quick Links:&nbsp;&nbsp;&nbsp;</h2>
                <div class="row">
                    <div class="col-12" align="right"><a href="https://www.linkedin.com" target="_blank"><img src="../images/linkedin.jpg" style="width: 62px; height: 59px; margin-right: 0px" /></a>&nbsp;<a href="https://app.joinhandshake.com/stu" target="_blank"><img src="../images/handshakelogo.jpg" style="width: 62px; height: 59px; margin-right: 0px" /></a></div>
                </div>
                <div class="row">
                    <div class="col-12" align="right"><a href="https://signin.blackboard.com" target="_blank"><img src="../images/blackboardlogo.jpg" style="width: 62px; height: 59px; margin-right: 0px" /></a>&nbsp;<a href="https://elmhurst.guide.eab.com/app/" target="_blank"><img src="../images/Navigate.jpg" style="width: 62px; height: 59px; margin-right: 0px" /></a></div>
                </div>
            </div>
            <div class="col-md-2"></div>
            <div class="col-md-5">
                <div class="row">
                    <div class="col-12"><h2 align="left">&nbsp;&nbsp;&nbsp;&nbsp;To do:</h2></div>
                </div>
                <div class="row">
                    <div class="col-12" align="left"><asp:CheckBox ID="cbSo1" runat="server" Text="&nbsp;Job Shadowing" OnCheckedChanged="cbSo1_CheckedChanged" /></div>
                </div>
                <div class="row">
                     <div class="col-12" align="left"><asp:CheckBox ID="cbSo2" runat="server" Text="&nbsp;Develop Elevator Pitch" OnCheckedChanged="cbSo2_CheckedChanged" /></div>
                </div>
                <div class="row">
                    <div class="col-12" align="left"><asp:CheckBox ID="cbSo3" runat="server" Text="&nbsp;Develop Brand Statement" OnCheckedChanged="cbSo3_CheckedChanged" /></div>
                </div>
                <div class="row">
                    <div class="col-12" align="left"><asp:CheckBox ID="cbSo4" runat="server" Text="&nbsp;Excel Tips" OnCheckedChanged="cbSo4_CheckedChanged" /></div>
                </div>
            </div>
        </div>
    </div>

    <p align="center">Need to update grade level?
        <asp:DropDownList ID="ddGradeLevel2" runat="server" OnSelectedIndexChanged="ddGradeLevel2_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem>Fr</asp:ListItem>
                    <asp:ListItem>So</asp:ListItem>
                    <asp:ListItem>Jr</asp:ListItem>
                    <asp:ListItem>Sn</asp:ListItem>
                </asp:DropDownList>
    </p>


</asp:Content>
