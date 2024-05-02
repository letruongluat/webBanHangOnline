using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;


public partial class cms_admin_Menu_Menu_ThemMoi : System.Web.UI.UserControl
{
    private string thaotac = "";
    private string id = "";//lấy id của danh mục cần chỉnh sửa
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["thaotac"] != null)
            thaotac = Request.QueryString["thaotac"];
        if (Request.QueryString["id"] != null)
            id = Request.QueryString["id"];
        if (!IsPostBack)
        {

            LayMenuCha();

            HienThiThongTin(id);
        }
            
    }

    private void HienThiThongTin(string id)
    {
        if(thaotac=="ChinhSua")
        {
            btThemMoi.Text = "Chỉnh Sửa";
            cbThemNhieuDanhMuc.Visible = false;

            DataTable dt = new DataTable();
            dt = emdepvn.Menu.Thongtin_Menu_by_id(id);
            if(dt.Rows.Count>0)
            {
                ddlMenuCha.SelectedValue = dt.Rows[0]["MaMenuCha"].ToString();
                tbTenMenu.Text = dt.Rows[0]["TenMenu"].ToString();
                tbLienKet.Text = dt.Rows[0]["LienKet"].ToString();
                tbThuTu.Text = dt.Rows[0]["ThuTuMenu"].ToString();
            }
        }

        else
        {
            btThemMoi.Text = "Thêm Mới";
            cbThemNhieuDanhMuc.Visible = true;
        }

    }
    private void LayMenuCha()
    {
        DataTable dt = new DataTable();
        dt = emdepvn.Menu.Thongtin_Menu_by_MaMenuCha("0");
        ddlMenuCha.Items.Clear();

        ddlMenuCha.Items.Add(new ListItem("Menu gốc","0"));
        for(int i = 0 ; i<dt.Rows.Count ; i++)
        {
            ddlMenuCha.Items.Add(new ListItem(dt.Rows[i]["TenMenu"].ToString(), dt.Rows[i]["MaMenu"].ToString()));
            LayMenuCon(dt.Rows[i]["MaMenu"].ToString(), "___");
        }
    }

    private void LayMenuCon(string MaMenuCha, string KhoangCach)
    {
        DataTable dt = new DataTable();
        dt = emdepvn.Menu.Thongtin_Menu_by_MaMenuCha(MaMenuCha);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddlMenuCha.Items.Add(new ListItem(KhoangCach + dt.Rows[i]["TenMenu"].ToString(), dt.Rows[i]["MaMenu"].ToString()));
            LayMenuCon(dt.Rows[i]["MaMenu"].ToString(), KhoangCach + "___");
        }
    }
    protected void btThemMoi_Click(object sender, EventArgs e)
    {
        if(thaotac=="ThemMoi")
        {
            #region code nút thêm mới

            emdepvn.Menu.Menu_Inser(
                tbTenMenu.Text, tbLienKet.Text, 
                ddlMenuCha.SelectedValue, tbThuTu.Text,"");
            ltrThongBao.Text = "<div class='thongBaoTaoThanhCong' style='color:#ff006e;font-size:16px;padding-bottom:20px;text-align:center;font-weight:bold'>Đã tạo danh mục: " + tbTenMenu.Text + "</div>";

            if (cbThemNhieuDanhMuc.Checked)
            {
                //viết code xử lý xóa mục đã nhập để người dùng nhập danh mục tiếp theo
                ResetControl();
            }

            else
            {
                //đẩy trang về trang danh sách các damnh mục đã tạo

                Response.Redirect("Admin.aspx?modul=Menu&modulphu=DanhSachMenu");
            }
            #endregion
        }
        else
        {
            #region code nút chỉnh sửa

            emdepvn.Menu.Menu_Update(id, tbTenMenu.Text, tbLienKet.Text,
                ddlMenuCha.SelectedValue, tbThuTu.Text);

             //đẩy trang về trang danh sách các damnh mục đã tạo
            Response.Redirect("Admin.aspx?modul=Menu&modulphu=DanhSachMenu");
            
            #endregion
        }
    }

    private void ResetControl()
    {
        tbTenMenu.Text = "";
        tbLienKet.Text = "";
        tbThuTu.Text = "";

    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        ResetControl();
    }
}