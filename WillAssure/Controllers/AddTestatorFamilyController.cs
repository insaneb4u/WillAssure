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
    public class AddTestatorFamilyController : Controller
    {


        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddTestatorFamily
        public ActionResult AddTestatorFamilyIndex(string success , string NestId)
        {

            if (success == "true")
            {
                ViewBag.Message = "Verified";
            
            }

            ViewBag.view = "Will";
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
            //if (Session["tid"]== null)
            //{
            //    ViewBag.message = "link";
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











            TestatorFamilyModel TFM = new TestatorFamilyModel();

            string query = "";


            con.Open();

            if (NestId != null)
            {
                query = "select * from testatorFamily where fId = " + NestId + "";
            }
            else
            {
                query = "select * from testatorFamily where tId = " + Convert.ToInt32(Session["distid"]) + "";
            }

           



            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            int alternatetfid = 0;

            if (dt.Rows.Count > 0)
            {
                ViewBag.disablefield = "true";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TFM.fId = Convert.ToInt32(dt.Rows[i]["fId"]);
                    alternatetfid = Convert.ToInt32(dt.Rows[i]["fId"]);
                    TFM.First_Name = dt.Rows[i]["First_Name"].ToString();
                    TFM.Last_Name = dt.Rows[i]["Last_Name"].ToString();
                    TFM.Middle_Name = dt.Rows[i]["Middle_Name"].ToString();
                    TFM.Dob = Convert.ToDateTime(dt.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
                    TFM.Marital_Status = dt.Rows[i]["Marital_Status"].ToString();
                    TFM.Religion = dt.Rows[i]["Religion"].ToString();
                    TFM.RelationshipTxt = dt.Rows[i]["Relationship"].ToString();
                    TFM.Address1 = dt.Rows[i]["Address1"].ToString();
                    TFM.Address2 = dt.Rows[i]["Address2"].ToString();
                    TFM.Address3 = dt.Rows[i]["Address3"].ToString();
                    TFM.City_txt = dt.Rows[i]["City"].ToString();
                    TFM.State_txt = dt.Rows[i]["State"].ToString();
                    TFM.Pin = dt.Rows[i]["Pin"].ToString();

                    TFM.active = dt.Rows[i]["active"].ToString();
                    TFM.Identity_Proof = dt.Rows[i]["Identity_Proof"].ToString();
                    TFM.Identity_Proof_Value = dt.Rows[i]["Identity_Proof_Value"].ToString();
                    TFM.Alt_Identity_Proof = dt.Rows[i]["Alt_Identity_Proof"].ToString();
                    TFM.Alt_Identity_Proof_Value = dt.Rows[i]["Alt_Identity_Proof_Value"].ToString();
                    TFM.Is_Informed_Person = dt.Rows[i]["Is_Informed_Person"].ToString();



                }
            }







            string query4 = "";

            con.Open();

      
            query4 = "select * from alttestatorFamily where testatorfamilyid = " + alternatetfid + "";
        
            





            SqlDataAdapter da4 = new SqlDataAdapter(query4, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            con.Close();
            string data4 = "";

            if (dt4.Rows.Count > 0)
            {
                ViewBag.disablefield = "true";

                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    TFM.altfId = Convert.ToInt32(dt4.Rows[i]["altfId"]);
                    TFM.altFirst_Name = dt4.Rows[i]["altFirst_Name"].ToString();
                    TFM.altLast_Name = dt4.Rows[i]["altLast_Name"].ToString();
                    TFM.altMiddle_Name = dt4.Rows[i]["altMiddle_Name"].ToString();
                    TFM.altDob = Convert.ToDateTime(dt4.Rows[0]["altDOB"]).ToString("dd-MM-yyyy");
                    TFM.altMarital_Status = dt4.Rows[i]["altMarital_Status"].ToString();
                    TFM.altReligion = dt4.Rows[i]["altReligion"].ToString();
                    TFM.altRelationshipTxt = dt4.Rows[i]["altRelationship"].ToString();
                    TFM.altAddress1 = dt4.Rows[i]["altAddress1"].ToString();
                    TFM.altAddress2 = dt4.Rows[i]["altAddress2"].ToString();
                    TFM.altAddress3 = dt4.Rows[i]["altAddress3"].ToString();
                    TFM.altCity_txt = dt4.Rows[i]["altCity"].ToString();
                    TFM.altState_txt = dt4.Rows[i]["altState"].ToString();
                    TFM.altPin = dt4.Rows[i]["altPin"].ToString();

                    
                    TFM.altIdentity_Proof = dt4.Rows[i]["altIdentity_Proof"].ToString();
                    TFM.altIdentity_Proof_Value = dt4.Rows[i]["altIdentity_Proof_Value"].ToString();
                    TFM.Alt_Identity_Proof = dt4.Rows[i]["altAlt_Identity_Proof"].ToString();
                    TFM.Alt_Identity_Proof_Value = dt4.Rows[i]["altAlt_Identity_Proof_Value"].ToString();
                    TFM.Is_Informed_Person = dt4.Rows[i]["altIs_Informed_Person"].ToString();



                }
            }






            return View("~/Views/AddTestatorFamily/AddTestatorFamilyPageContent.cshtml", TFM);
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




        public String AltBindRelationDDL()
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



        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state where country_id = 101 order by statename asc   ";
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
            string query = "select distinct * from tbl_city where state_id = '" + response + "' order by city_name asc ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["id"].ToString() + " >" + dt.Rows[i]["city_name"].ToString() + "</option>";



                }




            }

            return data;
        }



        public ActionResult InsertTestatorFamilyFormData(TestatorFamilyModel TFM)
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


            //if (Session["tid"] != null)
            //{
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDtestatorfamily", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@First_Name", TFM.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", TFM.Last_Name);
                cmd.Parameters.AddWithValue("@Middle_Name", TFM.Middle_Name);
                DateTime dat = DateTime.ParseExact(TFM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@DOB", dat);
                cmd.Parameters.AddWithValue("@Marital_Status", "none");
                cmd.Parameters.AddWithValue("@Religion", "none");
                cmd.Parameters.AddWithValue("@Relationship", TFM.RelationshipTxt);
                cmd.Parameters.AddWithValue("@Address1", TFM.Address1);
                cmd.Parameters.AddWithValue("@Address2", TFM.Address2);
                cmd.Parameters.AddWithValue("@Address3", TFM.Address3);
                cmd.Parameters.AddWithValue("@City", TFM.City_txt);
                cmd.Parameters.AddWithValue("@State", TFM.State_txt);
                cmd.Parameters.AddWithValue("@Pin", TFM.Pin);
                cmd.Parameters.AddWithValue("@tId", TFM.ddltid);

            if (TFM.active != null && TFM.active != "")
            {
                cmd.Parameters.AddWithValue("@active", TFM.active);
            }
            else
            {
                TFM.active = "Active";
                cmd.Parameters.AddWithValue("@active", TFM.active);
            }
                




            cmd.Parameters.AddWithValue("@Identity_Proof", TFM.Identity_Proof);
                cmd.Parameters.AddWithValue("@Identity_Proof_Value", TFM.Identity_Proof_Value);
                cmd.Parameters.AddWithValue("@Alt_Identity_Proof", TFM.Alt_Identity_Proof);

            if (TFM.Alt_Identity_Proof_Value != null)
            {
                cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", TFM.Alt_Identity_Proof_Value);
            }
            else
            {
                TFM.Alt_Identity_Proof_Value = "None";
                cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", TFM.Alt_Identity_Proof_Value);
            }

               



            cmd.Parameters.AddWithValue("@Is_Informed_Person", "none");
                cmd.ExecuteNonQuery();
                con.Close();

                ViewBag.message = "Verified";


            con.Open();
            SqlCommand cmd2 = new SqlCommand("SP_CRUDBeneficiaryDetails", con);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@condition", "insert");
            cmd2.Parameters.AddWithValue("@First_Name ", TFM.First_Name);
            cmd2.Parameters.AddWithValue("@Last_Name", TFM.Last_Name);
            cmd2.Parameters.AddWithValue("@Middle_Name", TFM.Middle_Name);
            
            cmd2.Parameters.AddWithValue("@DOB", dat);
            cmd2.Parameters.AddWithValue("@Mobile", "None");
            cmd2.Parameters.AddWithValue("@Relationship", "none");
            cmd2.Parameters.AddWithValue("@Marital_Status", "none");
            cmd2.Parameters.AddWithValue("@Religion", "none");
            cmd2.Parameters.AddWithValue("@Identity_proof", TFM.Identity_Proof);
            cmd2.Parameters.AddWithValue("@Identity_proof_value", TFM.Identity_Proof_Value);

            if (TFM.Alt_Identity_Proof != null)
            {
                cmd2.Parameters.AddWithValue("@Alt_Identity_proof", TFM.Alt_Identity_Proof);
            }
            else
            {
                TFM.Alt_Identity_Proof = "None";
                cmd2.Parameters.AddWithValue("@Alt_Identity_proof", TFM.Alt_Identity_Proof);
            }

           

            if (TFM.Alt_Identity_Proof_Value != null)
            {
                cmd2.Parameters.AddWithValue("@Alt_Identity_proof_value", TFM.Alt_Identity_Proof_Value);
            }
            else
            {
                TFM.Alt_Identity_Proof_Value = "none";
                cmd2.Parameters.AddWithValue("@Alt_Identity_proof_value", TFM.Alt_Identity_Proof_Value);
            }

            

            cmd2.Parameters.AddWithValue("@Address1", TFM.Address1);
            if (TFM.Address2 != null || TFM.Address2 == "")
            {
                cmd2.Parameters.AddWithValue("@Address2", TFM.Address2);

            }
            else
            {
                TFM.Address2 = "None";
                cmd2.Parameters.AddWithValue("@Address2", TFM.Address2);
            }


            if (TFM.Address3 != null || TFM.Address3 == "")
            {
                cmd2.Parameters.AddWithValue("@Address3", TFM.Address3);

            }
            else
            {
                TFM.Address3 = "None";
                cmd2.Parameters.AddWithValue("@Address3", TFM.Address3);
            }


            cmd2.Parameters.AddWithValue("@City", TFM.City_txt);
            cmd2.Parameters.AddWithValue("@State", TFM.State_txt);
            cmd2.Parameters.AddWithValue("@Pin", TFM.Pin);
            cmd2.Parameters.AddWithValue("@aid", 0);
            cmd2.Parameters.AddWithValue("@tid", TFM.ddltid);
            cmd2.Parameters.AddWithValue("@beneficiary_type", "none");
            cmd2.ExecuteNonQuery();
            con.Close();



            con.Open();
            string QUERY = "select top 1 fId from testatorfamily order by fId desc";
            SqlDataAdapter DA = new SqlDataAdapter(QUERY,con);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            int tfid = 0;
            if (DT.Rows.Count > 0)
            {
                tfid = Convert.ToInt32(DT.Rows[0]["fId"]);
            }

            con.Close();






            // alternate testator family
            if (TFM.altchek == "true")
            {

                DateTime dat3 = DateTime.ParseExact(TFM.altDob, "dd-MM-yyyy", CultureInfo.InvariantCulture);


                if (TFM.altMarital_Status == null)
                {
                    TFM.altMarital_Status = "None";
                }


                if (TFM.altReligion == null)
                {
                    TFM.altReligion = "None";
                }


                if (TFM.altAddress2 == null)
                {
                    TFM.altAddress2 = "None";
                }

                if (TFM.altAddress3 == null)
                {
                    TFM.altAddress3 = "None";
                }


                if (TFM.altactive == null)
                {
                    TFM.altactive = "None";
                }


                if (TFM.altIdentity_Proof == null)
                {
                    TFM.altIdentity_Proof = "None";
                }




                if (TFM.altIdentity_Proof_Value == null)
                {
                    TFM.altIdentity_Proof_Value = "None";
                }



                if (TFM.altAlt_Identity_Proof == null)
                {
                    TFM.altAlt_Identity_Proof = "None";
                }




                if (TFM.altAlt_Identity_Proof_Value == null)
                {
                    TFM.altAlt_Identity_Proof_Value = "None";
                }


                if (TFM.altIs_Informed_Person == null)
                {
                    TFM.altIs_Informed_Person = "None";
                }




                con.Open();
                string query = "insert into alttestatorFamily (altFirst_Name , altLast_Name , altMiddle_Name , altDOB , altMarital_Status , altReligion , altRelationship , altAddress1 , altAddress2 , altAddress3 , altCity , altState , altPin  , altactive , altIdentity_Proof , altIdentity_Proof_Value , altAlt_Identity_Proof , altAlt_Identity_Proof_Value , altIs_Informed_Person , testatorfamilyid , alttId) values ('" + TFM.altFirst_Name+"' , '"+TFM.altLast_Name+"' , '"+TFM.Middle_Name+"' , '"+ dat3 + "' , '"+TFM.altMarital_Status+"' , '"+TFM.altReligion+"' , '"+TFM.RelationshipTxt+"' , '"+TFM.altAddress1+ "' , '" + TFM.altAddress2 + "' , '"+TFM.altAddress3+"' , '"+TFM.City_txt+"' , '"+TFM.altState_txt+"' , '"+TFM.altPin+"'  ,  '"+TFM.altactive+ "' , '"+TFM.altIdentity_Proof+ "' , '"+TFM.altIdentity_Proof_Value+"' , '"+TFM.altAlt_Identity_Proof + "' , '"+TFM.altAlt_Identity_Proof_Value + "' , '"+TFM.altIs_Informed_Person + "' , "+tfid+ " ,  "+TFM.ddltid+"  )  ";
                SqlCommand cmd3 = new SqlCommand(query,con);
                cmd3.ExecuteNonQuery();
                con.Close();



            }





            //end



            int bpid = 0;
            con.Open();
            string qcheck = "select max(bpId) as bpId from BeneficiaryDetails ";
            SqlDataAdapter dachk = new SqlDataAdapter(qcheck,con);
            DataTable dtchk = new DataTable();
            dachk.Fill(dtchk);
            if (dtchk.Rows.Count > 0)
            {
                bpid = Convert.ToInt32(dtchk.Rows[0]["bpId"]);
            }

            con.Close();


            con.Open();
            string qu = "update BeneficiaryDetails set fetchid = 'TF' where  bpId = "+ bpid + "";
            SqlCommand cmdu = new SqlCommand(qu,con);
            cmdu.ExecuteNonQuery();

            con.Close();



            //}
            //else
            //{
            //    ViewBag.message = "link";
            //}


            //con.Open();
            //string lastvisit = "insert into PageActive () values ";
            //SqlCommand cmdv = new SqlCommand(lastvisit,con);
            //cmdv.ExecuteNonQuery();
            //con.Close();

            

            ModelState.Clear();

            return RedirectToAction("AddTestatorFamilyIndex", "AddTestatorFamily" , new { success = "true" });
        }



        public string BindTestatorDDL()
        {

            if (Convert.ToInt32(Session["uuid"]) != 1)
            {
                string ck = "select type from users where uId ="+ Convert.ToInt32(Session["uuid"]) + "";
                SqlDataAdapter cda = new SqlDataAdapter(ck,con);
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
                    string query2 = "select * from testatorFamily where tId =  " + Convert.ToInt32(dt.Rows[0]["tId"]) + " ";
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




                            data = data + "<option value=" + dt.Rows[i]["tId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option> " +"~"+ dt.Rows[i]["tId"].ToString() + "~" + popup;



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


        public string gettestatoraddress()
        {
            string tid = Request["send"].ToString();

            con.Open();
            string query = "select Address1 , Address2 , Address3 from TestatorDetails where tId = "+ tid + " ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            if (dt.Rows.Count > 0)
            {
                data = dt.Rows[0]["Address1"].ToString() + "~" + dt.Rows[0]["Address2"].ToString() + "~" + dt.Rows[0]["Address3"].ToString();

            }


            return data;
        }






        public int CheckTestatorUsers(string value , string checkstatus)
        {




            int check = 0;
            if (checkstatus != "true")
            {
                
                int Response = Convert.ToInt32(Request["send"]);

                if (Request["send"] != "")
                {
                    // check for data exists or not for testato family
                    con.Open();
                    string query1 = "select a.fId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Marital_Status , a.Religion , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.tId , a.active , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Is_Informed_Person from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where b.tId =   " + value + " ";
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



        public ActionResult updatetestatorfamily(TestatorFamilyModel TFM)
        {



            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDtestatorfamily", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@fId", TFM.fId);
            cmd.Parameters.AddWithValue("@First_Name", TFM.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", TFM.Last_Name);
            cmd.Parameters.AddWithValue("@Middle_Name", TFM.Middle_Name);
            DateTime dat = DateTime.ParseExact(TFM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            cmd.Parameters.AddWithValue("@DOB", dat);
            cmd.Parameters.AddWithValue("@Marital_Status", "none");
            cmd.Parameters.AddWithValue("@Religion", "none");
            cmd.Parameters.AddWithValue("@Relationship", TFM.RelationshipTxt);
            cmd.Parameters.AddWithValue("@Address1", TFM.Address1);
            cmd.Parameters.AddWithValue("@Address2", TFM.Address2);
            cmd.Parameters.AddWithValue("@Address3", TFM.Address3);
            cmd.Parameters.AddWithValue("@City", TFM.City_txt);
            cmd.Parameters.AddWithValue("@State", TFM.State_txt);
            cmd.Parameters.AddWithValue("@tId", TFM.ddltid);
            cmd.Parameters.AddWithValue("@Pin", TFM.Pin);
            cmd.Parameters.AddWithValue("@active", "1");
            cmd.Parameters.AddWithValue("@Identity_Proof", TFM.Identity_Proof);
            cmd.Parameters.AddWithValue("@Identity_Proof_Value", TFM.Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", TFM.Alt_Identity_Proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", TFM.Alt_Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Is_Informed_Person", "none");
            
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.message = "Verified";
            ViewBag.disablefield = "true";

            return RedirectToAction("AddTestatorFamilyIndex", "AddTestatorFamily");
        }








        public String altBindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state where country_id = 101 order by statename asc   ";
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



        public string altOnChangeBindCity()
        {
            string response = Request["send"];
            con.Open();
            string query = "select distinct * from tbl_city where state_id = '" + response + "' order by city_name asc ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["id"].ToString() + " >" + dt.Rows[i]["city_name"].ToString() + "</option>";



                }




            }

            return data;
        }





    }
}