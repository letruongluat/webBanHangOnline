using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using emdepvn;

public partial class cms_admin_SanPham_QuanLyDonHang_ChiTietDonHang : System.Web.UI.Page
{
    private string id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Kiểm tra nếu đã đăng nhập thì mới cho vào trang này
        if (Session["DangNhap"] != null && Session["DangNhap"].ToString() == "1")
        {
            //Đã đăng nhập
        }
        else
        {
            //Nếu chưa đăng nhập --> đẩy về trang login
            Response.Redirect("/Login.aspx");
        }

        if (Request.QueryString["id"] != null)
            id = Request.QueryString["id"];

        if (!IsPostBack)
            LayThongTinDonHang();
    }

    private void LayThongTinDonHang()
    {
        DataTable dt = DonDatHang.Thongtin_Dondathang_by_id(id);
        if (dt.Rows.Count>0)
        {
            ltrNgayDat.Text = ((DateTime) dt.Rows[0]["NgayTao"]).ToString("dd/MM/yyyy");//Hiển thị ra ngày đặt hàng dạng ngày/tháng/năm
            ltrMaDonHang.Text = dt.Rows[0]["MaDonDatHang"].ToString();

            ltrMaKH.Text = dt.Rows[0]["MaKH"].ToString();
            ltrTenKH.Text = dt.Rows[0]["TenKH"].ToString();
            ltrSoDTKH.Text = dt.Rows[0]["sdtKH"].ToString();
            ltrEmailKH.Text = dt.Rows[0]["EmailKH"].ToString();

            ltrTongTienDonHang.Text = dt.Rows[0]["ThanhTienDH"].ToString();


            ltrDanhSachSanPham.Text = LayDanhSachSanPhamTrongDonHang(dt.Rows[0]["MaDonDatHang"].ToString());
        }
    }

    private string LayDanhSachSanPhamTrongDonHang(string maDonHang)
    {
        string s = "";

        DataTable dt = ChiTietDonDatHang.Thongtin_Chitietdondathang_by_madondathang(maDonHang);
        for (int i = 0; i<dt.Rows.Count; i++)
        {
            s += @"
<tr>
    <td>"+(i+1)+@"</td>
    <td>"+dt.Rows[i]["MaSP"] + @"</td>
    <td>" + LayTenSanPhamTheoMaSP(dt.Rows[i]["MaSP"].ToString()) + @"</td>
    <td class='tar'>" + dt.Rows[i]["DonGiaDat"] + @"</td>
    <td class='tar'>" + dt.Rows[i]["SoLuongDat"] + @"</td>
    <td class='tar'>"+ (double.Parse(dt.Rows[i]["DonGiaDat"].ToString()) * double.Parse(dt.Rows[i]["SoLuongDat"].ToString())) + @"</td>
</tr>
";
        }

        return s;
    }

    private string LayTenSanPhamTheoMaSP(string maSP)
    {
        DataTable dt = emdepvn.SanPham.Thongtin_Sanpham_by_id(maSP);
        if (dt.Rows.Count>0)
            return dt.Rows[0]["TenSP"].ToString();
        return "";
    }
}