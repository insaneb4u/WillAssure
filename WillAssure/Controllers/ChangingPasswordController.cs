using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WillAssure.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WillAssure.Controllers
{
    public class ChangingPasswordController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: ChangingPassword
        public ActionResult ChangingPassword()
        {

            if (TempData["success"] != null)
            {
                if (TempData["success"].ToString() == "true")
                {
                    ViewBag.Message = "Verified";
                }

            }




            return View("~/Views/ChangingPassword/ChangingPasswordPageContent.cshtml");
        }


        public string checkoldpassword()
        {
            string response = Request["send"].ToString();
            string msg = "";
            con.Open();
            string checkquery = "select userPwd from users where uId = "+Convert.ToInt32(Session["uuid"])+"   ";
            SqlDataAdapter da = new SqlDataAdapter(checkquery,con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["userPwd"].ToString() == response)
                {
                    msg = "true";
                }
                else
                {
                    msg = "false";
                }

            }
            else
            {
                msg = "false";
            }

            con.Close();



            return msg;
        }





        public ActionResult Changepassword(RoleFormModel RFM)
        {

            con.Open();
            string query = "update users set userPwd='"+RFM.confirmpassword+"' where uId = "+Convert.ToInt32(Session["uuid"])+" ";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();



            TempData["success"] = "true";

            return RedirectToAction("ChangingPassword", "ChangingPassword");
        }
    }
}