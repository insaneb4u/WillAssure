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
    public class AddBeneficiaryController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddBeneficiary
        public ActionResult AddBeneficiaryIndex(string NestId)
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
                    queryc22 = "select * from Appointees where WillType = 'Quick'  and tId = " + Convert.ToInt32(Session["distid"]) + " and Type = 'Guardian'  ";
                }
                if (Session["WillType"].ToString() == "Detailed" && Session["doctype"].ToString() == "Will")
                {
                    queryc22 = "select * from Appointees where WillType = 'Detailed'  and tId = " + Convert.ToInt32(Session["distid"]) + "  and Type = 'Guardian' ";
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
                    queryc1 = "select * from BeneficiaryInstitutions where tId = " + Convert.ToInt32(Session["distid"]) + "  and WillType = 'Quick'    ";
                }
                if (Session["WillType"].ToString() == "Detailed" && Session["doctype"].ToString() == "Will")
                {
                    queryc1 = "select * from BeneficiaryInstitutions where tId = " + Convert.ToInt32(Session["distid"]) + "  and WillType = 'Detailed'     ";
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


                ////////END











                con.Close();




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









            if (TempData["Message"] != null)
            {
                if (TempData["Message"].ToString() == "true")
                {
                    ViewBag.Message = "Verified";
                }
            }


            if (TempData["showbenepopup"] != null)
            {
                if (TempData["showbenepopup"].ToString() == "false")
                {
                    ViewBag.checkmessage = "false";
                }
                else
                {
                    ViewBag.checkmessage = "true";
                }

               
                   
                
            }


            ViewBag.view = "Will";
            ViewBag.collapse = "true";
            // check type fsdf
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




            string query = "";

            BeneficiaryModel BM = new BeneficiaryModel();

            con.Open();
            if (NestId != null)
            {
                query = "select * from BeneficiaryDetails where fetchid not in('TF') and bpId  = '" + NestId + "' ";
            }
            else
            {
                if (Session["doctype"] != null)
                {

                    if (Session["doctype"].ToString() == "Will")
                    {
                        query = "select top 1  * from BeneficiaryDetails where fetchid not in('TF') and tId  = '" + Convert.ToInt32(Session["distid"]) + "' and doctype = 'Will' order by bpId desc ";
                    }

                    if (Session["doctype"].ToString() == "POA")
                    {
                        query = "select top 1  * from BeneficiaryDetails where fetchid not in('TF') and tId  = '" + Convert.ToInt32(Session["distid"]) + "' and doctype = 'POA' order by bpId desc ";
                    }


                    if (Session["doctype"].ToString() == "GiftDeeds")
                    {
                        query = "select top 1  * from BeneficiaryDetails where fetchid not in('TF') and tId  = '" + Convert.ToInt32(Session["distid"]) + "' and doctype = 'Giftdeeds' order by bpId desc";
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


            if (dt.Rows.Count > 0)
            {
                ViewBag.disablefield = "true";


                BM.bpId = Convert.ToInt32(dt.Rows[0]["bpId"]);
                BM.First_Name = dt.Rows[0]["First_Name"].ToString();
                BM.Last_Name = dt.Rows[0]["Last_Name"].ToString();

                if (dt.Rows[0]["Middle_Name"].ToString() != "None")
                {
                    BM.Middle_Name = dt.Rows[0]["Middle_Name"].ToString();
                }

                



                BM.Dob = Convert.ToDateTime(dt.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
                BM.Mobile = dt.Rows[0]["Mobile"].ToString();
                BM.RelationshipTxt = dt.Rows[0]["Relationship"].ToString();
                BM.Marital_Status = dt.Rows[0]["Marital_Status"].ToString();
                BM.Religion = dt.Rows[0]["Religion"].ToString();
                BM.Identity_proof_text = dt.Rows[0]["Identity_proof"].ToString();
                BM.Identity_proof_value = dt.Rows[0]["Identity_proof_value"].ToString();
                BM.country_txt = dt.Rows[0]["Country"].ToString();

                if(BM.Alt_Identity_proof != null)
                {
                    BM.Alt_Identity_proof = dt.Rows[0]["Alt_Identity_proof"].ToString();
                }
                else
                {
                   
                    BM.Alt_Identity_proof = dt.Rows[0]["Alt_Identity_proof"].ToString();

                }




                if (BM.Alt_Identity_proof_value != null)
                {
                    BM.Alt_Identity_proof_value = dt.Rows[0]["Alt_Identity_proof_value"].ToString();
                }
                else
                {
                   
                    BM.Alt_Identity_proof_value = dt.Rows[0]["Alt_Identity_proof_value"].ToString();
                }
               
                BM.Address1 = dt.Rows[0]["Address1"].ToString();
                BM.Address2 = dt.Rows[0]["Address2"].ToString();
                BM.Address3 = dt.Rows[0]["Address3"].ToString();
                BM.City_txt = dt.Rows[0]["City"].ToString();
                BM.State_txt = dt.Rows[0]["State"].ToString();
                BM.Pin = dt.Rows[0]["Pin"].ToString();
                BM.aid = 0;
                BM.tid = 0;
                BM.createdBy = 0;
                BM.documentId = 0;
                BM.beneficiary_type = dt.Rows[0]["beneficiary_type"].ToString();

            }




            con.Open();
            string query2 = "select * from alternate_Beneficiary where bpId = " + BM.bpId + " ";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            con.Close();
            if (dt2.Rows.Count > 0)
            {
                ViewBag.alternate = "true";

                ViewBag.disablefield = "true";

                BM.altbpId = Convert.ToInt32(dt2.Rows[0]["lnk_bd_id"]);
                BM.altFirst_Name = dt2.Rows[0]["First_Name"].ToString();
                BM.altLast_Name = dt2.Rows[0]["Last_Name"].ToString();
                BM.altMiddle_Name = dt2.Rows[0]["Middle_Name"].ToString();

                BM.altDob = Convert.ToDateTime(dt2.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
                BM.altMobile = dt2.Rows[0]["Mobile"].ToString();
                BM.altRelationshipTxt = dt2.Rows[0]["Relationship"].ToString();
                BM.altMarital_Status_Txt = dt2.Rows[0]["Marital_Status"].ToString();
                BM.altReligion_TXT = dt2.Rows[0]["Religion"].ToString();
                BM.altIdentity_Proof = dt2.Rows[0]["Identity_Proof"].ToString();
                BM.altIdentity_Proof_Value = dt2.Rows[0]["Identity_Proof_Value"].ToString();
                BM.altAlt_Identity_Proof = dt2.Rows[0]["Alt_Identity_Proof"].ToString();
                BM.altAlt_Identity_Proof_Value = dt2.Rows[0]["Alt_Identity_Proof_Value"].ToString();
                BM.altAddress1 = dt2.Rows[0]["Address1"].ToString();
                BM.altAddress2 = dt2.Rows[0]["Address2"].ToString();
                BM.altAddress3 = dt2.Rows[0]["Address3"].ToString();
                BM.altcitytext = dt2.Rows[0]["City"].ToString();
                BM.altstatetext = dt2.Rows[0]["State"].ToString();
                BM.altPin = dt2.Rows[0]["Pin"].ToString();
            }






            return View("~/Views/AddBeneficiary/AddBeneficiaryPageContent.cshtml", BM);
        }

        public string Onnamebindguacity()
        {
            string response = Request["send"];
            con.Open();
            string query = "select distinct b.state_id  , b.statename  from  country_tbl a inner join tbl_state b on  a.CountryID=b.country_id where a.CountryName = '"+response+"' order by b.statename asc";
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

        //public String BindStateDDL()
        //{
        //    string response = Request["send"].ToString();
        //    con.Open();
        //    string query = "select distinct * from tbl_state where country_id = "+response+" order by statename asc  ";
        //    SqlDataAdapter da = new SqlDataAdapter(query, con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    string data = "<option value=''>--Select--</option>";

        //    if (dt.Rows.Count > 0)
        //    {


        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {




        //            data = data + "<option value=" + dt.Rows[i]["state_id"].ToString() + " >" + dt.Rows[i]["statename"].ToString() + "</option>";



        //        }




        //    }

        //    return data;

        //}



        //public string OnChangeBindCity()
        //{
        //    string response = Request["send"];
        //    con.Open();
        //    string query = "select distinct * from tbl_city where state_id = '" + response + "' order by city_name asc";
        //    SqlDataAdapter da = new SqlDataAdapter(query, con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    string data = "<option value='0'>--Select City--</option>";

        //    if (dt.Rows.Count > 0)
        //    {


        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {




        //            data = data + "<option value=" + dt.Rows[i]["id"].ToString() + " >" + dt.Rows[i]["city_name"].ToString() + "</option>";



        //        }




        //    }

        //    return data;
        //}




        public ActionResult InsertBeneficiaryData(BeneficiaryModel BM)
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

            //if (Session["aiid"] != null && Session["tid"].ToString() != null)
            //{
            //BM.aid = Convert.ToInt32(Session["aiid"]);
            //BM.tid = Convert.ToInt32(Session["tid"]);
                BM.aid = 0;
                int bpid = 0;
            if (Session["doctype"].ToString() == "Will")
            {
                ViewBag.Message = "RecordsInsert";
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDBeneficiaryDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@First_Name ", BM.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", BM.Last_Name);

                if (BM.Middle_Name != null)
                {
                    cmd.Parameters.AddWithValue("@Middle_Name", BM.Middle_Name);
                }
                else
                {
                    BM.Middle_Name = "None";
                    cmd.Parameters.AddWithValue("@Middle_Name", BM.Middle_Name);
                }

               



                DateTime dat = DateTime.ParseExact(BM.Dob, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@DOB", dat);
                if (BM.Mobile != null)
                {
                    cmd.Parameters.AddWithValue("@Mobile", BM.Mobile);
                }
                else
                {
                    BM.Mobile = "None";
                    cmd.Parameters.AddWithValue("@Mobile", BM.Mobile);
                }
                
                cmd.Parameters.AddWithValue("@Relationship", "None");
                cmd.Parameters.AddWithValue("@Marital_Status", "none");
                cmd.Parameters.AddWithValue("@Religion", "none");
                cmd.Parameters.AddWithValue("@Identity_proof", BM.Identity_proof);
                cmd.Parameters.AddWithValue("@Identity_proof_value", BM.Identity_proof_value);


                if (BM.Alt_Identity_proof != null)
                {
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof", BM.Alt_Identity_proof);
                }
                else
                {
                    BM.Alt_Identity_proof = "None";
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof", BM.Alt_Identity_proof);
                }

                if (BM.Alt_Identity_proof_value != null)
                {
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", BM.Alt_Identity_proof_value);
                }
                else
                {

                    BM.Alt_Identity_proof_value = "None";
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", BM.Alt_Identity_proof_value);

                }
               
                

                cmd.Parameters.AddWithValue("@Address1", BM.Address1);
                if (BM.Address2 != null || BM.Address2 == "")
                {
                    cmd.Parameters.AddWithValue("@Address2", BM.Address2);

                }
                else
                {
                    BM.Address2 = "None";
                    cmd.Parameters.AddWithValue("@Address2", BM.Address2);
                }


                if (BM.Address3 != null || BM.Address3 == "")
                {
                    cmd.Parameters.AddWithValue("@Address3", BM.Address3);

                }
                else
                {
                    BM.Address3 = "None";
                    cmd.Parameters.AddWithValue("@Address3", BM.Address3);
                }


                cmd.Parameters.AddWithValue("@City", BM.City_txt);
                cmd.Parameters.AddWithValue("@State", BM.State_txt);
                cmd.Parameters.AddWithValue("@Pin", BM.Pin);
                cmd.Parameters.AddWithValue("@aid", BM.aid);
                cmd.Parameters.AddWithValue("@tid", BM.ddltid);
                cmd.Parameters.AddWithValue("@beneficiary_type", "Beneficiary");
                cmd.ExecuteNonQuery();
                con.Close();


                // get latest bpid with filter
                bpid = 0;
                con.Open();
                string qq = "select top 1 * from BeneficiaryDetails order by bpId desc";
                SqlDataAdapter da = new SqlDataAdapter(qq, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    bpid = Convert.ToInt32(dt.Rows[0]["bpId"]);
                }
                con.Close();


                con.Open();
                string spup = "update BeneficiaryDetails set fetchid = " + Convert.ToInt32(Session["uuid"]) + "  , doctype = 'Will' where  bpid = "+bpid+" ";
                SqlCommand cmdup = new SqlCommand(spup, con);
                cmdup.ExecuteNonQuery();
                con.Close();

                con.Open();
                string spupe = "update BeneficiaryDetails set documentstatus = 'incompleted' , WillType='"+Session["WillType"].ToString()+"' , country='"+BM.country_txt+"'  where  bpid = " + bpid + " ";
                SqlCommand cmdupe = new SqlCommand(spupe, con);
                cmdupe.ExecuteNonQuery();
                con.Close();
                //end
                ViewBag.disablefield = "true";
            }


            if (Session["doctype"].ToString() == "POA")
            {
                ViewBag.Message = "RecordsInsert";
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDBeneficiaryDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@First_Name ", BM.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", BM.Last_Name);
                if (BM.Middle_Name != null)
                {
                    cmd.Parameters.AddWithValue("@Middle_Name", BM.Middle_Name);
                }
                else
                {
                    BM.Middle_Name = "None";
                    cmd.Parameters.AddWithValue("@Middle_Name", BM.Middle_Name);
                }
                string dd = Convert.ToDateTime(BM.Dob).ToString("dd-MM-yyyy");
                var d = DateTime.ParseExact(dd, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                //DateTime dat = DateTime.ParseExact(BM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@DOB", d);
                cmd.Parameters.AddWithValue("@Mobile", BM.Mobile);
                cmd.Parameters.AddWithValue("@Relationship", "None");
                cmd.Parameters.AddWithValue("@Marital_Status", "none");
                cmd.Parameters.AddWithValue("@Religion", "none");
                cmd.Parameters.AddWithValue("@Identity_proof", BM.Identity_proof);
                cmd.Parameters.AddWithValue("@Identity_proof_value", BM.Identity_proof_value);



                if (BM.Alt_Identity_proof != null)
                {
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof", BM.Alt_Identity_proof);
                }
                else
                {
                    BM.Alt_Identity_proof = "None";
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof", BM.Alt_Identity_proof);
                }

                if (BM.Alt_Identity_proof_value != null)
                {
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", BM.Alt_Identity_proof_value);
                }
                else
                {
                    BM.Alt_Identity_proof_value = "None";
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", BM.Alt_Identity_proof_value);
                }





               

                cmd.Parameters.AddWithValue("@Address1", BM.Address1);
                if (BM.Address2 != null || BM.Address2 == "")
                {
                    cmd.Parameters.AddWithValue("@Address2", BM.Address2);

                }
                else
                {
                    BM.Address2 = "None";
                    cmd.Parameters.AddWithValue("@Address2", BM.Address2);
                }


                if (BM.Address3 != null || BM.Address3 == "")
                {
                    cmd.Parameters.AddWithValue("@Address3", BM.Address3);

                }
                else
                {
                    BM.Address3 = "None";
                    cmd.Parameters.AddWithValue("@Address3", BM.Address3);
                }


                cmd.Parameters.AddWithValue("@City", BM.City_txt);
                cmd.Parameters.AddWithValue("@State", BM.State_txt);
                cmd.Parameters.AddWithValue("@Pin", BM.Pin);
                cmd.Parameters.AddWithValue("@aid", BM.aid);
                cmd.Parameters.AddWithValue("@tid", BM.ddltid);
                cmd.Parameters.AddWithValue("@beneficiary_type", "none");
                cmd.ExecuteNonQuery();
                con.Close();


                // get latest bpid with filter
                 bpid = 0;
                con.Open();
                string qq = "select top 1 * from BeneficiaryDetails order by bpId desc";
                SqlDataAdapter da = new SqlDataAdapter(qq, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    bpid = Convert.ToInt32(dt.Rows[0]["bpId"]);
                }
                con.Close();


                con.Open();
                string spup = "update BeneficiaryDetails set fetchid = " + Convert.ToInt32(Session["uuid"]) + "  , doctype = 'POA' , WillType='" + Session["WillType"].ToString() + "' ,  country='" + BM.country_txt + "' where  bpid = " + bpid + " ";
                SqlCommand cmdup = new SqlCommand(spup, con);
                cmdup.ExecuteNonQuery();
                con.Close();


                //end

                ViewBag.disablefield = "true";
            }


            if (Session["doctype"].ToString() == "GiftDeeds")
            {
                ViewBag.Message = "RecordsInsert";
              
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDBeneficiaryDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@First_Name ", BM.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", BM.Last_Name);
                if (BM.Middle_Name != null)
                {
                    cmd.Parameters.AddWithValue("@Middle_Name", BM.Middle_Name);
                }
                else
                {
                    BM.Middle_Name = "None";
                    cmd.Parameters.AddWithValue("@Middle_Name", BM.Middle_Name);
                }
                string dd = Convert.ToDateTime(BM.Dob).ToString("dd-MM-yyyy");
                var d = DateTime.ParseExact(dd, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                //DateTime dat = DateTime.ParseExact(BM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@DOB", d);
                cmd.Parameters.AddWithValue("@Mobile", BM.Mobile);
                cmd.Parameters.AddWithValue("@Relationship", "None");
                cmd.Parameters.AddWithValue("@Marital_Status", "none");
                cmd.Parameters.AddWithValue("@Religion", "none");
                cmd.Parameters.AddWithValue("@Identity_proof", BM.Identity_proof);
                cmd.Parameters.AddWithValue("@Identity_proof_value", BM.Identity_proof_value);



                if (BM.Alt_Identity_proof != null)
                {
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof", BM.Alt_Identity_proof);
                }
                else
                {
                    BM.Alt_Identity_proof = "None";
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof", BM.Alt_Identity_proof);
                }

                if (BM.Alt_Identity_proof_value != null)
                {
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", BM.Alt_Identity_proof_value);
                }
                else
                {
                    BM.Alt_Identity_proof_value = "None";
                    cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", BM.Alt_Identity_proof_value);
                }







                cmd.Parameters.AddWithValue("@Address1", BM.Address1);
                if (BM.Address2 != null || BM.Address2 == "")
                {
                    cmd.Parameters.AddWithValue("@Address2", BM.Address2);

                }
                else
                {
                    BM.Address2 = "None";
                    cmd.Parameters.AddWithValue("@Address2", BM.Address2);
                }


                if (BM.Address3 != null || BM.Address3 == "")
                {
                    cmd.Parameters.AddWithValue("@Address3", BM.Address3);

                }
                else
                {
                    BM.Address3 = "None";
                    cmd.Parameters.AddWithValue("@Address3", BM.Address3);
                }


                cmd.Parameters.AddWithValue("@City", BM.City_txt);
                cmd.Parameters.AddWithValue("@State", BM.State_txt);
                cmd.Parameters.AddWithValue("@Pin", BM.Pin);
                cmd.Parameters.AddWithValue("@aid", BM.aid);
                cmd.Parameters.AddWithValue("@tid", BM.ddltid);
                cmd.Parameters.AddWithValue("@beneficiary_type", "none");
                cmd.ExecuteNonQuery();
                con.Close();


                // get latest bpid with filter

                con.Open();
                string qq = "select top 1 * from BeneficiaryDetails order by bpId desc";
                SqlDataAdapter da = new SqlDataAdapter(qq, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    bpid = Convert.ToInt32(dt.Rows[0]["bpId"]);
                }
                con.Close();


                con.Open();
                string spup = "update BeneficiaryDetails set fetchid = " + Convert.ToInt32(Session["uuid"]) + "  , doctype = 'Giftdeeds' , WillType='" + Session["WillType"].ToString() + "' , country='" + BM.country_txt + "' where  bpid = " + bpid + " ";
                SqlCommand cmdup = new SqlCommand(spup, con);
                cmdup.ExecuteNonQuery();
                con.Close();


                //end

                ViewBag.disablefield = "true";
            }




            



            // alternate beneficiary id

            //get latest id first
            int checkaltbeneid = 0;
            con.Open();
            string getquery = "select top 1 lnk_bd_id from alternate_Beneficiary order by lnk_bd_id desc";
            SqlDataAdapter da2 = new SqlDataAdapter(getquery, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
           
            if (dt2.Rows.Count > 0)
            {
                checkaltbeneid = 1;
            }
            else
            {
                checkaltbeneid = 0;
            }
            con.Close();

            //end




            // Document Rules

            //get latest id first
            con.Open();
            string getquery2 = "select top 1 * from documentRules order by wdId desc";
            SqlDataAdapter da4 = new SqlDataAdapter(getquery2, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            int docid = 0;
            if (dt4.Rows.Count > 0)
            {
                docid = Convert.ToInt32(dt4.Rows[0]["wdId"]);
            }
            con.Close();

            //end



            con.Open();
            string rulequery = "update documentRules set AlternateBenficiaries = " + checkaltbeneid + "  where tid = " + BM.ddltid + " ";
            SqlCommand cmd2 = new SqlCommand(rulequery, con);
            cmd2.ExecuteNonQuery();
            con.Close();
            //end



            ModelState.Clear();


            TempData["Message"] = "true";



            //}
            //else
            //{
            //    ViewBag.Message = "link";
            //}





            return RedirectToAction("AddBeneficiaryIndex", "AddBeneficiary");
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
                    string query2 = "select * from BeneficiaryDetails where tId = " + Convert.ToInt32(dt.Rows[0]["tId"]) + " ";
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






        public int CheckTestatorUsers(string value,string checkstatus)
        {
            int check = 0;

            if (checkstatus != "true")
            {
                int Response = Convert.ToInt32(Request["send"]);
               
                if (Request["send"] != "")
                {
                    // check for data exists or not for testator family
                    if (value != null)
                    {
                        con.Open();
                        string query1 = "select a.bpId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_proof , a.Identity_proof_value , a.Alt_Identity_proof , a.Alt_Identity_proof_value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.beneficiary_type from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId inner join BeneficiaryDetails c on b.tId=c.tId  where b.tId = "+value+" and c.fetchid not in('TF')  ";
                        SqlDataAdapter da = new SqlDataAdapter(query1, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

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
                 
                    //end

                    




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
            }
            





            return check;

        }



        public ActionResult updateBeneficiary(BeneficiaryModel BM)
        {

            string identity = "";


            if (BM.Identity_proof_text != null)
            {
                identity = BM.Identity_proof_text;
            }


            if (BM.Identity_proof != null)
            {
                identity = BM.Identity_proof;
            }




            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDBeneficiaryDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@bpId  ", BM.bpId);
            cmd.Parameters.AddWithValue("@First_Name ", BM.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", BM.Last_Name);
            cmd.Parameters.AddWithValue("@Middle_Name", BM.Middle_Name);

            cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(BM.Dob));
            cmd.Parameters.AddWithValue("@Mobile", BM.Mobile);
            cmd.Parameters.AddWithValue("@Relationship", "None");
            cmd.Parameters.AddWithValue("@Marital_Status", "none");
            cmd.Parameters.AddWithValue("@Religion", "none");
            cmd.Parameters.AddWithValue("@Identity_proof", identity);
            cmd.Parameters.AddWithValue("@Identity_proof_value", BM.Identity_proof_value);

            if (BM.Alt_Identity_proof != null)
            {

                cmd.Parameters.AddWithValue("@Alt_Identity_proof", BM.Alt_Identity_proof);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Alt_Identity_proof", "None");
            }



            if (BM.Alt_Identity_proof_value != null)
            {
                cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", BM.Alt_Identity_proof_value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", "None");
            }
            

            




            cmd.Parameters.AddWithValue("@Address1", BM.Address1);
            cmd.Parameters.AddWithValue("@Address2", BM.Address2);
            cmd.Parameters.AddWithValue("@Address3", BM.Address3);
            cmd.Parameters.AddWithValue("@City", BM.City_txt);
            cmd.Parameters.AddWithValue("@State", BM.State_txt);
            cmd.Parameters.AddWithValue("@Pin", BM.Pin);
            cmd.Parameters.AddWithValue("@aid", "");
            cmd.Parameters.AddWithValue("@tid", BM.ddltid);
            cmd.Parameters.AddWithValue("@beneficiary_type", "none");
            cmd.ExecuteNonQuery();
            con.Close();


            // get latest bpid with filter
            int bpid = 0;
            con.Open();
            string qq = "select top 1 * from BeneficiaryDetails order by bpId desc";
            SqlDataAdapter da = new SqlDataAdapter(qq, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                bpid = Convert.ToInt32(dt.Rows[0]["bpId"]);
            }
            con.Close();


            con.Open();
            string spup = "update BeneficiaryDetails set country='" + BM.country_txt + "' where  bpid = " + bpid + " ";
            SqlCommand cmdup = new SqlCommand(spup, con);
            cmdup.ExecuteNonQuery();
            con.Close();


            //end



            if (BM.check == "true")
            {

                con.Open();
                SqlCommand cmd2 = new SqlCommand("SP_CRUD_alternate_Beneficiary", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@condition", "update");
                cmd2.Parameters.AddWithValue("@lnk_bd_id", BM.altbpId);
                cmd2.Parameters.AddWithValue("@bpId", BM.altbpId);
                cmd2.Parameters.AddWithValue("@First_Name", BM.altFirst_Name);
                cmd2.Parameters.AddWithValue("@Last_Name", BM.altLast_Name);
                cmd2.Parameters.AddWithValue("@Middle_Name", BM.altMiddle_Name);
                //DateTime dat2 = DateTime.ParseExact(BM.altDob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd2.Parameters.AddWithValue("@DOB", Convert.ToDateTime(BM.altDob));
                cmd2.Parameters.AddWithValue("@Mobile", BM.altMobile);
                cmd2.Parameters.AddWithValue("@Relationship", "None");
                cmd2.Parameters.AddWithValue("@Marital_Status", "none");
                cmd2.Parameters.AddWithValue("@Religion", "none");
                cmd2.Parameters.AddWithValue("@Identity_Proof", BM.altIdentity_Proof);
                cmd2.Parameters.AddWithValue("@Identity_Proof_Value", BM.altIdentity_Proof_Value);

                if (BM.altAlt_Identity_Proof != null)
                {
                    cmd2.Parameters.AddWithValue("@Alt_Identity_Proof", BM.altAlt_Identity_Proof);
                }
                else
                {
                    BM.altAlt_Identity_Proof = "None";
                    cmd2.Parameters.AddWithValue("@Alt_Identity_Proof", BM.altAlt_Identity_Proof);
                }


                if (BM.altAlt_Identity_Proof_Value != null)
                {
                    cmd2.Parameters.AddWithValue("@Alt_Identity_Proof_Value", BM.altAlt_Identity_Proof_Value);
                }
                else
                {
                    BM.altAlt_Identity_Proof_Value = "None";
                    cmd2.Parameters.AddWithValue("@Alt_Identity_Proof_Value", BM.altAlt_Identity_Proof_Value);
                }
                
                





                cmd2.Parameters.AddWithValue("@Address1", BM.altAddress1);
                cmd2.Parameters.AddWithValue("@Address2", BM.altAddress2);
                cmd2.Parameters.AddWithValue("@Address3", BM.altAddress3);
                cmd2.Parameters.AddWithValue("@City", BM.altcitytext);
                cmd2.Parameters.AddWithValue("@State", BM.altstatetext);
                cmd2.Parameters.AddWithValue("@Pin", BM.altPin);
                cmd2.Parameters.AddWithValue("@tid", BM.ddltid);
                cmd2.ExecuteNonQuery();
                con.Close();


            }

            ViewBag.Message = "RecordsInsert";

            return RedirectToAction("AddBeneficiaryIndex", "AddBeneficiary");
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


            string query = "select tId from TestatorDetails where tId = " + Convert.ToInt32(Session["distid"]) + "";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int tid = 0;
            if (dt.Rows.Count > 0)
            {
                tid = Convert.ToInt32(dt.Rows[0]["tId"]);
            }




            string query2 = "select Identity_proof_Value , Alt_Identity_proof_value from TestatorDetails  where tId = " + Convert.ToInt32(Session["distid"]) + "  ";
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







            string query3 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where  b.tId = '" + Convert.ToInt32(Session["distid"]) + "'";
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





            string query4 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from Appointees a inner join TestatorDetails b on a.tId=b.tId where a.Type='Guardian' and b.tid = '" + Convert.ToInt32(Session["distid"]) + "' ";
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





            string query5 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId  where  b.tId = '" + Convert.ToInt32(Session["distid"]) + "' ";
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





            string query6 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from Appointees a inner join TestatorDetails b on a.tId=b.tId where  b.tId = " + Convert.ToInt32(Session["distid"]) + "   and a.Type = 'Witness'";
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




            string query2 = "select Identity_proof_Value , Alt_Identity_proof_value from TestatorDetails  where tId = " + Convert.ToInt32(Session["distid"]) + "  ";
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







            string query3 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where  b.tId = '" + Convert.ToInt32(Session["distid"]) + "'";
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





            string query4 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from Appointees a inner join TestatorDetails b on a.tId=b.tId where a.Type='Guardian' and b.tid = '" + Convert.ToInt32(Session["distid"]) + "' ";
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





            string query5 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId  where  b.tId = '" + Convert.ToInt32(Session["distid"]) + "' ";
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





            string query6 = "select a.Alt_Identity_proof_Value , a.Identity_proof_Value from Appointees a inner join TestatorDetails b on a.tId=b.tId where  b.tId = " + Convert.ToInt32(Session["distid"]) + "   and a.Type = 'Witness'";
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





        public ActionResult CheckBeneficiaryCount()
        {

            con.Open();

            // get tid
            if (Session["Type"].ToString() != "SuperAdmin")
            {
                string checkuid = "";
                if (Session["WillType"].ToString() == "Quick")
                {
                    checkuid = "select tId from TestatorDetails  where tId = " + Convert.ToInt32(Session["distid"]) + " ";
                }

                if (Session["WillType"].ToString() == "Detailed")
                {
                    checkuid = "select tId from TestatorDetails  where tId = " + Convert.ToInt32(Session["distid"]) + " ";
                }

                SqlDataAdapter test001da = new SqlDataAdapter(checkuid, con);
                DataTable test001dt = new DataTable();
                test001da.Fill(test001dt);

                int NestId = 0;
                if (test001dt.Rows.Count > 0)
                {

                    NestId = Convert.ToInt32(test001dt.Rows[0]["tId"]);


                }



                //end





                // check testator family
                string query1 = "select beneficiary_type from BeneficiaryDetails where  tid=" + NestId + "";
                SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["beneficiary_type"].ToString() == "TestatorFamily" || dt1.Rows[0]["beneficiary_type"].ToString() == "Beneficiary" || dt1.Rows[0]["beneficiary_type"].ToString() == "Institution")
                    {
                        ViewBag.beneactive = "true";
                        TempData["showbenepopup"] = "true";
                    }



                }
                else
                {
                    TempData["showbenepopup"] = "false";
                }
                //end





            }
            else
            {
                TempData["showbenepopup"] = "true";
            }






            return RedirectToAction("AddBeneficiaryIndex", "AddBeneficiary");
            
        }




    }
}