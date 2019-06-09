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
using System.Net.Mail;
using System.Net;
using System.Collections;

namespace WillAssure.Controllers
{
    public class AddPetCareController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: AddPetCare
        public ActionResult AddPetCareIndex(string success)
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



            PetCareModel pml = new PetCareModel();
            con.Open();
            string querychk11 = "select * from PetCare where tid = " + Session["distid"].ToString() + " ";
            SqlDataAdapter dachk11 = new SqlDataAdapter(querychk11, con);
            DataTable dtchk11 = new DataTable();
            dachk11.Fill(dtchk11);
            if (dtchk11.Rows.Count > 0)
            {
                ViewBag.disablefield = "true";
                pml.petid = Convert.ToInt32(dtchk11.Rows[0]["petid"]);
                pml.petname = dtchk11.Rows[0]["petname"].ToString();
                pml.petage = dtchk11.Rows[0]["petage"].ToString();
                pml.typeofpet = dtchk11.Rows[0]["typeofpet"].ToString();
                pml.amtforpet = dtchk11.Rows[0]["amtforpet"].ToString();
                pml.amtfromwhichasset = dtchk11.Rows[0]["amtfromwhichasset"].ToString();
                pml.responsibelpersonforpet = dtchk11.Rows[0]["responsibelpersonforpet"].ToString();
                pml.Proportion = Convert.ToInt32(dtchk11.Rows[0]["Proportion"]);


                string qqchk = "select AssetsType from AssetsType where atId = " + dtchk11.Rows[0]["assettypeid"].ToString() + "   ";
                SqlDataAdapter dachk = new SqlDataAdapter(qqchk, con);
                DataTable dtchk = new DataTable();
                dachk.Fill(dtchk);
                if (dtchk.Rows.Count > 0)
                {
                    pml.assettypetext = dtchk.Rows[0]["AssetsType"].ToString();
                }

                string qqchk2 = "select AssetsCategory from AssetsCategory where amId = " + dtchk11.Rows[0]["assetcategoryid"].ToString() + "   ";
                SqlDataAdapter dachk2 = new SqlDataAdapter(qqchk2, con);
                DataTable dtchk2 = new DataTable();
                dachk2.Fill(dtchk2);
                if (dtchk2.Rows.Count > 0)
                {
                    pml.assetCategorytext = dtchk2.Rows[0]["AssetsCategory"].ToString();
                }

            }
            con.Close();





            return View("~/Views/AddPetCare/AddPetCarePageContent.cshtml", pml);
        }



        public ActionResult InsertPetcaredata(PetCareModel PM)
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



          



                con.Open();
                string query = "insert into PetCare (petname,petage,typeofpet,amtforpet,amtfromwhichasset,responsibelpersonforpet,tid , assettypeid , assetcategoryid , Proportion) values ('" + PM.petname + "' , " + PM.petage + " , '" + PM.typeofpet + "' , " + PM.amtforpet + " ,'" + PM.amtfromwhichasset + "' , '" + PM.responsibelpersonforpet + "' , " + PM.ddltid + " , " + PM.assettypeid + " , " + PM.assetCategoryid + " , " + PM.Proportion + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Session["totalpetcare"] = PM.Proportion;
                Session["assettypeidforpetcare"] = PM.assettypeid;
                Session["assetcategoryidforpetcare"] = PM.assetCategoryid;


            Session["assetcategoryidforliablities"] = "";
            Session["assetcategorynameforliablities"] = "";
            ViewBag.Message = "Verified";
                ModelState.Clear();






            ViewBag.disablefield = "true";








            return RedirectToAction("AddPetCareIndex", "AddPetCare", new { success = "true" });
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
                    string query2 = "select * from testatorFamily where tId =  " + Convert.ToInt32(dt.Rows[0]["tId"]) + " ";
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



        public String BindAssetTypeDDL()
        {

            con.Open();
            string query = "select * from AssetsType";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["atId"].ToString() + " >" + dt.Rows[i]["AssetsType"].ToString() + "</option> ";



                }



            }

            return data;

        }



        public String BindAssetCategoryDDL()
        {
            int index = Convert.ToInt32(Request["send"]);
            int amid = 0;
            con.Open();
            string query = "select * from AssetsCategory where atId = '" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["amId"].ToString() + " >" + dt.Rows[i]["AssetsCategory"].ToString() + "</option>";



                }




            }

            return data;

        }




        public string FilterProporion()
        {
            string msg = "";
            string response = Request["send"].ToString();
            int value = Convert.ToInt32(response.Split('~')[0]);
            var assetcat = response.Split('~')[1];



            if (Session["totalliablities"] != null)
            {
                if (Session["totalliablities"].ToString() != "")
                {
                    int liabilitiesproportion = Convert.ToInt32(Session["totalliablities"]);

                    if (Session["assetcategorynameforliablities"] != null && Session["assetcategorynameforliablities"].ToString() != "")
                    {
                        if (Session["assetcategorynameforliablities"].ToString() == assetcat)
                        {
                            if (liabilitiesproportion > value)
                            {

                            }
                            else
                            {
                                msg = "true";
                            }

                        }
                    }


                }


            }
            else
            {
                if (!Response.IsRequestBeingRedirected)
                {
                    Response.Redirect("/LoginPage/LoginPageIndex");
                }
            }











            return msg;
        }




        public ActionResult UpdatePetcare(PetCareModel PM)
        {


            con.Open();
            string qqchk2 = "select amId from AssetsCategory where  AssetsCategory= '" + PM.assetCategorytext + "'   ";
            SqlDataAdapter dachk2 = new SqlDataAdapter(qqchk2, con);
            DataTable dtchk2 = new DataTable();
            dachk2.Fill(dtchk2);
            if (dtchk2.Rows.Count > 0)
            {
                PM.assetCategoryid = Convert.ToInt32(dtchk2.Rows[0]["amId"]);
            }




            string qqchk3 = "select atId from AssetsType where AssetsType ='" + PM.assettypetext + "'   ";
            SqlDataAdapter dachk3 = new SqlDataAdapter(qqchk3, con);
            DataTable dtchk3 = new DataTable();
            dachk3.Fill(dtchk3);
            if (dtchk3.Rows.Count > 0)
            {
                PM.assettypeid = Convert.ToInt32(dtchk3.Rows[0]["atId"]);
            }
            con.Close();






            con.Open();
            string query = "update PetCare set petname='" + PM.petname + "'  , petage=" + PM.petage + " , typeofpet='" + PM.typeofpet + "' , amtforpet = " + PM.amtforpet + "  , amtfromwhichasset='" + PM.amtfromwhichasset + "' , responsibelpersonforpet='" + PM.responsibelpersonforpet + "' , tid=" + Convert.ToInt32(Session["distid"]) + " , assettypeid = "+PM.assettypeid+ " , assetcategoryid = "+PM.assetCategoryid+ " , Proportion = "+PM.Proportion+" where petid=" + PM.petid + "  ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.Message = "Verified";






            return RedirectToAction("AddPetCareIndex", "AddPetCare");
        }



      





    }
}