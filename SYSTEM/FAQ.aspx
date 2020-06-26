<%@ Page Title="FAQ" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="SYSTEM.WebForm2" %>

<%@ MasterType VirtualPath="~/MyMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ol class="breadcrumb inverse ">
        <li class="active">Help</li>
        <li class="active">FAQ</li>

        <li></li>
    </ol>
    <h4>Frequently Asked Questions</h4>
    <div style="width: 85%; text-align: justify; float: left;">

        <p>
            <asp:Label ID="lblFAQ" runat="server" Text=""></asp:Label>
        </p>
    </div>

    <div style="text-align: right">
        <img src="images/faq-ST.jpg" alt="Sample Photo" style="width: 15%; height: 35%" />
    </div>

    <div class="panel-group" id="accordion">
        <div id="DivAccordion">
        </div>
    </div>

</asp:Content>
