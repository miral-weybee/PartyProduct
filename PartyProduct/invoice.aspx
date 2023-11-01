<%@ Page Title="Invoice" Language="C#" MasterPageFile="~/PartyProduct.Master" AutoEventWireup="true" CodeBehind="invoice.aspx.cs" Inherits="PartyProduct.WebForm11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 848px;
        }

        .auto-style2 {
            width: 848px;
            height: 27px;
        }

        .auto-style3 {
            width: 921px;
            height: 27px;
        }

        .auto-style4 {
            width: 921px;
        }

        .auto-style5 {
            height: 65px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td style="vertical-align: middle; text-align: center" class="auto-style5">
                <h1>Invoice Add</h1>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="auto-style2" style="text-align: right">Party Name: &nbsp; </td>
                        <td class="auto-style3">
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="30px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" Width="190px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" style="text-align: right">Product Name: &nbsp; </td>
                        <td class="auto-style4">
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="190px" Height="30px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="text-align: right">Current Rate: &nbsp; </td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" style="text-align: right">Quantity: &nbsp; </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" style="text-align: right">&nbsp;</td>
                        <td class="auto-style4">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div class="text-center">
                    <asp:Button class="btn btn-success" ID="Button2" runat="server" Text="Add To Invoice" OnClick="Button2_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="container">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                            <table class="table table-striped mt-4 table-bordered">
                                <thead>
                                    <tr>
                                        <th scope="col">#</th>
                                        <th scope="col">Party</th>
                                        <th scope="col">Product</th>
                                        <th scope="col">Rate of Product</th>
                                        <th scope="col">Quantity</th>
                                        <th scope="col">Total</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("invoiceId") %></td>
                                <td><%#Eval("partyName") %></td>
                                <td><%#Eval("productName") %></td>
                                <td><%#Eval("currentRate") %></td>
                                <td><%#Eval("qty") %></td>
                                <td><%#Eval("total") %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                    </table>
                        </FooterTemplate>
                    </asp:Repeater>



                </div>
            </td>
        </tr>
        <tr>

            <td style="vertical-align: middle; text-align: right">&nbsp;</td>

        </tr>
        <tr>

            <td style="vertical-align: middle; text-align: right">
                <div class="container">
                    Grand Total :
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </div>
            </td>

        </tr>
        <tr>

            <td style="vertical-align: middle; text-align: right">&nbsp;</td>

        </tr>
        <tr>
            <td>
                <div class="container">
                    <div class="text-end">
                        <asp:Button ID="Button3" class="btn btn-info" runat="server" Text="Close Invoice" OnClick="Button3_Click" />
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <div class="container">
        <hr />
    </div>
</asp:Content>
