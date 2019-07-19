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
        public ActionResult TestatorHomePageIndex(string status)
        {

            if (TempData["status"] != null)
            {
                if (TempData["status"].ToString() == "true")
                {
                    TempData["MakePayment"] = "true";
                    TempData["status"] = "false";
                }

            }




            int testatorid = 0;
            ViewBag.collapse = "true";


            if (true)
            {

            }





            if (Session["uuid"] != null)
            {
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




               





                //////////////////////////////////////////////////////  FOR CHECKING PAYMENT and displaying in incompleted document   ///////////////////////////////////////////////


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
                        ViewBag.hidepayment = "true";

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

                               



                                // if completed than hide 

                                string qchk008 = "select top 1 codId from Codocil where documentstatus='Incompleted'  order by codId desc ";
                                SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                                DataTable chk008dt = new DataTable();
                                chk008da.Fill(chk008dt);
                                con.Close();

                                if (chk008dt.Rows.Count > 0)
                                {
                                    // remove document
                                    ViewBag.documentbtn2 = "false";

                                }
                                else
                                {
                                    // display document
                                    ViewBag.documentbtn2 = "true";
                                }



                                    //end


                                   

                                

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






                //////////////////////////////////////////////////////  END  ///////////////////////////////////////////////





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







                con.Open();
                string query12 = "select tId from  TestatorDetails where  uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlDataAdapter da12 = new SqlDataAdapter(query12, con);
                DataTable dt12 = new DataTable();
                da12.Fill(dt12);
                if (dt12.Rows.Count > 0)
                {
                    testatorid = Convert.ToInt32(dt12.Rows[0]["tId"]);
                    ViewBag.testatorid = testatorid;

                }
                con.Close();















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

                        string quer1 = "select Document_Price from documentpricing  where Document_Name = 'Gift Deeds' ";
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

                        string quer1 = "select Document_Price from documentpricing  where Document_Name = 'Living Will' ";
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

            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }






            return View("~/Views/TestatorHomePage/TestatorHomePageContent.cshtml");
        }





        public ActionResult checkcompleteddocument()
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





            //////////////////////////////////////////////////////  FOR CHECKING DOCUMENT COMPLETION ///////////////////////////////////////////////


            con.Open();
            string query2 = "select Will , Codocil , POA , Giftdeeds , LivingWill  from users where uId =  " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();

            if (dt2.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt2.Rows[0]["Will"]) == 1)
                {
                    ViewBag.PaymentLink = "true";
                    // for appointees 

                    con.Open();
                    string qchk008 = "select * from Appointees where tid = " + testatorid + " and doctype='Will' and Type='Witness'  ";
                    SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                    DataTable chk008dt = new DataTable();
                    chk008da.Fill(chk008dt);
                    con.Close();

                    if (chk008dt.Rows.Count > 0)
                    {


                        ViewBag.Willbtn = "true";



                    }
                    else
                    {
                        ViewBag.empty = "true";
                    }


                    //end
                }



                if (Convert.ToInt32(dt2.Rows[0]["POA"]) == 1)
                {
                    ViewBag.PaymentLink = "true";
                    // for appointees 

                    con.Open();
                    string qchk008 = "select * from Appointees where tid = " + testatorid + " and doctype='POA'  and Type='Witness' ";
                    SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                    DataTable chk008dt = new DataTable();
                    chk008da.Fill(chk008dt);
                    con.Close();

                    if (chk008dt.Rows.Count > 0)
                    {


                        ViewBag.POAbtn = "true";



                    }
                    else
                    {
                        ViewBag.empty = "true";
                    }


                    //end
                }


                if (Convert.ToInt32(dt2.Rows[0]["Giftdeeds"]) == 1)
                {
                    ViewBag.PaymentLink = "true";
                    // for appointees 

                    con.Open();
                    string qchk008 = "select * from Appointees where tid = " + testatorid + " and doctype='Giftdeeds' and Type='Witness'  ";
                    SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                    DataTable chk008dt = new DataTable();
                    chk008da.Fill(chk008dt);
                    con.Close();

                    if (chk008dt.Rows.Count > 0)
                    {


                        ViewBag.Giftdeedsbtn = "true";



                    }
                    else
                    {
                        ViewBag.empty = "true";
                    }


                    //end
                }


                if (Convert.ToInt32(dt2.Rows[0]["LivingWill"]) == 1)
                {
                    ViewBag.PaymentLink = "true";
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
                        ViewBag.PaymentLink = "true";

                    }


                    //end
                }



                if (Convert.ToInt32(dt2.Rows[0]["Codocil"]) == 1)
                {
                    ViewBag.PaymentLink = "true";
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
                        ViewBag.PaymentLink = "true";



                    }


                    //end
                }
            }

            //////////////////////////////////////////////////////  END  ///////////////////////////////////////////////






            return View("~/Views/TestatorHomePage/TestatorHomePageContent.cshtml");
        }









  









        public ActionResult insertDocumentDetails(TestatorFormModel TFM)
        {


            // DOCUMENT RULES
            string typeid = "";
            int typecat = 0;

            TFM.documenttype = TFM.will + TFM.codocil + TFM.livingwill + TFM.poa + TFM.giftdeeds;


            if (TFM.codocil != "")
            {
                int codocilid = 0;
                con.Open();
                string quer1 = "select top 1 codId from  Codocil order by  codId desc";
                SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                DataTable daat = new DataTable();
                daa1.Fill(daat);
                if (daat.Rows.Count > 0)
                {
                    codocilid = Convert.ToInt32(daat.Rows[0]["codId"]);
                }




                
                string qq1 = "update Codocil set documentstatus = 'Completed' where codId = "+ codocilid + "";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();






            }



            if (TFM.documenttype == "WillCodocilPOA")
            {
                typeid = "1,2,3";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='0', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();

            }
            if (TFM.documenttype == "Codocil")
            {
                typeid = "2";



                con.Open();
                string qq1 = "update users set   Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='0'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();


            }
            if (TFM.documenttype == "POA")
            {
                typeid = "3";

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "Will")
            {
                typeid = "1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='0', LivingWill='0'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillCodocil")
            {
                typeid = "1,2";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='0'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillPOA")
            {
                typeid = "1,3";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilPOA")
            {
                typeid = "2,3";

                con.Open();
                string qq1 = "update users set  Will = '0' , Codocil = '1' , POA = '1' , Giftdeeds='0', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilWill")
            {
                typeid = "2,1";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='0'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAWill")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "Giftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "GiftdeedsCodocil")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set  Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftdeedsWill")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftdeedsPOA")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set  Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set  Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilGiftdeedsWill")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilGiftdeedsWillPOA")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilWillGiftdeedsPOA")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "WillCodocilPOAGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "WillCodocilPOAGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWill")
            {

                con.Open();
                string qq1 = "update users set  Will = '0' , Codocil = '0' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillWillCodocilPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilGiftdeedsLivingWillWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "POALivingWillWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set  Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAGiftdeedsWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAWillCodocil")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='0', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set  Will = '0' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POALivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "GiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillCodocilPOAGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "POAGiftDeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set  Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillGiftDeedsPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftDeedsLivingWillPOA")
            {

                con.Open();
                string qq1 = "update users set  Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillCodocil")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set  Will = '0' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftdeedsPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "LivingWillPOA")
            {

                con.Open();
                string qq1 = "update users set  Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillGiftdeedsCodocil")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "WillGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillCodocilGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "LivingWillWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA ='0' , Giftdeeds='0', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "POAWillGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }



            if (TFM.documenttype == "GiftdeedsPOAWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "WillCodocilGiftdeedsPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillCodocilGiftdeedsPOALivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillCodocilLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilLivingWillPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "WillCodocilLivingWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillCodocilLivingWillPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }



            


            con.Open();
            string qq1typ = "update users set WillType = '"+ TFM.typeofwill + "'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlCommand cc1typ = new SqlCommand(qq1typ, con);
            cc1typ.ExecuteNonQuery();
            con.Close();




            TempData["status"] = "true";




       


            return RedirectToAction("TestatorHomePageIndex", "TestatorHomePage");

        }


        public string checkwilldocument()
        {
            string status = "";

            string WillType = Session["WillType"].ToString();


            if (WillType == "Quick")
            {

                int NestId = 0;

                int getid = Convert.ToInt32(Session["uuid"]);


                con.Open();
                string identifydoc = "select Will from users where Will = 1 and uId = " + getid + " and WillType = 'Quick' ";
                SqlDataAdapter da = new SqlDataAdapter(identifydoc, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["Will"]) == 1)
                    {



                        string qq26 = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                        SqlDataAdapter daa26 = new SqlDataAdapter(qq26, con);
                        DataTable dtt26 = new DataTable();
                        daa26.Fill(dtt26);
                        if (dtt26.Rows.Count > 0)
                        {
                            NestId = Convert.ToInt32(dtt26.Rows[0]["tId"]);
                        }



                        // check which document is active
                        // for testator family

                        string qchk001 = "select a.fId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Marital_Status , a.Religion , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.tId , a.active , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Is_Informed_Person from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where b.tId =   " + NestId + " and a.WillType = 'Quick' ";
                        SqlDataAdapter chk001da = new SqlDataAdapter(qchk001, con);
                        DataTable chk001dt = new DataTable();
                        chk001da.Fill(chk001dt);


                        if (chk001dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }
                        //end


                        // for beneficiary

                        string qchk002 = "select a.bpId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_proof , a.Identity_proof_value , a.Alt_Identity_proof , a.Alt_Identity_proof_value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.beneficiary_type from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId where b.tId = " + NestId + "  and a.doctype='Will' and a.WillType='Quick'";
                        SqlDataAdapter chk002da = new SqlDataAdapter(qchk002, con);
                        DataTable chk002dt = new DataTable();
                        chk002da.Fill(chk002dt);
                        con.Close();
                        if (chk002dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }
                        //end


                        // for beneficiary institution
                        con.Open();
                        string qchk0020 = "select * from [BeneficiaryInstitutions] where tid = " + NestId + "  and WillType='Quick'";
                        SqlDataAdapter chk002da0 = new SqlDataAdapter(qchk0020, con);
                        DataTable chk002dt0 = new DataTable();
                        chk002da0.Fill(chk002dt0);
                        con.Close();
                        if (chk002dt0.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }
                        //end




                        // for appointees 

                        con.Open();
                        string qchk008 = "select * from Appointees where tid = " + NestId + " and Type='Executor' and WillType='Quick' ";
                        SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                        DataTable chk008dt = new DataTable();
                        chk008da.Fill(chk008dt);
                        con.Close();

                        if (chk008dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }

                        //end






                        // for Addwitness 

                        con.Open();
                        string qchk0082 = "select * from Appointees where tid = " + NestId + " and Type='Witness' and WillType='Quick' ";
                        SqlDataAdapter chk008da2 = new SqlDataAdapter(qchk0082, con);
                        DataTable chk008dt2 = new DataTable();
                        chk008da2.Fill(chk008dt2);
                        con.Close();

                        if (chk008dt2.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }

                        //end



                        // for asset mapping 


                        string qchk006 = "select a.Beneficiary_Asset_ID , a.AssetType_ID , a.AssetCategory_ID ,  a.Beneficiary_ID , a.Proportion , a.tid from BeneficiaryAssets a inner join TestatorDetails b on a.tid=b.tId where b.tId = " + NestId + "  and a.doctype='Will'  and a.WillType='Quick'";
                        SqlDataAdapter chk006da = new SqlDataAdapter(qchk006, con);
                        DataTable chk006dt = new DataTable();
                        chk006da.Fill(chk006dt);
                        con.Close();

                        if (chk006dt.Rows.Count > 0)
                        {
                            status = "true";
                        }
                        else
                        {
                            status = "false";
                        }

                        //end

















                    }
                }

                con.Close();






            }



            if (WillType == "Detailed")
            {

                int NestId = 0;

                int getid = Convert.ToInt32(Session["uuid"]);


                con.Open();
                string identifydoc = "select Will from users where Will = 1 and uId = " + getid + " and WillType = 'Detailed' ";
                SqlDataAdapter da = new SqlDataAdapter(identifydoc, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["Will"]) == 1)
                    {



                        string qq26 = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                        SqlDataAdapter daa26 = new SqlDataAdapter(qq26, con);
                        DataTable dtt26 = new DataTable();
                        daa26.Fill(dtt26);
                        if (dtt26.Rows.Count > 0)
                        {
                            NestId = Convert.ToInt32(dtt26.Rows[0]["tId"]);
                        }



                        // check which document is active
                        // for testator family

                        string qchk001 = "select a.fId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Marital_Status , a.Religion , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.tId , a.active , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Is_Informed_Person from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where b.tId =   " + NestId + " and a.WillType = 'Detailed' ";
                        SqlDataAdapter chk001da = new SqlDataAdapter(qchk001, con);
                        DataTable chk001dt = new DataTable();
                        chk001da.Fill(chk001dt);


                        if (chk001dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }
                        //end


                        // for beneficiary

                        string qchk002 = "select a.bpId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_proof , a.Identity_proof_value , a.Alt_Identity_proof , a.Alt_Identity_proof_value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.beneficiary_type from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId where b.tId = " + NestId + "  and a.doctype='Will' and a.WillType='Detailed'";
                        SqlDataAdapter chk002da = new SqlDataAdapter(qchk002, con);
                        DataTable chk002dt = new DataTable();
                        chk002da.Fill(chk002dt);
                        con.Close();
                        if (chk002dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }
                        //end




                        // for beneficiary institution
                        con.Open();
                        string qchk0020 = "select * from [BeneficiaryInstitutions] where tid = " + NestId + "  and WillType='Detailed'";
                        SqlDataAdapter chk002da0 = new SqlDataAdapter(qchk0020, con);
                        DataTable chk002dt0 = new DataTable();
                        chk002da0.Fill(chk002dt0);
                        con.Close();
                        if (chk002dt0.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }
                        //end




                        // for assetinformation

                        string qchk003 = "select a.aiid , a.atId , a.amId , a.tid , a.docid , a.Json from AssetInformation a inner join TestatorDetails b on a.tid=b.tId where b.tId = " + NestId + "  and a.doctype='Will'  and a.WillType='Detailed'  ";
                        SqlDataAdapter chk003da = new SqlDataAdapter(qchk003, con);
                        DataTable chk003dt = new DataTable();
                        chk003da.Fill(chk003dt);
                        con.Close();
                        if (chk003dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }

                        //end







                        // for asset mapping 


                        string qchk006 = "select a.Beneficiary_Asset_ID , a.AssetType_ID , a.AssetCategory_ID ,  a.Beneficiary_ID , a.Proportion , a.tid from BeneficiaryAssets a inner join TestatorDetails b on a.tid=b.tId where b.tId = " + NestId + "  and a.doctype='Will'  and a.WillType='Detailed'";
                        SqlDataAdapter chk006da = new SqlDataAdapter(qchk006, con);
                        DataTable chk006dt = new DataTable();
                        chk006da.Fill(chk006dt);
                        con.Close();

                        if (chk006dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }

                        //end








                        // for appointees 

                        con.Open();
                        string qchk008 = "select * from Appointees where tid = " + NestId + " and Type='Executor' and WillType='Detailed' ";
                        SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                        DataTable chk008dt = new DataTable();
                        chk008da.Fill(chk008dt);
                        con.Close();

                        if (chk008dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }

                        //end






                        // for Addwitness 

                        con.Open();
                        string qchk0082 = "select * from Appointees where tid = " + NestId + " and Type='Witness' and WillType='Detailed' ";
                        SqlDataAdapter chk008da2 = new SqlDataAdapter(qchk0082, con);
                        DataTable chk008dt2 = new DataTable();
                        chk008da2.Fill(chk008dt2);
                        con.Close();

                        if (chk008dt2.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }

                        //end











                    }
                }

                con.Close();







            }











            return status;
        }





        public string checkcodocildocument()
        {
                string status = "";


                int NestId = 0;

                int getid = Convert.ToInt32(Session["uuid"]);


                con.Open();
                string identifydoc = "select Codocil from users where Codocil = 1 and uId = " + getid + "  ";
                SqlDataAdapter da = new SqlDataAdapter(identifydoc, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["Codocil"]) == 1)
                    {



                        string qq26 = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                        SqlDataAdapter daa26 = new SqlDataAdapter(qq26, con);
                        DataTable dtt26 = new DataTable();
                        daa26.Fill(dtt26);
                        if (dtt26.Rows.Count > 0)
                        {
                            NestId = Convert.ToInt32(dtt26.Rows[0]["tId"]);
                        }




                    // for Codocil 

                    
                    string qchk0082 = "select * from Codocil where tid = " + NestId + "  ";
                    SqlDataAdapter chk008da2 = new SqlDataAdapter(qchk0082, con);
                    DataTable chk008dt2 = new DataTable();
                    chk008da2.Fill(chk008dt2);
                    con.Close();

                    if (chk008dt2.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        status = "false";
                    }

                    //end






                }
            }
              



                        return status;
        }







        public string checklivindocument()
        {
            string status = "";


            int NestId = 0;

            int getid = Convert.ToInt32(Session["uuid"]);


            con.Open();
            string identifydoc = "select LivingWill from users  where uId = " + getid + "  ";
            SqlDataAdapter da = new SqlDataAdapter(identifydoc, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["LivingWill"]) == 1)
                {



                    string qq26 = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter daa26 = new SqlDataAdapter(qq26, con);
                    DataTable dtt26 = new DataTable();
                    daa26.Fill(dtt26);
                    if (dtt26.Rows.Count > 0)
                    {
                        NestId = Convert.ToInt32(dtt26.Rows[0]["tId"]);
                    }




                    // for Codocil 


                    string qchk0082 = "select * from living_Will where tid = " + NestId + "  ";
                    SqlDataAdapter chk008da2 = new SqlDataAdapter(qchk0082, con);
                    DataTable chk008dt2 = new DataTable();
                    chk008da2.Fill(chk008dt2);
                    con.Close();

                    if (chk008dt2.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        status = "false";
                    }

                    //end






                }
            }





            return status;
        }





       




    











    }
}