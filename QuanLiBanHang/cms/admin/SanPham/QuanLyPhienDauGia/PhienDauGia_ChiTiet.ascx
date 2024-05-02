<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhienDauGia_ChiTiet.ascx.cs" Inherits="cms_admin_SanPham_QuanLyPhienDauGia_PhienDauGia_ChiTiet" %>
<asp:HiddenField ID="hdEmailKH" runat="server" />
<asp:HiddenField ID="hdTenKH" runat="server" />
<asp:HiddenField ID="hdTenSP" runat="server" />
<asp:HiddenField ID="hdGiaDuaRa" runat="server" />
<asp:HiddenField ID="hdThoiGianDauGia" runat="server" />
<asp:HiddenField ID="hdMaXacNhan" runat="server" />
<div class="PhienDauGia_ChiTiet">
    <div class="head">
        Chi tiết phiên đấu giá
    </div>

    <div class="noiDung">
        <div class="ThongTinSP">
            <asp:Literal ID="ltrThongTinPhienVaSanPham" runat="server"></asp:Literal>
        </div>
        <div class="KHDangChienThang">
            <div class="tieuDe">Khách hàng đang chiến thắng</div>
            <div class="thongTin">
                <asp:Literal ID="ltrThongTinKhachHangChienThang" runat="server"></asp:Literal>
            </div>
            <div class="nutGui">
                <asp:LinkButton ID="lbtGuiThongBao" runat="server" OnClick="lbtGuiThongBao_OnClick">Gửi email thông báo</asp:LinkButton>
            </div>
        </div>
        <div class="cb"></div>
        <div class="CacLuotDauGia">
            <div class="tieuDe">Tất cả các lượt đấu giá cho phiên này</div>
            <table>
                <tr>
                    <th>TT</th>
                    <th>Thời gian đấu giá</th>
                    <th>Giá đưa ra</th>
                    <th>Mã xác nhận</th>
                    <th>Mã KH</th>
                </tr>
                <asp:Literal ID="ltrCacLuotDauGia" runat="server"></asp:Literal>
            </table>
        </div>
    </div>
</div>
