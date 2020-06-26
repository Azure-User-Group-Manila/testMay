<%@ Page Title="Users" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="SYSTEM.Users" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/MyMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:HiddenField ID="hdsystem_id" runat="server" />
<asp:HiddenField ID="hdfirst_name" runat="server" />
<asp:HiddenField ID="hdmi_name" runat="server" />
<asp:HiddenField ID="hdlast_name" runat="server" />
<asp:HiddenField ID="hdsuffix_name" runat="server" />
<asp:HiddenField ID="hdemail" runat="server" />
<asp:HiddenField ID="hddomain_id" runat="server" />
<asp:HiddenField ID="txtID" runat="server" />
<asp:HiddenField ID="txtIsActive" runat="server" />
<asp:HiddenField ID="hdEmpOrNot" runat="server" />
    <ol class="breadcrumb">
        <li class="active">File Maintenance</li>
        <li class="active">Users</li>
    </ol>

    <div id="alert_msg"></div>

    <div class="row">

        <div class="col-lg-6">
            <button type="button" id="Button2" class="btn btn-info btn-sm" data-toggle="modal" data-target="#ModalEmployeeOrNot">New</button>
            <asp:Button ID="Button6" class="btn btn-info btn-sm" runat="server" Text="Refresh" OnClick="LOAD_LIST" />
            <asp:Button ID="Button8" class="btn btn-info btn-sm" runat="server" Text="View All" OnClick="LOAD_LIST_ALL" Visible="false"/>
            <asp:Button ID="btnExport" class="btn btn-info btn-sm" runat="server" Text="Export" OnClick="btnExport_Click" />
        </div>

        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="txtSearch" runat="server" class="form-control form-control input-sm" placeholder="Search for..." onkeypress="return xkeypress(event);"></asp:TextBox>
                <span class="input-group-btn">
                    <button id="btnFind" type="button" class="btn btn-info btn-sm custom" runat="server" onserverclick="btnSearch_Click"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                </span>
            </div>
        </div>

    </div>

    <asp:GridView ID="gvList" runat="server" Font-Size="12px" CssClass="table table-striped pagination-ys" AutoGenerateColumns="False" GridLines="Horizontal" Width="100%" OnRowCommand="gvList_RowCommand" OnPageIndexChanging="gvList_PageIndexChanging" PageSize="12" AllowPaging="True" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found">
         <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" Width="15px" ImageUrl="~/Images/edit-icon.png" runat="server"
                                    CommandArgument='<%# Eval("ID")%>' CommandName="toUpdate" ToolTip="Edit User" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
                <FooterStyle Width="10%" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="10px"></HeaderStyle>
            </asp:TemplateField>

            <asp:BoundField DataField="system_id" HeaderText="System ID" />
            <asp:BoundField DataField="password" HeaderText="Password" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="first_name" HeaderText="First Name" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="mi_name" HeaderText="Middle Name" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="last_name" HeaderText="Last Name" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="suffix_name" HeaderText="Suffix" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="email" HeaderText="E-Mail" />
            <asp:BoundField DataField="employeeid" HeaderText="Employee ID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="domainid" HeaderText="Domain" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="userrole" HeaderText="Role" />
            <asp:BoundField DataField="brch_name" HeaderText="Branch"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"/>
            <asp:BoundField DataField="Dept_Name" HeaderText="Department"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"/>
            <asp:BoundField DataField="isactive" HeaderText="Active"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"/>
            <asp:BoundField DataField="password" HeaderText="Password" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="userroleid" HeaderText="userroleid" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="branchid" HeaderText="branchid" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="departmentid" HeaderText="departmentid" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />

        </Columns>
        <HeaderStyle BackColor="WhiteSmoke" />
    </asp:GridView>

    <asp:GridView ID="gvExport" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="system_id" HeaderText="System ID" />
            <asp:BoundField DataField="password" HeaderText="Password" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="first_name" HeaderText="First Name" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="mi_name" HeaderText="Middle Name" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="last_name" HeaderText="Last Name" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="suffix_name" HeaderText="Suffix" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
            <asp:BoundField DataField="email" HeaderText="E-Mail" />
            <asp:BoundField DataField="employeeid" HeaderText="Employee ID" />
            <asp:BoundField DataField="domainid" HeaderText="Domain" />
            <asp:BoundField DataField="userrole" HeaderText="Role" />
            <asp:BoundField DataField="brch_name" HeaderText="Branch" />
            <asp:BoundField DataField="Dept_Name" HeaderText="Department" />
            <%--  <asp:BoundField DataField="isactive" HeaderText="Active" /> --%>
        </Columns>
    </asp:GridView>

    <span class="label label-danger">Total Record : 
                <asp:Label ID="lbRec" runat="server" Text="Label"></asp:Label></span>

    <div class="modal fade" id="ModalEmployeeOrNot" role="dialog" aria-labelledby="myModalLabel" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    Add New User
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-8">
                        <div class="form-group">
                                <label>Select User Type:</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddUserType" runat="server" class="form-control input-sm select2 ddUserType"></asp:DropDownList>
                                    <div class="input-group-btn">
                                        <button id="Button3" type="button" class="btn btn-info btn-sm btnIcon"><span class="caret"></span></button>
                                    </div>
                                </div>
                                <div id="Div1"></div>
                        </div>
                        </div>
                        <div class="col-md-2"></div>
                    </div>                                          
                </div>                
                <div class="modal-footer">
                    <asp:Button ID="Button4" runat="server" Text="OK" class="btn btn-info btn-sm" OnClientClick=" return NewUser()"/>
                    <button type="button" class="btn btn-info btn-sm" data-dismiss="modal" title="click to cancel">
                        Cancel</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModalNew" role="dialog" aria-labelledby="myModalLabel" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog custom-class" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    Add New User
                </div>
                <div class="modal-body">
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>--%>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group" id="divEmployee">
                                <label>Employee Name</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddListOfEmployee" runat="server" class="form-control input-sm select2 ddListOfEmployee" OnSelectedIndexChanged="ddListOfEmployee_SelectedIndexChanged" OnTextChanged="ddListOfEmployee_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    <div class="input-group-btn">
                                        <button id="btnNewEmployee" type="button" class="btn btn-info btn-sm btnIcon"><span class="caret"></span></button>
                                    </div>
                                </div>
                                <div id="ConfirmEmployee"></div>
                            </div>
                            <br/>
                        </div>
                    </div>                    
                    <div class="row">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:HiddenField ID="hdDuplicate" runat="server" Value="0" />
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>System ID</label>
                                <asp:TextBox ID="txtSysID" runat="server" class="form-control input-sm" OnTextChanged="txtSysID_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <div id="ConfirmSysID"></div>
                            </div>
                        </div>
</ContentTemplate></asp:UpdatePanel>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Password</label>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="ConfirmPassword"></div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Confirm Password</label>
                                <asp:TextBox ID="txtCPassword" TextMode="Password" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="ConfirmRepeatPassword"></div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Domain Id</label>
                                <asp:TextBox ID="txtDomain" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="ConfirmDomain"></div>
                            </div>
                        </div>
                        <br/>
                    </div>
                    <div class="row">
                         <div class="col-md-2">   
                            <div class="form-group">
                                <label>First name</label>
                                <asp:TextBox ID="txtFname" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="ConfirmFirst"></div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Middle name</label>
                                <asp:TextBox ID="txtMname" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="ConfirmMiddle"></div>
                           </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Last name</label>
                                <asp:TextBox ID="txtLname" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="ConfirmLast"></div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Suffix Name</label>
                                <asp:TextBox ID="txtSname" runat="server" class="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>	
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="ConfirmEmail"></div>
                            </div>
                        </div>
                        <br/>					
                    </div>
                    <div class="row">
                         <div class="col-md-3">   
                             <div class="form-group">
                                <label>User Role</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddUserRole" runat="server" class="form-control input-sm select2 ddNewUserRole"></asp:DropDownList>
                                    <div class="input-group-btn">
                                        <button id="btnNewUserRole" type="button" class="btn btn-info btn-sm btnIcon"><span class="caret"></span></button>
                                    </div>
                                </div>
                                <div id="ConfirmUserRole"></div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Branch</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddBranch" runat="server" class="form-control input-sm select2 ddNewBranch"></asp:DropDownList>
                                    <div class="input-group-btn">
                                        <button id="btnNewBranch" type="button" class="btn btn-info btn-sm btnIcon"><span class="caret"></span></button>
                                    </div>
                                </div>
                                <div id="ConfirmBranch"></div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Department</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddDepartment" runat="server" class="form-control input-sm select2 ddNewDepartment"></asp:DropDownList>
                                    <div class="input-group-btn">
                                        <button id="btnNewDepartment" type="button" class="btn btn-info btn-sm btnIcon"><span class="caret"></span></button>
                                    </div>
                                </div>
                                <div id="ConfirmDepartment"></div>
                            </div>
                        </div>
                        <br/>					
                    </div>
                    <%--</ContentTemplate></asp:UpdatePanel>--%>
                    <div class="modal-footer">
                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-info btn-sm" OnClick="SAVE" OnClientClick=" return validate_new()" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-info btn-sm" OnClick="btnCancel_Click" OnClientClick=" return clearfields()"/>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!----------------------------------------------MODAL-FOR-UPDATE----------------------------------------------------------->
    
    <div class="modal fade" id="myModalUpdate" role="dialog" aria-labelledby="myModalLabel" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog custom-class" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    Update User
                </div>
                <div class="modal-body">
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>--%>
                    <div class="row">
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>System ID</label>
                                <asp:TextBox ID="_txtSysID" runat="server" class="form-control input-sm" AutoPostBack="true"></asp:TextBox>
                                <div id="_ConfirmSysID"></div>
                            </div>
                        </div>
</ContentTemplate></asp:UpdatePanel>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Password</label>
                                <asp:TextBox ID="_txtPassword" TextMode="Password" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="_ConfirmPassword"></div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Confirm Password</label>
                                <asp:TextBox ID="_txtCPassword" TextMode="Password" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="_ConfirmCPassword"></div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Domain Id</label>
                                <asp:TextBox ID="_txtDomain" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="Div8"></div>
                            </div>
                        </div>
                        <br/>
                    </div>
                    <div class="row">
                         <div class="col-md-2">   
                            <div class="form-group">
                                <label>First name</label>
                                <asp:TextBox ID="_txtFname" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="_ConfirmFirst"></div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Middle name</label>
                                <asp:TextBox ID="_txtMname" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="_ConfirmMiddle"></div>
                           </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Last name</label>
                                <asp:TextBox ID="_txtLname" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="_ConfirmLast"></div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Suffix Name</label>
                                <asp:TextBox ID="_txtSname" runat="server" class="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>	
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox ID="_txtEmail" runat="server" class="form-control input-sm"></asp:TextBox>
                                <div id="_ConfirmEmail"></div>
                            </div>
                        </div>
                        <br/>					
                    </div>
                    <div class="row">
                         <div class="col-md-3">   
                             <div class="form-group">
                                <label>User Role</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="_ddUserRole" runat="server" class="form-control input-sm select2 ddNewUserRole"></asp:DropDownList>
                                    <div class="input-group-btn">
                                        <button id="Button7" type="button" class="btn btn-info btn-sm btnIcon"><span class="caret"></span></button>
                                    </div>
                                </div>
                                <div id="_ConfirmUserRole"></div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Branch</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="_ddBranch" runat="server" class="form-control input-sm select2 ddNewBranch"></asp:DropDownList>
                                    <div class="input-group-btn">
                                        <button id="Button9" type="button" class="btn btn-info btn-sm btnIcon"><span class="caret"></span></button>
                                    </div>
                                </div>
                                <div id="_ConfirmBranch"></div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Department</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="_ddDepartment" runat="server" class="form-control input-sm select2 ddNewDepartment"></asp:DropDownList>
                                    <div class="input-group-btn">
                                        <button id="Button10" type="button" class="btn btn-info btn-sm btnIcon"><span class="caret"></span></button>
                                    </div>
                                </div>
                                <div id="_ConfirmDepartment"></div>
                            </div>
                        </div>
                        <br/>					
                    </div>
                    <%--</ContentTemplate></asp:UpdatePanel>--%>
                    <div class="modal-footer">
                        <asp:Button ID="Button11" runat="server" Text="Save" class="btn btn-info btn-sm" OnClick="UPDATE" OnClientClick=" return validate_update()" />
                        <button type="button" id="Button1" title="Delete" class="btn btn-danger  btn-sm" data-toggle="modal" data-target="#ConfirmDelete">
                        Delete
                        </button>
                        <asp:Button ID="Button12" runat="server" Text="Cancel" class="btn btn-info btn-sm"/>
                    </div>
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
                    <asp:Button ID="Button5" runat="server" Text="Yes" class="btn btn-default btn-sm" OnClick="DELETE" />
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">
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

        function xkeypress(e) {
            if (e.keyCode == 13) {
                if ($('#<%=txtSearch.ClientID%>').val() != '')
                    $("#<%=btnFind.ClientID%>").click();

                return false;
            }
        }


        $(document).ready(function () {
            $("#btnNewUserRole").click(function () {
                $(".ddNewUserRole").select2("open");
            });
            $("#btnNewBranch").click(function () {
                $(".ddNewBranch").select2("open");
            });
            $("#btnNewDepartment").click(function () {
                $(".ddNewDepartment").select2("open");
            });

            $("#btnEditUserRole").click(function () {
                $(".ddEditUserRole").select2("open");
            });
            $("#btnEditBranch").click(function () {
                $(".ddEditBranch").select2("open");
            });
            $("#btnEditDepartment").click(function () {
                $(".ddEditDepartment").select2("open");
            });
        });

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

        function clearfields() {
            var dd1;
            dd1 = document.getElementById("<%=ddBranch.ClientID%>");
            dd1.options[dd1.selectedIndex].value = 0;
            dd1 = document.getElementById("<%=ddUserRole.ClientID%>");
            dd1.options[dd1.selectedIndex].value = 0;
            dd1 = document.getElementById("<%=ddDepartment.ClientID%>");
            dd1.options[dd1.selectedIndex].value = 0;
            document.getElementById("<%=txtSysID.ClientID%>").value = "";
            document.getElementById("<%=txtFname.ClientID%>").value = "";
            document.getElementById("<%=txtLname.ClientID%>").value = "";
            document.getElementById("<%=txtMname.ClientID%>").value = "";
            document.getElementById("<%=txtSname.ClientID%>").value = "";
            document.getElementById("<%=txtEmail.ClientID%>").value = "";
            document.getElementById("<%=txtDomain.ClientID%>").value = "";
        }

        function ModalEmployeeOrNot() {
            $('#ModalEmployeeOrNot').modal({ show: true })
        }

        function NewUser() {            
            var ut,emp;
            ut = document.getElementById("<%=ddUserType.ClientID%>");
            emp = document.getElementById("<%=ddListOfEmployee.ClientID%>");
            
            if (ut.options[ut.selectedIndex].value == "0") {
                document.getElementById("divEmployee").style.display = 'block';
                //document.getElementById("<%=txtSysID.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=txtFname.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=txtLname.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=txtMname.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=txtSname.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=txtEmail.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=ddBranch.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=ddDepartment.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=txtDomain.ClientID%>").disabled = !this.checked;
            }
            else {
                document.getElementById("divEmployee").style.display = 'none';
                //document.getElementById("<%=txtSysID.ClientID%>").disabled = false;
                document.getElementById("<%=txtFname.ClientID%>").disabled = false;
                document.getElementById("<%=txtLname.ClientID%>").disabled = false;
                document.getElementById("<%=txtMname.ClientID%>").disabled = false;
                document.getElementById("<%=txtSname.ClientID%>").disabled = false;
                document.getElementById("<%=txtEmail.ClientID%>").disabled = false;
                document.getElementById("<%=ddBranch.ClientID%>").disabled = false;
                document.getElementById("<%=ddDepartment.ClientID%>").disabled = false;
                document.getElementById("<%=txtDomain.ClientID%>").disabled = false;
            }

            $('#myModalNew').modal({ show: true })
            return false;
        }

        function Update() {

            emp = document.getElementById("<%=hdEmpOrNot.ClientID%>").value;

            if (emp != "0") {
                document.getElementById("<%=_txtPassword.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=_txtCPassword.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=_txtFname.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=_txtLname.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=_txtMname.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=_txtSname.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=_txtEmail.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=_ddBranch.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=_ddDepartment.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=_txtDomain.ClientID%>").disabled = !this.checked;
            }
            else {
                document.getElementById("<%=_txtPassword.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=_txtCPassword.ClientID%>").disabled = !this.checked;
                document.getElementById("<%=_txtFname.ClientID%>").disabled = false;
                document.getElementById("<%=_txtLname.ClientID%>").disabled = false;
                document.getElementById("<%=_txtMname.ClientID%>").disabled = false;
                document.getElementById("<%=_txtSname.ClientID%>").disabled = false;
                document.getElementById("<%=_txtEmail.ClientID%>").disabled = false;
                document.getElementById("<%=_ddBranch.ClientID%>").disabled = false;
                document.getElementById("<%=_ddDepartment.ClientID%>").disabled = false;
                document.getElementById("<%=_txtDomain.ClientID%>").disabled = false;
            }
            $('#myModalUpdate').modal({ show: true })
        }

        function checkID(){
            if (document.getElementById("<%=hdDuplicate.ClientID%>").value != "0") {
                $('#ConfirmSysID').html('<p class="text-danger">This System ID already exists.</p>');
                return false;
            }
        }

        function validate_new() {

            $('#ConfirmSysID').html('');
            $('#ConfirmPassword').html('');
            $('#ConfirmRepeatPassword').html('');
            $('#ConfirmFirst').html('');
            $('#ConfirmLast').html('');
            $('#ConfirmMiddle').html('');
            $('#ConfirmUserRole').html('');
            $('#ConfirmBranch').html('');
            $('#ConfirmDepartment').html('');
            $('#ConfirmEmployee').html('');
            $('#ConfirmEmail').html('');
            $('#ConfirmSysID').html('');

            var z = 0;

            if (document.getElementById("<%=txtSysID.ClientID%>").value == "") {
                z = 1;
                $('#ConfirmSysID').html('<p class="text-danger">This field is required</p>');
            }
            if (document.getElementById("<%=txtPassword.ClientID%>").value == "") {
                z = 1;
                $('#ConfirmPassword').html('<p class="text-danger">This field is required</p>');
            }
            if (document.getElementById("<%=txtCPassword.ClientID%>").value == "") {
                z = 1;
                $('#ConfirmRepeatPassword').html('<p class="text-danger">This field is required</p>');
            }
            if (document.getElementById("<%=txtFname.ClientID%>").value == "") {
                z = 1;
                $('#ConfirmFirst').html('<p class="text-danger">This field is required</p>');
            }
            if (document.getElementById("<%=txtLname.ClientID%>").value == "") {
                z = 1;
                $('#ConfirmLast').html('<p class="text-danger">This field is required</p>');
            }
            if (document.getElementById("<%=txtMname.ClientID%>").value == "") {
                z = 1;
                $('#ConfirmMiddle').html('<p class="text-danger">This field is required</p>');
            }
            if (document.getElementById("<%=hdDuplicate.ClientID%>").value != "0") {
                z = 1;
                $('#ConfirmSysID').html('<p class="text-danger">This System ID already exists.</p>');
            }

            var ddl;

            ddl = document.getElementById("<%=ddUserRole.ClientID%>");

            if (ddl.options[ddl.selectedIndex].value == "0") {
                z = 1;
                $('#ConfirmUserRole').html('<p class="text-danger">This field is required</p>');
            }

            ddl = document.getElementById("<%=ddBranch.ClientID%>");

            if (ddl.options[ddl.selectedIndex].value == "0") {
                z = 1;
                $('#ConfirmBranch').html('<p class="text-danger">This field is required</p>');
            }

            ddl = document.getElementById("<%=ddDepartment.ClientID%>");

            if (ddl.options[ddl.selectedIndex].value == "0") {
                z = 1;
                $('#ConfirmDepartment').html('<p class="text-danger">This field is required</p>');
            }

            ddl = document.getElementById("<%=ddListOfEmployee.ClientID%>");
            ddl2 = document.getElementById("<%=ddUserType.ClientID%>");

            if (ddl.options[ddl.selectedIndex].value == "0" && ddl2.options[ddl2.selectedIndex].value == "0") {
                z = 1;
                $('#ConfirmEmployee').html('<p class="text-danger">Select an Employee</p>');
            }

            var x = document.getElementById("<%=txtEmail.ClientID%>").value;

            if (x != "") {
                var atpos = x.indexOf("@");
                var dotpos = x.lastIndexOf(".");

                if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
                    z = 1;
                    $('#ConfirmEmail').html('<p class="text-danger">Invalid Email Address</p>');
                }
            }

            var np, cp;
            np = (document.getElementById("<%=txtPassword.ClientID%>").value);
            cp = (document.getElementById("<%=txtCPassword.ClientID%>").value);

            if (np !== cp) {
                z = 1;
                $('#ConfirmRepeatPassword').html('<p class="text-danger">Passwords did not match.</p>');
            }

            if (z == 1) {
                return false;
            } else {
                $('#Div2').modal({ show: true })
            }
        }

        function validate_update() {

            $('#_ConfirmSysID').html('');
            $('#_ConfirmFirst').html('');
            $('#_ConfirmLast').html('');
            $('#_ConfirmMiddle').html('');
            $('#_ConfirmUserRole').html('');
            $('#_ConfirmBranch').html('');
            $('#_ConfirmDepartment').html('');
            $('#_ConfirmEmail').html('');

            var z = 0;
            if (document.getElementById("<%=_txtSysID.ClientID%>").value == "") {
                z = 1;
                $('#_ConfirmSysID').html('<p class="text-danger">This field is required</p>');
            }
            if (document.getElementById("<%=_txtFname.ClientID%>").value == "") {
                z = 1;
                $('#_ConfirmFirst').html('<p class="text-danger">This field is required</p>');
            }
            if (document.getElementById("<%=_txtLname.ClientID%>").value == "") {
                z = 1;
                $('#_ConfirmLast').html('<p class="text-danger">This field is required</p>');
            }
            if (document.getElementById("<%=_txtMname.ClientID%>").value == "") {
                z = 1;
                $('#_ConfirmMiddle').html('<p class="text-danger">This field is required</p>');
            }


            var ddl = document.getElementById("<%=_ddUserRole.ClientID%>");
            if (ddl.options[ddl.selectedIndex].value == "0") {
                $('#_ConfirmUserRole').html('<p class="text-danger">This field is required</p>');
                z = 1;
            }
            else {
                $('#_ConfirmUserRole').html('');

            }

            var ddl = document.getElementById("<%=_ddBranch.ClientID%>");
            if (ddl.options[ddl.selectedIndex].value == "0") {
                $('#_ConfirmBranch').html('<p class="text-danger">This field is required</p>');
                z = 1;
            }
            else {
                $('#_ConfirmBranch').html('');

            }

            var ddl = document.getElementById("<%=_ddDepartment.ClientID%>");
            if (ddl.options[ddl.selectedIndex].value == "0") {
                $('#_ConfirmDepartment').html('<p class="text-danger">This field is required</p>');
                z = 1;
            }
            else {
                $('#_ConfirmDepartment').html('');

            }

            var x = document.getElementById("<%=_txtEmail.ClientID%>").value;

            if (x != "") {
                var atpos = x.indexOf("@");
                var dotpos = x.lastIndexOf(".");

                if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
                    z = 1;
                    $('#_ConfirmEmail').html('<p class="text-danger">Invalid Email Address </p>');
                }

                if (z == 1) {
                    return false;
                } else {
                    $('#Div2').modal({ show: true })
                }
            }

        }

        function numeric_only() {
            return (event.ctrlKey || event.altKey || (47 < event.keyCode && event.keyCode < 58 && event.shiftKey == false) ||
                (95 < event.keyCode && event.keyCode < 106) || (event.keyCode == 8) || (event.keyCode == 9) ||
                (event.keyCode > 34 && event.keyCode < 40));
        }

    </script>

</asp:Content>
