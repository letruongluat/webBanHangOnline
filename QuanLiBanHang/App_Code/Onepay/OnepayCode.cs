
/// <summary>
/// Lưu các mã cho tài khoản onepay
/// </summary>
public class OnepayCode
{
    public const string VPCRequest = "http://mtf.onepay.vn/onecomm-pay/vpc.op";//Url payment thật: https://onepay.vn/onecomm-pay/vpc.op 
    public const string Merchant = "ONEPAY";     
    public const string AccessCode = "D67342C2";
    public const string SECURE_SECRET = "A3EFDFABA8653DF2342E8DAC29B51AF0";    

    public static string ReturnURL = "http://localhost:1835/onepay/vpc_dr.aspx";




     
}