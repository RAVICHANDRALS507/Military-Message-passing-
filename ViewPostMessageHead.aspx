﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MCH.Master" AutoEventWireup="true" CodeBehind="ViewPostMessageHead.aspx.cs" Inherits="MilitaryMessage.ViewPostMessageHead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="">
        <div class="main-page">
            <div class="forms">
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <%--<div class="form-title">
                        <h4>
                            View Military Senstive Message:</h4>
                    </div>--%>
                    <div class="form-body">
                        <div class="tables">
                            <div class="table-responsive bs-example widget-shadow">
                                <h4>
                                    View Military Message Details</h4>
                                <asp:Table ID="Table1" runat="server" class="table table-bordered">
                                </asp:Table>
                                <br />
                                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="form-body">
                            
                            <div class="form-group">
                                <label for="exampleInputEmail1">
                                    Sensitive Data</label><asp:TextBox ID="txtDescription" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
