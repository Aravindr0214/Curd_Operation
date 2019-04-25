<%@ Page Title="" Language="C#" MasterPageFile="~/CRUD.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CRUD_Operation.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            background-size: cover;
            background-position: center;
            height: 100%;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="isc-login-main-bdy">
        <img src="supermarket.jpg" class="auto-style1" />
        <div class="isc-login">
            <div class="isc-login-con-hdr-s1">
            </div>
            <div class="isc-login-con-bdy-s1">
                <h2>*Super Market*</h2>
                <div>

                    <p>
                        <label style="color: #fff;">LoginId</label></p>
                    <p>
                        <asp:TextBox runat="server" id="txt_Login_id"></asp:TextBox>
                    </p>
                    <p>
                        <label style="color: #fff;">Password</label></p>
                    <p>
                        <asp:TextBox runat="server" id="txt_Password" />--%></p>
                    <p>
                        
                      <asp:Button runat="server" id="btn_login" Text="Log-in" OnClick="btn_login_Click"></asp:Button>
                        <input type="submit" id="btn_Cancel" value="Cancel" />
                    </p>
                    <p><a href="#">Forget Password</a></p>
                </div>
            </div>
        </div>
    </div>
    <link href="Style/Internal/Login.css" rel="stylesheet" />
</asp:Content>
