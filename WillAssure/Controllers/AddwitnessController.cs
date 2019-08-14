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
    public class AddwitnessController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: Addwitness
        static int btncount = 0;
        public ActionResult AddwitnessIndex(string NestId,string send)
        {

            if (TempData["Message"] != null)
            {
                if (TempData["Message"].ToString() == "true")
                {
                    ViewBag.Message = "Verified";
                }
            }





            if (Convert.ToInt32(send) == 2 || Convert.ToInt32(send) >= 2)
            {
                ViewBag.skip = "true";
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
                            query = "select * from Appointees where apId = " + NestId + " and  Type = 'Witness'";
                        }
                        else
                        {


                            if (Session["doctype"] != null)
                            {

                                if (Session["doctype"].ToString() == "Will")
                                {
                                    query = "select top 2 * from Appointees where tid = " + distid + "  and  Type = 'Witness' and doctype='Will' and WitnessType not in ('third')  order by apId desc  ";
                                }

                                if (Session["doctype"].ToString() == "POA")
                                {
                                    query = "select top 2 * from Appointees where tid = " + distid + "  and  Type = 'Witness' and doctype='POA' and WitnessType not in ('third')  order by apId desc ";
                                }


                                if (Session["doctype"].ToString() == "GiftDeeds")
                                {
                                    query = "select top 2 * from Appointees where tid = " + distid + "  and  Type = 'Witness' and doctype='Giftdeeds' and WitnessType not in ('third') order by apId desc ";
                                }





                            }
                            else
                            {
                                return RedirectToAction("LoginPageIndex", "LoginPage");
                            }






                        }





                        SqlDataAdapter da = new SqlDataAdapter(query, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        con.Close();
                        string data = "";
                        int count = 0;
                        if (dt.Rows.Count > 0)
                        {


                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                count++;
                                ViewBag.disablefield = "true";


                                if (count == 1)
                                {
                                    Am.wapId = Convert.ToInt32(dt.Rows[i]["apId"]);
                                    Am.wTypetxt = dt.Rows[i]["Type"].ToString();
                                    Am.wsubTypetxt = dt.Rows[i]["subType"].ToString();
                                    Am.wFirstname = dt.Rows[i]["Name"].ToString();
                                    Am.wmiddleName = dt.Rows[i]["middleName"].ToString();
                                    Am.wSurname = dt.Rows[i]["Surname"].ToString();
                                    Am.Identity_Proof_txt2 = dt.Rows[i]["Identity_Proof"].ToString();
                                    Am.wIdentity_Proof_Value = dt.Rows[i]["Identity_Proof_Value"].ToString();
                                    Am.wAlt_Identity_Proof = dt.Rows[i]["Alt_Identity_Proof"].ToString();
                                    Am.wAlt_Identity_Proof_Value = dt.Rows[i]["Alt_Identity_Proof_Value"].ToString();
                                    //Am.Dob = Convert.ToDateTime(dt.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
                                    Am.wGender = dt.Rows[i]["Gender"].ToString();
                                    Am.wOccupation = dt.Rows[i]["Occupation"].ToString();
                                    Am.wRelationshipTxt = dt.Rows[i]["Relationship"].ToString();
                                    Am.wAddress1 = dt.Rows[i]["Address1"].ToString();
                                    Am.wAddress2 = dt.Rows[i]["Address2"].ToString();
                                    Am.wAddress3 = dt.Rows[i]["Address3"].ToString();
                                    Am.wcitytext = dt.Rows[i]["City"].ToString();
                                    Am.wstatetext = dt.Rows[i]["State"].ToString();
                                    Am.wPin = dt.Rows[i]["Pin"].ToString();
                                    Am.country_txt = dt.Rows[i]["Country"].ToString();
                            }
                                else
                                {
                                    Am.apId = Convert.ToInt32(dt.Rows[i]["apId"]);
                                    Am.Typetxt = dt.Rows[i]["Type"].ToString();
                                    Am.subTypetxt = dt.Rows[i]["subType"].ToString();
                                    Am.Firstname = dt.Rows[i]["Name"].ToString();
                                    Am.middleName = dt.Rows[i]["middleName"].ToString();
                                    Am.Surname = dt.Rows[i]["Surname"].ToString();
                                    Am.Identity_Proof_txt1 = dt.Rows[i]["Identity_Proof"].ToString();
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
                                    Am.altcountry_txt = dt.Rows[i]["Country"].ToString();
                            }







                            }
                        }
                    }
                }
                else
                {
                    return RedirectToAction("LoginPageIndex", "LoginPage");


                }














            //////////////////////////////////////////////////////////  witness 3
            ///


            string querye = "";


            if (Session["doctype"] != null)
            {

                if (Session["doctype"].ToString() == "Will")
                {
                    querye = "select top 2 * from Appointees where tid = " + distid + "  and  Type = 'Witness' and doctype='Will' and WitnessType='Third'  order by apId desc  ";
                }

                if (Session["doctype"].ToString() == "POA")
                {
                    querye = "select top 2 * from Appointees where tid = " + distid + "  and  Type = 'Witness' and doctype='POA' and WitnessType='Third'  order by apId desc ";
                }


                if (Session["doctype"].ToString() == "GiftDeeds")
                {
                    querye = "select top 2 * from Appointees where tid = " + distid + "  and  Type = 'Witness' and doctype='Giftdeeds' and WitnessType='Third' order by apId desc ";
                }





            }
            else
            {
                return RedirectToAction("LoginPageIndex", "LoginPage");
            }

            SqlDataAdapter dae = new SqlDataAdapter(querye, con);
                    DataTable dte = new DataTable();
                    dae.Fill(dte);
                    con.Close();
                    string datae = "";
                    
                    if (dte.Rows.Count > 0)
                    {


                        for (int i = 0; i < dte.Rows.Count; i++)
                        {
                           
                            ViewBag.thirdwitnessdata = "true";


                            Am.weapId = Convert.ToInt32(dte.Rows[i]["apId"]);
                            Am.weTypetxt = dte.Rows[i]["Type"].ToString();
                            Am.wesubTypetxt = dte.Rows[i]["subType"].ToString();
                            Am.weFirstname = dte.Rows[i]["Name"].ToString();
                            Am.wemiddleName = dte.Rows[i]["middleName"].ToString();
                            Am.weSurname = dte.Rows[i]["Surname"].ToString();
                            Am.Identity_Proof_txt3 = dte.Rows[i]["Identity_Proof"].ToString();
                            Am.weIdentity_Proof_Value = dte.Rows[i]["Identity_Proof_Value"].ToString();
                            Am.weAlt_Identity_Proof = dte.Rows[i]["Alt_Identity_Proof"].ToString();
                            Am.weAlt_Identity_Proof_Value = dte.Rows[i]["Alt_Identity_Proof_Value"].ToString();
                            //Am.Dob = Convert.ToDateTime(dt.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
                            Am.weGender = dte.Rows[i]["Gender"].ToString();
                
                            Am.weRelationshipTxt = dte.Rows[i]["Relationship"].ToString();
                    Am.weAddress1 = dte.Rows[i]["Address1"].ToString();
                    Am.weAddress2 = dte.Rows[i]["Address2"].ToString();
                            Am.weAddress3 = dte.Rows[i]["Address3"].ToString();
                            Am.wecitytext = dte.Rows[i]["City"].ToString();
                            Am.westatetext = dte.Rows[i]["State"].ToString();
                            Am.wePin = dte.Rows[i]["Pin"].ToString();
                            Am.wecountrytext = dte.Rows[i]["Country"].ToString();





                        }

                    }



                
            








            return View("~/Views/Addwitness/AddWitnessPageContent.cshtml", Am);
        }


        public String BindCountryDDL()
        {

            con.Open();
            string query = "select distinct * from country_tbl order by CountryName asc  ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["CountryID"].ToString() + " >" + dt.Rows[i]["CountryName"].ToString() + "</option>";



                }




            }

            return data;

        }


        public String BindStateDDL()
        {
            string response = Request["send"].ToString();
            con.Open();
            string query = "select distinct * from tbl_state where country_id = " + response + " order by statename asc  ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<select value='0'>--Select State--</select>";

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




        public String altBindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state where country_id = 101 order by statename asc  ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<select value='0'>--Select State--</select>";

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



            AM.documentId = 0;
            int appid = 0;
            // latest appointees
            int apid = 0;


            if (Session["doctype"] != null)
            {
                if (Session["doctype"].ToString() == "Will")
                {
                    ViewBag.disablefield = "true";
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_CRUDAppointees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@condition", "insert");
                    cmd.Parameters.AddWithValue("@documentId", AM.documentId);
                    cmd.Parameters.AddWithValue("@Type", "Witness");

                    if (AM.subTypetxt != null || AM.subTypetxt != "")
                    {
                        cmd.Parameters.AddWithValue("@subType", AM.subTypetxt);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@subType", "None");
                    }






                    cmd.Parameters.AddWithValue("@Name", AM.Firstname);
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









                    //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    //cmd.Parameters.AddWithValue("@DOB", "None");
                    cmd.Parameters.AddWithValue("@Gender", AM.Gender);
                    cmd.Parameters.AddWithValue("@Occupation", "None");
                    cmd.Parameters.AddWithValue("@Relationship", "None");
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
                    cmd.Parameters.AddWithValue("@ExecutorType", "Single");
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

                    // update document status

                    con.Open();

                    string getcountryname = "select distinct top 1 CountryName from country_tbl where CountryID = " + AM.country_txt + "";
                    SqlDataAdapter dacou = new SqlDataAdapter(getcountryname,con);
                    DataTable dtcou = new DataTable();
                    dacou.Fill(dtcou);
                    string countryname = "";
                    if (dtcou.Rows.Count > 0)
                    {
                        countryname = dtcou.Rows[0]["CountryName"].ToString();
                    }

                    string qte = "update Appointees set Country='"+countryname+"'  , documentstatus = 'Incompleted' , WillType='"+Session["WillType"].ToString()+"' where apId =" + appid + " ";
                    SqlCommand cmdte = new SqlCommand(qte, con);
                    cmdte.ExecuteNonQuery();
                    con.Close();


                    //end


                    con.Open();
                    string qt = "update Appointees set doctype = 'Will'  , WitnessType = 'First'  where  apId = " + Convert.ToInt32(dt2.Rows[0]["apId"]) + "";
                    SqlCommand cmdt = new SqlCommand(qt, con);
                    cmdt.ExecuteNonQuery();
                    con.Close();






                    ////////////////////////////////////alternate witness //////////////////////////////////////////////////




                    con.Open();
                    SqlCommand cmdw = new SqlCommand("SP_CRUDAppointees", con);
                    cmdw.CommandType = CommandType.StoredProcedure;
                    cmdw.Parameters.AddWithValue("@condition", "insert");
                    cmdw.Parameters.AddWithValue("@documentId", AM.wdocumentId);
                    cmdw.Parameters.AddWithValue("@Type", "Witness");

                    if (AM.wsubTypetxt != null || AM.wsubTypetxt != "")
                    {
                        cmdw.Parameters.AddWithValue("@subType", AM.wsubTypetxt);
                    }
                    else
                    {
                        cmdw.Parameters.AddWithValue("@subType", "None");
                    }






                    cmdw.Parameters.AddWithValue("@Name", AM.wFirstname);
                    cmdw.Parameters.AddWithValue("@middleName", AM.wmiddleName);
                    cmdw.Parameters.AddWithValue("@Surname", AM.wSurname);
                    cmdw.Parameters.AddWithValue("@Identity_proof", AM.wIdentity_Proof);
                    cmdw.Parameters.AddWithValue("@Identity_proof_value", AM.wIdentity_Proof_Value);


                    if (AM.wAlt_Identity_Proof != null)
                    {
                        cmdw.Parameters.AddWithValue("@Alt_Identity_proof", AM.wAlt_Identity_Proof);
                    }
                    else
                    {
                        AM.wAlt_Identity_Proof = "None";
                        cmdw.Parameters.AddWithValue("@Alt_Identity_proof", AM.wAlt_Identity_Proof);
                    }


                    if (AM.wAlt_Identity_Proof_Value != null)
                    {
                        cmdw.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.wAlt_Identity_Proof_Value);
                    }
                    else
                    {
                        AM.wAlt_Identity_Proof_Value = "None";
                        cmdw.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.wAlt_Identity_Proof_Value);
                    }









                    //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    //cmd.Parameters.AddWithValue("@DOB", "None");
                    cmdw.Parameters.AddWithValue("@Gender", AM.wGender);
                    cmdw.Parameters.AddWithValue("@Occupation", "None");
                    cmdw.Parameters.AddWithValue("@Relationship", "None");
                    cmdw.Parameters.AddWithValue("@Address1", AM.wAddress1);
                    if (AM.wAddress2 != null || AM.wAddress2 == "")
                    {
                        cmdw.Parameters.AddWithValue("@Address2", AM.wAddress2);
                    }
                    else
                    {
                        AM.wAddress2 = "None";
                        cmdw.Parameters.AddWithValue("@Address2", AM.wAddress2);
                    }


                    if (AM.wAddress3 != null || AM.wAddress3 == "")
                    {
                        cmdw.Parameters.AddWithValue("@Address3", AM.wAddress3);
                    }
                    else
                    {
                        AM.wAddress3 = "None";
                        cmdw.Parameters.AddWithValue("@Address3", AM.wAddress3);
                    }


                    cmdw.Parameters.AddWithValue("@City", AM.wcitytext);
                    cmdw.Parameters.AddWithValue("@State", AM.wstatetext);
                    cmdw.Parameters.AddWithValue("@Pin", AM.wPin);
                    cmdw.Parameters.AddWithValue("@tid", AM.ddltid);
                    cmdw.Parameters.AddWithValue("@ExecutorType", "Single");
                    cmdw.ExecuteNonQuery();
                    con.Close();


                    int appid22 = 0;
                    con.Open();
                    string query22 = "select top 1 * from Appointees order by apId desc";
                    SqlDataAdapter da22= new SqlDataAdapter(query22, con);
                    DataTable dt22 = new DataTable();
                    da22.Fill(dt22);
                    if (dt22.Rows.Count > 0)
                    {
                        appid22 = Convert.ToInt32(dt22.Rows[0]["apId"]);
                        apid = 1; // for yes
                    }
                    else
                    {
                        apid = 2; //for no
                    }
                    con.Close();



                    //end

                    // update document status

                    con.Open();

                    string altgetcountryname = "select distinct top 1 CountryName from country_tbl where CountryID = " + AM.altcountry_txt + "";
                    SqlDataAdapter altdacou = new SqlDataAdapter(altgetcountryname, con);
                    DataTable altdtcou = new DataTable();
                    altdacou.Fill(altdtcou);
                    string altcountryname = "";
                    if (altdtcou.Rows.Count > 0)
                    {
                        altcountryname = altdtcou.Rows[0]["CountryName"].ToString();
                    }



                    string qte22 = "update Appointees set Country='" + altcountryname + "'  ,  documentstatus = 'Incompleted' , WillType='" + Session["WillType"].ToString() + "' where apId =" + appid22 + " ";
                    SqlCommand cmdte22 = new SqlCommand(qte22, con);
                    cmdte22.ExecuteNonQuery();
                    con.Close();


                    //end


                    con.Open();
                    string qt22 = "update Appointees set doctype = 'Will'   , WitnessType = 'Second'  where  apId = " + appid22 + "";
                    SqlCommand cmdt22 = new SqlCommand(qt22, con);
                    cmdt22.ExecuteNonQuery();
                    con.Close();









                    ////////////////////////////////////////end//////////////////////////////////////////////////////////////



                   


                    if (AM.checkwitness3 == "true")
                    {

                        ////////////////////////////////////alternate witness 3 //////////////////////////////////////////////////

                        con.Open();
                        SqlCommand cmdw3 = new SqlCommand("SP_CRUDAppointees", con);
                        cmdw3.CommandType = CommandType.StoredProcedure;
                        cmdw3.Parameters.AddWithValue("@condition", "insert");
                        cmdw3.Parameters.AddWithValue("@documentId", AM.wedocumentId);
                        cmdw3.Parameters.AddWithValue("@Type", "Witness");

                        if (AM.wsubTypetxt != null || AM.wsubTypetxt != "")
                        {
                            cmdw3.Parameters.AddWithValue("@subType", AM.wesubTypetxt);
                        }
                        else
                        {
                            cmdw3.Parameters.AddWithValue("@subType", "None");
                        }






                        cmdw3.Parameters.AddWithValue("@Name", AM.weFirstname);
                        cmdw3.Parameters.AddWithValue("@middleName", AM.wemiddleName);
                        cmdw3.Parameters.AddWithValue("@Surname", AM.weSurname);
                        cmdw3.Parameters.AddWithValue("@Identity_proof", AM.weIdentity_Proof);
                        cmdw3.Parameters.AddWithValue("@Identity_proof_value", AM.weIdentity_Proof_Value);


                        if (AM.wAlt_Identity_Proof != null)
                        {
                            cmdw3.Parameters.AddWithValue("@Alt_Identity_proof", AM.weAlt_Identity_Proof);
                        }
                        else
                        {
                            AM.wAlt_Identity_Proof = "None";
                            cmdw3.Parameters.AddWithValue("@Alt_Identity_proof", AM.weAlt_Identity_Proof);
                        }


                        if (AM.wAlt_Identity_Proof_Value != null)
                        {
                            cmdw3.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.weAlt_Identity_Proof_Value);
                        }
                        else
                        {
                            AM.wAlt_Identity_Proof_Value = "None";
                            cmdw3.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.weAlt_Identity_Proof_Value);
                        }









                        //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        //cmd.Parameters.AddWithValue("@DOB", "None");
                        cmdw3.Parameters.AddWithValue("@Gender", AM.weGender);
                        cmdw3.Parameters.AddWithValue("@Occupation", "None");
                        cmdw3.Parameters.AddWithValue("@Relationship", "None");
                        cmdw3.Parameters.AddWithValue("@Address1", AM.weAddress1);
                        if (AM.wAddress2 != null || AM.wAddress2 == "")
                        {
                            cmdw3.Parameters.AddWithValue("@Address2", AM.weAddress2);
                        }
                        else
                        {
                            AM.wAddress2 = "None";
                            cmdw3.Parameters.AddWithValue("@Address2", AM.weAddress2);
                        }


                        if (AM.wAddress3 != null || AM.wAddress3 == "")
                        {
                            cmdw3.Parameters.AddWithValue("@Address3", AM.weAddress3);
                        }
                        else
                        {
                            AM.wAddress3 = "None";
                            cmdw3.Parameters.AddWithValue("@Address3", AM.weAddress3);
                        }


                        cmdw3.Parameters.AddWithValue("@City", AM.wecitytext);
                        cmdw3.Parameters.AddWithValue("@State", AM.westatetext);
                        cmdw3.Parameters.AddWithValue("@Pin", AM.wePin);
                        cmdw3.Parameters.AddWithValue("@tid", AM.ddltid);
                        cmdw3.Parameters.AddWithValue("@ExecutorType", "Single");
                        cmdw3.ExecuteNonQuery();
                        con.Close();


                        int appid223 = 0;
                        con.Open();
                        string query223 = "select top 1 * from Appointees order by apId desc";
                        SqlDataAdapter da223 = new SqlDataAdapter(query223, con);
                        DataTable dt223 = new DataTable();
                        da223.Fill(dt223);
                        if (dt223.Rows.Count > 0)
                        {
                            appid223 = Convert.ToInt32(dt223.Rows[0]["apId"]);
                            apid = 1; // for yes
                        }
                        else
                        {
                            apid = 2; //for no
                        }
                        con.Close();



                        //end

                        // update document status

                        con.Open();

                        string altgetcountryname3 = "select distinct top 1 CountryName from country_tbl where CountryID = " + AM.wecountrytext + "";
                        SqlDataAdapter altdacou3 = new SqlDataAdapter(altgetcountryname3, con);
                        DataTable altdtcou3 = new DataTable();
                        altdacou3.Fill(altdtcou3);
                        string altcountryname3 = "";
                        if (altdtcou3.Rows.Count > 0)
                        {
                            altcountryname3 = altdtcou3.Rows[0]["CountryName"].ToString();
                        }

                        int thirdid = appid22 + 1;

                        string qte223 = "update Appointees set Country='" + altcountryname3 + "'  ,  documentstatus = 'Incompleted' , WillType='" + Session["WillType"].ToString() + "' where apId =" + thirdid + " ";
                        SqlCommand cmdte223 = new SqlCommand(qte223, con);
                        cmdte223.ExecuteNonQuery();
                        con.Close();


                        //end

                       

                        con.Open();
                        string qt223 = "update Appointees set doctype = 'Will' , WitnessType = 'Third'  where   apId = " + thirdid + "";
                        SqlCommand cmdt223 = new SqlCommand(qt223, con);
                        cmdt223.ExecuteNonQuery();
                        con.Close();









                        ////////////////////////////////////////end//////////////////////////////////////////////////////////////


                    }









                }
            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }






            if (Session["doctype"] != null)
            {
                if (Session["doctype"].ToString() == "POA")
            {
                ViewBag.disablefield = "true";
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDAppointees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@documentId", AM.documentId);
                cmd.Parameters.AddWithValue("@Type", "Witness");
                cmd.Parameters.AddWithValue("@subType", "None");
                cmd.Parameters.AddWithValue("@Name", AM.Firstname);
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









                //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                //cmd.Parameters.AddWithValue("@DOB", "None");
                cmd.Parameters.AddWithValue("@Gender", AM.Gender);
                cmd.Parameters.AddWithValue("@Occupation", "None");
                cmd.Parameters.AddWithValue("@Relationship", "None");
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
                cmd.Parameters.AddWithValue("@ExecutorType", "None");
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




                    string getcountryname = "select distinct top 1 CountryName from country_tbl where CountryID = " + AM.country_txt + "";
                    SqlDataAdapter dacou = new SqlDataAdapter(getcountryname, con);
                    DataTable dtcou = new DataTable();
                    dacou.Fill(dtcou);
                    string countryname = "";
                    if (dtcou.Rows.Count > 0)
                    {
                        countryname = dtcou.Rows[0]["CountryName"].ToString();
                    }




                    string qt = "update Appointees set  Country='" + countryname + "'  , doctype = 'POA'  , WitnessType = 'First' where  apId = " + apid + "";
                SqlCommand cmdt = new SqlCommand(qt, con);
                cmdt.ExecuteNonQuery();
                con.Close();







                    ////////////////////////////////////alternate witness //////////////////////////////////////////////////




                    con.Open();
                    SqlCommand cmdw = new SqlCommand("SP_CRUDAppointees", con);
                    cmdw.CommandType = CommandType.StoredProcedure;
                    cmdw.Parameters.AddWithValue("@condition", "insert");
                    cmdw.Parameters.AddWithValue("@documentId", AM.wdocumentId);
                    cmdw.Parameters.AddWithValue("@Type", "Witness");

                    if (AM.wsubTypetxt != null || AM.wsubTypetxt != "")
                    {
                        cmdw.Parameters.AddWithValue("@subType", AM.wsubTypetxt);
                    }
                    else
                    {
                        cmdw.Parameters.AddWithValue("@subType", "None");
                    }






                    cmdw.Parameters.AddWithValue("@Name", AM.wFirstname);
                    cmdw.Parameters.AddWithValue("@middleName", AM.wmiddleName);
                    cmdw.Parameters.AddWithValue("@Surname", AM.wSurname);
                    cmdw.Parameters.AddWithValue("@Identity_proof", AM.wIdentity_Proof);
                    cmdw.Parameters.AddWithValue("@Identity_proof_value", AM.wIdentity_Proof_Value);


                    if (AM.wAlt_Identity_Proof != null)
                    {
                        cmdw.Parameters.AddWithValue("@Alt_Identity_proof", AM.wAlt_Identity_Proof);
                    }
                    else
                    {
                        AM.wAlt_Identity_Proof = "None";
                        cmdw.Parameters.AddWithValue("@Alt_Identity_proof", AM.wAlt_Identity_Proof);
                    }


                    if (AM.wAlt_Identity_Proof_Value != null)
                    {
                        cmdw.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.wAlt_Identity_Proof_Value);
                    }
                    else
                    {
                        AM.wAlt_Identity_Proof_Value = "None";
                        cmdw.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.wAlt_Identity_Proof_Value);
                    }









                    //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    //cmd.Parameters.AddWithValue("@DOB", "None");
                    cmdw.Parameters.AddWithValue("@Gender", AM.wGender);
                    cmdw.Parameters.AddWithValue("@Occupation", "None");
                    cmdw.Parameters.AddWithValue("@Relationship", "None");
                    cmdw.Parameters.AddWithValue("@Address1", AM.wAddress1);
                    if (AM.wAddress2 != null || AM.wAddress2 == "")
                    {
                        cmdw.Parameters.AddWithValue("@Address2", AM.wAddress2);
                    }
                    else
                    {
                        AM.wAddress2 = "None";
                        cmdw.Parameters.AddWithValue("@Address2", AM.wAddress2);
                    }


                    if (AM.wAddress3 != null || AM.wAddress3 == "")
                    {
                        cmdw.Parameters.AddWithValue("@Address3", AM.wAddress3);
                    }
                    else
                    {
                        AM.wAddress3 = "None";
                        cmdw.Parameters.AddWithValue("@Address3", AM.wAddress3);
                    }


                    cmdw.Parameters.AddWithValue("@City", AM.wcitytext);
                    cmdw.Parameters.AddWithValue("@State", AM.wstatetext);
                    cmdw.Parameters.AddWithValue("@Pin", AM.wPin);
                    cmdw.Parameters.AddWithValue("@tid", AM.ddltid);
                    cmdw.Parameters.AddWithValue("@ExecutorType", "Single");
                    cmdw.ExecuteNonQuery();
                    con.Close();


                    int appid22 = 0;
                    con.Open();
                    string query22 = "select top 1 * from Appointees order by apId desc";
                    SqlDataAdapter da22 = new SqlDataAdapter(query22, con);
                    DataTable dt22 = new DataTable();
                    da22.Fill(dt22);
                    if (dt22.Rows.Count > 0)
                    {
                        appid22 = Convert.ToInt32(dt22.Rows[0]["apId"]);
                        apid = 1; // for yes
                    }
                    else
                    {
                        apid = 2; //for no
                    }
                    con.Close();



                    //end

                    // update document status

                    con.Open();



                    string altgetcountryname = "select distinct top 1 CountryName from country_tbl where CountryID = " + AM.altcountry_txt + "";
                    SqlDataAdapter altdacou = new SqlDataAdapter(altgetcountryname, con);
                    DataTable altdtcou = new DataTable();
                    altdacou.Fill(altdtcou);
                    string altcountryname = "";
                    if (altdtcou.Rows.Count > 0)
                    {
                        altcountryname = altdtcou.Rows[0]["CountryName"].ToString();
                    }




                    string qte22 = "update Appointees set Country='" + altcountryname + "'  , documentstatus = 'Incompleted' , WillType='" + Session["WillType"].ToString() + "'  , WitnessType = 'Second' where apId =" + appid22 + " ";
                    SqlCommand cmdte22 = new SqlCommand(qte22, con);
                    cmdte22.ExecuteNonQuery();
                    con.Close();


                    //end


                    con.Open();
                    string qt22 = "update Appointees set doctype = 'Will'  where  apId = " + Convert.ToInt32(dt22.Rows[0]["apId"]) + "";
                    SqlCommand cmdt22 = new SqlCommand(qt22, con);
                    cmdt.ExecuteNonQuery();
                    con.Close();









                    ////////////////////////////////////////end//////////////////////////////////////////////////////////////




                    if (AM.checkwitness3 == "true")
                    {

                        ////////////////////////////////////alternate witness 3 //////////////////////////////////////////////////

                        con.Open();
                        SqlCommand cmdw3 = new SqlCommand("SP_CRUDAppointees", con);
                        cmdw3.CommandType = CommandType.StoredProcedure;
                        cmdw3.Parameters.AddWithValue("@condition", "insert");
                        cmdw3.Parameters.AddWithValue("@documentId", AM.wedocumentId);
                        cmdw3.Parameters.AddWithValue("@Type", "Witness");

                        if (AM.wsubTypetxt != null || AM.wsubTypetxt != "")
                        {
                            cmdw3.Parameters.AddWithValue("@subType", AM.wesubTypetxt);
                        }
                        else
                        {
                            cmdw3.Parameters.AddWithValue("@subType", "None");
                        }






                        cmdw3.Parameters.AddWithValue("@Name", AM.weFirstname);
                        cmdw3.Parameters.AddWithValue("@middleName", AM.wemiddleName);
                        cmdw3.Parameters.AddWithValue("@Surname", AM.weSurname);
                        cmdw3.Parameters.AddWithValue("@Identity_proof", AM.weIdentity_Proof);
                        cmdw3.Parameters.AddWithValue("@Identity_proof_value", AM.weIdentity_Proof_Value);


                        if (AM.wAlt_Identity_Proof != null)
                        {
                            cmdw3.Parameters.AddWithValue("@Alt_Identity_proof", AM.weAlt_Identity_Proof);
                        }
                        else
                        {
                            AM.wAlt_Identity_Proof = "None";
                            cmdw3.Parameters.AddWithValue("@Alt_Identity_proof", AM.weAlt_Identity_Proof);
                        }


                        if (AM.wAlt_Identity_Proof_Value != null)
                        {
                            cmdw3.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.weAlt_Identity_Proof_Value);
                        }
                        else
                        {
                            AM.wAlt_Identity_Proof_Value = "None";
                            cmdw3.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.weAlt_Identity_Proof_Value);
                        }









                        //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        //cmd.Parameters.AddWithValue("@DOB", "None");
                        cmdw3.Parameters.AddWithValue("@Gender", AM.weGender);
                        cmdw3.Parameters.AddWithValue("@Occupation", "None");
                        cmdw3.Parameters.AddWithValue("@Relationship", "None");
                        cmdw3.Parameters.AddWithValue("@Address1", AM.weAddress1);
                        if (AM.wAddress2 != null || AM.wAddress2 == "")
                        {
                            cmdw3.Parameters.AddWithValue("@Address2", AM.weAddress2);
                        }
                        else
                        {
                            AM.wAddress2 = "None";
                            cmdw3.Parameters.AddWithValue("@Address2", AM.weAddress2);
                        }


                        if (AM.wAddress3 != null || AM.wAddress3 == "")
                        {
                            cmdw3.Parameters.AddWithValue("@Address3", AM.weAddress3);
                        }
                        else
                        {
                            AM.wAddress3 = "None";
                            cmdw3.Parameters.AddWithValue("@Address3", AM.weAddress3);
                        }


                        cmdw3.Parameters.AddWithValue("@City", AM.wecitytext);
                        cmdw3.Parameters.AddWithValue("@State", AM.westatetext);
                        cmdw3.Parameters.AddWithValue("@Pin", AM.wePin);
                        cmdw3.Parameters.AddWithValue("@tid", AM.ddltid);
                        cmdw3.Parameters.AddWithValue("@ExecutorType", "Single");
                        cmdw3.ExecuteNonQuery();
                        con.Close();


                        int appid223 = 0;
                        con.Open();
                        string query223 = "select top 1 * from Appointees order by apId desc";
                        SqlDataAdapter da223 = new SqlDataAdapter(query223, con);
                        DataTable dt223 = new DataTable();
                        da223.Fill(dt223);
                        if (dt223.Rows.Count > 0)
                        {
                            appid223 = Convert.ToInt32(dt223.Rows[0]["apId"]);
                            apid = 1; // for yes
                        }
                        else
                        {
                            apid = 2; //for no
                        }
                        con.Close();



                        //end

                        // update document status

                        con.Open();

                        string altgetcountryname3 = "select distinct top 1 CountryName from country_tbl where CountryID = " + AM.altcountry_txt + "";
                        SqlDataAdapter altdacou3 = new SqlDataAdapter(altgetcountryname3, con);
                        DataTable altdtcou3 = new DataTable();
                        altdacou3.Fill(altdtcou3);
                        string altcountryname3 = "";
                        if (altdtcou3.Rows.Count > 0)
                        {
                            altcountryname3 = altdtcou3.Rows[0]["CountryName"].ToString();
                        }



                        string qte223 = "update Appointees set Country='" + altcountryname + "'  ,  documentstatus = 'Incompleted' , WillType='" + Session["WillType"].ToString() + "'  , WitnessType = 'Third' where apId =" + appid22 + " ";
                        SqlCommand cmdte223 = new SqlCommand(qte223, con);
                        cmdte223.ExecuteNonQuery();
                        con.Close();


                        //end


                        con.Open();
                        string qt223 = "update Appointees set doctype = 'Will'  where  apId = " + appid22 + "";
                        SqlCommand cmdt223 = new SqlCommand(qt223, con);
                        cmdt223.ExecuteNonQuery();
                        con.Close();









                        ////////////////////////////////////////end//////////////////////////////////////////////////////////////


                    }



                }
            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

            if (Session["doctype"] != null)
            {
                if (Session["doctype"].ToString() == "Giftdeeds")
                {
                    ViewBag.disablefield = "true";
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_CRUDAppointees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@condition", "insert");
                    cmd.Parameters.AddWithValue("@documentId", AM.documentId);
                    cmd.Parameters.AddWithValue("@Type", "Witness");
                    cmd.Parameters.AddWithValue("@subType", AM.subTypetxt);
                    cmd.Parameters.AddWithValue("@Name", AM.Firstname);
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









                    //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    //cmd.Parameters.AddWithValue("@DOB", "None");
                    cmd.Parameters.AddWithValue("@Gender", AM.Gender);
                    cmd.Parameters.AddWithValue("@Occupation", "None");
                    cmd.Parameters.AddWithValue("@Relationship", "None");
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




                    string getcountryname = "select distinct top 1 CountryName from country_tbl where CountryID = " + AM.country_txt + "";
                    SqlDataAdapter dacou = new SqlDataAdapter(getcountryname, con);
                    DataTable dtcou = new DataTable();
                    dacou.Fill(dtcou);
                    string countryname = "";
                    if (dtcou.Rows.Count > 0)
                    {
                        countryname = dtcou.Rows[0]["CountryName"].ToString();
                    }




                    string qt = "update Appointees set Country='" + countryname + "'  , doctype = 'Giftdeeds' , WitnessType = 'First' where  apId = " + apid + "";
                    SqlCommand cmdt = new SqlCommand(qt, con);
                    cmdt.ExecuteNonQuery();
                    con.Close();






                    ////////////////////////////////////alternate witness //////////////////////////////////////////////////




                    con.Open();
                    SqlCommand cmdw = new SqlCommand("SP_CRUDAppointees", con);
                    cmdw.CommandType = CommandType.StoredProcedure;
                    cmdw.Parameters.AddWithValue("@condition", "insert");
                    cmdw.Parameters.AddWithValue("@documentId", AM.wdocumentId);
                    cmdw.Parameters.AddWithValue("@Type", "Witness");

                    if (AM.wsubTypetxt != null || AM.wsubTypetxt != "")
                    {
                        cmdw.Parameters.AddWithValue("@subType", AM.wsubTypetxt);
                    }
                    else
                    {
                        cmdw.Parameters.AddWithValue("@subType", "None");
                    }






                    cmdw.Parameters.AddWithValue("@Name", AM.wFirstname);
                    cmdw.Parameters.AddWithValue("@middleName", AM.wmiddleName);
                    cmdw.Parameters.AddWithValue("@Surname", AM.wSurname);
                    cmdw.Parameters.AddWithValue("@Identity_proof", AM.wIdentity_Proof);
                    cmdw.Parameters.AddWithValue("@Identity_proof_value", AM.wIdentity_Proof_Value);


                    if (AM.wAlt_Identity_Proof != null)
                    {
                        cmdw.Parameters.AddWithValue("@Alt_Identity_proof", AM.wAlt_Identity_Proof);
                    }
                    else
                    {
                        AM.wAlt_Identity_Proof = "None";
                        cmdw.Parameters.AddWithValue("@Alt_Identity_proof", AM.wAlt_Identity_Proof);
                    }


                    if (AM.wAlt_Identity_Proof_Value != null)
                    {
                        cmdw.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.wAlt_Identity_Proof_Value);
                    }
                    else
                    {
                        AM.wAlt_Identity_Proof_Value = "None";
                        cmdw.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.wAlt_Identity_Proof_Value);
                    }









                    //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    //cmd.Parameters.AddWithValue("@DOB", "None");
                    cmdw.Parameters.AddWithValue("@Gender", AM.wGender);
                    cmdw.Parameters.AddWithValue("@Occupation", "None");
                    cmdw.Parameters.AddWithValue("@Relationship", "None");
                    cmdw.Parameters.AddWithValue("@Address1", AM.wAddress1);
                    if (AM.wAddress2 != null || AM.wAddress2 == "")
                    {
                        cmdw.Parameters.AddWithValue("@Address2", AM.wAddress2);
                    }
                    else
                    {
                        AM.wAddress2 = "None";
                        cmdw.Parameters.AddWithValue("@Address2", AM.wAddress2);
                    }


                    if (AM.wAddress3 != null || AM.wAddress3 == "")
                    {
                        cmdw.Parameters.AddWithValue("@Address3", AM.wAddress3);
                    }
                    else
                    {
                        AM.wAddress3 = "None";
                        cmdw.Parameters.AddWithValue("@Address3", AM.wAddress3);
                    }


                    cmdw.Parameters.AddWithValue("@City", AM.wcitytext);
                    cmdw.Parameters.AddWithValue("@State", AM.wstatetext);
                    cmdw.Parameters.AddWithValue("@Pin", AM.wPin);
                    cmdw.Parameters.AddWithValue("@tid", AM.ddltid);
                    cmdw.Parameters.AddWithValue("@ExecutorType", "Single");
                    cmdw.ExecuteNonQuery();
                    con.Close();


                    int appid22 = 0;
                    con.Open();
                    string query22 = "select top 1 * from Appointees order by apId desc";
                    SqlDataAdapter da22 = new SqlDataAdapter(query22, con);
                    DataTable dt22 = new DataTable();
                    da22.Fill(dt22);
                    if (dt22.Rows.Count > 0)
                    {
                        appid22 = Convert.ToInt32(dt22.Rows[0]["apId"]);
                        apid = 1; // for yes
                    }
                    else
                    {
                        apid = 2; //for no
                    }
                    con.Close();



                    //end

                    // update document status

                    con.Open();


                    string altgetcountryname = "select distinct top 1 CountryName from country_tbl where CountryID = " + AM.altcountry_txt + "";
                    SqlDataAdapter altdacou = new SqlDataAdapter(altgetcountryname, con);
                    DataTable altdtcou = new DataTable();
                    altdacou.Fill(altdtcou);
                    string altcountryname = "";
                    if (altdtcou.Rows.Count > 0)
                    {
                        altcountryname = altdtcou.Rows[0]["CountryName"].ToString();
                    }




                    string qte22 = "update Appointees set Country='" + altcountryname + "'  , documentstatus = 'Incompleted' , WillType='" + Session["WillType"].ToString() + "'  , WitnessType = 'Second' where apId =" + appid22 + " ";
                    SqlCommand cmdte22 = new SqlCommand(qte22, con);
                    cmdte22.ExecuteNonQuery();
                    con.Close();


                    //end


                    con.Open();
                    string qt22 = "update Appointees set doctype = 'Will'  where  apId = " + Convert.ToInt32(dt22.Rows[0]["apId"]) + "";
                    SqlCommand cmdt22 = new SqlCommand(qt22, con);
                    cmdt.ExecuteNonQuery();
                    con.Close();









                    ////////////////////////////////////////end//////////////////////////////////////////////////////////////




                    if (AM.checkwitness3 == "true")
                    {

                        ////////////////////////////////////alternate witness 3 //////////////////////////////////////////////////

                        con.Open();
                        SqlCommand cmdw3 = new SqlCommand("SP_CRUDAppointees", con);
                        cmdw3.CommandType = CommandType.StoredProcedure;
                        cmdw3.Parameters.AddWithValue("@condition", "insert");
                        cmdw3.Parameters.AddWithValue("@documentId", AM.wedocumentId);
                        cmdw3.Parameters.AddWithValue("@Type", "Witness");

                        if (AM.wsubTypetxt != null || AM.wsubTypetxt != "")
                        {
                            cmdw3.Parameters.AddWithValue("@subType", AM.wesubTypetxt);
                        }
                        else
                        {
                            cmdw3.Parameters.AddWithValue("@subType", "None");
                        }






                        cmdw3.Parameters.AddWithValue("@Name", AM.weFirstname);
                        cmdw3.Parameters.AddWithValue("@middleName", AM.wemiddleName);
                        cmdw3.Parameters.AddWithValue("@Surname", AM.weSurname);
                        cmdw3.Parameters.AddWithValue("@Identity_proof", AM.weIdentity_Proof);
                        cmdw3.Parameters.AddWithValue("@Identity_proof_value", AM.weIdentity_Proof_Value);


                        if (AM.wAlt_Identity_Proof != null)
                        {
                            cmdw3.Parameters.AddWithValue("@Alt_Identity_proof", AM.weAlt_Identity_Proof);
                        }
                        else
                        {
                            AM.wAlt_Identity_Proof = "None";
                            cmdw3.Parameters.AddWithValue("@Alt_Identity_proof", AM.weAlt_Identity_Proof);
                        }


                        if (AM.wAlt_Identity_Proof_Value != null)
                        {
                            cmdw3.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.weAlt_Identity_Proof_Value);
                        }
                        else
                        {
                            AM.wAlt_Identity_Proof_Value = "None";
                            cmdw3.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.weAlt_Identity_Proof_Value);
                        }









                        //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        //cmd.Parameters.AddWithValue("@DOB", "None");
                        cmdw3.Parameters.AddWithValue("@Gender", AM.weGender);
                        cmdw3.Parameters.AddWithValue("@Occupation", "None");
                        cmdw3.Parameters.AddWithValue("@Relationship", "None");
                        cmdw3.Parameters.AddWithValue("@Address1", AM.weAddress1);
                        if (AM.wAddress2 != null || AM.wAddress2 == "")
                        {
                            cmdw3.Parameters.AddWithValue("@Address2", AM.weAddress2);
                        }
                        else
                        {
                            AM.wAddress2 = "None";
                            cmdw3.Parameters.AddWithValue("@Address2", AM.weAddress2);
                        }


                        if (AM.wAddress3 != null || AM.wAddress3 == "")
                        {
                            cmdw3.Parameters.AddWithValue("@Address3", AM.weAddress3);
                        }
                        else
                        {
                            AM.wAddress3 = "None";
                            cmdw3.Parameters.AddWithValue("@Address3", AM.weAddress3);
                        }


                        cmdw3.Parameters.AddWithValue("@City", AM.wecitytext);
                        cmdw3.Parameters.AddWithValue("@State", AM.westatetext);
                        cmdw3.Parameters.AddWithValue("@Pin", AM.wePin);
                        cmdw3.Parameters.AddWithValue("@tid", AM.ddltid);
                        cmdw3.Parameters.AddWithValue("@ExecutorType", "Single");
                        cmdw3.ExecuteNonQuery();
                        con.Close();


                        int appid223 = 0;
                        con.Open();
                        string query223 = "select top 1 * from Appointees order by apId desc";
                        SqlDataAdapter da223 = new SqlDataAdapter(query223, con);
                        DataTable dt223 = new DataTable();
                        da223.Fill(dt223);
                        if (dt223.Rows.Count > 0)
                        {
                            appid223 = Convert.ToInt32(dt223.Rows[0]["apId"]);
                            apid = 1; // for yes
                        }
                        else
                        {
                            apid = 2; //for no
                        }
                        con.Close();



                        //end

                        // update document status

                        con.Open();

                        string altgetcountryname3 = "select distinct top 1 CountryName from country_tbl where CountryID = " + AM.altcountry_txt + "";
                        SqlDataAdapter altdacou3 = new SqlDataAdapter(altgetcountryname3, con);
                        DataTable altdtcou3 = new DataTable();
                        altdacou3.Fill(altdtcou3);
                        string altcountryname3 = "";
                        if (altdtcou3.Rows.Count > 0)
                        {
                            altcountryname3 = altdtcou3.Rows[0]["CountryName"].ToString();
                        }



                        string qte223 = "update Appointees set Country='" + altcountryname + "'  ,  documentstatus = 'Incompleted' , WillType='" + Session["WillType"].ToString() + "'  , WitnessType = 'Third' where apId =" + appid22 + " ";
                        SqlCommand cmdte223 = new SqlCommand(qte223, con);
                        cmdte223.ExecuteNonQuery();
                        con.Close();


                        //end


                        con.Open();
                        string qt223 = "update Appointees set doctype = 'Will'  where  apId = " + appid22 + "";
                        SqlCommand cmdt223 = new SqlCommand(qt223, con);
                        cmdt223.ExecuteNonQuery();
                        con.Close();









                        ////////////////////////////////////////end//////////////////////////////////////////////////////////////


                    }





                }
            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

            TempData["Message"] = "true";

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
            string rquery2 = "update documentMaster set wdId = " + getruleid2 + " where tId =  " + AM.ddltid + "  ";
            SqlCommand rcmd2 = new SqlCommand(rquery2, con);
            rcmd2.ExecuteNonQuery();
            con.Close();




            //end





            

             int d= btncount++;

            int send = d;


            TempData["Message"] = "true";
            ModelState.Clear();

            return RedirectToAction("AddwitnessIndex", "Addwitness" , new { send = send });
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

            string w1identity = "";
            string w2identity = "";
            string w3identity = "";

            if (AM.Identity_Proof != null)
            {
                w1identity = AM.Identity_Proof;
            }
            else
            {
                w1identity = "None";
            }


            if (AM.wIdentity_Proof != null)
            {
                w2identity = AM.wIdentity_Proof;
            }
            else
            {
                w2identity = "None"; 
            }

            if (AM.weIdentity_Proof != null)
            {
                w3identity = AM.weIdentity_Proof;
            }
            else
            {
                w3identity = "None";
            }



         



            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDAppointees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@apId", AM.apId);
            cmd.Parameters.AddWithValue("@documentId", "0");
            cmd.Parameters.AddWithValue("@Type", "Witness");
            cmd.Parameters.AddWithValue("@subType", AM.wTypetxt);
            cmd.Parameters.AddWithValue("@Name", AM.Firstname);
            cmd.Parameters.AddWithValue("@middleName", AM.middleName);
            cmd.Parameters.AddWithValue("@Surname", AM.Surname);
            cmd.Parameters.AddWithValue("@Identity_proof", w1identity);
            cmd.Parameters.AddWithValue("@Identity_proof_value", AM.Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof", AM.Alt_Identity_Proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.Alt_Identity_Proof_Value);
            //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);


            cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(AM.Dob).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Gender", AM.Gender);
            cmd.Parameters.AddWithValue("@Occupation", "None");
            cmd.Parameters.AddWithValue("@Relationship", "None");
            cmd.Parameters.AddWithValue("@Address1", AM.Address1);
            cmd.Parameters.AddWithValue("@Address2", AM.Address2);
            cmd.Parameters.AddWithValue("@Address3", AM.Address3);
            cmd.Parameters.AddWithValue("@City", AM.citytext);
            cmd.Parameters.AddWithValue("@State", AM.statetext);
            cmd.Parameters.AddWithValue("@Pin", AM.Pin);
            cmd.Parameters.AddWithValue("@tid", AM.ddltid);
            cmd.Parameters.AddWithValue("@ExecutorType", "Single");
          

            cmd.ExecuteNonQuery();
            con.Close();




            con.Open();

            SqlCommand cmd2 = new SqlCommand("SP_CRUDAppointees", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@condition", "update");
            cmd2.Parameters.AddWithValue("@apId", AM.wapId);
            cmd2.Parameters.AddWithValue("@documentId", 0);
            cmd2.Parameters.AddWithValue("@Type", "Witness");
            cmd2.Parameters.AddWithValue("@subType", AM.wsubTypetxt);
            cmd2.Parameters.AddWithValue("@Name", AM.wFirstname);
            cmd2.Parameters.AddWithValue("@middleName", AM.wmiddleName);
            cmd2.Parameters.AddWithValue("@Surname", AM.wSurname);
            cmd2.Parameters.AddWithValue("@Identity_proof", w2identity);
            cmd2.Parameters.AddWithValue("@Identity_proof_value", AM.wIdentity_Proof_Value);
            cmd2.Parameters.AddWithValue("@Alt_Identity_proof", AM.wAlt_Identity_Proof);
            cmd2.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.wAlt_Identity_Proof_Value);
            //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);


            cmd2.Parameters.AddWithValue("@DOB", Convert.ToDateTime(AM.Dob).ToString("yyyy-MM-dd"));
            cmd2.Parameters.AddWithValue("@Gender", AM.wGender);
            cmd2.Parameters.AddWithValue("@Occupation", "None");
            cmd2.Parameters.AddWithValue("@Relationship", "None");
            cmd2.Parameters.AddWithValue("@Address1", AM.wAddress1);
            cmd2.Parameters.AddWithValue("@Address2", AM.wAddress2);
            cmd2.Parameters.AddWithValue("@Address3", AM.wAddress3);
            cmd2.Parameters.AddWithValue("@City", AM.wcitytext);
            cmd2.Parameters.AddWithValue("@State", AM.wstatetext);
            cmd2.Parameters.AddWithValue("@Pin", AM.wPin);
            cmd2.Parameters.AddWithValue("@tid", AM.ddltid);
            cmd2.Parameters.AddWithValue("@ExecutorType", "Single");

            cmd2.ExecuteNonQuery();

            con.Close();





            con.Open();

            SqlCommand cmd3 = new SqlCommand("SP_CRUDAppointees", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.AddWithValue("@condition", "update");
            cmd3.Parameters.AddWithValue("@apId", AM.weapId);
            cmd3.Parameters.AddWithValue("@documentId", 0);
            cmd3.Parameters.AddWithValue("@Type", "Witness");
            cmd3.Parameters.AddWithValue("@subType", AM.wesubTypetxt);
            cmd3.Parameters.AddWithValue("@Name", AM.weFirstname);
            cmd3.Parameters.AddWithValue("@middleName", AM.wemiddleName);
            cmd3.Parameters.AddWithValue("@Surname", AM.weSurname);
            cmd3.Parameters.AddWithValue("@Identity_proof", w3identity);
            cmd3.Parameters.AddWithValue("@Identity_proof_value", AM.weIdentity_Proof_Value);
            cmd3.Parameters.AddWithValue("@Alt_Identity_proof", AM.weAlt_Identity_Proof);
            cmd3.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.weAlt_Identity_Proof_Value);
            //DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);


            cmd3.Parameters.AddWithValue("@DOB", Convert.ToDateTime(AM.weDob).ToString("yyyy-MM-dd"));
            cmd3.Parameters.AddWithValue("@Gender", AM.weGender);
            cmd3.Parameters.AddWithValue("@Occupation", "None");
            cmd3.Parameters.AddWithValue("@Relationship", "None");
            cmd3.Parameters.AddWithValue("@Address1", AM.weAddress1);
            cmd3.Parameters.AddWithValue("@Address2", AM.weAddress2);
            cmd3.Parameters.AddWithValue("@Address3", AM.weAddress3);
            cmd3.Parameters.AddWithValue("@City", AM.wecitytext);
            cmd3.Parameters.AddWithValue("@State", AM.westatetext);
            cmd3.Parameters.AddWithValue("@Pin", AM.wePin);
            cmd3.Parameters.AddWithValue("@tid", AM.ddltid);
            cmd3.Parameters.AddWithValue("@ExecutorType", "Single");
   
            cmd3.ExecuteNonQuery();

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
            return RedirectToAction("AddwitnessIndex", "Addwitness");



        }






        public string Validateidentity()
        {
            string response = Request["send"].ToString();
            string msg = "";

            string testatorchk = "";
            string testatorfamilychk = "";
            string guardianchk = "";
            string benechk = "";
            string witchk = "";

            con.Open();


            string query = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int tid = 0;
            if (dt.Rows.Count > 0)
            {
                tid = Convert.ToInt32(dt.Rows[0]["tId"]);
            }




            string query2 = "select Identity_proof_Value , Alt_Identity_proof_value from TestatorDetails  where tId = " + tid + "  ";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {

                if (dt2.Rows[0]["Alt_Identity_proof_value"].ToString() == response || dt2.Rows[0]["Identity_proof_Value"].ToString() == response)
                {
                    testatorchk = "false";
                }
             

            }







            //////////////////////////////// check in testator family  ///////////////////////////////////////







            string query3 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where  b.uId = '" + Convert.ToInt32(Session["uuid"]) + "'";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);

            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt3.Rows[i]["Identity_proof_Value"].ToString() == response || dt3.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        testatorfamilychk = "false";
                    }
                 






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////


            //////////////////////////////// check in Appointees guardian  ///////////////////////////////////////





            string query4 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from Appointees a inner join TestatorDetails b on a.tId=b.tId where a.Type='Guardian' and b.uId = '" + Convert.ToInt32(Session["uuid"]) + "' ";
            SqlDataAdapter da4 = new SqlDataAdapter(query4, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);

            if (dt4.Rows.Count > 0)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    if (dt4.Rows[i]["Identity_proof_Value"].ToString() == response || dt4.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        guardianchk = "false";
                    }
                  






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////



            //////////////////////////////// check in beneficiary  ///////////////////////////////////////





            string query5 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId  where  b.uId = '" + Convert.ToInt32(Session["uuid"]) + "' ";
            SqlDataAdapter da5 = new SqlDataAdapter(query5, con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);

            if (dt5.Rows.Count > 0)
            {
                for (int i = 0; i < dt5.Rows.Count; i++)
                {
                    if (dt5.Rows[i]["Identity_proof_Value"].ToString() == response || dt5.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        benechk = "false";
                    }
                 






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////


            //////////////////////////////// check in Witness  ///////////////////////////////////////





            string query6 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from Appointees a inner join TestatorDetails b on a.tId=b.tId where  b.uId = " + Convert.ToInt32(Session["uuid"]) + "   and a.Type = 'Witness'";
            SqlDataAdapter da6 = new SqlDataAdapter(query6, con);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);

            if (dt6.Rows.Count > 0)
            {
                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                    if (dt6.Rows[i]["Identity_proof_Value"].ToString() == response || dt6.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        witchk = "false";
                    }
                 






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////








            con.Close();

            msg = testatorchk + "~" + testatorfamilychk + "~" + guardianchk + "~" + benechk + "~" + witchk;


            return msg;
        }





        public string altValidateidentity()
        {
            string response = Request["send"].ToString();
            string msg = "";

            string testatorchk = "";
            string testatorfamilychk = "";
            string guardianchk = "";
            string benechk = "";
            string witchk = "";

            con.Open();


            string query = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int tid = 0;
            if (dt.Rows.Count > 0)
            {
                tid = Convert.ToInt32(dt.Rows[0]["tId"]);
            }




            string query2 = "select Identity_proof_Value , Alt_Identity_proof_value from TestatorDetails  where tId = " + tid + "  ";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {

                if (dt2.Rows[0]["Alt_Identity_proof_value"].ToString() == response || dt2.Rows[0]["Identity_proof_Value"].ToString() == response)
                {
                    testatorchk = "false";
                }
              

            }







            //////////////////////////////// check in testator family  ///////////////////////////////////////







            string query3 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where  b.uId = '" + Convert.ToInt32(Session["uuid"]) + "'";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);

            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt3.Rows[i]["Identity_proof_Value"].ToString() == response || dt3.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        testatorfamilychk = "false";
                    }
                  






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////


            //////////////////////////////// check in Appointees guardian  ///////////////////////////////////////





            string query4 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from Appointees a inner join TestatorDetails b on a.tId=b.tId where a.Type='Guardian' and b.uId = '" + Convert.ToInt32(Session["uuid"]) + "' ";
            SqlDataAdapter da4 = new SqlDataAdapter(query4, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);

            if (dt4.Rows.Count > 0)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    if (dt4.Rows[i]["Identity_proof_Value"].ToString() == response || dt4.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        guardianchk = "false";
                    }
                   






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////



            //////////////////////////////// check in beneficiary  ///////////////////////////////////////





            string query5 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId  where  b.uId = '" + Convert.ToInt32(Session["uuid"]) + "' ";
            SqlDataAdapter da5 = new SqlDataAdapter(query5, con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);

            if (dt5.Rows.Count > 0)
            {
                for (int i = 0; i < dt5.Rows.Count; i++)
                {
                    if (dt5.Rows[i]["Identity_proof_Value"].ToString() == response || dt5.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        benechk = "false";
                    }
                 






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////


            //////////////////////////////// check in Witness  ///////////////////////////////////////





            string query6 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from Appointees a inner join TestatorDetails b on a.tId=b.tId where  b.uId = " + Convert.ToInt32(Session["uuid"]) + "   and a.Type = 'Witness'";
            SqlDataAdapter da6 = new SqlDataAdapter(query6, con);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);

            if (dt6.Rows.Count > 0)
            {
                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                    if (dt6.Rows[i]["Identity_proof_Value"].ToString() == response || dt6.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        witchk = "false";
                    }
                 






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////








            con.Close();

            msg = testatorchk + "~" + testatorfamilychk + "~" + guardianchk + "~" + benechk + "~" + witchk;


            return msg;
        }











        public string Validateidentity2()
        {
            string response = Request["send"].ToString();
            string msg = "";

            string testatorchk = "";
            string testatorfamilychk = "";
            string guardianchk = "";
            string benechk = "";
            string witchk = "";

            con.Open();


            string query = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int tid = 0;
            if (dt.Rows.Count > 0)
            {
                tid = Convert.ToInt32(dt.Rows[0]["tId"]);
            }




            string query2 = "select Identity_proof_Value , Alt_Identity_proof_value from TestatorDetails  where tId = " + tid + "  ";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {

                if (dt2.Rows[0]["Alt_Identity_proof_value"].ToString() == response || dt2.Rows[0]["Identity_proof_Value"].ToString() == response)
                {
                    testatorchk = "false";
                }
             

            }







            //////////////////////////////// check in testator family  ///////////////////////////////////////







            string query3 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where  b.uId = '" + Convert.ToInt32(Session["uuid"]) + "'";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);

            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt3.Rows[i]["Identity_proof_Value"].ToString() == response || dt3.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        testatorfamilychk = "false";
                    }
               






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////


            //////////////////////////////// check in Appointees guardian  ///////////////////////////////////////





            string query4 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from Appointees a inner join TestatorDetails b on a.tId=b.tId where a.Type='Guardian' and b.uId = '" + Convert.ToInt32(Session["uuid"]) + "' ";
            SqlDataAdapter da4 = new SqlDataAdapter(query4, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);

            if (dt4.Rows.Count > 0)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    if (dt4.Rows[i]["Identity_proof_Value"].ToString() == response || dt4.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        guardianchk = "false";
                    }
                






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////



            //////////////////////////////// check in beneficiary  ///////////////////////////////////////





            string query5 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId  where  b.uId = '" + Convert.ToInt32(Session["uuid"]) + "' ";
            SqlDataAdapter da5 = new SqlDataAdapter(query5, con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);

            if (dt5.Rows.Count > 0)
            {
                for (int i = 0; i < dt5.Rows.Count; i++)
                {
                    if (dt5.Rows[i]["Identity_proof_Value"].ToString() == response || dt5.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        benechk = "false";
                    }
                 






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////


            //////////////////////////////// check in Witness  ///////////////////////////////////////





            string query6 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from Appointees a inner join TestatorDetails b on a.tId=b.tId where  b.uId = " + Convert.ToInt32(Session["uuid"]) + "   and a.Type = 'Witness'";
            SqlDataAdapter da6 = new SqlDataAdapter(query6, con);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);

            if (dt6.Rows.Count > 0)
            {
                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                    if (dt6.Rows[i]["Identity_proof_Value"].ToString() == response || dt6.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        witchk = "false";
                    }
                  





                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////








            con.Close();

            msg = testatorchk + "~" + testatorfamilychk + "~" + guardianchk + "~" + benechk + "~" + witchk;


            return msg;
        }





        public string altValidateidentity2()
        {
            string response = Request["send"].ToString();
            string msg = "";

            string testatorchk = "";
            string testatorfamilychk = "";
            string guardianchk = "";
            string benechk = "";
            string witchk = "";

            con.Open();


            string query = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int tid = 0;
            if (dt.Rows.Count > 0)
            {
                tid = Convert.ToInt32(dt.Rows[0]["tId"]);
            }




            string query2 = "select Identity_proof_Value , Alt_Identity_proof_value from TestatorDetails  where tId = " + tid + "  ";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {

                if (dt2.Rows[0]["Alt_Identity_proof_value"].ToString() == response || dt2.Rows[0]["Identity_proof_Value"].ToString() == response)
                {
                    testatorchk = "false";
                }
          

            }







            //////////////////////////////// check in testator family  ///////////////////////////////////////







            string query3 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where  b.uId = '" + Convert.ToInt32(Session["uuid"]) + "'";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);

            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt3.Rows[i]["Identity_proof_Value"].ToString() == response || dt3.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        testatorfamilychk = "false";
                    }
                






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////


            //////////////////////////////// check in Appointees guardian  ///////////////////////////////////////





            string query4 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from Appointees a inner join TestatorDetails b on a.tId=b.tId where a.Type='Guardian' and b.uId = '" + Convert.ToInt32(Session["uuid"]) + "' ";
            SqlDataAdapter da4 = new SqlDataAdapter(query4, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);

            if (dt4.Rows.Count > 0)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    if (dt4.Rows[i]["Identity_proof_Value"].ToString() == response || dt4.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        guardianchk = "false";
                    }
                 






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////



            //////////////////////////////// check in beneficiary  ///////////////////////////////////////





            string query5 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId  where  b.uId = '" + Convert.ToInt32(Session["uuid"]) + "' ";
            SqlDataAdapter da5 = new SqlDataAdapter(query5, con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);

            if (dt5.Rows.Count > 0)
            {
                for (int i = 0; i < dt5.Rows.Count; i++)
                {
                    if (dt5.Rows[i]["Identity_proof_Value"].ToString() == response || dt5.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        benechk = "false";
                    }
                






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////


            //////////////////////////////// check in Witness  ///////////////////////////////////////





            string query6 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from Appointees a inner join TestatorDetails b on a.tId=b.tId where  b.uId = " + Convert.ToInt32(Session["uuid"]) + "   and a.Type = 'Witness'";
            SqlDataAdapter da6 = new SqlDataAdapter(query6, con);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);

            if (dt6.Rows.Count > 0)
            {
                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                    if (dt6.Rows[i]["Identity_proof_Value"].ToString() == response || dt6.Rows[i]["Alt_Identity_proof_Value"].ToString() == response)
                    {
                        witchk = "false";
                    }
              






                }



            }


            ////////////////////////////////////////end////////////////////////////////////////////








            con.Close();

            msg = testatorchk + "~" + testatorfamilychk + "~" + guardianchk + "~" + benechk + "~" + witchk;


            return msg;
        }



    }
}