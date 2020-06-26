<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SYSTEM.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb inverse ">
        <li class="active"> Home </li>
        <li></li>
    </ol>
    <style>
        .modal-footer {
        padding: 8px;
        text-align: right;
        border-top: 1px solid #e5e5e5;
        }
        body {
          font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
          font-size: 14px;
          line-height: 1.42857143;
          color: gray;
          background-color: #fff;
        }
     .input-sm
        {
            height: 30px;
            padding: 3px 7px;
            font-size: 12px;
            line-height: 1.5;
            border-radius: 3px;
        }
    </style>
    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">v
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 style="color: #006666;"><span class="glyphicon glyphicon-lock"></span> Sign-In </h4>
                </div>
                <div class="modal-body">
                    <%--<p class="bg-danger">
                        <asp:Label ID="lbMsg" runat="server"></asp:Label>                        
                    </p>
                     <div id="ForgotMsg"></div>--%>
                    <div id="alert_msg"></div>
                    <div class="row">
                        <div class="col-md-3">
                            <img alt="" src="Images/blank.png" width="130px" height="130px" />
                        </div>
                        <div class="col-md-9">
                            <form role="form">
                                <div class="form-group">
                                    <label for="usrname" style="color: #006666;"><span class="glyphicon glyphicon-user "></span>Username</label>
                                    <asp:TextBox ID="txtUserName" runat="server" class="form-control input-sm" placeholder="Enter Username"></asp:TextBox>
                                </div>
                                <div id="Div1"></div>
                                <div class="form-group">
                                    <label for="psw" style="color: #006666;"><span class="glyphicon glyphicon-eye-open"></span> Password</label>
                                    <asp:TextBox ID="txtPassword" runat="server" class="form-control  input-sm" TextMode="Password" placeholder="Enter Password" Text="admin"></asp:TextBox>
                                </div>
                                <div id="Div2"></div>
                                <div class="form-group">                                     
                                    <asp:LinkButton ID="lbtnChange"  runat="server"  OnClick="lbtnChange_Click" Font-Underline="true" >Change Password</asp:LinkButton>
                                    <%--<asp:LinkButton ID="lbtnForgot"  runat="server" OnClick="lbtnForgot_Click" Font-Underline="true" >Forgot Password</asp:LinkButton>--%>
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-info pull-right" OnClick="btnLogin_Click"  OnClientClick=" return validate_login()"/>
                                </div>
                            </form>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <p class="text-muted" align="left" ><h6 align="left" > Designed and Developed By TEAM7. <br /> Copyright (c) 2019 TEAM7. All Rights Reserved. </h6></p> 
                </div>

            </div>
        </div>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="myModalBranch" role="dialog" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-body">
                    <label for="usrname" style="color: #006666;"><span class="glyphicon glyphicon-user"></span>Select Branch</label>
                    <div class="input-group">
                        <asp:DropDownList ID="ddBranch" class="form-control" runat="server"></asp:DropDownList>
                        <span class="input-group-btn">
                            <asp:Button ID="btnOk" runat="server" Text="Ok" class="btn btn-info" OnClick="btnOk_Click" />
                        </span>
                    </div>
                    <!-- /input-group -->
                </div>
            </div>
        </div>
    </div>
    <!-- Change Password -->
    <div class="modal fade" id="myChangePassword" role="dialog" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return Login();">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 style="color: #006666;"><span class="glyphicon glyphicon-lock"></span>Change Password</h4>
                </div>
                <div class="modal-body">
                <p class="bg-danger">
                    <asp:Label ID="lblChange" runat="server"></asp:Label>
                </p>
                <div id="ChangeMsg"></div>
                    <div class="row">                        
                        <div class="col-md-12">                            
                                <div class="form-group">
                                    <label for="usrname" style="color: #006666;"><span class="glyphicon glyphicon-user "></span>Username</label>
                                    <asp:TextBox ID="txtCUserName" runat="server" class="form-control input-sm" placeholder="Enter Username"></asp:TextBox>
                                </div>
                                <div id="ValUserName"></div>
                                <div class="form-group">
                                    <label for="psw" style="color: #006666;"><span class="glyphicon glyphicon-eye-open"></span> Old Password</label>
                                    <asp:TextBox ID="txtCOld" runat="server" class="form-control  input-sm" TextMode="Password" placeholder="Enter Old Password" Text="admin"></asp:TextBox>
                                </div>
                                <div id="ValOld"></div>
                                <div class="form-group">
                                    <label for="psw" style="color: #006666;"><span class="glyphicon glyphicon-eye-open"></span> New Password</label>
                                    <asp:TextBox ID="txtCNew" runat="server" class="form-control  input-sm" TextMode="Password" placeholder="Enter New Password" Text="admin"></asp:TextBox>
                                </div>
                                <div id="ValNew"></div>
                                <div class="form-group">
                                    <label for="psw" style="color: #006666;"><span class="glyphicon glyphicon-eye-open"></span> Re-type NewPassword</label>
                                    <asp:TextBox ID="txtCRetype" runat="server" class="form-control  input-sm" TextMode="Password" placeholder="Re-type New Password" Text="admin"></asp:TextBox>
                                </div>
                                <div id="ValReType"></div>
                                <div class="form-group">                                   
                                     <asp:Button ID="bntCSave" runat="server" Text="Save" class="btn btn-info pull-right" OnClick="bntCSave_Click" OnClientClick=" return validate_Change()"/>                                    
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function Branch() {
            $('#myModalBranch').modal({ show: true })
            $('#myModal').modal({ show: false })
        }
        function Login() {
            $('#myModal').modal({ show: true })
        }
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
        function validate_login() {
            var x = 0;
            if (document.getElementById("<%=txtUserName.ClientID%>").value == "") {
                x = 1;
                $('#Div1').html('<p class="text-danger">This field is required</p>');
                setTimeout(function () {
                    $('#Div1').fadeIn();
                }, 1);
                setTimeout(function () {
                    $('#Div1').fadeOut();
                }, 2000);
            }
            if (document.getElementById("<%=txtPassword.ClientID%>").value == "") {
                x = 1;
                $('#Div2').html('<p class="text-danger">This field is required</p>');
                setTimeout(function () {
                    $('#Div2').fadeIn();
                }, 1);
                setTimeout(function () {
                    $('#Div2').fadeOut();
                }, 2000);
            }
            if (x == 1) {
                return false;
            }
        }
        function validate_Forgot() {
            var x = 0;
            if (document.getElementById("<%=txtUserName.ClientID%>").value == "") {
                $('#ForgotMsg').html('<p class="text-danger">Please enter Username.</p>');
                x = 1;
            }
            else {
                $('#ForgotMsg').html('');
            }

            if (x == 1) {
                return false;
            }
        }
        function validate_Change() {
            var x = 0;

            if (document.getElementById("<%=txtCUserName.ClientID%>").value == "") {
                x = 1;
                $('#ValUserName').html('<p class="text-danger">This field is required</p>');
                setTimeout(function () {
                    $('#ValUserName').fadeIn();
                }, 1);
                setTimeout(function () {
                    $('#ValUserName').fadeOut();
                }, 2000);
            }
            if (document.getElementById("<%=txtCOld.ClientID%>").value == "") {
                x = 1;
                $('#ValOld').html('<p class="text-danger">This field is required</p>');
                setTimeout(function () {
                    $('#ValOld').fadeIn();
                }, 1);
                setTimeout(function () {
                    $('#ValOld').fadeOut();
                }, 2000);
            }
            if (document.getElementById("<%=txtCNew.ClientID%>").value == "") {
                x = 1;
                $('#ValNew').html('<p class="text-danger">This field is required</p>');
                setTimeout(function () {
                    $('#ValNew').fadeIn();
                }, 1);
                setTimeout(function () {
                    $('#ValNew').fadeOut();
                }, 2000);
            }
            if (document.getElementById("<%=txtCRetype.ClientID%>").value == "") {
                x = 1;
                $('#ValReType').html('<p class="text-danger">This field is required</p>');
                setTimeout(function () {
                    $('#ValReType').fadeIn();
                }, 1);
                setTimeout(function () {
                    $('#ValReType').fadeOut();
                }, 2000);
            }
            var np, cp;
            np = (document.getElementById("<%=txtCNew.ClientID%>").value);
            cp = (document.getElementById("<%=txtCRetype.ClientID%>").value);
            if (np !== cp) {
                x = 1;
                $('#ChangeMsg').html('<p class="text-danger">New and Re-Type Passwords do not match.</p>');
                setTimeout(function () {
                    $('#ChangeMsg').fadeIn();
                }, 1);
                setTimeout(function () {
                    $('#ChangeMsg').fadeOut();
                }, 2000);
            }
            var op, np;
            op = (document.getElementById("<%=txtCOld.ClientID%>").value);
            np = (document.getElementById("<%=txtCNew.ClientID%>").value);
            if (op != "" && np != "")
            {
                if (op == np) {
                    x = 1;
                    $('#ChangeMsg').html('<p class="text-danger">Old and New Passwords are the same. Please provide a New Password</p>');
                    setTimeout(function () {
                        $('#ChangeMsg').fadeIn();
                    }, 1);
                    setTimeout(function () {
                        $('#ChangeMsg').fadeOut();
                    }, 2000);
                }
            }
            if (x == 1) {
                return false;
            }
        }
    </script>
</asp:Content>

