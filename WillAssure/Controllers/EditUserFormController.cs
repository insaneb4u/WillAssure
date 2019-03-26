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
    public class EditUserFormController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        public ActionResult EditUserFormIndex()
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

            return View("~/Views/EditUserForm/EditUserFormPageContent.cshtml");
        }


        public string BindUserForm()
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

            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[3].Action;

            }


            con.Open();
            string query = "select * from users";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            string Role = "";
            string a = "";
            if (dt.Rows.Count > 0)
            {

                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int Status = Convert.ToInt32(dt.Rows[i]["active"]);



                        if (Status == 1)
                        {
                            a = "Active";
                        }
                        else
                        {
                            a = "InActive";
                        }




                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                    + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                    + "<td>" + a + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int Status = Convert.ToInt32(dt.Rows[i]["active"]);



                        if (Status == 1)
                        {
                            a = "Active";
                        }
                        else
                        {
                            a = "InActive";
                        }




                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                    + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                    + "<td>" + a + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger'>Delete</button></td></tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int Status = Convert.ToInt32(dt.Rows[i]["active"]);



                        if (Status == 1)
                        {
                            a = "Active";
                        }
                        else
                        {
                            a = "InActive";
                        }




                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                    + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                    + "<td>" + a + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger'>Delete</button></td></tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int Status = Convert.ToInt32(dt.Rows[i]["active"]);



                        if (Status == 1)
                        {
                            a = "Active";
                        }
                        else
                        {
                            a = "InActive";
                        }




                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                    + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                    + "<td>" + a + "</td>";

                                 

                    }
                }


              
                


              
            


                


                }

                    return data;
        }



        public string DeleteEditFormRecords()
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Users", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@uid", index);
            cmd.Parameters.AddWithValue("@FirstName", "");
            cmd.Parameters.AddWithValue("@LastName","");
            cmd.Parameters.AddWithValue("@MiddleName","");
            cmd.Parameters.AddWithValue("@Dob","");
            cmd.Parameters.AddWithValue("@Mobile", "");
            cmd.Parameters.AddWithValue("@Email", "");
            cmd.Parameters.AddWithValue("@Address1", "");
            cmd.Parameters.AddWithValue("@Address2","");
            cmd.Parameters.AddWithValue("@Address3", "");
            cmd.Parameters.AddWithValue("@City","");
            cmd.Parameters.AddWithValue("@State ", "");
            cmd.Parameters.AddWithValue("@Pin", "");
            cmd.Parameters.AddWithValue("@UserId","");
            cmd.Parameters.AddWithValue("@UserPassword", "");
           
            cmd.Parameters.AddWithValue("@Designation", "");
            cmd.Parameters.AddWithValue("@Active", "");
            cmd.Parameters.AddWithValue("@compId", "");
            cmd.Parameters.AddWithValue("@Linked_user", "");
            cmd.Parameters.AddWithValue("@rid", "");
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
                testString = Lmlist[3].Action;

            }


            con.Open();
            string query = "select * from users";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            string Role = "";
            string a = "";
            if (dt.Rows.Count > 0)
            {

                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int Status = Convert.ToInt32(dt.Rows[i]["active"]);



                        if (Status == 1)
                        {
                            a = "Active";
                        }
                        else
                        {
                            a = "InActive";
                        }




                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                    + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                    + "<td>" + a + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int Status = Convert.ToInt32(dt.Rows[i]["active"]);



                        if (Status == 1)
                        {
                            a = "Active";
                        }
                        else
                        {
                            a = "InActive";
                        }




                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                    + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                    + "<td>" + a + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger'>Delete</button></td></tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int Status = Convert.ToInt32(dt.Rows[i]["active"]);



                        if (Status == 1)
                        {
                            a = "Active";
                        }
                        else
                        {
                            a = "InActive";
                        }




                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                    + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                    + "<td>" + a + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger'>Delete</button></td></tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int Status = Convert.ToInt32(dt.Rows[i]["active"]);



                        if (Status == 1)
                        {
                            a = "Active";
                        }
                        else
                        {
                            a = "InActive";
                        }




                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                    + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                    + "<td>" + a + "</td>";



                    }
                }













            }

            return data;
        }




        public int UpdateEditForm()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }







    }
}