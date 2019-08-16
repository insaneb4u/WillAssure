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

namespace WillAssure.Controllers
{
    public class EditBeneficiaryInstitutionController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: EditBeneficiaryInstitution
        public ActionResult EditBeneficiaryInstitutionIndex()
        {

            ViewBag.documentlink = "true";
            ViewBag.collapse = "true";

            return View("~/Views/EditBeneficiaryInstitution/EditBeneficiaryInstitution.cshtml");
        }


        public string BindInstitutionFormData()
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

         

            con.Open();

     
            string query0 = "select top 1 tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + "    ";

            SqlDataAdapter da0 = new SqlDataAdapter(query0, con);
            DataTable dt0 = new DataTable();
            da0.Fill(dt0);
            int tid = 0;
            if (dt0.Rows.Count > 0)
            {
                tid = Convert.ToInt32(dt0.Rows[0]["tId"]);
            }


       


            string query = "select * from BeneficiaryInstitutions where tid="+tid+"";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[22].Action;

            }


            string regno = "";


            if (dt.Rows.Count > 0)
            {

                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["registrationNo"].ToString() != "0")
                        {
                            regno = dt.Rows[i]["registrationNo"].ToString();
                        }



                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["biId"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                        + "<td>" + regno + "</td>"
                        + "<td>" + dt.Rows[i]["Address"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt.Rows[i]["biId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";
                    }
                }


                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["biId"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                        + "<td>" + regno + "</td>"
                        + "<td>" + dt.Rows[i]["Address"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                        + "<td><button type='button'   id=" + dt.Rows[i]["biId"].ToString() + "    class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }
                }



                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["biId"].ToString() + "</td>"
                          + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                        + "<td>" + regno + "</td>"
                        + "<td>" + dt.Rows[i]["Address"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt.Rows[i]["biId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id=" + dt.Rows[i]["rId"].ToString() + "     class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }

                }



                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["biId"].ToString() + "</td>"
                          + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                        + "<td>" + regno + "</td>"
                        + "<td>" + dt.Rows[i]["Address"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>";

                    }



                }





            }

            return data;
        }



        public string DeleteRolesRecords(RoleFormModel RFM)
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
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            string query = "delete from BeneficiaryInstitutions where biId= "+index+"";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();




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




            con.Open();

            string query0 = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + "  ";
            SqlDataAdapter da0 = new SqlDataAdapter(query0, con);
            DataTable dt0 = new DataTable();
            da0.Fill(dt0);
            int tid = 0;
            if (dt0.Rows.Count > 0)
            {
                tid = Convert.ToInt32(dt0.Rows[0]["tId"]);
            }





            string query1 = "select * from BeneficiaryInstitutions where tid = "+tid+"";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();
            string data = "";
            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[22].Action;

            }

            string regno = "";

            if (dt1.Rows.Count > 0)
            {

                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {


                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {

                        if (dt1.Rows[i]["registrationNo"].ToString() != "0")
                        {
                            regno = dt1.Rows[i]["registrationNo"].ToString();
                        }



                        data = data + "<tr class='nr'><td>" + dt1.Rows[i]["biId"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                        + "<td>" + regno + "</td>"
                        + "<td>" + dt1.Rows[i]["Address"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt1.Rows[i]["biId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";
                    }
                }


                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt1.Rows[i]["biId"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                        + "<td>" + regno + "</td>"
                        + "<td>" + dt1.Rows[i]["Address"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                        + "<td><button type='button'   id=" + dt1.Rows[i]["biId"].ToString() + "    class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }
                }



                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt1.Rows[i]["biId"].ToString() + "</td>"
                          + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                        + "<td>" + regno + "</td>"
                        + "<td>" + dt1.Rows[i]["Address"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt1.Rows[i]["biId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id=" + dt1.Rows[i]["rId"].ToString() + "     class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }

                }



                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt1.Rows[i]["biId"].ToString() + "</td>"
                          + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                        + "<td>" + regno + "</td>"
                        + "<td>" + dt1.Rows[i]["Address"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>";

                    }



                }





            }

            return data;
        }





        public int UpdateRoles()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }



        public string BindTestatorFamilyFormData(int value)
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
            string query1 = "select * from BeneficiaryInstitutions where tid = "+value+"";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();
            string data = "";
           

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[22].Action;

            }

            string regno = "";

            if (dt1.Rows.Count > 0)
            {

                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (dt1.Rows[i]["registrationNo"].ToString() != "0")
                        {
                            regno = dt1.Rows[i]["registrationNo"].ToString();
                        }


                        data = data + "<tr class='nr'><td>" + dt1.Rows[i]["biId"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                        + "<td>" + regno + "</td>"
                        + "<td>" + dt1.Rows[i]["Address"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt1.Rows[i]["biId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";
                    }
                }


                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt1.Rows[i]["biId"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                        + "<td>" + regno + "</td>"
                        + "<td>" + dt1.Rows[i]["Address"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                        + "<td><button type='button'   id=" + dt1.Rows[i]["biId"].ToString() + "    class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }
                }



                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt1.Rows[i]["biId"].ToString() + "</td>"
                          + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                        + "<td>" + regno + "</td>"
                        + "<td>" + dt1.Rows[i]["Address"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt1.Rows[i]["biId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id=" + dt1.Rows[i]["rId"].ToString() + "     class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }

                }



                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt1.Rows[i]["biId"].ToString() + "</td>"
                          + "<td>" + dt1.Rows[i]["Name"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["Type"].ToString() + "</td>"
                        + "<td>" + regno + "</td>"
                        + "<td>" + dt1.Rows[i]["Address"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["City"].ToString() + "</td>"
                        + "<td>" + dt1.Rows[i]["State"].ToString() + "</td>";

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