<%@ Page Title="" Language="C#" MasterPageFile="~/CRUD.Master" AutoEventWireup="true" CodeBehind="CRUD_Form.aspx.cs" Inherits="CRUD_Operation.CRUD_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <label>Product ID <sup style="color: Red">*</sup></label></td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="txt_Prod_Id" size="90" placeholder="Enter Product Id" /></td>
                </tr>
                <tr>
                    <td>
                        <label>Product Name <sup style="color: Red">*</sup></label></td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="txt_Prod_Name" size="90" placeholder="Enter Product Name" /></td>
                </tr>
                <tr>
                    <td>
                        <label>Product Price <sup style="color: Red">*</sup></label></td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="txt_Prod_Price" size="90" placeholder="Enter Product Price" /></td>
                </tr>
            </table>
            <input type="button" class="btn" id="btn_Submit_prod" value="Submit" />
            <input type="button" class="btn" id="btn_Delete_prod" value="Delete" />
            <input type="button" class="btn" id="btn_View_prod" value="View" />
            <input type="button" class="btn" id="btn_Update_prod" value="Update" />
            &nbsp;
        </div>
    </div>
    <table class="auto-style5">
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>
        <input type="button" id="btn_ProductList" value="List all Products" class="auto-style3" /></td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div>
        <table border="1" id="render_product">
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td class="auto-style1"> Server Side control</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="UploadFile_Server"  multiple="true" runat="server" Height="26px" />&nbsp;</td>           

                    <td class="auto-style1"> Client Side control</td>
                    <td class="auto-style1"><input type="file" id="UploadFile_Client" onchange="filesave()" accept="multipart" /></td>
                                <td class="auto-style1">
                    <asp:Button ID="Upload" runat="server" OnClick="Upload_Click" Text="Upload" Width="182px" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Download" runat="server" OnClick="Download_Click" Text="Download" Width="182px" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
          <td><%--<asp:GridView ID="View_file" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">--%>
    
                <asp:Label ID="lbltxt" runat="server" Font-Bold="true" ForeColor="Red" />
<asp:GridView ID="View_files" CellPadding="5" runat="server" AutoGenerateColumns="false" >
<Columns>
<asp:TemplateField>
<ItemTemplate>
<asp:CheckBox ID="chkSelect" name="check" runat="server" />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Text" HeaderText="Files" />
</Columns>
<HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
</asp:GridView>
            </tr>
        </table>
    </div>
    <script src="Script/Internal/PageScript/CRUD_Operation.js"></script>
    <script src="Script/Internal/PageScript/Handler.js"></script>
</asp:Content>
