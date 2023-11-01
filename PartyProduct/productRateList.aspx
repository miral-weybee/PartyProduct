<%@ Page Title="Product Rate List" Language="C#" MasterPageFile="~/PartyProduct.Master" AutoEventWireup="true" CodeBehind="productRateList.aspx.cs" Inherits="PartyProduct.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">Product Rate List</h1>
    <div class="container">
        <asp:Button ID="Button1" class="btn btn-warning" runat="server" Text="Add New Product" OnClick="Button1_Click" />
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table table-striped mt-4 table-bordered">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Product Name</th>
                            <th scope="col">Rate</th>
                            <th scope="col">Date Of Rate</th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td scope="row"><%#Eval("productRateId") %></td>
                    <td><%# Eval("productName") %></td>
                    <td><%#Eval("rate") %></td>
                    <td><%#Eval("dateOfRate") %></td>
                    <td>
                        <a href="EditProductRate.aspx?id=<%#Eval("productRateId") %>" class="btn btn-success">Edit</a>
                        <a href="productRateListDelete.aspx?id=<%#Eval("productRateId") %>" class="btn btn-danger">Delete</a>
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
