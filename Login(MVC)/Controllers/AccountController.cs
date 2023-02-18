using Login_MVC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Login_MVC_.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-25KBACP; database=WPF; integrated security=SSPI;"; 
        }
        [HttpPost]
        public ActionResult Verify(Account account)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tbl_login where username = '"+account.Name+"' and password = '"+account.Password+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
             
        }
    }
}