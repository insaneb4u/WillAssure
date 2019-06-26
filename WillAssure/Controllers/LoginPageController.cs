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
                string q = Request.QueryString["Type"].ToString();
                q = q.Replace("/", "");
                ViewBag.type = q;
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
                                return RedirectToAction("Index", "Frontend" , new { displayname = Session["displayname"].ToString() });
                            }


                               
                        }
                        else
                        {
                            return RedirectToAction("DashBoardIndex", "DashBoard");
                        }


                       
                        }
                    
                  




                    return RedirectToAction("DashBoardIndex", "DashBoard");


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




       






    }
}