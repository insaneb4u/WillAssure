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
using Newtonsoft.Json.Linq;

namespace WillAssure.Controllers
{
    public class AddMainAssetsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        string json = "";
        // GET: AddMainAssets
        public ActionResult AddMainAssetsIndex(string success)
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
            //if (Session["tid"] == null)
            //{
            //    ViewBag.Message = "link"
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







            






                return View("~/Views/AddMainAssets/AddMainAssetsPageContent.cshtml");
        }



        public string  jstruct()
        {
            string final = "";

            if (Session["distid"] != null)
            {

                if (Session["distid"].ToString() != "")
                {

                    con.Open();
                    string query = "select a.aiid , c.AssetsType , d.AssetsCategory , a.tid , a.docid , a.Json from AssetInformation a  inner join TestatorDetails b on a.tid=b.tId inner join AssetsType c on a.atId = c.atId inner join AssetsCategory d on a.amId=d.amId inner join users e on e.uId=b.uId  where b.tid = " + Convert.ToInt32(Session["distid"]) + "   ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    string data = "";

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string getjson = dt.Rows[i]["Json"].ToString();


                            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                            foreach (var kv in dict)
                            {
                                final = final + kv.Key + ":" + kv.Value;
                            }


                        }
                    }

                    



                }

            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }



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




        //public string GenerateColumns()
        //{
        //    string final = "";

        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("SP_AssetColumns", con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    string data = "";

        //    if (dt.Rows.Count > 0)
        //    {







        //        data = data + "<option value=''>--Select--</option><option value='1' >" + dt.Rows[0]["DueDate"].ToString() + "</option>" +
        //        data + "<option value='2' >" + dt.Rows[0]["CurrentStatus"].ToString() + "</option>" +
        //        data + "<option value='3' >" + dt.Rows[0]["IssuedBy"].ToString() + "</option>" +
        //        data + "<option value='4' >" + dt.Rows[0]["Location"].ToString() + "</option>" +
        //        data + "<option value='5' >" + dt.Rows[0]["Identifier"].ToString() + "</option>" +
        //        data + "<option value='6' >" + dt.Rows[0]["assetsValue"].ToString() + "</option>" +
        //        data + "<option value='7' >" + dt.Rows[0]["CertificateNumber"].ToString() + "</option>" +
        //        data + "<option value='8' >" + dt.Rows[0]["PropertyDescription"].ToString() + "</option>" +
        //        data + "<option value='9' >" + dt.Rows[0]["Qty"].ToString() + "</option>" +
        //        data + "<option value='10' >" + dt.Rows[0]["Weight"].ToString() + "</option>" +
        //        data + "<option value='11' >" + dt.Rows[0]["OwnerShip"].ToString() + "</option>" +
        //        data + "<option value='12' >" + dt.Rows[0]["Remark"].ToString() + "</option>" +
        //        data + "<option value='13' >" + dt.Rows[0]["Nomination"].ToString() + "</option>" +
        //        data + "<option value='14' >" + dt.Rows[0]["NomineeDetails"].ToString() + "</option>" +
        //        data + "<option value='15' >" + dt.Rows[0]["Name"].ToString() + "</option>" +
        //        data + "<option value='16' >" + dt.Rows[0]["RegisteredAddress"].ToString() + "</option>" +
        //        data + "<option value='17' >" + dt.Rows[0]["PermanentAddress"].ToString() + "</option>" +
        //        data + "<option value='18' >" + dt.Rows[0]["Identity_proof"].ToString() + "</option>" +
        //        data + "<option value='19' >" + dt.Rows[0]["Identity_proof_value"].ToString() + "</option>" +
        //        data + "<option value='20' >" + dt.Rows[0]["Alt_Identity_proof"].ToString() + "</option>" +
        //        data + "<option value='21' >" + dt.Rows[0]["Alt_Identity_proof_value"].ToString() + "</option>" +
        //        data + "<option value='22' >" + dt.Rows[0]["Phone"].ToString() + "</option>" +
        //        data + "<option value='23' >" + dt.Rows[0]["Mobile"].ToString() + "</option>" +
        //        data + "<option value='24' >" + dt.Rows[0]["Amount"].ToString() + "</option>";







        //    }





        //    con.Open();
        //    string query = "select * from AssetsCategory";
        //    SqlDataAdapter da2 = new SqlDataAdapter(query, con);
        //    DataTable dt2 = new DataTable();
        //    da2.Fill(dt2);
        //    con.Close();
        //    string data2 = "";

        //    if (dt2.Rows.Count > 0)
        //    {







        //        for (int i = 0; i < dt2.Rows.Count; i++)
        //        {




        //            data2 = data2 + "<option value=" + dt2.Rows[i]["amId"].ToString() + " >" + dt2.Rows[i]["AssetsCategory"].ToString() + "</option>";



        //        }







        //    }







        //    final = "<div class='col-sm-4'><div class='form-group'><label for='input-1'>Select Asset</label><select id='ddlasset' class='form-control input-shadow'  onChange='getassetcat(this.value)'><option value='0' >--Select--</option>" + data2 + "</select></div></div>            <div class='col-sm-4'><div class='form-group'><label for='input-1'>Select Asset</label><select id='ddlasset' class='form-control input-shadow'  onChange='getassetcolumntext(this.options[this.selectedIndex].innerHTML)'><option value='0' >--Select--</option>" + data + "</select></div></div>   <div class='col-sm-4'><div class='form-group'><label for='input-1'>Values</label><input type='text' class='form-control input-shadow'  onchange=bar2(this.value)  placeholder='Enter Value For Your Asset'/></div></div>";




        //    return final;
        //}

        public String BindAssetCategoryDDL()
        {
            int response = Convert.ToInt32(Request["send"]);
            TempData["atid"] = response;
            con.Open();
            string query = "select * from AssetsCategory where atId = "+ response + "";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value='' >--Select--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["amId"].ToString() + " >" + dt.Rows[i]["AssetsCategory"].ToString() + "</option>";



                }




            }

            return data;

        }


        public string  OnChangeDDLCat()
        {
            int response = Convert.ToInt32(Request["send"]);
            TempData["amid"] = response;
            con.Open();
            string query = "select * from AssetsInfo where amId = "+response+" ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt3 = new DataTable();
            da.Fill(dt3);
            con.Close();
            string data = "";
            string column = "";
            string finalstruct = "";
            MainAssetsModel MAM = new MainAssetsModel();
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt3.Rows[i]["DueDate"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["DueDate"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));

                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.dueDate = dt3.Rows[i]["DueDate"].ToString();

                    }

                    if (dt3.Rows[i]["DueDateControls"].ToString() != "")
                    {
                     
                        column = column + "<input type=" + dt3.Rows[i]["DueDateControls"].ToString() + "   class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.dueDateControls = dt3.Rows[i]["DueDateControls"].ToString();
                    }


                    if (dt3.Rows[i]["CurrentStatus"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["CurrentStatus"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));

                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.CurrentStatus = dt3.Rows[i]["CurrentStatus"].ToString();
                    }

                    if (dt3.Rows[i]["CurrentStatusControls"].ToString() != "")
                    {

                        if (dt3.Rows[i]["CurrentStatusControls"].ToString() == "RadioButton" && dt3.Rows[i]["CurrentStatusValues"].ToString() != "")
                        {

                            string testString = dt3.Rows[i]["CurrentStatusValues"].ToString();
                            ArrayList result = new ArrayList(testString.Split('/'));

                            column = column + " <br> <label class='radio-inline' >  <input type='radio'  id='ddlrole' name='Currentradio' value=" + result[0]+" checked> " + result[0]+ "</label>  <label class='radio - inline'> <input type='radio' id='ddlrole' name='Currentradio'  value=" + result[1] + ">" + result[1]+ "</label></div></div>";
                           

                        }
                      
                        MAM.CurrentStatusValues = dt3.Rows[i]["CurrentStatusValues"].ToString();

                    }




                    if (dt3.Rows[i]["IssuedBy"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["IssuedBy"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));

                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.IssuedBy = dt3.Rows[i]["IssuedBy"].ToString();
                    }

                    if (dt3.Rows[i]["IssuedByControls"].ToString() != "")
                    {
                       
                        column = column + "<input type=" + dt3.Rows[i]["IssuedByControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.column = dt3.Rows[i]["IssuedByControls"].ToString();

                    }



                    if (dt3.Rows[i]["Location"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Location"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));

                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Location = dt3.Rows[i]["Location"].ToString();
                    }

                    if (dt3.Rows[i]["LocationControls"].ToString() != "")
                    {
                        if (dt3.Rows[i]["LocationControls"].ToString() == "TextArea")
                        {

                            

                            column = column + "<textarea class='form-control input-shadow validate[required]' name='inputName'></textarea></div></div>";
                         

                        }
                        else
                        {
                            column = column + "<input type=" + dt3.Rows[i]["LocationControls"].ToString() + " class='form-control input-shadow' /></div></div>";
                            
                        }
                        MAM.LocationControls = dt3.Rows[i]["LocationControls"].ToString();
                    }



                    if (dt3.Rows[i]["Identifier"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Identifier"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));

                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Identifier = dt3.Rows[i]["Identifier"].ToString();
                    }

                    if (dt3.Rows[i]["IdentifierControls"].ToString() != "")
                    {
                      
                        column = column + "<input type=" + dt3.Rows[i]["IdentifierControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName'/></div></div>";
                        MAM.IdentifierControls = dt3.Rows[i]["IdentifierControls"].ToString();
                    }



                    if (dt3.Rows[i]["assetsValue"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["assetsValue"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.assetsValue = dt3.Rows[i]["assetsValue"].ToString();
                    }
                    if (dt3.Rows[i]["assetsValueControls"].ToString() != "")
                    {
                        
                        column = column + "<input type=" + dt3.Rows[i]["assetsValueControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.assetsValueControls = dt3.Rows[i]["assetsValueControls"].ToString();
                    }

                    if (dt3.Rows[i]["CertificateNumber"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["CertificateNumber"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.CertificateNumber = dt3.Rows[i]["CertificateNumber"].ToString();
                    }
                    if (dt3.Rows[i]["CertificateNumberControls"].ToString() != "")
                    {
                    
                        column = column + "<input type=" + dt3.Rows[i]["CertificateNumberControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.CertificateNumberControls = dt3.Rows[i]["CertificateNumberControls"].ToString();
                    }

                    if (dt3.Rows[i]["PropertyDescription"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["PropertyDescription"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.PropertyDescription = dt3.Rows[i]["PropertyDescription"].ToString();
                    }

                    if (dt3.Rows[i]["PropertyDescriptionControls"].ToString() != "")
                    {
                      
                        column = column + "<input type=" + dt3.Rows[i]["PropertyDescriptionControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName'/></div></div>";
                        MAM.PropertyDescriptionControls = dt3.Rows[i]["PropertyDescriptionControls"].ToString();

                    }

                    if (dt3.Rows[i]["Qty"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Qty"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Qty = dt3.Rows[i]["Qty"].ToString();
                    }
                    if (dt3.Rows[i]["QtyControls"].ToString() != "")
                    {
                     
                        column = column + "<input type=" + dt3.Rows[i]["QtyControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.QtyControls = dt3.Rows[i]["QtyControls"].ToString();
                    }

                    if (dt3.Rows[i]["Weight"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Weight"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Weight = dt3.Rows[i]["Weight"].ToString();
                    }
                    if (dt3.Rows[i]["WeightControls"].ToString() != "")
                    {
                       
                        column = column + "<input type=" + dt3.Rows[i]["WeightControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.WeightControls = dt3.Rows[i]["WeightControls"].ToString();
                    }

                    if (dt3.Rows[i]["OwnerShip"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["OwnerShip"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.OwnerShip = dt3.Rows[i]["OwnerShip"].ToString();
                    }
                    if (dt3.Rows[i]["OwnerShipControls"].ToString() != "")
                    {
                        if (dt3.Rows[i]["OwnerShipControls"].ToString() == "RadioButton" && dt3.Rows[i]["OwnerShipValues"].ToString() != "")
                        {

                            string testString = dt3.Rows[i]["OwnerShipValues"].ToString();
                            ArrayList result = new ArrayList(testString.Split('/'));

                            column = column + " <br> <label class='radio-inline' >  <input type='radio' id='ddlrole' name='ownershipRadio' value=" + result[0] + " checked> " + result[0] + "</label>  <label class='radio - inline'> <input type='radio' id='ddlrole' name='ownershipRadio' value=" + result[1] + ">" + result[1] + "</label></div></div>";


                        }
                       
                        MAM.OwnerShipValues = dt3.Rows[i]["OwnerShipValues"].ToString();


                    }
                   
                    if (dt3.Rows[i]["Remark"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Remark"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Remark = dt3.Rows[i]["Remark"].ToString();
                    }
                    if (dt3.Rows[i]["RemarkControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["RemarkControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.RemarkControls = dt3.Rows[i]["RemarkControls"].ToString();
                    }
                
                    if (dt3.Rows[i]["Nomination"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Nomination"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Nomination = dt3.Rows[i]["Nomination"].ToString();
                    }


                    if (dt3.Rows[i]["NominationControls"].ToString() != "")
                    {
                        if (dt3.Rows[i]["NominationControls"].ToString() == "RadioButton" && dt3.Rows[i]["NominationValues"].ToString() != "")
                        {

                            string testString = dt3.Rows[i]["NominationValues"].ToString();
                            ArrayList result = new ArrayList(testString.Split('/'));

                            column = column + " <br> <label class='radio-inline' >  <input type='radio' id='ddlrole' name='nominationradio'  onchange='getstatusone(this.value)' value=" + result[0] + " > " + result[0] + "</label>  <label class='radio - inline'> <input type='radio' id='ddlrole'  onchange='getstatustwo(this.value)' name='nominationradio' value=" + result[1] + ">" + result[1] + "</label></div></div>";



                        }
                        else
                        {
                            column = column + "<input type=" + dt3.Rows[i]["NominationControls"].ToString() + " name='inputName' id='txtnominee' class='form-control input-shadow' /> </div></div>";
                        }

                        MAM.NominationControls = dt3.Rows[i]["NominationControls"].ToString();

                    }
                  
                    if (dt3.Rows[i]["NomineeDetails"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["NomineeDetails"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.NomineeDetails = dt3.Rows[i]["NomineeDetails"].ToString();
                    }


                    if (dt3.Rows[i]["NomineeDetailsControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["NomineeDetailsControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' id='txtnominee' /> </div></div>";
                        MAM.NomineeDetailsControls = dt3.Rows[i]["NomineeDetailsControls"].ToString();
                    }
       
                    if (dt3.Rows[i]["Name"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Name"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Name = dt3.Rows[i]["Name"].ToString();

                    }
                    if (dt3.Rows[i]["NameControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["NameControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.NameControls = dt3.Rows[i]["NameControls"].ToString();
                    }
                   
                    if (dt3.Rows[i]["RegisteredAddress"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["RegisteredAddress"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.RegisteredAddress = dt3.Rows[i]["RegisteredAddress"].ToString();
                    }
                    if (dt3.Rows[i]["RegisteredAddressControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["RegisteredAddressControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.RegisteredAddressControls = dt3.Rows[i]["RegisteredAddressControls"].ToString();
                    }
                 
                    if (dt3.Rows[i]["PermanentAddress"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["PermanentAddress"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.PermanentAddress = dt3.Rows[i]["PermanentAddress"].ToString();
                    }
                    if (dt3.Rows[i]["PermanentAddressControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["PermanentAddressControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.PermanentAddressControls = dt3.Rows[i]["PermanentAddressControls"].ToString();
                    }
                  
                    if (dt3.Rows[i]["Identity_proof"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Identity_proof"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Identity_proof = dt3.Rows[i]["Identity_proof"].ToString();
                    }
                    if (dt3.Rows[i]["Identity_proofControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Identity_proofControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.Identity_proofControls = dt3.Rows[i]["Identity_proofControls"].ToString();
                    }
            
                    if (dt3.Rows[i]["Identity_proof_value"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Identity_proof_value"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Identity_proof_value = dt3.Rows[i]["Identity_proof_value"].ToString();
                    }
                    if (dt3.Rows[i]["Identity_proof_valueControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Identity_proof_valueControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.Identity_proof_valueControls = dt3.Rows[i]["Identity_proof_valueControls"].ToString();
                    }
                  
                    if (dt3.Rows[i]["Alt_Identity_proof"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Alt_Identity_proof"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Alt_Identity_proof = dt3.Rows[i]["Alt_Identity_proof"].ToString();
                    }
                    if (dt3.Rows[i]["Alt_Identity_proofControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Alt_Identity_proofControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.Alt_Identity_proofControls = dt3.Rows[i]["Alt_Identity_proofControls"].ToString();
                    }
                 
                    if (dt3.Rows[i]["Alt_Identity_proof_value"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Alt_Identity_proof_value"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Alt_Identity_proof_value = dt3.Rows[i]["Alt_Identity_proof_value"].ToString();
                    }
                    if (dt3.Rows[i]["Alt_Identity_proof_valueControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Alt_Identity_proof_valueControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.Alt_Identity_proof_valueControls = dt3.Rows[i]["Alt_Identity_proof_valueControls"].ToString();
                    }
           
                    if (dt3.Rows[i]["Phone"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Phone"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Phone = dt3.Rows[i]["Phone"].ToString();
                    }
                    if (dt3.Rows[i]["PhoneControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["PhoneControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.PhoneControls = dt3.Rows[i]["PhoneControls"].ToString();
                    }
                   
                    if (dt3.Rows[i]["Mobile"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Mobile"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Mobile = dt3.Rows[i]["Mobile"].ToString();


                    }
                    if (dt3.Rows[i]["MobileControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["MobileControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.MobileControls = dt3.Rows[i]["MobileControls"].ToString();

                    }

                    if (dt3.Rows[i]["Amount"].ToString() != "")
                    {
                        string testString = dt3.Rows[i]["Amount"].ToString();
                        ArrayList result = new ArrayList(testString.Split('~'));
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + result[1].ToString() + "</label>";
                        MAM.Amount = dt3.Rows[i]["Amount"].ToString();

                    }
                    if (dt3.Rows[i]["AmountControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["AmountControls"].ToString() + " class='form-control input-shadow validate[required]' name='inputName' /></div></div>";
                        MAM.AmountControls = dt3.Rows[i]["AmountControls"].ToString();
                    }

                    json = JsonConvert.SerializeObject(MAM);
                    TempData["mydata"] = json;
                    finalstruct = column;


                }


            }

            return finalstruct;

        }



        [HttpPost]
        public ActionResult InsertMainAsset(FormCollection collection)
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


            // string response = Convert.ToString(Request["send"]);
            MainAssetsModel MAM = new MainAssetsModel();
            MainAssetsModel JSON = new MainAssetsModel();
            List<MainAssetsModel> assetlist = new List<MainAssetsModel>(); 
            string data = TempData["mydata"].ToString();
            MainAssetsModel obj = JsonConvert.DeserializeObject<MainAssetsModel>(data);
            string value = Convert.ToString(collection["inputName"]);
            var radio1 = Convert.ToString(Request.Form["Currentradio"]);
            var radio2 = Convert.ToString(Request.Form["ownershipRadio"]);
            var radio3 = Convert.ToString(Request.Form["nominationradio"]);
            var tid = Convert.ToString(collection["ddlTid"]);
            string ttid = tid.Replace("true", "");
            string c = "";

            if (obj.dueDate != null)
            {
                string testString = obj.dueDate;
                ArrayList result = new ArrayList(testString.Split('~'));

                c = c + obj.dueDate + ",";
            }
           
         
            if (obj.IssuedBy != null)
            {
                string testString = obj.IssuedBy;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.IssuedBy + ",";
            }
            if (obj.Location != null)
            {
                string testString = obj.Location;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Location + ",";
            }
            if (obj.Identifier != null)
            {
                string testString = obj.Identifier;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Identifier + ",";
            }
            if (obj.assetsValue != null)
            {
                string testString = obj.assetsValue;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.assetsValue + ",";
            }
            if (obj.CertificateNumber != null)
            {
                string testString = obj.CertificateNumber;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.CertificateNumber + ",";
            }
            if (obj.PropertyDescription != null)
            {
                string testString = obj.PropertyDescription;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.PropertyDescription + ",";
            }
            
            if (obj.Qty != null)
            {
                string testString = obj.Qty;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Qty + ",";
            }
           
            if (obj.Weight != null)
            {
                string testString = obj.Weight;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Weight + ",";
            }

            if (obj.Remark != null)
            {
                string testString = obj.Remark;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Remark + ",";
            }
        
            if (obj.NomineeDetails != null)
            {
                string testString = obj.NomineeDetails;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.NomineeDetails + ",";
            }
            if (obj.Name != null)
            {
                string testString = obj.Name;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Name + ",";
            }
            if (obj.RegisteredAddress != null)
            {
                string testString = obj.RegisteredAddress;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.RegisteredAddress + ",";
            }
            if (obj.PermanentAddress != null)
            {
                string testString = obj.PermanentAddress;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.PermanentAddress + ",";
            }
            if (obj.Identity_proof != null)
            {
                string testString = obj.Identity_proof;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Identity_proof + ",";
            }
            if (obj.Identity_proof_value != null)
            {
                string testString = obj.Identity_proof_value;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Identity_proof_value + ",";
            }
            if (obj.Alt_Identity_proof != null)
            {
                string testString = obj.Alt_Identity_proof;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Alt_Identity_proof + ",";
            }
            if (obj.Alt_Identity_proof_value != null)
            {
                string testString = obj.Alt_Identity_proof_value;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Alt_Identity_proof_value + ",";
            }
            if (obj.Phone != null)
            {
                string testString = obj.Phone;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Phone + ",";
            }
            if (obj.Mobile != null)
            {
                string testString = obj.Mobile;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Mobile + ",";
            }
            if (obj.Amount != null)
            {
                string testString = obj.Amount;
                ArrayList result = new ArrayList(testString.Split('~'));
                c = c + obj.Amount + ",";
            }







            var itemToAdd = new JObject();
            ArrayList Column = new ArrayList(c.Split(','));
            ArrayList Values = new ArrayList(value.Split(','));
            
            JArray jsonArray6 = new JArray();


            ArrayList NewList = new ArrayList();
            NewList.AddRange(Column);
            NewList.AddRange(Values);

            Dictionary<string, string> dd = new Dictionary<string, string>();
            for (int i = 0; i <= Column.Count; i++)
            {
                if (Column[i].ToString() != "")
                {
                    dd.Add(Column[i].ToString(), Values[i].ToString());
                }
                else
                {
                    break;
                }
                
            }

            if (obj.CurrentStatus != null)
            {


                dd.Add(obj.CurrentStatus, radio1.ToString());
            }


            if (obj.OwnerShip != null)
            {
                dd.Add(obj.OwnerShip, radio2.ToString());
            }

            if (obj.Nomination != null)
            {
                
                dd.Add(obj.Nomination, radio3.ToString());
            }
            if (Session["aiid"] == null)
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

            //if (Session["tid"] != null)
            //{

            if (Session["doctype"].ToString() == "Will")
            {
                
                string json = JsonConvert.SerializeObject(dd);
                int amid = Convert.ToInt32(TempData["amid"]);



                con.Open();
                string qcheck = "SELECT count(*) FROM AssetInformation where amId = " + amid + "  ";
                SqlCommand cmdchk = new SqlCommand(qcheck,con);
                int count = (int)cmdchk.ExecuteScalar();
                con.Close();

                if (count > 0)
                {
                    Response.Write("<script>alert('Asset Category Already Mapped Please Select Another Asset')</script>");
                }
                else
                {

                    con.Open();
                    string query = "insert into AssetInformation (atId,amId,Json,tid,uId) values (" + TempData["atid"] + " , " + amid + " ,'" + json + "' , " + ttid + " , " + Convert.ToInt32(Session["uuid"]) + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    string query2 = "select top 1 * from AssetInformation order by aiid desc";
                    SqlDataAdapter da = new SqlDataAdapter(query2, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        Session["aiid"] = Convert.ToInt32(dt.Rows[0]["aiid"]);

                    }
                    con.Close();

                    con.Open();
                    string query22 = "update AssetInformation set doctype = 'Will' where aiid = " + Session["aiid"] + "  ";
                    SqlCommand cmd22 = new SqlCommand(query22, con);
                    cmd22.ExecuteNonQuery();
                    con.Close();
                    ViewBag.Message = "Verified";
                }




                

              



               
            }





            if (Session["doctype"].ToString() == "POA")
            {
                string json = JsonConvert.SerializeObject(dd);
                int amid = Convert.ToInt32(TempData["amid"]);


                con.Open();
                string qcheck = "SELECT count(*) FROM AssetInformation where amId = " + amid + "  ";
                SqlCommand cmdchk = new SqlCommand(qcheck, con);
                int count = (int)cmdchk.ExecuteScalar();
                con.Close();

                if (count > 0)
                {
                    Response.Redirect("<script>alert('Asset Category Already Mapped Please Select Another Asset')</script>");
                }
                else
                {
                    con.Open();
                    string query = "insert into AssetInformation (atId,amId,Json,tid,uId) values (" + TempData["atid"] + " , " + amid + " ,'" + json + "' , " + ttid + " , " + Convert.ToInt32(Session["uuid"]) + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    string query2 = "select top 1 * from AssetInformation order by aiid desc";
                    SqlDataAdapter da = new SqlDataAdapter(query2, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        Session["aiid"] = Convert.ToInt32(dt.Rows[0]["aiid"]);

                    }
                    con.Close();

                    con.Open();
                    string query22 = "update AssetInformation set doctype = 'POA' where aiid = " + Session["aiid"] + "  ";
                    SqlCommand cmd22 = new SqlCommand(query22, con);
                    cmd22.ExecuteNonQuery();
                    con.Close();
                    ViewBag.Message = "Verified";
                }

               

            }





            if (Session["doctype"].ToString() == "Giftdeeds")
            {
                string json = JsonConvert.SerializeObject(dd);
                int amid = Convert.ToInt32(TempData["amid"]);


                con.Open();
                string qcheck = "SELECT count(*) FROM AssetInformation where amId = " + amid + "  ";
                SqlCommand cmdchk = new SqlCommand(qcheck, con);
                int count = (int)cmdchk.ExecuteScalar();
                con.Close();

                if (count > 0)
                {
                    Response.Redirect("<script>alert('Asset Category Already Mapped Please Select Another Asset')</script>");
                }
                else
                {
                    con.Open();
                    string query = "insert into AssetInformation (atId,amId,Json,tid,uId) values (" + TempData["atid"] + " , " + amid + " ,'" + json + "' , " + ttid + " , " + Convert.ToInt32(Session["uuid"]) + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    string query2 = "select top 1 * from AssetInformation order by aiid desc";
                    SqlDataAdapter da = new SqlDataAdapter(query2, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        Session["aiid"] = Convert.ToInt32(dt.Rows[0]["aiid"]);

                    }
                    con.Close();



                    con.Open();
                    string query22 = "update AssetInformation set doctype = 'Giftdeeds' where aiid = " + Session["aiid"] + "  ";
                    SqlCommand cmd22 = new SqlCommand(query22, con);
                    cmd22.ExecuteNonQuery();
                    con.Close();


                    ViewBag.Message = "Verified";
                }


               
            }






            con.Close();
                ModelState.Clear();


            //}
            //else
            //{
            //    ViewBag.Message = "link";

            //}






            return RedirectToAction("AddMainAssetsIndex", "AddMainAssets", new { success = "true" });
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
                    string query2 = "select * from AssetInformation where tId =  " + Convert.ToInt32(dt.Rows[0]["tId"]) + " ";
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
                if (Request["send"] != "")
                {
                    // check for data exists or not for testato family
                    if (value != null)
                    {
                        int Response = Convert.ToInt32(Request["send"]);
                        con.Open();
                        string query1 = "select a.aiid , a.atId , a.amId , a.tid , a.docid , a.Json from AssetInformation a inner join TestatorDetails b on a.tid=b.tId where b.tId = " + value + "   ";
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
            }

          





            return check;

        }














    }
}