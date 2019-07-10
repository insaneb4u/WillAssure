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
    public class DashBoardController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: DashBoard
        public ActionResult DashBoardIndex()
        {

            int testatorid = 0;


            con.Open();
            string query1t = "select tId from  TestatorDetails where  uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter da1t = new SqlDataAdapter(query1t, con);
            DataTable dt1t = new DataTable();
            da1t.Fill(dt1t);
            if (dt1t.Rows.Count > 0)
            {
                testatorid = Convert.ToInt32(dt1t.Rows[0]["tId"]);


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

                // for appointees 

                con.Open();
                string qchk008 = "select * from Appointees where tid = " + testatorid + " and doctype='Will'  ";
                SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                DataTable chk008dt = new DataTable();
                chk008da.Fill(chk008dt);
                con.Close();

                if (chk008dt.Rows.Count > 0)
                {


                    ViewBag.Willbtn = "true";
                }


                //end
            }



            if (Convert.ToInt32(dt2.Rows[0]["POA"]) == 1)
            {

                // for appointees 

                con.Open();
                string qchk008 = "select * from Appointees where tid = " + testatorid + " and doctype='POA'  ";
                SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                DataTable chk008dt = new DataTable();
                chk008da.Fill(chk008dt);
                con.Close();

                if (chk008dt.Rows.Count > 0)
                {


                    ViewBag.POAbtn = "true";
                }


                //end
            }


            if (Convert.ToInt32(dt2.Rows[0]["Giftdeeds"]) == 1)
            {

                // for appointees 

                con.Open();
                string qchk008 = "select * from Appointees where tid = " + testatorid + " and doctype='Giftdeeds'  ";
                SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                DataTable chk008dt = new DataTable();
                chk008da.Fill(chk008dt);
                con.Close();

                if (chk008dt.Rows.Count > 0)
                {


                    ViewBag.Giftdeedsbtn = "true";
                }


                //end
            }


            if (Convert.ToInt32(dt2.Rows[0]["LivingWill"]) == 1)
            {

                // for appointees 

                con.Open();
                string qchk008 = "select * from Appointees where tid = " + testatorid + " and doctype='LivingWill'  ";
                SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                DataTable chk008dt = new DataTable();
                chk008da.Fill(chk008dt);
                con.Close();

                if (chk008dt.Rows.Count > 0)
                {


                    ViewBag.LivingWillbtn = "true";
                }


                //end
            }



            if (Convert.ToInt32(dt2.Rows[0]["Codocil"]) == 1)
            {

                // for appointees 

                con.Open();
                string qchk008 = "select * from Appointees where tid = " + testatorid + " and doctype='Codocil'  ";
                SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                DataTable chk008dt = new DataTable();
                chk008da.Fill(chk008dt);
                con.Close();

                if (chk008dt.Rows.Count > 0)
                {


                    ViewBag.Codocilbtn = "true";
                }


                //end
            }



            con.Open();
            string qq222 = "select PaymentStatus from testatordetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa22 = new SqlDataAdapter(qq222, con);
            DataTable paydtt = new DataTable();
            daa22.Fill(paydtt);
            con.Close();

            if (paydtt.Rows.Count > 0)
            {
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



            string OTP = "";
            if (Session["LoginOTP"] != null)
            {
                OTP = Session["LoginOTP"].ToString();
                //Session["LoginOTP"] = Eramake.eCryptography.Decrypt(OTP);
                Session["enteredOTP"] = OTP;
            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

            if (Session["enteredOTP"] == null)
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

            con.Open();
            string query = "select Designation  from users where uId = " + Convert.ToInt32(Session["uuid"]) + "  ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string type = "";

            if (dt.Rows.Count > 0)
            {
                type = dt.Rows[0]["Designation"].ToString();
            }
            con.Close();


            if (type != "2")
            {
                List<LoginModel> Lmlist = new List<LoginModel>();
                con.Open();
                string q = "select * from Assignment_Roles where RoleId = " + Convert.ToInt32(Session["rId"]) + "";
                SqlDataAdapter da3 = new SqlDataAdapter(q, con);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {

                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        LoginModel lm = new LoginModel();
                        lm.PageName = dt3.Rows[i]["PageName"].ToString();
                        lm.PageStatus = dt3.Rows[i]["PageStatus"].ToString();
                        lm.Action = dt3.Rows[i]["Action"].ToString();
                        lm.Nav1 = dt3.Rows[i]["Nav1"].ToString();
                        lm.Nav2 = dt3.Rows[i]["Nav2"].ToString();

                        Lmlist.Add(lm);
                    }



                    ViewBag.PageName = Lmlist;




                }






            }
            else
            {

                ViewBag.Testatorpopup = "true";

            }




            // total count Dashboard

            string q1 = "select count(*) as TotalDistributorAdmin from users  where Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and Type = 'DistributorAdmin'";
            SqlDataAdapter da1 = new SqlDataAdapter(q1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            ViewBag.TotalDistributorAdmin = Convert.ToInt32(dt1.Rows[0]["TotalDistributorAdmin"]);


            string q5 = "select count(*) as TotalTestator  from TestatorDetails a inner join users b on a.uId=b.uId where b.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da5 = new SqlDataAdapter(q5, con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            ViewBag.TotalTestator = Convert.ToInt32(dt5.Rows[0]["TotalTestator"]);


            string q52 = "select count(*) as TotalVisitor from visitorinfo ";
            SqlDataAdapter da52 = new SqlDataAdapter(q52, con);
            DataTable dt52 = new DataTable();
            da52.Fill(dt52);
            ViewBag.TotalVisitor = Convert.ToInt32(dt52.Rows[0]["TotalVisitor"]);




            string q2 = "select count(*) as TotalWill from documentRules WHERE documentType = 'Will' and uId = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da22 = new SqlDataAdapter(q2, con);
            DataTable dt22 = new DataTable();
            da22.Fill(dt22);
            ViewBag.Will = Convert.ToInt32(dt22.Rows[0]["TotalWill"]);



            string q4 = "select count(*) as TotalCodocil from documentRules WHERE documentType = 'Codocil' and uId = " + Convert.ToInt32(Session["uuid"]) + "  ";
            SqlDataAdapter da4 = new SqlDataAdapter(q4, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            ViewBag.Codocil = Convert.ToInt32(dt4.Rows[0]["TotalCodocil"]);







            string q6 = "select count(*) as TotalPOA from documentRules WHERE documentType = 'POA' and uId = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da6 = new SqlDataAdapter(q6, con);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);
            ViewBag.POA = Convert.ToInt32(dt6.Rows[0]["TotalPOA"]);




            string q7 = "select count(*) as TotalGiftDeeds from documentRules WHERE documentType = 'GiftDeeds' and uId = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da7 = new SqlDataAdapter(q7, con);
            DataTable dt7 = new DataTable();
            da7.Fill(dt7);
            ViewBag.GiftDeeds = Convert.ToInt32(dt7.Rows[0]["TotalGiftDeeds"]);







            con.Close();




            //end



            // check type 
            string typ = "";
            con.Open();
            string qq1 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa = new SqlDataAdapter(qq1, con);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            con.Close();

            if (dtt.Rows.Count > 0)
            {
                typ = dtt.Rows[0]["Type"].ToString();
            }



            //end



            ViewBag.showtitle = "true";
            ViewBag.documentlink = "true";







            return View("~/Views/DashBoard/DashBoardPageContent.cshtml");
        }


        public ActionResult EnableDocumentLinks(string doctype)
        {

            if (Session["Type"] == null)
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

            if (Session["Type"] != null)
            {
                if (Session["Type"].ToString() != "Testator")
                {
                    if (doctype == "Will")
                    {
                        ViewBag.collapse = "true";
                        Session["doctype"] = "Will";
                        return RedirectToAction("EditTestatorIndex", "EditTestator", new { doctype = doctype });
                    }

                    if (doctype == "Codocil")
                    {
                        ViewBag.collapse = "true";
                        Session["doctype"] = "Codocil";
                        return RedirectToAction("EditTestatorIndex", "EditTestator", new { doctype = doctype });
                    }


                    if (doctype == "POA")
                    {
                        ViewBag.collapse = "true";
                        Session["doctype"] = "POA";
                        return RedirectToAction("EditTestatorIndex", "EditTestator", new { doctype = doctype });
                    }


                    if (doctype == "GiftDeeds")
                    {
                        ViewBag.collapse = "true";
                        Session["doctype"] = "GiftDeeds";
                        return RedirectToAction("EditTestatorIndex", "EditTestator", new { doctype = doctype });
                    }


                    if (doctype == "LivingWill")
                    {
                        ViewBag.collapse = "true";
                        Session["doctype"] = "LivingWill";
                        return RedirectToAction("EditTestatorIndex", "EditTestator", new { doctype = doctype });
                    }
                }
            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

           





            if (doctype != null)
            {
                if (doctype == "Will")
                {
                    ViewBag.collapse = "true";
                    Session["doctype"] = "Will";
                    return RedirectToAction("UpdateTestatorsIndex", "UpdateTestators", new { NestId = Convert.ToInt32(Session["uuid"]) });
                }

                if (doctype == "Codocil")
                {
                    ViewBag.collapse = "true";
                    Session["doctype"] = "Codocil";
                    return RedirectToAction("CodocilIndex", "Codocil");
                }


                if (doctype == "POA")
                {
                    ViewBag.collapse = "true";
                    Session["doctype"] = "POA";



                  



                    return RedirectToAction("UpdateTestatorsIndex", "UpdateTestators", new { NestId = Convert.ToInt32(Session["uuid"]) });
                }


                if (doctype == "GiftDeeds")
                {
                    ViewBag.collapse = "true";
                    Session["doctype"] = "GiftDeeds";

                    return RedirectToAction("UpdateTestatorsIndex", "UpdateTestators", new { NestId = Convert.ToInt32(Session["uuid"]) });
                }


                if (doctype == "LivingWill")
                {
                    ViewBag.collapse = "true";
                    Session["doctype"] = "LivingWill";
                    return RedirectToAction("LivingWillIndex", "LivingWill");
                }
            }
            else
            {

                // make payment done
                con.Open();
                string qp = "update testatordetails set PaymentStatus = 1 where uId = " + Convert.ToInt32(Session["uuid"]) + "";
                SqlCommand cmq = new SqlCommand(qp, con);
                cmq.ExecuteNonQuery();
                con.Close();


                con.Open();
                string qp1 = "update visitorinfo set paymentstatus = 1 where uId = " + Convert.ToInt32(Session["uuid"]) + "";
                SqlCommand cmq1 = new SqlCommand(qp1, con);
                cmq1.ExecuteNonQuery();
                con.Close();


                //end

                if (Session["Type"] == null)
                {
                    RedirectToAction("LoginPageIndex", "LoginPage");
                }


                int testid = 0;

                // for will only 
                con.Open();
                string query44 = " select * from users where Will = 1   and  uId = " + Convert.ToInt32(Session["uuid"]) + " and active='Active' ";
                SqlDataAdapter d4aa = new SqlDataAdapter(query44, con);
                DataTable dtaa = new DataTable();
                d4aa.Fill(dtaa);
                con.Close();
                if (dtaa.Rows.Count > 0)
                {
                    ViewBag.dash = "disable";
                    testid = Convert.ToInt32(dtaa.Rows[0]["uId"]);

                    con.Open();
                    string que = "select tid from TestatorDetails where uId = " + testid + " ";
                    SqlDataAdapter d48 = new SqlDataAdapter(que, con);
                    DataTable dt8 = new DataTable();
                    d48.Fill(dt8);
                    con.Close();
                    Session["doctype"] = "Will";
                    ViewBag.view = "Will";
                    return RedirectToAction("UpdateTestatorsIndex", "UpdateTestators", new { NestId = Convert.ToInt32(dt8.Rows[0]["tid"]) });

                }
                //end


                // for Codocil only 
                con.Open();
                string query45 = " select * from users where Codocil = 1 and  uId = " + Convert.ToInt32(Session["uuid"]) + " and active='Active' ";
                SqlDataAdapter d4a5 = new SqlDataAdapter(query45, con);
                DataTable dta5 = new DataTable();
                d4a5.Fill(dta5);
                con.Close();
                if (dta5.Rows.Count > 0)
                {
                    return RedirectToAction("CodocilIndex", "Codocil");
                }
                //end



                // for POA only 
                con.Open();
                string query46 = " select * from users where  POA = 1  and  uId = " + Convert.ToInt32(Session["uuid"]) + " and active='Active' ";
                SqlDataAdapter d4a6 = new SqlDataAdapter(query46, con);
                DataTable dta6 = new DataTable();
                d4a6.Fill(dta6);
                con.Close();
                if (dta6.Rows.Count > 0)
                {
                    ViewBag.dash = "disable";
                    testid = Convert.ToInt32(dta6.Rows[0]["uId"]);

                    con.Open();
                    string que = "select tid from TestatorDetails where uId = " + testid + " ";
                    SqlDataAdapter d48 = new SqlDataAdapter(que, con);
                    DataTable dt8 = new DataTable();
                    d48.Fill(dt8);
                    con.Close();

                    Session["doctype"] = "POA";
                    ViewBag.view = "POA";
                    return RedirectToAction("UpdateTestatorsIndex", "UpdateTestators", new { NestId = Convert.ToInt32(dt8.Rows[0]["tid"]) });

                }
                //end



                // for Giftdeeds only 
                con.Open();
                string query47 = " select * from users where  Giftdeeds = 1   and  uId = " + Convert.ToInt32(Session["uuid"]) + " and active='Active' ";
                SqlDataAdapter d4a7 = new SqlDataAdapter(query47, con);
                DataTable dta7 = new DataTable();
                d4a7.Fill(dta7);
                con.Close();
                if (dta7.Rows.Count > 0)
                {
                    ViewBag.dash = "disable";
                    testid = Convert.ToInt32(dta7.Rows[0]["uId"]);
                    con.Open();
                    string que = "select tid from TestatorDetails where uId = " + testid + " ";
                    SqlDataAdapter d48 = new SqlDataAdapter(que, con);
                    DataTable dt8 = new DataTable();
                    d48.Fill(dt8);
                    con.Close();

                    ViewBag.view = "GiftDeeds";
                    Session["doctype"] = "GiftDeeds";

                    return RedirectToAction("UpdateTestatorsIndex", "UpdateTestators", new { NestId = Convert.ToInt32(dt8.Rows[0]["tid"]) });

                }
                //end



                // for LivingWill only 
                con.Open();
                string query48 = " select * from users where  LivingWill = 1  and  uId = " + Convert.ToInt32(Session["uuid"]) + " and active='Active' ";
                SqlDataAdapter d4a8 = new SqlDataAdapter(query48, con);
                DataTable dta8 = new DataTable();
                d4a8.Fill(dta8);
                con.Close();
                if (dta8.Rows.Count > 0)
                {

                    testid = Convert.ToInt32(dta8.Rows[0]["uId"]);
                    return RedirectToAction("LivingWillIndex", "LivingWill");

                }
                //end





            }













            List<LoginModel> Lmlist = new List<LoginModel>();
            con.Open();
            string q = "select * from Assignment_Roles where RoleId = " + Convert.ToInt32(Session["rId"]) + "";
            SqlDataAdapter da3 = new SqlDataAdapter(q, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    LoginModel lm = new LoginModel();
                    lm.PageName = dt3.Rows[i]["PageName"].ToString();
                    lm.PageStatus = dt3.Rows[i]["PageStatus"].ToString();
                    lm.Action = dt3.Rows[i]["Action"].ToString();
                    lm.Nav1 = dt3.Rows[i]["Nav1"].ToString();
                    lm.Nav2 = dt3.Rows[i]["Nav2"].ToString();

                    Lmlist.Add(lm);
                }



                ViewBag.PageName = Lmlist;




            }

            con.Close();


            ViewBag.enabledocumentlink = "true";



            return View("~/Views/DashBoard/DashBoardPageContent.cshtml");
        }




        public ActionResult CodocilMasterindex()
        {

            List<LoginModel> Lmlist = new List<LoginModel>();
            con.Open();
            string q = "select * from Assignment_Roles where RoleId = " + Convert.ToInt32(Session["rId"]) + "";
            SqlDataAdapter da3 = new SqlDataAdapter(q, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    LoginModel lm = new LoginModel();
                    lm.PageName = dt3.Rows[i]["PageName"].ToString();
                    lm.PageStatus = dt3.Rows[i]["PageStatus"].ToString();
                    lm.Action = dt3.Rows[i]["Action"].ToString();
                    lm.Nav1 = dt3.Rows[i]["Nav1"].ToString();
                    lm.Nav2 = dt3.Rows[i]["Nav2"].ToString();

                    Lmlist.Add(lm);
                }



                ViewBag.PageName = Lmlist;




            }

            con.Close();


            return View("~/Views/Shared/CodocilMaster.cshtml");

        }




        public ActionResult VerifyOTP(LoginModel EVM)
        {
            if (Session["enteredOTP"] != null || Session["MobileOTP"] != null)
            {
                if (Session["enteredOTP"].ToString() == EVM.OTP || Session["MobileOTP"].ToString() == EVM.OTP)
                {
                    con.Open();
                    string query = "update TestatorDetails set Contact_Verification =1 , Email_Verification = 1 , Mobile_Verification_Status = 1 where Email_OTP = '" + ViewBag.OTP + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();




                    con.Open();
                    string updateotp = "update users set Designation = 1 where uid = " + Convert.ToInt32(Session["uuid"]) + "  ";
                    SqlCommand cmdot = new SqlCommand(updateotp, con);
                    cmdot.ExecuteNonQuery();
                    con.Close();




                    con.Open();

                    string qq = "select a.Amt_Paid_By from Authorization_Rules a inner join TestatorDetails b on  a.Testator_Id=b.tId where b.Email_OTP = " + Session["enteredOTP"].ToString() + " ";
                    SqlDataAdapter dda = new SqlDataAdapter(qq, con);
                    DataTable ddt = new DataTable();
                    dda.Fill(ddt);
                    string amtpaidby = "";
                    if (ddt.Rows.Count > 0)
                    {
                        amtpaidby = ddt.Rows[0]["Amt_Paid_By"].ToString();
                    }
                    con.Close();

                    if (amtpaidby == "Testator")
                    {


                        ViewBag.PaymentLink = "true";
                    }
                    else
                    {
                        return RedirectToAction("TestatorHomePageIndex", "TestatorHomePage");
                    }




                    ViewBag.Message = "Verified";
                }
                else
                {
                    con.Open();
                    string query = "update TestatorDetails set Contact_Verification =2 , Email_Verification = 2 , Mobile_Verification_Status = 2 where Email_OTP = '" + Session["enteredOTP"].ToString() + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ViewBag.Testatorpopup = "true";
                    ViewBag.Message = "Failed";
                }









            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }












            return View("~/Views/DashBoard/DashBoardPageContent.cshtml");

        }



    }
}