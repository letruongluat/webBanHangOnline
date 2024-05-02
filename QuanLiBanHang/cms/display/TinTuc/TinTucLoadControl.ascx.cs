using System;

public partial class cms_display_TinTuc_TinTucLoadControl : System.Web.UI.UserControl
{
    private string modulphu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["modulphu"] != null)
            modulphu = Request.QueryString["modulphu"];
        switch (modulphu)
        {
            case "DanhSachTinTuc":
                plLoadControl.Controls.Add(LoadControl("DanhSachCacTinTuc.ascx"));
                break;

            case "ChiTietTinTuc":
                plLoadControl.Controls.Add(LoadControl("ChiTietTinTuc.ascx"));
                break;

            default:
                plLoadControl.Controls.Add(LoadControl("TrangChuModulTinTuc.ascx"));
                break;


        }
    }
}