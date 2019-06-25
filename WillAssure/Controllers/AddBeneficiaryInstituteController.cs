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
        public ActionResult AddBeneficiaryInstituteIndex(string success, string NestId)
        {

            if (success == "true")
            {
                ViewBag.Message = "Verified";

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
                query = "select * from BeneficiaryInstitutions where tid = " + Convert.ToInt32(Session["distid"]) + " ";
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

            }



            // alternate beneficiary institute


            string query2 = "select * from alternate_BeneficiaryInstitutions where biId = "+ BIM.BiId + "  ";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();


            if (dt2.Rows.Count > 0)
            {
                ViewBag.disablefield = "true";
                


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



        public ActionResult InsertBeneficiaryInstitute(BeneficiaryInstitutionModel BIM)
        {

            con.Open();
            string query = "insert into BeneficiaryInstitutions (Name,Type,registrationNo,Address,City,State,tid) values ('"+BIM.FirstName+"' , '"+BIM.TypeText+"' , "+BIM.RegistrationNo+" , '"+BIM.Address+"' , '"+BIM.CityText+"' , '"+BIM.StateText+"',"+Convert.ToInt32(Session["distid"])+")";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();


            string query2 = "insert into BeneficiaryDetails (First_Name,Address1,State,City,tId) values ('"+BIM.FirstName+"', '"+BIM.Address+"' , '"+BIM.StateText+"' , '"+BIM.CityText+ "'," + Convert.ToInt32(Session["distid"]) + ")";
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




            if (BIM.altchek == "true")
            {

                con.Open();
                string query3 = "insert into alternate_BeneficiaryInstitutions (Name,Type,registrationNo,Address,City,State,biId) values ('" + BIM.altFirstName + "' , '" + BIM.altTypeText + "' , " + BIM.altRegistrationNo + " , '" + BIM.altAddress + "' , '" + BIM.altCityText + "' , '" + BIM.altStateText + "' , "+ biId + ")";
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd3.ExecuteNonQuery();
                con.Close();

            }

           



            ModelState.Clear();

            return RedirectToAction("AddBeneficiaryInstituteIndex", "AddBeneficiaryInstitute",new { success = "true" });
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



    }
}