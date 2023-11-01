<%@ Page Title="Assign Party List" Language="C#" MasterPageFile="~/PartyProduct.Master" AutoEventWireup="true" CodeBehind="assignPartyList.aspx.cs" Inherits="PartyProduct.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">Assign Party List</h1>
    <div class="container">
        <asp:Button ID="Button1" class="btn btn-warning" runat="server" Text="Add New Assign" OnClick="Button1_Click" />
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table table-striped mt-4 table-bordered">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Party Name</th>
                            <th scope="col">Product Name</th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("assignPartyId")%></td>
                    <td><%#Eval("partyName")%></td>
                    <td><%#Eval("productName")%></td>
                    <td>
                        <a href="EditAssignParty.aspx?id=<%#Eval("assignPartyId") %>" class="btn btn-success">Edit</a>
                        <a href="assignPartyDelete.aspx?id=<%#Eval("assignPartyId") %>" class="btn btn-danger">Delete</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
        </table>
            </FooterTemplate>
        </asp:Repeater>



        <hr />
    </div>
</asp:Content>
