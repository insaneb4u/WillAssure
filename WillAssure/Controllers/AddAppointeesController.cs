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
using System.Collections;

namespace WillAssure.Controllers
{
    public class AddAppointeesController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddAppointees
        public ActionResult AddAppointeesIndex(string NestId)
        {
            if (TempData["Message"] != null)
            {
                if (TempData["Message"].ToString() == "true")
                {
                    ViewBag.Message = "Verified";
                }
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








            string query = "";

            AppointeesModel Am = new AppointeesModel();
            string distid = "";
            if (Session["distid"] != null)
            {
                if (Session["distid"].ToString() != "")
                {
                    distid = Session["distid"].ToString();

                    con.Open();

                    if (NestId != null)
                    {
                        query = "select * from Appointees where apId = " + NestId + " and  ExecutorType = 'Single'";
                    }
                    else
                    {
                        query = "select * from Appointees where tid = " + distid + "  and  ExecutorType = 'Single'";
                    }





                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    string data = "";

                    if (dt.Rows.Count > 0)
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ViewBag.disablefield = "true";
                            Am.apId = Convert.ToInt32(dt.Rows[i]["apId"]);
                            Am.Typetxt = dt.Rows[i]["Type"].ToString();
                            Am.subTypetxt = dt.Rows[i]["subType"].ToString();
                            Am.Firstname = dt.Rows[i]["Name"].ToString();
                            Am.middleName = dt.Rows[i]["middleName"].ToString();
                            Am.Surname = dt.Rows[i]["Surname"].ToString();
                            Am.Identity_Proof = dt.Rows[i]["Identity_Proof"].ToString();
                            Am.Identity_Proof_Value = dt.Rows[i]["Identity_Proof_Value"].ToString();
                            Am.Alt_Identity_Proof = dt.Rows[i]["Alt_Identity_Proof"].ToString();
                            Am.Alt_Identity_Proof_Value = dt.Rows[i]["Alt_Identity_Proof_Value"].ToString();
                            //Am.Dob = Convert.ToDateTime(dt.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
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
                }
            }
            else
            {
                //return  RedirectToAction("LoginPageIndex", "LoginPage");

                return View("/Views/AddAppointees/AddAppointeesPageContent.cshtml", Am);
            }







            //  for alternate appointees
            string query2 = "";
            con.Open();

            if (NestId != null)
            {
                query2 = "select * from alternate_Appointees where apId = " + NestId + "";

            }
            else
            {
                query2 = "select * from alternate_Appointees where apId = " + Am.apId + "";

            }






            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();


            if (dt2.Rows.Count > 0)
            {


                for (int i = 0; i < dt2.Rows.Count; i++)
                {

                    ViewBag.alternate = "true";
                    ViewBag.disablefield = "true";
                    Am.altapId = Convert.ToInt32(dt2.Rows[i]["id"]);
                    Am.altguardian = dt2.Rows[i]["altguardian"].ToString();
                    Am.altexecutor = dt2.Rows[i]["altexec"].ToString();


                    Am.altName = dt2.Rows[i]["Name"].ToString();
                    Am.altmiddleName = dt2.Rows[i]["middleName"].ToString();
                    Am.altSurname = dt2.Rows[i]["Surname"].ToString();
                    Am.altIdentity_Proof = dt2.Rows[i]["Identity_Proof"].ToString();
                    Am.altIdentity_Proof_Value = dt2.Rows[i]["Identity_Proof_Value"].ToString();
                    Am.altAlt_Identity_Proof = dt2.Rows[i]["Alt_Identity_Proof"].ToString();
                    Am.altAlt_Identity_Proof_Value = dt2.Rows[i]["Alt_Identity_Proof_Value"].ToString();

                    //Am.altDob = Convert.ToDateTime(dt2.Rows[i]["DOB"]).ToString("dd-MM-yyyy");

                    Am.altGender = dt2.Rows[i]["Gender"].ToString();
                    Am.altOccupation = dt2.Rows[i]["Occupation"].ToString();
                    Am.altRelationshipTxt = dt2.Rows[i]["Relationship"].ToString();
                    Am.altAddress1 = dt2.Rows[i]["Address1"].ToString();
                    Am.altAddress2 = dt2.Rows[i]["Address2"].ToString();
                    Am.altAddress3 = dt2.Rows[i]["Address3"].ToString();
                    Am.altcitytext = dt2.Rows[i]["City"].ToString();
                    Am.altstatetext = dt2.Rows[i]["State"].ToString();
                    Am.altPin = dt2.Rows[i]["Pin"].ToString();




                }
            }







            //end







            return View("/Views/AddAppointees/AddAppointeesPageContent.cshtml", Am);
        }


        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state where country_id = 101 order by statename asc  ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<select value=''>--Select State--</select>";

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
            string data = "<option value=''>--Select--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["id"].ToString() + " >" + dt.Rows[i]["city_name"].ToString() + "</option>";



                }




            }

            return data;
        }








        public string DYNAMICOnChangeBindCity()
        {
            string response = Request["send"];
            con.Open();
            string query = "select distinct * from tbl_city where state_id ='" + response + "' order by city_name asc ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["id"].ToString() + " >" + dt.Rows[i]["city_name"].ToString() + "</option>";



                }




            }

            return data;
        }






        public string ALTDYNAMICOnChangeBindCity()
        {
            string response = Request["send"];
            con.Open();
            string query = "select distinct * from tbl_city where state_id ='" + response + "' order by city_name asc ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select--</option>";

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


        public ActionResult InsertAppointeesFormData(FormCollection collection)
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



            int documentId = 0;
            int appid = 0;
            // latest appointees
            int apid = 0;

            ViewBag.disablefield = "true";
            // appointees 
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDAppointees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "insert");
            cmd.Parameters.AddWithValue("@documentId", "0");
            cmd.Parameters.AddWithValue("@Type", "Executor");

            if (collection["subTypetxt"] != null || collection["subTypetxt"] != "")
            {
                cmd.Parameters.AddWithValue("@subType", collection["subTypetxt"]);
            }
            else
            {
                cmd.Parameters.AddWithValue("@subType", "None");
            }






            cmd.Parameters.AddWithValue("@Name", collection["Firstname"]);
            cmd.Parameters.AddWithValue("@middleName", collection["middleName"]);
            cmd.Parameters.AddWithValue("@Surname", collection["Surname"]);
            cmd.Parameters.AddWithValue("@Identity_proof", collection["Identity_Proof"]);
            cmd.Parameters.AddWithValue("@Identity_proof_value", collection["Identity_Proof_Value"]);


            if (collection["Alt_Identity_Proof"] != null || collection["Alt_Identity_Proof"] != "")
            {
                cmd.Parameters.AddWithValue("@Alt_Identity_proof", collection["Alt_Identity_Proof"]);
            }
            else
            {

                cmd.Parameters.AddWithValue("@Alt_Identity_proof", "None");
            }


            if (collection["Alt_Identity_Proof_Value"] != null)
            {
                cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", collection["Alt_Identity_Proof_Value"]);
            }
            else
            {

                cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", "None");
            }









            //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            //cmd.Parameters.AddWithValue("@DOB", "None");
            cmd.Parameters.AddWithValue("@Gender", collection["Gender"]);
            cmd.Parameters.AddWithValue("@Occupation", "None");
            cmd.Parameters.AddWithValue("@Relationship", "None");
            cmd.Parameters.AddWithValue("@Address1", collection["Address1"]);
            if (collection["Address2"] != null || collection["Address2"] == "")
            {
                cmd.Parameters.AddWithValue("@Address2", collection["Address2"]);
            }
            else
            {
                collection["Address2"] = "None";
                cmd.Parameters.AddWithValue("@Address2", collection["Address2"]);
            }


            if (collection["Address3"] != null || collection["Address3"] == "")
            {
                cmd.Parameters.AddWithValue("@Address3", collection["Address3"]);
            }
            else
            {
                collection["Address3"] = "None";
                cmd.Parameters.AddWithValue("@Address3", collection["Address3"]);
            }


            string cityquery = "select city_name from tbl_city where id = " + collection["ddlcity"] + " ";
            SqlDataAdapter citda = new SqlDataAdapter(cityquery, con);
            DataTable citdata = new DataTable();
            citda.Fill(citdata);
            string cityname = "";
            if (citdata.Rows.Count > 0)
            {
                cityname = citdata.Rows[0]["city_name"].ToString();
            }
            cmd.Parameters.AddWithValue("@City", cityname);






            string statequery = "select statename from tbl_state where state_id = " + collection["ddlstate"] + " ";
            SqlDataAdapter stateda = new SqlDataAdapter(statequery, con);
            DataTable statedata = new DataTable();
            stateda.Fill(statedata);
            string statename = "";
            if (statedata.Rows.Count > 0)
            {
                statename = statedata.Rows[0]["statename"].ToString();
            }
            cmd.Parameters.AddWithValue("@State", statename);





            cmd.Parameters.AddWithValue("@Pin", collection["Pin"]);
            cmd.Parameters.AddWithValue("@tid", Convert.ToInt32(Session["distid"]));
            cmd.Parameters.AddWithValue("@ExecutorType", "Single");
            cmd.ExecuteNonQuery();
            con.Close();

            // end



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
            string qt = "update Appointees set doctype = 'Will' ,  WillType='"+Session["WillType"].ToString()+"'    where  apId = " + Convert.ToInt32(dt2.Rows[0]["apId"]) + "";
            SqlCommand cmdt = new SqlCommand(qt, con);
            cmdt.ExecuteNonQuery();
            con.Close();


            // update document status

            con.Open();
            string qte = "update Appointees set documentstatus = 'Incompleted' where apId =" + Convert.ToInt32(dt2.Rows[0]["apId"]) + " ";
            SqlCommand cmdte = new SqlCommand(qte, con);
            cmdte.ExecuteNonQuery();
            con.Close();


            //end





            // dropdown selection
            //int AppointmentofGuardian = 0;
            //if (AM.Typetxt == "Guardian")
            //{
            //    AppointmentofGuardian = 1;    //yes
            //}
            //else
            //{
            //    AppointmentofGuardian = 2;    // no
            //}

            //int Numberofexecutors = 0;
            //if (AM.subTypetxt == "Single")
            //{
            //    Numberofexecutors = 1;
            //}
            //if (AM.subTypetxt == "Many Joint")
            //{
            //    Numberofexecutors = 2;
            //}
            //if (AM.subTypetxt == "Many Independent")
            //{
            //    Numberofexecutors = 3;
            //}

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



            //con.Open();
            //string rulequery = "update documentRules set guardian = " + AppointmentofGuardian + " ,executors_category = " + Numberofexecutors + " where tid = " + AM.ddltid + " ";
            //SqlCommand cmd2 = new SqlCommand(rulequery, con);
            //cmd2.ExecuteNonQuery();
            //con.Close();
            //end











            if (collection["check"] == "true")
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



                cmdd.Parameters.AddWithValue("@Name", collection["altName"]);
                cmdd.Parameters.AddWithValue("@middleName", collection["altmiddleName"]);
                cmdd.Parameters.AddWithValue("@Surname", collection["altSurname"]);
                cmdd.Parameters.AddWithValue("@Identity_proof", collection["altIdentity_Proof"]);
                cmdd.Parameters.AddWithValue("@Identity_proof_value", collection["altIdentity_Proof_Value"]);

                if (collection["altAlt_Identity_Proof"] != null)
                {

                    cmdd.Parameters.AddWithValue("@Alt_Identity_proof", collection["altAlt_Identity_Proof"]);
                }
                else
                {
                    collection["altAlt_Identity_Proof"] = "None";
                    cmdd.Parameters.AddWithValue("@Alt_Identity_proof", collection["altAlt_Identity_Proof"]);
                }


                if (collection["altAlt_Identity_Proof_Value"] != null)
                {
                    cmdd.Parameters.AddWithValue("@Alt_Identity_proof_value", collection["altAlt_Identity_Proof_Value"]);
                }
                else
                {
                    collection["altAlt_Identity_Proof_Value"] = "None";
                    cmdd.Parameters.AddWithValue("@Alt_Identity_proof_value", collection["altAlt_Identity_Proof_Value"]);
                }


                //DateTime dat2 = DateTime.ParseExact(AM.altDob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                //cmdd.Parameters.AddWithValue("@DOB", dat2);
                cmdd.Parameters.AddWithValue("@Gender", collection["altGender"]);
                cmdd.Parameters.AddWithValue("@Occupation", "None");
                cmdd.Parameters.AddWithValue("@Relationship", "None");
                cmdd.Parameters.AddWithValue("@Address1", collection["altAddress1"]);
                if (collection["altAddress2"] != null || collection["altAddress2"] == "")
                {
                    cmdd.Parameters.AddWithValue("@Address2", collection["altAddress2"]);
                }
                else
                {
                    collection["altAddress2"] = "None";
                    cmdd.Parameters.AddWithValue("@Address2", collection["altAddress2"]);
                }


                if (collection["altAddress3"] != null || collection["altAddress3"] != "")
                {
                    cmdd.Parameters.AddWithValue("@Address3", collection["altAddress3"]);
                }
                else
                {
                    collection["altAddress3"] = "None";
                    cmdd.Parameters.AddWithValue("@Address3", collection["altAddress3"]);
                }


                string altcityquery = "select city_name from tbl_city where id = " + collection["altddlcity"] + " ";
                SqlDataAdapter altcitda = new SqlDataAdapter(altcityquery, con);
                DataTable altcitdata = new DataTable();
                altcitda.Fill(altcitdata);
                string altcityname = "";
                if (altcitdata.Rows.Count > 0)
                {
                    altcityname = altcitdata.Rows[0]["city_name"].ToString();
                }
                cmdd.Parameters.AddWithValue("@City", altcityname);



                string altstatequery = "select statename from tbl_state where state_id = " + collection["altddlstate"] + " ";
                SqlDataAdapter altstateda = new SqlDataAdapter(altstatequery, con);
                DataTable altstatedata = new DataTable();
                altstateda.Fill(altstatedata);
                string altstatename = "";
                if (altstatedata.Rows.Count > 0)
                {
                    altstatename = altstatedata.Rows[0]["statename"].ToString();
                }
                cmdd.Parameters.AddWithValue("@State", altstatename);






                cmdd.Parameters.AddWithValue("@Pin", collection["altPin"]);
                cmdd.Parameters.AddWithValue("@tid", Convert.ToInt32(Session["distid"]));
                //cmdd.Parameters.AddWithValue("@altguardian", AM.altguardian);
                //if (AM.altexecutor != null)
                //{
                //    cmdd.Parameters.AddWithValue("@altexecutor", AM.altexecutor);
                //}
                //else
                //{
                //    AM.altexecutor = "None";
                //    cmdd.Parameters.AddWithValue("@altexecutor", AM.altexecutor);
                //}


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
            //int AppointmentofaltGuardian = 0;
            //if (AM.altguardian == "Guardian")
            //{
            //    AppointmentofaltGuardian = 1;    //yes
            //}
            //else
            //{
            //    AppointmentofaltGuardian = 2;    // no
            //}

            //int altNumberofexecutors = 2;
            //if (AM.altexecutor == "Single")
            //{
            //    altNumberofexecutors = 1;
            //}
            //if (AM.altexecutor == "Many Joint")
            //{
            //    altNumberofexecutors = 1;
            //}
            //if (AM.altexecutor == "Many Independent")
            //{
            //    altNumberofexecutors = 1;
            //}

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



            //con.Open();
            //string rulequery2 = "update documentRules set AlternateGaurdian = " + AppointmentofaltGuardian + " , AlternateExecutors = " + altNumberofexecutors + " where tid = " + AM.ddltid + " ";
            //SqlCommand cmd6 = new SqlCommand(rulequery2, con);
            //cmd6.ExecuteNonQuery();
            //con.Close();
            //end


            // update document master with latest rule id

            //con.Open();
            //string rquery2 = "update documentMaster set wdId = " + getruleid2 + " where tId =  " + AM.ddltid + "  ";
            //SqlCommand rcmd2 = new SqlCommand(rquery2, con);
            //rcmd2.ExecuteNonQuery();
            //con.Close();




            //end





            // dynamic data

            
            if(collection["txtcounter"] == "true")
            {

                string querydy = "";
                string value = Convert.ToString(collection["inputfield"]);


                ArrayList result = new ArrayList(value.Split(','));
                string data = "";

                int getcount = 0;

                con.Open();
                for (int i = 0; i <= result.Count; i++)
                {
                    //getcount = count++;
                    try
                    {
                        if (result[i].ToString() == "")
                        {
                            continue;
                        }
                    }
                    catch (Exception)
                    {


                    }



                    //if (getcount == change)

                    // dynamic appointees
                    if (getcount == 8)
                    {



                        data = data.Remove(data.Length - 2, 2);
                        data = data + "'";
                        querydy = "insert into Appointees (Name,middleName,Surname,Gender,Pin,Address1,Identity_Proof,Identity_Proof_Value,tid,doctype,ExecutorType,Type,documentstatus) values (" + data + " , " + Convert.ToInt32(Session["distid"]) + " , '" + Session["doctype"].ToString() + "' , 'Multiple' , 'Executor' , 'Incompleted') ";
                        SqlCommand cmdy = new SqlCommand(querydy, con);
                        cmdy.ExecuteNonQuery();
                        getcount = 1;

                        data = "";
                        //  change = 10;
                        // count = 3;

                        try
                        {
                            data = "'" + result[i].ToString() + "',";
                        }
                        catch (Exception)
                        {


                        }






                        continue;
                    }
                    else
                    {

                        data += "'" + result[i].ToString() + "',";



                    }
                    getcount++;
                    //end







                    //end



                }
                con.Close();




                int dyapid = 0;
                con.Open();
                string idquery = "select top 1 * from Appointees order by apId desc";
                SqlDataAdapter idda2 = new SqlDataAdapter(idquery, con);
                DataTable iddt2 = new DataTable();
                idda2.Fill(iddt2);
                if (iddt2.Rows.Count > 0)
                {
                    dyapid = Convert.ToInt32(iddt2.Rows[0]["apId"]);

                }


                string cq = "select city_name from tbl_city where id = " + collection["inputcity"] + " ";
                SqlDataAdapter cda = new SqlDataAdapter(cq, con);
                DataTable cdt = new DataTable();
                cda.Fill(cdt);
                string dcityname = "";
                if (cdt.Rows.Count > 0)
                {
                    dcityname = cdt.Rows[0]["city_name"].ToString();
                }




                string sq = "select statename from tbl_state where state_id = " + collection["inputstate"] + " ";
                SqlDataAdapter sqda = new SqlDataAdapter(sq, con);
                DataTable sqdt = new DataTable();
                sqda.Fill(sqdt);
                string dstatename = "";
                if (sqdt.Rows.Count > 0)
                {
                    dstatename = sqdt.Rows[0]["statename"].ToString();
                }



                string updatelocation = "update Appointees set City = '" + cityname + "'  , State='" + statename + "' where apId = " + dyapid + "";
                SqlCommand uplcmd = new SqlCommand(updatelocation, con);
                uplcmd.ExecuteNonQuery();
                con.Close();


            }








            //end








            // dynamic alternate  data

            if (collection["checking"] == "true")
            {
                string querydy2 = "";
            string value2 = Convert.ToString(collection["altinputfield"]);


            ArrayList result2 = new ArrayList(value2.Split(','));
            string data2 = "";

            int getcount2 = 0;

            con.Open();
            for (int i = 0; i <= result2.Count; i++)
            {
                //getcount = count++;
                try
                {
                    if (result2[i].ToString() == "")
                    {
                        continue;
                    }
                }
                catch (Exception)
                {


                }



                //if (getcount == change)

                // dynamic alternate appointees

                if (getcount2 == 8)
                {



                    data2 = data2.Remove(data2.Length - 2, 2);
                    data2 = data2 + "'";
                    querydy2 = "insert into alternate_Appointees (Name,MiddleName,Surname,Gender,Pin,Address1,Identity_Proof,Identity_Proof_Value,tid,apId) values (" + data2 + " , " + Convert.ToInt32(Session["distid"]) + " , " + appid + " )";
                    SqlCommand cmdy2 = new SqlCommand(querydy2, con);
                    cmdy2.ExecuteNonQuery();
                    getcount2 = 1;

                    data2 = "";
                    //  change = 10;
                    // count = 3;

                    try
                    {
                        data2 = "'" + result2[i].ToString() + "',";
                    }
                    catch (Exception)
                    {


                    }






                    continue;
                }
                else
                {
                        try
                        {

                            data2 += "'" + result2[i].ToString() + "',";
                        }
                        catch (Exception)
                        {


                        }


                    }
                getcount2++;



                //end







                //end



            }
            con.Close();




            int dyapid2 = 0;
            con.Open();
            string idquery2 = "select top 1 * from alternate_Appointees order by apId desc";
            SqlDataAdapter idda22 = new SqlDataAdapter(idquery2, con);
            DataTable iddt22 = new DataTable();
            idda22.Fill(iddt22);
            if (iddt22.Rows.Count > 0)
            {
                dyapid2 = Convert.ToInt32(iddt22.Rows[0]["id"]);

            }


            string cq2 = "select city_name from tbl_city where id = " + collection["altinputcity"] + " ";
            SqlDataAdapter cda2 = new SqlDataAdapter(cq2, con);
            DataTable cdt2 = new DataTable();
            cda2.Fill(cdt2);
            string dcityname2 = "";
            if (cdt2.Rows.Count > 0)
            {
                dcityname2 = cdt2.Rows[0]["city_name"].ToString();
            }




            string sq2 = "select statename from tbl_state where state_id = " + collection["inputstate"] + " ";
            SqlDataAdapter sqda2 = new SqlDataAdapter(sq2, con);
            DataTable sqdt2 = new DataTable();
            sqda2.Fill(sqdt2);
            string dstatename2 = "";
            if (sqdt2.Rows.Count > 0)
            {
                dstatename2 = sqdt2.Rows[0]["statename"].ToString();
            }



            string updatelocation2 = "update alternate_Appointees set City = '" + dcityname2 + "'  , State='" + dstatename2 + "' where id = " + dyapid2 + "";
            SqlCommand uplcmd2 = new SqlCommand(updatelocation2, con);
            uplcmd2.ExecuteNonQuery();
            con.Close();





            //end



        }





            TempData["Message"] = "true";

            ModelState.Clear();

            return RedirectToAction("AddAppointeesIndex", "AddAppointees");
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




                            data = data + "<option value=" + dt.Rows[i]["tId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option> " + "~" + dt.Rows[i]["tId"].ToString() + "~" + popup;



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





        public ActionResult UpdateAppointees(AppointeesModel AM)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDAppointees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@apId", AM.apId);
            cmd.Parameters.AddWithValue("@documentId", AM.documentId);
            cmd.Parameters.AddWithValue("@Type", "Executor");
            cmd.Parameters.AddWithValue("@subType", AM.subTypetxt);
            cmd.Parameters.AddWithValue("@Name", AM.Firstname);
            cmd.Parameters.AddWithValue("@middleName", AM.middleName);
            cmd.Parameters.AddWithValue("@Surname", AM.Surname);
            cmd.Parameters.AddWithValue("@Identity_proof", AM.Identity_Proof);
            cmd.Parameters.AddWithValue("@Identity_proof_value", AM.Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof", AM.Alt_Identity_Proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.Alt_Identity_Proof_Value);
            //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);


            cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(AM.Dob));
            cmd.Parameters.AddWithValue("@Gender", AM.Gender);
            cmd.Parameters.AddWithValue("@Occupation", AM.Occupation);
            cmd.Parameters.AddWithValue("@Relationship", AM.RelationshipTxt);
            cmd.Parameters.AddWithValue("@Address1", AM.Address1);
            cmd.Parameters.AddWithValue("@Address2", AM.Address2);
            cmd.Parameters.AddWithValue("@Address3", AM.Address3);


            cmd.Parameters.AddWithValue("@City", AM.citytext);
            cmd.Parameters.AddWithValue("@State", AM.statetext);
            cmd.Parameters.AddWithValue("@Pin", AM.Pin);
            cmd.Parameters.AddWithValue("@tid", AM.ddltid);

            cmd.ExecuteNonQuery();
            con.Close();



            if (Convert.ToInt32(Session["upappointeesid"]) != 0)
            {
                AM.check = "true";
            }


            if (AM.check == "true")
            {
                con.Open();
                SqlCommand cmdd = new SqlCommand("SP_CRUDAlternateAppointees", con);
                cmdd.CommandType = CommandType.StoredProcedure;
                cmdd.Parameters.AddWithValue("@condition", "update");
                cmdd.Parameters.AddWithValue("@id", AM.altapId);
                cmdd.Parameters.AddWithValue("@apId", AM.apId);


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



                //DateTime dat2 = DateTime.ParseExact(AM.altDob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmdd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(AM.altDob).ToString("dd-MM-yyyy"));
                cmdd.Parameters.AddWithValue("@Gender", AM.altGender);
                cmdd.Parameters.AddWithValue("@Occupation", AM.altOccupation);
                cmdd.Parameters.AddWithValue("@Relationship", AM.altRelationshipTxt);
                cmdd.Parameters.AddWithValue("@Address1", AM.altAddress1);
                cmdd.Parameters.AddWithValue("@Address2", AM.altAddress2);
                cmdd.Parameters.AddWithValue("@Address3", AM.altAddress3);
                cmdd.Parameters.AddWithValue("@City", AM.altcitytext);
                cmdd.Parameters.AddWithValue("@State", AM.altstatetext);
                cmdd.Parameters.AddWithValue("@Pin", AM.altPin);
                cmdd.Parameters.AddWithValue("@tid", AM.ddltid);
                cmdd.ExecuteNonQuery();
                con.Close();
            }






            ViewBag.Message = "Verified";
            return RedirectToAction("AddAppointeesIndex", "AddAppointees");



        }


        public string DynamicControl()
        {
            string structure = "";

            int response = Convert.ToInt32(Request["send"]);




            con.Open();
            string query = "select distinct * from tbl_state where country_id = 101 order by statename asc  ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select State--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int j = 0; j < dt.Rows.Count; j++)
                {




                    data = data + "<option value=" + dt.Rows[j]["state_id"].ToString() + " >" + dt.Rows[j]["statename"].ToString() + "</option>";



                }




            }







            int count = 2;
            int i = 0;
            for (int j = 0; j < response - 1; j++)
            {
                i = count++;

                structure = structure + "<div id='executorform' style='border:2px solid #8f2b2b; border-radius:18px; padding:25px;'>" +
                    "<center>Executor : " + i + "</center>" +

     "<div class='row'>" +
     "&nbsp;&nbsp;&nbsp;&nbsp" +
     "<div class='col-sm-1'></div>" +


     "<div class='form-group' style='line-height:42px'>" +

     "<div class='form-group'>" +


     "</div>" +

     "<input type = 'text' style='width:245px; display:none;' id='txtnumber" + i + "' class='form-control' placeholder='Enter Number Of Executor You Want' name='name' value=''>" +
     "</div>" +

     "</div>" +

     "<div class='row'>" +

     "<div class='col-sm-1'></div>" +
     "<div class='col-sm-2'>" +
     "<label for='input-1' style='white-space:nowrap'><i class='fa fa-user-circle-o' aria-hidden='true'></i>Personal Details</label>" +
     "</div>" +

     "<div class='col-sm-3' style='padding-bottom:15px;'>" +
     "<div class='form-group'>" +
     "<label for='input-1'>Type</label>" +
     "<br>" +
     "<label class='checkbox-inline'>" +
     "<input type = 'checkbox' value='Individual' class='radio validate[required] typeonedd' id='typecheckone"+i+"' onchange='dydtypeone(this.value,this.id)' name='radio" + i + "' checked>Individual</label>" +
     "<label class='checkbox-inline'>" +
     "<input type = 'checkbox' value='Company' class='radio validate[required] typetwodd' id='typechecktwo"+i+"' onchange='dydtypetwo(this.value,this.id)' name='radio" + i + "'>Company</label>" +
     "</div>" +
     "<input type = 'text' style='width:245px; display:none;' id='txtnumber" + i + "' class='form-control' placeholder='Enter Number Of Executor You Want' name='name' value=''>" +
     "</div>" +
          "<div class='col-sm-2' id='compone" + i + "' style='display:none'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Company</label>" +
                "<input autocomplete = 'off' class='form-control input-shadow validate[required]  text-input' id='companyname" + i + "' name='inputfield' placeholder='Company ' type='text' value=''>" +
            "</div>" +
        "</div>" +

        "<div class='col-sm-3' id='comptwo" + i + "' style='display:none'>" +
            "<div class='form-group'>" +
                "<label for='input-1' style='white-space:nowrap;'>Registration No</label>" +
                "<input autocomplete = 'off' class='form-control input-shadow validate[required]  text-input' id='registrationno" + i + "' name='inputfield' placeholder='Registration No' type='text' value=''>" +
            "</div>" +
        "</div>" +
     "<div class='col-sm-3' id='Firsttxthide" + i+"'>" +
     "<div class='form-group'>" +
     "<label for='input-1'>First Name</label>" +
     "<input autocomplete = 'off' class='form-control input-shadow required validate[required]' id='txtname" + i + "' name='inputfield' placeholder='Enter Name' type='text' value='' >" +
     "</div>" +
     "</div>" +

     "<div class='col-sm-3' id='Middletxthide" + i + "'>" +
     "<div class='form-group'>" +
     "<label for='input-1'>Middle Name</label>" +
     "<input autocomplete = 'off' class='form-control input-shadow validate[required] text-input' id='txtmiddlename" + i + "' name='inputfield' placeholder='Enter Middle Name' type='text' value='' >" +
     "</div>" +
     "</div>" +
        "<div class='col-sm-3'></div>" +
        "<div class='col-sm-2' id='Lasttxthide" + i + "'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Last Name</label>" +
                "<input autocomplete = 'off' class='form-control input-shadow validate[required] text-input' id='txtsurname" + i + "' name='inputfield' placeholder='Surname' type='text' value='' >" +
            "</div>" +
        "</div>" +

        "<div class='col-sm-2' id='Gendertxthide" + i + "'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Gender</label>" +
                "<select class='form-control input-shadow  validate[required]' id='Gender" + i + "' name='inputfield' >" +
                    "<option value =''>Select</option>" +
                    "<option value='Male'>Male</option>" +
                    "<option value='Female'>Female</option>" +
                    "<option value='Transgender'>Transgender</option>" +
                "</select>" +
            "</div>" +
        "</div>" +

   

    "</div>" +

    "<hr>" +

    "<div class='row'>" +
        "<div class='col-sm-1'>" + "</div>" +
        "<div class='col-sm-2'>" +
            "<label for='input-1'>" + "<i class='fa fa-map-marker' aria-hidden='true'></i>Contact Details</label>" +
        "</div>" +
        "<div class='col-sm-3'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>State</label>" +
                "<select id ='ddlstate" + i + "'  onchange='dynamicstate(this.value,this.id)' name='inputstate' class='form-control input-shadow validate[required] stateddl' >" +
                    data +
                "</select>" +
                "<input data-val= 'true' data-val-number= 'The field stateid must be a number.' data-val-required= 'The stateid field is required.' id='stateid' name= 'stateid' type= 'hidden' value= '0' >" +
          

                "</div>" +

            "</div>" +


            "<div class='col-sm-3'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>City</label>" +
                "<select id='ddlcity" + i + "' class='form-control input-shadow validate[required] cityddl'  name='inputcity' >" +
                    "<option value=''>--Select City--</option>" +
                "</select>" +

             
            "</div>" +
        "</div>" +

        "<div class='col-sm-3'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Pin</label>" +
                "<input autocomplete = 'off' class='form-control input-shadow validate[required,custom[PinCode]]  text-input' id='txtpin" + i + "' name='inputfield' placeholder='Enter Pin' type='text' value='' >" +
            "</div>" +
        "</div>" +
    "</div>" +

    "<div class='row'>" +
        "<div class='col-sm-3'>" + "</div>" +
        "<div class='col-sm-9'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Address 1</label>" +
                "<textarea autocomplete = 'off' class='form-control input-shadow  text-input validate[required]' cols='20' id='txtaddress1" + i + "' name='inputfield' placeholder='Enter Address1' rows='2' ></textarea>" +
            "</div>" +
        "</div>" +
        //"<div class='col-sm-3'>" + "</div>" +
        //"<div class='col-sm-9'>" +
        //    "<div class='form-group'>" +
        //        "<label for='input-1'>Address 2</label>" +
        //        "<textarea autocomplete = 'off' class='form-control input-shadow  text-input ' cols='20' id='txtaddress2" + i + "' name='inputfield' placeholder='Enter Address2' rows='2' ></textarea>" +
        //    "</div>" +
        //"</div>" +
        //"<div class='col-sm-3'>" + "</div>" +
        //"<div class='col-sm-9'>" +
        //    "<div class='form-group'>" +
        //        "<label for='input-1'>Address 3</label>" +
        //        "<textarea autocomplete = 'off' class='form-control input-shadow  text-input' cols='20' id='txtaddress3" + i + "' name='inputfield' placeholder='Enter Address3' rows='2' ></textarea>" +
        //    "</div>" +
        //"</div>" +
    "</div>" +

    "<div class='row'>" +
        "<div class='col-sm-1'>" + "</div>" +
        "<div class='col-sm-2'>" +
            "<label for='input-1'>" + "<i class='fa fa-id-card-o' aria-hidden='true'>" + "</i>Identity Proof</label>" +
        "</div>" +
    "<div class='col-sm-3'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Identity Proof</label>" +
                "<select class='form-control input-shadow validate[required]' id='firstproof" + i + "' name='inputfield' onchange='firstproofselection(this.options[this.selectedIndex].innerHTML,this.id)' >" +
                    "<option value=''>--Select Identity Proof--</option>" +
                    "<option value='Aadhaar Card'>Aadhaar Card</option>" +
                    "<option value='Passport' >Passport</option >" +
                    "<option value='Driving Licences'>Driving Licences</option>" +
                      "<option value='Pan Card'>Pan Card</option>" +
                 "</select>" +
            "</div>" +
        "</div>" +
        "<div class='col-sm-3'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Identity Proof Value</label>" +
                "<div id='firstappendtxt" + i + "' >" +
                    "<input autocomplete='off' class='form-control input-shadow validate[required] text-input' id='txtfirstproof" + i + "' name='inputfield' placeholder='Enter Identity Proof Number'  type='text' value='' >" +
                "</div>" +
            "</div>" +
        "</div>" +

        //"<div class='col-sm-3'>" +
        //    "<div class='form-group'>" +
        //        "<label for='input-1'>Alt Identity Proof</label>" +
        //        "<select class='form-control input-shadow' id='secondproof" + i + "' name='inputfield' onchange='secondproofselection(this.options[this.selectedIndex].innerHTML,this.id)' >" +
        //            "<option value ='' >--Select Identity Proof--</option>" +
        //            "<option value ='Aadhaar Card' >Aadhaar Card</option>" +
        //            "<option value ='Passport' >Passport</option>" +
        //            "<option value='Driving Licences'>Driving Licences</option>" +
        //            "<option value ='Pan Card'>Pan Card</option>" +
        //         "</select>" +
        //        "<input id = 'Alt_Identity_Proof' name= 'Alt_Identity_Proof_Value' type= 'hidden' value= 'None' >" +

        //     "</div>" +

        // "</div>" +

        // "<div class='col-sm-3'></div>" +
        //"<div class='col-sm-3'>" +
        //    "<div class='form-group'>" +
        //        "<label for='input-1'>Alt Identity Proof Value</label>" +
        //        "<div id='secondappendtxt" + i + "'>" +
        //        "<input autocomplete='off' class='form-control input-shadow  text-input' id='txtsecondproof" + i + "' name='inputfield' placeholder='Enter Identity Proof Value'  type='text' value=''>" + "</div>" +
        //    "</div>" +
        //"</div>" +
    "</div>" +

    "<hr style='border:1px solid black; border-color:lightgray'>" +

    


       "<br>" +
       "<center>"+
        "<div>"+
        "<label for='input-1' style='white-space:nowrap;'>Add Alternate Executor</label>"+
         "<br>"+
         "<label class='checkbox-inline'>"+
         "<input type='checkbox' value='Yes' class='f1radio validate[required] faltone'  id='dyradioone" + i + "' onchange='getdradio1(this.value,this.id)' name='fradio2'>Yes" +
         "</label>"+
         "&nbsp;&nbsp; <label class='checkbox-inline'>"+
         "<input type='checkbox' value='No' class='f2radio validate[required] falttwo'  id='dyradiotwo" + i + "' onchange='getdradio2(this.value,this.id)' name='fradio2'>No" +
         "</label>"+
         "</div>"+
         "</center>"+


    "<input type='hidden' name='checking' id='txtcheck" + i + "' >" +

     // alternate appointees





     "<div id='alternateform" +i+"' style='display:none;'  > " +


     "<div class='row'>" +
     "&nbsp;&nbsp;&nbsp;&nbsp" +
     "<div class='col-sm-1'></div>" +


     "<div class='form-group' style='line-height:42px'>" +

     "<div class='form-group'>" +


     "</div>" +

     "<input type = 'text' style='width:245px; display:none;' id='txtnumber" + i + "' class='form-control' placeholder='Enter Number Of Executor You Want' name='name' value=''>" +
     "</div>" +

     "</div>" +

     "<div class='row'>" +

     "<div class='col-sm-1'></div>" +
     "<div class='col-sm-2'>" +
     "<label for='input-1' style='white-space:nowrap'><i class='fa fa-user-circle-o' aria-hidden='true'></i>Personal Details</label>" +
     "</div>" +


     
     "<div class='col-sm-3' style='padding-bottom:15px;'>" +
     "<div class='form-group'>" +
     "<label for='input-1'>Type</label>" +
     "<br>" +
     "<label class='checkbox-inline'>" +
     "<input type = 'checkbox' value='Individual' class='radio validate[required] typeonedd' id='alttypecheckone" + i + "' onchange='altdydtypeone(this.value,this.id)' name='radio" + i + "' checked>Individual</label>" +
     "<label class='checkbox-inline'>" +
     "<input type = 'checkbox' value='Company' class='radio validate[required] typetwodd' id='alttypechecktwo" + i + "' onchange='altdydtypetwo(this.value,this.id)' name='radio" + i + "'>Company</label>" +
     "</div>" +
     "<input type = 'text' style='width:245px; display:none;' id='txtnumber" + i + "' class='form-control' placeholder='Enter Number Of Executor You Want' name='name' value=''>" +
     "</div>" +
        "<div class='col-sm-2' id='altcompone" + i + "' style='display:none'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Company</label>" +
                "<input autocomplete = 'off' class='form-control input-shadow validate[required]  text-input' id='altcompanyname" + i + "' name='altinputfield' placeholder='Company ' type='text' value=''>" +
            "</div>" +
        "</div>" +

        "<div class='col-sm-3' id='altcomptwo" + i + "' style='display:none'>" +
            "<div class='form-group'>" +
                "<label for='input-1' style='white-space:nowrap;'>Registration No</label>" +
                "<input autocomplete = 'off' class='form-control input-shadow validate[required]  text-input' id='altregistrationno" + i + "' name='altinputfield' placeholder='Registration No' type='text' value=''>" +
            "</div>" +
        "</div>" +
     "<div class='col-sm-3' id='altFirsttxthide" + i + "'>" +
     "<div class='form-group'>" +
     "<label for='input-1'>First Name</label>" +
     "<input autocomplete = 'off' class='form-control input-shadow required validate[required]' id='alttxtname" + i + "' name='altinputfield' placeholder='Enter Name' type='text' value='' >" +
     "</div>" +
     "</div>" +

     "<div class='col-sm-3' id='altMiddletxthide"+i+"'>" +
     "<div class='form-group'>" +
     "<label for='input-1'>Middle Name</label>" +
     "<input autocomplete = 'off' class='form-control input-shadow validate[required] text-input' id='alttxtmiddlename" + i + "' name='altinputfield' placeholder='Enter Middle Name' type='text' value='' >" +
     "</div>" +
     "</div>" +
     "<div class='col-sm-3'></div>" +
       "<div class='col-sm-2' id='altLasttxthide" + i + "'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Last Name</label>" +
                "<input autocomplete = 'off' class='form-control input-shadow validate[required] text-input' id='alttxtsurname" + i + "' name='altinputfield' placeholder='Surname' type='text' value='' >" +
            "</div>" +
        "</div>" +



        "<div class='col-sm-2' id='altGendertxthide" + i + "'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Gender</label>" +
                "<select class='form-control input-shadow  validate[required]' id='altGender" + i + "' name='altinputfield' >" +
                    "<option value =''>Select</option>" +
                    "<option value='Male'>Male</option>" +
                    "<option value='Female'>Female</option>" +
                    "<option value='Transgender'>Transgender</option>" +
                "</select>" +
            "</div>" +
        "</div>" +

     

    "</div>" +

    "<hr>" +

    "<div class='row'>" +
        "<div class='col-sm-1'>" + "</div>" +
        "<div class='col-sm-2'>" +
            "<label for='input-1'>" + "<i class='fa fa-map-marker' aria-hidden='true'></i>Contact Details</label>" +
        "</div>" +
        "<div class='col-sm-3'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>State</label>" +
                "<select id ='altddlstate" + i + "'  onchange='altdynamicstate(this.value,this.id)' class='form-control input-shadow validate[required] stateddl' name='altinputstate' >" +
                    data +
                "</select>" +
               

                "</div>" +

            "</div>" +


            "<div class='col-sm-3'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>City</label>" +
                "<select id='altddlcity" + i + "' class='form-control input-shadow validate[required] cityddl' name='altinputcity' >" +
                    "<option value=''>--Select City--</option>" +
                "</select>" +

                
            "</div>" +
        "</div>" +

        "<div class='col-sm-3'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Pin</label>" +
                "<input autocomplete = 'off' class='form-control input-shadow validate[required,custom[PinCode]]  text-input' id='alttxtpin" + i + "' name='altinputfield' placeholder='Enter Pin' type='text' value='' >" +
            "</div>" +
        "</div>" +
    "</div>" +

    "<div class='row'>" +
        "<div class='col-sm-3'>" + "</div>" +
        "<div class='col-sm-9'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Address 1</label>" +
                "<textarea autocomplete = 'off' class='form-control input-shadow  text-input validate[required]' cols='20' id='alttxtaddress1" + i + "' name='altinputfield' placeholder='Enter Address1' rows='2' ></textarea>" +
            "</div>" +
        "</div>" +
        //"<div class='col-sm-3'>" + "</div>" +
        //"<div class='col-sm-9'>" +
        //    "<div class='form-group'>" +
        //        "<label for='input-1'>Address 2</label>" +
        //        "<textarea autocomplete = 'off' class='form-control input-shadow  text-input ' cols='20' id='txtaddress2" + i + "' name='altinputfield' placeholder='Enter Address2' rows='2' ></textarea>" +
        //    "</div>" +
        //"</div>" +
        //"<div class='col-sm-3'>" + "</div>" +
        //"<div class='col-sm-9'>" +
        //    "<div class='form-group'>" +
        //        "<label for='input-1'>Address 3</label>" +
        //        "<textarea autocomplete = 'off' class='form-control input-shadow  text-input' cols='20' id='txtaddress3" + i + "' name='altinputfield' placeholder='Enter Address3' rows='2' ></textarea>" +
        //    "</div>" +
        //"</div>" +
    "</div>" +

    "<div class='row'>" +
        "<div class='col-sm-1'>" + "</div>" +
        "<div class='col-sm-2'>" +
            "<label for='input-1'>" + "<i class='fa fa-id-card-o' aria-hidden='true'>" + "</i>Identity Proof</label>" +
        "</div>" +
        "<div class='col-sm-3'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Identity Proof</label>" +
                "<select class='form-control input-shadow validate[required]' id='altfirstproof" + i + "' name='altaltinputfield' onchange='altfirstproofselection(this.options[this.selectedIndex].innerHTML,this.id)' >" +
                    "<option value=''>--Select Identity Proof--</option>" +
                    "<option value='Aadhaar Card'>Aadhaar Card</option>" +
                    "<option value='Passport' >Passport</option >" +
                    "<option value='Driving Licences'>Driving Licences</option>" +
                      "<option value='Pan Card'>Pan Card</option>" +
                 "</select>" +
            "</div>" +
        "</div>" +
        "<div class='col-sm-3'>" +
            "<div class='form-group'>" +
                "<label for='input-1'>Identity Proof Value</label>" +
                "<div id='altfirstappendtxt" + i + "' >" +
                    "<input autocomplete='off' class='form-control input-shadow validate[required] text-input' id='alttxtfirstproof" + i + "' name='altinputfield' placeholder='Enter Identity Proof Number'  type='text' value='' >" +
                "</div>" +
            "</div>" +
        "</div>" +

        //"<div class='col-sm-3'>" +
        //    "<div class='form-group'>" +
        //        "<label for='input-1'>Alt Identity Proof</label>" +
        //        "<select class='form-control input-shadow' id='altsecondproof" + i + "' name='altinputfield' onchange='altsecondproofselection(this.options[this.selectedIndex].innerHTML,this.id)' >" +
        //            "<option value ='' >--Select Identity Proof--</option>" +
        //            "<option value ='Aadhaar Card' >Aadhaar Card</option>" +
        //            "<option value ='Passport' >Passport</option>" +
        //            "<option value='Driving Licences'>Driving Licences</option>" +
        //            "<option value ='Pan Card'>Pan Card</option>" +
        //         "</select>" +
        //        "<input id = 'Alt_Identity_Proof' name= 'Alt_Identity_Proof_Value' type= 'hidden' value= 'None' >" +

        //     "</div>" +

        // "</div>" +

        // "<div class='col-sm-3'></div>" +
        //"<div class='col-sm-3'>" +
        //    "<div class='form-group'>" +
        //        "<label for='input-1'>Alt Identity Proof Value</label>" +
        //        "<div id='altsecondappendtxt" + i + "'>" +
        //        "<input autocomplete='off' class='form-control input-shadow  text-input' id='alttxtsecondproof" + i + "' name='altinputfield' placeholder='Enter Identity Proof Value'  type='text' value=''>" + "</div>" +
        //    "</div>" +
        //"</div>" +
    "</div>" +

    "</div>"+

                "</div>";

     



     


  

 









            }






            return structure;

        }




        public ActionResult InsertDynamicData(FormCollection collection)
        {
            string data = "";
            string query = "";
            string value = Convert.ToString(collection["txtinput"]);

            ArrayList result = new ArrayList(value.Split(','));

            int count = 0;
            int getcount = 0;
            int change = 9;
            con.Open();
            for (int i = 0; i <= result.Count; i++)
            {
                //getcount = count++;



                //if (getcount == change)
                if (getcount == 9)
                {



                    data = data.Remove(data.Length - 2, 2);
                    data = data + "'";
                    query = "insert into Appointees (Name,middleName,Surname,Gender,State,City,Pin,Address1,Identity_Proof_Value,tid,doctype,ExecutorType,Type) values (" + data + " , " + Convert.ToInt32(Session["distid"]) + " , '" + Session["doctype"].ToString() + "' , 'Multiple' , 'Executor') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    getcount = 1;

                    data = "";
                    //  change = 10;
                    // count = 3;

                    try
                    {
                        data = "'" + result[i].ToString() + "',";
                    }
                    catch (Exception)
                    {


                    }






                    continue;
                }
                else
                {

                    data += "'" + result[i].ToString() + "',";



                }
                getcount++;

            }
            con.Close();

            TempData["Message"] = "true";

            return RedirectToAction("AddAppointeesIndex", "AddAppointees");
        }





        public ActionResult InsertAlternateDynamicData(FormCollection collection)
        {
            string data = "";
            string query = "";
            string value = Convert.ToString(collection["alternateinput"]);

            ArrayList result = new ArrayList(value.Split(','));

            int count = 0;
            int getcount = 0;
            int change = 10;
            con.Open();
            for (int i = 0; i <= result.Count; i++)
            {
                getcount = count++;



                //if (getcount == change)
                if (getcount == change)
                {



                    data = data.Remove(data.Length - 2, 2);
                    data = data + "'";
                    query = "insert into alternate_Appointees (apId,Name,MiddleName,Surname,Gender,State,City,Pin,Address1,Identity_proof_value,tid,ExecutorType) values (" + data + " , " + Convert.ToInt32(Session["distid"]) + "  , 'Multiple') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    count = 1;

                    data = "";

                    //  change = 10;
                    // count = 3;

                    try
                    {
                        data += "'" + result[i].ToString() + "',";
                    }
                    catch (Exception)
                    {


                    }






                    continue;
                }
                else
                {

                    try
                    {
                        data += "'" + result[i].ToString() + "',";
                    }
                    catch (Exception)
                    {


                    }




                }


            }
            con.Close();


            TempData["Message"] = "true";
            return RedirectToAction("AddAppointeesIndex", "AddAppointees");
        }




        public string BindNumberOfExecutor()
        {
            string structure = "<option value=''>--Select--</option>";

            con.Open();
            string getquery4 = "select apId  from appointees where ExecutorType='Multiple' and tid = 1";
            SqlDataAdapter da5 = new SqlDataAdapter(getquery4, con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            int count = 1;
            int getcount = 0;
            if (dt5.Rows.Count > 0)
            {


                for (int i = 0; i <= dt5.Rows.Count - 1; i++)
                {
                    getcount = count++;


                    try
                    {
                        structure = structure + "<option value=" + getcount + ">" + getcount + "</option>";
                    }
                    catch (Exception)
                    {


                    }




                }

            }

            con.Close();




            return structure;
        }










    }
}