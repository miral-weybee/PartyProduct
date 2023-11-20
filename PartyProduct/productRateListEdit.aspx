<%@ Page Title="Product Rate List Edit" Language="C#" MasterPageFile="~/PartyProduct.Master" AutoEventWireup="true" CodeBehind="productRateListEdit.aspx.cs" Inherits="PartyProduct.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">Product Rate Add</h1>
    <div class="container">
        <div style="display:flex;justify-content:center;align-items:center;gap:1em;margin-top:1em">
            <asp:Label ID="Label1" runat="server" Text="Product Name:"></asp:Label>
            
            <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="170px" DataSourceID="SqlDataSource1" DataTextField="productName" DataValueField="productName">
            </asp:DropDownList>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT [productName] FROM [product]"></asp:SqlDataSource>
            
        </div>
        <div style="display:flex;justify-content:center;align-items:center;gap:1em;margin-top:1em">
            <asp:Label ID="Label2" runat="server" Text="Product Rate:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div style="display:flex;justify-content:center;align-items:center;gap:1em;margin-top:1em">
            <asp:Label ID="Label3" runat="server" Text="Date of Rate:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div style="display:flex;justify-content:center;align-items:center;gap:1em;margin-top:1em">
            <asp:Button ID="productRateListEditSavebtn" class="btn btn-success" runat="server" Text="Save" OnClick="productRateListEditSavebtn_Click" />
            <asp:Button ID="productRateListEditCancelbtn" class="btn btn-secondary" runat="server" Text="Cancel" OnClick="Button2_Click" />
        </div>
    <hr />
    </div>
</asp:Content>
