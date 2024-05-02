<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<%@ Register Src="~/cms/admin/AdminLoadControl.ascx" TagPrefix="uc1" TagName="AdminLoadControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang quan trị website Shop Bán Áo Quần</title>
    <link href="cms/admin/css/cssAdmin.css" rel="stylesheet" />
    <script src="cms/admin/js/jquery-3.1.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--Header--%>
            <div id="header">
                <div class="container">
                    <div class="logo">
                        <a href="/Admin.aspx"></a>
                    </div>
                    <div class="accountMenu">
                        Xin chào:<asp:Literal ID="ltrTenDangNhap" runat="server"></asp:Literal> | <asp:LinkButton ID="lbtDangXuat" runat="server" OnClick="lbtDangXuat_Click">Đăng xuất</asp:LinkButton>
                    </div>                 
                </div>               
            </div>

             <%--MenuChinh--%>
            <div class="MenuChinh">
                <div class="container">
                    <ul>
                        <li><a class="<%=DanhDau("SanPham") %>" href="Admin.aspx?modul=SanPham">Sản phẩm</a></li>
                        <li><a class="<%=DanhDau("KhachHang") %>" href="Admin.aspx?modul=KhachHang">Khách Hàng</a></li>
                        <li><a class="<%=DanhDau("TinTuc") %>" href="Admin.aspx?modul=TinTuc">Tin Tức</a></li>
                        <li><a class="<%=DanhDau("TaiKhoan") %>" href="Admin.aspx?modul=TaiKhoan">Tài khoản</a></li> 
                        <li><a class="<%=DanhDau("QuangCao") %>" href="Admin.aspx?modul=QuangCao">Quảng cáo</a></li> 
                        <li><a class="<%=DanhDau("Menu") %>" href="Admin.aspx?modul=Menu">Menu</a></li>                              
                    </ul>
                </div>              
            </div>        
            
             <%--Nội dung trang--%>
            <uc1:AdminLoadControl runat="server" ID="AdminLoadControl" />
        </div>
    </form>
</body>
</html>
