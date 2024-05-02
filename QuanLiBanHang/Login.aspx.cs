using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lbtDangNhap_Click(object sender, EventArgs e)
        {
            //kiểm tra database có tên đăng nhập và mật khẩu này không?=>có=>xác nhận đăng nhập thành công
            DataTable dt = emdepvn.DangKy.Thongtin_DangKy_by_id_matkhau(tbTenDangNhap.Text,
                emdepvn.MaHoa.MaHoaMD5(tbMatKhau.Text));
            if (dt.Rows.Count > 0)
            {
                //Đăng nhập thành công --> Lưu giá trị vào session để đánh dấu đăng nhập thành công
                Session["DangNhap"] = "1"; //Thể hiện đã đăng nhập thành công

                //Gán thêm thông tin tài khoản đã đăng nhập
                Session["TenDangNhap"] = dt.Rows[0]["TenDangNhap"];
                Response.Redirect("/Admin.aspx");
            }
            else
            {
                ltrThongBao.Text = "<div class='ThongBao'>Tên đăng nhập hoặc mật khẩu không chính xác!</div>";
            }

        }
    }
