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


            if (typ == "Testator")
            {
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
                    string qry312 = "select LivingWill , Designation  from users where LivingWill = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
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
                    ViewBag.PaymentLink = "true";
                }




            }

            else
            {
                ViewBag.showtitle = "true";
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

            Session["distidbal"] = TFM.distributor_id;

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
                ViewBag.showtitle = "true";
           
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
            cm.Parameters.AddWithValue("@UserPassword", "None");
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

            if (TFM.Email != "" || TFM.Amt_Paid_By == "Testator")
            {
               

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
                cmd.Parameters.AddWithValue("@Contact_Verification", "0");
                cmd.Parameters.AddWithValue("@Email_Verification", "0");
                cmd.Parameters.AddWithValue("@Mobile_Verification_Status", "0");
                cmd.Parameters.AddWithValue("@Email_OTP", "0");
                cmd.Parameters.AddWithValue("@Mobile_OTP", "0");
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
            //ViewBag.Message = "Verified";







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

        



            ViewBag.Type = "create";

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
            string data = "";

            if (Session["Type"] != null)
            {

                if (Session["Type"].ToString() != "DistributorAdmin")
                {
                    data = "<option value=''>--Select Distributor--</option>";
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

                }
                else
                {

                    con.Open();
                    string query = "select uId , First_Name from users where uId = " + Convert.ToInt32(Session["uuid"]) + "  ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();


                    if (dt.Rows.Count > 0)
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {




                            data = dt.Rows[i]["First_Name"].ToString() + "~" + dt.Rows[i]["uId"].ToString();



                        }




                    }

                }

            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }


          


            return data;
        }



        public ActionResult insertDocumentDetails(TestatorFormModel TFM)
        {


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
                typ5 = dtt5.Rows[0]["Type"].ToString();
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
                    int distid = 0;
                    string testatortype = "";
                    string Email = "";


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




            // get testator id and dist id from lastest inserted

            con.Open();
            string gettid = "select max(tId) as tid , max(uId) as uid from testatordetails";
            SqlDataAdapter tida = new SqlDataAdapter(gettid, con);
            DataTable tidt = new DataTable();
            tida.Fill(tidt);
            if (tidt.Rows.Count > 0)
            {
                testatorid = Convert.ToInt32(tidt.Rows[0]["tid"]);
                distid = Convert.ToInt32(tidt.Rows[0]["uId"]);

            }
            con.Close();





            //end


            // update password for the users

            con.Open();
            string qtt = "update users set userPwd = " + TFM.userPassword + " where uId = " + distid + " ";
            SqlCommand cmd = new SqlCommand(qtt,con);
            cmd.ExecuteNonQuery();
            con.Close();



            //end







            // identitfy email of testator

                    con.Open();
                    string tquery = "select Email from testatordetails where tId = " + testatorid + " ";
                    SqlDataAdapter tda = new SqlDataAdapter(tquery, con);
                    DataTable tdt = new DataTable();
                    tda.Fill(tdt);
                    if (tdt.Rows.Count > 0)
                    {
                        Email = tdt.Rows[0]["Email"].ToString();

                    }
                    con.Close();




                    //end










               






                    // get coupon id
                    con.Open();
                    string query5 = "select a.couponId  from couponAllotment a inner join users b on a.uId=b.uId where b.uId = " + distid + "";
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
                    string q1 = "insert into documentMaster (tId,templateId,IsUpdatetable,uId,pId,created_by,testator_type,couponId,adminVerification) values (" + testatorid + " , " + templateid + " ,  'Yes' ,   " + distid + " , 1 , '" + TFM.Document_Created_By + "' , '" + testatortype + "' , " + couponsid + "  , 2)";
                    SqlCommand c = new SqlCommand(q1, con);
                    c.ExecuteNonQuery();
                    con.Close();



                    //end



                    // DOCUMENT RULES
                    string typeid = "";
                    int typecat = 0;
                    if (TFM.documenttype == "WillCodocilPOA")
                    {
                        typeid = "1,2,3";

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();

                    }
                    if (TFM.documenttype == "Codocil")
                    {
                        typeid = "2";



                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();


                    }
                    if (TFM.documenttype == "POA")
                    {
                        typeid = "3";

                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "Will")
                    {
                        typeid = "1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "WillCodocil")
                    {
                        typeid = "1,2";

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "WillPOA")
                    {
                        typeid = "1,3";

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "CodocilPOA")
                    {
                        typeid = "2,3";

                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "CodocilWill")
                    {
                        typeid = "2,1";

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "POAWill")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "Giftdeeds")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "GiftdeedsCodocil")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "GiftdeedsWill")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "GiftdeedsPOA")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }


                    if (TFM.documenttype == "WillGiftdeeds")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' ,  Giftdeeds='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "POAGiftdeeds")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "CodocilGiftdeeds")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "CodocilGiftdeedsWill")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "CodocilGiftdeedsWillPOA")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "CodocilWillGiftdeedsPOA")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "WillCodocilPOAGiftdeeds")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "WillCodocilPOAGiftdeedsLivingWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "LivingWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='0' , LivingWill='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "LivingWillWillCodocilPOAGiftdeeds")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "CodocilGiftdeedsLivingWillWillPOA")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "LivingWillWillPOA")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "POALivingWillWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "LivingWillPOAGiftdeeds")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "POAGiftdeeds")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "POAGiftdeedsWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "POAWillCodocil")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='0', LivingWill='0' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "CodocilLivingWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "CodocilGiftdeedsLivingWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "POALivingWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "GiftdeedsLivingWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
            if (TFM.documenttype == "WillCodocilPOAGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "POAGiftDeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillGiftDeedsPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftDeedsLivingWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillCodocil")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftdeedsPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "LivingWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillGiftdeedsCodocil")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "WillGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillCodocilGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "LivingWillWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "WillPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "POAWillGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }



            if (TFM.documenttype == "GiftdeedsPOAWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillCodocilGiftdeedsPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillCodocilGiftdeedsPOALivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
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
                    string q2 = "insert into documentRules (documentType,category,guardian , executors_category , AlternateBenficiaries , AlternateGaurdian , AlternateExecutors , tid) values ('" + TFM.documenttype + "' , " + typecat + "  ,  0  , 0 , 0 , 0 , 0 , " + testatorid + " )";
                    SqlCommand c1 = new SqlCommand(q2, con);
                    c1.ExecuteNonQuery();
                    con.Close();



            //


            if (Session["distidbal"] == null)
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }


                    //1st condition
                    if (TFM.Amt_Paid_By == "Distributor" && TFM.Document_Created_By == "Distributor")
                    {
                        int cal = 0;
                        con.Open();
                        string qq1 = "select Balance_Count from  allotmentDistributor";
                        SqlDataAdapter qq1da = new SqlDataAdapter(qq1,con);
                        DataTable qq1dt = new DataTable();
                        qq1da.Fill(qq1dt);
                        int bal = 0;
                        if (qq1dt.Rows.Count > 0)
                        {
                            bal = Convert.ToInt32(qq1dt.Rows[0]["Balance_Count"]);
                        }
                        con.Close();

                        cal = bal - 1;

                        Response.Write("<script>alert('Balance Document For Distributor is :"+cal+"')</script>");
                        con.Open();
                        string qqchk = "update allotmentDistributor set Balance_Count = "+cal+" where uId = "+ Convert.ToInt32(Session["distidbal"]) + "  ";
                        SqlCommand cccm = new SqlCommand(qqchk,con);
                        cccm.ExecuteNonQuery();
                        con.Close();
                       
                        TFM.Authentication_Required = 0;
                        TFM.Link_Required = 0;
                        TFM.Login_Required = 0;

                        con.Open();
                        string query1 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , " + distid + " , '" + TFM.Amt_Paid_By_txt + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                        SqlCommand cmd2 = new SqlCommand(query1, con);
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        ModelState.Clear();
                        return View("~/Views/AddTestatorsForm/AddTestatorPageContent.cshtml");
                    }
                    //end
                    //2nd condition 
                    if (TFM.Amt_Paid_By == "Distributor" && TFM.Document_Created_By == "Testator")
                    {

                int cal = 0;
                con.Open();
                string qq1 = "select Balance_Count from  allotmentDistributor";
                SqlDataAdapter qq1da = new SqlDataAdapter(qq1, con);
                DataTable qq1dt = new DataTable();
                qq1da.Fill(qq1dt);
                int bal = 0;
                if (qq1dt.Rows.Count > 0)
                {
                    bal = Convert.ToInt32(qq1dt.Rows[0]["Balance_Count"]);
                }
                con.Close();

                cal = bal - 1;

                con.Open();
                string qqchk = "update allotmentDistributor set Balance_Count = " + cal + " where uId = " + Convert.ToInt32(Session["distidbal"]) + "  ";
                SqlCommand cccm = new SqlCommand(qqchk, con);
                cccm.ExecuteNonQuery();
                con.Close();


                TFM.Authentication_Required = 1;
                        TFM.Link_Required = 1;
                        TFM.Login_Required = 1;

                        con.Open();
                        string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By + "' , " + distid + " , '" + TFM.Amt_Paid_By + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                        SqlCommand cmd2 = new SqlCommand(query3, con);
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
                        // new mail code
                        //string mailto = TFM.Email;
                        //string Userid = TFM.Identity_proof_Value;
                        //mailto = Email;

                        //string subject = "Will Assure Link For Payment";
                        //string body = "<font color='Green' style='font-size=3em;'> Click the Link To Make A Payment For The Document :</font> <a href='https://razorpay.com/'>Payment</a> ";



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



                        //end

                        // payment status for testator details table
                        con.Open();
                        string paymentquery2 = "update TestatorDetails set PaymentStatus = 1 where tId = " + testatorid + " ";
                        SqlCommand paymentcmd2 = new SqlCommand(paymentquery2, con);
                        paymentcmd2.ExecuteNonQuery();
                        con.Close();
                        //end


                        // payment info
                        con.Open();
                        string paymentquery = "insert into PaymentInfo (uId,tId,transactionStatus) values (" + distid + " , " + testatorid + " , 1)  ";
                        SqlCommand paymentcmd = new SqlCommand(paymentquery, con);
                        paymentcmd.ExecuteNonQuery();
                        con.Close();
                        //end

                        ViewBag.PaymentLink = "true";
                    }
                    //end
                    // 3rd condtion
                    if (TFM.Amt_Paid_By == "Testator" && TFM.Document_Created_By == "Distributor")
                    {
                ViewBag.msg = "true";
                TFM.Authentication_Required = 1;
                        TFM.Link_Required = 1;
                        TFM.Login_Required = 1;

                        con.Open();
                        string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By + "' , " + distid + " , '" + TFM.Amt_Paid_By + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                        SqlCommand cmd2 = new SqlCommand(query3, con);
                        cmd2.ExecuteNonQuery();
                        con.Close();




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



              
                    // new mail code
                    string mailto = Email;
                    string Userid = Email;
                    mailto = Session["TestatorEmail"].ToString();
                    Session["userid"] = Userid;
                    string subject1 = "Testing Mail Sending";
                    string OTP1 = "<font color='Green' style='font-size=3em;'>" + TFM.EmailOTP + "</font>";
                    string text1 = "Your OTP for Verification Is " + OTP1 + "";
                    string body1 = "<font color='red'>" + text1 + "</font>";


                    MailMessage msg1 = new MailMessage();
                    msg1.From = new MailAddress("info@drinco.in");
                    msg1.To.Add(mailto);
                    msg1.Subject = subject1;
                    msg1.Body = body1;

                    msg1.IsBodyHtml = true;
                    SmtpClient smtp1 = new SmtpClient("216.10.240.149", 25);
                    smtp1.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
                    smtp1.EnableSsl = false;
                    smtp1.Send(msg1);
                    smtp1.Dispose();



                    //end
                



                // mobile OTP

                //HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("http://167.86.89.78:7412/api/mt/SendSMS?user=rnarvadeempire&password=microlan@123&senderid=RNDEVE&channel=Trans&DCS=0&flashsms=0&number=" + TFM.Mobile + "&text=OTP for Will Assure Verification is : " + TFM.MobileOTP + "+sms&route=1051");
                //HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();
                //System.IO.StreamReader respStreamReader = new System.IO.StreamReader(Resp.GetResponseStream());
                //string responseString = respStreamReader.ReadToEnd();
                //respStreamReader.Close();
                //Resp.Close();






                //END





                








                //generate Mail
                string mailto2 = Email;
                string userlogin = Email;


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



                // update otp for email and mobile

                con.Open();
                string qq = "update TestatorDetails set Contact_Verification = 0 ,Email_Verification = 0 , Mobile_Verification_Status = 0 , Email_OTP = '" + TFM.EmailOTP + "' , Mobile_OTP = '" + TFM.MobileOTP + "' where  tId = " + testatorid + " ";
                SqlCommand cmddd = new SqlCommand(qq, con);
                cmddd.ExecuteNonQuery();
                con.Close();





                //end





                // new mail code
                //string mailto = TFM.Email;
                //string Userid = TFM.Identity_proof_Value;
                //mailto = Email;
                //string subject = "Will Assure Link For Payment";
                //string body = "<font color='Green' style='font-size=3em;'> Click the Link To Make A Payment For The Document :</font> <a href='https://razorpay.com/'>Payment</a> ";



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



                //end

                // payment status for testator details table
                con.Open();
                        string paymentquery2 = "update TestatorDetails set PaymentStatus = 1 where tId = " + testatorid + " ";
                        SqlCommand paymentcmd2 = new SqlCommand(paymentquery2, con);
                        paymentcmd2.ExecuteNonQuery();
                        con.Close();
                        //end

                        // payment info
                        con.Open();
                        string paymentquery = "insert into PaymentInfo (uId,tId,transactionStatus) values (" + distid + " , " + testatorid + " , 1)  ";
                        SqlCommand paymentcmd = new SqlCommand(paymentquery, con);
                        paymentcmd.ExecuteNonQuery();
                        con.Close();
                        //end

                        ViewBag.PaymentLink = "true";
                    }
                    //end
                    //4th condition
                    if (TFM.Amt_Paid_By == "Testator" && TFM.Document_Created_By == "Testator")
                    {
                ViewBag.msg = "true";
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By + "' , " + distid + " , '" + TFM.Amt_Paid_By + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query3, con);
                cmd2.ExecuteNonQuery();
                con.Close();




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



               
                    // new mail code
                    string mailto = Email;
                    string Userid = Email;
                    mailto = Session["TestatorEmail"].ToString();
                    Session["userid"] = Userid;
                    string subject1 = "Testing Mail Sending";
                    string OTP1 = "<font color='Green' style='font-size=3em;'>" + TFM.EmailOTP + "</font>";
                    string text1 = "Your OTP for Verification Is " + OTP1 + "";
                    string body1 = "<font color='red'>" + text1 + "</font>";


                    MailMessage msg1 = new MailMessage();
                    msg1.From = new MailAddress("info@drinco.in");
                    msg1.To.Add(mailto);
                    msg1.Subject = subject1;
                    msg1.Body = body1;

                    msg1.IsBodyHtml = true;
                    SmtpClient smtp1 = new SmtpClient("216.10.240.149", 25);
                    smtp1.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
                    smtp1.EnableSsl = false;
                    smtp1.Send(msg1);
                    smtp1.Dispose();



                    //end
                



                // mobile OTP

                //HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("http://167.86.89.78:7412/api/mt/SendSMS?user=rnarvadeempire&password=microlan@123&senderid=RNDEVE&channel=Trans&DCS=0&flashsms=0&number=" + TFM.Mobile + "&text=OTP for Will Assure Verification is : " + TFM.MobileOTP + "+sms&route=1051");
                //HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();
                //System.IO.StreamReader respStreamReader = new System.IO.StreamReader(Resp.GetResponseStream());
                //string responseString = respStreamReader.ReadToEnd();
                //respStreamReader.Close();
                //Resp.Close();






                //END





              






                //generate Mail
                string mailto2 = Email;
                string userlogin = Email;


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



                // update otp for email and mobile

                con.Open();
                string qq = "update TestatorDetails set Contact_Verification = 0 ,Email_Verification = 0 , Mobile_Verification_Status = 0 , Email_OTP = '" + TFM.EmailOTP + "' , Mobile_OTP = '" + TFM.MobileOTP + "' where  tId = " + testatorid + " ";
                SqlCommand cmddd = new SqlCommand(qq, con);
                cmddd.ExecuteNonQuery();
                con.Close();





                //end





                // new mail code
                //string mailto = TFM.Email;
                //string Userid = TFM.Identity_proof_Value;
                //mailto = Email;
                //string subject = "Will Assure Link For Payment";
                //string body = "<font color='Green' style='font-size=3em;'> Click the Link To Make A Payment For The Document :</font> <a href='https://razorpay.com/'>Payment</a> ";



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



                //end

                // payment status for testator details table
                con.Open();
                string paymentquery2 = "update TestatorDetails set PaymentStatus = 1 where tId = " + testatorid + " ";
                SqlCommand paymentcmd2 = new SqlCommand(paymentquery2, con);
                paymentcmd2.ExecuteNonQuery();
                con.Close();
                //end

                // payment info
                con.Open();
                string paymentquery = "insert into PaymentInfo (uId,tId,transactionStatus) values (" + distid + " , " + testatorid + " , 1)  ";
                SqlCommand paymentcmd = new SqlCommand(paymentquery, con);
                paymentcmd.ExecuteNonQuery();
                con.Close();
                //end

                ViewBag.PaymentLink = "true";
            }
            //end





            ViewBag.collapse = "true";
            

            ModelState.Clear();




            //end


            


            return View("~/Views/AddTestatorsForm/AddTestatorPageContent.cshtml");

        }


    }
}