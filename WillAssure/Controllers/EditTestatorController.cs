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
using System.Collections;
using System.Globalization;
using System.Net.Mail;
using System.Net;

namespace WillAssure.Controllers
{
    public class EditTestatorController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: EditTestator
        public ActionResult EditTestatorIndex(string doctype)
        {


            TempData["selected"] = doctype;
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


            if (doctype != "")
            {
                Session["doctype"] = doctype;
            }



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
            ViewBag.documentlink = "true";
            ViewBag.collapse = "true";

            //if (Session["doctype"].ToString() == "Will")
            //{
            //    ViewBag.view = "Will";
            //}

            //if (Session["doctype"].ToString() == "POA")
            //{
            //    ViewBag.view = "POA";
            //}


            //if (Session["doctype"].ToString() == "GiftDeeds")
            //{
            //    ViewBag.view = "GiftDeeds";
            //}


         


            return View("~/Views/EditTestator/EditTestatorPageContent.cshtml");
        }


        public string BindTestatorFormData()
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


            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[19].Action;

            }


            if (Convert.ToInt32(Session["uuid"]) != 1)
            {
                con.Open();
                string query = "select * from TestatorDetails a   inner join users b on a.uId = b.uId  where a.uId = " + Convert.ToInt32(Session["uuid"])+"  ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                string data = "";

                if (dt.Rows.Count > 0)
                {
                    if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary Editbtn'>Edit</button></td></tr>";   //<button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='getclickedid(this.id)'   class='btn btn-success'  data-toggle='modal' data-target='.primarymodal'>Create Document</button>

                        }
                    }

                    if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                        }
                    }


                    if (testString == "1,2,3" || testString == "0,2,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary Editbtn'>Edit</button><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                        }

                    }


                    if (testString == "0,0,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>";



                        }
                    }







                }

                return data;

            }
            else
            {
                con.Open();
                string query = "select * from TestatorDetails";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                string data = "";

                if (dt.Rows.Count > 0)
                {
                    if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary Editbtn'>Edit</button></td></tr>";

                        }
                    }

                    if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                        }
                    }


                    if (testString == "1,2,3" || testString == "0,2,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary '>Edit</button><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                        }

                    }


                    if (testString == "0,0,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>";



                        }
                    }







                }

                return data;
            }

            
        }

        public string DeleteTestatorFormRecords(TestatorFormModel TFM)
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
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDTestatorDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@tId", index);
            cmd.Parameters.AddWithValue("@First_Name", "");
            cmd.Parameters.AddWithValue("@Last_Name", "");
            cmd.Parameters.AddWithValue("@Middle_Name", "");
            cmd.Parameters.AddWithValue("@DOB", "");
            cmd.Parameters.AddWithValue("@Occupation", "");
            cmd.Parameters.AddWithValue("@Mobile", "");
            cmd.Parameters.AddWithValue("@Email", "");
            cmd.Parameters.AddWithValue("@maritalStatus", "");
            cmd.Parameters.AddWithValue("@Relationship", "");
            cmd.Parameters.AddWithValue("@Religion", "");
            cmd.Parameters.AddWithValue("@Identity_Proof", "");
            cmd.Parameters.AddWithValue("@Identity_proof_Value", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_proof_Value", "");
            cmd.Parameters.AddWithValue("@Gender", "");
            cmd.Parameters.AddWithValue("@Address1", "");
            cmd.Parameters.AddWithValue("@Address2", "");
            cmd.Parameters.AddWithValue("@Address3", "");
            cmd.Parameters.AddWithValue("@City", "");
            cmd.Parameters.AddWithValue("@State", "");
            cmd.Parameters.AddWithValue("@Country", "");
            cmd.Parameters.AddWithValue("@Pin", "");
            cmd.Parameters.AddWithValue("@active", "");
            cmd.Parameters.AddWithValue("@Contact_Verification", "");
            cmd.Parameters.AddWithValue("@Email_Verification", "");
            cmd.Parameters.AddWithValue("@Mobile_Verification_Status", "");
            cmd.Parameters.AddWithValue("@Email_OTP", "");
            cmd.Parameters.AddWithValue("@Mobile_OTP", "");
            cmd.Parameters.AddWithValue("@uid", "");
            cmd.ExecuteNonQuery();
            con.Close();


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


            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[19].Action;

            }


            con.Open();
            string query = "select * from TestatorDetails";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {
                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                              + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                  + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>";



                    }
                }







            }

            return data;
        }





        public string UpdateTestatorForm()
        {

            string data = Request["send"].ToString();



            string type = TempData["selected"].ToString();
            //if (Session["doctype"].ToString() == "Will")
            //{

            //    int id = Convert.ToInt32(Request["send"]);
            //    string type = "Will";
            //    data = type + "~" + id;

            //}

            //if (Session["doctype"].ToString() == "POA" || Session["doctype"].ToString() == "GiftDeeds")
            //{

            //    int id = Convert.ToInt32(Request["send"]);
            //    string type = "Will";
            //    data = type + "~" + id;
            //}


            //if (Session["doctype"].ToString() == "Codocil")
            //{
            //    data = "Codocil";
            //}

            //if (Session["doctype"].ToString() == "LivingWill")
            //{
            //    data = "LivingWill";
            //}

            return data+"~"+type;
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





            // check payment done or not
            con.Open();
            string payquery = "select PaymentStatus from TestatorDetails  where tId ="+TFM.tId+" ";
            SqlDataAdapter payda = new SqlDataAdapter(payquery, con);
            DataTable paydt = new DataTable();
            payda.Fill(paydt);
            con.Close();


            if (paydt.Rows.Count > 0)
            {
                if (Convert.ToInt32(paydt.Rows[0]["PaymentStatus"]) != 1)
                {

                





                    int testatorid = TFM.tId;
                    int templateid = 0;
                    string testatortype = "";
                    string Email = "";


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





                  




                    // get identity dist id from testator

                    con.Open();
                    string gedistid = "select uId from TestatorDetails where tId=" + testatorid + " ";
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



                    // get distid


                    con.Open();
                    string gedistid22 = "select Linked_user from users where  uId = "+ distidd + "";
                    SqlDataAdapter distid2 = new SqlDataAdapter(gedistid22,con);
                    DataTable distdt2 = new DataTable();
                    distid2.Fill(distdt2);
                    int did = 0;
                    if (distdt2.Rows.Count > 0)
                    {
                        did = Convert.ToInt32(distdt2.Rows[0]["Linked_user"]);
                    }
                    con.Close();



                    //end






                    // get coupon id
                    con.Open();
                    string query5 = "select a.couponId  from couponAllotment a inner join users b on a.uId=b.uId where b.uId = " + did + "";
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
                    string q1 = "insert into documentMaster (tId,templateId,IsUpdatetable,uId,pId,created_by,testator_type,couponId,adminVerification) values (" + testatorid + " , " + templateid + " ,  'Yes' ,   " + did + " , 1 , '" + TFM.Document_Created_By + "' , '" + testatortype + "' , " + couponsid + "  , 2)";
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
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();

                    }
                    if (TFM.documenttype == "Codocil")
                    {
                        typeid = "2";



                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();


                    }
                    if (TFM.documenttype == "POA")
                    {
                        typeid = "3";

                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "Will")
                    {
                        typeid = "1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "WillCodocil")
                    {
                        typeid = "1,2";

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "WillPOA")
                    {
                        typeid = "1,3";

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "CodocilPOA")
                    {
                        typeid = "2,3";

                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "CodocilWill")
                    {
                        typeid = "2,1";

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "POAWill")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "Giftdeeds")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '0' , Giftdeeds='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "GiftdeedsCodocil")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "GiftdeedsWill")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "GiftdeedsPOA")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }


                    if (TFM.documenttype == "WillGiftdeeds")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' ,  Giftdeeds='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "POAGiftdeeds")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "CodocilGiftdeeds")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "CodocilGiftdeedsWill")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "CodocilGiftdeedsWillPOA")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "CodocilWillGiftdeedsPOA")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "WillCodocilPOAGiftdeeds")
                    {
                        typeid = "3,1";
                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "WillCodocilPOAGiftdeedsLivingWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "LivingWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='0' , LivingWill='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "LivingWillWillCodocilPOAGiftdeeds")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "CodocilGiftdeedsLivingWillWillPOA")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "LivingWillWillPOA")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "POALivingWillWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }

                    if (TFM.documenttype == "LivingWillPOAGiftdeeds")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "POAGiftdeeds")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "POAGiftdeedsWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "POAWillCodocil")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='0', LivingWill='0' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "CodocilLivingWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "CodocilGiftdeedsLivingWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "POALivingWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + distidd + " ";
                        SqlCommand cc1 = new SqlCommand(qq1, con);
                        cc1.ExecuteNonQuery();
                        con.Close();
                    }
                    if (TFM.documenttype == "GiftDeedsLivingWill")
                    {

                        con.Open();
                        string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + distidd + " ";
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

                    //1st condition
                    if (TFM.Amt_Paid_By == "Distributor" && TFM.Document_Created_By == "Distributor")
                    {
                        TFM.Authentication_Required = 0;
                        TFM.Link_Required = 0;
                        TFM.Login_Required = 0;

                        con.Open();
                        string query1 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , " + did + " , '" + TFM.Amt_Paid_By_txt + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
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
                        TFM.Authentication_Required = 1;
                        TFM.Link_Required = 1;
                        TFM.Login_Required = 1;

                        con.Open();
                        string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By + "' , " + did + " , '" + TFM.Amt_Paid_By + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
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
                        string mailto = TFM.Email;
                        string Userid = TFM.Identity_proof_Value;
                        mailto = Email;

                        string subject = "Will Assure Link For Payment";
                        string body = "<font color='Green' style='font-size=3em;'> Click the Link To Make A Payment For The Document :</font> <a href='https://razorpay.com/'>Payment</a> ";



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

                        // payment status for testator details table
                        con.Open();
                        string paymentquery2 = "update TestatorDetails set PaymentStatus = 1 where tId = " + testatorid + " ";
                        SqlCommand paymentcmd2 = new SqlCommand(paymentquery2, con);
                        paymentcmd2.ExecuteNonQuery();
                        con.Close();
                        //end


                        // payment info
                        con.Open();
                        string paymentquery = "insert into PaymentInfo (uId,tId,transactionStatus) values (" + did + " , " + testatorid + " , 1)  ";
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
                        TFM.Authentication_Required = 1;
                        TFM.Link_Required = 1;
                        TFM.Login_Required = 1;

                        con.Open();
                        string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By + "' , " + did + " , '" + TFM.Amt_Paid_By + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                        SqlCommand cmd2 = new SqlCommand(query3, con);
                        cmd2.ExecuteNonQuery();
                        con.Close();









                        // new mail code
                        string mailto = TFM.Email;
                        string Userid = TFM.Identity_proof_Value;
                        mailto = Email;
                        string subject = "Will Assure Link For Payment";
                        string body = "<font color='Green' style='font-size=3em;'> Click the Link To Make A Payment For The Document :</font> <a href='https://razorpay.com/'>Payment</a> ";



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

                        // payment status for testator details table
                        con.Open();
                        string paymentquery2 = "update TestatorDetails set PaymentStatus = 1 where tId = " + testatorid + " ";
                        SqlCommand paymentcmd2 = new SqlCommand(paymentquery2, con);
                        paymentcmd2.ExecuteNonQuery();
                        con.Close();
                        //end

                        // payment info
                        con.Open();
                        string paymentquery = "insert into PaymentInfo (uId,tId,transactionStatus) values (" + did + " , " + testatorid + " , 1)  ";
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
                        TFM.Authentication_Required = 1;
                        TFM.Link_Required = 1;
                        TFM.Login_Required = 1;

                        con.Open();
                        string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By + "' , " + did + " , '" + TFM.Amt_Paid_By + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                        SqlCommand cmd2 = new SqlCommand(query3, con);
                        cmd2.ExecuteNonQuery();
                        con.Close();





                        // new mail code
                        string mailto = TFM.Email;
                        string Userid = TFM.Identity_proof_Value;
                        mailto = Email;
                        string subject = "Will Assure Link For Payment";
                        string body = "<font color='Green' style='font-size=3em;'> Click the Link To Make A Payment For The Document :</font> <a href='https://razorpay.com/'>Payment</a> ";



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


                        // payment status for testator details table
                        con.Open();
                        string paymentquery2 = "update TestatorDetails set PaymentStatus = 1 where tId = " + testatorid + " ";
                        SqlCommand paymentcmd2 = new SqlCommand(paymentquery2, con);
                        paymentcmd2.ExecuteNonQuery();
                        con.Close();
                        //end






                        // payment info
                        con.Open();
                        string paymentquery = "insert into PaymentInfo (uId,tId,transactionStatus) values (" + did + " , " + testatorid + " , 1)  ";
                        SqlCommand paymentcmd = new SqlCommand(paymentquery, con);
                        paymentcmd.ExecuteNonQuery();
                        con.Close();
                        //end
                        ViewBag.PaymentLink = "true";
                    }
                    //end







                    ModelState.Clear();


                }
            }

            //end





            return View("~/Views/EditTestator/EditTestatorPageContent.cshtml");

        }



        public string txtchangecouponnumber()
        {
            string sts = "";
            string response = Request["send"];
            string tid = response.Split('~')[0];
            string entertxt = response.Split('~')[1];

            // coupon status

            con.Open();
                string checkcoupon = "select * from couponAllotment where Coupon_Number = " + entertxt + " and  Status = 'Active' ";
                SqlDataAdapter da = new SqlDataAdapter(checkcoupon, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                
                string getdatquery = "select validFrm , validTo from couponAllotment where Coupon_Number = " + entertxt + " ";
                SqlDataAdapter getdatda = new SqlDataAdapter(getdatquery,con);
                DataTable getdata = new DataTable();
                getdatda.Fill(getdata);
               

              

                if (getdata.Rows.Count > 0)
                {
                 
                    string getdatquery2 = "select Coupon_Number from couponAllotment where validFrm <= '"+ getdata.Rows[0]["validFrm"].ToString() +"'  and validTo >= '" + getdata.Rows[0]["validTo"].ToString() + "' ";
                    SqlDataAdapter getdatda2 = new SqlDataAdapter(getdatquery2,con);
                    DataTable getdata2 = new DataTable();
                    getdatda2.Fill(getdata2);
                    if (getdata2.Rows.Count > 0)
                    {
                        string upcoupon = "update couponAllotment set Status = 'Inactive' ,    Tid=" + tid + " ";
                        SqlCommand cmd2 = new SqlCommand(upcoupon, con);
                        cmd2.ExecuteNonQuery();




                        string upcoupon2 = "update discountCoupons set status = 'Inactive' ,    Coupon_Number=" + entertxt + " ";
                        SqlCommand cmd22 = new SqlCommand(upcoupon2, con);
                        cmd22.ExecuteNonQuery();


                        sts = "success";

                    }
                    else
                    {
                        sts = "Expire";
                    }
                 


                }



                   
                }
                else
                {
                    ViewBag.Message = "checkCoupon";

                sts = "failed";
            }
                con.Close();
            


            //end

         




            return sts;
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
            string query = "select * from users where Type = 'DistributorAdmin'";
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




        public string FilterTestatordata()
        {
            // check type 
            string typ5 = "";
            con.Open();
            string qq15 = "select * from users where Type = 'DistributorAdmin' ";
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


            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[19].Action;

            }

            string response = Request["send"].ToString();
            if (response != "")
            {
                if (Convert.ToInt32(Session["uuid"]) != 1)
                {
                    con.Open();
                    string query = "select * from TestatorDetails a   inner join users b on a.uId = b.uId  where b.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "  ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    string data = "";

                    if (dt.Rows.Count > 0)
                    {
                        if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                            + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary Editbtn'>Edit</button></td></tr>";   //<button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='getclickedid(this.id)'   class='btn btn-success'  data-toggle='modal' data-target='.primarymodal'>Create Document</button>

                            }
                        }

                        if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                             + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                            + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                            }
                        }


                        if (testString == "1,2,3" || testString == "0,2,3")
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                            + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary Editbtn'>Edit</button><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                            }

                        }


                        if (testString == "0,0,0")
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["active"].ToString() + "</td>";



                            }
                        }







                    }

                    return data;

                }
                else
                {

                    // linked user

                    con.Open();
                    string querylk = "select uId from users where Linked_user = " + response + " ";
                    SqlDataAdapter dalk = new SqlDataAdapter(querylk, con);
                    DataTable dtlk = new DataTable();
                    dalk.Fill(dtlk);
                    int lnkid = 0;
                    if (dtlk.Rows.Count > 0)
                    {
                        lnkid = Convert.ToInt32(dtlk.Rows[0]["uId"]);
                    }
                    con.Close();
                    //end



                    con.Open();
                    string query = "select * from TestatorDetails where uId = " + lnkid + " ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    con.Close();
                    string data = "";

                    if (dt.Rows.Count > 0)
                    {
                        if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                            + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary Editbtn'>Edit</button></td></tr>";

                            }
                        }

                        if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                             + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                            + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                            }
                        }


                        if (testString == "1,2,3" || testString == "0,2,3")
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"

                                            + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary '>Edit</button><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                            }

                        }


                        if (testString == "0,0,0")
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt.Rows[i]["active"].ToString() + "</td>";



                            }
                        }







                    }

                    return data;
                }
            }
            return "";
        }


       


    }
}