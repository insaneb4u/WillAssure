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
    public class EditMainAssetsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: EditMainAssets
        public ActionResult EditMainAssetsIndex()
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
            ViewBag.documentlink = "true";
            ViewBag.collapse = "true";


            if (Session["doctype"] != null)
            {
                if (Session["doctype"].ToString() == "Will")
                {
                    ViewBag.view = "Will";
                }


                if (Session["doctype"].ToString() == "POA" || Session["doctype"].ToString() == "GiftDeeds")
                {
                    ViewBag.view = "POA";
                    ViewBag.view = "GiftDeeds";
                }
            }
            else
            {
              return  RedirectToAction("LoginPageIndex", "LoginPage");
            }


           
            return View("~/Views/EditMainAssets/EditMainAssetsPageContent.cshtml");
        }



        public string BindMappedFormData(int value)
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
                testString = Lmlist[22].Action;

            }




            string final = "";
            con.Open();
            string query = "select a.aiid , c.AssetsType , d.AssetsCategory , a.tid , a.docid , a.Json from AssetInformation a  inner join TestatorDetails b on a.tid=b.tId inner join AssetsType c on a.atId = c.atId inner join AssetsCategory d on a.amId=d.amId where a.tid =" + value + "   ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string getjson = dt.Rows[i]["Json"].ToString();


                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                foreach (var kv in dict)
                {
                    final = final + kv.Key + ":" + kv.Value;
                }



                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                    data += "<td>" + final + "</td>";
                    data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                    data += "<td>" + final + "</td>";
                    data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button>  </td></tr>";

                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                    data += "<td>" + final + "</td>";
                    data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button>  </td></tr>";


                }


                if (testString == "0,0,0")
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                    data += "<td>" + final + "</td>";
                   

                }





            }










        
    

            return data;
        }



        public string DeleteMappedRecords(RoleFormModel RFM)
        {
            string final = "";
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            string query1 = "delete from AssetInformation where aiid = "+index+" ";
            SqlCommand cmd = new SqlCommand(query1,con);
            cmd.ExecuteNonQuery();
            con.Close();

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
                testString = Lmlist[22].Action;

            }




           // string final = "";
            con.Open();
            string query = "select a.aiid , c.AssetsType , d.AssetsCategory , a.tid , a.docid , a.Json from AssetInformation a  inner join TestatorDetails b on a.tid=b.tId inner join AssetsType c on a.atId = c.atId inner join AssetsCategory d on a.amId=d.amId inner join users e on e.uId=b.uId  where e.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "   ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string getjson = dt.Rows[i]["Json"].ToString();


                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                foreach (var kv in dict)
                {
                    final = final + kv.Key + ":" + kv.Value;
                }



                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                    data += "<td>" + final + "</td>";
                    data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                    data += "<td>" + final + "</td>";
                    data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button>  </td></tr>";

                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                    data += "<td>" + final + "</td>";
                    data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button>  </td></tr>";


                }


                if (testString == "0,0,0")
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                    data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                    data += "<td>" + final + "</td>";


                }





            }













            return data;
        }





        public int UpdateMappedData()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }


        public string LoadData()
        {
            string data = "";
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
                testString = Lmlist[22].Action;

            }

           

            con.Open();
            string checkuid = "select tId from TestatorDetails  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter checkda = new SqlDataAdapter(checkuid, con);
            DataTable checkdt = new DataTable();
            checkda.Fill(checkdt);
            int chktid = 0;
            if (checkdt.Rows.Count > 0)
            {
                chktid = Convert.ToInt32(checkdt.Rows[0]["tId"]);
            }
            con.Close();

            if (Convert.ToInt32(Session["uuid"]) != 1)
            {
                string final = "";
                con.Open();
                string query = "select a.aiid , c.AssetsType , d.AssetsCategory , a.tid , a.docid , a.Json from AssetInformation a  inner join TestatorDetails b on a.tid=b.tId inner join AssetsType c on a.atId = c.atId inner join AssetsCategory d on a.amId=d.amId where a.tid = " + chktid + "   ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                string keydata = "";
                string key = "";
                string values = "";
                string jstructure = "";

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string getjson = dt.Rows[i]["Json"].ToString();

                         keydata = "";
                         key = "";
                         values = "";
                         jstructure = "";
                        var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                        foreach (var kv in dict)
                        {
                            keydata = kv.Key.Split('~')[1];
                            key = key + keydata + "~";
                            values = values + kv.Value + "~";


                            

                         


                            
                        }


                        ArrayList result1 = new ArrayList(key.Split('~'));
                        ArrayList result2 = new ArrayList(values.Split('~'));

                        ArrayList result3 = new ArrayList();
                        result3.AddRange(result1);
                        result3.AddRange(result2);
                        jstructure = "";
                        for (int k = 0; k < result1.Count; k++)
                        {
                            if (result1[k].ToString() != "")
                            {
                                jstructure = jstructure + "<p>" + result1[k].ToString() + ":" + result2[k].ToString() + "</p></br>";
                            }

                           
                        }



                        if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                        {
                            
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                            data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                            data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
 
                            data += "<td>" + final + "</td>";
                            data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                        }

                        if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                            data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                            data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                            data += "<td>" + final + "</td>";
                            data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button>  </td></tr>";

                        }


                        if (testString == "1,2,3" || testString == "0,2,3")
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                            data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                            data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                            data += "<td>" + final + "</td>";
                            data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button>  </td></tr>";


                        }


                        if (testString == "0,0,0")
                        {

                            


                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                            data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                            data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                            data += "<td>" + jstructure + "</td>";


                        }





                    }
                }
                else // for distributor
                {

                    con.Open();
                    string query22 = "select a.aiid , c.AssetsType , d.AssetsCategory , a.tid , a.docid , a.Json from AssetInformation a  inner join TestatorDetails b on a.tid=b.tId inner join AssetsType c on a.atId = c.atId inner join AssetsCategory d on a.amId=d.amId inner join TestatorDetails e on a.tid=e.tId inner join users f on e.uId=f.uId where f.Linked_user  = " + Convert.ToInt32(Session["uuid"]) + "   ";
                    SqlDataAdapter da22 = new SqlDataAdapter(query22, con);
                    DataTable dt22 = new DataTable();
                    da22.Fill(dt22);
                    con.Close();


                    if (dt22.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt22.Rows.Count; i++)
                        {
                            string getjson = dt22.Rows[i]["Json"].ToString();


                            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                            foreach (var kv in dict)
                            {
                                final = final + kv.Key + ":" + kv.Value;
                            }



                            if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                            {
                                data = data + "<tr class='nr'><td>" + dt22.Rows[i]["aiid"].ToString() + "</td>";
                                data += "<td>" + dt22.Rows[i]["AssetsType"].ToString() + "</td>";
                                data += "<td>" + dt22.Rows[i]["AssetsCategory"].ToString() + "</td>";
                                data += "<td>" + final + "</td>";
                                data += "<td><button type='button'   id='" + dt22.Rows[i]["aiid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                            }

                            if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                            {
                                data = data + "<tr class='nr'><td>" + dt22.Rows[i]["aiid"].ToString() + "</td>";
                                data += "<td>" + dt22.Rows[i]["AssetsType"].ToString() + "</td>";
                                data += "<td>" + dt22.Rows[i]["AssetsCategory"].ToString() + "</td>";
                                data += "<td>" + final + "</td>";
                                data += "<td><button type='button'   id='" + dt22.Rows[i]["aiid"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button>  </td></tr>";

                            }


                            if (testString == "1,2,3" || testString == "0,2,3")
                            {
                                data = data + "<tr class='nr'><td>" + dt22.Rows[i]["aiid"].ToString() + "</td>";
                                data += "<td>" + dt22.Rows[i]["AssetsType"].ToString() + "</td>";
                                data += "<td>" + dt22.Rows[i]["AssetsCategory"].ToString() + "</td>";
                                data += "<td>" + final + "</td>";
                                data += "<td><button type='button'   id='" + dt22.Rows[i]["aiid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt22.Rows[i]["aiid"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button>  </td></tr>";


                            }


                            if (testString == "0,0,0")
                            {
                                data = data + "<tr class='nr'><td>" + dt22.Rows[i]["aiid"].ToString() + "</td>";
                                data += "<td>" + dt22.Rows[i]["AssetsType"].ToString() + "</td>";
                                data += "<td>" + dt22.Rows[i]["AssetsCategory"].ToString() + "</td>";
                                data += "<td>" + final + "</td>";


                            }





                        }
                    }



                }

               













              
            }
            else
            {
                string final = "";
                con.Open();
                string query = "select a.aiid , c.AssetsType , d.AssetsCategory , a.tid , a.docid , a.Json from AssetInformation a  inner join TestatorDetails b on a.tid=b.tId inner join AssetsType c on a.atId = c.atId inner join AssetsCategory d on a.amId=d.amId    ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
             

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string getjson = dt.Rows[i]["Json"].ToString();


                    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                    foreach (var kv in dict)
                    {
                        final = final + kv.Key + ":" + kv.Value;
                    }



                    if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                        data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                        data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                        data += "<td>" + final + "</td>";
                        data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                    }

                    if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                        data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                        data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                        data += "<td>" + final + "</td>";
                        data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button>  </td></tr>";

                    }


                    if (testString == "1,2,3" || testString == "0,2,3")
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                        data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                        data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                        data += "<td>" + final + "</td>";
                        data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button>  </td></tr>";


                    }


                    if (testString == "0,0,0")
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                        data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                        data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                        data += "<td>" + final + "</td>";


                    }





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


    }
}