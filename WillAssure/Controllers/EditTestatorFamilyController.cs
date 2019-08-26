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

namespace WillAssure.Controllers
{
    public class EditTestatorFamilyController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: EditTestatorFamily
        public ActionResult EditTestatorFamilyIndex()
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
                

        

            ViewBag.documentlink = "true";
            ViewBag.collapse = "true";




            /////////////////////////////////////////////////////////////  Bind Testator Family data ///////////////////////////////////////////


            // check type 
            string typ56 = "";
            con.Open();
            string qq156 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa56 = new SqlDataAdapter(qq156, con);
            DataTable dtt56 = new DataTable();
            daa56.Fill(dtt56);
            con.Close();

            if (dtt56.Rows.Count > 0)
            {
                typ56 = dtt56.Rows[0]["Type"].ToString();
            }



            //end



            if (typ56 == "Testator")
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
                testString = Lmlist[20].Action;

            }


            con.Open();

            string checkuid = "";

            if (Session["WillType"].ToString() == "Quick")
            {
                checkuid = "select tId from TestatorDetails  where tId = " + Convert.ToInt32(Session["distid"]) + " and WillType='Quick' ";
            }
            if (Session["WillType"].ToString() == "Detailed")
            {
                checkuid = "select tId from TestatorDetails  where tId = " + Convert.ToInt32(Session["distid"]) + " and WillType='Detailed' ";
            }
            




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
                string query = "select a.fId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Marital_Status , a.Religion , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.tId , a.active , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Is_Informed_Person from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where b.tId = " + chktid + " ";
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
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                        }
                    }

                    if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }
                    }


                    if (testString == "1,2,3" || testString == "0,2,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }

                    }


                    if (testString == "0,0,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>";



                        }
                    }



                }
                else // for distributor
                {
                    con.Open();
                    string query22 = "select * from testatorFamily a inner join TestatorDetails b on a.tId=b.tId inner join users c on b.uId=c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + " ";
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
                                data = data + "<tr class='nr'><td>" + dt22.Rows[i]["fId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["First_Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Last_Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Middle_Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["DOB"].ToString() + "</td>"

                                            + "<td>" + dt22.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["tId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["active"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                            + "<td><button type='button'   id='" + dt22.Rows[i]["fId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                            }
                        }

                        if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt22.Rows[i]["fId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["First_Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Last_Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Middle_Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["DOB"].ToString() + "</td>"

                                            + "<td>" + dt22.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["tId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["active"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                            + "<td><button type='button'   id='" + dt22.Rows[i]["fId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                            }
                        }


                        if (testString == "1,2,3" || testString == "0,2,3")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt22.Rows[i]["fId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["First_Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Last_Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Middle_Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["DOB"].ToString() + "</td>"

                                            + "<td>" + dt22.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["tId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["active"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                            + "<td><button type='button'   id='" + dt22.Rows[i]["fId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt22.Rows[i]["fId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                            }

                        }


                        if (testString == "0,0,0")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data = data + "<tr class='nr'><td>" + dt22.Rows[i]["fId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["First_Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Last_Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Middle_Name"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["DOB"].ToString() + "</td>"

                                            + "<td>" + dt22.Rows[i]["Relationship"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address1"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address2"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Address3"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["City"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["State"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Pin"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["tId"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["active"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                            + "<td>" + dt22.Rows[i]["Is_Informed_Person"].ToString() + "</td>";



                            }
                        }



                    }
                }



            }
            else
            {

                con.Open();
                string query = "select a.fId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Marital_Status , a.Religion , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.tId , a.active , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Is_Informed_Person from testatorFamily a inner join TestatorDetails b on a.tId=b.tId  ";
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
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                        }
                    }

                    if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }
                    }


                    if (testString == "1,2,3" || testString == "0,2,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }

                    }


                    if (testString == "0,0,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>";



                        }
                    }



                }


            }





            ViewBag.Tabledata = data;




            ///////////////////////////////////////////////////////////////     END   //////////////////////////////////////////////////////////////








            ////////////////////////////////////////////// appointees data ////////////////////////////////////////////////


           
          





            //end
            string testString1 = "";
            string data1 = "";
            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString1 = Lmlist[26].Action;

            }

            con.Open();
            string checkuid1 = "select tId from TestatorDetails  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter checkda1 = new SqlDataAdapter(checkuid1, con);
            DataTable checkdt1 = new DataTable();
            checkda1.Fill(checkdt1);
            int chktid1 = 0;
            if (checkdt1.Rows.Count > 0)
            {
                chktid1 = Convert.ToInt32(checkdt1.Rows[0]["tId"]);
            }
            con.Close();

            if (Convert.ToInt32(Session["uuid"]) != 1)
            {
                con.Open();
                string query1 = "select a.apId , a.documentId , a.Type , a.subType , a.Name , a.middleName  , a.Surname , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.DOB , a.Gender , a.Occupation , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.dateCreated, a.tid  from Appointees a inner join  TestatorDetails b on a.tid=b.tid where b.tId = "+Convert.ToInt32(Session["distid"])+"  and  a.Type='Guardian'";
                SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                con.Close();


                if (dt1.Rows.Count > 0)
                {
                    if (testString1 == "1,2,0" || testString1 == "0,2,0" || testString1 == "0,2,3" || testString1 == "0,2,3" || testString1 == "0,2,0")
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            data1 = data1 + "<tr class='nr'><td>" + dt1.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                         + "<td>" + dt1.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["dateCreated"].ToString() + "</td>"
                                          + "<td>" + dt1.Rows[i]["tid"].ToString() + "</td>"
                                        + "<td><button type='button'   id='" + dt1.Rows[i]["apId"].ToString() + "' onClick='Edit1(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                        }
                    }

                    if (testString1 == "1,0,3" || testString1 == "0,0,3" || testString1 == "0,2,3" || testString1 == "1,0,3" || testString1 == "0,0,3")
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            data1 = data1 + "<tr class='nr'><td>" + dt1.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                      + "<td>" + dt1.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["tid"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt1.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }
                    }


                    if (testString1 == "1,2,3" || testString1 == "0,2,3")
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            data1 = data1 + "<tr class='nr'><td>" + dt1.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["dateCreated"].ToString() + "</td>"
                                         + "<td>" + dt1.Rows[i]["tid"].ToString() + "</td>"
                                        + "<td><button type='button'   id='" + dt1.Rows[i]["apId"].ToString() + "' onClick='Edit1(this.id)'   class='btn btn-primary'>Edit1</button><button type='button'   id='" + dt1.Rows[i]["apId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }

                    }


                    if (testString1 == "0,0,0")
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            data1 = data1 + "<tr class='nr'><td>" + dt1.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                         + "<td>" + dt1.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["tid"].ToString() + "</td>";



                        }
                    }




                }
                else // for distributor
                {
                    con.Open();
                    string query22 = "select a.apId , a.documentId , a.Type , a.subType , a.Name , a.middleName  , a.Surname , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.DOB , a.Gender , a.Occupation , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.dateCreated, a.tid  from Appointees a inner join  TestatorDetails b on a.tid=b.tid inner join users c on b.uId=c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and a.Type='Guardian' ";
                    SqlDataAdapter da22 = new SqlDataAdapter(query22, con);
                    DataTable dt22 = new DataTable();
                    da22.Fill(dt22);
                    con.Close();


                    if (dt22.Rows.Count > 0)
                    {
                        if (testString1 == "1,2,0" || testString1 == "0,2,0" || testString1 == "0,2,3" || testString1 == "0,2,3" || testString1 == "0,2,0")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data1 = data1 + "<tr class='nr'><td>" + dt22.Rows[i]["apId"].ToString() + "</td>"
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
                                            + "<td><button type='button'   id='" + dt22.Rows[i]["apId"].ToString() + "' onClick='Edit1(this.id)'   class='btn btn-primary'>Edit1</button></td>    </tr>";

                            }
                        }

                        if (testString1 == "1,0,3" || testString1 == "0,0,3" || testString1 == "0,2,3" || testString1 == "1,0,3" || testString1 == "0,0,3")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data1 = data1 + "<tr class='nr'><td>" + dt22.Rows[i]["apId"].ToString() + "</td>"
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


                        if (testString1 == "1,2,3" || testString1 == "0,2,3")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data1 = data1 + "<tr class='nr'><td>" + dt22.Rows[i]["apId"].ToString() + "</td>"
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
                                            + "<td><button type='button'   id='" + dt22.Rows[i]["apId"].ToString() + "' onClick='Edit1(this.id)'   class='btn btn-primary'>Edit1</button><button type='button'   id='" + dt22.Rows[i]["apId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                            }

                        }


                        if (testString1 == "0,0,0")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data1 = data1 + "<tr class='nr'><td>" + dt22.Rows[i]["apId"].ToString() + "</td>"
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
                string query = "select a.apId , a.documentId , a.Type , a.subType , a.Name , a.middleName  , a.Surname , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.DOB , a.Gender , a.Occupation , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.dateCreated, a.tid  from Appointees a inner join  TestatorDetails b on a.tid=b.tid and a.Type='" + Session["typ"].ToString() + "'  ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                con.Close();


                if (dt1.Rows.Count > 0)
                {
                    if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            data1 = data1 + "<tr class='nr'><td>" + dt1.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                         + "<td>" + dt1.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["dateCreated"].ToString() + "</td>"
                                          + "<td>" + dt1.Rows[i]["tid"].ToString() + "</td>"
                                        + "<td><button type='button'   id='" + dt1.Rows[i]["apId"].ToString() + "' onClick='Edit1(this.id)'   class='btn btn-primary'>Edit1</button></td>    </tr>";

                        }
                    }

                    if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            data1 = data1 + "<tr class='nr'><td>" + dt1.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                      + "<td>" + dt1.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["tid"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt1.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }
                    }


                    if (testString == "1,2,3" || testString == "0,2,3")
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            data1 = data1 + "<tr class='nr'><td>" + dt1.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["dateCreated"].ToString() + "</td>"
                                         + "<td>" + dt1.Rows[i]["tid"].ToString() + "</td>"
                                        + "<td><button type='button'   id='" + dt1.Rows[i]["apId"].ToString() + "' onClick='Edit1(this.id)'   class='btn btn-primary'>Edit1</button><button type='button'   id='" + dt1.Rows[i]["apId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }

                    }


                    if (testString == "0,0,0")
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            data1 = data1 + "<tr class='nr'><td>" + dt1.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                         + "<td>" + dt1.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt1.Rows[i]["tid"].ToString() + "</td>";



                        }
                    }




                }


            }
            ViewBag.tabledata1 = data1;












            ////////////////////////////////////////////////end//////////////////////////////////////////////////////////////






            ////////////////////////////////////////////// appointees data ////////////////////////////////////////////////


            string data2 = "";
            // check roles
            
            con.Open();
            string q2 = "select * from Assignment_Roles where RoleId = " + Convert.ToInt32(Session["rId"]) + "";
            SqlDataAdapter da32 = new SqlDataAdapter(q2, con);
            DataTable dt32 = new DataTable();
            da32.Fill(dt32);
            if (dt32.Rows.Count > 0)
            {

                for (int i = 0; i < dt32.Rows.Count; i++)
                {
                    LoginModel lm = new LoginModel();
                    lm.PageName = dt32.Rows[i]["PageName"].ToString();
                    lm.PageStatus = dt32.Rows[i]["PageStatus"].ToString();
                    lm.Action = dt32.Rows[i]["Action"].ToString();
                    lm.Nav1 = dt32.Rows[i]["Nav1"].ToString();
                    lm.Nav2 = dt32.Rows[i]["Nav2"].ToString();

                    Lmlist.Add(lm);
                }








            }

            con.Close();





            //end
            string testString2 = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString2 = Lmlist[26].Action;

            }

            con.Open();
            string checkuid2 = "select tId from TestatorDetails  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter checkda2 = new SqlDataAdapter(checkuid2, con);
            DataTable checkdt2 = new DataTable();
            checkda2.Fill(checkdt2);
            int chktid2 = 0;
            if (checkdt2.Rows.Count > 0)
            {
                chktid2 = Convert.ToInt32(checkdt2.Rows[0]["tId"]);
            }
            con.Close();

            if (Convert.ToInt32(Session["uuid"]) != 1)
            {
                con.Open();
                string query2 = "select a.apId , a.documentId , a.Type , a.subType , a.Name , a.middleName  , a.Surname , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.DOB , a.Gender , a.Occupation , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.dateCreated, a.tid  from Appointees a inner join  TestatorDetails b on a.tid=b.tid where b.tId = " + Convert.ToInt32(Session["distid"]) + "  and  a.Type='AlternateGuardian'";
                SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                con.Close();


                if (dt2.Rows.Count > 0)
                {
                    if (testString2 == "1,2,0" || testString2 == "0,2,0" || testString2 == "0,2,3" || testString2 == "0,2,3" || testString2 == "0,2,0")
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            data2 = data2 + "<tr class='nr'><td>" + dt2.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                         + "<td>" + dt2.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["dateCreated"].ToString() + "</td>"
                                          + "<td>" + dt2.Rows[i]["tid"].ToString() + "</td>"
                                        + "<td><button type='button'   id='" + dt2.Rows[i]["apId"].ToString() + "' onClick='Edit2(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                        }
                    }

                    if (testString2 == "1,0,3" || testString2 == "0,0,3" || testString2 == "0,2,3" || testString2 == "1,0,3" || testString2 == "0,0,3")
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            data2 = data2 + "<tr class='nr'><td>" + dt2.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                      + "<td>" + dt2.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["tid"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt2.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }
                    }


                    if (testString2 == "1,2,3" || testString2 == "0,2,3")
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            data2 = data2 + "<tr class='nr'><td>" + dt2.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["dateCreated"].ToString() + "</td>"
                                         + "<td>" + dt2.Rows[i]["tid"].ToString() + "</td>"
                                        + "<td><button type='button'   id='" + dt2.Rows[i]["apId"].ToString() + "' onClick='Edit2(this.id)'   class='btn btn-primary'>Edit2</button><button type='button'   id='" + dt2.Rows[i]["apId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }

                    }


                    if (testString2 == "0,0,0")
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            data2 = data2 + "<tr class='nr'><td>" + dt2.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                         + "<td>" + dt2.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["tid"].ToString() + "</td>";



                        }
                    }




                }
                else // for distributor
                {
                    con.Open();
                    string query22 = "select a.apId , a.documentId , a.Type , a.subType , a.Name , a.middleName  , a.Surname , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.DOB , a.Gender , a.Occupation , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.dateCreated, a.tid  from Appointees a inner join  TestatorDetails b on a.tid=b.tid inner join users c on b.uId=c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and a.Type='AlternateGuardian' ";
                    SqlDataAdapter da22 = new SqlDataAdapter(query22, con);
                    DataTable dt22 = new DataTable();
                    da22.Fill(dt22);
                    con.Close();


                    if (dt22.Rows.Count > 0)
                    {
                        if (testString2 == "1,2,0" || testString2 == "0,2,0" || testString2 == "0,2,3" || testString2 == "0,2,3" || testString2 == "0,2,0")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data2 = data2 + "<tr class='nr'><td>" + dt22.Rows[i]["apId"].ToString() + "</td>"
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
                                            + "<td><button type='button'   id='" + dt22.Rows[i]["apId"].ToString() + "' onClick='Edit2(this.id)'   class='btn btn-primary'>Edit2</button></td>    </tr>";

                            }
                        }

                        if (testString2 == "1,0,3" || testString2 == "0,0,3" || testString2 == "0,2,3" || testString2 == "1,0,3" || testString2 == "0,0,3")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data2 = data2 + "<tr class='nr'><td>" + dt22.Rows[i]["apId"].ToString() + "</td>"
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


                        if (testString2 == "1,2,3" || testString2 == "0,2,3")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data2 = data2 + "<tr class='nr'><td>" + dt22.Rows[i]["apId"].ToString() + "</td>"
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
                                            + "<td><button type='button'   id='" + dt22.Rows[i]["apId"].ToString() + "' onClick='Edit2(this.id)'   class='btn btn-primary'>Edit2</button><button type='button'   id='" + dt22.Rows[i]["apId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                            }

                        }


                        if (testString2 == "0,0,0")
                        {
                            for (int i = 0; i < dt22.Rows.Count; i++)
                            {
                                data2 = data2 + "<tr class='nr'><td>" + dt22.Rows[i]["apId"].ToString() + "</td>"
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
                string query2 = "select a.apId , a.documentId , a.Type , a.subType , a.Name , a.middleName  , a.Surname , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.DOB , a.Gender , a.Occupation , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.dateCreated, a.tid  from Appointees a inner join  TestatorDetails b on a.tid=b.tid and a.Type='" + Session["typ"].ToString() + "'  ";
                SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                con.Close();


                if (dt2.Rows.Count > 0)
                {
                    if (testString2 == "1,2,0" || testString2 == "0,2,0" || testString2 == "0,2,3" || testString2 == "0,2,3" || testString2 == "0,2,0")
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            data2 = data2 + "<tr class='nr'><td>" + dt2.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                         + "<td>" + dt2.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["dateCreated"].ToString() + "</td>"
                                          + "<td>" + dt2.Rows[i]["tid"].ToString() + "</td>"
                                        + "<td><button type='button'   id='" + dt2.Rows[i]["apId"].ToString() + "' onClick='Edit2(this.id)'   class='btn btn-primary'>Edit2</button></td>    </tr>";

                        }
                    }

                    if (testString2 == "1,0,3" || testString2 == "0,0,3" || testString2 == "0,2,3" || testString2 == "1,0,3" || testString2 == "0,0,3")
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            data2 = data2 + "<tr class='nr'><td>" + dt2.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                      + "<td>" + dt2.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["tid"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt2.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }
                    }


                    if (testString2 == "1,2,3" || testString2 == "0,2,3")
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            data2 = data2 + "<tr class='nr'><td>" + dt2.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["dateCreated"].ToString() + "</td>"
                                         + "<td>" + dt2.Rows[i]["tid"].ToString() + "</td>"
                                        + "<td><button type='button'   id='" + dt2.Rows[i]["apId"].ToString() + "' onClick='Edit2(this.id)'   class='btn btn-primary'>Edit2</button><button type='button'   id='" + dt2.Rows[i]["apId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }

                    }


                    if (testString2 == "0,0,0")
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            data2 = data2 + "<tr class='nr'><td>" + dt2.Rows[i]["apId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Type"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["subType"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Name"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["middleName"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Surname"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                         + "<td>" + dt2.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Gender"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Occupation"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt2.Rows[i]["tid"].ToString() + "</td>";



                        }
                    }




                }


            }
            ViewBag.tabledata2 = data2;












            ////////////////////////////////////////////////end//////////////////////////////////////////////////////////////







            return View("/Views/EditTestatorFamily/EditTestatorFamilyPageContent.cshtml");
        }


        public ActionResult filterdata()
        {


            return View("/Views/EditTestatorFamily/EditTestatorFamilyPageContent.cshtml");
        }

        public string BindTestatorFamilyFormData(int value)
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
                testString = Lmlist[16].Action;

            }


            con.Open();
            string query = "select a.fId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Marital_Status , a.Religion , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.tId , a.active , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Is_Informed_Person from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where a.tId =  " + value + " ";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>";

                                  

                    }
                }



            }

            return data;
        }



    



        public string DeleteTestatorFamilyRecords()
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDtestatorfamily", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete"); 
            cmd.Parameters.AddWithValue("@fId", index);
            cmd.Parameters.AddWithValue("@First_Name", "");
            cmd.Parameters.AddWithValue("@Last_Name", "");
            cmd.Parameters.AddWithValue("@Middle_Name", "");
            cmd.Parameters.AddWithValue("@DOB","");
            cmd.Parameters.AddWithValue("@Marital_Status", "");
            cmd.Parameters.AddWithValue("@Religion", "");
            cmd.Parameters.AddWithValue("@Relationship", "");
            cmd.Parameters.AddWithValue("@Address1","");
            cmd.Parameters.AddWithValue("@Address2", "");
            cmd.Parameters.AddWithValue("@Address3", "");
            cmd.Parameters.AddWithValue("@City", "");
            cmd.Parameters.AddWithValue("@State", "");
            cmd.Parameters.AddWithValue("@Pin", "");
            cmd.Parameters.AddWithValue("@tId", "");
            cmd.Parameters.AddWithValue("@active", "");
            cmd.Parameters.AddWithValue("@Identity_Proof", "");
            cmd.Parameters.AddWithValue("@Identity_Proof_Value", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value","");
            cmd.Parameters.AddWithValue("@Is_Informed_Person", "");
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

            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[20].Action;

            }


            con.Open();
            string query = "select a.fId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Marital_Status , a.Religion , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.tId , a.active , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Is_Informed_Person from testatorFamily a inner join TestatorDetails b on a.tId=b.tId inner join users c on b.uId = c.uId where c.Linked_user =  " + Convert.ToInt32(Session["uuid"]) + " ";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    //+ "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    //+ "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    //+ "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    //+ "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    //+ "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    //+ "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["fId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["fId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    //+ "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    //+ "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Is_Informed_Person"].ToString() + "</td>";



                    }
                }



            }

            return data;
        }





        public int UpdateTestatorFamilyData()
        {
            int index = Convert.ToInt32(Request["send"]);




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