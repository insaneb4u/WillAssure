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
    public class AddBeneficiaryInstituteController : Controller
    {


        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddBeneficiaryInstitute
        public ActionResult AddBeneficiaryInstituteIndex(string NestId)
        {



            string queryc1 = "";
            string queryc2 = "";
            string queryc3 = "";
            string queryc4 = "";
            string queryc5 = "";
            string queryc6 = "";
            string queryc7 = "";
            string queryc22 = "";
            //// check data for next page link if available active links

            if (Session["distid"] != null && Session["willtype"] != null && Session["doctype"] != null)
            {
                con.Open();


                //////// check TesttaorFamily 


                if (Session["WillType"].ToString() == "Quick" && Session["doctype"].ToString() == "Will")
                {
                    queryc22 = "select * from Appointees where WillType = 'Quick'  and tId = " + Convert.ToInt32(Session["distid"]) + " and  Type = 'Guardian'  ";
                }
                if (Session["WillType"].ToString() == "Detailed" && Session["doctype"].ToString() == "Will")
                {
                    queryc22 = "select * from Appointees where WillType = 'Detailed'  and tId = " + Convert.ToInt32(Session["distid"]) + " and Type = 'Guardian'  ";
                }



                SqlDataAdapter dac22 = new SqlDataAdapter(queryc22, con);
                DataTable dtc22 = new DataTable();
                dac22.Fill(dtc22);

                if (dtc22.Rows.Count > 0)
                {
                    ViewBag.beneactive = "true";
                }


                /////end


                //////// check beneficiary institution


                if (Session["WillType"].ToString() == "Quick" && Session["doctype"].ToString() == "Will")
                {
                    queryc1 = "select * from BeneficiaryInstitutions where tId = " + Convert.ToInt32(Session["distid"]) + "  and WillType = 'Quick'     ";
                }
                if (Session["WillType"].ToString() == "Detailed" && Session["doctype"].ToString() == "Will")
                {
                    queryc1 = "select * from BeneficiaryInstitutions where tId = " + Convert.ToInt32(Session["distid"]) + "  and WillType = 'Detailed'    ";
                }
                //if (Session["doctype"].ToString() == "POA")
                //{
                //    queryc1 = "select * from BeneficiaryInstitutions where tId = " + Convert.ToInt32(Session["distid"]) + "  and doctype = 'POA'    ";
                //}
                //if (Session["doctype"].ToString() == "Giftdeeds")
                //{
                //    queryc1 = "select * from BeneficiaryInstitutions where tId = " + Convert.ToInt32(Session["distid"]) + "  and doctype = 'Giftdeeds'    ";
                //}




                SqlDataAdapter dac1 = new SqlDataAdapter(queryc1, con);
                DataTable dtc1 = new DataTable();
                dac1.Fill(dtc1);

                if (dtc1.Rows.Count > 0)
                {
                    ViewBag.beneinstitureactive = "true";
                }


                /////end






                //////// check beneficiary 


                if (Session["WillType"].ToString() == "Quick" && Session["doctype"].ToString() == "Will")
                {
                    queryc2 = "select * from BeneficiaryDetails where tId = " + Convert.ToInt32(Session["distid"]) + " and doctype = 'Will' and WillType = 'Quick'  and tId = " + Convert.ToInt32(Session["distid"]) + "  and beneficiary_type='Beneficiary'  ";
                }
                if (Session["WillType"].ToString() == "Detailed" && Session["doctype"].ToString() == "Will")
                {
                    queryc2 = "select * from BeneficiaryDetails where tId = " + Convert.ToInt32(Session["distid"]) + " and doctype = 'Will' and WillType = 'Detailed'  and tId = " + Convert.ToInt32(Session["distid"]) + "  and beneficiary_type='Beneficiary'  ";
                }
                if (Session["doctype"].ToString() == "POA")
                {
                    queryc2 = "select * from BeneficiaryDetails where tId = " + Convert.ToInt32(Session["distid"]) + " and doctype = 'POA'   and tId = " + Convert.ToInt32(Session["distid"]) + "  and beneficiary_type='Beneficiary'  ";
                }
                if (Session["doctype"].ToString() == "Giftdeeds")
                {
                    queryc2 = "select * from BeneficiaryDetails where tId = " + Convert.ToInt32(Session["distid"]) + " and doctype = 'Giftdeeds'   and tId = " + Convert.ToInt32(Session["distid"]) + "  and beneficiary_type='Beneficiary'  ";
                }


                SqlDataAdapter dac2 = new SqlDataAdapter(queryc2, con);
                DataTable dtc2 = new DataTable();
                dac2.Fill(dtc2);

                if (dtc2.Rows.Count > 0)
                {
                    ViewBag.beneactive = "true";
                }


                /////end







                //////// check Executor 


                if (Session["WillType"].ToString() == "Quick" && Session["doctype"].ToString() == "Will")
                {
                    queryc3 = "select * from Appointees where Type = 'Executor' and doctype = 'Will' and WillType = 'Quick'  and tId = " + Convert.ToInt32(Session["distid"]) + " ";
                }
                if (Session["WillType"].ToString() == "Detailed" && Session["doctype"].ToString() == "Will")
                {
                    queryc3 = "select * from Appointees where Type = 'Executor' and doctype = 'Will' and WillType = 'Detailed'  and tId = " + Convert.ToInt32(Session["distid"]) + " ";
                }
                if (Session["doctype"].ToString() == "POA")
                {
                    queryc3 = "select * from Appointees where Type = 'Executor' and doctype = 'POA'  and tId = " + Convert.ToInt32(Session["distid"]) + " ";
                }
                if (Session["doctype"].ToString() == "Giftdeeds")
                {
                    queryc3 = "select * from Appointees where Type = 'Executor' and doctype = 'Giftdeeds' and  tId = " + Convert.ToInt32(Session["distid"]) + " ";
                }




                SqlDataAdapter dac3 = new SqlDataAdapter(queryc3, con);
                DataTable dtc3 = new DataTable();
                dac3.Fill(dtc3);

                if (dtc3.Rows.Count > 0)
                {
                    ViewBag.executoractive = "true";
                }


                /////end



                //////// check Witness 

                if (Session["WillType"].ToString() == "Quick" && Session["doctype"].ToString() == "Will")
                {
                    queryc4 = "select * from Appointees where Type = 'Witness' and doctype = 'Will' and WillType='Quick'   and tId = " + Convert.ToInt32(Session["distid"]) + " ";
                }
                if (Session["WillType"].ToString() == "Detailed" && Session["doctype"].ToString() == "Will")
                {
                    queryc4 = "select * from Appointees where Type = 'Witness' and doctype = 'Will' and WillType='Detailed'   and tId = " + Convert.ToInt32(Session["distid"]) + " ";
                }
                if (Session["doctype"].ToString() == "POA")
                {
                    queryc4 = "select * from Appointees where Type = 'Witness' and doctype = 'POA'  and tId = " + Convert.ToInt32(Session["distid"]) + " ";
                }
                if (Session["doctype"].ToString() == "Giftdeeds")
                {
                    queryc4 = "select * from Appointees where Type = 'Witness' and doctype = 'Giftdeeds'   and tId = " + Convert.ToInt32(Session["distid"]) + " ";
                }



                SqlDataAdapter dac4 = new SqlDataAdapter(queryc4, con);
                DataTable dtc4 = new DataTable();
                dac4.Fill(dtc4);

                if (dtc4.Rows.Count > 0)
                {
                    ViewBag.witnessactive = "true";
                }


                /////end








                /////////////////////////mAPPING

                if (Session["WillType"].ToString() == "Quick" && Session["doctype"].ToString() == "Will")
                {
                    queryc5 = "select * from BeneficiaryAssets where WillType = 'Quick' and doctype = 'Will' and tid = " + Convert.ToInt32(Session["distid"]) + " ";
                }
                if (Session["WillType"].ToString() == "Detailed" && Session["doctype"].ToString() == "Will")
                {
                    queryc5 = "select * from BeneficiaryAssets where WillType = 'Detailed' and doctype = 'Will' and tid = " + Convert.ToInt32(Session["distid"]) + " ";
                }
                if (Session["doctype"].ToString() == "POA")
                {
                    queryc5 = "select * from BeneficiaryAssets where  doctype = 'POA' and tid = " + Convert.ToInt32(Session["distid"]) + " ";
                }
                if (Session["doctype"].ToString() == "Giftdeeds")
                {
                    queryc5 = "select * from BeneficiaryAssets where doctype = 'Giftdeeds' and tid = " + Convert.ToInt32(Session["distid"]) + " ";
                }



                SqlDataAdapter dac5 = new SqlDataAdapter(queryc5, con);
                DataTable dtc5 = new DataTable();
                dac5.Fill(dtc5);

                if (dtc5.Rows.Count > 0)
                {
                    ViewBag.mappingactive = "true";
                }





                /////////////////////////Testator Details

                if (Session["WillType"].ToString() == "Quick" && Session["doctype"].ToString() == "Will")
                {
                    queryc6 = "select * from testatorFamily where  WillType = 'Quick' and tid = " + Convert.ToInt32(Session["distid"]) + "";
                }
                if (Session["WillType"].ToString() == "Detailed" && Session["doctype"].ToString() == "Will")
                {
                    queryc6 = "select * from testatorFamily where  WillType = 'Detailed' and tid = " + Convert.ToInt32(Session["distid"]) + "";
                }




                SqlDataAdapter dac6 = new SqlDataAdapter(queryc6, con);
                DataTable dtc6 = new DataTable();
                dac6.Fill(dtc6);

                if (dtc6.Rows.Count > 0)
                {
                    ViewBag.tfactive = "true";
                }







                /////////////////////////assetinformation

                if (Session["WillType"].ToString() == "Quick" && Session["doctype"].ToString() == "Will")
                {

                    queryc7 = "select * from AssetInformation where doctype = 'Will' and WillType = 'Quick' and tid = " + Convert.ToInt32(Session["distid"]) + " ";

                }


                if (Session["WillType"].ToString() == "Detailed" && Session["doctype"].ToString() == "Will")
                {

                    queryc7 = "select * from AssetInformation where doctype = 'Will' and WillType = 'Detailed' and tid = " + Convert.ToInt32(Session["distid"]) + " ";

                }
                if (Session["doctype"].ToString() == "POA")
                {
                    queryc7 = "select * from AssetInformation where   doctype = 'POA' and tid = " + Convert.ToInt32(Session["distid"]) + " ";
                }
                if (Session["doctype"].ToString() == "Giftdeeds")
                {
                    queryc7 = "select * from AssetInformation where  doctype = 'Giftdeeds' and tid = " + Convert.ToInt32(Session["distid"]) + " ";
                }



                SqlDataAdapter dac7 = new SqlDataAdapter(queryc7, con);
                DataTable dtc7 = new DataTable();
                dac7.Fill(dtc7);

                if (dtc7.Rows.Count > 0)
                {
                    ViewBag.assetinformationactive = "true";
                }
                ////////END











                con.Close();






                //end



            }
            else
            {
                return RedirectToAction("LoginPageIndex", "LoginPage");
            }




            con.Open();








            // check testator family
            string query1 = "select beneficiary_type from BeneficiaryDetails where  tid=" + Convert.ToInt32(Session["distid"]) + "";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["beneficiary_type"].ToString() == "TestatorFamily" || dt1.Rows[0]["beneficiary_type"].ToString() == "Beneficiary" || dt1.Rows[0]["beneficiary_type"].ToString() == "Institution")
                {
                    ViewBag.beneactive = "true";

                }



            }




            con.Close();

















            ViewBag.Collapse = "true";

            if (TempData["Message"] != null)
            {
                if (TempData["Message"].ToString() == "true")
                {
                    ViewBag.Message = "Verified";
                }
            }


            string query = "";
            BeneficiaryInstitutionModel BIM = new BeneficiaryInstitutionModel();

            con.Open();


            if (NestId != null)
            {
                query = "select * from BeneficiaryInstitutions where biId = "+NestId+" ";
            }
            else
            {
                query = "select * from BeneficiaryInstitutions where tid = " + Convert.ToInt32(Session["distid"]) + " order by biId desc ";
            }
           




            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {
                ViewBag.disablefield = "true";
                BIM.BiId = Convert.ToInt32(dt.Rows[0]["biId"]);


                BIM.FirstName = dt.Rows[0]["Name"].ToString();
                BIM.TypeText = dt.Rows[0]["Type"].ToString();
                BIM.RegistrationNo = Convert.ToInt32(dt.Rows[0]["registrationNo"]);
               
                BIM.Address = dt.Rows[0]["Address"].ToString();
                BIM.CityText = dt.Rows[0]["City"].ToString();
                BIM.StateText = dt.Rows[0]["State"].ToString();
                BIM.country_txt = dt.Rows[0]["Country"].ToString();

            }



            // alternate beneficiary institute


            string query2 = "select * from alternate_BeneficiaryInstitutions where biId = "+ BIM.BiId + " order by lnk_bi_id desc ";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();


            if (dt2.Rows.Count > 0)
            {
                ViewBag.disablefield = "true";
                ViewBag.alternate = "true";


                BIM.altFirstName = dt2.Rows[0]["Name"].ToString();
                BIM.altTypeText = dt2.Rows[0]["Type"].ToString();
                BIM.altRegistrationNo = Convert.ToInt32(dt2.Rows[0]["registrationNo"]);
                BIM.altAddress = dt2.Rows[0]["Address"].ToString();
                BIM.altCityText = dt2.Rows[0]["City"].ToString();
                BIM.altStateText = dt2.Rows[0]["State"].ToString();

            }







            //end











            return View("~/Views/AddBeneficiaryInstitute/AddBeneficiaryInstitute.cshtml",BIM);
        }

        public String UBindStateDDL()
        {

            string countryid = Request["send"].ToString();

            con.Open();
            string query = "select distinct b.state_id , b.statename from country_tbl a inner join tbl_state b on a.CountryID=b.country_id where a.CountryName = '" + countryid + "' order by b.statename asc";
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



        public String BindCountryDDL()
        {

            con.Open();
            string query = "select distinct * from country_tbl order by CountryName asc  ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select Country--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["CountryID"].ToString() + " >" + dt.Rows[i]["CountryName"].ToString() + "</option>";



                }




            }

            return data;

        }


        public string Onnamebindguacity()
        {
            string response = Request["send"];
            con.Open();
            string query = "select distinct b.id  , b.city_name  from  tbl_state a inner join tbl_city b on  a.state_id=b.state_id where a.statename = '" + response + "' order by b.city_name asc";
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



        public ActionResult InsertBeneficiaryInstitute(BeneficiaryInstitutionModel BIM)
        {

            con.Open();
            string query = "insert into BeneficiaryInstitutions (Name,Type,registrationNo,Address,City,State,tid,documentstatus,WillType,Country) values ('"+BIM.FirstName+"' , '"+BIM.TypeText+"' , "+BIM.RegistrationNo+" , '"+BIM.Address+"' , '"+BIM.CityText+"' , '"+BIM.StateText+"',"+Convert.ToInt32(Session["distid"])+" , 'incompleted' , '"+Session["WillType"].ToString()+"' ,  '"+BIM.country_txt+"')";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();


            string query2 = "insert into BeneficiaryDetails (First_Name,Address1,State,City,tId,beneficiary_type,WillType,Country) values ('" + BIM.FirstName+"', '"+BIM.Address+"' , '"+BIM.StateText+"' , '"+BIM.CityText+ "'," + Convert.ToInt32(Session["distid"]) + ",'Institution','"+Session["WillType"].ToString()+ "'  ,  '" + BIM.country_txt + "')";
            SqlCommand cmd2 = new SqlCommand(query2,con);
            cmd2.ExecuteNonQuery();
            con.Close();



            con.Open();
            string QUERY = "select top 1 biId from BeneficiaryInstitutions order by biId desc";
            SqlDataAdapter DA = new SqlDataAdapter(QUERY, con);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            int biId = 0;
            if (DT.Rows.Count > 0)
            {
                biId = Convert.ToInt32(DT.Rows[0]["biId"]);
            }

            con.Close();




            //  for beneficiary details


            con.Open();
            string QUERYe = "select top 1 bpId from BeneficiaryDetails order by bpId desc";
            SqlDataAdapter DAe = new SqlDataAdapter(QUERYe, con);
            DataTable DTe = new DataTable();
            DAe.Fill(DTe);
            int tfide = 0;
            if (DTe.Rows.Count > 0)
            {
                tfide = Convert.ToInt32(DTe.Rows[0]["bpId"]);
            }

            con.Close();



            // set document status
            con.Open();
            string queryee = "update BeneficiaryDetails set documentstatus = 'incompleted'  where  bpId = " + tfide + "";
            SqlCommand cmd3ee = new SqlCommand(queryee, con);
            cmd3ee.ExecuteNonQuery();
            con.Close();



            //end




            if (BIM.altchek == "true")
            {

                con.Open();
                string query3 = "insert into alternate_BeneficiaryInstitutions (Name,Type,registrationNo,Address,City,State,biId) values ('" + BIM.altFirstName + "' , '" + BIM.altTypeText + "' , " + BIM.altRegistrationNo + " , '" + BIM.altAddress + "' , '" + BIM.altCityText + "' , '" + BIM.altStateText + "' , "+ biId + ")";
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd3.ExecuteNonQuery();
                con.Close();

            }



            TempData["Message"] = "true";

            ModelState.Clear();

            return RedirectToAction("AddBeneficiaryInstituteIndex", "AddBeneficiaryInstitute");
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




        public ActionResult UpdateBeneficiaryInstitute(BeneficiaryInstitutionModel BIM)
        {

            con.Open();
            string query = "update BeneficiaryInstitutions set Name='"+BIM.FirstName+"' , Type = '"+BIM.TypeText+"' , registrationNo = "+BIM.RegistrationNo+" , Address = '"+BIM.Address+"' , City = '"+BIM.CityText+"' , State = '"+BIM.StateText+"' where biId = "+BIM.BiId+" ";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();


            con.Close();





            return RedirectToAction("AddBeneficiaryInstituteIndex", "AddBeneficiaryInstitute", new { success = "true" });
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









        public String altBindStateDDL()
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





        public string altOnChangeBindCity()
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

    }
}