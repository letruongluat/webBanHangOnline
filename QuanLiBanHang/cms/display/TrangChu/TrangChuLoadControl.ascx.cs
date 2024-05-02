using emdepvn;
using System;
using System.Data;

public partial class cms_display_TrangChu_TrangChuLoadControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ltrSlide.Text = LaySlide();

            ltrNhomSanPham.Text = LayNhomSanPham();
        }
    }

    #region Lấy nhóm và các sản phẩm
    private string LayNhomSanPham()
    {
        string s = "";
        DataTable dt = new DataTable();
        dt = emdepvn.NhomSanPham.Thongtin_Nhomsp();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            s += "<div class='sanphamnoibat'>";
            s += @"
<div class='title-line'>
    <h3>" + dt.Rows[i]["TenNhom"] + @"</h3>
</div>
";
            s += "<div>";
            s += LayDanhSachSanPhamTheoNhom(dt.Rows[i]["NhomID"].ToString(), dt.Rows[i]["SoSPHienThi"].ToString());
            s += "</div>";
            s += "<div style='clear:both'></div>";
            s += "</div>";
        }

        return s;
    }

    private string LayDanhSachSanPhamTheoNhom(string NhomID, string SoSPHienThi)
    {
        string s = "";
        DataTable dt = new DataTable();
        dt = emdepvn.SanPham.Thongtin_Sanpham_by_nhomid(NhomID, SoSPHienThi);

        string link = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            link = "Default.aspx?modul=SanPham&modulphu=ChiTietSanPham&id=" + dt.Rows[i]["MaSP"];

            s += @"
<div class='item'>
    <a href='" + link + @"' title='" + dt.Rows[i]["TenSP"] + @"'>
        <img src='/pic/sanpham/" + dt.Rows[i]["AnhSP"] + @"' alt='" + dt.Rows[i]["TenSP"] + @"' />
    </a>
    <a class='title-sp' href='" + link + @"' title='" + dt.Rows[i]["TenSP"] + @"'>
        " + dt.Rows[i]["TenSP"] + @"
    </a>
    <div class='desc'>
        Giá: " + dt.Rows[i]["GiaSP"] + @"
    </div>
</div>
";
        }
        return s;
    }

    #endregion

    #region Lấy logo
    private string LaySlide()
    {
        string s = "";

        //Code lấy ra vị trí quảng nhóm cáo
        DataTable dt = new DataTable();
        dt = emdepvn.NhomQuangCao.Thongtin_Nhomquangcao_by_vitriqc("slide");

        //Nếu tồn tại vị trí nhóm quảng cáo --> tìm quảng cáo trong nhóm đó
        if (dt.Rows.Count > 0)
        {
            //Gọi tới phương thức lấy ảnh quảng cáo theo id nhóm quảng cáo
            s = LayAnhSlide(dt.Rows[0]["NhomQuangCaoID"].ToString());
        }

        return s;
    }

    private string LayAnhSlide(string nhomQuangCaoID)
    {
        string s = "";

        DataTable dt = new DataTable();
        dt = QuangCao.Thongtin_Quangcao_by_nhomquangcaoid(nhomQuangCaoID);
        if (dt.Rows.Count > 0)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                s += @"
<div data-p='225.00' style='display: none;'>                      
    <img data-u='image' src='/pic/quangcao/" + dt.Rows[i]["AnhQC"] + @"' alt='" + dt.Rows[i]["TenQC"] + @"' />
</div>";
            }
            
        }

        return s;
    }
    #endregion
}