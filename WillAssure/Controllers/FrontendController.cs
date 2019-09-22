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


    public class FrontendController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        static long AutoId = 0;
        // GET: Frontend
        public ActionResult Index()
        {
            if (Session["displayname"] != null)
            {
                if (Session["displayname"].ToString() != "")
                {
                    ViewBag.enableMultipleSelect = "true";
                }
            }


            TempData["count"] = 0;
          
            return View("~/Views/Frontend/Index.cshtml");
        }




        public ActionResult OtpIndex(string userid)
        {
            con.Open();
            string query = "select Email_Verification from TestatorDetails where uId = "+userid+"";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Email_Verification"].ToString() == "1")
                {
                    ViewBag.alreadyverified = "true";
                }
            }

            con.Close();

            return View("~/Views/Frontend/otpscreen.cshtml");
        }




        public string checkgetotp()
        {

            con.Open();
            string query = "select top 1 uId  from users order by uId desc";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string userid = "";
            if (dt.Rows.Count > 0)
            {
                userid = dt.Rows[0]["uId"].ToString();
            }
            con.Close();


            return userid;
        }





        public string Resendotp()
        {
            string returnmsg = "";
            AutoId++;
            
            if (AutoId >= 5)
            {
                returnmsg = "disable";
            }
            else
            {

                string response = Request["send"].ToString();
                string emailid = "";
                 returnmsg = "true";


                con.Open();

                string q = "select * from users where uid = " + response + "";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string firstname = "";
                if (dt.Rows.Count > 0)
                {
                    emailid = dt.Rows[0]["eMail"].ToString();
                    firstname = dt.Rows[0]["First_Name"].ToString();
                }
                con.Close();











                //generate MOBILE OTP
                string MobileOTP = "";
                MobileOTP = String.Empty;
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                int iOTPLength = 5;

                string sTempChars = String.Empty;
                Random rand = new Random();

                for (int i = 0; i < iOTPLength; i++)

                {

                    int p = rand.Next(0, saAllowedCharacters.Length);

                    sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                    MobileOTP += sTempChars;

                }
                //END




                //generate EMAIL OTP
                string EmailOTP = "";
                EmailOTP = String.Empty;
                string[] saAllowedCharacters2 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                int iOTPLength2 = 5;

                string sTempChars2 = String.Empty;
                Random rand2 = new Random();

                for (int i = 0; i < iOTPLength2; i++)

                {

                    int p = rand.Next(0, saAllowedCharacters2.Length);

                    sTempChars2 = saAllowedCharacters2[rand.Next(0, saAllowedCharacters2.Length)];

                    EmailOTP += sTempChars2;

                }
                //END



                if (emailid != "")
                {
                    // new mail code
                    string mailto = emailid;
                    string Userid = emailid;

                    Session["userid"] = Userid;
                    string subject = "Resend OTP request for Willassure registration";
                 
                    string body = "<font style='font-size:large'>Dear "+ firstname + ",<br>" +
                        "We have received your request to resend the OTP to complete your registration on <br>" +
                        "Willassure.<br>" +
                        "<br>" +
                        "Your new OTP is "+EmailOTP+"<br>" +
                        "<br>" +
                        "<br>" +
                        "Regards,<br>" +
                        "Team Willassure";

                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("info@drinco.in");
                    msg.To.Add(mailto);
                    msg.Subject = subject;
                    msg.Body = body;

                    msg.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
                    smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
                    smtp.EnableSsl = false;
                    smtp.Send(msg);
                    smtp.Dispose();



                    //end
                }





                con.Open();

                string query = "update TestatorDetails set Email_OTP = " + EmailOTP + " where uid = " + response + " ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();


                con.Close();

            }


            return returnmsg;

        }








        public ActionResult AboutUsIndex()
        {
            if (Session["displayname"] != null)
            {
                if (Session["displayname"].ToString() != "")
                {
                    ViewBag.enableMultipleSelect = "true";
                }
            }
        
           

            return View("~/Views/Frontend/Aboutus.cshtml");
        }


        public ActionResult ContactUsIndex()
        {

            if (Session["displayname"] != null)
            {
                if (Session["displayname"].ToString() != "")
                {
                    ViewBag.enableMultipleSelect = "true";
                }
            }
        

          
            return View("~/Views/Frontend/ContactUs.cshtml");
        }



        public ActionResult DisclaimerIndex()
        {
            if (Session["displayname"] != null)
            {
                if (Session["displayname"].ToString() != "")
                {
                    ViewBag.enableMultipleSelect = "true";
                }
            }
        

            return View("~/Views/Frontend/Disclaimer.cshtml");
        }


        public ActionResult DocumentIndex()
        {

            if (Session["displayname"] != null)
            {

                if (Session["displayname"].ToString() != "")
                {
                    ViewBag.enableMultipleSelect = "true";
                }
           


            }
        




            return View("~/Views/Frontend/Document.cshtml");
        }


        public ActionResult FaqIndex()
        {

            if (Session["displayname"] != null)
            {
                if (Session["displayname"].ToString() != "")
                {
                    ViewBag.enableMultipleSelect = "true";
                }
            }
        


        
            return View("~/Views/Frontend/Faq.cshtml");
        }



        public ActionResult HowweworkIndex()
        {
            if (Session["displayname"] != null)
            {
                if (Session["displayname"].ToString() != "")
                {
                    ViewBag.enableMultipleSelect = "true";
                }
            }
          

            return View("~/Views/Frontend/Howwework.cshtml");
        }



        public ActionResult PrivacyPolicyIndex()
        {
            if (Session["displayname"] != null)
            {
                if (Session["displayname"].ToString() != "")
                {
                    ViewBag.enableMultipleSelect = "true";
                }
            }
          
          
            return View("~/Views/Frontend/Privacypolicy.cshtml");
        }


        public ActionResult RegnIndex()
        {
            if (Session["displayname"] != null)
            {
               
                    if (Session["displayname"].ToString() != "")
                    {
                        ViewBag.enableMultipleSelect = "true";
                    }
                
            }
            

            
            return View("~/Views/Frontend/Regn.cshtml");
        }


        public ActionResult ServicesIndex()
        {

            if (Session["displayname"] != null)
            {
                if (Session["displayname"].ToString() != "")
                {
                    ViewBag.enableMultipleSelect = "true";
                }

            }
          

            return View("~/Views/Frontend/Services.cshtml");
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
            return View("~/Views/Frontend/Document.cshtml");



        }



        public ActionResult Makepayment()
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


             return RedirectToAction("TestatorHomePageIndex", "TestatorHomePage");


        }




        public ActionResult insertDocumentDetails(TestatorFormModel TFM)
        {


           














           

          








           
















        





            



            



            // DOCUMENT RULES
            string typeid = "";
            int typecat = 0;
            if (TFM.documenttype == "WillCodocilPOA")
            {
                typeid = "1,2,3";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();

            }
            if (TFM.documenttype == "Codocil")
            {
                typeid = "2";



                con.Open();
                string qq1 = "update users set   Codocil = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();


            }
            if (TFM.documenttype == "POA")
            {
                typeid = "3";

                con.Open();
                string qq1 = "update users set  POA = '1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "Will")
            {
                typeid = "1";
                con.Open();
                string qq1 = "update users set Will = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillCodocil")
            {
                typeid = "1,2";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillPOA")
            {
                typeid = "1,3";

                con.Open();
                string qq1 = "update users set Will = '1'  , POA = '1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilPOA")
            {
                typeid = "2,3";

                con.Open();
                string qq1 = "update users set  Codocil = '1' , POA = '1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilWill")
            {
                typeid = "2,1";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAWill")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1'  , POA = '1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "Giftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set  Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "GiftdeedsCodocil")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set  Codocil = '1'  , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftdeedsWill")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' ,  Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftdeedsPOA")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set  POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' ,  Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set   POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set   Codocil = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilGiftdeedsWill")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' ,  Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilGiftdeedsWillPOA")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilWillGiftdeedsPOA")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "WillCodocilPOAGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
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
                string qq1 = "update users set  LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
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
                string qq1 = "update users set Will = '1'  , POA = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "POALivingWillWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
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
                string qq1 = "update users set  POA = '1' , Giftdeeds='1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAGiftdeedsWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1'  , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAWillCodocil")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilLivingWill")
            {

                con.Open();
                string qq1 = "update users set   Codocil = '1' ,  LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set   Codocil = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POALivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1'  , POA = '1' , . LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "GiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1'  Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
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
                string qq1 = "update users set   POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillGiftDeedsPOA")
            {

                con.Open();
                string qq1 = "update users set  POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftDeedsLivingWillPOA")
            {

                con.Open();
                string qq1 = "update users set  POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillCodocil")
            {

                con.Open();
                string qq1 = "update users set  Codocil = '1' ,   LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set  Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' ,  Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftdeedsPOA")
            {

                con.Open();
                string qq1 = "update users set  POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "LivingWillPOA")
            {

                con.Open();
                string qq1 = "update users set  POA = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillGiftdeedsCodocil")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "WillGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set  Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillCodocilGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' ,  Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' ,  LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "LivingWillWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1'  , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "POAWillGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }



            if (TFM.documenttype == "GiftdeedsPOAWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1'  , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
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


            ViewBag.PaymentLink = "true";




            return View("~/Views/Frontend/Document.cshtml");

        }


        public string checkwilldocument()
        {
            int NestId = 0;
            string status = "";
            int getid = Convert.ToInt32(Session["uuid"]);


            con.Open();
            string identifydoc = "select Will from users where Will = 1 and uId = "+ getid + " ";
            SqlDataAdapter da = new SqlDataAdapter(identifydoc,con);
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
                   
                    string qchk001 = "select a.fId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Marital_Status , a.Religion , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.tId , a.active , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Is_Informed_Person from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where b.tId =   " + NestId + "  ";
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
                 
                    string qchk002 = "select a.bpId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_proof , a.Identity_proof_value , a.Alt_Identity_proof , a.Alt_Identity_proof_value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.beneficiary_type from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId where b.tId = " + NestId + "  and a.doctype='Will'";
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




                    // for assetinformation
                   
                    string qchk003 = "select a.aiid , a.atId , a.amId , a.tid , a.docid , a.Json from AssetInformation a inner join TestatorDetails b on a.tid=b.tId where b.tId = " + NestId + "  and a.doctype='Will'  ";
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

                   
                    string qchk006 = "select a.Beneficiary_Asset_ID , a.AssetType_ID , a.AssetCategory_ID , a.SchemeName , a.InstrumentName , a.Beneficiary_ID , a.Proportion , a.tid from BeneficiaryAssets a inner join TestatorDetails b on a.tid=b.tId where b.tId = " + NestId + "  and a.doctype='Will'";
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






                    // for nominee


                  
                    string qchk007 = " select a.nId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.Description_of_Assets from Nominee a inner join TestatorDetails b on a.tId=b.tId where b.tId = " + NestId + "  ";
                    SqlDataAdapter chk007da = new SqlDataAdapter(qchk007, con);
                    DataTable chk007dt = new DataTable();
                    chk007da.Fill(chk007dt);
                    con.Close();

                    if (chk007dt.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        status = "false";
                    }

                    //end





                    // for appointees 

                 
                    string qchk008 = "select * from Appointees where tid = " + NestId + " and doctype='Will' ";
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






                    //end







                }
            }

            con.Close();




           
            




            return status;
        }





        public string checkcodocildocument()
        {
            int NestId = 0;
            string status = "";
            int getid = Convert.ToInt32(Session["uuid"]);


            con.Open();
            string identifydoc = "select Codocil from users where Codocil = 1 and uId = " + getid + " ";
            SqlDataAdapter da = new SqlDataAdapter(identifydoc, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["Codocil"]) == 1)
                {



                    // check which document is active


                    // for Codocil

                    string qchk002 = "SELECT * FROM Codocil where uId = " + getid + " ";
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





                }
            }







            return status;
        }







        public string checklivindocument()
        {
            int NestId = 0;
            string status = "";
            int getid = Convert.ToInt32(Session["uuid"]);


            con.Open();
            string identifydoc = "select LivingWill from users where LivingWill = 1 and uId = " + getid + " ";
            SqlDataAdapter da = new SqlDataAdapter(identifydoc, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["LivingWill"]) == 1)
                {



                    // check which document is active


                    // for Codocil

                    string qchk002 = "SELECT * FROM living_Will where uId = " + getid + " ";
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





                }
            }







            return status;
        }


    }
}