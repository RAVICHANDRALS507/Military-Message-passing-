<%@ Page Title="" Language="C#" MasterPageFile="~/MSCH.Master" AutoEventWireup="true" CodeBehind="PostMessageHead.aspx.cs" Inherits="MilitaryMessage.PostMessageHead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="">
        <div class="main-page">
            <div class="forms">
               
                <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                    <div class="form-title">
                        <h4>
                           Post Message To Head:</h4>
                    </div>
                   <div class="form-body">
                       
                         <div class="form-group">
                            <label for="exampleInputEmail1">
                               Enter Message</label><asp:TextBox ID="txtDescription" class="form-control" runat="server"></asp:TextBox>
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
