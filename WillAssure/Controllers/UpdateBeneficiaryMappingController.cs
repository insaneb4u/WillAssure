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
using System.Collections;
using Newtonsoft.Json;

namespace WillAssure.Controllers
{
    public class UpdateBeneficiaryMappingController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: UpdateBeneficiaryMapping
        public ActionResult UpdateBeneficiaryMappingIndex(int NestId)
        {

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
            LoginModel MAM = new LoginModel();

            con.Open();
            string query = "select c.atId , b.amId , e.bpId , a.Beneficiary_Asset_ID , e.First_Name , c.AssetsType , b.AssetsCategory , a.SchemeName , a.InstrumentName , a.Proportion from BeneficiaryAssets a inner join AssetsCategory b on a.AssetCategory_ID = b.amId inner join AssetsType c on b.atId = c.atId inner join TestatorDetails d on a.tid = d.tId inner join BeneficiaryDetails e on a.Beneficiary_ID = e.bpId where a.Beneficiary_Asset_ID = " + NestId+" ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            


           


            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   MAM.Beneficiary_Asset_ID = Convert.ToInt32(dt.Rows[i]["Beneficiary_Asset_ID"]);

                   MAM.AssetsType = dt.Rows[i]["AssetsType"].ToString();
                   MAM.assettypeid = Convert.ToInt32(dt.Rows[i]["atId"]);


                   MAM.AssetsCategory = dt.Rows[i]["AssetsCategory"].ToString();
                   MAM.assetcatid = Convert.ToInt32(dt.Rows[i]["amId"]);


                    MAM.SchemeName = dt.Rows[i]["SchemeName"].ToString();
                   MAM.InstrumentName = dt.Rows[i]["InstrumentName"].ToString();
                   MAM.Proportion = dt.Rows[i]["Proportion"].ToString();


                   MAM.Beneficiarytxt = dt.Rows[i]["First_Name"].ToString();
                   MAM.Beneficiaryid = Convert.ToInt32(dt.Rows[i]["bpId"]);
                }





            }

            // asset category of selected asset
            string queryt = "";
            string final = "";
            string structure = "";

            queryt = "select a.aiid , c.AssetsType , d.AssetsCategory , a.tid , a.docid , a.Json from AssetInformation a  inner join TestatorDetails b on a.tid=b.tId inner join AssetsType c on a.atId = c.atId inner join AssetsCategory d on a.amId=d.amId inner join users e on e.uId=b.uId  where a.aiid = 1  ";
            



            SqlDataAdapter da1 = new SqlDataAdapter(queryt, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();


            if (dt1.Rows.Count > 0)
            {
                ViewBag.disablefield = "true";

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string getjson = dt1.Rows[i]["Json"].ToString();

                    ViewBag.assettype = dt1.Rows[0]["AssetsType"].ToString();
                    ViewBag.assetcategory = dt1.Rows[0]["AssetsCategory"].ToString();


                    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                    int count = 0;
                    int index = 0;
                    foreach (var kv in dict)
                    {
                        string removecomma = kv.Key;
                        string first = removecomma.Split('~')[0];
                        string second = removecomma.Split('~')[1];

                        final = final + kv.Key + ":" + kv.Value;




                        if (kv.Value != "")
                        {
                            index = count++;

                            structure = structure + "<form>" +
                         "<div class='col-sm-3'>" +
                          "<div class='form-group'>" +
                          "<input type='hidden' id='col" + index + "' value='" + first + "'  />" +
                          "<input type='hidden' id='c" + index + "' value='" + second + "'  />" +
                          "<label for='input-1'>" + second + "</label>" +
                          "<input type='text' id=" + index + " name='inputtxt' class='form-control' style='width:150px;' value='" + kv.Value + "'   />" +
                          "</div>" +
                          "</div>" +
                          "</form>";

                        }









                    }


                }

                ViewBag.assetdata = structure;
            }
            else
            {
                ViewBag.check = "Blank";
            }







            //end





            return View("~/Views/UpdateBeneficiaryMapping/UpdateBeneficiaryMappingPageContent.cshtml", MAM);
        }




        public ActionResult UpdateBeneficiaryMappingDATA(LoginModel M)
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
                ViewBag.showtitle = "true";
                ViewBag.documentlink = "true";

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


            int assettype = 0;
            int assetcategory = 0;
            int beneficiary = 0;


            string atq = "select atId from AssetsType where AssetsType = '" + M.AssetsType + "' ";
            SqlDataAdapter atda3 = new SqlDataAdapter(atq, con);
            DataTable atdt3 = new DataTable();
            atda3.Fill(atdt3);

            if (atdt3.Rows.Count > 0)
            {
                assettype = Convert.ToInt32(atdt3.Rows[0]["atId"]);
            }




            string catq = "select amId from AssetsCategory where AssetsCategory = '"+ M.AssetsCategory + "' ";
            SqlDataAdapter catda3 = new SqlDataAdapter(catq, con);
            DataTable catdt3 = new DataTable();
            catda3.Fill(catdt3);

            if (catdt3.Rows.Count > 0)
            {
                assettype = Convert.ToInt32(catdt3.Rows[0]["amId"]);
            }





            string beneq = "select bpId from BeneficiaryDetails where First_Name = '"+M.Beneficiarytxt+"' ";
            SqlDataAdapter beneda3 = new SqlDataAdapter(beneq, con);
            DataTable benedt3 = new DataTable();
            beneda3.Fill(benedt3);

            if (benedt3.Rows.Count > 0)
            {
                beneficiary = Convert.ToInt32(benedt3.Rows[0]["bpId"]);
            }






            con.Open();
            string update = "update BeneficiaryAssets set AssetType_ID = "+M.assettypeid+ " , AssetCategory_ID ="+ M.assetcatid + " ,   Beneficiary_ID = "+M.Beneficiaryid+"   ,Proportion =" + M.Proportion+ " where Beneficiary_Asset_ID = "+ M.Beneficiary_Asset_ID+" ";
            SqlCommand cmd = new SqlCommand(update,con);
            cmd.ExecuteNonQuery();

            con.Close();



            return RedirectToAction("UpdateBeneficiaryMappingIndex", "UpdateBeneficiaryMapping" , new { NestId = M.Beneficiary_Asset_ID });
        }


        public String BindBeneficiaryDDL()
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
            string d = "";

            if (type == "Testator")
            {
                d = "select a.aiid, a.bpId , a.First_Name from BeneficiaryDetails a inner join TestatorDetails b on a.tId = b.tId inner join users c on b.uId=c.uId where c.uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            }
            else if (type == "SuperAdmin")
            {
                d = "select a.aiid, a.bpId , a.First_Name from BeneficiaryDetails a inner join TestatorDetails b on a.tId = b.tId  ";
            }
            else
            {

                d = "select a.aiid, a.bpId , a.First_Name from BeneficiaryDetails a inner join TestatorDetails b on a.tId = b.tId inner join users c on b.uId=c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + " ";
            }





            string data = "<option value='0'>--Select--</option>";
            con.Open();

            SqlDataAdapter da1 = new SqlDataAdapter(d, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();


            if (dt1.Rows.Count > 0)
            {

                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    data = data + "<option value=" + dt1.Rows[i]["bpId"] + ">" + dt1.Rows[i]["First_Name"] + "</option>";

                }

            }
            return data;

        }


        public String BindAssetTypeDDL()
        {

            con.Open();
            string query = "select * from AssetsType";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["atId"].ToString() + " >" + dt.Rows[i]["AssetsType"].ToString() + "</option> ";



                }



            }

            return data;

        }

        public string bindassetcatDDL()
        {
            int response = Convert.ToInt32(Request["send"]);
            string ddlassetcat = "<option value=''>--Select--</option>";
            con.Open();
            string query3 = "select * from AssetsCategory where atId = " + response + " ";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            con.Close();


            if (dt3.Rows.Count > 0)
            {

                for (int i = 0; i < dt3.Rows.Count; i++)
                {

                    ddlassetcat = ddlassetcat + "<option value=" + dt3.Rows[i]["amId"] + "  onchange='getassetcatid(this.value)'  >" + dt3.Rows[i]["AssetsCategory"] + "</option>";

                }

            }

            return ddlassetcat;
        }



        public string getassetcolumndata()
        {
           



            con.Open();
            string query3 = "select * from AssetInformation";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt = new DataTable();
            da3.Fill(dt);
            con.Close();

            string property = "";
            string structure = "";
            string Identifier = "";
            string ddlscheme = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string getjson = dt.Rows[i]["Json"].ToString();
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                    foreach (var item in dict)
                    {
                        string testString = item.Key;
                        ArrayList result = new ArrayList(testString.Split('~'));


                        if (result[0].ToString() == "PropertyDescription")
                        {
                            property = result[1].ToString();
                            if (property == "Scheme")
                            {

                                ddlscheme = ddlscheme + "<option value=" + item.Value + " >" + item.Value + "</option>";
                            }

                        }


                        if (result[0].ToString() == "Identifier")
                        {
                            Identifier = result[1].ToString();

                            ddlscheme = ddlscheme + "<option value=" + item.Value + " >" + item.Value + "</option>";
                        }





                    }
                }





                structure = "<label>Scheme</label><select class='form-control input-shadow schemenameclass' id='schemename1'  onchange=getschemename(this.id)><option value='0'>--Select--</option>" + ddlscheme + "</select>";





                // structure = structure + data;
                //structure = structure + "<div class='col-sm-4'><div class='form-group'>   <label for='input-1'>Instruments</label> <input type='text' class='form-control input-shadow' placeholder='MF Scheme' />     </div></div>";
                //structure = structure + "<div class='col-sm-4'><div class='form-group'>   <label for='input-1'>Proportion</label> <input type='text' class='form-control input-shadow' />     </div></div>";
            }
            else
            {
                structure = "<label>Scheme</label><select class='form-control input-shadow schemenameclass' id='schemename1'  onchange=getschemename(this.id)><option value='0'>--Select--</option>" + ddlscheme + "</select>";
            }




            return structure;
        }



        public string ddlassetname()
        {
            

            string bindddlname = "<option value='0'>--Select--</option>";
            con.Open();
            string query1 = "select aiid , Json from AssetInformation";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();
            int index = 2;
            if (dt1.Rows.Count > 0)
            {

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string getjson = dt1.Rows[i]["Json"].ToString();
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                    int count = index++;
                    foreach (var item in dict)
                    {
                        string testString = item.Key;
                        ArrayList result = new ArrayList(testString.Split('~'));


                        if (result[0].ToString() == "IssuedBy")
                        {

                            bindddlname = bindddlname + "   <option value=" + count + ">" + item.Value + "</option>    ";


                        }

                        if (result[0].ToString() == "Identifier")
                        {

                            bindddlname = bindddlname + "   <option value=" + count + ">" + item.Value + "</option>    ";


                        }


                    }



                }



            }


            return bindddlname;
        }



    }
}