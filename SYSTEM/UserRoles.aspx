<%@ Page Title="User Roles" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="UserRoles.aspx.cs" Inherits="SYSTEM.UserRoles" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/MyMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ol class="breadcrumb">
        <li class="active">File Maintenance</li>
        <li class="active">User Role</li>
    </ol>

    <div id="alert_msg"></div>

    <div class="row">

        <div class="col-lg-6">
            <button type="button" id="Button2" class="btn btn-info btn-sm" data-toggle="modal" data-target="#myModalNew" title="Create new User Role">
                New
            </button>
            <asp:Button ID="Button6" class="btn btn-info btn-sm" runat="server" Text="Refresh" OnClick="LOAD_LIST" ToolTip="Reload List" />
            <asp:Button ID="Button8" class="btn btn-info btn-sm" runat="server" Text="View All" OnClick="LOAD_LIST_ALL" ToolTip="View all records" Visible="false"/>
            <asp:Button ID="btnExport" class="btn btn-info btn-sm" runat="server" Text="Export" OnClick="btnExport_Click" ToolTip="Export to excel" />

        </div>

        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="txtSearch" runat="server" class="form-control form-control input-sm" placeholder="Search for..." OnTextChanged="txtSearch_TextChanged" AutoPostBack="True"></asp:TextBox>
                <span class="input-group-btn">
                    <button id="tbnFind" title="Search" type="button" class="btn btn-info btn-sm custom" runat="server" onserverclick="btnSearch_Click"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                </span>
            </div>
        </div>

    </div>

    <asp:GridView ID="gvList" runat="server" Font-Size="12px" CssClass="table table-striped pagination-ys" AutoGenerateColumns="False" GridLines="Horizontal" Width="100%" OnRowCommand="gvList_RowCommand" OnPageIndexChanging="gvList_PageIndexChanging" PageSize="12" AllowPaging="True" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found">
         <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" Width="15px" ImageUrl="~/Images/edit-icon.png" runat="server"
                                    CommandArgument='<%# Eval("UserRoleID")%>' CommandName="toUpdate" ToolTip="Edit User Role" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
                <FooterStyle Width="10%" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="10px"></HeaderStyle>
            </asp:TemplateField>

            <asp:BoundField DataField="userrole" HeaderText="Description" />
            <asp:BoundField DataField="isactive" HeaderText="Active"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"/>

        </Columns>
        <HeaderStyle BackColor="WhiteSmoke" />
    </asp:GridView>

    <asp:GridView ID="gvExport" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="userrole" HeaderText="Description" />
            <%--<asp:BoundField DataField="isactive" HeaderText="Active" />--%>
        </Columns>
    </asp:GridView>

    <span class="label label-danger">Total Record : 
                <asp:Label ID="lblRec" runat="server" Text="Label"></asp:Label></span>

    <div class="modal fade" id="myModalNew" role="dialog" aria-labelledby="myModalLabel" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    New User Role
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>
                            Description</label>
                        <asp:TextBox ID="txtDescription" runat="server" class="form-control input-sm"></asp:TextBox>
                        <div id="ConfirmDesc"></div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSave" ToolTip="Save" runat="server" Text="Save" class="btn btn-info btn-sm" OnClick="btnSave_Click" OnClientClick=" return validate_new()" />
                    <button type="button" title="Close current view" class="btn btn-info  btn-sm" data-dismiss="modal">
                        Close
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModalView" role="dialog" aria-labelledby="myModalLabel" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    Update User Role
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:HiddenField ID="txtId" runat="server" />
                        <asp:HiddenField ID="txtisActive" runat="server" />
                        <label>
                            Description</label>
                        <asp:TextBox ID="txtDescription_" runat="server" class="form-control input-sm"></asp:TextBox>
                        <div id="_ConfirmDesc"></div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnUpdate" ToolTip="Save" runat="server" Text="Save" class="btn btn-info  btn-sm" OnClick="btnEdit_Click" OnClientClick=" return validate_update()" />
                    <button type="button" title="Delete record" id="Button1" class="btn btn-danger  btn-sm" data-toggle="modal" data-target="#ConfirmDelete">
                        Delete
                    </button>
                    <button type="button" title="Close current view" class="btn btn-info  btn-sm" data-dismiss="modal">
                        Close
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ConfirmDelete" role="dialog" aria-labelledby="myModalLabel" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <span class="glyphicon glyphicon-question-sign"></span>Are you sure you want to
                        delete this record ?
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button5" ToolTip="Click to confirm" runat="server" Text="Yes" class="btn btn-default btn-sm" OnClick="Delete" />
                    <button type="button" title="Close" class="btn btn-default btn-sm" data-dismiss="modal">
                        No</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="Div2" role="dialog" aria-labelledby="myModalLabel" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <span class="glyphicon glyphicon-alert"></span>
                    <asp:Label ID="Label1" runat="server" Text="Saving...Please wait..."></asp:Label>                    
                </div>               
            </div>
        </div>
    </div>

    <script type="text/jscript">

        document.onkeydown = function (e) {
            if (e.keyCode === 116) {
                return false;
            }
        };

        function success(msg) {

            var str1 = '<div class="alert alert-success fade in"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button><span>';
            var str2 = msg;
            var str3 = '</span></div>';
            var str4 = str1.concat(str2).concat(str3)

            $('#alert_msg').html(str4);

            setTimeout(function () {
                $('#alert_msg').fadeOut();
            }, 2000);
        }

        function err(msg) {

            var str1 = '<div class="alert alert-danger fade in"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button><span>';
            var str2 = msg;
            var str3 = '</span></div>';
            var str4 = str1.concat(str2).concat(str3)

            $('#alert_msg').html(str4);

            setTimeout(function () {
                $('#alert_msg').fadeOut();
            }, 4000);
        }

        function New() {
            $('#myModalNew').modal({ show: true })
        }

        function Update() {
            $('#myModalView').modal({ show: true })
        }

        function validate_new() {
            $('#ConfirmDesc').html('');

            if (document.getElementById("<%=txtDescription.ClientID%>").value == "") {
                $('#ConfirmDesc').html('<p class="text-danger">This field is required</p>');
                return false;
            } else {
                $('#Div2').modal({ show: true })
            }
        }

        function validate_update() {
            $('#_ConfirmDesc').html('');

            if (document.getElementById("<%=txtDescription_.ClientID%>").value == "") {
                $('#_ConfirmDesc').html('<p class="text-danger">This field is required</p>');
                return false;
            } else {
                $('#Div2').modal({ show: true })
            }
        }

        function UserCheck()
        {
            $('#ConfirmDesc').html('<p class="text-danger">Record Existing</p>');
        }

        
    </script>

</asp:Content>
