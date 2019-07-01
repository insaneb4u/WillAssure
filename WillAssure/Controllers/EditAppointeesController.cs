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

namespace WillAssure.Controllers
{
    public class EditAppointeesController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: EditAppointees

        public ActionResult EditAppointeesIndex(string Type)
        {
            // check type 

            ViewBag.Typ = Type;

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


            ViewBag.documentlink = "true";
            ViewBag.collapse = "true";

            if (Session["Type"] != null)
            {
                if (Session["Type"].ToString() != "DistributorAdmin")
                {
                    if (Session["doctype"] != null)
                    {
                        if (Session["doctype"].ToString() == "Will")
                        {
                            ViewBag.view = "Will";
                        }


                        if (Session["doctype"].ToString() == "POA" || Session["doctype"].ToString() == "GiftDeeds")
                        {
                            ViewBag.view = "POA";
                            ViewBag.view = "GiftDeeds";
                        }
                    }

                }
            }
            else
            {

                RedirectToAction("LoginPageIndex", "LoginPage");
            }


            return View("~/Views/EditAppointees/EditAppointeesPageContent.cshtml");
        }


        public string BindAppointeesFormData(int value)
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
                testString = Lmlist[26].Action;

            }



            con.Open();
            string query = "select a.apId , a.documentId , a.Type , a.subType , a.Name , a.middleName  , a.Surname , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.DOB , a.Gender , a.Occupation , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.dateCreated, a.tid  from Appointees a inner join  TestatorDetails b on a.tid=b.tid where a.tid =" + value + "  and a.Type='" + ViewBag.Typ + "'";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                      + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                  + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>";



                    }
                }



               
            }

            return data;
        }


        public string LoadData()
        {
            string data = "";
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
                testString = Lmlist[26].Action;

            }

            con.Open();
            string checkuid = "select tId from TestatorDetails  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter checkda = new SqlDataAdapter(checkuid, con);
            DataTable checkdt = new DataTable();
            checkda.Fill(checkdt);
            int chktid = 0;
            if (checkdt.Rows.Count > 0)
            {
                chktid = Convert.ToInt32(checkdt.Rows[0]["tId"]);
            }
            con.Close();

            if (Convert.ToInt32(Session["uuid"]) != 1)
            {
                con.Open();
                string query = "select a.apId , a.documentId , a.Type , a.subType , a.Name , a.middleName  , a.Surname , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.DOB , a.Gender , a.Occupation , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.dateCreated, a.tid  from Appointees a inner join  TestatorDetails b on a.tid=b.tid where b.tId = " + chktid + "   ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
               

                if (dt.Rows.Count > 0)
                {
                    if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                          + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                        + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                        }
                    }

                    if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                      + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }
                    }


                    if (testString == "1,2,3" || testString == "0,2,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                        + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }

                    }


                    if (testString == "0,0,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>";



                        }
                    }




                }
                else // for distributor
                {
                    con.Open();
                    string query22 = "select a.apId , a.documentId , a.Type , a.subType , a.Name , a.middleName  , a.Surname , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.DOB , a.Gender , a.Occupation , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.dateCreated, a.tid  from Appointees a inner join  TestatorDetails b on a.tid=b.tid inner join users c on b.uId=c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and a.Type='" + ViewBag.Typ + "' ";
                    SqlDataAdapter da22 = new SqlDataAdapter(query22, con);
                    DataTable dt22 = new DataTable();
                    da22.Fill(dt22);
                    con.Close();


                    if (dt22.Rows.Count > 0)
                    {
                        if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt22.Rows[i]["apId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["documentId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Type"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["subType"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["middleName"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Surname"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                             + "<td>" + dt22.Rows[i]["DOB"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Gender"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Occupation"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["dateCreated"].ToString() + "</td>"
                                              + "<td>" + dt22.Rows[i]["tid"].ToString() + "</td>"
                                            + "<td><button type='button'   id='" + dt22.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                            }
                        }

                        if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt22.Rows[i]["apId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["documentId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Type"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["subType"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["middleName"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Surname"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                          + "<td>" + dt22.Rows[i]["DOB"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Gender"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Occupation"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["dateCreated"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["tid"].ToString() + "</td>"

                                            + "<td><button type='button'   id='" + dt22.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                            }
                        }


                        if (testString == "1,2,3" || testString == "0,2,3")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt22.Rows[i]["apId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["documentId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Type"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["subType"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["middleName"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Surname"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["DOB"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Gender"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Occupation"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["dateCreated"].ToString() + "</td>"
                                             + "<td>" + dt22.Rows[i]["tid"].ToString() + "</td>"
                                            + "<td><button type='button'   id='" + dt22.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt22.Rows[i]["apId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                            }

                        }


                        if (testString == "0,0,0")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt22.Rows[i]["apId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["documentId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Type"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["subType"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["middleName"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Surname"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                             + "<td>" + dt22.Rows[i]["DOB"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Gender"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Occupation"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["dateCreated"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["tid"].ToString() + "</td>";



                            }
                        }




                    }


                }
              
            }
            else
            {
                con.Open();
                string query = "select a.apId , a.documentId , a.Type , a.subType , a.Name , a.middleName  , a.Surname , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.DOB , a.Gender , a.Occupation , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.dateCreated, a.tid  from Appointees a inner join  TestatorDetails b on a.tid=b.tid and a.Type='" + ViewBag.Typ + "'  ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
             

                if (dt.Rows.Count > 0)
                {
                    if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                          + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                        + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                        }
                    }

                    if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                      + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }
                    }


                    if (testString == "1,2,3" || testString == "0,2,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                        + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }

                    }


                    if (testString == "0,0,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>";



                        }
                    }




                }

              
            }
            return data;

        }



        public string DeleteAppointeesRecords(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDAppointees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@apId",index);
            cmd.Parameters.AddWithValue("@documentId", "");
            cmd.Parameters.AddWithValue("@Type", "");
            cmd.Parameters.AddWithValue("@subType", "");
            cmd.Parameters.AddWithValue("@Name", "");
            cmd.Parameters.AddWithValue("@middleName", "");
            cmd.Parameters.AddWithValue("@Surname", "");
            cmd.Parameters.AddWithValue("@Identity_proof", "");
            cmd.Parameters.AddWithValue("@Identity_proof_value", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_proof", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", "");
            cmd.Parameters.AddWithValue("@DOB", "");
            cmd.Parameters.AddWithValue("@Gender", "");
            cmd.Parameters.AddWithValue("@Occupation", "");
            cmd.Parameters.AddWithValue("@Relationship", "");
            cmd.Parameters.AddWithValue("@Address1", "");
            cmd.Parameters.AddWithValue("@Address2", "");
            cmd.Parameters.AddWithValue("@Address3", "");
            cmd.Parameters.AddWithValue("@City", "");
            cmd.Parameters.AddWithValue("@State", "");
            cmd.Parameters.AddWithValue("@Pin", "");
            cmd.Parameters.AddWithValue("@tid", "");
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
                testString = Lmlist[26].Action;

            }



            con.Open();
            string query = "select a.apId , a.documentId , a.Type , a.subType , a.Name , a.middleName  , a.Surname , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.DOB , a.Gender , a.Occupation , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.dateCreated , a.tid  from Appointees a inner join  TestatorDetails b on a.tid=b.tid inner join users c on b.uId=c.uId where c.Linked_user =" + Convert.ToInt32(Session["uuid"]) + "  and a.Type='"+ ViewBag.Typ + "'";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification '>Delete</button></td>    </tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>";


                    }
                }




            }

            return data;
        }





        public int UpdateAppointees()
        {
            int index = Convert.ToInt32(Request["send"]);


            con.Open();
            string query = "select id from alternate_Appointees where apId = " + index + " ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["upappointeesid"] = Convert.ToInt32(dt.Rows[0]["id"]);
            }
            con.Close();



            return index;
        }




        public string BindTestatorDDL()
        {

            if (Convert.ToInt32(Session["uuid"]) != 1)
            {
                string ck = "select type from users where uId =" + Convert.ToInt32(Session["uuid"]) + "";
                SqlDataAdapter cda = new SqlDataAdapter(ck, con);
                DataTable cdt = new DataTable();
                cda.Fill(cdt);
                string type = "";
                if (cdt.Rows.Count > 0)
                {
                    type = cdt.Rows[0]["type"].ToString();

                }

                if (type != "Testator")
                {
                    con.Open();
                    string query = "select * from TestatorDetails a   inner join users b on a.uId = b.uId  where b.Linked_user = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    string data = "<option value='' >--Select--</option>";




                    if (dt.Rows.Count > 0)
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {




                            data = data + "<option value=" + dt.Rows[i]["tId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";



                        }




                    }

                    return data;
                }
                else
                {
                    con.Open();
                    string query = "select * from TestatorDetails a   inner join users b on a.uId = b.uId  where b.uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    string data = "";




                    if (dt.Rows.Count > 0)
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {




                            data = data + "<option value=" + dt.Rows[i]["tId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";



                        }




                    }

                    return data;


                }



            }
            else
            {
                con.Open();
                string query = "select * from TestatorDetails";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                string data = "<option value='' >--Select--</option>";




                if (dt.Rows.Count > 0)
                {


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {




                        data = data + "<option value=" + dt.Rows[i]["tId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";



                    }




                }

                return data;

            }


        }




    }
}