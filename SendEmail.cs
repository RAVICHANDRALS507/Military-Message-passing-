using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace MilitaryMessage
{
    public class SendEmail
    {
        public static void Send(string EmailID, string Message)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("mmpsnie@gmail.com", "hsxukiulnsbdrzjz");
            smtp.EnableSsl = true;

            MailAddress _from = new MailAddress("mmpsnie@gmail.com");
            MailAddress _to = new MailAddress(EmailID);

            MailMessage mail = new MailMessage(_from, _to);
            mail.Subject = "Login Credentials ";
            mail.Body = "<font size=15> Your <br> " + Message + "</font>";
            mail.IsBodyHtml = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void Send(string EmailID, string Message, string Sub)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("mmpsnie@gmail.com", "hsxukiulnsbdrzjz");
            smtp.EnableSsl = true;

            MailAddress _from = new MailAddress("mmpsnie@gmail.com");
            MailAddress _to = new MailAddress(EmailID);

            MailMessage mail = new MailMessage(_from, _to);
            mail.Subject = Sub;
            mail.Body = "<font size=15> Your <br> " + Message + "</font>";
            mail.IsBodyHtml = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}