<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChiTietDonHang.aspx.cs" Inherits="cms_admin_SanPham_QuanLyDonHang_ChiTietDonHang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chi tiết đơn hàng</title>
    <link href="../../css/cssChiTietDonHang.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="DonHang">
        <div class="tieuDeTrang">Đơn đặt hàng</div>
        <div class="ngayDat">Ngày đặt: <asp:Literal ID="ltrNgayDat" runat="server"></asp:Literal> - Mã đơn hàng: <asp:Literal ID="ltrMaDonHang" runat="server"></asp:Literal></div>
        <div class="thongTinKH">
            <div class="head">Thông tin khách hàng</div>
            <ul>
                <li>Mã KH: <asp:Literal ID="ltrMaKH" runat="server"></asp:Literal></li>
                <li>Họ tên: <asp:Literal ID="ltrTenKH" runat="server"></asp:Literal></li>
                <li>Email: <asp:Literal ID="ltrEmailKH" runat="server"></asp:Literal></li>
                <li>Số ĐT: <asp:Literal ID="ltrSoDTKH" runat="server"></asp:Literal></li>
            </ul>
        </div>
        <div class="thongTinSanPham">
            <div class="head">Danh sách sản phẩm</div>
            <table>
                <tr>
                    <th>STT</th>
                    <th>Mã SP</th>
                    <th>Tên SP</th>
                    <th class="tar">Đơn giá</th>
                    <th class="tar">Số lượng</th>
                    <th class="tar">Thành tiền</th>
                </tr>
                <asp:Literal ID="ltrDanhSachSanPham" runat="server"></asp:Literal>
                <%--<tr>
                    <td>STT</td>
                    <td>Mã SP</td>
                    <td>Tên SP</td>
                    <td class="tar">Đơn giá</td>
                    <td class="tar">Số lượng</td>
                    <td class="tar">Thành tiền</td>
                </tr>--%>
                <tr>
                    <td colspan="5"><b>Tổng tiền</b></td>                    
                    <td class="tar"><b><asp:Literal ID="ltrTongTienDonHang" runat="server"></asp:Literal></b></td>
                </tr>
            </table>
        </div>
        <div class="thongTinCuoi">
            Mọi nhu cầu liên hệ của quý khách, vui lòng liên hệ với chúng tôi theo thông tin dưới đây.<br/>
            <br/>
            Địa chỉ: ...<br/>
            Số điện thoại: 0352808225<br/>
            Email: lluatt91@gmail.com<br/>
            Rất hân hạnh được phục vụ quý khách!
        </div>
        <div style="position:fixed;z-index:1;bottom:10px;right:10px">Gợi ý: nhấn <b>Ctrl P</b> để in đơn hàng</div>
    </div>
    </form>
</body>
</html>
