using System;
using System.Data;

public partial class cms_admin_SanPham_QuanLyPhienDauGia_PhienDauGia_HienThi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LayPhienDauGia();
    }

    private void LayPhienDauGia()
    {
        DataTable dt = new DataTable();
        dt = emdepvn.PhienDauGia.Thongtin_PhienDauGia();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ltrPhienDauGia.Text += @"
<tr id='maDong_" + dt.Rows[i]["MaPhienDG"] + @"'>
            <td class='cotMa'>" + dt.Rows[i]["MaPhienDG"] + @"</td>
           <td class='cotDonGia'>" + dt.Rows[i]["ThoiGianBatDau"] + @"</td>
           <td class='cotDonGia'>" + dt.Rows[i]["ThoiGianKetThuc"] + @"</td>
           <td class='cotThuTu'>" + dt.Rows[i]["MaSP"] + @"</td>
           <td class='cotDonGia'>" + dt.Rows[i]["GiaDeXuat"] + @"</td>
           <td class='cotCongCu'>
                <a href='Admin.aspx?modul=SanPham&modulphu=PhienDauGia&thaotac=ChiTiet&id=" + dt.Rows[i]["MaPhienDG"] + @"' class='xem' title='Xem'></a>
               <a href='Admin.aspx?modul=SanPham&modulphu=PhienDauGia&thaotac=ChinhSua&id=" + dt.Rows[i]["MaPhienDG"] + @"' class='sua' title='Sửa'></a>
               <a href='javascript:XoaPhienDauGia(" + dt.Rows[i]["MaPhienDG"] + @")' class='xoa' title='Xóa'></a>
           </td>
</tr>
";
        }

    }
}