<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Juniors.aspx.cs" Inherits="CareerPlanning.GradeLevels.Junior" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

        <br />

    <h1 align="center">Junior Dashboard</h1>

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

      <div class="row">
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
                    <div class="col" align="left"><asp:CheckBox ID="cbJn1" runat="server" Text="&nbsp;Mock and Informational Interviews" /></div>
                    <div class="col" align="left"><asp:CheckBox ID="cbJn2" runat="server" Text="&nbsp;Client Business Projects" /></div>
                    <div class="col" align="left"><asp:CheckBox ID="cbJn3" runat="server" Text="&nbsp;Develop job search goals" /></div>
                    <div class="col" align="left"><asp:CheckBox ID="cbJn4" runat="server" Text="&nbsp;Develop networking strategy" /></div>
                </div>
            </div>
        </div>
      </div>

    <p align="center">Need to update grade level?
        <asp:DropDownList ID="ddGradeLevel3" runat="server" OnSelectedIndexChanged="ddGradeLevel3_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem>Fr</asp:ListItem>
                    <asp:ListItem>So</asp:ListItem>
                    <asp:ListItem>Jr</asp:ListItem>
                    <asp:ListItem>Sn</asp:ListItem>
                </asp:DropDownList>
    </p>

</asp:Content>
