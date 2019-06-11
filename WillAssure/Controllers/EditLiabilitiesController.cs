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
using System.Collections;

namespace WillAssure.Controllers
{
    public class EditLiabilitiesController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: EditLiabilities
        public ActionResult EditLiabilitiesIndex()
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


            return View("~/Views/EditLiabilities/EditLiabilitiesPageContent.cshtml");
        }





        public string BindLiabilitiesFormData()
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
            // check roles
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








            }

            con.Close();





            //end



            con.Open();
            string query = "select * from Liabilities ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[16].Action;

            }



            if (dt.Rows.Count > 0)
            {

                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["lId"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Amount"].ToString() + "</td>"
                      
                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["address"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["city"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["state"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["pin"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Details"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt.Rows[i]["lId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";
                    }
                }


                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["lId"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["Amount"].ToString() + "</td>"
                      
                         + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["address"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["city"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["state"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["pin"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["Details"].ToString() + "</td>"
                         + "<td><button type='button'   id=" + dt.Rows[i]["lId"].ToString() + "    class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }
                }



                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["lId"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Amount"].ToString() + "</td>"
                       
                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["address"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["city"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["state"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["pin"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Details"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt.Rows[i]["lId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id=" + dt.Rows[i]["lId"].ToString() + "     class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }

                }



                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["lId"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["Amount"].ToString() + "</td>"
                   
                      + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["address"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["city"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["state"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["pin"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["Details"].ToString() + "</td>";

                    }



                }





            }

            return data;
        }



        public string DeleteLiabilitiesRecords(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Roles", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@roleid", index);
            cmd.Parameters.AddWithValue("@Role", "");
            cmd.Parameters.AddWithValue("@pid", "");
            cmd.ExecuteNonQuery();
            con.Close();


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

            // check roles
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








            }

            con.Close();





            //end



            con.Open();
            string query = "select * from Liabilities ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[16].Action;

            }



            if (dt.Rows.Count > 0)
            {

                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["lId"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Amount"].ToString() + "</td>"
                       
                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["address"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["city"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["state"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["pin"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Details"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt.Rows[i]["lId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";
                    }
                }


                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["lId"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["Amount"].ToString() + "</td>"
                 
                         + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["address"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["city"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["state"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["pin"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["Details"].ToString() + "</td>"
                         + "<td><button type='button'   id=" + dt.Rows[i]["lId"].ToString() + "    class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }
                }



                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["lId"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Amount"].ToString() + "</td>"
                      
                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["address"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["city"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["state"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["pin"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Details"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt.Rows[i]["lId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id=" + dt.Rows[i]["lId"].ToString() + "     class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }

                }



                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["lId"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["Amount"].ToString() + "</td>"
                   
                      + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["address"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["city"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["state"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["pin"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                      + "<td>" + dt.Rows[i]["Details"].ToString() + "</td>";

                    }



                }





            }

            return data;
        }





        public int UpdateLiabilities()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }




    }
}