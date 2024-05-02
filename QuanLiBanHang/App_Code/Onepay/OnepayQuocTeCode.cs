
/// <summary>
/// Lưu các mã cho tài khoản onepay
/// </summary>
public class OnepayQuocTeCode
{
    public const string VPCRequest = "http://mtf.onepay.vn/vpcpay/vpcpay.op";//Url payment thật: https://onepay.vn/onecomm-pay/vpc.op 
    public const string Merchant = "TESTONEPAY";    
    public const string AccessCode = "6BEB2546";
    public const string SECURE_SECRET = "6D0870CDE5F24F34F3915FB0045120DB";

    public static string ReturnURL = "http://localhost:1835/onepay/vpc_dr_quocte.aspx";

    
}