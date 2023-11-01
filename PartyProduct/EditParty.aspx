<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProduct.Master" AutoEventWireup="true" CodeBehind="EditParty.aspx.cs" Inherits="PartyProduct.EditParty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">Party Edit</h1>
    <div class="container">
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="OldEditpartyNameLabel" runat="server" Text="Old Party Name:"></asp:Label>
            <asp:TextBox ID="OldEditpartyNameTextBox" runat="server"></asp:TextBox>
        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="NewEditpartyNameLabel" runat="server" Text="New Party Name:"></asp:Label>
            <asp:TextBox ID="NewEditpartyNameTextBox" runat="server"></asp:TextBox>
        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            
            <asp:Button ID="EditPartySavebtn" runat="server" Text="Save" class="btn btn-success" OnClick="EditPartySavebtn_Click" />
            <asp:Button ID="CancelPartybtn" runat="server" Text="Cancel" class="btn btn-secondary" OnClick="CancelPartybtn_Click" />
            <br />
            <br />
        </div>
        <hr />
    </div>
</asp:Content>
