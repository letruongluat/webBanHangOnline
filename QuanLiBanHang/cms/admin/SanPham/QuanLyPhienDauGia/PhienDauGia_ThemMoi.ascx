<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhienDauGia_ThemMoi.ascx.cs" Inherits="cms_admin_SanPham_QuanLyPhienDauGia_PhienDauGia_ThemMoi" %>
<div class="head">
    Thêm mới, chỉnh sửa phiên đấu giá
</div>
<div class="FormThemMoi">
    <asp:Literal ID="ltrThongBao" runat="server"></asp:Literal>   
    <div class="thongTin">
        <div class="tenTruong">Thời gian bắt đầu</div>
        <div class="oNhap">            
            <asp:TextBox ID="tbThoiGianBatDau" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="tbThoiGianBatDau" Display="Dynamic" SetFocusOnError="True" ForeColor="Red" ></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="thongTin">
        <div class="tenTruong">Thời gian kết thúc</div>
        <div class="oNhap">            
            <asp:TextBox ID="tbThoiGianKetThuc" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="tbThoiGianKetThuc" Display="Dynamic" SetFocusOnError="True" ForeColor="Red" ></asp:RequiredFieldValidator>
        </div>
    </div>
     <div class="thongTin">
        <div class="tenTruong">Mã sản phẩm</div>
        <div class="oNhap">            
            <asp:TextBox ID="tbMaSP" runat="server"></asp:TextBox> (Xem bên <a href="/Admin.aspx?modul=SanPham&modulphu=DanhSachSanPham" target="_blank">Danh sách sản phẩm</a>)
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="tbMaSP" Display="Dynamic" SetFocusOnError="True" ForeColor="Red" ></asp:RequiredFieldValidator>
        </div>
    </div>
      
    <div class="thongTin">
        <div class="tenTruong">Giá đề xuất</div>
        <div class="oNhap">
            <asp:TextBox ID="tbGiaDeXuat" runat="server"></asp:TextBox> (Xem bên <a href="/Admin.aspx?modul=SanPham&modulphu=DanhSachSanPham" target="_blank">Danh sách sản phẩm</a>)
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Giá đề xuất phải nhập kiểu số" ControlToValidate="tbGiaDeXuat" Display="Dynamic" SetFocusOnError="True" ValidationExpression="(\d)*" ForeColor="Red"  ></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="thongTin">
        <div class="tenTruong">&nbsp;</div>
        <div class="oNhap"><asp:CheckBox ID="cbThemNhieuNhom" runat="server" Text="Tạo thêm nhóm sản phẩm khác sau khi tạo nhóm sản phẩm này"/></div>
    </div>
    <div class="thongTin">
        <div class="tenTruong">&nbsp;</div>
        <div class="oNhap">
            <asp:Button ID="btThemMoi" runat="server" Text="Thêm mới" CssClass="btThemMoi" OnClick="btThemMoi_Click" />
            <asp:Button ID="btHuy" runat="server" Text="Hủy" CssClass="btHuy" OnClick="btHuy_Click" CausesValidation="false" />
        </div>
    </div>
</div>