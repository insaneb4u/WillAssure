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
    public class AddNomineeController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddNominee
        public ActionResult AddNomineeIndex(string success)
        {

            if (success == "true")
            {
                ViewBag.Message = "Verified";
            }
            ViewBag.collapse = "true";
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
            //if (Session["aiid"] == null && Session["tid"] == null)
            //{
            //    ViewBag.Message = "link";
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





            NomineeModel NM = new NomineeModel();
            con.Open();
            string query = "select * from Nominee where tId = "+ Convert.ToInt32(Session["distid"]) + " ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ViewBag.disablefield = "true";
                    NM.nId = Convert.ToInt32(dt.Rows[i]["nId"]);
                    NM.First_Name = dt.Rows[i]["First_Name"].ToString();
                    NM.Last_Name = dt.Rows[i]["Last_Name"].ToString();
                    NM.Middle_Name = dt.Rows[i]["Middle_Name"].ToString();
                    NM.Dob = Convert.ToDateTime(dt.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
                    NM.Mobile = dt.Rows[i]["Mobile"].ToString();
                    NM.RelationshipTxt = dt.Rows[i]["Relationship"].ToString();
                    NM.Marital_Status = dt.Rows[i]["Marital_Status"].ToString();
                    NM.Religion = dt.Rows[i]["Religion"].ToString();
                    NM.Identity_Proof = dt.Rows[i]["Identity_Proof"].ToString();
                    NM.Identity_Proof_Value = dt.Rows[i]["Identity_Proof_Value"].ToString();
                    NM.Alt_Identity_Proof = dt.Rows[i]["Alt_Identity_Proof"].ToString();
                    NM.Alt_Identity_Proof_Value = dt.Rows[i]["Alt_Identity_Proof_Value"].ToString();
                    NM.Address1 = dt.Rows[i]["Address1"].ToString();
                    NM.Address2 = dt.Rows[i]["Address2"].ToString();
                    NM.Address3 = dt.Rows[i]["Address3"].ToString();
                    NM.citytext = dt.Rows[i]["City"].ToString();
                    NM.statetext = dt.Rows[i]["State"].ToString();
                    NM.Pin = dt.Rows[i]["Pin"].ToString();
                    NM.aid = Convert.ToInt32(dt.Rows[i]["aiid"]);
                    NM.tId = Convert.ToInt32(dt.Rows[i]["tId"]);

                    NM.createdBy = dt.Rows[i]["createdBy"].ToString();
                    NM.documentId = Convert.ToInt32(dt.Rows[i]["documentId"]);
                    NM.Description_of_Assets = dt.Rows[i]["Description_of_Assets"].ToString();



                }
            }




            return View("~/Views/AddNominee/AddNomineePageContent.cshtml",NM);
        }


        public ActionResult InsertNomineeData(NomineeModel NM)
        {

            ViewBag.collapse = "true";
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


            //end



            //if (Session["aiid"] != null && Session["tid"] != null)
            //{
            if (Session["aiid"] == null)
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

            //asset information id

            

            //if (Convert.ToInt32(Session["aiid"]) != 0)
            //{
            //    NM.aid = Convert.ToInt32(Session["aiid"]);
            //}
            //else
            //{
                NM.aid = 0;
            //}

            //end

                //NM.tId = Convert.ToInt32(Session["tid"]);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDNominee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@First_Name", NM.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", NM.Last_Name);
                cmd.Parameters.AddWithValue("@Middle_Name", NM.Middle_Name);
                DateTime dat = DateTime.ParseExact(NM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@DOB", dat);
                cmd.Parameters.AddWithValue("@Mobile", NM.Mobile);
                cmd.Parameters.AddWithValue("@Relationship", NM.RelationshipTxt);
                cmd.Parameters.AddWithValue("@Marital_Status", NM.Marital_Status);
                cmd.Parameters.AddWithValue("@Religion", NM.Religion);
                cmd.Parameters.AddWithValue("@Identity_Proof", NM.Identity_Proof);
                cmd.Parameters.AddWithValue("@Identity_Proof_Value", NM.Identity_Proof_Value);

            if (NM.Alt_Identity_Proof != null)
            {
                cmd.Parameters.AddWithValue("@Alt_Identity_Proof", NM.Alt_Identity_Proof);
            }
            else
            {
                NM.Alt_Identity_Proof = "None";
                cmd.Parameters.AddWithValue("@Alt_Identity_Proof", NM.Alt_Identity_Proof);
            }


            if (NM.Alt_Identity_Proof_Value != null)
            {
                cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", NM.Alt_Identity_Proof_Value);
            }
            else
            {
                NM.Alt_Identity_Proof_Value = "None";
                cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", NM.Alt_Identity_Proof_Value);
            }
               
                
                cmd.Parameters.AddWithValue("@Address1", NM.Address1);
            if (NM.Address2 != null)
            {
                cmd.Parameters.AddWithValue("@Address2", NM.Address2);
            }
            else
            {
                NM.Address2 = "None";
                cmd.Parameters.AddWithValue("@Address2", NM.Address2);
            }

            if (NM.Address3 != null)
            {
                cmd.Parameters.AddWithValue("@Address3", NM.Address3);
            }
            else
            {
                NM.Address3 = "None";
                cmd.Parameters.AddWithValue("@Address3", NM.Address3);
            }

           
                cmd.Parameters.AddWithValue("@City", NM.citytext);
                cmd.Parameters.AddWithValue("@State", NM.statetext);
                cmd.Parameters.AddWithValue("@Pin", NM.Pin);
                cmd.Parameters.AddWithValue("@aid", NM.aid);
                cmd.Parameters.AddWithValue("@tId", NM.ddltid);
                cmd.Parameters.AddWithValue("@createdBy", Convert.ToInt32(Session["uuid"]));
                cmd.Parameters.AddWithValue("@documentId", NM.documentId);
                cmd.Parameters.AddWithValue("@Description_of_Assets", NM.Description_of_Assets);
                cmd.ExecuteNonQuery();
                con.Close();
                ModelState.Clear();
                ViewBag.Message = "Verified";
            //}
            //else
            //{


            //    ViewBag.Message = "link";

            //}

            ViewBag.disablefield = "true";


            return RedirectToAction("AddNomineeIndex", "AddNominee", new { success = "true" });
        }


        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state where country_id = 101 order by statename asc  ";
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
            string data = "<option value=''>--Select--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["Rid"].ToString() + " >" + dt.Rows[i]["MemberName"].ToString() + "</option>";



                }




            }

            return data;

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

                    con.Open();
                    string query2 = "select * from Nominee where tId =  " + Convert.ToInt32(dt.Rows[0]["tId"]) + " ";
                    SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    con.Close();
                    string popup = "";
                    if (dt2.Rows.Count > 0)
                    {
                        popup = "true";

                    }



                    if (dt.Rows.Count > 0)
                    {



                        for (int i = 0; i < dt.Rows.Count; i++)
                        {




                            data = data + "<option value=" + dt.Rows[i]["tId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option> " + "~" + dt.Rows[i]["tId"].ToString() +"~" + popup;



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













        public int CheckTestatorUsers(string value, string checkstatus)
        {
            int check = 0;
            if (checkstatus != "true" )
            {

                

                if (value != null)
                {
                    // check for data exists or not for testato family
                   
                    con.Open();
                    string query1 = " select a.nId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.Description_of_Assets from Nominee a inner join TestatorDetails b on a.tId=b.tId where b.tId = " + value+" ";
                    SqlDataAdapter da = new SqlDataAdapter(query1, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //end

                    if (dt.Rows.Count > 0)
                    {
                        string query2 = "Update PageActivity set ActID=1 , Tid=" + value + " , PageStatus=2  ";
                        SqlCommand cmd = new SqlCommand(query2, con);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string query2 = "Update PageActivity set ActID=1 , Tid=" + value + " , PageStatus=1  ";
                        SqlCommand cmd = new SqlCommand(query2, con);
                        cmd.ExecuteNonQuery();
                    }




                    // if already exits page status 2 else 1

                    string query3 = "select * from PageActivity";
                    SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);

                    if (dt3.Rows.Count > 0)
                    {
                        check = Convert.ToInt32(dt3.Rows[0]["PageStatus"]);




                    }


                    //end






                    con.Close();

                }





                return check;
            }

            return check;

        }



        public ActionResult updateNominee(NomineeModel NM)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDNominee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@nId", NM.nId);
            cmd.Parameters.AddWithValue("@First_Name", NM.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", NM.Last_Name);
            cmd.Parameters.AddWithValue("@Middle_Name", NM.Middle_Name);
            //DateTime dat = DateTime.ParseExact(Convert.ToDateTime(NM.Dob), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(NM.Dob));
            cmd.Parameters.AddWithValue("@Mobile", NM.Mobile);
            cmd.Parameters.AddWithValue("@Relationship", NM.RelationshipTxt);
            cmd.Parameters.AddWithValue("@Marital_Status", NM.Marital_Status);
            cmd.Parameters.AddWithValue("@Religion", NM.Religion);
            cmd.Parameters.AddWithValue("@Identity_Proof", NM.Identity_Proof);
            cmd.Parameters.AddWithValue("@Identity_Proof_Value", NM.Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", NM.Alt_Identity_Proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", NM.Alt_Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Address1", NM.Address1);
            cmd.Parameters.AddWithValue("@Address2", NM.Address2);
            cmd.Parameters.AddWithValue("@Address3", NM.Address3);
            cmd.Parameters.AddWithValue("@City", NM.citytext);
            cmd.Parameters.AddWithValue("@State", NM.statetext);
            cmd.Parameters.AddWithValue("@Pin", NM.Pin);
            cmd.Parameters.AddWithValue("@aid", NM.aid);
            cmd.Parameters.AddWithValue("@tId", NM.ddltid);
            cmd.Parameters.AddWithValue("@createdBy", "None");
            cmd.Parameters.AddWithValue("@documentId", NM.documentId);
            cmd.Parameters.AddWithValue("@Description_of_Assets", NM.Description_of_Assets);
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.Message = "Verified";

            return RedirectToAction("AddNomineeIndex", "AddNominee");
        }





    }
}