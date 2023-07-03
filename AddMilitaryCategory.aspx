<%@ Page Title="" Language="C#" MasterPageFile="~/MH.Master" AutoEventWireup="true" CodeBehind="AddMilitaryCategory.aspx.cs" Inherits="MilitaryMessage.AddMilitaryCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="">
        <div class="main-page">
            <div class="forms">
               
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                          Military Category Details:</h4>
                    </div>
                   <div class="form-body">
                      
                       
                        <div class="form-group">
                            <label for="exampleInputEmail1">
                               Enter Military Category Name</label><asp:TextBox ID="txtMCName" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="Enter Military Category Name" ControlToValidate="txtMCName" ForeColor="Red" 
                                ValidationGroup="A"></asp:RequiredFieldValidator>
                        </div>
                         <div class="form-group">
                            <label for="exampleInputEmail1">
                               Enter Description</label><asp:TextBox ID="txtDescription" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="Enter Description" ControlToValidate="txtDescription" ForeColor="Red" 
                                ValidationGroup="A"></asp:RequiredFieldValidator>
                        </div>
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnSave" runat="server" class="btn btn-primary pull-right" Text="Save" 
                            onclick="btnSave_Click" ValidationGroup="A" />
                        
                    </div>
                </div>
          </div>
          </div>     
    </div>
</asp:Content>
