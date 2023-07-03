<%@ Page Title="" Language="C#" MasterPageFile="~/MH.Master" AutoEventWireup="true" CodeBehind="AddMilitarySC.aspx.cs" Inherits="MilitaryMessage.AddMilitarySC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="">
        <div class="main-page">
            <div class="forms">
               
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                           Add Military Sub Category:</h4>
                    </div>
                   <div class="form-body">
                      
                       
                        <div class="form-group">
                            <label for="exampleInputEmail1">
                               Select Military Category</label> <asp:DropDownList ID="ddlMC" runat="server" class="form-control">
                       </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="Select Military Category" ControlToValidate="ddlMC" InitialValue="--Select--" ForeColor="Red" 
                                ValidationGroup="A"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">
                               Enter Military Sub Category Name</label><asp:TextBox ID="txtMSCName" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="Enter Military Sub Category Name" ControlToValidate="txtMSCName" ForeColor="Red" 
                                ValidationGroup="A"></asp:RequiredFieldValidator>
                        </div>
                         <div class="form-group">
                            <label for="exampleInputEmail1">
                               Description</label><asp:TextBox ID="txtDescription" class="form-control" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
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
