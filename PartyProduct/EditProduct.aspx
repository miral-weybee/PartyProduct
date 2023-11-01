<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProduct.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="PartyProduct.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">Product Edit</h1>
    <div class="container">
        <div style="display:flex;justify-content:center;align-items:center;gap:1em;margin-top:1em">
            <asp:Label ID="OldProductNamelbl" runat="server" Text="Old Product Name:"></asp:Label>
            <asp:TextBox ID="OldProductNameTextBox" runat="server"></asp:TextBox>
        </div>
        <div style="display:flex;justify-content:center;align-items:center;gap:1em;margin-top:1em">
            <asp:Label ID="NewProductNamelbl" runat="server" Text="New Product Name:"></asp:Label>
            <asp:TextBox ID="NewProductNameTextBox" runat="server"></asp:TextBox>
        </div>
        <div style="display:flex;justify-content:center;align-items:center;gap:1em;margin-top:1em">
            <asp:Button ID="ProductSavebtn" class="btn btn-success" runat="server" Text="Save" OnClick="ProductSavebtn_Click"  />
            <asp:Button ID="EditProductCancelbtn" class="btn btn-secondary" runat="server" Text="Cancel" OnClick="Button2_Click" />
        </div>
    <hr />
    </div>
</asp:Content>
