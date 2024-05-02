using System;
using System.Data;

public partial class cms_admin_SanPham_QuanLyDonHang_DonHang_HienThi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LayDonHang();
        }
    }

    private void LayDonHang()
    {
        // Import the necessary namespace if required
        // Example: using emdepvn;

        DataTable dt = emdepvn.DonDatHang.Thongtin_Dondathang_Desc(); // Assuming Thongtin_Dondathang_Desc returns a DataTable
        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                int maDonDatHang = Convert.ToInt32(row["MaDonDatHang"]);
                string ngayTao = row["NgayTao"].ToString();
                decimal thanhTienDH = Convert.ToDecimal(row["ThanhTienDH"]);
                string tinhTrangDonHang = row["TinhTrangDonHang"].ToString();
                string maKH = row["MaKH"].ToString();
                string tenKH = row["TenKH"].ToString();
                string sdtKH = row["sdtKH"].ToString();
                string emailKH = row["EmailKH"].ToString();

                string tinhTrang = HienThiTinhTrangDonHang(tinhTrangDonHang);

                ltrDonHang.Text += @"
<tr id='maDong_" + maDonDatHang + @"'>
    <td class='cotMa'>" + maDonDatHang + @"</td>
    <td class='cotDonGia'>" + ngayTao + @"</td>
    <td class='cotDonGia'>" + thanhTienDH + @"</td>
    <td class='cotDonGia'>" + tinhTrang + @"</td>
    <td class='cotDonGia'>
        Mã KH: " + maKH + @"<br/>
        Tên KH: " + tenKH + @"<br/>
        Số điện thoại KH: " + sdtKH + @"<br/>
        Email KH: " + emailKH + @"<br/>
    </td>
    <td class='cotCongCu'>
        <a href=""javascript:window.open('cms/admin/sanpham/quanlydonhang/chitietdonhang.aspx?id=" + maDonDatHang + @"')"" class='xem' title='Xem'></a>
        <a href='javascript:XoaDonHang(" + maDonDatHang + @")' class='xoa' title='Xóa'></a>
    </td> 
</tr>
";
            }
        }
        else
        {
            ltrDonHang.Text = "<tr><td colspan='6'>No data found</td></tr>";
        }
    }

    private string HienThiTinhTrangDonHang(string maTinhTrang)
    {
        switch (maTinhTrang)
        {
            case "1":
                return "Khách hàng đã thanh toán";
            case "0":
                return "Khách hàng hủy thanh toán";
            default:
                return "Chờ KH thanh toán";
        }
    }
}
