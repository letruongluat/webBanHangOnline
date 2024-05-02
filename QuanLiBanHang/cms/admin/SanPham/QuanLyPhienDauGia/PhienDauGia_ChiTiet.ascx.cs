using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using emdepvn;

public partial class cms_admin_SanPham_QuanLyPhienDauGia_PhienDauGia_ChiTiet : System.Web.UI.UserControl
{
    private string id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
            id = Request.QueryString["id"];

        if (!IsPostBack)
        {
            LayThongTinPhienDauGia();
            LayCacLuotDauGiaTheoPhienDauGia();
        }
    }

    private void LayCacLuotDauGiaTheoPhienDauGia()
    {
        DataTable dt = LuotDauGia.Thongtin_LuotDauGia_by_maphiendg(id);
        for (int i = 0; i<dt.Rows.Count; i++)
        {
            ltrCacLuotDauGia.Text += @"
<tr>
    <td>"+(i+1)+@"</td>
    <td>"+dt.Rows[i]["ThoiGianDG"] + @"</td>
    <td>" + dt.Rows[i]["GiaDuaRa"] + @"</td>
    <td>" + dt.Rows[i]["MaXacNhan"] + @"</td>
    <td>" + dt.Rows[i]["MaKH"] + @"</td>
</tr>
";
        }

        //Nếu đã có lượt đấu giá thì bản ghi đầu tiên là người chiến thắng (bởi vì hàm lấy thông tin ở trên đã sắp xếp theo ưu tiên giá bé nhất và sớm nhất)
        if (dt.Rows.Count>0)
        {
            ltrThongTinKhachHangChienThang.Text = LayThongTinKHTheoMaKH(dt.Rows[0]["MaKH"].ToString()) + @"
Thời gian đấu giá: " + dt.Rows[0]["ThoiGianDG"] + @"<br/>
Mức giá đưa ra: " + dt.Rows[0]["GiaDuaRa"] + @"đ<br/>
Mã xác nhận: " + dt.Rows[0]["MaXacNhan"] + @"
";

            //Lưu thông tin người chiến thắng để gửi email
            hdGiaDuaRa.Value = dt.Rows[0]["GiaDuaRa"].ToString();
            hdMaXacNhan.Value = dt.Rows[0]["MaXacNhan"].ToString();
            hdThoiGianDauGia.Value = dt.Rows[0]["ThoiGianDG"].ToString();
        }
    }

    private string LayThongTinKHTheoMaKH(string MaKH)
    {
        DataTable dt = KhachHang.Thongtin_Khachhang_by_makh(MaKH);
        if (dt.Rows.Count>0)
        {
            hdTenKH.Value = dt.Rows[0]["TenKh"].ToString();
            hdEmailKH.Value = dt.Rows[0]["EmailKH"].ToString();

            return @"
Mã KH: " + dt.Rows[0]["MaKH"] + @"<br/>
Họ tên: " + dt.Rows[0]["TenKh"] + @"<br/>
Email: " + dt.Rows[0]["EmailKH"] + @"<br/>
Điện thoại: " + dt.Rows[0]["sdtKH"] + @"<br/>
Địa chỉ: " + dt.Rows[0]["DiaChiKH"] + @"<br/>
";
        }
        return "";
    }

    private void LayThongTinPhienDauGia()
    {
        DataTable dt = emdepvn.PhienDauGia.Thongtin_PhienDauGia_by_id(id);
        if (dt.Rows.Count > 0)
        {
            ltrThongTinPhienVaSanPham.Text =LayThongTinSanPham(dt.Rows[0]["MaSP"].ToString()) + @"
<div class='thoiGian'>Thời gian:<br/>Từ "+ dt.Rows[0]["ThoiGianBatDau"] + @" đến "+ dt.Rows[0]["ThoiGianKetThuc"] + @" <span class='trangThaiPhien'>("+LayTrangThaiPhienDauGia((DateTime)dt.Rows[0]["ThoiGianBatDau"],(DateTime)dt.Rows[0]["ThoiGianKetThuc"]) +@")</span></div>
<div class='giaDeXua'>Giá đề xuất: "+ dt.Rows[0]["GiaDeXuat"] + @"đ</div>
";
        }
    }

    private string LayThongTinSanPham(string MaSP)
    {
        string s = "";

        DataTable dt = emdepvn.SanPham.Thongtin_Sanpham_by_id(MaSP);
        if (dt.Rows.Count > 0)
        {
            hdTenSP.Value = dt.Rows[0]["TenSP"].ToString();

            s = @"
<img src='/pic/sanpham/" + dt.Rows[0]["AnhSP"] + @"' alt='" + dt.Rows[0]["TenSP"] + @"' />
<div class='tenSP'>" + dt.Rows[0]["TenSP"] + @"</div>
<div class='gia'>Giá: " + dt.Rows[0]["GiaSP"] + @"</div>";
        }

        return s;
    }

    private string LayTrangThaiPhienDauGia(DateTime dateTime1, DateTime dateTime2)
    {
        string ketQua = "";


        if ((DateTime.Now - dateTime1).TotalDays>0 &&
            (DateTime.Now - dateTime2).TotalDays<0)
            ketQua = "Đang diễn ra";
        else if ((DateTime.Now - dateTime1).TotalDays<=0)
            ketQua = "Chưa diễn ra";
        else        
            ketQua = "Đã kết thúc";
        
        return ketQua;
    }

    protected void lbtGuiThongBao_OnClick(object sender, EventArgs e)
    {
        //Gửi email thông báo tới khách hàng
        #region Gửi email thông báo đến email hệ thống                    

        string body = @"
<div style='font:normal 12px Arial;padding-bottom:15px'>
    Xin chào quý khách " + hdTenKH.Value + @"<br/>
    Chúng tôi rất vui được thông báo Quý khách đã chiến thắng trong phiên đấu giá:<br/>
    <ul>
        <li>Sản phẩm đấu giá: " + hdTenSP.Value + @"</li>
        <li>Thời gian đấu giá: " + hdThoiGianDauGia.Value + @"</li>
        <li>Mức giá bạn chọn: " + hdGiaDuaRa.Value + @"</li>
        <li>Mã xác nhận: " + hdMaXacNhan.Value + @" (Đây là mã duy nhất theo mỗi lần đấu giá, quý khách lưu ý giữ bí mật)</li>
    </ul>
    Chúng tôi sẽ sớm liên lạc và gửi sản phẩm tới quý khách.<br/>
    Trân trọng cảm ơn!
</div>";

        //Gửi email tới khách hàng
        TatThanhJsc.Extension.EmailExtension.SendEmail(hdEmailKH.Value, "Xác nhận chiến thắng trong phiên đấu giá từ emdep.vn", body, "test.email.x111@gmail.com");
        #endregion

        //Thông báo thành công
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Đã gửi email thông báo tới khách hàng chiến thắng.');", true);
    }
}