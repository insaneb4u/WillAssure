﻿using System;
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
using System.Globalization;
using System.IO;
using Newtonsoft.Json.Linq;

namespace WillAssure.Controllers
{
    public class AddTestatorsFormController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: AddTestatorsForm
        public ActionResult AddTestatorsFormIndex()
        {
            
                ViewBag.collapse = "true";
            
           
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



            if (typ == "Testator")
            {
                // check will status
                con.Open();
                string qry1 = "select Will  from users where Will = 1 ";
                SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                DataTable dtt1 = new DataTable();
                daa1.Fill(dtt1);
                if (dtt1.Rows.Count > 0)
                {
                    ViewBag.documentbtn1 = "true";
                }
                con.Close();
                //end


                // check codocil status
                con.Open();
                string qry22 = "select Codocil  from users where Codocil = 1 ";
                SqlDataAdapter daa22 = new SqlDataAdapter(qry22, con);
                DataTable dtt22 = new DataTable();
                daa22.Fill(dtt22);
                if (dtt22.Rows.Count > 0)
                {
                    ViewBag.documentbtn2 = "true";
                }
                con.Close();

                //end


                // check Poa status
                con.Open();
                string qry4 = "select POA  from users where POA = 1 ";
                SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                DataTable dtt4 = new DataTable();
                daa4.Fill(dtt4);
                if (dtt4.Rows.Count > 0)
                {
                    ViewBag.documentbtn3 = "true";
                }
                con.Close();
                //end


                // check gift deeds status
                con.Open();
                string qry3 = "select Giftdeeds  from users where Giftdeeds = 1 ";
                SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                DataTable dtt3 = new DataTable();
                daa3.Fill(dtt3);
                if (dtt3.Rows.Count > 0)
                {
                    ViewBag.documentbtn4 = "true";
                }
                con.Close();
                //end
            }
            else
            {

                ViewBag.documentlink = "true";

            }



            if (Session["rId"] == null || Session["uuid"] == null)
            {

               RedirectToAction("LoginPageIndex", "LoginPage");

            }
            //if (Session["compId"] == null)
            //{
            //    ViewBag.Message = "link";
            //}

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



            // check type 
            string typ2 = "";
            con.Open();
            string qq12 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa2 = new SqlDataAdapter(qq12, con);
            DataTable dtt2 = new DataTable();
            daa2.Fill(dtt2);
            con.Close();

            if (dtt2.Rows.Count > 0)
            {
                typ = dtt2.Rows[0]["Type"].ToString();
            }



            //end



            if (typ2 == "Testator")
            {
                // check will status
                con.Open();
                string qry1 = "select Will  from users where Will = 1 ";
                SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                DataTable dtt1 = new DataTable();
                daa1.Fill(dtt1);
                if (dtt1.Rows.Count > 0)
                {
                    ViewBag.documentbtn1 = "true";
                }
                con.Close();
                //end


                // check codocil status
                con.Open();
                string qry22 = "select Codocil  from users where Codocil = 1 ";
                SqlDataAdapter daa22 = new SqlDataAdapter(qry22, con);
                DataTable dtt22 = new DataTable();
                daa2.Fill(dtt2);
                if (dtt2.Rows.Count > 0)
                {
                    ViewBag.documentbtn2 = "true";
                }
                con.Close();

                //end


                // check Poa status
                con.Open();
                string qry4 = "select POA  from users where POA = 1 ";
                SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                DataTable dtt4 = new DataTable();
                daa4.Fill(dtt4);
                if (dtt4.Rows.Count > 0)
                {
                    ViewBag.documentbtn3 = "true";
                }
                con.Close();
                //end


                // check gift deeds status
                con.Open();
                string qry3 = "select Giftdeeds  from users where Giftdeeds = 1 ";
                SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                DataTable dtt3 = new DataTable();
                daa3.Fill(dtt3);
                if (dtt3.Rows.Count > 0)
                {
                    ViewBag.documentbtn4 = "true";
                }
                con.Close();
                //end
            }
            else
            {

                ViewBag.documentlink = "true";

            }





            return View("~/Views/AddTestatorsForm/AddTestatorPageContent.cshtml");
        }


        public string onchangeemailtxt()
        {
            // check count for email and mobile

            con.Open();
            string chkmobilemail = "select Value from Settings_vals";
            SqlDataAdapter chkmobilemailda = new SqlDataAdapter(chkmobilemail, con);
            DataTable chkmobilemaildt = new DataTable();
            chkmobilemailda.Fill(chkmobilemaildt);
            int chkcount = 0;
            if (chkmobilemaildt.Rows.Count > 0)
            {
                chkcount = Convert.ToInt32(chkmobilemaildt.Rows[0]["Value"]);

            }
            con.Close();





            con.Open();
            string chkmobilemail2 = "select count(Email) as EmailCount from TestatorDetails";
            SqlDataAdapter chkmobilemailda2 = new SqlDataAdapter(chkmobilemail2, con);
            DataTable chkmobilemaildt2 = new DataTable();
            chkmobilemailda2.Fill(chkmobilemaildt2);
            int emailcount = 0;
            if (chkmobilemaildt2.Rows.Count > 0)
            {
                emailcount = Convert.ToInt32(chkmobilemaildt2.Rows[0]["EmailCount"]);

            }
            con.Close();

            string msg = "";
            if (chkcount == emailcount)
            {
                msg = "true";
            }


            return msg;




            


        }




        public string onchangemobiletxt()
        {
            // check count for email and mobile

            con.Open();
            string chkmobilemail = "select Value from Settings_vals";
            SqlDataAdapter chkmobilemailda = new SqlDataAdapter(chkmobilemail, con);
            DataTable chkmobilemaildt = new DataTable();
            chkmobilemailda.Fill(chkmobilemaildt);
            int chkcount = 0;
            if (chkmobilemaildt.Rows.Count > 0)
            {
                chkcount = Convert.ToInt32(chkmobilemaildt.Rows[0]["Value"]);

            }
            con.Close();





            con.Open();
            string chkmobilemail2 = "select count(Mobile) as MobileCount from TestatorDetails";
            SqlDataAdapter chkmobilemailda2 = new SqlDataAdapter(chkmobilemail2, con);
            DataTable chkmobilemaildt2 = new DataTable();
            chkmobilemailda2.Fill(chkmobilemaildt2);
            int mobilecount = 0;
            if (chkmobilemaildt2.Rows.Count > 0)
            {
                mobilecount = Convert.ToInt32(chkmobilemaildt2.Rows[0]["MobileCount"]);

            }
            con.Close();

            string msg = "";
            if (chkcount == mobilecount)
            {
                msg = "true";
            }


            return msg;







        }



        public ActionResult InsertTestatorFormData(TestatorFormModel TFM)
        {

            ViewBag.collapse = "true";

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



            if (typ == "Testator")
            {
                // check will status
                con.Open();
                string qry1 = "select Will  from users where Will = 1 ";
                SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                DataTable dtt1 = new DataTable();
                daa1.Fill(dtt1);
                if (dtt1.Rows.Count > 0)
                {
                    ViewBag.documentbtn1 = "true";
                }
                con.Close();
                //end


                // check codocil status
                con.Open();
                string qry2 = "select Codocil  from users where Codocil = 1 ";
                SqlDataAdapter daa2 = new SqlDataAdapter(qry2, con);
                DataTable dtt2 = new DataTable();
                daa2.Fill(dtt2);
                if (dtt2.Rows.Count > 0)
                {
                    ViewBag.documentbtn2 = "true";
                }
                con.Close();

                //end


                // check Poa status
                con.Open();
                string qry4 = "select POA  from users where POA = 1 ";
                SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                DataTable dtt4 = new DataTable();
                daa4.Fill(dtt4);
                if (dtt4.Rows.Count > 0)
                {
                    ViewBag.documentbtn3 = "true";
                }
                con.Close();
                //end


                // check gift deeds status
                con.Open();
                string qry3 = "select Giftdeeds  from users where Giftdeeds = 1 ";
                SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                DataTable dtt3 = new DataTable();
                daa3.Fill(dtt3);
                if (dtt3.Rows.Count > 0)
                {
                    ViewBag.documentbtn4 = "true";
                }
                con.Close();
                //end
            }
            else
            {

                ViewBag.documentlink = "true";

            }

            // check type 
            string typ5 = "";
            con.Open();
            string qq15 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa5 = new SqlDataAdapter(qq15, con);
            DataTable dtt5 = new DataTable();
            daa5.Fill(dtt5);
            con.Close();

            if (dtt5.Rows.Count > 0)
            {
                typ = dtt5.Rows[0]["Type"].ToString();
            }



            //end



            if (typ5 == "Testator")
            {
                // check will status
                con.Open();
                string qry1 = "select Will  from users where Will = 1 ";
                SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                DataTable dtt1 = new DataTable();
                daa1.Fill(dtt1);
                if (dtt1.Rows.Count > 0)
                {
                    ViewBag.documentbtn1 = "true";
                }
                con.Close();
                //end


                // check codocil status
                con.Open();
                string qry2 = "select Codocil  from users where Codocil = 1 ";
                SqlDataAdapter daa2 = new SqlDataAdapter(qry2, con);
                DataTable dtt2 = new DataTable();
                daa2.Fill(dtt2);
                if (dtt2.Rows.Count > 0)
                {
                    ViewBag.documentbtn2 = "true";
                }
                con.Close();

                //end


                // check Poa status
                con.Open();
                string qry4 = "select POA  from users where POA = 1 ";
                SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                DataTable dtt4 = new DataTable();
                daa4.Fill(dtt4);
                if (dtt4.Rows.Count > 0)
                {
                    ViewBag.documentbtn3 = "true";
                }
                con.Close();
                //end


                // check gift deeds status
                con.Open();
                string qry3 = "select Giftdeeds  from users where Giftdeeds = 1 ";
                SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                DataTable dtt3 = new DataTable();
                daa3.Fill(dtt3);
                if (dtt3.Rows.Count > 0)
                {
                    ViewBag.documentbtn4 = "true";
                }
                con.Close();
                //end
            }
            else
            {

                ViewBag.documentlink = "true";

            }

            // roleassignment
            List<LoginModel> Lmlist = new List<LoginModel>();
            con.Open();
            string q3 = "select * from Assignment_Roles where RoleId = " + Convert.ToInt32(Session["rId"]) + "";
            SqlDataAdapter da3 = new SqlDataAdapter(q3, con);
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


            //end




            //generate Password OTP
            TFM.userPassword = String.Empty;
            string[] saAllowedCharacters3 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            int iOTPLength3 = 5;

            string sTempChars3 = String.Empty;
            Random rand3 = new Random();

            for (int i = 0; i < iOTPLength3; i++)

            {

                int p = rand3.Next(0, saAllowedCharacters3.Length);

                sTempChars3 = saAllowedCharacters3[rand3.Next(0, saAllowedCharacters3.Length)];

                TFM.userPassword += sTempChars3;

            }
            //END















           

            // insert testator data on users


    



            con.Open();
            SqlCommand cm = new SqlCommand("SP_Users", con);
            cm.CommandType = System.Data.CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@condition", "insert");
            cm.Parameters.AddWithValue("@FirstName", TFM.First_Name);
            cm.Parameters.AddWithValue("@LastName", TFM.Last_Name);
            cm.Parameters.AddWithValue("@MiddleName", TFM.Middle_Name);



            DateTime dat2 = DateTime.ParseExact(TFM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            cm.Parameters.AddWithValue("@Dob", dat2);
            cm.Parameters.AddWithValue("@Mobile", TFM.Mobile);
            cm.Parameters.AddWithValue("@Email", TFM.Email);
            cm.Parameters.AddWithValue("@Address1", TFM.Address1);
            cm.Parameters.AddWithValue("@Address2", TFM.Address2);
            cm.Parameters.AddWithValue("@Address3", TFM.Address3);
            cm.Parameters.AddWithValue("@City", TFM.citytext);
            cm.Parameters.AddWithValue("@State ", TFM.statetext);
            cm.Parameters.AddWithValue("@Pin", TFM.Pin);
            cm.Parameters.AddWithValue("@Linked_user", TFM.distributor_id);
            cm.Parameters.AddWithValue("@UserId", TFM.Email);
            cm.Parameters.AddWithValue("@UserPassword", TFM.userPassword);
            cm.Parameters.AddWithValue("@rid", 5);
            cm.Parameters.AddWithValue("@Active", "Active");
            cm.Parameters.AddWithValue("@compId", 0);
            cm.Parameters.AddWithValue("@Designation", 2);
            cm.ExecuteNonQuery();
            con.Close();




            string userid = "";
            con.Open();
            string qery2 = "select top 1 * from users order by uId desc";
            SqlDataAdapter da2 = new SqlDataAdapter(qery2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {

                userid = Convert.ToString(dt2.Rows[0]["uId"]);


            }
            con.Close();


            con.Open();
            string qury3 = "update  users set Type='Testator' where uId = " + userid + "  ";
            SqlCommand cm2 = new SqlCommand(qury3, con);
            cm2.ExecuteNonQuery();
            con.Close();

            if (TFM.Email != "")
            {
                //generate Mail
                string mailto2 = TFM.Email;
                string userlogin = TFM.Email;

        
                string subject = "Will Assure Login Credentials";

                string text = "<font color='Green' style='font-size=3em;'>Your UserId And Password For Logging In Is <br> UserID : " + userlogin + " <br> Password : " + TFM.userPassword + "</font>";
                string body = "<font color='red'>" + text + "</font>";


                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("info@drinco.in");
                msg.To.Add(mailto2);
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





            //end


            if (Session["TestatorEmail"] == null)
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }
           


            //TFM.uId = Convert.ToInt32(Session["filterUid"]);
            DateTime dat = DateTime.ParseExact(TFM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDTestatorDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@First_Name", TFM.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", TFM.Last_Name);
                cmd.Parameters.AddWithValue("@Middle_Name", TFM.Middle_Name);
                cmd.Parameters.AddWithValue("@DOB", dat);
                cmd.Parameters.AddWithValue("@Occupation", TFM.Occupation);
                cmd.Parameters.AddWithValue("@Mobile", TFM.Mobile);
                cmd.Parameters.AddWithValue("@Email", TFM.Email);
                Session["TestatorEmail"] = TFM.Email;
                cmd.Parameters.AddWithValue("@maritalStatus", TFM.material_status_txt);
                cmd.Parameters.AddWithValue("@Religion", TFM.Religiontext);
                cmd.Parameters.AddWithValue("@Relationship", "none");
                cmd.Parameters.AddWithValue("@Identity_Proof", TFM.Identity_Proof_txt);
                cmd.Parameters.AddWithValue("@Identity_proof_Value", TFM.Identity_proof_Value);
                cmd.Parameters.AddWithValue("@Alt_Identity_Proof", TFM.Alt_Identity_Proof);
                cmd.Parameters.AddWithValue("@Alt_Identity_proof_Value", TFM.Alt_Identity_proof_Value);
                cmd.Parameters.AddWithValue("@Gender", TFM.Gendertext);
                cmd.Parameters.AddWithValue("@Address1", TFM.Address1);
                cmd.Parameters.AddWithValue("@Address2", TFM.Address2);
                cmd.Parameters.AddWithValue("@Address3", TFM.Address3);
                cmd.Parameters.AddWithValue("@City", TFM.citytext);
                cmd.Parameters.AddWithValue("@State", TFM.statetext);
                cmd.Parameters.AddWithValue("@Country", TFM.countrytext);
                cmd.Parameters.AddWithValue("@Pin", TFM.Pin);
                cmd.Parameters.AddWithValue("@active", TFM.active);
                //cmd.Parameters.AddWithValue("@Contact_Verification", "0");
                //cmd.Parameters.AddWithValue("@Email_Verification", "0");
                //cmd.Parameters.AddWithValue("@Mobile_Verification_Status", "0");
                //cmd.Parameters.AddWithValue("@Email_OTP", TFM.EmailOTP);
                //cmd.Parameters.AddWithValue("@Mobile_OTP", TFM.MobileOTP);
                cmd.Parameters.AddWithValue("@uid", userid);
                Session["userid"] = userid;
                cmd.ExecuteNonQuery();
                con.Close();

            int testatorid = 0;

         

            con.Open();
            string gettid = "select top 1 tId from TestatorDetails order by tId desc";
            SqlDataAdapter datid = new SqlDataAdapter(gettid, con);
            DataTable dttid = new DataTable();
            datid.Fill(dttid);
            if (dttid.Rows.Count > 0)
            {
                testatorid = Convert.ToInt32(dttid.Rows[0]["tId"]);
            }
            con.Close();




          




            ModelState.Clear();
            ViewBag.Message = "Verified";







            // document generation 







            //    //1st condition
            //    if (TFM.Amt_Paid_By_txt == "Distributor" && TFM.Document_Created_By_txt == "Distributor")
            //    {
            //        TFM.Authentication_Required = 0;
            //        TFM.Link_Required = 0;
            //        TFM.Login_Required = 0;

            //        con.Open();
            //        string query1 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , '" + TFM.Document_Created_By_ID + "' , '" + TFM.Amt_Paid_By_txt + "' , '" + TFM.Amt_Paid_By + "'  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
            //        SqlCommand cmd2 = new SqlCommand(query1, con);
            //        cmd2.ExecuteNonQuery();
            //        con.Close();
            //    ModelState.Clear();
            //    return View("~/Views/AddTestatorsForm/AddTestatorPageContent.cshtml");
            //}
            //    //end
            //    //2nd condition 
            //    if (TFM.Amt_Paid_By_txt == "Distributor" && TFM.Document_Created_By_txt == "Testator")
            //    {
            //        TFM.Authentication_Required = 1;
            //        TFM.Link_Required = 1;
            //        TFM.Login_Required = 1;

            //        con.Open();
            //        string query2 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , '" + TFM.Document_Created_By_ID + "' , '" + TFM.Amt_Paid_By_txt + "' , '" + TFM.Amt_Paid_By + "'  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
            //        SqlCommand cmd2 = new SqlCommand(query2, con);
            //        cmd2.ExecuteNonQuery();
            //        con.Close();



            //    if (Session["mailto"] == null)
            //    {
            //        RedirectToAction("LoginPageIndex", "LoginPage");
            //    }
            //    if (Session["userid"] == null)
            //    {
            //        RedirectToAction("LoginPageIndex", "LoginPage");
            //    }
            //    // new mail code
            //    string mailto = TFM.Email;
            //        string Userid = TFM.Identity_proof_Value;
            //        Session["mailto"] = mailto;
            //        Session["userid"] = Userid;
            //        string subject = "Testing Mail Sending";
            //        string OTP = "<font color='Green' style='font-size=3em;'>" + TFM.EmailOTP + "</font>";
            //        string text = "Your OTP for Verification Is " + OTP + "";
            //        string body = "<font color='red'>" + text + "</font>";


            //        MailMessage msg = new MailMessage();
            //        msg.From = new MailAddress("info@drinco.in");
            //        msg.To.Add(mailto);
            //        msg.Subject = subject;
            //        msg.Body = body;

            //        msg.IsBodyHtml = true;
            //        SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
            //        smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
            //        smtp.EnableSsl = false;
            //        smtp.Send(msg);
            //        smtp.Dispose();



            //        //end



            //    }
            //    //end
            //    // 3rd condtion
            //    if (TFM.Amt_Paid_By_txt == "Testator" && TFM.Document_Created_By_txt == "Distributor")
            //    {
            //        TFM.Authentication_Required = 1;
            //        TFM.Link_Required = 1;
            //        TFM.Login_Required = 1;

            //        con.Open();
            //        string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , '" + TFM.Document_Created_By_ID + "' , '" + TFM.Amt_Paid_By_txt + "' , '" + TFM.Amt_Paid_By + "'  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
            //        SqlCommand cmd2 = new SqlCommand(query3, con);
            //        cmd2.ExecuteNonQuery();
            //        con.Close();









            //        // new mail code
            //        string mailto = TFM.Email;
            //        string Userid = TFM.Identity_proof_Value;
            //        Session["mailto"] = mailto;
            //        Session["userid"] = Userid;
            //        string subject = "Testing Mail Sending";
            //        string OTP = "<font color='Green' style='font-size=3em;'>" + TFM.EmailOTP + "</font>";
            //        string text = "Your OTP for Verification Is " + OTP + "";
            //        string body = "<font color='red'>" + text + "</font>";


            //        MailMessage msg = new MailMessage();
            //        msg.From = new MailAddress("info@drinco.in");
            //        msg.To.Add(mailto);
            //        msg.Subject = subject;
            //        msg.Body = body;

            //        msg.IsBodyHtml = true;
            //        SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
            //        smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
            //        smtp.EnableSsl = false;
            //        smtp.Send(msg);
            //        smtp.Dispose();



            //    //end




            //    }
            //    //end
            //    //4th condition
            //    if (TFM.Amt_Paid_By_txt == "Testator" && TFM.Document_Created_By_txt == "Testator")
            //    {
            //        TFM.Authentication_Required = 1;
            //        TFM.Link_Required = 1;
            //        TFM.Login_Required = 1;

            //        con.Open();
            //        string query4 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , '" + TFM.Document_Created_By_ID + "' , '" + TFM.Amt_Paid_By_txt + "' , '" + TFM.Amt_Paid_By + "'  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
            //        SqlCommand cmd2 = new SqlCommand(query4, con);
            //        cmd2.ExecuteNonQuery();
            //        con.Close();






            //        // new mail code
            //        string mailto = TFM.Email;
            //        string Userid = TFM.Identity_proof_Value;
            //        Session["mailto"] = mailto;
            //        Session["userid"] = Userid;
            //        string subject = "Testing Mail Sending";
            //        string OTP = "<font color='Green' style='font-size=3em;'>" + TFM.EmailOTP + "</font>";
            //        string text = "Your OTP for Verification Is " + OTP + "";
            //        string body = "<font color='red'>" + text + "</font>";


            //        MailMessage msg = new MailMessage();
            //        msg.From = new MailAddress("info@drinco.in");
            //        msg.To.Add(mailto);
            //        msg.Subject = subject;
            //        msg.Body = body;

            //        msg.IsBodyHtml = true;
            //        SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
            //        smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
            //        smtp.EnableSsl = false;
            //        smtp.Send(msg);
            //        smtp.Dispose();



            //        //end

            //    }
            ////end








            //string v1 = Eramake.eCryptography.Encrypt(TFM.EmailOTP);



            //return RedirectToAction("DocumentpgIndex", "Documentpg");
            //}
            //else
            //{
            //    ViewBag.Message = "link";

            //}

            //generate MOBILE OTP
            TFM.MobileOTP = String.Empty;
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            int iOTPLength = 5;

            string sTempChars = String.Empty;
            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                TFM.MobileOTP += sTempChars;

            }
            //END




            //generate EMAIL OTP
            TFM.EmailOTP = String.Empty;
            string[] saAllowedCharacters2 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            int iOTPLength2 = 5;

            string sTempChars2 = String.Empty;
            Random rand2 = new Random();

            for (int i = 0; i < iOTPLength2; i++)

            {

                int p = rand.Next(0, saAllowedCharacters2.Length);

                sTempChars2 = saAllowedCharacters2[rand.Next(0, saAllowedCharacters2.Length)];

                TFM.EmailOTP += sTempChars2;

            }
            //END


            
            if (TFM.Email != "")
            {
                // new mail code
                string mailto = TFM.Email;
                string Userid = TFM.Identity_proof_Value;
                mailto = Session["TestatorEmail"].ToString();
                Session["userid"] = Userid;
                string subject = "Testing Mail Sending";
                string OTP = "<font color='Green' style='font-size=3em;'>" + TFM.EmailOTP + "</font>";
                string text = "Your OTP for Verification Is " + OTP + "";
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
            }



            // mobile OTP

            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("http://167.86.89.78:7412/api/mt/SendSMS?user=rnarvadeempire&password=microlan@123&senderid=RNDEVE&channel=Trans&DCS=0&flashsms=0&number=" + TFM.Mobile + "&text=OTP for Will Assure Verification is : " + TFM.MobileOTP + "+sms&route=1051");
            HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(Resp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            Resp.Close();






            //END







            // update otp for email and mobile

            con.Open();
            string qq = "update TestatorDetails set Contact_Verification = 0 ,Email_Verification = 0 , Mobile_Verification_Status = 0 , Email_OTP = '" + TFM.EmailOTP + "' , Mobile_OTP = '" + TFM.MobileOTP + "' where  tId = " + testatorid + " ";
            SqlCommand cmddd = new SqlCommand(qq, con);
            cmddd.ExecuteNonQuery();
            con.Close();





            //end

            return View("~/Views/AddTestatorsForm/AddTestatorPageContent.cshtml");
          

        }





        public String BindCountryDDL()
        {

            con.Open();
            string query = "select distinct * from country_tbl order by CountryName asc  ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select Country--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["CountryID"].ToString() + " >" + dt.Rows[i]["CountryName"].ToString() + "</option>";



                }




            }

            return data;

        }



        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state order by statename asc  ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select State--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["state_id"].ToString() + " >" + dt.Rows[i]["statename"].ToString() + "</option>";



                }




            }

            return data;

        }






        public String BindCityDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_city  order by city_name asc ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select City--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["id"].ToString() + " >" + dt.Rows[i]["city_name"].ToString() + "</option>";



                }




            }

            return data;

   }


        public string OnChangeBindState()
        {
            string response = Request["send"];
            con.Open();
            string query = "select distinct * from tbl_state where country_id = '" + response + "' order by statename asc";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select State--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["state_id"].ToString() + " >" + dt.Rows[i]["statename"].ToString() + "</option>";



                }




            }

            return data;
           }




        public string OnChangeBindCity()
        {
            string response = Request["send"];
            con.Open();
            string query = "select distinct * from tbl_city where state_id = '" + response + "' order by city_name asc";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select City--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["id"].ToString() + " >" + dt.Rows[i]["city_name"].ToString() + "</option>";



                }




            }

            return data;
        }

        public String BindRelationDDL()
        {

            con.Open();
            string query = "select * from relationship";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value='' >--Select--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["Rid"].ToString() + " >" + dt.Rows[i]["MemberName"].ToString() + "</option>";



                }




            }

            return data;

        }



        public string BindDistributorDDL()
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
            string data = "<option value=''>--Select Distributor--</option>";
            con.Open();
            string query = "select uId , First_Name from users where Linked_user = "+Convert.ToInt32(Session["uuid"])+ "   and Type = 'DistributorAdmin'   ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["uId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";



                }




            }
            else
            {

                con.Open();
                string query2 = "select uId , First_Name from users where uId = " + Convert.ToInt32(Session["uuid"]) + "  ";
                SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                con.Close();
              

                if (dt2.Rows.Count > 0)
                {


                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {




                        data = data + "<option value=" + dt2.Rows[i]["uId"].ToString() + " >" + dt2.Rows[i]["First_Name"].ToString() + "</option>";



                    }
                }

                }

            return data;
        }


    }
}