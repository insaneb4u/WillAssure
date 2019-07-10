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
using System.Net.Mail;
using System.Net;
using System.Collections;

namespace WillAssure.Controllers
{
    public class CodocilController : Controller
    {
        static int counter = 1; 
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: Codocil
        public ActionResult CodocilIndex()
        {
            ViewBag.collapse = "true";
            ViewBag.cod = "true";


            return View("~/Views/Codocil/CodocilPageContent.cshtml");
        }


        public ActionResult InsertCodocilData()
        {
            ViewBag.collapse = "true";

            string response = Request["send"];
          
            ArrayList result = new ArrayList(response.Split('~'));

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].ToString() != "")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(result[i].ToString(), con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }



            return View("~/Views/Codocil/CodocilPageContent.cshtml");
        }






        public string getdatastructure()
        {
            int getcount = 0;
             getcount = counter++;

            string structure = "";


            structure = structure + "<div id='main"+ getcount + "' style='border:1px solid green; padding:15px; border-radius:10px;'>"+

                            "<div class='row'>"+
                                "<div class='col-sm-2'>"+
                                    "<div class='form-group'>"+
                                        "<label for='input-1'>Selection</label>"+

                                        "<select class='form-control input-shadow validate[required] beneficiaryclass'  id='ddlselection" + getcount + "'  onchange='checkbeneficiaryduplicate(this.id,this.value)' >" +
                                            "<option value='1' >--Select--</ option >"+
                                            "<option value='2'>beneficiary</option>" +
                                            "<option value='3' >assets</ option >" +
                                            "<option value='4'>executors</option>" +
                                            "<option value='5' >guardian </ option >" +
                                            "<option value='6'>liabilities</option>" +
                                        "</select>"+

                                    "</div>"+
                                "</div>"+


                            "</div>"+



                            "<div class='row'>"+


                                "<div class='col-sm-6'>"+
                                    "<div class='form-group'>"+
                                        "<label for='input-1'>Old Details</label>"+


                                        "<textarea  class='form-control input-shadow'  id='olddetails" + getcount + "'  onchange='getolddetails(this.value)'></textarea>" +
                                    "</div>"+
                                "</div>"+


                                "<div class='col-sm-6'>"+
                                    "<div class='form-group'>"+
                                        "<label for='input-1'>New Details</label>"+

                                        "<textarea class='form-control input-shadow'  id ='newdetails" + getcount + "'  onchange='getnewdetails(this.value)'></textarea>" +
                                    "</div>"+
                                "</div>"+


                            "</div>"+



                        "</div>";




            return structure;
        }



    }
}