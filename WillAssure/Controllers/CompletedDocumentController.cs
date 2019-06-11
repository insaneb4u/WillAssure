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
    public class CompletedDocumentController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: CompletedDocument
        public ActionResult CompletedDocumentIndex()
        {








                int testatorid = 0;

           
                con.Open();
                string query1 = "select tId from  TestatorDetails where  uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    testatorid = Convert.ToInt32(dt1.Rows[0]["tId"]);
                    ViewBag.testatorid = testatorid;

                }
                con.Close();





            con.Open();
            string query2 = "select Will , Codocil , POA , Giftdeeds , LivingWill  from users where uId =  " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();



            if (Convert.ToInt32(dt2.Rows[0]["Will"]) == 1)
            {
                con.Open();
                string query3 = "select * from appointees where doctype = 'will' and tid = "+ testatorid + "";
                SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    ViewBag.documentbtn1 = "true";
                }
              
                con.Close();


            }





            if (Convert.ToInt32(dt2.Rows[0]["POA"]) == 1)
            {
                con.Open();
                string query4 = "select * from appointees where doctype = 'POA' and tid = "+ testatorid + "";
                SqlDataAdapter da4 = new SqlDataAdapter(query4, con);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                if (dt4.Rows.Count > 0)
                {
                    ViewBag.documentbtn3 = "true";
                }

                con.Close();


            }





            if (Convert.ToInt32(dt2.Rows[0]["Giftdeeds"]) == 1)
            {
                con.Open();
                string query5 = "select * from appointees where doctype = 'Giftdeeds' and tid = "+ testatorid + "";
                SqlDataAdapter da5 = new SqlDataAdapter(query5, con);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);
                if (dt5.Rows.Count > 0)
                {
                    ViewBag.documentbtn4 = "true";
                }

                con.Close();


            }



            if (ViewBag.documentbtn1 == null && ViewBag.documentbtn3 == null && ViewBag.documentbtn4 == null)
            {
                ViewBag.empty = "true";
            }





            return View("~/Views/CompletedDocument/Completeddocumentpagecontent.cshtml");
        }
    }
}