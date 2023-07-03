<%@ Page Title="" Language="C#" MasterPageFile="~/MH.Master" AutoEventWireup="true" CodeBehind="AddMCHead.aspx.cs" Inherits="MilitaryMessage.AddMCHead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="">
        <div class="main-page">
            <div class="forms">
               
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                           Add Military Category Head Details:</h4>
                    </div>
                   <div class="form-body">
                      <div class="form-group">
                            <label for="exampleInputEmail1">
                               Select Military Category</label> <asp:DropDownList ID="ddlMC" runat="server" class="form-control">
                       </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="Select Military Category" ControlToValidate="ddlMC" InitialValue="--Select--" ForeColor="Red" 
                                ValidationGroup="A"></asp:RequiredFieldValidator>
                        </div>
                       
                        <div class="form-group">
                            <label for="exampleInputEmail1">
                               Enter Name</label><asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="Enter Name" ControlToValidate="txtName" ForeColor="Red" 
                                ValidationGroup="A"></asp:RequiredFieldValidator>
                        </div>
                         <div class="form-group">
                            <label for="exampleInputEmail1">
                               Enter EmailId</label><asp:TextBox ID="txtEmailId" class="form-control" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ErrorMessage="Enter EmailId" ControlToValidate="txtEmailId" ForeColor="Red" 
                                ValidationGroup="A"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                 ErrorMessage="Invalid Email Id" ControlToValidate="txtEmailId" ForeColor="Red" 
                                 ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                 ValidationGroup="A"></asp:RegularExpressionValidator>
                        </div>
                         <div class="form-group">
                            <label for="exampleInputEmail1">
                               Enter MobileNo</label><asp:TextBox ID="txtMobileNo" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ErrorMessage="Enter MobileNo" ControlToValidate="txtMobileNo" ForeColor="Red" 
                                ValidationGroup="A"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                 ErrorMessage="Only 10 Digits" ControlToValidate="txtMobileNo" ForeColor="Red" 
                                 ValidationExpression="[0-9]{10}" ValidationGroup="A"></asp:RegularExpressionValidator>
                        </div>
                         <div class="form-group">
                            <label for="exampleInputEmail1">
                               Enter Address</label><asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ErrorMessage="Enter Address" ControlToValidate="txtAddress" ForeColor="Red" 
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
