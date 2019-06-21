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
using System.Net.Mail;
using System.Net;
namespace WillAssure.Controllers
{
    public class TestatorHomePageController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: TestatorHomePage
        public ActionResult TestatorHomePageIndex()
        {




            return View("~/Views/TestatorHomePage/TestatorHomePageContent.cshtml");
        }



        public ActionResult checkpaymentstatus()
        {


            if (Session["displayname"].ToString() != "")
            {

                // document amount cal

                int total = 0;
                int willamt = 0;
                int Codocilamt = 0;
                int POAamt = 0;
                int Giftdeedsamt = 0;
                int LivingWillamt = 0;
                con.Open();
                string qry312 = "select Will , Codocil , POA , Giftdeeds , LivingWill from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlDataAdapter daa23 = new SqlDataAdapter(qry312, con);
                DataTable dtt43 = new DataTable();
                daa23.Fill(dtt43);
                if (dtt43.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtt43.Rows[0]["Will"]) == 1)
                    {

                        string quer1 = "select Document_Price from documentpricing  where Document_Name = 'Will' ";
                        SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                        DataTable daat = new DataTable();
                        daa1.Fill(daat);
                        if (daat.Rows.Count > 0)
                        {
                            willamt = Convert.ToInt32(daat.Rows[0]["Document_Price"]);
                        }

                    }
                    if (Convert.ToInt32(dtt43.Rows[0]["Codocil"]) == 1)
                    {

                        string quer1 = "select Document_Price from documentpricing  where Document_Name = 'Codocil' ";
                        SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                        DataTable daat = new DataTable();
                        daa1.Fill(daat);
                        if (daat.Rows.Count > 0)
                        {
                            Codocilamt += Convert.ToInt32(daat.Rows[0]["Document_Price"]);
                        }

                    }
                    if (Convert.ToInt32(dtt43.Rows[0]["POA"]) == 1)
                    {

                        string quer1 = "select Document_Price from documentpricing  where Document_Name = 'POA' ";
                        SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                        DataTable daat = new DataTable();
                        daa1.Fill(daat);
                        if (daat.Rows.Count > 0)
                        {
                            POAamt += Convert.ToInt32(daat.Rows[0]["Document_Price"]);
                        }

                    }
                    if (Convert.ToInt32(dtt43.Rows[0]["Giftdeeds"]) == 1)
                    {

                        string quer1 = "select Document_Price from documentpricing  where Document_Name = 'Giftdeeds' ";
                        SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                        DataTable daat = new DataTable();
                        daa1.Fill(daat);
                        if (daat.Rows.Count > 0)
                        {
                            Giftdeedsamt += Convert.ToInt32(daat.Rows[0]["Document_Price"]);
                        }

                    }
                    if (Convert.ToInt32(dtt43.Rows[0]["LivingWill"]) == 1)
                    {

                        string quer1 = "select Document_Price from documentpricing  where Document_Name = 'LivingWill' ";
                        SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                        DataTable daat = new DataTable();
                        daa1.Fill(daat);
                        if (daat.Rows.Count > 0)
                        {
                            LivingWillamt += Convert.ToInt32(daat.Rows[0]["Document_Price"]);
                        }

                    }
                }
                con.Close();

                total = willamt + Codocilamt + POAamt + Giftdeedsamt + LivingWillamt;

                Session["documentamount"] = total;

                //end








                ViewBag.enableMultipleSelect = "true";

                con.Open();
                string qq222 = "select PaymentStatus from testatordetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlDataAdapter daa22 = new SqlDataAdapter(qq222, con);
                DataTable paydtt = new DataTable();
                daa22.Fill(paydtt);
                con.Close();

                if (Convert.ToInt32(paydtt.Rows[0]["PaymentStatus"]) == 1)
                {


                    // check will status
                    con.Open();
                    string qry1 = "select Will , Designation  from users where Will = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                    DataTable dtt1 = new DataTable();
                    daa1.Fill(dtt1);
                    if (dtt1.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtt1.Rows[0]["Will"]) == 1 && Convert.ToInt32(dtt1.Rows[0]["Designation"]) == 1)
                        {
                            ViewBag.documentbtn1 = "true";
                        }

                    }
                    con.Close();
                    //end


                    // check codocil status
                    con.Open();
                    string qry2 = "select Codocil , Designation  from users where Codocil = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter daa2 = new SqlDataAdapter(qry2, con);
                    DataTable dtt2 = new DataTable();
                    daa2.Fill(dtt2);
                    if (dtt2.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtt2.Rows[0]["Codocil"]) == 1 && Convert.ToInt32(dtt2.Rows[0]["Designation"]) == 1)
                        {
                            ViewBag.documentbtn2 = "true";
                        }
                    }
                    con.Close();

                    //end


                    // check Poa status
                    con.Open();
                    string qry4 = "select POA  , Designation  from users where POA = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                    DataTable dtt4 = new DataTable();
                    daa4.Fill(dtt4);
                    if (dtt4.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtt4.Rows[0]["POA"]) == 1 && Convert.ToInt32(dtt4.Rows[0]["Designation"]) == 1)
                        {

                            ViewBag.documentbtn3 = "true";
                        }
                    }
                    con.Close();
                    //end


                    // check gift deeds status
                    con.Open();
                    string qry3 = "select Giftdeeds , Designation  from users where Giftdeeds = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                    DataTable dtt3 = new DataTable();
                    daa3.Fill(dtt3);
                    if (dtt3.Rows.Count > 0)
                    {
                        if (dtt3.Rows[0]["Giftdeeds"] != null)
                        {
                            if (Convert.ToInt32(dtt3.Rows[0]["Giftdeeds"]) == 1 && Convert.ToInt32(dtt3.Rows[0]["Designation"]) == 1)
                            {
                                ViewBag.documentbtn4 = "true";
                            }
                        }

                    }
                    con.Close();
                    //end


                    // check Living Will status
                    con.Open();
                    string qry3122 = "select LivingWill , Designation  from users where LivingWill = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter daa233 = new SqlDataAdapter(qry3122, con);
                    DataTable dtt433 = new DataTable();
                    daa233.Fill(dtt433);
                    if (dtt433.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtt433.Rows[0]["LivingWill"]) == 1 && Convert.ToInt32(dtt433.Rows[0]["Designation"]) == 1)
                        {
                            ViewBag.documentbtn5 = "true";
                        }
                    }
                    con.Close();
                    //end

                    ViewBag.create = "true";

                }
                else
                {

                    ViewBag.PaymentLink = "true";


                }



            }
            return View("~/Views/TestatorHomePage/TestatorHomePageContent.cshtml");



        }








    }
}