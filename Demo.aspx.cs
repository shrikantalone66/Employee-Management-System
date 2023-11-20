using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
public partial class Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {




        string from = "mycollegeproject02@gmail.com";
        string to="amitssawarkar@gmail.com";
      

        using (MailMessage mm = new MailMessage(from, to))
        {
           
            mm.Subject ="Forget Password Phase"; 
            mm.Body = "Your password is : Amit123# \n Thank you ";           
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            NetworkCredential NetworkCred = new NetworkCredential("mycollegeproject02@gmail.com", "9503351933");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;

            smtp.Send(mm);
           
        }
    }
}