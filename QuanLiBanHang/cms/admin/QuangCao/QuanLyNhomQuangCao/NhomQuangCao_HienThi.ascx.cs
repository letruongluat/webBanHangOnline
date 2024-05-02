using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cms_admin_QuangCao_QuanLyNhomQuangCao_NhomQuangCao_HienThi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LayNhomQuangCao();
    }

     private void LayNhomQuangCao()
    {
        DataTable dt = new DataTable();
        dt = emdepvn.NhomQuangCao.Thongtin_Nhomquangcao();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ltrNhomQuangCao.Text += @"
<tr id='maDong_" + dt.Rows[i]["NhomQuangCaoID"] + @"'>
           <td class='cotMa'>" + dt.Rows[i]["NhomQuangCaoID"] + @"</td>
           <td class='cotTen'>" + dt.Rows[i]["TenNhomQuangCao"] + @"</td>
           <td class='cotViTri'>" + dt.Rows[i]["ViTriQC"] + @"</td>
           <td class='cotAnh'>
             <img class='anhDaiDien'src='/pic/QuangCao/" + dt.Rows[i]["AnhDaiDienQC"] + @"'/>
             <img class='anhDaiDienHover'src='/pic/QuangCao/" + dt.Rows[i]["AnhDaiDienQC"] + @"'/>
           </td>
           <td class='cotThuTu'>" + dt.Rows[i]["ThuTuNhomQC"] + @"</td>
           <td class='cotCongCu'>
               <a href='Admin.aspx?modul=QuangCao&modulphu=NhomQuangCao&thaotac=ChinhSua&id=" + dt.Rows[i]["NhomQuangCaoID"] + @"' class='sua' title='Sửa'></a>
               <a href='javascript:XoaNhomQuangCao(" + dt.Rows[i]["NhomQuangCaoID"] + @")' class='xoa' title='Xóa'></a>
           </td>
</tr>
";
        }

    }
}
