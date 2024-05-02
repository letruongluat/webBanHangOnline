using System;
using System.Net.Mail;
using System.Net;
using TatThanhJsc.Extension;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Email
/// </summary>
namespace TatThanhJsc.Extension
{
    public class EmailExtension
    {
        /// <summary>
        /// Kiểm tra xem email có hợp lệ hay không
        /// </summary>
        /// <param name="email">địa chỉ email</param>
        /// <returns></returns>
        public static bool TestEmail(string email)
        {
            string pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            return Regex.IsMatch(email, pattern);
        }
        /// <summary>
        /// Gửi mail đến địa chỉ SendTo thông qua tài khoản và mật khẩu quản trị website và trả về kết quả gửi email.
        /// <c>
        /// <code>
        /// Phương thức này sẽ sử dụng tài khoản và mật khẩu được quản trị trong "hệ thống/email hệ thống" để gửi email thông qua smtp.gmail.com
        /// </code>
        /// </c>
        /// </summary>       
        /// <param name="SendTo">Email người nhận (vd: example@gmail.com)</param>
        /// <param name="Subject">Tiêu đề email</param>
        /// <param name="Body">Nội dung email</param>
        /// <param name="MailCCAddress">Danh sách các địa chỉ cc</param>
        /// <returns></returns>
        public static string SendEmail(string SendTo, string Subject, string Body, params string[] MailCCAddress)
        {

            
            string SendFrom = "test.email.x111@gmail.com";
            string password = "nguyenvanhoalh";

            int portGmail = 587;
            if (!TestEmail(SendTo))
            {
                return "Địa chỉ email không hợp lệ.";
            }
            else
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", portGmail);
                client.EnableSsl = true;
                MailAddress from = new MailAddress(SendFrom, "emdep.vn - Triệu người bán, tỷ người mua");
                MailAddress to = new MailAddress(SendTo, "emdep.vn - Triệu người bán, tỷ người mua");
                MailMessage message = new MailMessage(from, to);
                message.Body = Body;
                message.Subject = Subject;
                message.IsBodyHtml = true;

                foreach (var item in MailCCAddress)
                {
                    if (TestEmail(item))
                    {
                        MailAddress copy = new MailAddress(item);
                        message.CC.Add(copy);
                    }
                }

                NetworkCredential myCreds = new NetworkCredential(SendFrom, password);
                client.Credentials = myCreds;
                try
                {
                    client.Send(message);
                    return "Đã gửi Email thành công";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
