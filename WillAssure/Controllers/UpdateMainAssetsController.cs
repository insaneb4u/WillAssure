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
using Newtonsoft.Json;
using System.Collections;

namespace WillAssure.Controllers
{
    public class UpdateMainAssetsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateMainAssets
        public ActionResult UpdateMainAssetsIndex(int NestId)
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



            string queryt = "";
            string final = "";
            string structure = "";

            con.Open();

      
            queryt  = "select a.aiid , c.AssetsType , d.AssetsCategory , a.tid , a.docid , a.Json from AssetInformation a  inner join TestatorDetails b on a.tid=b.tId inner join AssetsType c on a.atId = c.atId inner join AssetsCategory d on a.amId=d.amId inner join users e on e.uId=b.uId  where a.aiid = 1";
           
            



            SqlDataAdapter da = new SqlDataAdapter(queryt, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {
                ViewBag.disablefield = "true";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string getjson = dt.Rows[i]["Json"].ToString();

                    ViewBag.assettype = dt.Rows[0]["AssetsType"].ToString();
                    ViewBag.assetcategory = dt.Rows[0]["AssetsCategory"].ToString();


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















            MainAssetsModel mam = new MainAssetsModel();
            mam.aiid = NestId;
            return View("~/Views/UpdateMainAssets/UpdateMainAssetsPageContent.cshtml", mam);
        }


        public ActionResult UpdatingMainAsset(RoleFormModel RFM)
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


            ViewBag.Message = "Verified";
            return View("~/Views/UpdateMainAssets/UpdateMainAssetsPageContent.cshtml");
        }

        public string getdynamicfields()
        {
            string response = Request["send"].ToString();
            string structure = "";

            if (response != "")
            {
                con.Open();
                string query = "select b.aiid , a.AssetsType , c.AssetsCategory , b.Json from AssetsType a inner join  AssetInformation b on a.atId = b.atId inner join AssetsCategory  c on b.amId = c.amId  where b.aiid = " + response + " order by b.aiid asc  ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {




                        structure = structure + "<div class='col-sm-6'>  <label>Assets Type</label>       <input type='text' class='form-control input-shadow' value=" + dt.Rows[i]["AssetsType"].ToString() + " />     </div>";
                        structure = structure + "<div class='col-sm-6'>  <label>Category Type</label>   <input type='text' class='form-control input-shadow' value=" + dt.Rows[i]["AssetsCategory"].ToString() + " /> </div>";
                        string getjson = dt.Rows[i]["Json"].ToString();

                        var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);

                        foreach (var kv in dict)
                        {
                            var k = kv.Key;
                            ArrayList va = new ArrayList(k.Split('~'));
                            for (int j = 0; j < va.Count; j++)
                            {
                                if (va.ToString() != "")
                                {


                                    structure = structure + "<div class='col-sm-6'>  <label>" + va[i].ToString() + "</label>  <input type='text' class='form-control input-shadow' value=" + kv.Value + " />   </div>  ";
                                    break;
                                }
                            }


                            
                        }
                    }



                }
            }
            

            


            return structure;
        }


    }
}