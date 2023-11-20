using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Security.Cryptography;


public partial class NewEmp : System.Web.UI.Page
{

    SqlConnection cn;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        generateID();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {       
        try
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["EMP"]);
            cmd = new SqlCommand();
            cn.Open();
            string img = "Photo" + "_" + txtempid.Text + ".jpg";

            cmd.CommandText = "insert into Registration(empid,empname,dob,gender,address,emailid,mobile,username,pwd,photo,status,groupname)values(@empid,@empname,@dob,@gender,@address,@emailid,@mobile,@username,@pwd,@photo,@status,@groupname)";

            cmd.Parameters.AddWithValue("@empid", txtempid.Text);
            cmd.Parameters.AddWithValue("@empname", txtname.Text);

            cmd.Parameters.AddWithValue("@dob", txtdob.Text);
            cmd.Parameters.AddWithValue("@gender", rbgender.SelectedItem.Value.ToString());
            cmd.Parameters.AddWithValue("@address", txtadd.Text);

            cmd.Parameters.AddWithValue("@emailid", txtemail.Text);
            cmd.Parameters.AddWithValue("@mobile", txtmob.Text);
            cmd.Parameters.AddWithValue("@username",txtempid.Text);
           // cmd.Parameters.AddWithValue("@username", txtusername.Text);

            //cmd.Parameters.AddWithValue("@pwd",Encrypt(txtpwd.Text.Trim()));
            cmd.Parameters.AddWithValue("@pwd", txtpwd.Text.Trim());
            cmd.Parameters.AddWithValue("@photo", img);
            cmd.Parameters.AddWithValue("@status", "Accept");

            //cmd.Parameters.AddWithValue("@company", txtCompany.Text);
            cmd.Parameters.AddWithValue("@groupname", "All");
            cmd.Connection = cn;

            int n = cmd.ExecuteNonQuery();

            cn.Close();

            if (n > 0)
            {
                
                if (fuphoto.HasFile)
                {

                    fuphoto.SaveAs(Server.MapPath("~/employee/photos/" + img));
                    Directory.CreateDirectory(Server.MapPath("~/employee/task/" + txtempid.Text));
                }
                string msg = "Your Login Credential are : %0a Emp ID : " + txtusername.Text + " %0a password : " + txtpwd.Text + "%0a Do not share with anyone.";
                BasicCode b = new BasicCode();
                b.SendSms("EMPTTS", txtmob.Text, msg);
              // lblmsg.Text = "User Registrered Successfully !";

               txtadd.Text = "";
               txtdob.Text = "";
               txtemail.Text = "";
               txtempid.Text = "";
               txtmob.Text = "";
               txtname.Text = "";
               txtpwd.Text = "";
               txtusername.Text = "";

               Response.Redirect("Success.aspx");
            }
            else
            {
                // lblmsg.Text = "Unabled To Insert....";
                Response.Write("Unabled To Insert....");
            }
        }
        catch (Exception er)
        {
            Response.Write(er.ToString());
        }
         

    }
    protected void generateID()
    {
        cn = new SqlConnection(ConfigurationManager.AppSettings["EMP"]);
        cmd = new SqlCommand();
        cn.Open();

        cmd.CommandText = "select empid from Registration order by empid desc";
        cmd.Connection = cn;

        object obj = cmd.ExecuteScalar();
        if (obj == null)
        {
            txtempid.Text = "1";
            
        }
        else
        {
            int n = Convert.ToInt32(obj);
            n = n + 1;
            txtempid.Text = n.ToString();
        }
        cn.Close();

    }

    protected string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
    protected void txtusername_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtusername.Text))
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["LIS"]);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Registration where username=@Name", con);
            cmd.Parameters.AddWithValue("@Name", txtusername.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                checkusername.Visible = true;
                //imgstatus.ImageUrl = "NotAvailable.jpg";    
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "UserName Already Taken";
                txtusername.Focus();
            }
            else
            {
                checkusername.Visible = true;
                //imgstatus.ImageUrl = "Icon_Available.gif";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "UserName Available";
            }
        }
        else
        {
            checkusername.Visible = false;
        }
    }
}