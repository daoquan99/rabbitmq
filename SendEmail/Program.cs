using System;
using System.Net.Mail;

namespace SendEmail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string emailAddress = "ungdungnoibo@mpi.gov.vn";
            string ipAddress = "10.2.1.18";
            string emailNguoiNhan = "gemtest1@mpi.gov.vn";
            string tieuDe = "Test send email";
            string noiDung = "Test send email";
            MailMessage mail = new MailMessage(emailAddress, emailNguoiNhan, tieuDe, noiDung);
            mail.SubjectEncoding = System.Text.UTF8Encoding.UTF8;
            mail.BodyEncoding = System.Text.UTF8Encoding.UTF8;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient(ipAddress);
            smtp.Send(mail);

            Console.ReadKey();
        }
    }
}
