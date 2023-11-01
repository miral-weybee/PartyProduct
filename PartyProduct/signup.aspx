<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="PartyProduct.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <section class="vh-100">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card bg-dark text-white" style="border-radius: 1rem;">
                        <div class="card-body p-5 text-center">

                            <div class="mb-md-5 mt-md-4 pb-5">

                                <h2 class="fw-bold mb-2 text-uppercase">Create Your Account</h2>
                                <p class="text-white-50 mb-5">Please enter the details!</p>

                                <div class="form-outline form-white mb-4">
                                    <label class="form-label">Your Name</label>
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control form-control-lg"></asp:TextBox>
                                </div>

                                <div class="form-outline form-white mb-4">
                                    <label class="form-label">Username</label>
                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control form-control-lg"></asp:TextBox>
                                </div>

                                <div class="form-outline form-white mb-4">
                                    <label class="form-label" for="typePasswordX">Password</label>
                                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" class="form-control form-control-lg"></asp:TextBox>
                                </div>


                                <asp:Button ID="Button1" class="btn btn-outline-light btn-lg px-5" runat="server" Text="Create Account" OnClick="Button1_Click" />
                            </div>

                            <div>
                                <p class="mb-0">
                                    Already have an account?
                                    <asp:HyperLink ID="HyperLink1" runat="server" class="text-white-50 fw-bold" NavigateUrl="~/login.aspx">Login</asp:HyperLink>
                                </p>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    </form>
</body>
</html>

