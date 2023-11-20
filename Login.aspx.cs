﻿using System;
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
public partial class Login : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        //ClassCheck cs = new ClassCheck();
        //cs.lis(Server.MapPath("MasterPage.master"), Server.MapPath("MasterPage.master.cs"), Server.MapPath("web.config"));
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (Session["userid"] == null)
        {
            //Response.Write("You are already logout !");
        }


        hfUser.Value = txtuser.Text.Trim();
        hfPwd.Value = txtpwd.Text.Trim();
        //hfPwd.Value = Encrypt( txtpwd.Text.Trim());


        if (ddltype.SelectedItem.Value.ToString() == "Admin")
        {
            if (txtuser.Text == "admin" && txtpwd.Text == "super")
            {
                Session.Add("userid", txtuser.Text);
                Response.Redirect("admin/Default.aspx");
            }
            else
            {
                lblmsg.Text = "Invalid Username and Password !";
                txtuser.Text = "";
                txtuser.Focus();
                txtpwd.Text = "";
            }

        }

        else if (ddltype.SelectedItem.Value.ToString() == "Teamleader")
        {
            if (txtuser.Text == "team" && txtpwd.Text == "team123")
            {
                Session.Add("userid", txtuser.Text);
                Response.Redirect("TeamLeader/Default.aspx");
            }
            else
            {
                lblmsg.Text = "Invalid Username and Password !";
                txtuser.Text = "";
                txtuser.Focus();
                txtpwd.Text = "";
            }
        }

        else
        {

            DataView dv = (DataView)SqlDataLogin.Select(new DataSourceSelectArguments());
            if (dv.Count == 0)
            {
                
                lblmsg.Text = "Invalid username and password !";
               
            }
            else
            {
                string status=dv[0][2].ToString();
                if (status == "pending")
                {
                    lblmsg.Text = "Account Status is Pending !";

                }
                else
                {
                    Session.Add("userid", hfUser.Value);
                    Session.Add("pwd", hfPwd.Value);
                    Response.Redirect("employee/Default.aspx");

                }
            }



        }
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
}