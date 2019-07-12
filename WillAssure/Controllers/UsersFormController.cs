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

namespace WillAssure.Controllers
{
    public class UsersFormController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        public ActionResult UsersFormIndex()
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


                con.Open();
                string qq12 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " and designation = 1 ";
                SqlDataAdapter da42 = new SqlDataAdapter(qq12, con);
                DataTable d4t2 = new DataTable();
                da42.Fill(d4t2);
                con.Close();

                if (d4t2.Rows.Count > 0)
                {
                    ViewBag.documentlink = "true";
                }


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






            if (Session["rId"] == null || Session["uuid"] == null)
            {

                RedirectToAction("LoginPageIndex", "LoginPage");

            }
            //if (Session["tid"]== null)
            //{
            //    ViewBag.message = "link";
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

            int RoleId = Convert.ToInt32(Session["rId"]); 

            return View("~/Views/UsersForm/UsersFormPageContent.cshtml");
        }

        public ActionResult GetUserFormData(UserFormModel UFM)
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
                ViewBag.showtitle = "true";
                ViewBag.documentlink = "true";

            }


            int newusers = 0;
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


            //if (Session["compId"] != null)
            //{


                con.Open();
                string q = "select count(*) from users where userID = '"+ UFM.UserId + "'";
                SqlCommand c = new SqlCommand(q, con);
                int count = (int)c.ExecuteScalar();

                if (count > 0)
                {
                    ViewBag.Message = "Duplicate";
                }
                else
                {
                   
                    SqlCommand cmd = new SqlCommand("SP_Users", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@condition", "insert");
                    cmd.Parameters.AddWithValue("@FirstName", UFM.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", UFM.LastName);
                    cmd.Parameters.AddWithValue("@MiddleName", UFM.MiddleName);

                    

                    DateTime dat = DateTime.ParseExact(UFM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                    cmd.Parameters.AddWithValue("@Dob", dat);
                    cmd.Parameters.AddWithValue("@Mobile", UFM.Mobile);
                    cmd.Parameters.AddWithValue("@Email", UFM.Email);
                    cmd.Parameters.AddWithValue("@Address1", UFM.Address1);


                if (UFM.Address2 != null)
                {
                    cmd.Parameters.AddWithValue("@Address2", UFM.Address2);
                }
                else
                {
                    UFM.Address2 = "None";
                    cmd.Parameters.AddWithValue("@Address2", UFM.Address2);
                }

                if (UFM.Address3 != null)
                {
                    cmd.Parameters.AddWithValue("@Address3", UFM.Address3);
                }
                else
                {
                    UFM.Address3 = "None";
                    cmd.Parameters.AddWithValue("@Address3", UFM.Address3);
                }



                
                    cmd.Parameters.AddWithValue("@City", UFM.citytext);
                    cmd.Parameters.AddWithValue("@State ", UFM.statetext);
                    cmd.Parameters.AddWithValue("@Pin", UFM.Pin);
                    cmd.Parameters.AddWithValue("@UserId", UFM.UserId);
                    cmd.Parameters.AddWithValue("@UserPassword", UFM.UserPassword);
                    cmd.Parameters.AddWithValue("@Designation", UFM.Designation);
                    cmd.Parameters.AddWithValue("@Active", UFM.Active);

                //UFM.rid = 0;
                //if (Convert.ToInt32(Session["rId"]) != 2)
                //{
                    UFM.rid = 2;
                    cmd.Parameters.AddWithValue("@rid", UFM.rid);
                //}
                //else
                //{

                //    cmd.Parameters.AddWithValue("@rid", UFM.rid);
                //}


                UFM.CompId = 0;

                cmd.Parameters.AddWithValue("@compId", UFM.CompId);





                    cmd.Parameters.AddWithValue("@Linked_user", UFM.rid);
                    cmd.ExecuteNonQuery();


                





               

                    con.Close();




                //generate Mail
                string mailto = "";
                string userid1 = "";

                mailto = UFM.Email;
                userid1 = UFM.UserId;
                string subject = "Will Assure Login Credentials";

                string text = "<font color='Green' style='font-size=3em;'>Your UserId And Password For Logging In Is <br> UserID : " + userid1 + " <br> Password : " + UFM.UserPassword + "</font>";
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








                // get latest uid by userid filter
                string userid = ""; 
                    con.Open();
                    string query2 = "select top 1 * from users order by uId desc";
                    SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    
                    if (dt2.Rows.Count > 0)
                    {

                        userid = Convert.ToString(dt2.Rows[0]["userID"]);
              

                    }
                    con.Close();



                con.Open();
                string q1 = "select * from users where userID = '" + userid + "'  ";
                SqlDataAdapter qda = new SqlDataAdapter(q1, con);
                DataTable qdt = new DataTable();
                qda.Fill(qdt);

                if (qdt.Rows.Count > 0)
                {
                    newusers = Convert.ToInt32(qdt.Rows[0]["uId"]);
                    Session["filterUid"] = newusers;
                }
                con.Close();


                //end


                //Linked Users Query

                con.Open();

                string LinkedQuery = "update users set Linked_user = " + Convert.ToInt32(Session["uuid"]) + " where uId = " + newusers + "  ";
                SqlCommand LinkedCommand = new SqlCommand(LinkedQuery,con);
                LinkedCommand.ExecuteNonQuery();
                con.Close();
                
                //end





                con.Open();
                string query3 = "update  users set Type='DistributorAdmin' where uId = " + newusers + "  ";
                SqlCommand cm = new SqlCommand(query3, con);
                cm.ExecuteNonQuery();
                con.Close();




                ViewBag.Message = "Verified";

                }
            con.Close();


            // company data

            if (UFM.check == "true")
            {

                string s = "none";
                string s2 = "none";
                string s3 = "none";
                string s4 = "none";

                con.Open();
                SqlCommand companycmd = new SqlCommand("SP_CrudcompanyDetails", con);
                companycmd.CommandType = System.Data.CommandType.StoredProcedure;
                companycmd.Parameters.AddWithValue("@condition", "insert");
                companycmd.Parameters.AddWithValue("@companyName ", UFM.ccompanyName);
                companycmd.Parameters.AddWithValue("@ownerName", UFM.cownerName);
                companycmd.Parameters.AddWithValue("@ownerMobileNo", UFM.cownerMobileNo);
                companycmd.Parameters.AddWithValue("@Address1", UFM.cAddress1);
                companycmd.Parameters.AddWithValue("@Address2", UFM.cAddress2);
                companycmd.Parameters.AddWithValue("@City", UFM.ccitytext);
                companycmd.Parameters.AddWithValue("@State", UFM.cstatetext);
                companycmd.Parameters.AddWithValue("@Pin", UFM.cPin);
                companycmd.Parameters.AddWithValue("@GST_NO", UFM.cGST_NO);
                companycmd.Parameters.AddWithValue("@Identity_Proof", UFM.cIdentity_Proof);
                companycmd.Parameters.AddWithValue("@Identity_Proof_Value", UFM.cIdentity_Proof_Value);
                companycmd.Parameters.AddWithValue("@Alt_Identity_Proof", UFM.cAlt_Identity_Proof);
                companycmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", UFM.cAlt_Identity_Proof_Value);
                companycmd.Parameters.AddWithValue("@contactPerson", UFM.ccontactPerson);
                companycmd.Parameters.AddWithValue("@contactMobileNo", UFM.ccontactMobileNo);
                companycmd.Parameters.AddWithValue("@contactMailId", UFM.ccontactMailId);
                companycmd.Parameters.AddWithValue("@bankName", UFM.cbankName);
                companycmd.Parameters.AddWithValue("@Branch", UFM.cBranch);
                companycmd.Parameters.AddWithValue("@accountNumber", UFM.caccountNumber);
                companycmd.Parameters.AddWithValue("@IFSC_Code", UFM.cIFSC_Code);
                companycmd.Parameters.AddWithValue("@accountName", UFM.caccountName);
                companycmd.Parameters.AddWithValue("@Referred_By", UFM.cReferred_By);
                companycmd.Parameters.AddWithValue("@leadgeneratedBy", s);
                companycmd.Parameters.AddWithValue("@leadconvertedBy", s2);
                companycmd.Parameters.AddWithValue("@relationshipManager", UFM.crelationshipManager);
                companycmd.Parameters.AddWithValue("@leadStatus", s3);
                companycmd.Parameters.AddWithValue("@leadRemark", s4);
                companycmd.ExecuteNonQuery();
                con.Close();


       


                // ASSIGN TYPE

                con.Open();
                string companyquery3 = "update  users set Type='DistributorAdmin' where uId = " + newusers + "  ";
                SqlCommand companycm = new SqlCommand(companyquery3, con);
                companycm.ExecuteNonQuery();
                con.Close();



                //END





                // get latest inserted compid
                string companyquery5 = "select top 1 * from companyDetails order by compId desc";
                SqlDataAdapter companyda5 = new SqlDataAdapter(companyquery5, con);
                DataTable companydt5 = new DataTable();
                companyda5.Fill(companydt5);
                int compid = 0;
                if (companydt5.Rows.Count > 0)
                {
                    compid = Convert.ToInt32(companydt5.Rows[0]["compId"]);
                }
                else
                {
                    compid = 0;
                }
                //end



                // update user with latest compid
                con.Open();
                string companyquery6 = "update users set compId=" + compid + " where uId=" + newusers + "";
                SqlCommand companycmd2 = new SqlCommand(companyquery6, con);
                companycmd2.ExecuteNonQuery();
                con.Close();
                //end




            }




     







            ModelState.Clear();








            //end



            //}
            //else
            //{

            //    ViewBag.Message = "link";

            //}












            return View("~/Views/UsersForm/UsersFormPageContent.cshtml");
        }



     


        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state where country_id = 101 order by statename asc";
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




        public String BindRoleDDL()
        {
            string data = "";

       
                 data = "<option value=''>--Select Role--</option>";
            
                

            if (Session["rId"] != null)
            {
                int roles = 0;
                roles = Convert.ToInt32(Session["rId"]);

                if (roles == 2)
                {
                    con.Open();
                    string query = "select * from roles where Pid = "+Convert.ToInt32(Session["uuid"])+"";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();


                    if (dt.Rows.Count > 0)
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {




                            data = data + "<option value=" + dt.Rows[i]["rid"].ToString() + " >" + dt.Rows[i]["Role"].ToString() + "</option>";



                        }




                    }
                }
                else
                {

                    con.Open();
                    string query = "select * from roles where Pid = " + Convert.ToInt32(Session["uuid"]) + "";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();


                    if (dt.Rows.Count > 0)
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {




                            data = data + "<option value=" + dt.Rows[i]["rid"].ToString() + " >" + dt.Rows[i]["Role"].ToString() + "</option>";



                        }




                    }




                }
               
              

           



            }
           
            return data;
        }




        public String BindCompanyDDL()
        {

            con.Open();
            string query = "select compId , companyName  from companydetails";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select --</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["compId"].ToString() + " >" + dt.Rows[i]["companyName"].ToString() + "</option>";



                }




            }

            return data;

        }



        public string checktype()
        {
        
            string buttonname = "";
        
            if (Convert.ToInt32(Session["rId"]) == 1)
            {
            
             
                 

                  



             
                
              
                    buttonname = "Add Distributor";
                    ViewBag.type = buttonname;
                




           
            }

          
            //bindbutton
                

            return buttonname;
        }













    }
}