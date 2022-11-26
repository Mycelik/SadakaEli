using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Utilities.Helpers
{
    public static class MailHelper
    {
        public static void Send(string to,string subject,string message)
        {

            string from = "prdxlastr@gmail.com";
            MailMessage msg = new MailMessage(from, to,subject,message);
            msg.IsBodyHtml = true;

            
            
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("prdxlastr@gmail.com", "256581rake");
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(msg);
        }
    }
}
