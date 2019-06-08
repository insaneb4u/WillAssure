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
    public class AddAssetMappingController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddAssetMapping
        public ActionResult AddAssetMappingIndex(string success)
        {
            if (success == "true")
            {
                ViewBag.Message = "Verified";
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

        
                   
             
      

            

            return View("~/Views/AddAssetMapping/AddAssetMappingPageContent.cshtml");
        }


        public String BindBeneficiaryDDL()
        {

            string final = "";

            string ck = "select type from users where uId =" + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter cda = new SqlDataAdapter(ck, con);
            DataTable cdt = new DataTable();
            cda.Fill(cdt);
            string type = "";
            if (cdt.Rows.Count > 0)
            {
                type = cdt.Rows[0]["type"].ToString();

            }



            int tid = 0;
            string ck2 = "select tId from TestatorDetails where uId =" + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter cda2 = new SqlDataAdapter(ck2, con);
            DataTable cdt2 = new DataTable();
            cda2.Fill(cdt2);
      
            if (cdt2.Rows.Count > 0)
            {
                tid = Convert.ToInt32(cdt2.Rows[0]["tId"]);

            }





            string d = "";



            //d = " select tb.tid,us.Type ,  concat(bd.first_name, '  ', '(benefi)') as name ";
            //d += " from users us  inner join users b ON us.uId = b.linked_user ";
            //d += " left outer join  testatorDetails tb on b.uid = tb.uId ";
            //d += " left outer join testatorFamily tf on tb.tid = tf.tid ";
            //d += " left outer join BeneficiaryDetails bd on tb.tid = bd.tid ";
            //d += " where b.linked_user = " + Convert.ToInt32(Session["uuid"]) + " and tb.tid = " + Convert.ToInt32(Session["distid"]) + "  and tb.tid is not null    and bd.first_name is not null ";
            //d += " union select   tb.tid,us.Type ,  concat(tf.First_Name, '  ', '(FAMILY)') as name ";
            //d += " from users us  inner join users b ON us.uId = b.linked_user ";
            //d += " left outer join   testatorDetails tb  on b.uid = tb.uId ";
            //d += " left outer join testatorFamily tf on tb.tId = tf.tid where ";
            //d += " b.linked_user = " + Convert.ToInt32(Session["uuid"]) + "  and tb.tid = " + Convert.ToInt32(Session["distid"]) + "   and tb.tid is not null and tf.first_name is not null ";



            d = "select * from BeneficiaryDetails where tId = "+tid+"";










            string data = "<option value=''>--Select--</option>";
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



            con.Open();
            string query3 = "select count(*) as counter from AssetsCategory";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            con.Close();
            int count = 0;

            if (dt3.Rows.Count > 0)
            {
                count = Convert.ToInt32(dt3.Rows[0]["counter"]);
            }

            final = data + "~" + count;

            return final;

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

        public JsonResult bindassetcatDDL()
        {


            con.Open();
            string query = "select tId from testatordetails where uId = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            int testatorid = 0;
            if (dt.Rows.Count > 0)
            {

                testatorid = Convert.ToInt32(dt.Rows[0]["tId"]);

            }


            //int response = Convert.ToInt32(Request["send"]);
            List<LoginModel> assetcatlist = new List<LoginModel>();
            string ddlassetcat = "";
            con.Open();
            string query3 = "";

            if (Session["Type"] != null)
            {
                if (Session["Type"].ToString() != "Testator" || Session["Type"].ToString() != "DistributorAdmin")
                {
                    query3 = "select ac.*,at.AssetsType as AssetsType from AssetsCategory ac left join assetstype at on at.atId=ac.atId inner join AssetInformation d on d.amId=ac.amId where d.uId = "+Session["uuid"]+" ";
                }
               
            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

           

            
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            con.Close();


            if (dt3.Rows.Count > 0)
            {

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    LoginModel assetcatdata = new LoginModel();

                    assetcatdata.assetcatid = Convert.ToInt32(dt3.Rows[i]["amId"]);
                    assetcatdata.atId = Convert.ToInt32(dt3.Rows[i]["atId"]);
                    assetcatdata.AssetsType = dt3.Rows[i]["AssetsType"].ToString();
                    assetcatdata.AssetsCategory = dt3.Rows[i]["AssetsCategory"].ToString();
                    assetcatlist.Add(assetcatdata);


                }

            }

            return Json(assetcatlist);
        }





        public JsonResult bindassetcatDDL2()
        {
            //int response = Convert.ToInt32(Request["send"]);
            List<LoginModel> assetcatlist = new List<LoginModel>();
            string ddlassetcat = "";
            con.Open();
            string query3 = "select * from AssetsCategory  ";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            con.Close();


            if (dt3.Rows.Count > 0)
            {

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    LoginModel assetcatdata = new LoginModel();

                    assetcatdata.assetcatid = Convert.ToInt32(dt3.Rows[i]["amId"]);
                    assetcatdata.AssetsCategory = dt3.Rows[i]["AssetsCategory"].ToString();

                    assetcatlist.Add(assetcatdata);


                }

            }

            return Json(assetcatlist);
        }





        public string getassetcolumndata()
        {
            int response = Convert.ToInt32(Request["send"]);
            string final = "";

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


                d = "select aiid , atId , amId  , tid , docid , Json from AssetInformation where  uid = "+Convert.ToInt32(Session["uuid"])+"  ";
            







            con.Open();
            string query3 = "select * from AssetInformation where  uid = "+Convert.ToInt32(Session["uuid"])+"  ";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt = new DataTable();
            da3.Fill(dt);
            con.Close();

            string property = "";
            string structure = "";
            string Identifier = "";
            string ddlscheme = "<option value=''>--Select--</option>";
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





         





                // structure = structure + data;
                //structure = structure + "<div class='col-sm-4'><div class='form-group'>   <label for='input-1'>Instruments</label> <input type='text' class='form-control input-shadow' placeholder='MF Scheme' />     </div></div>";
                //structure = structure + "<div class='col-sm-4'><div class='form-group'>   <label for='input-1'>Proportion</label> <input type='text' class='form-control input-shadow' />     </div></div>";
            }
            //else
            //{
            //    structure = "<label>Scheme</label><select class='form-control input-shadow schemenameclass' id='schemename1'  onchange=getschemename(this.id)><option value='0'>--Select--</option>" + ddlscheme + "</select>";
            //}



            con.Open();
            string query4 = "select count(*) as counter from AssetsCategory";
            SqlDataAdapter da4 = new SqlDataAdapter(query4, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            con.Close();
            int count = 0;

            if (dt4.Rows.Count > 0)
            {
                count = Convert.ToInt32(dt4.Rows[0]["counter"]);
            }

            final = ddlscheme + "~" + count;






            return final;
        }






        public ActionResult InsertBeneficiaryAsset(FormCollection collection)
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



            int Beneficiaryid = 0;
            int AssetId = 0;
            int assetcatid = 0;
            int checknumberofitems = 0;
            int checkweight = 0;
            string getcheckdata = TempData["checkdata"].ToString();


            AssetMappingModel saveasset = new AssetMappingModel();





            ArrayList cheknum = new ArrayList(TempData["calculate"].ToString().Split('~'));

            for (int i = 0; i < cheknum.Count; i++)
            {
                checknumberofitems = Convert.ToInt32(cheknum[0]);
                checkweight = Convert.ToInt32(cheknum[1]);

            }




            string value = Convert.ToString(collection["inputName"]);
            string ddllist = collection["contentList"];

            ArrayList result = new ArrayList(value.Split(','));
            ArrayList dd = new ArrayList(ddllist.Split(','));

            for (int i = 0; i < result.Count; i++)
            {
                saveasset.NumberofItems = Convert.ToInt32(result[0]);
                saveasset.weight = Convert.ToInt32(result[1]);

            }


            for (int i = 0; i < dd.Count; i++)
            {
                Beneficiaryid = Convert.ToInt32(dd[0]);
                AssetId = Convert.ToInt32(dd[1]);
                assetcatid = Convert.ToInt32(dd[2]);
            }

            var radio1 = Convert.ToString(Request.Form["Currentradio"]);
            var radio2 = Convert.ToString(Request.Form["ownershipRadio"]);
            var radio3 = Convert.ToString(Request.Form["nominationradio"]);

            if (saveasset.NumberofItems >= checknumberofitems && saveasset.weight >= checkweight)
            {
                Response.Write("<script>alert('Number of Item Left is " + checknumberofitems + " and Number of Weight Left is " + checkweight + " ')</script>");
            }
            else
            {
                // insert beneficiary asset
                string insertbenefijson = JsonConvert.SerializeObject(saveasset, Newtonsoft.Json.Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                con.Open();
                string inserbeneficiaryasset = "insert into Beneficiary_AssetInfo (bpId,atId,amId,Json) values (" + Beneficiaryid + "," + AssetId + "," + assetcatid + ",'" + insertbenefijson + "')";
                SqlCommand cmd = new SqlCommand(inserbeneficiaryasset, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //end




                con.Open();
                string query = "select * from AssetInformation where amId = " + TempData["amid"] + "";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string data = "";

                if (dt.Rows.Count > 0)
                {
                    string getjson = dt.Rows[0]["Json"].ToString();
                    MainAssetsModel upobj = JsonConvert.DeserializeObject<MainAssetsModel>(getjson);
                    TempData["checkdata"] = getjson;

                    string getcolumn = "";

                    if (upobj.dueDate != null)
                    {
                        getcolumn = getcolumn + upobj.dueDate + "~";
                    }






                    if (upobj.IssuedBy != null)
                    {
                        upobj.IssuedBy = upobj.IssuedBy;
                    }







                    if (upobj.Location != null)
                    {
                        upobj.Location = upobj.Location;
                    }






                    if (upobj.Identifier != null)
                    {
                        upobj.Identifier = upobj.Identifier;
                    }





                    if (upobj.assetsValue != null)
                    {
                        upobj.assetsValue = upobj.assetsValue;
                    }







                    if (upobj.CertificateNumber != null)
                    {
                        upobj.CertificateNumber = upobj.CertificateNumber;
                    }






                    if (upobj.DescriptionTypeofItem != null)
                    {
                        upobj.DescriptionTypeofItem = upobj.DescriptionTypeofItem;
                    }





                    if (upobj.NumberofItems != null)
                    {
                        int cal = Convert.ToInt32(upobj.NumberofItems) - Convert.ToInt32(saveasset.NumberofItems);
                        upobj.NumberofItems = cal.ToString();
                    }





                    if (upobj.Weight != null)
                    {


                        int cal = Convert.ToInt32(upobj.Weight) - Convert.ToInt32(saveasset.weight);
                        upobj.Weight = cal.ToString();
                    }









                    if (upobj.Remark != null)
                    {
                        upobj.Remark = upobj.Remark;
                    }
                    if (upobj.RemarkControls != null)
                    {
                        upobj.RemarkControls = "";
                    }





                    if (upobj.NomineeDetails != null)
                    {
                        upobj.NomineeDetails = upobj.NomineeDetails;
                    }
                    if (upobj.NominationControls != null)
                    {
                        upobj.NominationControls = "";
                    }





                    if (upobj.Name != null)
                    {
                        upobj.Name = upobj.Name;
                    }
                    if (upobj.NameControls != null)
                    {
                        upobj.NameControls = "";
                    }




                    if (upobj.RegisteredAddress != null)
                    {
                        upobj.RegisteredAddress = upobj.RegisteredAddress;
                    }

                    if (upobj.RegisteredAddressControls != null)
                    {
                        upobj.RegisteredAddressControls = "";
                    }




                    if (upobj.PermanentAddress != null)
                    {
                        upobj.PermanentAddress = upobj.PermanentAddress;
                    }
                    if (upobj.PermanentAddressControls != null)
                    {
                        upobj.PermanentAddressControls = "";
                    }





                    if (upobj.Identity_proof != null)
                    {
                        upobj.Identity_proof = upobj.Identity_proof;
                    }
                    if (upobj.Identity_proofControls != null)
                    {
                        upobj.Identity_proofControls = "";
                    }




                    if (upobj.Identity_proof_value != null)
                    {
                        upobj.Identity_proof_value = upobj.Identity_proof_value;
                    }
                    if (upobj.Identity_proof_valueControls != null)
                    {
                        upobj.Identity_proof_valueControls = "";
                    }





                    if (upobj.Alt_Identity_proof != null)
                    {
                        upobj.Alt_Identity_proof = upobj.Alt_Identity_proof;
                    }
                    if (upobj.Alt_Identity_proofControls != null)
                    {
                        upobj.Alt_Identity_proofControls = "";
                    }






                    if (upobj.Alt_Identity_proof_value != null)
                    {
                        upobj.Alt_Identity_proof_value = upobj.Alt_Identity_proof_value;
                    }
                    if (upobj.Alt_Identity_proofControls != null)
                    {
                        upobj.Alt_Identity_proofControls = "";
                    }






                    if (upobj.Phone != null)
                    {
                        upobj.Phone = upobj.Phone;
                    }
                    if (upobj.PhoneControls != null)
                    {
                        upobj.PhoneControls = "";
                    }




                    if (upobj.Mobile != null)
                    {
                        upobj.Mobile = upobj.Mobile;
                    }
                    if (upobj.MobileControls != null)
                    {
                        upobj.MobileControls = "";
                    }




                    if (upobj.Amount != null)
                    {
                        upobj.Amount = upobj.Amount;
                    }
                    if (upobj.AmountControls != null)
                    {
                        upobj.AmountControls = "";
                    }

                    if (upobj.Address != null)
                    {
                        upobj.Address = "";
                    }
                    if (upobj.CTSNo != null)
                    {
                        upobj.CTSNo = "";
                    }
                    con.Close();
                    string upjson = JsonConvert.SerializeObject(upobj, Newtonsoft.Json.Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    con.Open();
                    string updateassetinfo = "update AssetInformation set Json='" + upjson + "' where amId = " + TempData["amid"] + " ";
                    SqlCommand cm2 = new SqlCommand(updateassetinfo, con);
                    cm2.ExecuteNonQuery();
                    con.Close();
                }
            }








            ModelState.Clear();
            ViewBag.Message = "Verified";

            return View("~/Views/AddAssetMapping/AddAssetMappingPageContent.cshtml");
        }



        public string ddlassetname()
        {
            int response = Convert.ToInt32(Request["send"]);
            string final = "";
            string bindddlname = "<option value=''>--Select--</option>";
            con.Open();
            string query1 = "select aiid , Json from AssetInformation where  uid = "+Convert.ToInt32(Session["uuid"])+"";
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



            con.Open();
            string query4 = "select count(*) as counter from AssetsCategory";
            SqlDataAdapter da4 = new SqlDataAdapter(query4, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            con.Close();
            int count2 = 0;

            if (dt4.Rows.Count > 0)
            {
                count2 = Convert.ToInt32(dt4.Rows[0]["counter"]);
            }

            final = bindddlname + "~" + count2;


            return final;
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
            string assetcat = "";
            string assettype = "";
            string response = Request["send"];
            //string assettype = response.Split('~')[0];
            //string assetcat = response.Split('~')[1];
            string beneficiary = response.Split('~')[2];
            string schemename = response.Split('~')[3];
            string instrument = response.Split('~')[4];
            string proportion = response.Split('~')[5];
            tid = Convert.ToString(response.Split('~')[6]);

            if (tid == "" || tid == null || tid == "undefined")
            {
                tid = Session["distid"].ToString();
            }

            assetcat = Convert.ToString(response.Split('~')[7]);

            con.Open();
            string getassettype = "select atId from AssetsCategory where amId = "+assetcat+" ";
            SqlDataAdapter atda = new SqlDataAdapter(getassettype,con);
            DataTable atdt = new DataTable();
            atda.Fill(atdt);
            if (atdt.Rows.Count > 0)
            {
                assettype = atdt.Rows[0]["atId"].ToString();

            }
            con.Close();


         
         
                con.Open();
                string query = "insert into BeneficiaryAssets (AssetType_ID , AssetCategory_ID , Beneficiary_ID , SchemeName , InstrumentName , Proportion , tid , doctype) values   (  " + assettype + " , " + assetcat + ", " + beneficiary + " , '" + schemename + "' , '" + instrument + "' , '" + proportion + "' , " + Convert.ToInt32(tid) + " , '"+ Session["doctype"].ToString() + "') ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();


            
         

            ModelState.Clear();
            return RedirectToAction("AddAssetMappingIndex", "AddAssetMapping", new { success = "true" });
        }



        public ActionResult InsertMultipleAssetMappeddata(string data, string assettype, string assetcat , string tid , string btnidentify)
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


            string assettyp = "";
            con.Open();
            string getassettype = "select atId from AssetsCategory where amId = " + btnidentify + " ";
            SqlDataAdapter atda = new SqlDataAdapter(getassettype, con);
            DataTable atdt = new DataTable();
            atda.Fill(atdt);
            if (atdt.Rows.Count > 0)
            {
                assettyp = atdt.Rows[0]["atId"].ToString();

            }
            con.Close();


            string response = data;
            string filter = response.Replace(" ", string.Empty).Replace("\n", string.Empty);
            ArrayList result = new ArrayList(filter.Split('~'));

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].ToString() != "")
                {
                    con.Open();
                    result[i].ToString();
                    string query = "insert into BeneficiaryAssets (Beneficiary_ID,SchemeName,InstrumentName,Proportion , tid , AssetType_ID , AssetCategory_ID , doctype) values (" + result[i].ToString() + "," + Convert.ToInt32(tid) + " , "+assettyp+" , "+btnidentify+" , '"+ Session["doctype"].ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }


            con.Open();



            con.Close();
            ModelState.Clear();
            return RedirectToAction("AddAssetMappingIndex", "AddAssetMapping", new { success = "true" });
        }





        public string Filterdata()
        {
            int response = Convert.ToInt32(Request["send"]);

            string data = "<option value=''>--Select--</option>";
            con.Open();
            string query1 = "select aiid, bpId , First_Name from BeneficiaryDetails where  bpId not in ("+ response + ")";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();


            if (dt1.Rows.Count > 0)
            {

                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    data = data + "<option value=" + dt1.Rows[i]["aiid"] + ">" + dt1.Rows[i]["First_Name"] + "</option>";

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
                        string query2 = "select * from BeneficiaryAssets where tid =  " + Convert.ToInt32(dt.Rows[0]["tId"]) + " ";
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

                    if (value != "")
                    {
                        if (value != null)
                        {
                            con.Open();
                            string query1 = "select a.Beneficiary_Asset_ID , a.AssetType_ID , a.AssetCategory_ID , a.SchemeName , a.InstrumentName , a.Beneficiary_ID , a.Proportion , a.tid from BeneficiaryAssets a inner join TestatorDetails b on a.tid=b.tId where b.tId = " + value + "";
                            SqlDataAdapter da = new SqlDataAdapter(query1, con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            //end

                            if (dt.Rows.Count > 0)
                            {
                                string query2 = "Update PageActivity set ActID=1 , Tid=" + Response + " , PageStatus=2  ";
                                SqlCommand cmd = new SqlCommand(query2, con);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                string query2 = "Update PageActivity set ActID=1 , Tid=" + Response + " , PageStatus=1  ";
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
                }
                    

            }





            return check;

        }




    }
}