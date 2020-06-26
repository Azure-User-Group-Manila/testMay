<%@ Page Title="Homepage" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SYSTEM.Home" %>

<%@ MasterType VirtualPath="~/MyMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <style>
        /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
        #map {
            height: 500px;
        }
        /* Optional: Makes the sample page fill the window. */
    </style>

    <ol class="breadcrumb inverse ">
        <li class="active"><i class="fa fa-home fa-1x"></i>Dash Board</li>
    </ol>

    <div class="row">
        <div id="map"></div>

        <div class="col-lg-10 col-md-6">
            <div class="hidden">
                <div class="bg col-lg-6 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Stations By Country
                         <span class="label label-success">
                             <asp:Label ID="lblC1Total" runat="server"></asp:Label></span>
                                <span class="label label-primary pull-right">
                                    <a href="#" data-toggle="modal" data-target="#ModByLocation"><span style="color: white"><u>View For Allocation</u></span></a>
                                </span>
                            </h3>
                        </div>

                        <div class="panel-body ">
                            <asp:Chart ID="Chart1" runat="server" Height="180px">
                                <Series>
                                    <asp:Series Name="Series1" YValuesPerPoint="2" ChartType="Pie" IsValueShownAsLabel="true"></asp:Series>
                                </Series>
                                <ChartAreas>

                                    <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true"></asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend IsTextAutoFit="True"
                                        DockedToChartArea="ChartArea1"
                                        Docking="Bottom"
                                        IsDockedInsideChartArea="False"
                                        Name="Default" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center" />
                                </Legends>
                            </asp:Chart>

                        </div>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Station Orders By Region
                            <span class="label label-success">
                                <asp:Label ID="lblC2Total" runat="server"></asp:Label></span>
                            </h3>
                        </div>

                        <div class="panel-body">

                            <asp:Chart ID="Chart2" runat="server" Height="180px">
                                <Series>
                                    <asp:Series Name="Series1" YValuesPerPoint="2" ChartType="Pie" IsValueShownAsLabel="true"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true"></asp:ChartArea>
                                </ChartAreas>

                                <Legends>
                                    <asp:Legend IsTextAutoFit="True"
                                        DockedToChartArea="ChartArea1"
                                        Docking="Bottom"
                                        IsDockedInsideChartArea="False"
                                        Name="Default" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center" />
                                </Legends>
                            </asp:Chart>

                        </div>
                    </div>
                </div>

                <div class="bg col-lg-6 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Stations By Province
                            <span class="label label-primary pull-right">
                                <a href="#" data-toggle="modal" data-target="#modCritical"><span style="color: white"><u>View Critical</u></span></a> &nbsp;&nbsp
                                <a href="#" data-toggle="modal" data-target="#modOverstocked"><span style="color: white"><u>View Overstocked</u></span></a>
                            </span>
                            </h3>
                        </div>

                        <div class="panel-body ">
                            <asp:Chart ID="Chart3" runat="server" Height="180px">
                                <Series>
                                    <asp:Series Name="Series1" YValuesPerPoint="2" ChartType="Pie" IsValueShownAsLabel="true"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true"></asp:ChartArea>
                                </ChartAreas>
                                <Legends>

                                    <asp:Legend IsTextAutoFit="True"
                                        DockedToChartArea="ChartArea1"
                                        Docking="Bottom"
                                        IsDockedInsideChartArea="False"
                                        Name="Default" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center" />
                                </Legends>
                            </asp:Chart>

                        </div>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Stations vs. Station Stores
                            <span class="label label-primary pull-right">
                                <a href="#" data-toggle="modal" data-target="#modView"><span style="color: white"><u>View Details</u></span></a>
                            </span>
                            </h3>
                        </div>
                        <div class="panel-body">
                            <asp:Chart ID="Chart4" runat="server" Height="180px">
                                <Series>
                                    <asp:Series Name="Budget" YValuesPerPoint="2"></asp:Series>
                                    <asp:Series Name="Actual" YValuesPerPoint="2" ChartArea="ChartArea1"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend IsTextAutoFit="True"
                                        DockedToChartArea="ChartArea1"
                                        Docking="Bottom"
                                        IsDockedInsideChartArea="False"
                                        Name="Default" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center" />
                                </Legends>
                            </asp:Chart>
                        </div>

                    </div>
                </div>
            </div>



        </div>

        <div class="col-lg-2 col-md-6 hidden">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-folder-open-o fa-3x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label ID="lblOpenPo" runat="server"></asp:Label>
                            </div>
                            <div>Open PO</div>
                        </div>
                    </div>
                </div>
                <a href="PO.aspx">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-envelope-o fa-3x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label ID="lblPOReceiving" runat="server"></asp:Label>
                            </div>
                            <div>For RRPO Approval</div>
                        </div>
                    </div>
                </div>
                <a href="POReceived.aspx">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
            <div class="panel panel-warning">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-thumbs-o-up fa-3x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label ID="lblFATMApproval" runat="server"></asp:Label>
                            </div>
                            <div>FATM Approval</div>
                        </div>
                    </div>
                </div>
                <a href="FATM.aspx">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
            <div class="panel panel-danger">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-truck fa-3x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label ID="lblInTransit" runat="server"></asp:Label>
                            </div>
                            <div>In Transit Delivery</div>
                        </div>
                    </div>
                </div>
                <a href="RrAftm.aspx">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modView" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    Details - Budget vs. Actual by Department
                    &nbsp;&nbsp;
                    <asp:Button ID="btnBudgetExport" class="btn btn-info btn-sm" runat="server" Text="Export" OnClick="btnBudgetExport_Click" />


                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                </div>
                <div class="modal-body">

                    <asp:GridView ID="grdView" runat="server" CssClass="table table-striped pagination-ys"
                        GridLines="Horizontal" Width="100%" AutoGenerateColumns="False"
                        PageSize="10" AllowPaging="True" OnPageIndexChanging="grdView_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Budget" HeaderText="Budget" DataFormatString="{0:#,##0.00}" />
                            <asp:BoundField DataField="Actual" HeaderText="Actual" DataFormatString="{0:#,##0.00}" />
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="gvBudgetExport" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Budget" HeaderText="Budget" DataFormatString="{0:#,##0.00}" />
                            <asp:BoundField DataField="Actual" HeaderText="Actual" DataFormatString="{0:#,##0.00}" />
                        </Columns>
                    </asp:GridView>

                </div>

            </div>
        </div>
    </div>

    <div class="modal fade" id="ModByLocation" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    Details - Assets For Allocation

                    &nbsp;&nbsp;
                    <asp:Button ID="bntForAllocationExport" class="btn btn-info btn-sm" runat="server" Text="Export" OnClick="bntForAllocationExport_Click" />

                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                </div>
                <div class="modal-body">

                    <asp:GridView ID="grdByLocation" runat="server" CssClass="table table-striped pagination-ys"
                        GridLines="Horizontal" Width="100%" AutoGenerateColumns="False"
                        PageSize="10" AllowPaging="True" OnPageIndexChanging="grdByLocation_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Items" />
                            <asp:BoundField DataField="brch_name" HeaderText="Branch" />
                            <asp:BoundField DataField="CNT" HeaderText="Stock" DataFormatString="{0:#,##0}" />
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="grdByLocationExport" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Items" />
                            <asp:BoundField DataField="brch_name" HeaderText="Branch" />
                            <asp:BoundField DataField="CNT" HeaderText="Stock" DataFormatString="{0:#,##0}" />
                        </Columns>
                    </asp:GridView>

                    <span class="label label-danger">Item Count : 
                    <asp:Label ID="lblByLocation" runat="server" Text="Label"></asp:Label></span>

                    <span class="label label-danger">Stock Total : 
                    <asp:Label ID="lblStockSummary" runat="server" Text="Label"></asp:Label></span>

                </div>

            </div>
        </div>
    </div>

    <div class="modal fade" id="modCritical" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    Details - Stock Level (Critical)

                    &nbsp;&nbsp;
                    <asp:Button ID="bntCriticalExport" class="btn btn-info btn-sm" runat="server" Text="Export" OnClick="bntCriticalExport_Click" />

                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                </div>
                <div class="modal-body">

                    <asp:GridView ID="grdCritical" runat="server" CssClass="table table-striped pagination-ys"
                        GridLines="Horizontal" Width="100%" AutoGenerateColumns="False"
                        PageSize="10" AllowPaging="True" OnPageIndexChanging="grdCritical_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Name" />
                            <asp:BoundField DataField="Minimum" HeaderText="Minimum" DataFormatString="{0:#,##0}" />
                            <asp:BoundField DataField="Maximum" HeaderText="Maximum" DataFormatString="{0:#,##0}" />
                            <asp:BoundField DataField="STOCK_CARD" HeaderText="Stock" />
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="grdCriticalExport" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Name" />
                            <asp:BoundField DataField="Minimum" HeaderText="Minimum" DataFormatString="{0:#,##0}" />
                            <asp:BoundField DataField="Maximum" HeaderText="Maximum" DataFormatString="{0:#,##0}" />
                            <asp:BoundField DataField="STOCK_CARD" HeaderText="Stock" />
                        </Columns>
                    </asp:GridView>

                    <span class="label label-danger">Total Record : 
                     <asp:Label ID="lblCritical" runat="server" Text="Label"></asp:Label></span>
                </div>

            </div>
        </div>
    </div>

    <div class="modal fade" id="modOverstocked" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    Details - Stock Level (Overstocked)

                     &nbsp;&nbsp;
                    <asp:Button ID="bntOverstockedExport" class="btn btn-info btn-sm" runat="server" Text="Export" OnClick="bntOverstockedExport_Click" />


                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                </div>
                <div class="modal-body">

                    <asp:GridView ID="grdOverstocked" runat="server" CssClass="table table-striped pagination-ys"
                        GridLines="Horizontal" Width="100%" AutoGenerateColumns="False"
                        PageSize="10" AllowPaging="True" OnPageIndexChanging="grdOverstocked_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Name" />
                            <asp:BoundField DataField="Minimum" HeaderText="Minimum" DataFormatString="{0:#,##0}" />
                            <asp:BoundField DataField="Maximum" HeaderText="Maximum" DataFormatString="{0:#,##0}" />
                            <asp:BoundField DataField="STOCK_CARD" HeaderText="Stock" />
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="grdOverstockedExport" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Name" />
                            <asp:BoundField DataField="Minimum" HeaderText="Minimum" DataFormatString="{0:#,##0}" />
                            <asp:BoundField DataField="Maximum" HeaderText="Maximum" DataFormatString="{0:#,##0}" />
                            <asp:BoundField DataField="STOCK_CARD" HeaderText="Stock" />
                        </Columns>
                    </asp:GridView>

                    <span class="label label-danger">Total Record : 
                    <asp:Label ID="lblOverstocked" runat="server" Text="Label"></asp:Label></span>
                </div>

            </div>
        </div>
    </div>


    <script>
        function initMap() {
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 3,
                center: { lat: 0, lng: -180 },
                mapTypeId: 'terrain'
            });

            var flightPlanCoordinates = [
                { lat: 37.772, lng: -122.214 },
                { lat: 21.291, lng: -157.821 },
                { lat: -18.142, lng: 178.431 },
                { lat: -27.467, lng: 153.027 }
            ];
            var flightPath = new google.maps.Polyline({
                path: flightPlanCoordinates,
                geodesic: true,
                strokeColor: '#FF0000',
                strokeOpacity: 1.0,
                strokeWeight: 2
            });

            flightPath.setMap(map);
        }
    </script>
    <script async defer
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAxlA--EmKMuuDYA7MVpCCcnkK3ZBGukw8&callback=initMap">
    </script>

    <script type="text/jscript">
        function ViewCritical() {
            $('#modCritical').modal({ show: true })
        }

        function ViewOverStocked() {
            $('#modOverstocked').modal({ show: true })
        }

        function ViewBudget() {
            $('#modView').modal({ show: true })
        }

        function ViewByLocation() {
            $('#ModByLocation').modal({ show: true })
        }

    </script>

</asp:Content>
