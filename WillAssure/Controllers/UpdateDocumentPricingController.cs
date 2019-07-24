using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using WillAssure.Models;

namespace WillAssure.Controllers
{
    public class UpdateDocumentPricingController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: UpdateDocumentPricing
        public ActionResult UpdateDocumentPricingIndex(string NestId)
        {

            ViewBag.collapse = "true";
            if (TempData["Message"] != null)
            {
                if (TempData["Message"].ToString() == "true")
                {
                    ViewBag.Message = "Verified";
                }
            }

            LoginModel RFM = new LoginModel();
            string query = "";

            con.Open();

            if (Session["Type"] != null)
            {
                if (Session["Type"].ToString() == "SuperAdmin")
                {
                    query = "select * from documentpricing where prid = '" + NestId + "' ";
                }
                if (Session["Type"].ToString() == "DistributorAdmin")
                {
                    query = "select * from Distributor_documentpricing where prid = '" + NestId + "' ";
                }
            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }
          


          
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {
                RFM.prid = Convert.ToInt32(NestId);
                RFM.documentname = dt.Rows[0]["Document_Name"].ToString();
                RFM.documentprice = Convert.ToInt32(dt.Rows[0]["Document_Price"]);



            }


            return View("~/Views/UpdateDocumentPricing/UpdateDocumentPricingPageContent.cshtml",RFM);
        }





        public ActionResult UpdateDistributorPricing(LoginModel LM)
        {
            string query = "";


            if (Session["Type"] != null)
            {
                if (Session["Type"].ToString() == "SuperAdmin")
                {
                    query = "Update documentpricing set Document_Name = '"+LM.documentname+ "' , Document_Price = "+LM.documentprice+" where prid = "+LM.prid+" ";
                }
                if (Session["Type"].ToString() == "DistributorAdmin")
                {
                    query = "Update Distributor_documentpricing set Document_Name = '" + LM.documentname + "' , Document_Price = " + LM.documentprice + " where prid = " + LM.prid + " ";
                }

                con.Open();
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }



            TempData["Message"] = "true";
            return RedirectToAction("UpdateDocumentPricingIndex", "UpdateDocumentPricing");
        }





    }
}