<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhienDauGia_HienThi.ascx.cs" Inherits="cms_admin_SanPham_QuanLyPhienDauGia_PhienDauGia_HienThi" %>
<div class="head">
    Các phiên đấu giá đã tạo. 
    <div class="fr ter"><a class="btThemMoi" href="/Admin.aspx?modul=SanPham&modulphu=PhienDauGia&thaotac=ThemMoi">Thêm mới phiên đấu giá</a></div>
    <div class="cb"></div>
</div>
<div class="KhungChuaBang">
   <table class="tbNhomSanPham">
       <tr>
           <th class="cotMa">Mã</th>
           <th class="cotDonGia">Thời gian bắt đầu</th>
           <th class="cotDonGia">Thời gian kết thúc</th>
           <th class="cotThuTu">Mã sản phẩm</th>
           <th class="cotDonGia">Giá đề xuất</th>
           <th class="cotCongCu">Công cụ</th>
       </tr>
       <asp:Literal ID="ltrPhienDauGia" runat="server"></asp:Literal>
   </table>
</div>

<script type="text/javascript">
    function XoaPhienDauGia(id) {
        if (confirm("Bạn chắc chắn muốn xóa phiên đấu giá này")) {
            //Viết code xóa danh mục tại đây

            $.post("cms/admin/SanPham/QuanLyPhienDauGia/Ajax/PhienDauGia.aspx",
                {
                    "ThaoTac": "XoaPhienDauGia",
                    "id": id
                },
                function (data, status) {
                    //alert("Data :" + data + "\n Status :" + status);
                    if (data == 1) {
                        //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#maDong_" + id).slideUp();

                    }
                });
        }
    }
</script>