using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cms_admin_SanPham_QuanLyPhienDauGia_PhienDauGia_ThemMoi : System.Web.UI.UserControl
{
    private string thaotac = "";
    private string id = "";//lấy id của nhóm sản phẩm cần chỉnh sửa
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["thaotac"] != null)
            thaotac = Request.QueryString["thaotac"];
        if (Request.QueryString["id"] != null)
            id = Request.QueryString["id"];
        if (!IsPostBack)
        {
            HienThiThongTin(id);
        }
    }

    private void HienThiThongTin(string id)
    {
        if (thaotac == "ChinhSua")
        {
            btThemMoi.Text = "Chỉnh Sửa";
            cbThemNhieuNhom.Visible = false;

            DataTable dt = new DataTable();
            dt = emdepvn.PhienDauGia.Thongtin_PhienDauGia_by_id(id);
            if (dt.Rows.Count > 0)
            {
                tbThoiGianBatDau.Text = dt.Rows[0]["ThoiGianBatDau"].ToString();
                tbThoiGianKetThuc.Text = dt.Rows[0]["ThoiGianKetThuc"].ToString();
                tbMaSP.Text = dt.Rows[0]["MaSP"].ToString();
                tbGiaDeXuat.Text = dt.Rows[0]["GiaDeXuat"].ToString();
            }
        }

        else
        {
            tbThoiGianBatDau.Text = DateTime.Now.ToString();
            tbThoiGianKetThuc.Text = DateTime.Now.ToString();

            btThemMoi.Text = "Thêm Mới";
            cbThemNhieuNhom.Visible = true;
        }

    }
    protected void btThemMoi_Click(object sender, EventArgs e)
    {
        if (thaotac == "ThemMoi")
        {
            #region code nút thêm mới

           
            emdepvn.PhienDauGia.PhienDauGia_Inser(tbThoiGianBatDau.Text,tbThoiGianKetThuc.Text,tbMaSP.Text,tbGiaDeXuat.Text,"");
            ltrThongBao.Text = "<div class='thongBaoTaoThanhCong' style='color:#ff006e;font-size:16px;padding-bottom:20px;text-align:center;font-weight:bold'>Đã tạo phiên từ " + tbThoiGianBatDau.Text + " tới " + tbThoiGianKetThuc.Text + "</div>";

            if (cbThemNhieuNhom.Checked)
            {
                //viết code xử lý xóa mục đã nhập để người dùng nhập danh mục tiếp theo
                ResetControl();
            }

            else
            {
                //đẩy trang về trang danh sách các damnh mục đã tạo

                Response.Redirect("Admin.aspx?modul=SanPham&modulphu=PhienDauGia");
            }
            #endregion
        }
        else
        {
            #region code nút chỉnh sửa
           

            emdepvn.PhienDauGia.PhienDauGia_Update(id, tbThoiGianBatDau.Text,tbThoiGianKetThuc.Text,tbMaSP.Text,tbGiaDeXuat.Text);

            //đẩy trang về trang danh sách các damnh mục đã tạo
            Response.Redirect("Admin.aspx?modul=SanPham&modulphu=PhienDauGia");

            #endregion
        }
    }

    private void ResetControl()
    {
        tbThoiGianBatDau.Text = DateTime.Now.ToString();
        tbThoiGianKetThuc.Text = DateTime.Now.ToString();
        tbMaSP.Text = "";
        tbGiaDeXuat.Text = "";

    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        ResetControl();
    }
}