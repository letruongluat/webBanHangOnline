using System;
using System.Data;
using System.Web.UI;

public partial class cms_display_SanPham_DauGia : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Kiểm tra đăng nhập
        if (Session["KhachHang"] != null && Session["KhachHang"].ToString() == "1")
        {
            //Đã đăng nhập
            hdMaKH.Value = Session["MaKH"].ToString();
            hdEmailKH.Value = Session["EmailKH"].ToString();
            hdTenKH.Value = Session["TenKh"].ToString();
        }
        else
        {
            //Xuất ra script alert để báo khách hàng cần đăng nhập tài khoản
            ScriptManager.RegisterStartupScript(this,this.GetType(),"","alert('Quý khách vui lòng đăng nhập tài khoản thành viên để tham gia đấu giá.');",true);
        }
        #endregion

        if (!IsPostBack)
            LayThongTinPhienDauGia();
    }

    //Tạm thời lấy phiên mới nhất
    private void LayThongTinPhienDauGia()
    {
        DataTable dt = emdepvn.PhienDauGia.Thongtin_PhienDauGia();
        if (dt.Rows.Count>0)
        {
            hdMaPhienDauGia.Value = dt.Rows[0]["MaPhienDG"].ToString();

            ltrGiaDeXuat.Text = dt.Rows[0]["GiaDeXuat"].ToString();
            ltrThoiGianDauGia.Text = dt.Rows[0]["ThoiGianBatDau"].ToString() + " đến " +
                                     dt.Rows[0]["ThoiGianKetThuc"].ToString();

            ltrThongTinSanPham.Text = LayThongTinSanPham(dt.Rows[0]["MaSP"].ToString());
        }
    }

    private string LayThongTinSanPham(string MaSP)
    {
        string s = "";

        DataTable dt = emdepvn.SanPham.Thongtin_Sanpham_by_id(MaSP);
        if (dt.Rows.Count>0)
        {
            string link = "Default.aspx?modul=SanPham&modulphu=ChiTietSanPham&id=" + dt.Rows[0]["MaSP"];
            hdTenSP.Value = dt.Rows[0]["TenSP"].ToString();
            s = @"
<div class='item'>
    <a href='" + link + @"' title='" + dt.Rows[0]["TenSP"] + @"'>
        <img src='/pic/sanpham/" + dt.Rows[0]["AnhSP"] + @"' alt='" + dt.Rows[0]["TenSP"] + @"' />
    </a>
    <a class='title-sp' href='" + link + @"' title='" + dt.Rows[0]["TenSP"] + @"'>
        " + dt.Rows[0]["TenSP"] + @"
    </a>
    <div class='desc'>
        Giá: " + dt.Rows[0]["GiaSP"] + @"
    </div>
</div>
";
        }

        return s;
    }

    protected void lbDauGia_OnClick(object sender, EventArgs e)
    {
        //Kiểm tra đăng nhập
        if (Session["KhachHang"] != null && Session["KhachHang"].ToString() == "1")
        {
            //Kiểm tra mức giá đưa ra có phải bội số của 1000 không
            int giaDaChon = int.Parse(tbGiaBanChon.Text);

            if (giaDaChon%1000 == 0)
            {
                //Kiểm tra tổng lượt bình chọn theo phiên và mã khách hàng (chỉ cho bình chọn 10 lần trên 1 phiên)
                if (TongLuotDauGia()<10)
                {
                    //Kiểm tra phiên đấu giá còn thời gian
                    if (ConThoiGianDauGia())
                    {
                        //Thực hiện đấu giá và gửi email thông báo
                        string maXacNhan = emdepvn.MaHoa.MaHoaMD5(hdMaKH.Value + hdMaPhienDauGia.Value + DateTime.Now.Ticks);

                        emdepvn.LuotDauGia.LuotDauGia_Inser(DateTime.Now.ToString(), tbGiaBanChon.Text, maXacNhan, hdMaKH.Value, hdMaPhienDauGia.Value, "");

                        //Gửi email thông báo tới khách hàng
                        #region Gửi email thông báo đến email hệ thống                    

                        string body = @"
<div style='font:normal 12px Arial;padding-bottom:15px'>
    Xin chào quý khách " + hdTenKH.Value + @"<br/>
    Chúng tôi xác nhận thông tin đấu giá của quý khách với thông tin như sau:<br/>
    <ul>
        <li>Sản phẩm đấu giá: " + hdTenSP.Value + @"</li>
        <li>Mức giá bạn chọn: " + tbGiaBanChon.Text + @"</li>
        <li>Mã xác nhận: " + maXacNhan + @" (Đây là mã duy nhất theo mỗi lần đấu giá, quý khách lưu ý giữ bí mật)</li>
    </ul>
    Sau thời gian hết hạn phiên đấu giá, chúng tôi sẽ gửi thông báo nếu quý khách chiến thắng.<br/>
    Trân trọng cảm ơn!
</div>";

                        //Gửi email tới khách hàng
                        TatThanhJsc.Extension.EmailExtension.SendEmail(hdEmailKH.Value, "Xác nhận lượt đấu giá từ emdep.vn", body, "test.email.x111@gmail.com");
                        #endregion

                        //Thông báo thành công
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Xin chúc mừng quý khách đã gửi đấu giá thành công. Chúng tôi đã gửi email xác nhận cho quý khách. Sau khi hết hạn phiên đấu giá chung tối sẽ thông báo kết quả nếu quý khách chiến thắng.');", true);
                    }
                    else
                    {
                        //Xuất ra script alert để báo khách hàng phiên đấu giá chưa tới hoặc đã hết hạn
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Phiên đấu giá đã hết hạn hoặc chưa được bắt đầu');", true);
                    }
                }
                else
                {
                    //Xuất ra script alert để báo khách hàng đã hết lượt đấu gúa
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Quý khách đã hết lượt đấu giá cho phiên này, mỗi phiên quý khách được đấu giá tối đa 10 lượt.');", true);
                }
            }
            else
            {
                //Xuất ra script alert để báo khách hàng cần nhập giá là bội số của 1000đ
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Quý khách vui lòng chọn mức giá là bội số của 1000đ (ví dụ 2000đ, 15000đ...');", true);
            }
        }
        else
        {
            //Xuất ra script alert để báo khách hàng cần đăng nhập tài khoản
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Quý khách vui lòng đăng nhập tài khoản thành viên để tham gia đấu giá.');", true);
        }
    }

    private bool ConThoiGianDauGia()
    {
        bool kq = false;
        DataTable dt = emdepvn.PhienDauGia.Thongtin_PhienDauGia();
        if (dt.Rows.Count > 0)
        {
            if ((DateTime.Now - (DateTime) dt.Rows[0]["ThoiGianBatDau"]).TotalDays>0 &&
                (DateTime.Now - (DateTime) dt.Rows[0]["ThoiGianKetThuc"]).TotalDays<0)
                kq = true;
        }

        return kq;
    }

    private int TongLuotDauGia()
    {
        DataTable dt = emdepvn.LuotDauGia.Thongtin_LuotDauGia_by_makh_maphiendg(hdMaKH.Value, hdMaPhienDauGia.Value);
        return dt.Rows.Count;
    }
}