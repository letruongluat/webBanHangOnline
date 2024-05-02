using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_display_SanPham_GioHang : System.Web.UI.UserControl
{
    #region Khai báo các biến lấy ra thông tin của khách hàng nếu họ đã đăng nhập

    protected string hoTen = "";
    protected string diaChi = "";
    protected string email = "";
    protected string soDienThoai = "";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LayRaThongTinKhachHangDaDangNhap();
    }

    private void LayRaThongTinKhachHangDaDangNhap()
    {
        //Nếu khách hàng đã đăng nhập
        if (Session["KhachHang"] != null && Session["KhachHang"].ToString() == "1")
        {
            //Lấy thông tin đã lưu khi khách hàng đăng nhập
            hoTen = Session["TenKh"].ToString();
            diaChi=Session["DiaChiKH"].ToString();
            soDienThoai =Session["sdtKH"].ToString();
            email =Session["EmailKH"].ToString();
        }
    }
}