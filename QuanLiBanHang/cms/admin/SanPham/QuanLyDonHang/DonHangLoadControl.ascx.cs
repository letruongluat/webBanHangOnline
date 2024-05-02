using System;

public partial class cms_admin_SanPham_QuanLyDonHang_DonHangLoadControl : System.Web.UI.UserControl
{
    private string thaotac = "null";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["thaotac"] != null)
            thaotac = Request.QueryString["thaotac"];
        switch (thaotac)
        {            
            case "HienThi":
                plLoadControl.Controls.Add(LoadControl("DonHang_HienThi.ascx"));
                break;

            case "ChiTiet":
                plLoadControl.Controls.Add(LoadControl("DonHang_ChiTiet.ascx"));
                break;

            default:
                plLoadControl.Controls.Add(LoadControl("DonHang_HienThi.ascx"));
                break;

        }
    }
}