using System;
using System.Data;
using emdepvn;
using WebApplication2;

public partial class onepay_vpc_dr_quocte : System.Web.UI.Page
{
	protected string mathanhtoantructuyen = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string SECURE_SECRET = OnepayQuocTeCode.SECURE_SECRET;//Hòa: cần thay bằng mã thật từ app_code          
        string hashvalidateResult = "";
        // Khoi tao lop thu vien
        VPCRequest conn = new VPCRequest("http://onepay.vn");
        conn.SetSecureSecret(SECURE_SECRET);
        // Xu ly tham so tra ve va kiem tra chuoi du lieu ma hoa
        hashvalidateResult = conn.Process3PartyResponse(Request.QueryString);

        // Lay gia tri tham so tra ve tu cong thanh toan
        String vpc_TxnResponseCode = conn.GetResultField("vpc_TxnResponseCode", "Unknown");
        string amount = conn.GetResultField("vpc_Amount", "Unknown");
        string localed = conn.GetResultField("vpc_Locale", "Unknown");
        string command = conn.GetResultField("vpc_Command", "Unknown");
        string version = conn.GetResultField("vpc_Version", "Unknown");
        string cardType = conn.GetResultField("vpc_Card", "Unknown");
        string orderInfo = conn.GetResultField("vpc_OrderInfo", "Unknown");
        string merchantID = conn.GetResultField("vpc_Merchant", "Unknown");
        string authorizeID = conn.GetResultField("vpc_AuthorizeId", "Unknown");
        string merchTxnRef = conn.GetResultField("vpc_MerchTxnRef", "Unknown");
        string transactionNo = conn.GetResultField("vpc_TransactionNo", "Unknown");
        string acqResponseCode = conn.GetResultField("vpc_AcqResponseCode", "Unknown");
        string txnResponseCode = vpc_TxnResponseCode;
        string message = conn.GetResultField("vpc_Message", "Unknown");

        mathanhtoantructuyen = merchTxnRef;

        // Sua lai ham check chuoi ma hoa du lieu            
        if (hashvalidateResult == "CORRECTED" && txnResponseCode.Trim() == "0")
        {
            //vpc_Result.Text = "Transaction was paid successful";

            #region Cập nhật vào db theo mã đơn hàng

            DataTable dt = DonDatHang.Thongtin_Dondathang_by_maThanhToan(mathanhtoantructuyen);
            //Nếu tồn tại đơn hàng này --> cập nhật lại trạng thái
            if (dt.Rows.Count > 0)
            {
                string tinhTrangDonHang = "1";//1: có nghĩa là thành toán thành công
                DonDatHang.Dondathang_Update(dt.Rows[0]["MaDonDatHang"].ToString(), dt.Rows[0]["NgayTao"].ToString(), dt.Rows[0]["ThanhTienDH"].ToString(), tinhTrangDonHang, dt.Rows[0]["MaKH"].ToString(), dt.Rows[0]["TenKH"].ToString(), dt.Rows[0]["sdtKH"].ToString(), dt.Rows[0]["EmailKH"].ToString());
            }
            #endregion

            Response.Write("<div class='result'>Đã thanh toán thành công</div>");
        }
        else if (hashvalidateResult == "INVALIDATED" && txnResponseCode.Trim() == "0")
        {
            #region Cập nhật vào db theo mã đơn hàng

            DataTable dt = DonDatHang.Thongtin_Dondathang_by_maThanhToan(mathanhtoantructuyen);
            //Nếu tồn tại đơn hàng này --> cập nhật lại trạng thái
            if (dt.Rows.Count > 0)
            {
                string tinhTrangDonHang = "0";//1: có nghĩa là thành toán chưa thành công
                DonDatHang.Dondathang_Update(dt.Rows[0]["MaDonDatHang"].ToString(), dt.Rows[0]["NgayTao"].ToString(), dt.Rows[0]["ThanhTienDH"].ToString(), tinhTrangDonHang, dt.Rows[0]["MaKH"].ToString(), dt.Rows[0]["TenKH"].ToString(), dt.Rows[0]["sdtKH"].ToString(), dt.Rows[0]["EmailKH"].ToString());
            }
            #endregion

            //vpc_Result.Text = "Transaction is pending";
            Response.Write("Error description : " + message + "<br/>");
            Response.Write("<div class='result'>Thanh toán đang chờ</div>");
        }
        else
        {
            #region Cập nhật vào db theo mã đơn hàng

            DataTable dt = DonDatHang.Thongtin_Dondathang_by_maThanhToan(mathanhtoantructuyen);
            //Nếu tồn tại đơn hàng này --> cập nhật lại trạng thái
            if (dt.Rows.Count > 0)
            {
                string tinhTrangDonHang = "0";//1: có nghĩa là thành toán chưa thành công
                DonDatHang.Dondathang_Update(dt.Rows[0]["MaDonDatHang"].ToString(), dt.Rows[0]["NgayTao"].ToString(), dt.Rows[0]["ThanhTienDH"].ToString(), tinhTrangDonHang, dt.Rows[0]["MaKH"].ToString(), dt.Rows[0]["TenKH"].ToString(), dt.Rows[0]["sdtKH"].ToString(), dt.Rows[0]["EmailKH"].ToString());
            }
            #endregion

            //vpc_Result.Text = "Transaction was not paid successful";
            Response.Write("Error description : " + message + "<br/>");
            Response.Write("<div class='result'>Thanh toán không thành công</div>");
        }

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "Redirect('" + TatThanhJsc.Website.URL.WebisteUrl + "', 6);", true);

        
    }
}