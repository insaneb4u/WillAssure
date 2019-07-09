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
            if (TempData["Message"] != null)
            {
                if (TempData["Message"].ToString() == "true")
                {
                    ViewBag.Message = "Verified";
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


            // beneficiary dropdown bind


             string d = "";

            d = "select * from BeneficiaryDetails where tid = "+Convert.ToInt32(Session["distid"])+"";

            string data11 = "<option value='0'>--Select--</option>";
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
            for (int i = 0; i <1; i++)
            {

                res += "<div class='card mb-2 border border-danger' id='accparent'>";

                res += "<div class='card-header'>";
                res += "<button type='button' class='btn btn-link shadow-none text-danger collapsed ' data-toggle='collapse' data-target='#accordio" + i + "' aria-expanded='false' aria-controls='collapse-23'>";
             
                res += "<input type='text' style='display:none;' id='txtassetcat" + i + "'  value='" + i + "' class='form-control' />";
                res += "</button>";
                res += "</div>";
                res += "<div id='accordio" + i + "' class='collapse show  accordiondiv' data-parent='#accordion8'>";


                res += "<div class='card-body'>";
                res += "<div id='main-body" + i + "'>";
               
                res +="<div class='col-sm-3' id='type" + i + "'>";

                res += "<div class='form-group'>";
                res += "<label for='input-1'>Type</label>";
                res += "<br />";
                res += "<form id='testatorform'>";
                res += "<label class='radio-inline'>";
                res += "<input type='radio' id='getvalone' class=" + i + " name='optradio' value='Single' checked>Single";
                res += "</label>";
                res += "<label class='radio-inline'>";
                res += "<input type='radio' id='getvaltwo' class=" + i + " name='optradio' value='Multiple'  >Multiple";
                res += "</label>";
                res += "</form>";
                res += "</div>";
                res += "</div>";
                res += "<div id='parentdiv" + i + "'  class='test'>";
                res += "<div class='row rowdiv' id='beneficiarydetails' >";

                res += "&nbsp;&nbsp;&nbsp;&nbsp;";
                res += "<div class='col-sm-2'>";
                res += "<div class='form-group' id='mainbeneddl" + i + "'>";
                res += "<label for='input-1'>Beneficiary</label><span id='errbene'  style='color:red; display:;'>(*)</span>";
                res += "<select id='ddlbeneficiary" + i + "' onchange='checkbeneficiaryduplicate(this.id,this.value)' name='contentList' class='form-control beneficiaryclass validate[required]'>"+ data11 + "</select>";
                res += "<input type='text' class='form-control' style='display: none' id='ddlbeneficiarytxt' name='name' value='' />";
                res += "</div>";
                res += "</div>";

                res += "<div class='col-sm-2 grandparent'>";
                res += "<div class='form-group parent'>";
                res += "<label for='input-1'>Proportion</label><span id='errproportion' style='color:red;display:;'>(*)</span>";
                res += "<input type='text' autocomplete='off' class='form-control proportioninput validate[required]'  onkeypress='return isNumberKey(event)'   onchange='gettxtproportion(this.id,this.value)' name='rank' id='txtproportion" + i + "' />";
                res += "</div>";
                res += "</div>";
                res += "<div class='col-sm-2' id='totaldiv" + i + "'>";
                res += "<div class='form-group start'>";
                res += "<label for='input-1'>Balance Proportion</label>";
                res += "<input type='text' id='txttotal" + i + "' min=0  class='form-control totalinput' readonly />";
                res += "<button type='button' id='btnremove' style='position:relative; top:-39px; right:-466px;'  value='" + i + "' style='display:;'    class='btn btn-danger  btnremove'><i class='icon-trash'></i></button>";
                res += "</div>";
                res += "</div>";


                res += "<div class='col-sm-2'>";
                res += "<div class='form-group' id='mainbeneddl" + i + "'>";
                res += "<label for='input-1' style='white-space:nowrap'>Alternate Beneficiary</label>";
                res += "<select id='ddlbeneficiaryalt" + i + "' onchange='altcheckbeneficiaryduplicate(this.id,this.value)' name='contentList' class='form-control altbeneficiaryclass '> " + data11 + " </select>";
                res += "<input type='text' class='form-control' style='display: none' id='ddlbeneficiarytxt' name='name' value='' />";
                res += "</div>";
                res += "</div>";




                res += "<div class='col-sm-2' id='singlepropo" + i + "' style='display:none;'>";
                res += "<div class='form-group start'>";
                res += "<label for='input-1'>single Proportion</label>";
                res += "<input type='text' id='txtsingleproportion" + i + "' Value='100'  class='form-control' readonly />";

                res += "</div>";
                res += "</div>";










                res += "</div>";
                res += "</div>";


                res += "<div class='form-group'>";
                res += "&nbsp;&nbsp;&nbsp;&nbsp;<button type='button' id='btnmappingsubmit' value=" + i + "  class='btn btn-primary shadow-primary px-5 btn" + i + "'><i class='icon-lock'></i>Submit</button>";
                res += "&nbsp;&nbsp;&nbsp;&nbsp;<button type='button' id='btnadd'   value='" + i + "' style='display:none;' disabled='disabled'    class='btn btn-success shadow-primary px-5 btnadd" + i + "'><i class='icon-lock'></i>Add Multiple</button>";
                res += "&nbsp;&nbsp;&nbsp;&nbsp;<input type='button' value='Reset' class='btn btn-danger' id='btnreset' />";
                res += " </div>";
                res += " </div>";
                res += " </div>";
                res += " </div>";
                res += " </div>";

            }



           




            return Json(res);
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



        public JsonResult InsertMultipleAssetMappeddata(string data, string assetcat, string tid, string btnidentify)
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
            string assetcatid = "";
            string assettypeid = "";
            string combine = "";

            con.Open();
            string getassettype = "select amId , atId from AssetsCategory where AssetsCategory =  '" + assetcat + "' ";
            SqlDataAdapter atda = new SqlDataAdapter(getassettype, con);
            DataTable atdt = new DataTable();
            atda.Fill(atdt);
            if (atdt.Rows.Count > 0)
            {
                assetcatid = atdt.Rows[0]["amId"].ToString();
                assettypeid = atdt.Rows[0]["atId"].ToString();

            }
            con.Close();

            combine = assetcat + assetcatid;

            string response = data;
            string filter = response.Replace(" ", string.Empty).Replace("\n", string.Empty);
            ArrayList result = new ArrayList(filter.Split('~'));

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].ToString() != "")
                {
                    try
                    {
                        con.Open();
                        result[i].ToString();
                        string query = "insert into BeneficiaryAssets (Beneficiary_ID ,Proportion , alternatebid , tid , doctype,Type,documentstatus,WillType) values (" + result[i].ToString() + "," + Convert.ToInt32(tid) + " , '" + Session["doctype"].ToString() + "',2, 'incompleted','Quick')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {

                        
                    }
                 
                }
            }

            // if records submitted change status for assetinformation
            con.Close();



           


            ModelState.Clear();
            return Json(btnidentify);
        }





        public string BindLastSingleRecords()
        {
            // last financial records
            string financialstructure = "";
            con.Open();
            string checkfinancial = "";





            if (Session["doctype"] != null)
            {

                if (Session["doctype"].ToString() == "Will")
                {
                    checkfinancial = "select a.Beneficiary_Asset_ID , b.First_Name , c.First_Name as alternate , a.Proportion  from BeneficiaryAssets a inner join BeneficiaryDetails b on a.Beneficiary_ID=b.bpId inner join BeneficiaryDetails  c on a.alternatebid=c.bpId where a.Type = 1 and a.WillType = 'Quick' and  a.doctype='Will' and a.tid = " + Convert.ToInt32(Session["distid"])+" ";
                }

                if (Session["doctype"].ToString() == "POA")
                {
                    checkfinancial = "select a.Beneficiary_Asset_ID , b.First_Name , c.First_Name as alternate , a.Proportion  from BeneficiaryAssets a inner join BeneficiaryDetails b on a.Beneficiary_ID=b.bpId inner join BeneficiaryDetails  c on a.alternatebid=c.bpId where a.Type =1 and a.WillType = 'POA' and  a.doctype='Will' and a.tid = " + Convert.ToInt32(Session["distid"]) + " ";
                }


                if (Session["doctype"].ToString() == "GiftDeeds")
                {
                    checkfinancial = "select a.Beneficiary_Asset_ID , b.First_Name , c.First_Name as alternate , a.Proportion  from BeneficiaryAssets a inner join BeneficiaryDetails b on a.Beneficiary_ID=b.bpId inner join BeneficiaryDetails  c on a.alternatebid=c.bpId where a.Type = 1 and a.WillType = 'GiftDeeds' and  a.doctype='Will' and a.tid = " + Convert.ToInt32(Session["distid"]) + "";
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













                for (int i = 0; i < chkfinancialdt.Rows.Count; i++)
                {





                    financialstructure = financialstructure + "<div class='row'>" +
                   "<div class='col-lg-12'>" +
                   "<div id='accordion001'>" +
                   "<div class='card mb-2 border border-success'>" +
                   "<div class='card-header'>" +
                   "<button type='button' class='btn btn-link shadow - none text - success' data-toggle='collapse' data-target='#collapsesingleFA-" + Convert.ToInt32(chkfinancialdt.Rows[i]["Beneficiary_Asset_ID"]) + "' aria-expanded='true' aria-controls='collapse-22'>" +
                   "(Single)" +
                   "</button>" +
                   "</div>" +
                   "<div id='collapsesingleFA-" + Convert.ToInt32(chkfinancialdt.Rows[i]["Beneficiary_Asset_ID"]) + "' class='collapse' data-parent='#accordion001'>" +
                   "<div class='card-body'>" +
                   "<div class='row'>" +
                   "<div class='col-sm-3'>" +
                   "<label for='input-1'>Beneficiary</label>" +
                   "<input type='text' value='" + chkfinancialdt.Rows[i]["First_Name"].ToString() + "'  readonly='true' class='form-control' id='' />" +
                   "</div>" +
                     "<div class='col-sm-3'>" +
                   "<label for='input-1'>Alternate Beneficiary</label>" +
                   "<input type='text' value='" + chkfinancialdt.Rows[i]["alternate"].ToString() + "'  readonly='true' class='form-control' id='' />" +
                   "</div>" +

                   "<div class='col-sm-3'>" +
                   "<label for='input-1'>Proportion</label>" +
                   "<input type='text' value='" + chkfinancialdt.Rows[i]["Proportion"].ToString() + "' id=''  readonly='true' class='form-control' />" +
                   "</div>" +
                   "</div>" +
                   "</div>" +
                   "</div>" +
                   "</div>" +
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





         

              
                    checkfinancial = "select a.Beneficiary_Asset_ID , b.First_Name , c.First_Name as alternate , a.Proportion  from beneficiaryassets a inner join BeneficiaryDetails b on a.Beneficiary_ID=b.bpId inner join BeneficiaryDetails c on b.bpId=c.bpId where Type = 2 and a.WillType = 'Quick' and a.tid = " + Convert.ToInt32(Session["distid"]) + " ";
               









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
                               "<input type='text' value='" + chkfinancialdt.Rows[i]["First_Name"].ToString() + "'  readonly='true' class='form-control' id='' />" +
                               "</div>" +
                               "<div class='col-sm-3'>" +
                               "<label for='input-1'>Alternate Beneficiary</label>" +
                               "<input type='text' value='" + chkfinancialdt.Rows[i]["alternate"].ToString() + "'  readonly='true' class='form-control' id='' />" +
                               "</div>" +

                               "<div class='col-sm-3'>" +
                               "<label for='input-1'>Proportion</label>" +
                               "<input type='text' value='" + chkfinancialdt.Rows[i]["Proportion"].ToString() + "' id=''  readonly='true' class='form-control' />" +
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