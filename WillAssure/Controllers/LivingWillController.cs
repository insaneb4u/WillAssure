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
using System.Globalization;

namespace WillAssure.Controllers
{
    public class LivingWillController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: LivingWill
        public ActionResult LivingWillIndex()
        {
            ViewBag.collapse = "true";

            ViewBag.enablelivingwill = "true";




            return View("~/Views/LivingWill/LivingWillPageContent.cshtml");
        }


        public ActionResult InsertWillData(CodocilModel CM)
        {
            ViewBag.collapse = "true";
            ViewBag.enablelivingwill = "true";


            int getid = Convert.ToInt32(Session["uuid"]);
            int NestId = 0;

            con.Open();

            string qq26 = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa26 = new SqlDataAdapter(qq26, con);
            DataTable dtt26 = new DataTable();
            daa26.Fill(dtt26);
            if (dtt26.Rows.Count > 0)
            {
                NestId = Convert.ToInt32(dtt26.Rows[0]["tId"]);
            }




            string query = "insert into living_Will (Conditions,TreatmentDecline,uId,tid,documentstatus) values ('" + CM.conditions+"' , '"+CM.treatmentdecline+"' , "+Convert.ToInt32(Session["uuid"])+" , "+NestId+" , 'Completed'  )";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();


            con.Close();


            ModelState.Clear();
            ViewBag.Message = "Verified";

            return View("~/Views/LivingWill/LivingWillPageContent.cshtml");
        }


    }
}