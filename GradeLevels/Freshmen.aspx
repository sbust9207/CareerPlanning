<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Freshmen.aspx.cs" Inherits="CareerPlanning.GradeLevels.Freshman" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

    <br />

    <h1 align="center">Freshman Dashboard</h1>

    <div class="container text-center" >
      <div class="row">
        <div class="col">ACHIEVEMENT</div>
        <div class="col">ACHIEVEMENT</div>
        <div class="col">ACHIEVEMENT</div>
        <div class="col">ACHIEVEMENT</div>
        <div class="col">ACHIEVEMENT</div>
      </div> 
    </div>
    
    <br />

      <div class="row" align="center">
        <div class="col-6">
            <div class="container text-center">
                <h2>Quick Links</h2>
                <div class="row row-cols-2">
                    <div class="col" align="right"><a href="https://www.linkedin.com" target="_blank"><img src="../images/linkedin.jpg" style="width: 62px; height: 59px; margin-right: 0px" /></a></div>
                    <div class="col" align="left"><a href="https://app.joinhandshake.com/stu" target="_blank"><img src="../images/handshakelogo.jpg" style="width: 62px; height: 59px; margin-right: 0px" /></a></div>
                    <div class="col" align="right"><a href="https://signin.blackboard.com" target="_blank"><img src="../images/blackboardlogo.jpg" style="width: 62px; height: 59px; margin-right: 0px" /></a></div>
                    <div class="col" align="left"><a href="https://elmhurst.guide.eab.com/app/" target="_blank"><img src="../images/Navigate.jpg" style="width: 62px; height: 59px; margin-right: 0px" /></a></div>
                </div>
            </div>
        </div>
        <div class="col-6">
            <div class="container text-center">
                <h2 align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To do:</h2>
                <div class="row row-cols-1">
                    <div class="col" align="left"><asp:CheckBox ID="cbFr1" runat="server" Text="&nbsp;Set up account on Handshake" /></div>
                    <div class="col" align="left"><asp:CheckBox ID="cbFr2" runat="server" Text="&nbsp;Set-up a LinkedIn profile" /></div>
                    <div class="col" align="left"><asp:CheckBox ID="cbFr3" runat="server" Text="&nbsp;Create a resume" /></div>
                    <div class="col" align="left"><asp:CheckBox ID="cdFr4" runat="server" Text="&nbsp;Business Etiquette Activities" /></div>
                </div>
            </div>
        </div>
      </div>

    <p align="center">Need to update grade level?
        <asp:DropDownList ID="ddGradeLevel" runat="server" OnSelectedIndexChanged="ddGradeLevel_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem>Fr</asp:ListItem>
                    <asp:ListItem>So</asp:ListItem>
                    <asp:ListItem>Jr</asp:ListItem>
                    <asp:ListItem>Sn</asp:ListItem>
                </asp:DropDownList>
    </p>
     
</asp:Content>
