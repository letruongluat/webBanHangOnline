<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DauGia.ascx.cs" Inherits="cms_display_SanPham_DauGia" %>
<link href="css/dau-gia.css" rel="stylesheet" />
<asp:HiddenField ID="hdMaPhienDauGia" runat="server" />
<asp:HiddenField ID="hdMaKH" runat="server" />
<asp:HiddenField ID="hdEmailKH" runat="server" />
<asp:HiddenField ID="hdTenKH" runat="server" />
<asp:HiddenField ID="hdTenSP" runat="server" />

<div class="DauGia">
    <div class="FormDauGia">
        <div class="ThongTinSanPham">
            <div class="head">Thông tin sản phẩm</div>
            <asp:Literal ID="ltrThongTinSanPham" runat="server"></asp:Literal>
            <div class="thongTinKhac">
                <div class="giaDeXuat">Mức giá đề xuất: <span><asp:Literal ID="ltrGiaDeXuat" runat="server"></asp:Literal></span>đ</div>
                <div class="thoiGianConLai">Thời gian đấu giá: <asp:Literal ID="ltrThoiGianDauGia" runat="server"></asp:Literal></div>
                <div class="giaBanChon">
                    Giá bạn chọn:  <asp:TextBox ID="tbGiaBanChon" runat="server" Text="1000" type="number"></asp:TextBox>đ
                </div>
                <div class="nutGuiNgoai">
                    <asp:LinkButton ID="lbDauGia" runat="server" CssClass="nutGui" OnClick="lbDauGia_OnClick">Đấu giá</asp:LinkButton>
                </div>
            </div>
            <div class="cb"></div>
        </div>
    </div>
    
    <div class="LuatChoi">
        <b>Quý khách vui lòng tham khảo hình thức đấu giá dưới đây:</b>
        <ul>
            <li>Đấu giá ngược với yêu cầu giá người chơi đưa ra là nhỏ nhất và duy nhất.</li>
            <li>Đơn vị tổ chức sẽ tạo ra một phiên đấu giá bắt đầu từ ngày nào tới ngày nào với một hoặc nhiều sản phẩm được đưa ra kèm theo mức giá bán thông thường.</li>
            <li>
                Người dùng tham gia đấu giá trên website cần thực hiện đăng ký tài khoản với email thật của mình. Sau khi có tài khoản, người dùng tới trang đấu giá &rarr; Chọn mức giá mình cho rằng sẽ là nhỏ nhất và duy nhất (mức giá phải là bội số của 1.000đ và lớn hơn 0) &rarr; Nhấn nút xác nhận gửi giá đấu lên hệ thống &rarr; Hệ thống sẽ gửi một email xác nhận kèm theo mã xác nhận đấu giá tới email người dùng (mã ngẫu nhiên do hệ thống sinh ra, mã này được dùng để so sánh khi nhận giải)
            </li>
            <li>Mỗi người dùng được phép gửi tối đa 10 lần đấu giá cho một phiên (số lần do đơn vị tổ chức quy định)</li>
            <li>Sau khi hết hạn phiên đấu giá thì đơn vị tổ chức sẽ chọn ra giá đấu nhỏ nhất, duy nhất và thông báo tới email người sở hữu mức đấu giá đó. Đồng thời thông tin email trúng thưởng sẽ được công bố trên website.</li>
            <li>Trong trường hợp không có ai gửi mức giá nhỏ nhất và duy nhất thì người chiến thắng là người gửi mức giá nhỏ nhất và sớm nhất.</li>
        </ul>
    </div>
</div>