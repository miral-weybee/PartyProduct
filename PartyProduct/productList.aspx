<%@ Page Title="Product List" Language="C#" MasterPageFile="~/PartyProduct.Master" AutoEventWireup="true" CodeBehind="productList.aspx.cs" Inherits="PartyProduct.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">Product List</h1>
    <div class="container">
        <asp:Button ID="Button1" class="btn btn-warning" runat="server" Text="Add New Product" OnClick="Button1_Click" />
        <asp:Repeater ID="ProductRepeater" runat="server">
            <HeaderTemplate>
                <table class="table table-striped mt-4 table-bordered">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Product Name</th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("productId")%></td>
                    <td><%#Eval("productName")%></td>
                    <td>
                        <a href="EditProduct.aspx?id=<%#Eval("productId") %>" class="btn btn-success">Edit</a>
                        <a href="productDelete.aspx?id=<%#Eval("productId") %>" class="btn btn-danger">Delete</a>
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
