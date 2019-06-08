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
    public class AddAppointeesController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddAppointees
        public ActionResult AddAppointeesIndex(string success)
        {
            if (success == "true")
            {
                ViewBag.Message = "Verified";
            }

            ViewBag.collapse = "true";
            if (Session["rId"] == null || Session["uuid"] == null)
            {

               RedirectToAction("LoginPageIndex", "LoginPage");

            }
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




            // total count Dashboard

            string q1 = "select count(*) as TotalDistributorAdmin from users  where Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and Type = 'DistributorAdmin'";
            SqlDataAdapter da1 = new SqlDataAdapter(q1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            ViewBag.TotalDistributorAdmin = Convert.ToInt32(dt1.Rows[0]["TotalDistributorAdmin"]);




            string q2 = "select count(*) as TotalWillEmployee from users  where Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and Type = 'WillEmployee'";
            SqlDataAdapter da22 = new SqlDataAdapter(q2, con);
            DataTable dt22 = new DataTable();
            da22.Fill(dt22);
            ViewBag.TotalWillEmployee = Convert.ToInt32(dt22.Rows[0]["TotalWillEmployee"]);



            string q4 = "select count(*) as TotalDistributorEmployee from users  where Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and Type = 'DistributorEmployee'";
            SqlDataAdapter da4 = new SqlDataAdapter(q4, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            ViewBag.TotalDistributorEmployee = Convert.ToInt32(dt4.Rows[0]["TotalDistributorEmployee"]);



            string q5 = "select count(*) as TotalTestator  from TestatorDetails a inner join users b on a.uId=b.uId where b.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da5 = new SqlDataAdapter(q5, con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            ViewBag.TotalTestator = Convert.ToInt32(dt5.Rows[0]["TotalTestator"]);



            string q6 = "select count(*) as TotalWillEmployee from users  where Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and Type = 'WillEmployee'";
            SqlDataAdapter da6 = new SqlDataAdapter(q6, con);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);
            ViewBag.TotalWillEmployee = Convert.ToInt32(dt6.Rows[0]["TotalWillEmployee"]);




            string q7 = "select count(*) as TotalFamily from testatorFamily a inner join TestatorDetails b on a.tId=b.tId inner join users c on b.uId = c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da7 = new SqlDataAdapter(q7, con);
            DataTable dt7 = new DataTable();
            da7.Fill(dt7);
            ViewBag.TotalFamily = Convert.ToInt32(dt7.Rows[0]["TotalFamily"]);



            string q8 = "select count(*) as TotalAssetInformation from AssetInformation a  inner join TestatorDetails b on a.tid=b.tId inner join AssetsType c on a.atId = c.atId inner join AssetsCategory d on a.amId=d.amId inner join users e on e.uId=b.uId  where e.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da8 = new SqlDataAdapter(q8, con);
            DataTable dt8 = new DataTable();
            da8.Fill(dt8);
            ViewBag.TotalAssetInformation = Convert.ToInt32(dt8.Rows[0]["TotalAssetInformation"]);



            string q9 = "select count(*) as TotalBeneficiary from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId inner join users c on b.uId = c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da9 = new SqlDataAdapter(q9, con);
            DataTable dt9 = new DataTable();
            da9.Fill(dt9);
            ViewBag.TotalBeneficiary = Convert.ToInt32(dt9.Rows[0]["TotalBeneficiary"]);



            string q10 = "select count(*) as TotalNominee from Nominee a inner join TestatorDetails b on a.tId=b.tId inner join users c on b.uId=c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da10 = new SqlDataAdapter(q10, con);
            DataTable dt10 = new DataTable();
            da10.Fill(dt10);
            ViewBag.TotalNominee = Convert.ToInt32(dt10.Rows[0]["TotalNominee"]);




            string q11 = "select count(*) as TotalAppointees  from Appointees a inner join  TestatorDetails b on a.tid=b.tid inner join users c on b.uId=c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da11 = new SqlDataAdapter(q11, con);
            DataTable dt11 = new DataTable();
            da11.Fill(dt11);
            ViewBag.TotalAppointees = Convert.ToInt32(dt11.Rows[0]["TotalAppointees"]);





            con.Close();



            //end


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

                    ViewBag.view = "Will";
             


            
                    ViewBag.view = "POA";
                    ViewBag.view = "GiftDeeds";










            AppointeesModel Am = new AppointeesModel();
          

            con.Open();
            string query = "select * from Appointees where apId = " + Session["distid"].ToString() + "";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Am.Typetxt = dt.Rows[i]["Type"].ToString();
                    Am.subTypetxt = dt.Rows[i]["subType"].ToString();
                    Am.Name = dt.Rows[i]["Name"].ToString();
                    Am.middleName = dt.Rows[i]["middleName"].ToString();
                    Am.Surname = dt.Rows[i]["Surname"].ToString();
                    Am.Identity_Proof = dt.Rows[i]["Identity_Proof"].ToString();
                    Am.Identity_Proof_Value = dt.Rows[i]["Identity_Proof_Value"].ToString();
                    Am.Alt_Identity_Proof = dt.Rows[i]["Alt_Identity_Proof"].ToString();
                    Am.Alt_Identity_Proof_Value = dt.Rows[i]["Alt_Identity_Proof_Value"].ToString();
                    Am.Dob = Convert.ToDateTime(dt.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
                    Am.Gender = dt.Rows[i]["Gender"].ToString();
                    Am.Occupation = dt.Rows[i]["Occupation"].ToString();
                    Am.RelationshipTxt = dt.Rows[i]["Relationship"].ToString();
                    Am.Address1 = dt.Rows[i]["Address1"].ToString();
                    Am.Address2 = dt.Rows[i]["Address2"].ToString();
                    Am.Address3 = dt.Rows[i]["Address3"].ToString();
                    Am.citytext = dt.Rows[i]["City"].ToString();
                    Am.statetext = dt.Rows[i]["State"].ToString();
                    Am.Pin = dt.Rows[i]["Pin"].ToString();




                }
            }







            return View("/Views/AddAppointees/AddAppointeesPageContent.cshtml",Am);
        }


        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state where country_id = 101 order by statename asc  ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

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
            string query = "select distinct * from tbl_city where state_id ='" + response + "' order by city_name asc ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value='0'>--Select--</option>";

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
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["Rid"].ToString() + " >" + dt.Rows[i]["MemberName"].ToString() + "</option>";



                }




            }

            return data;

        }


        public ActionResult InsertAppointeesFormData(AppointeesModel AM)
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



            AM.documentId =0;
            int appid = 0;
            // latest appointees
            int apid = 0;
            if (Session["doctype"].ToString() == "Will")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDAppointees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@documentId", AM.documentId);
                cmd.Parameters.AddWithValue("@Type", AM.Typetxt);
                cmd.Parameters.AddWithValue("@subType", AM.subTypetxt);
                cmd.Parameters.AddWithValue("@Name", AM.Name);
                cmd.Parameters.AddWithValue("@middleName", AM.middleName);
                cmd.Parameters.AddWithValue("@Surname", AM.Surname);
                cmd.Parameters.AddWithValue("@Identity_proof", AM.Identity_Proof);
                cmd.Parameters.AddWithValue("@Identity_proof_value", AM.Identity_Proof_Value);


                if (AM.Alt_Identity_Proof != null)
                {
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof", AM.Alt_Identity_Proof);
                }
                else
                {
                    AM.Alt_Identity_Proof = "None";
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof", AM.Alt_Identity_Proof);
                }


                if (AM.Alt_Identity_Proof_Value != null)
                {
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.Alt_Identity_Proof_Value);
                }
                else
                {
                    AM.Alt_Identity_Proof_Value = "None";
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.Alt_Identity_Proof_Value);
                }

                
               






                DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@DOB", dat);
                cmd.Parameters.AddWithValue("@Gender", AM.Gender);
                cmd.Parameters.AddWithValue("@Occupation", AM.Occupation);
                cmd.Parameters.AddWithValue("@Relationship", AM.RelationshipTxt);
                cmd.Parameters.AddWithValue("@Address1", AM.Address1);
                if (AM.Address2 != null || AM.Address2 == "")
                {
                    cmd.Parameters.AddWithValue("@Address2", AM.Address2);
                }
                else
                {
                    AM.Address2 = "None";
                    cmd.Parameters.AddWithValue("@Address2", AM.Address2);
                }


                if (AM.Address3 != null || AM.Address3 == "")
                {
                    cmd.Parameters.AddWithValue("@Address3", AM.Address3);
                }
                else
                {
                    AM.Address3 = "None";
                    cmd.Parameters.AddWithValue("@Address3", AM.Address3);
                }


                cmd.Parameters.AddWithValue("@City", AM.citytext);
                cmd.Parameters.AddWithValue("@State", AM.statetext);
                cmd.Parameters.AddWithValue("@Pin", AM.Pin);
                cmd.Parameters.AddWithValue("@tid", AM.ddltid);
                cmd.ExecuteNonQuery();
                con.Close();


             
                con.Open();
                string query = "select top 1 * from Appointees order by apId desc";
                SqlDataAdapter da2 = new SqlDataAdapter(query, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    appid = Convert.ToInt32(dt2.Rows[0]["apId"]);
                    apid = 1; // for yes
                }
                else
                {
                    apid = 2; //for no
                }
                con.Close();



                //end


                con.Open();
                string qt = "update Appointees set doctype = 'Will'  where  apId = "+ Convert.ToInt32(dt2.Rows[0]["apId"]) + "";
                SqlCommand cmdt = new SqlCommand(qt,con);
                cmdt.ExecuteNonQuery();
                con.Close();


            }




            if (Session["doctype"].ToString() == "POA")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDAppointees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@documentId", AM.documentId);
                cmd.Parameters.AddWithValue("@Type", AM.Typetxt);
                cmd.Parameters.AddWithValue("@subType", AM.subTypetxt);
                cmd.Parameters.AddWithValue("@Name", AM.Name);
                cmd.Parameters.AddWithValue("@middleName", AM.middleName);
                cmd.Parameters.AddWithValue("@Surname", AM.Surname);
                cmd.Parameters.AddWithValue("@Identity_proof", AM.Identity_Proof);
                cmd.Parameters.AddWithValue("@Identity_proof_value", AM.Identity_Proof_Value);



                if (AM.Alt_Identity_Proof != null)
                {
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof", AM.Alt_Identity_Proof);
                }
                else
                {
                    AM.Alt_Identity_Proof = "None";
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof", AM.Alt_Identity_Proof);
                }


                if (AM.Alt_Identity_Proof_Value != null)
                {
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.Alt_Identity_Proof_Value);
                }
                else
                {
                    AM.Alt_Identity_Proof_Value = "None";
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.Alt_Identity_Proof_Value);
                }


                
               





                DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@DOB", dat);
                cmd.Parameters.AddWithValue("@Gender", AM.Gender);
                cmd.Parameters.AddWithValue("@Occupation", AM.Occupation);
                cmd.Parameters.AddWithValue("@Relationship", AM.RelationshipTxt);
                cmd.Parameters.AddWithValue("@Address1", AM.Address1);
                if (AM.Address2 != null || AM.Address2 == "")
                {
                    cmd.Parameters.AddWithValue("@Address2", AM.Address2);
                }
                else
                {
                    AM.Address2 = "None";
                    cmd.Parameters.AddWithValue("@Address2", AM.Address2);
                }


                if (AM.Address3 != null || AM.Address3 == "")
                {
                    cmd.Parameters.AddWithValue("@Address3", AM.Address3);
                }
                else
                {
                    AM.Address3 = "None";
                    cmd.Parameters.AddWithValue("@Address3", AM.Address3);
                }


                cmd.Parameters.AddWithValue("@City", AM.citytext);
                cmd.Parameters.AddWithValue("@State", AM.statetext);
                cmd.Parameters.AddWithValue("@Pin", AM.Pin);
                cmd.Parameters.AddWithValue("@tid", AM.ddltid);
                cmd.ExecuteNonQuery();
                con.Close();


               
                con.Open();
                string query = "select top 1 * from Appointees order by apId desc";
                SqlDataAdapter da2 = new SqlDataAdapter(query, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    appid = Convert.ToInt32(dt2.Rows[0]["apId"]);
                    apid = 1; // for yes
                }
                else
                {
                    apid = 2; //for no
                }
                con.Close();



                //end
                con.Open();
                string qt = "update Appointees set doctype = 'POA'  where  apId = " + apid + "";
                SqlCommand cmdt = new SqlCommand(qt, con);
                cmdt.ExecuteNonQuery();
                con.Close();

            }



            if (Session["doctype"].ToString() == "Giftdeeds")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDAppointees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@documentId", AM.documentId);
                cmd.Parameters.AddWithValue("@Type", AM.Typetxt);
                cmd.Parameters.AddWithValue("@subType", AM.subTypetxt);
                cmd.Parameters.AddWithValue("@Name", AM.Name);
                cmd.Parameters.AddWithValue("@middleName", AM.middleName);
                cmd.Parameters.AddWithValue("@Surname", AM.Surname);
                cmd.Parameters.AddWithValue("@Identity_proof", AM.Identity_Proof);
                cmd.Parameters.AddWithValue("@Identity_proof_value", AM.Identity_Proof_Value);
                cmd.Parameters.AddWithValue("@Alt_Identity_proof", AM.Alt_Identity_Proof);
                cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.Alt_Identity_Proof_Value);
                DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@DOB", dat);
                cmd.Parameters.AddWithValue("@Gender", AM.Gender);
                cmd.Parameters.AddWithValue("@Occupation", AM.Occupation);
                cmd.Parameters.AddWithValue("@Relationship", AM.RelationshipTxt);
                cmd.Parameters.AddWithValue("@Address1", AM.Address1);
                if (AM.Address2 != null || AM.Address2 == "")
                {
                    cmd.Parameters.AddWithValue("@Address2", AM.Address2);
                }
                else
                {
                    AM.Address2 = "None";
                    cmd.Parameters.AddWithValue("@Address2", AM.Address2);
                }


                if (AM.Address3 != null || AM.Address3 == "")
                {
                    cmd.Parameters.AddWithValue("@Address3", AM.Address3);
                }
                else
                {
                    AM.Address3 = "None";
                    cmd.Parameters.AddWithValue("@Address3", AM.Address3);
                }


                cmd.Parameters.AddWithValue("@City", AM.citytext);
                cmd.Parameters.AddWithValue("@State", AM.statetext);
                cmd.Parameters.AddWithValue("@Pin", AM.Pin);
                cmd.Parameters.AddWithValue("@tid", AM.ddltid);
                cmd.ExecuteNonQuery();
                con.Close();


               
                con.Open();
                string query = "select top 1 * from Appointees order by apId desc";
                SqlDataAdapter da2 = new SqlDataAdapter(query, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    appid = Convert.ToInt32(dt2.Rows[0]["apId"]);
                    apid = 1; // for yes
                }
                else
                {
                    apid = 2; //for no
                }
                con.Close();



                //end
                con.Open();
                string qt = "update Appointees set doctype = 'Giftdeeds'  where  apId = " + apid + "";
                SqlCommand cmdt = new SqlCommand(qt, con);
                cmdt.ExecuteNonQuery();
                con.Close();

            }

            // dropdown selection
            int AppointmentofGuardian = 0;
            if (AM.Typetxt == "Guardian")
            {
                AppointmentofGuardian = 1;    //yes
            }
            else
            {
                AppointmentofGuardian = 2;    // no
            }

            int Numberofexecutors = 0;
            if (AM.subTypetxt == "Single")
            {
                Numberofexecutors = 1;
            }
            if (AM.subTypetxt == "Many Joint")
            {
                Numberofexecutors = 2;
            }
            if (AM.subTypetxt == "Many Independent")
            {
                Numberofexecutors = 3;
            }

            //end

            // Document Rules

            //get latest id first
            con.Open();
            string getquery = "select top 1 * from documentRules order by wdId desc";
            SqlDataAdapter da = new SqlDataAdapter(getquery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int getruleid = 0;
            if (dt.Rows.Count > 0)
            {
                getruleid = Convert.ToInt32(dt.Rows[0]["wdId"]);
            }
            con.Close();

            //end



            con.Open();
            string rulequery = "update documentRules set guardian = " + AppointmentofGuardian + " ,executors_category = " + Numberofexecutors + " where tid = " + AM.ddltid + " ";
            SqlCommand cmd2 = new SqlCommand(rulequery, con);
            cmd2.ExecuteNonQuery();
            con.Close();
            //end








           


            if (AM.check == "true")
            {
                // alternate appointees

                con.Open();
                SqlCommand cmdd = new SqlCommand("SP_CRUDAlternateAppointees", con);
                cmdd.CommandType = CommandType.StoredProcedure;
                cmdd.Parameters.AddWithValue("@condition", "insert");

                if (appid != 0)
                {
                    cmdd.Parameters.AddWithValue("@apId", appid);
                }
                else
                {
                    appid = 0;
                    cmdd.Parameters.AddWithValue("@apId", appid);
                }

                

                cmdd.Parameters.AddWithValue("@Name", AM.altName);
                cmdd.Parameters.AddWithValue("@middleName", AM.altmiddleName);
                cmdd.Parameters.AddWithValue("@Surname", AM.altSurname);
                cmdd.Parameters.AddWithValue("@Identity_proof", AM.altIdentity_Proof);
                cmdd.Parameters.AddWithValue("@Identity_proof_value", AM.altIdentity_Proof_Value);


                if (AM.altAlt_Identity_Proof != null)
                {

                    cmdd.Parameters.AddWithValue("@Alt_Identity_proof", AM.altAlt_Identity_Proof);
                }
                else
                {
                      AM.altAlt_Identity_Proof = "None";
                     cmdd.Parameters.AddWithValue("@Alt_Identity_proof", AM.altAlt_Identity_Proof);
                }


                if (AM.altAlt_Identity_Proof_Value != null)
                {
                    cmdd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.altAlt_Identity_Proof_Value);
                }
                else
                {
                    AM.altAlt_Identity_Proof_Value = "None";
                    cmdd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.altAlt_Identity_Proof_Value);
                }
               
               
                DateTime dat2 = DateTime.ParseExact(AM.altDob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmdd.Parameters.AddWithValue("@DOB", dat2);
                cmdd.Parameters.AddWithValue("@Gender", AM.altGender);
                cmdd.Parameters.AddWithValue("@Occupation", AM.altOccupation);
                cmdd.Parameters.AddWithValue("@Relationship", AM.altRelationshipTxt);
                cmdd.Parameters.AddWithValue("@Address1", AM.altAddress1);
                if (AM.altAddress2 != null || AM.altAddress2 == "")
                {
                    cmdd.Parameters.AddWithValue("@Address2", AM.altAddress2);
                }
                else
                {
                    AM.altAddress2 = "None";
                    cmdd.Parameters.AddWithValue("@Address2", AM.altAddress2);
                }


                if (AM.altAddress3 != null || AM.altAddress3 == "")
                {
                    cmdd.Parameters.AddWithValue("@Address3", AM.altAddress3);
                }
                else
                {
                    AM.altAddress3 = "None";
                    cmdd.Parameters.AddWithValue("@Address3", AM.altAddress3);
                }

                cmdd.Parameters.AddWithValue("@City", AM.altcitytext);
                cmdd.Parameters.AddWithValue("@State", AM.altstatetext);
                cmdd.Parameters.AddWithValue("@Pin", AM.altPin);
                cmdd.Parameters.AddWithValue("@tid", AM.ddltid);
                cmdd.Parameters.AddWithValue("@altguardian", AM.altguardian);
                if (AM.altexecutor != null)
                {
                    cmdd.Parameters.AddWithValue("@altexecutor", AM.altexecutor);
                }
                else
                {
                    AM.altexecutor = "None";
                    cmdd.Parameters.AddWithValue("@altexecutor", AM.altexecutor);
                }
             
                
                cmdd.ExecuteNonQuery();
                con.Close();





                //end

            }


            ViewBag.Message = "Verified";


            // latest appointees
            int altapid = 0;
            con.Open();
            string query4 = "select top 1 * from alternate_Appointees order by apId desc";
            SqlDataAdapter da4 = new SqlDataAdapter(query4, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            if (dt4.Rows.Count > 0)
            {

                altapid = 1; // for yes
            }
            else
            {
                altapid = 2; //for no
            }
            con.Close();



            //end



            // dropdown selection
            int AppointmentofaltGuardian = 0;
            if (AM.altguardian == "Guardian")
            {
                AppointmentofaltGuardian = 1;    //yes
            }
            else
            {
                AppointmentofaltGuardian = 2;    // no
            }

            int altNumberofexecutors = 2;
            if (AM.altexecutor == "Single")
            {
                altNumberofexecutors = 1;
            }
            if (AM.altexecutor == "Many Joint")
            {
                altNumberofexecutors = 1;
            }
            if (AM.altexecutor == "Many Independent")
            {
                altNumberofexecutors = 1;
            }

            //end

            // Document Rules

            //get latest id first
            con.Open();
            string getquery4 = "select top 1 * from documentRules order by wdId desc";
            SqlDataAdapter da5 = new SqlDataAdapter(getquery4, con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            int getruleid2 = 0;
            if (dt.Rows.Count > 0)
            {
                getruleid2 = Convert.ToInt32(dt5.Rows[0]["wdId"]);
            }
            con.Close();

            //end



            con.Open();
            string rulequery2 = "update documentRules set AlternateGaurdian = " + AppointmentofaltGuardian + " , AlternateExecutors = " + altNumberofexecutors + " where tid = " + AM.ddltid + " ";
            SqlCommand cmd6 = new SqlCommand(rulequery2, con);
            cmd6.ExecuteNonQuery();
            con.Close();
            //end


            // update document master with latest rule id

            con.Open();
            string rquery2 = "update documentMaster set wdId = "+ getruleid2 + " where tId =  " + AM.ddltid + "  ";
            SqlCommand rcmd2 = new SqlCommand(rquery2, con);
            rcmd2.ExecuteNonQuery();
            con.Close();




            //end



            ModelState.Clear();

            return RedirectToAction("AddAppointeesIndex", "AddAppointees", new { success = "true" });
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
                    string query2 = "select * from Appointees where tId =  " + Convert.ToInt32(dt.Rows[0]["tId"]) + " ";
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




                            data = data + "<option value=" + dt.Rows[i]["tId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option> " + "~" + dt.Rows[i]["tId"].ToString() +"~"+popup;



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
            if (checkstatus != "true")
            {

                int Response = Convert.ToInt32(Request["send"]);

                if (Request["send"] != "")
                {
                    // check for data exists or not for testato family
                    if (value != null)
                    {
                        con.Open();
                        string query1 = "select * from Appointees where tid = " + value + " ";
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






    }
}