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
    public class LoginPageController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        SqlConnection con = new SqlConnection(connectionString);
        // GET: LoginPage
        public ActionResult LoginPageIndex()
        {
            if (Request.QueryString["Type"] != null)
            {
                if (Request.QueryString["Type"].ToString() == "message")
                {
                    ViewBag.type = "(Please Check Email-ID For Credentials)";
                }
                
            }


            if (TempData["ForgotPasswordProcess"] != null)
            {
                if (TempData["ForgotPasswordProcess"].ToString() == "True")
                {
                    ViewBag.EnablePassword = "true";
                }

               

            }

            if (TempData["changed"] != null)
            {

            if (TempData["changed"].ToString() == "true")
            {
                ViewBag.passmsg = "true";
            }


            }


            return View("~/Views/LoginPage/LoginPageContent.cshtml");
        }



        public ActionResult frontendindex()

        {






            return View("~/Views/Frontend/Index.cshtml");
        }



        public ActionResult DynamicMenu()
        {
            return View("~/Views/LoginPage/DynamicMenuPageContent.cshtml");
        }

        [HttpPost]
        public ActionResult LoginPageData(LoginModel LM)
        {


            List<LoginModel> Lmlist = new List<LoginModel>();

            con.Open();
            string query = "select * from users where userID = '"+LM.UserID+"' and userPwd = '"+LM.Password+ "' and active = 'Active'";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                //declaration
                Session["rId"] = Convert.ToInt32(dt.Rows[0]["rId"]);
                Session["uid"] = dt.Rows[0]["userID"].ToString();
                Session["uuid"] = Convert.ToInt32(dt.Rows[0]["uId"]);
                Session["compId"] = Convert.ToInt32(dt.Rows[0]["compId"]);
                Session["Type"] = dt.Rows[0]["Type"].ToString();
                Session["willchk"] = dt.Rows[0]["Will"].ToString();
                Session["ComparerrId"] = Convert.ToInt32(dt.Rows[0]["rId"]);
                Session["displayname"] = dt.Rows[0]["First_Name"].ToString();
                //Session["WillType"] = dt.Rows[0]["WillType"].ToString();
                con.Open();
               string query2 = "select * from roles where rId = "+ Session["rId"] + " ";
               SqlDataAdapter da2 = new SqlDataAdapter(query2,con);
               DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    // declaration
                    Session["Role"] = dt2.Rows[0]["Role"].ToString();
                   
                }
                else
                {
                    Session["Role"] = dt.Rows[0]["Type"].ToString();
                }



                string q = "select * from Assignment_Roles where RoleId = "+ Convert.ToInt32(Session["rId"]) + "";
                SqlDataAdapter da3 = new SqlDataAdapter(q,con);
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


                if (dt.Rows[0]["Type"].ToString() == "Testator")
                {


                    int testid = 0;


                        con.Open();
                        string query4 = "select tId ,Email_OTP, Mobile_OTP from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                        SqlDataAdapter d4a = new SqlDataAdapter(query4, con);
                        DataTable dta = new DataTable();
                        d4a.Fill(dta);
                        con.Close();

                  
                        if (dta.Rows.Count > 0)
                        {

                            testid = Convert.ToInt32(dta.Rows[0]["tId"]);
                            Session["LoginOTP"] = dta.Rows[0]["Email_OTP"].ToString();
                            Session["MobileOTP"] = dta.Rows[0]["Mobile_OTP"].ToString();


                        // check verify if very direct menu else otp verify

                        con.Open();
                        string query42 = "select Designation from users where uId = "+ Convert.ToInt32(Session["uuid"]) + " and Designation = 1 ";
                        SqlDataAdapter d4a2 = new SqlDataAdapter(query42, con);
                        DataTable dta2 = new DataTable();
                        d4a2.Fill(dta2);
                        con.Close();


                        if (dta2.Rows.Count > 0)
                        {
                            con.Open();
                            string qq222 = "select PaymentStatus from testatordetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                            SqlDataAdapter daa22 = new SqlDataAdapter(qq222, con);
                            DataTable paydtt = new DataTable();
                            daa22.Fill(paydtt);
                            con.Close();

                            if (Convert.ToInt32(paydtt.Rows[0]["PaymentStatus"]) == 1)
                            {
                                //  return RedirectToAction("EnableDocumentLinks", "DashBoard");
                                //return RedirectToAction("Index", "Frontend", new { displayname = Session["displayname"].ToString() });

                                return RedirectToAction("TestatorHomePageIndex", "TestatorHomePage", new { displayname = Session["displayname"].ToString() });
                            }
                            else
                            {
                                return RedirectToAction("TestatorHomePageIndex", "TestatorHomePage", new { displayname = Session["displayname"].ToString() });
                            }


                               
                        }
                        else
                        {
                            return RedirectToAction("TestatorHomePageIndex", "TestatorHomePage");
                        }


                       
                        }






                    return RedirectToAction("TestatorHomePageIndex", "TestatorHomePage");


                }
                else
                {
                    return RedirectToAction("DashBoardIndex", "DashBoard");
                }




            }
            else
            {
                ViewBag.Message = "FAILED";
                return View("~/Views/LoginPage/LoginPageContent.cshtml");
            }

            

            

            
        }



        public ActionResult Logout()
        {
           

            // used in master
            Session["Role"] = "";

            // alternate not req
           // Session["apId"] = "";

            // used in many
            Session["rId"] = "";    // not checked  in login

            // only in login
            Session["uid"] = "";    // not checked  in login

            // used in 3 users
            Session["compId"] = "";

            // in controller
            Session["filterUid"] = "";

            // in controller
            Session["amId"] = "";


            // in controller
            Session["aiid"] = "";

            // alt bene not req
            //Session["bpId"] = "";

            // tid commented
            //Session["tid"] = "";

            // in controller
            Session["Document_Created_By"] = "";

            // in controller
            Session["mailto"] = "";

            // in controller
            Session["userid"] = "";


            Session["uuid"] = "";

            // in controller
            Session["upcompanyid"] = "";

            // in controller 
            Session["upbeneficiaryid"] = "";

            // in controller 
            Session["upappointeesid"] = "";


            // in Dashboard in control  
            Session["LoginOTP"] = "";


            // in Dashboard in control
            Session["enteredOTP"] = "";

            // in add testator for mail sending in control

            Session["TestatorEmail"] = "";


            // in login in control

            Session["Type"] = "";


            // for checking document  in control

            Session["doctype"] = "";


            // for checing will   

            Session["willchk"] = "";  // not sure


            // in control
            Session["MobileOTP"] = "";

            // for view to active view page
            Session["activeview"] = "";


            // for pet lia mapp total 

            Session["totalliablities"] = "";
            Session["totalpetcare"] = "";

            Session["assettypeidforpetcare"] = "";
            Session["assetcategoryidforpetcare"] = "";


            Session["assettypeidforliablities"] = "";
            Session["assetcategoryidforliablities"] = "";


            // for document bal
            Session["distidbal"] = "";


            // for distributor text box
            Session["disttestator"] = "";
            Session["distid"] = "";


            // on dashboard
            Session["documentamount"] = "";

            Session["displayname"] = "";

            Session["nomineeform"] = "";


            Session["typ"] = "";


            Session["WillType"] = "";


            Session["testatorID"] = "";


            return View("~/Views/LoginPage/LoginPageContent.cshtml");
        }



        public ActionResult LogoutFrontend()
        {
            Session["displayname"] = "";
            ViewBag.enableMultipleSelect = "false";

            return RedirectToAction("Index", "Frontend");
        }




        public ActionResult InsertParentMenu(DynamicMenuModel DMM)
        {

            con.Open();
            string query = "insert into parentmenu (ParentName) values ('"+DMM.ParentMenu+"') ";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();




          return  View("~/Views/LoginPage/DynamicMenuPageContent.cshtml");
        }



        public string BindParent()
        {
            string data = "";
            con.Open();
            string query = "select * from parentmenu";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<option value=" + Convert.ToInt32(dt.Rows[i]["ParentId"]) + ">"+ dt.Rows[i]["ParentName"].ToString() + "</option>";
                }
                
            }


            return data;
        }




        public ActionResult InsertChildmenu(DynamicMenuModel DMM)
        {


            con.Open();
            string query = "insert into dynamicmenu (ParentId,ParentMenu,ChildMenu,ChildUrl) values ('" + DMM.parentid + "' ,'" + DMM.parenttxt + "' , '"+DMM.ChildMenu+"' , '"+DMM.ChildUrl+"') ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();


            return View("~/Views/LoginPage/DynamicMenuPageContent.cshtml");
        }



        public ActionResult ViewLogout()
        {


            return RedirectToAction("LoginPageIndex", "LoginPage");
        }






        public ActionResult ForgotpasswordMail(LoginModel LM)
        {

            //generate EMAIL OTP
         
        
            string sTempChars = String.Empty;
            Random rand = new Random();

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


            // new mail code
            string mailto = LM.EmailID;
            string Userid = LM.EmailID;

            Session["userid"] = Userid;
            string subject = "OTP For Forgot Password Request";
            string OTP = "<font color='Green' style='font-size=3em;'>" + EmailOTP + "</font>";
            string text = "Your OTP for Forgot Password Process Is " + OTP + "";
            string body = "<font color='red'>" + text + "</font>";


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




            con.Open();
            string query = "insert into ForgotPassword_Tbl (Email,OTP,OTP_Status) values ('"+LM.EmailID+"' , '"+EmailOTP+"' , 'InActive')";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();




            TempData["ForgotPasswordProcess"] = "True";



            return RedirectToAction("LoginPageIndex", "LoginPage");
        }







        public ActionResult UpdateNewPassword(LoginModel LM)
        {

            con.Open();

            string query1 = "select Email , OTP from ForgotPassword_Tbl where OTP = "+LM.FOTP+" ";
            SqlDataAdapter da1 = new SqlDataAdapter(query1,con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            if (dt1.Rows.Count > 0)
            {

                if (dt1.Rows[0]["OTP"].ToString() == LM.FOTP)
                {
                    // identify user id
                    string query2 = "select uId from users where eMail = '"+dt1.Rows[0]["Email"].ToString()+ "' and  Type='Testator'";
                    SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    // end

                  

                    if (dt2.Rows.Count > 0)
                    {
                        // update password
                        string query3 = "update users set userPwd = '"+LM.FPassword+"' where uId = "+ Convert.ToInt32(dt2.Rows[0]["uId"]) + " and Type='Testator' ";
                        SqlCommand cmd3 = new SqlCommand(query3,con);
                        cmd3.ExecuteNonQuery();
                        //end


                        TempData["changed"] = "true";

                    }

                   



                }

            }





            con.Close();




            return RedirectToAction("LoginPageIndex", "LoginPage");
        }







        public string CheckOTP()
        {

            string Response = Request["send"].ToString();
            string msg = "";

            con.Open();

            string query1 = "select Email , OTP from ForgotPassword_Tbl where OTP = " + Response + " ";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            if (dt1.Rows.Count > 0)
            {

                if (dt1.Rows[0]["OTP"].ToString() == Response)
                {

                    msg = "true";


                }


            }
            else
            {
                msg = "false";
            }





            con.Close();

            return msg;


        }



        public string EmailCheckOTP()
        {
            string Response = Request["send"].ToString();
            string msg = "";
            con.Open();
            string query = "select * from users where  eMail = '"+ Response + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {
                msg = "true";
            }
            else
            {
                msg = "false";
            }


            con.Close();





            return msg;
        }





    }
}