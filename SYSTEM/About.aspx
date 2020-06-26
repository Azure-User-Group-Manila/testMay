<%@ Page Title="About" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SYSTEM.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <ol class="breadcrumb">
        <li class="active">Help</li>
        <li class="active">About the System</li>
    </ol>

    <div id="alert_msg"></div>

    <%--  --%>
        <h4>SMART CITY TRANSPORT</h4>
        <p>Version 1.0</p>
        <p><asp:Label ID="Label1" runat="server" Text="Label" ></asp:Label></p>
        <p><asp:Label ID="Label2" runat="server" Text="Label" ></asp:Label></p>
        
         <div class="modal-footer">
            <p class="text-muted" align="left" ><h6 align="left" > Design and Author By TEAM7 <br /> Copyright @ TEAM7 2019</h6> </p> 
         </div>
         
</asp:Content>
