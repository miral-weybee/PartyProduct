<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProduct.Master" AutoEventWireup="true" CodeBehind="EditProductRate.aspx.cs" Inherits="PartyProduct.EditPoductRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">Product Rate Edit</h1>
    <div class="container">
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="Label1" runat="server" Text="Old Product Name:"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="170px">
            </asp:DropDownList>
        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="Label2" runat="server" Text="Old Product Rate:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="Label3" runat="server" Text="Old Date of Rate:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>

        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="Label4" runat="server" Text="New Product Name:"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" Width="170px" DataSourceID="SqlDataSource1" DataTextField="productName" DataValueField="productName">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT [productName] FROM [product]"></asp:SqlDataSource>
        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="Label5" runat="server" Text="New Product Rate:"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="Label6" runat="server" Text="New Date of Rate:"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Button ID="productRateListEditSavebtn" class="btn btn-success" runat="server" Text="Save" OnClick="productRateListEditSavebtn_Click" />
            <asp:Button ID="productRateListEditCancelbtn" class="btn btn-secondary" runat="server" Text="Cancel" OnClick="productRateListEditCancelbtn_Click" />
        </div>
        <hr />
    </div>
</asp:Content>
