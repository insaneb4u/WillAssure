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
using System.Web.Script.Serialization;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WillAssure.Controllers
{
    public class QuickMappingController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: QuickMapping
        public ActionResult Index()
        {


            string queryc1 = "";
            string queryc2 = "";
            string queryc3 = "";
            string queryc4 = "";
            string queryc5 = "";
            string queryc22 = "";
            //// check data for next page link if available active links

            if (Session["distid"] != null && Session["willtype"] != null && Session["doctype"] != null)
            {
                con.Open();


                //////// check TesttaorFamily 


                if (Session["WillType"].ToString() == "Quick" && Session["doctype"].ToString() == "Will")
                {
                    queryc22 = "select * from testatorFamily where WillType = 'Quick'  and tId = " + Convert.ToInt32(Session["distid"]) + "   ";
                }
                if (Session["WillType"].ToString() == "Detailed" && Session["doctype"].ToString() == "Will")
                {
                    queryc22 = "select * from testatorFamily where WillType = 'Detailed'  and tId = " + Convert.ToInt32(Session["distid"]) + "   ";
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





                ////////END











                con.Close();






                //end



            }
            else
            {
                return RedirectToAction("LoginPageIndex", "LoginPage");
            }














            if (TempData["Message"] != null)
            {
                if (TempData["Message"].ToString() != "")
                {
                    ViewBag.Message = TempData["Message"].ToString();
                }
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



            con.Open();
            string query2 = "select count(*) as total from TestatorDetails a   inner join users b on a.uId = b.uId  where b.uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            if (Convert.ToInt32(dt2.Rows[0]["total"]) == 1)
            {
                ViewBag.popup = "true";
            }
            if (Session["rId"] == null || Session["uuid"] == null)
            {

                RedirectToAction("LoginPageIndex", "LoginPage");

            }







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







            return View("~/Views/QuickMapping/QuickMappingPageContent.cshtml");
        }

        public JsonResult bindassetcatDDL()
        {


            string res = "";


            con.Open();
            string qut = "select Proportion from BeneficiaryAssets where tid = "+ Convert.ToInt32(Session["distid"]) + " and documentstatus = 'Incompleted'";
            SqlDataAdapter daqt = new SqlDataAdapter(qut,con);
            DataTable dtq = new DataTable();
            daqt.Fill(dtq);
            con.Close();


            if (dtq.Rows.Count > 0)
            {

            }
            else
            {
                // beneficiary dropdown bind


                string d = "";

                d = "select * from BeneficiaryDetails where tid = " + Convert.ToInt32(Session["distid"]) + "";

                string data11 = "<option value=''>--Select--</option>";
                con.Open();

                SqlDataAdapter da11 = new SqlDataAdapter(d, con);
                DataTable dt11 = new DataTable();
                da11.Fill(dt11);
                con.Close();


                if (dt11.Rows.Count > 0)
                {

                    for (int k = 0; k < dt11.Rows.Count; k++)
                    {

                        data11 = data11 + "<option value=" + dt11.Rows[k]["bpId"] + ">" + dt11.Rows[k]["First_Name"] + "</option>";

                    }

                }


                //end

                int data = 1;
                for (int i = 0; i < 1; i++)
                {

                    res += "<div class='card mb-2 border border-danger' id='accparent'>";

                    res += "<div class='card-header'>";
                    res += "<button type='button' class='btn btn-link shadow-none text-danger collapsed ' data-toggle='collapse' data-target='#accordio" + i + "' aria-expanded='false' aria-controls='collapse-23'>";

                    res += "<input type='text' style='display:none;' id='txtassetcat" + i + "'  name='txtassetcat'  value='" + i + "' class='form-control' />";
                    res += "</button>";
                    res += "</div>";
                    res += "<div id='accordio" + i + "' class='collapse show  accordiondiv' data-parent='#accordion8'>";


                    res += "<div class='card-body'>";
                    res += "<div id='main-body" + i + "'>";

                    res += "<div class='col-sm-3' id='type" + i + "'>";

                    res += "<div class='form-group'>";
                    res += "<label for='input-1'>Type</label>";
                    res += "<br />";

                    res += "<label class='radio-inline'>";
                    res += "<input type='radio' id='getvalone' class=" + i + " name='optradio' value='Single' checked>Single";
                    res += "</label>";
                    res += "<label class='radio-inline'>";
                    res += "<input type='radio' id='getvaltwo' class=" + i + " name='optradio' value='Multiple'  >Multiple";
                    res += "</label>";
                    res += "<input type='hidden' name='checking' id='checking' value='Single' />";
                    res += "</div>";
                    res += "</div>";
                    res += "<div id='parentdiv" + i + "'  class='test'>";
                    res += "<div class='row rowdiv' id='beneficiarydetails' >";

                    res += "&nbsp;&nbsp;&nbsp;&nbsp;";
                    res += "<div class='col-sm-2'>";
                    res += "<div class='form-group' id='mainbeneddl" + i + "'>";
                    res += "<label for='input-1'>Beneficiary</label><span id='errbene'  style='color:red; display:;'>(*)</span>";
                    res += "<select id='ddlbeneficiary" + i + "'  onchange='checkbeneficiaryduplicate(this.id,this.value)' name='multiproportion' class='form-control beneficiaryclass validate[required]'>" + data11 + "</select>";

                    res += "<input type='text' class='form-control' style='display: none' id='ddlbeneficiarytxt' name='name' value='' />";
                    res += "</div>";
                    res += "</div>";

                    res += "<div class='col-sm-2 grandparent'>";
                    res += "<div class='form-group parent'>";
                    res += "<label for='input-1'>Proportion</label><span id='errproportion' style='color:red;display:;'>(*)</span>";

                    res += "<input type='text' autocomplete='off' class='form-control proportioninput validate[required] multiple'  onkeypress='return isNumberKey(event)'   onchange='gettxtproportion(this.id,this.value)' name='multiproportion'  id='txtproportion" + i + "' />";
                    res += "</div>";
                    res += "</div>";
                    res += "<div class='col-sm-2' id='totaldiv" + i + "'>";
                    res += "<div class='form-group start'>";
                    res += "<label for='input-1' style='White-space:nowrap;'>Balance Proportion</label>";
                    res += "<input type='text' id='txttotal" + i + "' min=0  class='form-control totalinput' readonly />";
                    res += "<button type='button' id='btnremove' style='position:relative; top:-39px; right:-466px;'  value='" + i + "' style='display:;'    class='btn btn-danger  btnremove'><i class='icon-trash'></i></button>";
                    res += "<input type='text' id='txtcapbeneid' style='display:none;' name='txtcapbeneid' class='txtcapclass'  />";
                    res += "</div>";
                    res += "</div>";


                    res += "<div class='col-sm-2' id='singlepropo" + i + "' style='display:none;'>";
                    res += "<div class='form-group start'>";
                    res += "<label for='input-1' style='white-space:nowrap'>single Proportion</label>";
                    res += "<input type='text' id='txtsingleproportion" + i + "' name='multiproportion' Value='100'  class='form-control singleproportion' readonly />";

                    res += "</div>";
                    res += "</div>";


                    res += "</br>";
                    res += "<div class='col-md-8 alternaterow' style='display:;'>";
                    res += "<table class='table tblalternaterow'>";
                    res += "<tr class='rowclass'>";


                    res += "<td><select disabled name='alt_proportion'  style='width:109px' onchange='checkaltbeneficiaryduplicate(this.id,this.value)' id='alt_beneficiary1' data-errormessage-value-missing='All Alternate Beneficiary Fields are Mandatory...!' class='form-control altbeneficiaryclass disabledelement  validate[required]'>" + data11 + "</select></td>";
                    res += "<td><input disabled type='text' name='alt_proportion' style='width:109px' id='alt_proportion1' class='form-control alt_proportioninput disabledelement validate[required]'   data-errormessage-value-missing='All Alternate Beneficiary Fields are Mandatory...!'></td>";
                    res += "<td><input disabled type='text' name='alt_total' style='Width:109px;'  id='alt_total1' value='100' class='form-control alt_totalinput disabledelement'></td>";
                    res += "<td><input disabled type='text' name='alt_proportion' style='display:none;' value='0' id='alt_pr1' class='form-control alt_propo disabledelement'></td>";
                    res += "<td><button type='button' class='btn btn-sm btn-success btnaddalternate'>Add Alternate Beneficiary</button></td>";
                    res += "</tr>";
                    res += "</table>";
                    res += "</div>";


                    res += "<div class='col-sm-2' id='alternatefield' style='display:none'>";
                    res += "<div class='form-group' id='mainbeneddl" + i + "'>";
                    res += "<label for='input-1' style='white-space:nowrap'>Alternate Beneficiary</label>";
                    res += "<select id='ddlbeneficiaryalt" + i + "'  style='width:109px' onchange='altcheckbeneficiaryduplicate(this.id,this.value)' name='contentList' class='form-control altbeneficiaryclass '> " + data11 + " </select>";
                    res += "<input type='text' class='form-control' style='display: none' id='ddlbeneficiarytxt' name='name' value='' />";
                    res += "</div>";
                    res += "</div>";




                










                    res += "</div>";
                    res += "</div>";


                    res += "<div class='form-group'>";
                    res += "&nbsp;&nbsp;&nbsp;&nbsp;<button type='submit'   formaction='InsertMultipleAssetMappeddata' id='btnmappingsubmit' value=" + i + "  class='btn btn-primary shadow-primary px-5 btn" + i + "'><i class='icon-lock'></i>Submit</button>";
                    res += "&nbsp;&nbsp;&nbsp;&nbsp;<button type='button' id='btnadd'   value='" + i + "' style='display:none;' disabled='disabled'    class='btn btn-success shadow-primary px-5 btnadd" + i + "'><i class='icon-lock'></i>Add Multiple</button>";
                    res += "&nbsp;&nbsp;&nbsp;&nbsp;<input type='button' value='Reset' class='btn btn-danger' id='btnreset' />";
                    res += "</div>";
                    res += "</div>";
                    res += "</div>";
                    res += "</div>";
                    res += "</div>";

                }





            }






            return Json(res);
        }





        [HttpPost]
        public ActionResult InsertMultipleAssetMappeddata(FormCollection collection)
        {
            string collect = collection["checking"].ToString();

            if (collection["checking"] == "Single")
            {
                string propo = collection["multiproportion"].ToString();
                propo = propo.Replace(",,", ",");

                string querydy = "";


                string assetcatid = "";
                string assettypeid = "";
                string combine = "";

                con.Open();
                string getassettype = "select amId , atId from AssetsCategory where AssetsCategory =  '" + collection["txtassetcat"].ToString() + "' ";
                SqlDataAdapter atda = new SqlDataAdapter(getassettype, con);
                DataTable atdt = new DataTable();
                atda.Fill(atdt);
                if (atdt.Rows.Count > 0)
                {
                    assetcatid = atdt.Rows[0]["amId"].ToString();
                    assettypeid = atdt.Rows[0]["atId"].ToString();

                }
                con.Close();

                combine = collection["txtassetcat"].ToString() + assetcatid;




                ArrayList result = new ArrayList(propo.Split(','));
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
                    if (getcount == 2)
                    {



                        data = data.Remove(data.Length - 1, 1);

                        querydy = "insert BeneficiaryAssets (Beneficiary_ID ,Proportion , tid  , doctype,Type,Category,documentstatus,WillType) values(" + data + " , " + Session["distid"].ToString() + "  , '" + Session["doctype"].ToString() + "', 1  ,'" + combine + "' , 'incompleted','" + Session["WillType"].ToString() + "' ) ";
                        SqlCommand cmdy = new SqlCommand(querydy, con);
                        cmdy.ExecuteNonQuery();
                        getcount = 1;

                        data = "";
                        //  change = 10;
                        // count = 3;

                        try
                        {
                            data = "" + result[i].ToString() + ",";
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
                            data += "" + result[i].ToString() + ",";
                        }
                        catch (Exception)
                        {


                        }

                    }
                    getcount++;
                    //end







                    //end



                }
                con.Close();





                if (collection["checkaltbenestatus"].ToString() == "true")
                {


                    string querydy2 = "";
                    string altbene = collection["alt_proportion"].ToString();
                    string linkid = collection["txtcapbeneid"].ToString();





                    string firstValue = result[0].ToString();
                    ArrayList result2 = new ArrayList(altbene.Split(','));
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
                                if ((result2.IndexOf(result2) != 0))
                                {
                                    data2 += linkid;
                                }


                                continue;
                            }
                        }
                        catch (Exception)
                        {


                        }



                        //if (getcount == change)

                        // dynamic appointees
                        if (getcount2 == 3)
                        {



                            data2 = data2.Remove(data2.Length - 1, 1);

                            querydy2 = "insert into alternate_Beneficiaryassets (alternatebenefciaryid ,alternateproportion,linkedbid,WillType) values (" + data2 + ",'Quick') ";
                            SqlCommand cmdy2 = new SqlCommand(querydy2, con);
                            cmdy2.ExecuteNonQuery();
                            getcount2 = 1;

                            data2 = "";
                            //  change = 10;
                            // count = 3;

                            try
                            {
                                data2 = "" + result2[i].ToString() + ",";
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
                                data2 += "" + result2[i].ToString() + ",";
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

                }
            }
            else
            {
                string propo = collection["multiproportion"].ToString();
               


                string querydy = "";


                string assetcatid = "";
                string assettypeid = "";
                string combine = "";

                con.Open();
                string getassettype = "select amId , atId from AssetsCategory where AssetsCategory =  '" + collection["txtassetcat"].ToString() + "' ";
                SqlDataAdapter atda = new SqlDataAdapter(getassettype, con);
                DataTable atdt = new DataTable();
                atda.Fill(atdt);
                if (atdt.Rows.Count > 0)
                {
                    assetcatid = atdt.Rows[0]["amId"].ToString();
                    assettypeid = atdt.Rows[0]["atId"].ToString();

                }
                con.Close();

                combine = collection["txtassetcat"].ToString() + assetcatid;




                ArrayList result = new ArrayList(propo.Split(','));
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
                    if (getcount == 2)
                    {



                        data = data.Remove(data.Length - 1, 1);

                        querydy = "insert BeneficiaryAssets (Beneficiary_ID ,Proportion , tid  , doctype,Type,Category,documentstatus,WillType) values(" + data + " , " + Session["distid"].ToString() + "  , '" + Session["doctype"].ToString() + "', 2  ,'" + combine + "' , 'incompleted','" + Session["WillType"].ToString() + "' ) ";
                        SqlCommand cmdy = new SqlCommand(querydy, con);
                        cmdy.ExecuteNonQuery();
                        getcount = 1;

                        data = "";
                        //  change = 10;
                        // count = 3;

                        try
                        {
                            data = "" + result[i].ToString() + ",";
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
                            data += "" + result[i].ToString() + ",";
                        }
                        catch (Exception)
                        {


                        }

                    }
                    getcount++;
                    //end







                    //end



                }
                con.Close();





                if (collection["checkaltbenestatus"].ToString() == "true")
                {



                    // set document rules
                    con.Open();
                    string qdr = "update documentRules set AlternateBenficiaries = 1 where tid = " + Convert.ToInt32(Session["distid"]) + " ";
                    SqlCommand cdr = new SqlCommand(qdr, con);
                    cdr.ExecuteNonQuery();
                    con.Close();
                    // end



                    string querydy2 = "";
                    string altbene = collection["alt_proportion"].ToString();
                    string linkid = collection["txtcapbeneid"].ToString();





                    string firstValue = result[0].ToString();
                    ArrayList result2 = new ArrayList(altbene.Split(','));
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
                                if ((result2.IndexOf(result2) != 0))
                                {
                                    data2 += linkid;
                                }


                                continue;
                            }
                        }
                        catch (Exception)
                        {


                        }



                        //if (getcount == change)

                        // dynamic appointees
                        if (getcount2 == 3)
                        {



                            data2 = data2.Remove(data2.Length - 1, 1);

                            querydy2 = "insert into alternate_Beneficiaryassets (alternatebenefciaryid ,alternateproportion,linkedbid,WillType) values (" + data2 + ",'Quick') ";
                            SqlCommand cmdy2 = new SqlCommand(querydy2, con);
                            cmdy2.ExecuteNonQuery();
                            getcount2 = 1;

                            data2 = "";
                            //  change = 10;
                            // count = 3;

                            try
                            {
                                data2 = "" + result2[i].ToString() + ",";
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
                                data2 += "" + result2[i].ToString() + ",";
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

                }
                else
                {
                    // set document rules
                    con.Open();
                    string qdr = "update documentRules set AlternateBenficiaries = 2 where tid = " + Convert.ToInt32(Session["distid"]) + " ";
                    SqlCommand cdr = new SqlCommand(qdr, con);
                    cdr.ExecuteNonQuery();
                    con.Close();
                    // end

                }
            }



            




            // if records submitted change status for assetinformation
            con.Close();
            con.Open();
            string query2 = "update assetinformation set Remark ='Completed' where tid = " + Convert.ToInt32(Session["distid"]) + "  and WillType='Quick'";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.ExecuteNonQuery();
            con.Close();
            //end

            if (collect == "")
            {
                TempData["Message"] = "Single";
            }
            else
            {
                TempData["Message"] = collect;
            }
            


            return RedirectToAction("Index", "QuickMapping");
        }




        public ActionResult InsertSingleAssetMappeddata()
        {
            ViewBag.collapse = "true";
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

            string tid = "";
            string assetcategorytxt = "";
            string beneficiaryid = "";
            string assetcatid = "";
            string assettypeid = "";
            int proportion = 100;
            int btnid = 0;
            int altbeneid = 0;
            string response = Request["send"];
            //string assettype = response.Split('~')[0];
            //string assetcat = response.Split('~')[1];
            assetcategorytxt = response.Split('~')[0];

            beneficiaryid = response.Split('~')[1];
            tid = Convert.ToString(response.Split('~')[2]);
            btnid = Convert.ToInt32(response.Split('~')[3]);
            if (response.Split('~')[4] != "")
            {
                altbeneid = Convert.ToInt32(response.Split('~')[4]);
            }
            else
            {
                altbeneid = 0;
            }



            if (tid == "" || tid == null || tid == "undefined")
            {
                tid = Session["distid"].ToString();
            }

            string combine = "";

            con.Open();
            string getassettype = "select amId , atId from AssetsCategory where AssetsCategory =  '" + assetcategorytxt + "' ";
            SqlDataAdapter atda = new SqlDataAdapter(getassettype, con);
            DataTable atdt = new DataTable();
            atda.Fill(atdt);
            if (atdt.Rows.Count > 0)
            {
                assetcatid = atdt.Rows[0]["amId"].ToString();
                assettypeid = atdt.Rows[0]["atId"].ToString();

            }
            con.Close();

            combine = assetcategorytxt + assetcatid;


            con.Open();
            string query = "insert into BeneficiaryAssets ( Beneficiary_ID  , Proportion , tid , doctype ,Type  , documentstatus , alternatebid , WillType) values   (" + beneficiaryid + " ,  '" + proportion + "' , " + Convert.ToInt32(tid) + " , '" + Session["doctype"].ToString() + "',1, 'incompleted' , " + altbeneid + " , 'Quick') ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();


            //// if records submitted change status for assetinformation
            //con.Open();
            //string query2 = "update assetinformation set Remark ='Completed' where amId = " + assetcatid + "";
            //SqlCommand cmd2 = new SqlCommand(query2, con);
            //cmd2.ExecuteNonQuery();
            //con.Close();
            ////end


            ModelState.Clear();
            return Json(btnid);
        }



        //public JsonResult InsertMultipleAssetMappeddata(string data, string assetcat, string tid, string btnidentify)
        //{


        //    ViewBag.collapse = "true";
        //    // roleassignment
        //    List<LoginModel> Lmlist = new List<LoginModel>();
        //    con.Open();
        //    string q = "select * from Assignment_Roles where RoleId = " + Convert.ToInt32(Session["rId"]) + "";
        //    SqlDataAdapter da3 = new SqlDataAdapter(q, con);
        //    DataTable dt3 = new DataTable();
        //    da3.Fill(dt3);
        //    if (dt3.Rows.Count > 0)
        //    {

        //        for (int i = 0; i < dt3.Rows.Count; i++)
        //        {
        //            LoginModel lm = new LoginModel();
        //            lm.PageName = dt3.Rows[i]["PageName"].ToString();
        //            lm.PageStatus = dt3.Rows[i]["PageStatus"].ToString();
        //            lm.Action = dt3.Rows[i]["Action"].ToString();
        //            lm.Nav1 = dt3.Rows[i]["Nav1"].ToString();
        //            lm.Nav2 = dt3.Rows[i]["Nav2"].ToString();

        //            Lmlist.Add(lm);
        //        }



        //        ViewBag.PageName = Lmlist;




        //    }

        //    con.Close();


        //    //end
        //    string assetcatid = "";
        //    string assettypeid = "";
        //    string combine = "";

        //    con.Open();
        //    string getassettype = "select amId , atId from AssetsCategory where AssetsCategory =  '" + assetcat + "' ";
        //    SqlDataAdapter atda = new SqlDataAdapter(getassettype, con);
        //    DataTable atdt = new DataTable();
        //    atda.Fill(atdt);
        //    if (atdt.Rows.Count > 0)
        //    {
        //        assetcatid = atdt.Rows[0]["amId"].ToString();
        //        assettypeid = atdt.Rows[0]["atId"].ToString();

        //    }
        //    con.Close();

        //    combine = assetcat + assetcatid;

        //    string response = data;
        //    string filter = response.Replace(" ", string.Empty).Replace("\n", string.Empty);
        //    ArrayList result = new ArrayList(filter.Split('~'));

        //    for (int i = 0; i < result.Count; i++)
        //    {
        //        if (result[i].ToString() != "")
        //        {
        //            try
        //            {
        //                con.Open();
        //                result[i].ToString();
        //                string query = "insert into BeneficiaryAssets (Beneficiary_ID ,Proportion , alternatebid , tid , doctype,Type,documentstatus,WillType) values (" + result[i].ToString() + "," + Convert.ToInt32(tid) + " , '" + Session["doctype"].ToString() + "',2, 'incompleted','Quick')";
        //                SqlCommand cmd = new SqlCommand(query, con);
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //            }
        //            catch (Exception)
        //            {


        //            }

        //        }
        //    }

        //    // if records submitted change status for assetinformation
        //    con.Close();






        //    ModelState.Clear();
        //    return Json(btnidentify);
        //}





        public string BindLastSingleRecords()
        {
            // last financial records
            string financialstructure = "";
            con.Open();
            string checkfinancial = "";


            string checkuid = "";
            if (Session["WillType"].ToString() == "Quick")
            {
                checkuid = "select tId from TestatorDetails  where tId = " + Convert.ToInt32(Session["distid"]) + " ";
            }

            if (Session["WillType"].ToString() == "Detailed")
            {
                checkuid = "select tId from TestatorDetails  where tId = " + Convert.ToInt32(Session["distid"]) + " ";
            }
            SqlDataAdapter dachk = new SqlDataAdapter(checkuid,con);
            DataTable dtchk = new DataTable();
            dachk.Fill(dtchk);
            int tid = 0;
            if (dtchk.Rows.Count > 0)
            {
                tid = Convert.ToInt32(dtchk.Rows[0]["tId"]);
            }


            if (Session["doctype"] != null)
            {

                if (Session["doctype"].ToString() == "Will")
                {
                    checkfinancial = "select distinct ab.alternatebenefciaryid , a.First_Name as beneficiary , c.Proportion from BeneficiaryDetails a inner join BeneficiaryAssets b on a.bpId=b.Beneficiary_ID inner join BeneficiaryAssets c on a.tId=c.tid  inner join Alternate_BeneficiaryAssets ab on b.Beneficiary_ID=ab.alternatebenefciaryid where a.tId = " + tid + " and a.doctype = 'Will' and c.Type = 1";
                }

                if (Session["doctype"].ToString() == "POA")
                {
                    checkfinancial = "select distinct ab.alternatebenefciaryid , a.First_Name as beneficiary , c.Proportion from BeneficiaryDetails a inner join BeneficiaryAssets b on a.bpId=b.Beneficiary_ID inner join BeneficiaryAssets c on a.tId=c.tid  inner join Alternate_BeneficiaryAssets ab on b.Beneficiary_ID=ab.alternatebenefciaryid where a.tId = " + tid + " and a.doctype = 'POA' and c.Type = 1";
                }


                if (Session["doctype"].ToString() == "GiftDeeds")
                {
                    checkfinancial = "select distinct ab.alternatebenefciaryid , a.First_Name as beneficiary , c.Proportion from BeneficiaryDetails a inner join BeneficiaryAssets b on a.bpId=b.Beneficiary_ID inner join BeneficiaryAssets c on a.tId=c.tid inner join Alternate_BeneficiaryAssets ab on b.Beneficiary_ID=ab.alternatebenefciaryid where a.tId = " + tid + " and a.doctype = 'GiftDeeds' and c.Type = 1";
                }




            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }




            SqlDataAdapter chkfinancialda = new SqlDataAdapter(checkfinancial, con);
            DataTable chkfinancialdt = new DataTable();
            chkfinancialda.Fill(chkfinancialdt);
            string assetcat = "";
            string assettype = "";
            string alternatedata = "";
            if (chkfinancialdt.Rows.Count > 0)
            {
                for (int j = 0; j < 1; j++)
                {

                    financialstructure += "<div class='row'>" +
      "<div class='col-lg-12'>" +
      "<div id='accordion001'>" +
      "<div class='card mb-2 border border-success'>" +
      "<div class='card-header'>" +
      "<button type='button' class='btn btn-link shadow - none text - success' data-toggle='collapse' data-target='#multipleaccordion-" + j + "' aria-expanded='true' aria-controls='collapse-22'>" +
      "(Single)" +
      "</button>" +
      "</div>" +
      "<div id='multipleaccordion-" + j + "' class='collapse' data-parent='#accordion001'>" +
      "<div class='card-body'>";


                    if (chkfinancialdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < chkfinancialdt.Rows.Count; i++)
                        {


                            /// alternate beneficiary records
                            string queryalt = "select bd.First_Name , ab.alternateproportion from Alternate_BeneficiaryAssets ab inner join BeneficiaryDetails bd on ab.linkedbid=bd.bpId  where ab.linkedbid = " + Convert.ToInt32(chkfinancialdt.Rows[i]["alternatebenefciaryid"]) + "";
                            SqlDataAdapter daalt = new SqlDataAdapter(queryalt, con);
                            DataTable dtalt = new DataTable();
                            daalt.Fill(dtalt);

                            if (dtalt.Rows.Count > 0)
                            {
                                for (int z = 0; z < dtalt.Rows.Count; z++)
                                {
                                    alternatedata += "<div class='col-sm-3'>" +
                          "<label for='input-1'>Alternate Beneficiary</label>" +
                          "<input type='text' value='" + dtalt.Rows[z]["First_Name"].ToString() + "'  readonly='true' class='form-control' id='' />" +
                          "</div>" +

                          "<div class='col-sm-3'>" +
                          "<label for='input-1'>Proportion</label>" +
                          "<input type='text' value='" + dtalt.Rows[z]["alternateproportion"].ToString() + "' id=''  readonly='true' class='form-control' />" +
                          "</div><div class='col-sm-6'></div>";
                                }

                            }
                            //end




                            financialstructure += "<div class='row'>" +
                               "<div class='col-sm-3'>" +
                               "<label for='input-1'>Beneficiary</label>" +
                               "<input type='text' value='" + chkfinancialdt.Rows[i]["beneficiary"].ToString() + "'  readonly='true' class='form-control' id='' />" +
                               "</div>" +


                               "<div class='col-sm-3'>" +
                               "<label for='input-1'>Proportion</label>" +
                               "<input type='text' value='" + chkfinancialdt.Rows[i]["Proportion"].ToString() + "' id=''  readonly='true' class='form-control' />" +
                               "</div><div class='col-sm-6'></div>" +

                                    "<br>" +
                                    "<br>" +
                                    "<br>" +
                       "<button type='button' class='btn btn-link shadow - none text - success' data-toggle='collapse' data-target='#collapsesingleFA' aria-expanded='true' aria-controls='collapse-22'>" +
                       "(Alternate Beneficiary)" +
                       "</button>" +
                       "<br>" +
                       "<br>" +
                       "<div class='row' id='alternatedata'>" +
                       alternatedata +
                       "</div>" +




                            "</div>";



                        }





                    }


                    financialstructure += "</div>" +
                         "</div>" +
                         "</div>" +
                         "</div>";

                }
            }


















            con.Close();



            //end





            return financialstructure;

        }




        public string BindLastMultipleRecords()
        {
            // last financial records
            string financialstructure = "";
            con.Open();
            string checkfinancial = "";








            if (Session["doctype"] != null)
            {

                if (Session["doctype"].ToString() == "Will")
                {
                    checkfinancial = "select distinct bd.First_Name as beneficiary , c.Proportion ,a.First_Name as altbeneficiary , b.alternateproportion   from BeneficiaryDetails a inner join Alternate_BeneficiaryAssets b on a.bpId=b.alternatebenefciaryid inner join BeneficiaryAssets c on a.tId=c.tid inner join BeneficiaryDetails bd on c.Beneficiary_ID=bd.bpId  where a.tId = " + Convert.ToInt32(Session["distid"]) + " and a.doctype = 'Will' and c.Type = 2";
                }

                if (Session["doctype"].ToString() == "POA")
                {
                    checkfinancial = "select distinct bd.First_Name as beneficiary , c.Proportion ,a.First_Name as altbeneficiary , b.alternateproportion   from BeneficiaryDetails a inner join Alternate_BeneficiaryAssets b on a.bpId=b.alternatebenefciaryid inner join BeneficiaryAssets c on a.tId=c.tid inner join BeneficiaryDetails bd on c.Beneficiary_ID=bd.bpId  where a.tId = " + Convert.ToInt32(Session["distid"]) + "  and a.doctype = 'POA' and c.Type = 2 ";
                }


                if (Session["doctype"].ToString() == "GiftDeeds")
                {
                    checkfinancial = "select distinct bd.First_Name as beneficiary , c.Proportion ,a.First_Name as altbeneficiary , b.alternateproportion   from BeneficiaryDetails a inner join Alternate_BeneficiaryAssets b on a.bpId=b.alternatebenefciaryid inner join BeneficiaryAssets c on a.tId=c.tid inner join BeneficiaryDetails bd on c.Beneficiary_ID=bd.bpId  where a.tId = " + Convert.ToInt32(Session["distid"]) + "  and a.doctype = 'GiftDeeds' and c.Type = 2";
                }





            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }










            SqlDataAdapter chkfinancialda = new SqlDataAdapter(checkfinancial, con);
            DataTable chkfinancialdt = new DataTable();
            chkfinancialda.Fill(chkfinancialdt);
            string assetcat = "";
            string assettype = "";

            if (chkfinancialdt.Rows.Count > 0)
            {
                for (int j = 0; j < 1; j++)
                {

                    financialstructure += "<div class='row'>" +
      "<div class='col-lg-12'>" +
      "<div id='accordion001'>" +
      "<div class='card mb-2 border border-success'>" +
      "<div class='card-header'>" +
      "<button type='button' class='btn btn-link shadow - none text - success' data-toggle='collapse' data-target='#multipleaccordion-" + j + "' aria-expanded='true' aria-controls='collapse-22'>" +
      "(Multiple)" +
      "</button>" +
      "</div>" +
      "<div id='multipleaccordion-" + j + "' class='collapse' data-parent='#accordion001'>" +
      "<div class='card-body'>";


                    if (chkfinancialdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < chkfinancialdt.Rows.Count; i++)
                        {






                            financialstructure += "<div class='row'>" +
                               "<div class='col-sm-3'>" +
                               "<label for='input-1'>Beneficiary</label>" +
                               "<input type='text' value='" + chkfinancialdt.Rows[i]["beneficiary"].ToString() + "'  readonly='true' class='form-control' id='' />" +
                               "</div>" +


                               "<div class='col-sm-3'>" +
                               "<label for='input-1'>Proportion</label>" +
                               "<input type='text' value='" + chkfinancialdt.Rows[i]["Proportion"].ToString() + "' id=''  readonly='true' class='form-control' />" +
                               "</div>" +



                                "<div class='col-sm-3'>" +
                               "<label for='input-1'>Alternate Beneficiary</label>" +
                               "<input type='text' value='" + chkfinancialdt.Rows[i]["altbeneficiary"].ToString() + "'  readonly='true' class='form-control' id='' />" +
                               "</div>" +


                                "<div class='col-sm-3'>" +
                               "<label for='input-1'>Alternate Proportion</label>" +
                               "<input type='text' value='" + chkfinancialdt.Rows[i]["alternateproportion"].ToString() + "'  readonly='true' class='form-control' id='' />" +
                               "</div>" +
                            "</div>";



                        }





                    }


                    financialstructure += "</div>" +
                         "</div>" +
                         "</div>" +
                         "</div>";

                }
            }



















            con.Close();



            //end





            return financialstructure;

        }

















    }
}