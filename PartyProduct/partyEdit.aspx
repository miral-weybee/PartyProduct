<%@ Page Title="Party Edit" Language="C#" MasterPageFile="~/PartyProduct.Master" AutoEventWireup="true" CodeBehind="partyEdit.aspx.cs" Inherits="PartyProduct.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1 style="text-align: center">Party Add</h1>
    <p style="text-align: center; display: none">Data Added Successfully..</p>
    <div class="container">
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="partyNameLabel" runat="server" Text="Party Name:"></asp:Label>
            <asp:TextBox ID="partyNameTextBox" runat="server"></asp:TextBox>
        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            
            <asp:Button ID="partyNameSavebtn" class="btn btn-success" runat="server" Text="Save" OnClick="partyNameSavebtn_Click"  />
            <asp:Button ID="partyNameCancelbtn" class="btn btn-secondary" runat="server" Text="Cancel" OnClick="Button2_Click" />
            <br />
            <br />
        </div>
        <hr />
    </div>
   
</asp:Content>
