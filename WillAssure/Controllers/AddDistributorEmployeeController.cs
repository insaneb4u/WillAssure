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
    public class AddDistributorEmployeeController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddDistributorEmployee
        public ActionResult AddDistributorEmployeeIndex()
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


            return View("~/Views/AddDistributorEmployee/AddDistributorPageContent.cshtml");
        }



        public ActionResult GetUserFormData(UserFormModel UFM)
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
            string q = "select count(*) from users where userID = '" + UFM.UserId + "'";
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


                string dateString = UFM.Dob;
                DateTime dd = Convert.ToDateTime(dateString,
                    System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
              

                cmd.Parameters.AddWithValue("@Dob", dd);
                cmd.Parameters.AddWithValue("@Mobile", UFM.Mobile);
                cmd.Parameters.AddWithValue("@Email", UFM.Email);
                if (UFM.Address1 != null )
                {
                    cmd.Parameters.AddWithValue("@Address1", UFM.Address1);
                }
                else
                {
                    UFM.Address1 = "None";
                    cmd.Parameters.AddWithValue("@Address1", UFM.Address1);
                }
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
                    UFM.Address2 = "None";
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
                //if (Convert.ToInt32(Session["rId"]) == 1 || Convert.ToInt32(Session["rId"]) == 2)
                //{
                //    UFM.rid = 2;
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








                string query = "SELEct * from users where compId = '" + UFM.CompId + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


              

                con.Close();

                con.Open();
                string query2 = "select top 1 * from users order by uId desc";
                SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                int distempid = 0;
                if (dt2.Rows.Count > 0)
                {

                 
                    distempid = Convert.ToInt32(dt2.Rows[0]["uId"]);

                }
                con.Close();



                con.Open();
                string query3 = "update  users set Type='DistributorEmployee' where uId = "+ distempid + "  ";
                SqlCommand cm = new SqlCommand(query3,con);
                cm.ExecuteNonQuery();
                con.Close();






                //generate Mail
                string mailto = "";
                string userid = "";

                mailto = UFM.Email;
                userid = UFM.UserId;
                string subject = "Will Assure Login Credentials";

                string text = "<font color='Green' style='font-size=3em;'>Your UserId And Password For Logging In Is <br> UserID : " + userid + " <br> Password : " + UFM.UserPassword + "</font>";
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






                //Linked Users Query

                con.Open();

                string LinkedQuery = "update users set Linked_user = " + Convert.ToInt32(Session["uuid"]) + " where uId = " + distempid + "  ";
                SqlCommand LinkedCommand = new SqlCommand(LinkedQuery, con);
                LinkedCommand.ExecuteNonQuery();
                con.Close();

                //end


                ModelState.Clear();



                ViewBag.Message = "Verified";

            }







            //}
            //else
            //{

            //    ViewBag.Message = "link";

            //}












            return View("~/Views/AddDistributorEmployee/AddDistributorPageContent.cshtml");
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
            int index = Convert.ToInt32(Request["send"]); 
            string data = "";


            data = "<option value=''>--Select Role--</option>";



            if (Session["rId"] != null)
            {
                int roles = 0;
                roles = Convert.ToInt32(Session["rId"]);

              
                    con.Open();
                    string query = "select * from Roles   where  Pid = "+ index + "";
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

            return data;
        }




        public String BindCompanyDDL()
        {
            
            if (Convert.ToInt32(Session["rId"]) == 1)
            {
                string data = "<option value=''>--Select --</option>";
                con.Open();
                string query = "select uId , First_Name from users where Type in ('DistributorAdmin', 'SuperAdmin')";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                

                if (dt.Rows.Count > 0)
                {


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        ViewBag.checktype = "superadmin";

             

                        data = data + "<option value=" + dt.Rows[i]["uId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";



                    }




                }

                return data;

            }
            else
            {
                string dd = "<option value=''>--Select --</option>";
                con.Open();
                string query = "select a.uId , a.First_Name  from users a inner join roles b on a.rId=b.rId where a.rId = "+Convert.ToInt32(Session["rId"])+" and a.uId = "+ Convert.ToInt32(Session["uuid"]) + " ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                if (dt.Rows.Count > 0)
                {


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {







                        dd = dd + "<option value=" + dt.Rows[i]["uId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";
                    }




                }
                return dd;

            }

           

        }



      



        public string BindDistributorDDL()
        {
            con.Open();
            string query = "select uId , First_Name from users";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select --</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["uId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";



                }




            }

            return data;
        }











    }
}