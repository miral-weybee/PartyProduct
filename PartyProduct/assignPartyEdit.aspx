<%@ Page Title="Assign Party Edit" Language="C#" MasterPageFile="~/PartyProduct.Master" AutoEventWireup="true" CodeBehind="assignPartyEdit.aspx.cs" Inherits="PartyProduct.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">Assign Party Add</h1>
    <div class="container">
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="Label1" runat="server" Text="Party Name:"></asp:Label>
            
        &nbsp;<asp:DropDownList ID="PartyNameDropDown" runat="server" Height="31px" Width="169px" DataSourceID="SqlDataSource1" DataTextField="partyName" DataValueField="partyName">
                
            </asp:DropDownList>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT [partyName] FROM [party]"></asp:SqlDataSource>
            
        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="Label2" runat="server" Text="Product Name:"></asp:Label>
            
            <asp:DropDownList ID="ProductNameDropDown" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" Height="31px" Width="170px" DataSourceID="SqlDataSource2" DataTextField="productName" DataValueField="productName">
                
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString2 %>" SelectCommand="SELECT [productName] FROM [product]"></asp:SqlDataSource>
        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Button ID="AssignPartySavebtn" class="btn btn-success" runat="server" Text="Save" OnClick="Button1_Click" />
            <asp:Button ID="AssignPartyCancelbtn" class="btn btn-secondary" runat="server" Text="Cancel" OnClick="Button2_Click" />
        </div>
        <hr />
    </div>
</asp:Content>
