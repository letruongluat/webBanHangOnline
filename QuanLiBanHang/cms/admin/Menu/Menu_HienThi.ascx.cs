using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cms_admin_Menu_Menu_HienThi : System.Web.UI.UserControl
{
    string mamenucha = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["mamenucha"] != null)
            mamenucha = Request.QueryString["mamenucha"];
        if (!IsPostBack)
            LayMenu();
    }

    private void LayMenu()
    {
        DataTable dt = new DataTable();
        dt = emdepvn.Menu.Thongtin_Menu_by_MaMenuCha(mamenucha);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ltrMenu.Text += @"
          
           <tr id='maDong_" + dt.Rows[i]["MaMenu"] + @"'>
               <td class='cotMa'>" + dt.Rows[i]["MaMenu"] + @"</td>
               <td class='cotTen'>" + dt.Rows[i]["TenMenu"] + @"</td>
               <td class='cotThuTu'>" + dt.Rows[i]["ThuTuMenu"] + @"</td>
               <td class='cotCongCu'>";
            if (CoMenuCon(dt.Rows[i]["MaMenu"].ToString()))
                ltrMenu.Text += @"<a href='Admin.aspx?modul=Menu&modulphu=DanhSachMenu&mamenucha=" + dt.Rows[i]["MaMenu"] + @"' class='dmcon' title='Xem menu con'></a>";
                ltrMenu.Text += @"
               <a href='Admin.aspx?modul=Menu&modulphu=DanhSachMenu&thaotac=ChinhSua&id=" + dt.Rows[i]["MaMenu"] + @"' class='sua' title='Sửa'></a>
               <a href='javascript:XoaMenu(" + dt.Rows[i]["MaMenu"] + @")' class='xoa' title='Xóa'></a>
               </td>
           </tr>
";
        }
        
    }

    //Hàm kiểm tra danh mục có danh mục con hay ko
    bool CoMenuCon(string MaMenuCha)
    {
        DataTable dt = new DataTable();
        dt = emdepvn.Menu.Thongtin_Menu_by_MaMenuCha(MaMenuCha);
        if (dt.Rows.Count > 0)
            return true;
        else
            return false;
    }
}