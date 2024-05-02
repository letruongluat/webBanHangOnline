using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cms_admin_QuangCao_QuanLyNhomQuangCao_NhomQuangCao_ThemMoi : System.Web.UI.UserControl
{
    private string thaotac = "";
    private string id = "";//lấy id của nhóm quảng cáo cần chỉnh sửa
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
            dt = emdepvn.NhomQuangCao.Thongtin_Nhomquangcao_by_id(id);
            if (dt.Rows.Count > 0)
            {
                tbTenNhomQC.Text = dt.Rows[0]["TenNhomQuangCao"].ToString();
                tbViTriQC.Text = dt.Rows[0]["ViTriQC"].ToString();
                tbThuTu.Text = dt.Rows[0]["ThuTuNhomQC"].ToString();
                ltrAnhDaiDien.Text = "<img class='anhDaiDien'src='/pic/QuangCao/" + dt.Rows[0]["AnhDaiDienQC"] + @"'/>";
                hdTenAnhDaiDienCu.Value = dt.Rows[0]["AnhDaiDienQC"].ToString();
            }
        }

        else
        {
            btThemMoi.Text = "Thêm Mới";
            cbThemNhieuNhom.Visible = true;
        }

    }
    protected void btThemMoi_Click(object sender, EventArgs e)
    {
        if (thaotac == "ThemMoi")
        {
            #region code nút thêm mới

            if (flAnhDaiDien.FileContent.Length > 0)
            {
                if (flAnhDaiDien.FileName.EndsWith(".jpeg") || flAnhDaiDien.FileName.EndsWith(".jpg") || flAnhDaiDien.FileName.EndsWith(".png") || flAnhDaiDien.FileName.EndsWith(".gif"))
                {
                    flAnhDaiDien.SaveAs(Server.MapPath("pic/QuangCao/") + flAnhDaiDien.FileName);
                }
            }
            //else ltrThongBao.Text = "Nhập sai hoặc thiếu thông tin! Mời nhập lại";


            emdepvn.NhomQuangCao.Nhomquangcao_Inser(tbTenNhomQC.Text, tbViTriQC.Text, tbThuTu.Text, flAnhDaiDien.FileName, "");
            ltrThongBao.Text = "<div class='thongBaoTaoThanhCong' style='color:#ff006e;font-size:16px;padding-bottom:20px;text-align:center;font-weight:bold'>Đã tạo danh mục: " + tbTenNhomQC.Text + "</div>";

            if (cbThemNhieuNhom.Checked)
            {
                //viết code xử lý xóa mục đã nhập để người dùng nhập danh mục tiếp theo
                ResetControl();
            }

            else
            {
                //đẩy trang về trang danh sách các damnh mục đã tạo

                Response.Redirect("Admin.aspx?modul=QuangCao&modulphu=NhomQuangCao");
            }
            #endregion
        }
        else
        {
            #region code nút chỉnh sửa
            string tenAnhDaiDien = "";

            if (flAnhDaiDien.FileContent.Length > 0)
            {
                if (flAnhDaiDien.FileName.EndsWith(".jpeg") || flAnhDaiDien.FileName.EndsWith(".jpg") || flAnhDaiDien.FileName.EndsWith(".png") || flAnhDaiDien.FileName.EndsWith(".gif"))
                {
                    flAnhDaiDien.SaveAs(Server.MapPath("pic/QuangCao/") + flAnhDaiDien.FileName);
                    tenAnhDaiDien = flAnhDaiDien.FileName;

                    // viết đoạn code xóa ảnh đại diện cũ tại đây - tạm thời chưa viết
                }
            }

            if (tenAnhDaiDien == "")
            {
                tenAnhDaiDien = hdTenAnhDaiDienCu.Value;
            }

            emdepvn.NhomQuangCao.Nhomquangcao_Update(id, tbTenNhomQC.Text, tbViTriQC.Text, tbThuTu.Text, flAnhDaiDien.FileName);

            //đẩy trang về trang danh sách các damnh mục đã tạo
            Response.Redirect("Admin.aspx?modul=QuangCao&modulphu=NhomQuangCao");

            #endregion
        }
    }

    private void ResetControl()
    {
        tbTenNhomQC.Text = "";
        tbViTriQC.Text = "";
        tbThuTu.Text = "";

    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        ResetControl();
    }
}