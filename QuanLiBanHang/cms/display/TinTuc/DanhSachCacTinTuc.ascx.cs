using System;
using System.Data;

public partial class cms_display_TinTuc_DanhSachCacTinTuc : System.Web.UI.UserControl
{
    private string id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
            id = Request.QueryString["id"];

        if (!IsPostBack)
        {
            ltrNhomTinTuc.Text = LayDanhMucTinTuc();
        }
    }

    #region Lấy nhóm và các tin tức
    private string LayDanhMucTinTuc()
    {
        string s = "";
        DataTable dt = new DataTable();
        dt = emdepvn.DanhMucTin.Thongtin_DanhmucTin_by_id(id);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            s += "<div class='sanphamnoibat'>";
            s += @"
<a class='title-line' href='/Default.aspx?modul=TinTuc&modulphu=DanhSachTinTuc&id=" + dt.Rows[i]["MaDM"] + @"' title='" + dt.Rows[i]["TenDM"] + @"'>
    <h3>" + dt.Rows[i]["TenDM"] + @"</h3>
</a>
";
            s += "<div>";
            s += LayTatCaDanhSachTinTucTheoDanhMuc(dt.Rows[i]["MaDM"].ToString());
            s += "</div>";
            s += "<div style='clear:both'></div>";
            s += "</div>";
        }

        return s;
    }

    private string LayTatCaDanhSachTinTucTheoDanhMuc(string MaDM)
    {
        string s = "";
        DataTable dt = new DataTable();
        dt = emdepvn.TinTuc.Thongtin_TinTuc_by_madm_tatca(MaDM);

        string link = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            link = "Default.aspx?modul=TinTuc&modulphu=ChiTietTinTuc&id=" + dt.Rows[i]["TinTucID"];

            s += @"
<div class='itemtintuc'>
    <div class='khungAnh'>
        <a class='khungAnhCrop' href='" + link + @"'>
            <img class='imganh' src='/pic/tintuc/" + dt.Rows[i]["AnhDaiDien"] + @"' alt='" + dt.Rows[i]["TieuDe"] + @"' />
        </a>
    </div>
    <div class='itemContent'>
        <a href='" + link + @"' class='title' title='" + dt.Rows[i]["TieuDe"] + @"'>
            " + dt.Rows[i]["TieuDe"] + @"
        </a>
        <span class=''><span class='view'>" + dt.Rows[i]["LuotXem"] + @"</span><span class='date'>" + ((DateTime)dt.Rows[i]["NgayDang"]).ToString("dd/MM/yyyy") + @"</span></span>
        <div class='desc'>
            " + dt.Rows[i]["MoTa"] + @"
        </div>
        <div class='tar'><a href='" + link + @"' class='detail'>Xem chi tiết</a></div>
    </div>
    <div class='cb'><!----></div>
</div>
";

        }
        return s;
    }

    #endregion
}