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
using System.Collections;


namespace WillAssure.Controllers
{
    public class EditVisitorController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: EditVisitor
        public ActionResult EditVisitorIndex()
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

            return View("~/Views/EditVisitor/EditVisitorPageContent.cshtml");
        }

        public string BindvisitorFormData()
        {

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
            string query = "select * from visitorinfo";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
           

           



            if (dt.Rows.Count > 0)
            {

               
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["vid"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["RefDist"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["DocumentType"].ToString() + "</td>"
                      + "<td> <button type='button'   id='" + dt.Rows[i]["vid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id=" + dt.Rows[i]["vid"].ToString() + "     class='btn btn-danger deletenotification'>Delete</button>  <button type='button'   id=" + dt.Rows[i]["vid"].ToString() + " onClick='verifydoc(this.id)'     class='btn btn-success deletenotification'>Verify Visitor</button></td></tr>";
                }
                


             




            }

            return data;
        }



        public string DeletevisitorRecords(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            string query = "delete from visitorinfo where vid = "+Response+" )";
            SqlCommand cmd = new SqlCommand(query, con);
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



            con.Open();
            string query2 = "select * from visitorinfo";
            SqlDataAdapter da = new SqlDataAdapter(query2, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[0].Action;

            }



            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["vid"].ToString() + "</td>"
                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                    + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                    + "<td>" + dt.Rows[i]["RefDist"].ToString() + "</td>"
                    + "<td>" + dt.Rows[i]["DocumentType"].ToString() + "</td>"
                    + "<td> <button type='button'   id='" + dt.Rows[i]["vid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id=" + dt.Rows[i]["vid"].ToString() + "     class='btn btn-danger deletenotification'>Delete</button>  <button type='button'   id=" + dt.Rows[i]["vid"].ToString() + " onClick='verifydoc(this.id)'     class='btn btn-success deletenotification'>Verify Visitor</button></td></tr>";
                }








            }

            return data;
        }





        public int Updatevisitor()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }




      




    }
}