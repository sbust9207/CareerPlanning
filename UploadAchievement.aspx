<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UploadAchievement.aspx.cs" Inherits="CareerPlanning.UploadAchievement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MyContentPlaceHolder" runat="server">

    <div class="container">
        <p>
            Achievement Name:&nbsp;&nbsp;
            <asp:TextBox ID="txtAchievementName" runat="server" MaxLength="30"></asp:TextBox>
        </p>
    </div>
    <div class="container">
        <p>
            Achievement Description:&nbsp;&nbsp;
            <asp:TextBox ID="txtAchievementDescription" runat="server" MaxLength="400" Height="90" Width="180" TextMode="MultiLine"></asp:TextBox>
        </p>
    </div>
    <div class="container">
        <p>Level For Bronze:&nbsp;&nbsp;<asp:TextBox ID="txtBronzeLevel" runat="server" MaxLength="2" Columns="3"></asp:TextBox></p>
        <p>Bronze Achievement Image:&nbsp;&nbsp;<asp:FileUpload ID="bronzeFile" runat="server" /></p>
    </div>
    <div class="container">
        <p>Level For Silver:&nbsp;&nbsp;<asp:TextBox ID="txtSilverLevel" runat="server" MaxLength="2" Columns="3"></asp:TextBox></p>
        <p>Silver Achievement Image:&nbsp;&nbsp;<asp:FileUpload ID="silverFile" runat="server" /></p>
    </div>
    <div class="container">
        <p>Level For Gold:&nbsp;&nbsp;<asp:TextBox ID="txtGoldLevel" runat="server" MaxLength="2" Columns="3"></asp:TextBox></p>
        <p>Gold Achievement Image:&nbsp;&nbsp;<asp:FileUpload ID="goldFile" runat="server" /></p>
    </div>
    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />

</asp:Content>
