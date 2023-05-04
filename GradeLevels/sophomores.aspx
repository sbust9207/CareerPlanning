<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="sophomores.aspx.cs" Inherits="CareerPlanning.GradeLevels.sophomore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">
    
    <br />

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
                <h1>Quick Links</h1>
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
                <h1 align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To do:</h1>
                <div class="row row-cols-1">
                    <div class="col" align="left"><asp:CheckBox ID="cbSo1" runat="server" Text="&nbsp;Job Shadowing" /></div>
                    <div class="col" align="left"><asp:CheckBox ID="cbSo2" runat="server" Text="&nbsp;Develop Elevator Pitch" /></div>
                    <div class="col" align="left"><asp:CheckBox ID="cbSo3" runat="server" Text="&nbsp;Develop Brand Statement" /></div>
                    <div class="col" align="left"><asp:CheckBox ID="cbSo04" runat="server" Text="&nbsp;Excel Tips" /></div>
                </div>
            </div>
        </div>
      </div>


</asp:Content>
