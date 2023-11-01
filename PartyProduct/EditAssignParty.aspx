<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProduct.Master" AutoEventWireup="true" CodeBehind="EditAssignParty.aspx.cs" Inherits="PartyProduct.EditAssignParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">Assign Party Edit</h1>

    <div class="container">
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">

            <asp:Label ID="Label1" runat="server" Text="Old Party Name:"></asp:Label>

            &nbsp;
            <asp:DropDownList ID="PartyNameDropDown" runat="server" Height="31px" Width="169px">
            </asp:DropDownList>

        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="Label2" runat="server" Text="Old Product Name:"></asp:Label>

            <asp:DropDownList ID="ProductNameDropDown" runat="server" Height="31px" Width="169px">
            </asp:DropDownList>
        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="Label3" runat="server" Text="New Party Name:"></asp:Label>

            &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Height="31px" Width="169px" DataSourceID="SqlDataSource1" DataTextField="partyName" DataValueField="partyName">
            </asp:DropDownList>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString5 %>" SelectCommand="SELECT [partyName] FROM [party]"></asp:SqlDataSource>

        </div>
        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Label ID="Label4" runat="server" Text="New Product Name:"></asp:Label>

            <asp:DropDownList ID="DropDownList2" runat="server" Height="31px" Width="169px" DataSourceID="SqlDataSource2" DataTextField="productName" DataValueField="productName">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString6 %>" SelectCommand="SELECT [productName] FROM [product]"></asp:SqlDataSource>
        </div>

        <div style="display: flex; justify-content: center; align-items: center; gap: 1em; margin-top: 1em">
            <asp:Button ID="AssignPartySavebtn" class="btn btn-success" runat="server" Text="Save" OnClick="AssignPartySavebtn_Click" />
            <asp:Button ID="AssignPartyCancelbtn" class="btn btn-secondary" runat="server" Text="Cancel" OnClick="AssignPartyCancelbtn_Click" />
        </div>
        <hr />
    </div>
</asp:Content>
