<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DonHang_HienThi.ascx.cs" Inherits="cms_admin_SanPham_QuanLyDonHang_DonHang_HienThi" %>
<div class="head">
    Danh sách đơn hàng
    <div class="cb"></div>
</div>
<div class="KhungChuaBang">
   <table class="tbNhomSanPham">
       <tr>
           <th class="cotMa">Mã</th>
           <th class="cotDonGia">Ngày nhận</th>
           <th class="cotDonGia">Tổng tiền</th>
           <th class="cotDonGia">Tình trạng</th>
           <th class="cotDonGia">Khách hàng</th>
           <th class="cotCongCu">Công cụ</th>
       </tr>
       <asp:Literal ID="ltrDonHang" runat="server"></asp:Literal>
   </table>
</div>

<script type="text/javascript">
    function XoaDonHang(id) {
        if (confirm("Bạn chắc chắn muốn xóa đơn hàng này")) {
            //Viết code xóa danh mục tại đây

            $.post("cms/admin/SanPham/QuanLyDonHang/Ajax/DonHang.aspx",
                {
                    "ThaoTac": "XoaDonHang",
                    "id": id
                },
                function(data, status) {
                    //alert("Data :" + data + "\n Status :" + status);
                    if (data == 1) {
                        //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#maDong_" + id).slideUp();
                    }
                });
        }
    }
</script>