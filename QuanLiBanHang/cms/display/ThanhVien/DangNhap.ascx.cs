using System;
using System.Data;
using System.Web.UI;

public partial class cms_display_ThanhVien_DangNhap : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbtDangNhap_Click(object sender, EventArgs e)
    {
        //kiểm tra database có tên đăng nhập và mật khẩu này không?=>có=>xác nhận đăng nhập thành công
        DataTable dt = new DataTable();
        dt = emdepvn.KhachHang.Thongtin_Khachhang_by_emailkh_matkhau(tbEmail.Text,
            emdepvn.MaHoa.MaHoaMD5(tbMatKhau.Text));
            
        if (dt.Rows.Count > 0)
        {
            //Đăng nhập thành công --> Lưu giá trị vào session để đánh dấu đăng nhập thành công
            Session["KhachHang"] = "1"; //Thể hiện đã đăng nhập thành công

            //Gán thêm thông tin tài khoản đã đăng nhập
            Session["MaKH"] = dt.Rows[0]["MaKH"];
            Session["TenKh"] = dt.Rows[0]["TenKh"];
            Session["DiaChiKH"] = dt.Rows[0]["DiaChiKH"];
            Session["sdtKH"] = dt.Rows[0]["sdtKH"];
            Session["EmailKH"] = dt.Rows[0]["EmailKH"];

            Response.Redirect("/Default.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this,this.GetType(),"", "alert('Tên đăng nhập hoặc mật khẩu không chính xác!');", true);
        }
    }
}