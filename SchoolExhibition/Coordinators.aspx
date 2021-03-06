﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Coordinators.aspx.cs" Inherits="SchoolExhibition.Coordinators" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>School Exhibition
       
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Add Coordinator</li>
        </ol>
    </section>
    <div class="col-md-12" style="left: 0px; top: 0px">
        <!-- Horizontal Form -->
        <div class="box box-info">
            <div class="box-header with-border">
                <h3 class="box-title">Add Coordinator</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->

            <div class="box-body">
                <div class="form-group col-md-6">
                    <label class="col-sm-4 control-label" for="inputEmail3">Name <span style="color: red">*</span></label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="name" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorclassName" ValidationGroup="save" ControlToValidate="name" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </div>
              
                
            </div>
            <asp:HiddenField ID="hdnValue" runat="server" />
            <!-- /.box-body -->
            <div class="box-footer">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="save" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnback" runat="server" class="btn btn-danger" Text="Reset" OnClick="btnback_Click" />
            </div>
            <!-- /.box-footer -->
        </div>
        <!-- /.box -->
    </div>
    <div class="box-body">
        <div id="datatable-responsive_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">

            <asp:GridView ID="grd" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" CaptionAlign="Top" AllowPaging="True"
                    EnableSortingAndPagingCallbacks="True" PageSize="5" HorizontalAlign="Left" AllowSorting="True">
                    <AlternatingRowStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                    </Columns>
                    <EditRowStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <EmptyDataRowStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="Black" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SortedAscendingCellStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SortedAscendingHeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SortedDescendingCellStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SortedDescendingHeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView>

        </div>
    </div>
</asp:Content>
