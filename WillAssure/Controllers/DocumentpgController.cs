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
using System.Globalization;


namespace WillAssure.Controllers
{
    public class DocumentpgController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: Documentpg
        public ActionResult DocumentpgIndex()
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
                string qry3 = "select Giftdeeds , Designation  from users where Will = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
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
                string qry312 = "select LivingWill , Designation  from users where Will = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlDataAdapter daa23 = new SqlDataAdapter(qry312, con);
                DataTable dtt43 = new DataTable();
                daa23.Fill(dtt43);
                if (dtt43.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtt43.Rows[0]["LivingWill"]) == 1 && Convert.ToInt32(dtt43.Rows[0]["Designation"]) == 1)
                    {
                        ViewBag.documentbtn5 = "true";
                    }
                }
                con.Close();
                //end



            }
            else
            {
                ViewBag.showtitle = "true";
                ViewBag.documentlink = "true";

            }




            return View("~/Views/Documentpg/DocumentPgPageContent.cshtml");
        }



        public ActionResult insertDocumentDetails(TestatorFormModel TFM)
        {

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
                string qry3 = "select Giftdeeds , Designation  from users where Will = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
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
                string qry312 = "select LivingWill , Designation  from users where Will = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlDataAdapter daa23 = new SqlDataAdapter(qry312, con);
                DataTable dtt43 = new DataTable();
                daa23.Fill(dtt43);
                if (dtt43.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtt43.Rows[0]["LivingWill"]) == 1 && Convert.ToInt32(dtt43.Rows[0]["Designation"]) == 1)
                    {
                        ViewBag.documentbtn5 = "true";
                    }
                }
                con.Close();
                //end



            }
            else
            {
                ViewBag.showtitle = "true";
                ViewBag.documentlink = "true";

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







            int testatorid = 0;
            int templateid = 0;
            string testatortype = "";


            if (Session["TestatorEmail"] == null)
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }



            // coupon status
            if (TFM.txtCoupon != null)
            {
                con.Open();
                string checkcoupon = "select * from couponAllotment where Coupon_Number = " + TFM.txtCoupon + " and  Status = 'Active' ";
                SqlDataAdapter da = new SqlDataAdapter(checkcoupon, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    string upcoupon = "update couponAllotment set Status = 'Inactive' ,    Tid=" + testatorid + " ";
                    SqlCommand cmd2 = new SqlCommand(upcoupon, con);
                    cmd2.ExecuteNonQuery();




                    string upcoupon2 = "update discountCoupons set status = 'Inactive' ,    Coupon_Number=" + TFM.txtCoupon + " ";
                    SqlCommand cmd22 = new SqlCommand(upcoupon2, con);
                    cmd22.ExecuteNonQuery();




                }
                else
                {
                    ViewBag.Message = "checkCoupon";
                }
                con.Close();
            }


            //end

            // get coupon id
            con.Open();
            string query5 = "select a.couponId  from couponAllotment a inner join users b on a.uId=b.uId where b.uId = " + TFM.distributor_id + "";
            SqlDataAdapter da4 = new SqlDataAdapter(query5, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            int couponsid = 0;
            if (dt4.Rows.Count > 0)
            {
                couponsid = Convert.ToInt32(dt4.Rows[0]["couponId"]);
            }
            con.Close();
            //end


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


            // get distributor id

            con.Open();
            string gedistid = "select uId from TestatorDetails where tId="+testatorid+" ";
            SqlDataAdapter distid = new SqlDataAdapter(gedistid, con);
            DataTable distdt = new DataTable();
            distid.Fill(distdt);
            int distidd = 0;
            if (distdt.Rows.Count > 0)
            {
                distidd = Convert.ToInt32(distdt.Rows[0]["uId"]);
            }
            con.Close();


            //end



        





            con.Open();
            string q1 = "insert into documentMaster (tId,templateId,IsUpdatetable,uId,pId,created_by,testator_type,couponId,adminVerification) values (" + testatorid + " , " + templateid + " ,  'Yes' ,   " + TFM.distributor_id + " , 1 , '" + TFM.Document_Created_By_txt + "' , '" + testatortype + "' , "+couponsid+"  , 2)";
            SqlCommand c = new SqlCommand(q1, con);
            c.ExecuteNonQuery();
            con.Close();



            //end



            // DOCUMENT RULES
            int typeid = 0;
            int typecat = 0;

            if (TFM.documenttype == "Will")
            {
                typeid = 1;
            }
            if (TFM.documentcategory == "Quick")
            {
                typecat = 1;
            }
            if (TFM.documentcategory == "Detailed")
            {
                typecat = 2;
            }


            con.Open();
            string q2 = "insert into documentRules (documentType,category,tid,executors_category,AlternateBenficiaries,AlternateExecutors) values (" + typeid + " , " + typecat + "  , " + testatorid + " , 0 , 0 , 0 )";
            SqlCommand c1 = new SqlCommand(q2, con);
            c1.ExecuteNonQuery();
            con.Close();



            //

            //1st condition
            if (TFM.Amt_Paid_By_txt == "Distributor" && TFM.Document_Created_By_txt == "Distributor")
            {
                TFM.Authentication_Required = 0;
                TFM.Link_Required = 0;
                TFM.Login_Required = 0;

                con.Open();
                string query1 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , " + distidd + " , '" + TFM.Amt_Paid_By_txt + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query1, con);
                cmd2.ExecuteNonQuery();
                con.Close();
                ModelState.Clear();
                return View("~/Views/AddTestatorsForm/AddTestatorPageContent.cshtml");
            }
            //end
            //2nd condition 
            if (TFM.Amt_Paid_By_txt == "Distributor" && TFM.Document_Created_By_txt == "Testator")
            {
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query2 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , " + distidd + " , '" + TFM.Amt_Paid_By_txt + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "')  ";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.ExecuteNonQuery();
                con.Close();



                if (Session["mailto"] == null)
                {
                    RedirectToAction("LoginPageIndex", "LoginPage");
                }
                if (Session["userid"] == null)
                {
                    RedirectToAction("LoginPageIndex", "LoginPage");
                }
                //// new mail code
                //string mailto = TFM.Email;
                //string Userid = TFM.Identity_proof_Value;
                //mailto = Session["TestatorEmail"].ToString();
                //Session["userid"] = Userid;
                //string subject = "Testing Mail Sending";
                //string OTP = "<font color='Green' style='font-size=3em;'>" + TFM.EmailOTP + "</font>";
                //string text = "Your OTP for Verification Is " + OTP + "";
                //string body = "<font color='red'>" + text + "</font>";


                //MailMessage msg = new MailMessage();
                //msg.From = new MailAddress("info@drinco.in");
                //msg.To.Add(mailto);
                //msg.Subject = subject;
                //msg.Body = body;

                //msg.IsBodyHtml = true;
                //SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
                //smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
                //smtp.EnableSsl = false;
                //smtp.Send(msg);
                //smtp.Dispose();



                ////end



            }
            //end
            // 3rd condtion
            if (TFM.Amt_Paid_By_txt == "Testator" && TFM.Document_Created_By_txt == "Distributor")
            {
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , " + distidd + " , '" + TFM.Amt_Paid_By_txt + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query3, con);
                cmd2.ExecuteNonQuery();
                con.Close();









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
            //end
            //4th condition
            if (TFM.Amt_Paid_By_txt == "Testator" && TFM.Document_Created_By_txt == "Testator")
            {
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query4 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , " + distidd + " , '" + TFM.Amt_Paid_By_txt + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "')  ";
                SqlCommand cmd2 = new SqlCommand(query4, con);
                cmd2.ExecuteNonQuery();
                con.Close();






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
            //end








            string v1 = Eramake.eCryptography.Encrypt(TFM.EmailOTP);



            return View("~/Views/Documentpg/DocumentPgPageContent.cshtml");

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
            string query = "select uId , First_Name from users where Linked_user = " + Convert.ToInt32(Session["uuid"]) + "   and Type = 'DistributorAdmin'   ";
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




        public ActionResult VerifyOTP(LoginModel EVM)
        {

           

            return View("~/Views/LoginPage/LoginPageContent.cshtml");

        }


    }
}