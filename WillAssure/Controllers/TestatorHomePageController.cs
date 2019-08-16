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
namespace WillAssure.Controllers
{
    public class TestatorHomePageController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: TestatorHomePage
        public ActionResult TestatorHomePageIndex(string status)
        {
            if(TempData["setamount"] != null)
            {
                if (TempData["setamount"].ToString() != null)
                {
                    ViewBag.documentamount = TempData["setamount"];
                }
            }
          


            if (TempData["status"] != null)
            {
                if (TempData["status"].ToString() == "true")
                {
                    TempData["MakePayment"] = "true";
                    TempData["status"] = "false";
                }

            }




            int testatorid = 0;
            ViewBag.collapse = "true";






            if (Session["uuid"] != null)
            {
                con.Open();
                string query1tt = "select tId from  TestatorDetails where  uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlDataAdapter da1tt = new SqlDataAdapter(query1tt, con);
                DataTable dt1tt = new DataTable();
                da1tt.Fill(dt1tt);
                if (dt1tt.Rows.Count > 0)
                {
                    testatorid = Convert.ToInt32(dt1tt.Rows[0]["tId"]);


                }
                con.Close();










                //////////////////////////////////////////////////////  FOR CHECKING PAYMENT and displaying  ///////////////////////////////////////////////


                con.Open();
                string qq222 = "select PaymentStatus from testatordetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlDataAdapter daa22 = new SqlDataAdapter(qq222, con);
                DataTable paydtt = new DataTable();
                daa22.Fill(paydtt);
                con.Close();

                if (paydtt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(paydtt.Rows[0]["PaymentStatus"]) == 1)
                    {
                        ViewBag.hidepayment = "true";

                        // check will status
                        con.Open();
                        string qry1 = "select WillType , Will ,  Designation  from users where Will = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + "  ";
                        SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                        DataTable dtt1 = new DataTable();
                        daa1.Fill(dtt1);
                        if (dtt1.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dtt1.Rows[0]["Will"]) == 1 && Convert.ToInt32(dtt1.Rows[0]["Designation"]) == 1)
                            {

                                if (dtt1.Rows[0]["WillType"].ToString() == "Quick")
                                {
                                    // display document
                                    ViewBag.Quick = "true";
                                }

                                if (dtt1.Rows[0]["WillType"].ToString() == "Detailed")
                                {
                                    // display document
                                    ViewBag.Detailed = "true";
                                }


















                            }

                        }
                        con.Close();
                        //end


                        // check codocil status
                        con.Open();
                        string qry2 = "select Codocil , Designation  from users where Codocil = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                        SqlDataAdapter daa2 = new SqlDataAdapter(qry2, con);
                        DataTable dtt2 = new DataTable();
                        daa2.Fill(dtt2);
                        if (dtt2.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dtt2.Rows[0]["Codocil"]) == 1 && Convert.ToInt32(dtt2.Rows[0]["Designation"]) == 1)
                            {






                                // display document
                                ViewBag.documentbtn2 = "true";







                            }
                        }
                        con.Close();

                        //end


                        // check Poa status
                        con.Open();
                        string qry4 = "select POA  , Designation  from users where POA = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                        SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                        DataTable dtt4 = new DataTable();
                        daa4.Fill(dtt4);
                        if (dtt4.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dtt4.Rows[0]["POA"]) == 1 && Convert.ToInt32(dtt4.Rows[0]["Designation"]) == 1)
                            {

                                // display document
                                ViewBag.documentbtn3 = "true";



                            }
                        }
                        con.Close();
                        //end


                        // check gift deeds status
                        con.Open();
                        string qry3 = "select Giftdeeds , Designation  from users where Giftdeeds = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                        SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                        DataTable dtt3 = new DataTable();
                        daa3.Fill(dtt3);
                        if (dtt3.Rows.Count > 0)
                        {
                            if (dtt3.Rows[0]["Giftdeeds"] != null)
                            {
                                if (Convert.ToInt32(dtt3.Rows[0]["Giftdeeds"]) == 1 && Convert.ToInt32(dtt3.Rows[0]["Designation"]) == 1)
                                {


                                    // display document
                                    ViewBag.documentbtn4 = "true";




                                }
                            }

                        }
                        con.Close();
                        //end








                        // check LivingWill status
                        con.Open();
                        string qryl2 = "select LivingWill , Designation  from users where LivingWill = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                        SqlDataAdapter daal2 = new SqlDataAdapter(qryl2, con);
                        DataTable dttl2 = new DataTable();
                        daal2.Fill(dttl2);
                        if (dttl2.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dttl2.Rows[0]["LivingWill"]) == 1 && Convert.ToInt32(dttl2.Rows[0]["Designation"]) == 1)
                            {




                                // display document
                                ViewBag.documentbtn5 = "true";








                            }
                        }
                        con.Close();

                        //end
                    }


                }




                //////////////////////////////////////////////////////  END  ///////////////////////////////////////////////





                string OTP = "";
                if (Session["LoginOTP"] != null)
                {
                    OTP = Session["LoginOTP"].ToString();
                    //Session["LoginOTP"] = Eramake.eCryptography.Decrypt(OTP);
                    Session["enteredOTP"] = OTP;
                }
                else
                {
                    RedirectToAction("LoginPageIndex", "LoginPage");
                }

                if (Session["enteredOTP"] == null)
                {
                    RedirectToAction("LoginPageIndex", "LoginPage");
                }


                con.Open();
                string query = "select Designation  from users where uId = " + Convert.ToInt32(Session["uuid"]) + "  ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string type = "";

                if (dt.Rows.Count > 0)
                {
                    type = dt.Rows[0]["Designation"].ToString();
                }
                con.Close();


                if (type != "2")
                {
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






                }
                else
                {

                    ViewBag.Testatorpopup = "true";

                }




                // total count Dashboard

                string q1 = "select count(*) as TotalDistributorAdmin from users  where Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and Type = 'DistributorAdmin'";
                SqlDataAdapter da1 = new SqlDataAdapter(q1, con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                ViewBag.TotalDistributorAdmin = Convert.ToInt32(dt1.Rows[0]["TotalDistributorAdmin"]);


                string q5 = "select count(*) as TotalTestator  from TestatorDetails a inner join users b on a.uId=b.uId where b.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
                SqlDataAdapter da5 = new SqlDataAdapter(q5, con);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);
                ViewBag.TotalTestator = Convert.ToInt32(dt5.Rows[0]["TotalTestator"]);


                string q52 = "select count(*) as TotalVisitor from visitorinfo ";
                SqlDataAdapter da52 = new SqlDataAdapter(q52, con);
                DataTable dt52 = new DataTable();
                da52.Fill(dt52);
                ViewBag.TotalVisitor = Convert.ToInt32(dt52.Rows[0]["TotalVisitor"]);




                string q2 = "select count(*) as TotalWill from documentRules WHERE documentType = 'Will' and uId = " + Convert.ToInt32(Session["uuid"]) + "";
                SqlDataAdapter da22 = new SqlDataAdapter(q2, con);
                DataTable dt22 = new DataTable();
                da22.Fill(dt22);
                ViewBag.Will = Convert.ToInt32(dt22.Rows[0]["TotalWill"]);



                string q4 = "select count(*) as TotalCodocil from documentRules WHERE documentType = 'Codocil' and uId = " + Convert.ToInt32(Session["uuid"]) + "  ";
                SqlDataAdapter da4 = new SqlDataAdapter(q4, con);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                ViewBag.Codocil = Convert.ToInt32(dt4.Rows[0]["TotalCodocil"]);







                string q6 = "select count(*) as TotalPOA from documentRules WHERE documentType = 'POA' and uId = " + Convert.ToInt32(Session["uuid"]) + "";
                SqlDataAdapter da6 = new SqlDataAdapter(q6, con);
                DataTable dt6 = new DataTable();
                da6.Fill(dt6);
                ViewBag.POA = Convert.ToInt32(dt6.Rows[0]["TotalPOA"]);




                string q7 = "select count(*) as TotalGiftDeeds from documentRules WHERE documentType = 'GiftDeeds' and uId = " + Convert.ToInt32(Session["uuid"]) + "";
                SqlDataAdapter da7 = new SqlDataAdapter(q7, con);
                DataTable dt7 = new DataTable();
                da7.Fill(dt7);
                ViewBag.GiftDeeds = Convert.ToInt32(dt7.Rows[0]["TotalGiftDeeds"]);







                con.Close();




                //end



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



                ViewBag.showtitle = "true";
                ViewBag.documentlink = "true";







                con.Open();
                string query12 = "select top 1 tId from  TestatorDetails where  uId = " + Convert.ToInt32(Session["uuid"]) + " order by tid desc ";
                SqlDataAdapter da12 = new SqlDataAdapter(query12, con);
                DataTable dt12 = new DataTable();
                da12.Fill(dt12);
                if (dt12.Rows.Count > 0)
                {
                    testatorid = Convert.ToInt32(dt12.Rows[0]["tId"]);
                    ViewBag.testatorid = testatorid;

                }
                con.Close();















                
            }


           






         
            con.Open();
            string query1t = "select top 1 tId from  TestatorDetails where  uId = " + Convert.ToInt32(Session["uuid"]) + " order by tid desc ";
            SqlDataAdapter da1t = new SqlDataAdapter(query1t, con);
            DataTable dt1t = new DataTable();
            da1t.Fill(dt1t);
            if (dt1t.Rows.Count > 0)
            {
                testatorid = Convert.ToInt32(dt1t.Rows[0]["tId"]);


            }
            con.Close();





            //////////////////////////////////////////////////////  FOR CHECKING DOCUMENT COMPLETION ///////////////////////////////////////////////


          
                    // for Detailed Will 

                    con.Open();
                    string qchk008 = "select * from TestatorDetails where WillType = 'Detailed' and doctype = 'Will' and documentstatus = 'Completed' and uId= "+Convert.ToInt32(Session["uuid"])+"";
                    SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                    DataTable chk008dt = new DataTable();
                    chk008da.Fill(chk008dt);
                    con.Close();
                    int detailedcount = 1;
                    int getcount = 0;
                    string btnwillDetailed = "";
                    if (chk008dt.Rows.Count > 0)
                    {
                        
                        for (int i = 0; i < chk008dt.Rows.Count; i++)
                        {
                            getcount = detailedcount++;
                            try
                            {
                                btnwillDetailed = btnwillDetailed + "<a href='/page/Report.aspx?NestId="+chk008dt.Rows[i]["tid"].ToString()+"&WillType=Detailed' id='compdocumentbtn1' ><button type='button' class='btn btn-primary waves-effect waves-lightm-1'> <i class='fa fa-file' style='color:#f7dddd;'></i> <span>Detailed-Will-(" + i + ")</span> </button> &nbsp;&nbsp;&nbsp;&nbsp;";
                            }
                            catch (Exception)
                            {

                              
                            }

                            
                        }

                       


                        ViewBag.Willbtn = btnwillDetailed;



                    }


            //end



            // for Quick Will 

            con.Open();
            string qchk00822 = "select * from TestatorDetails where WillType = 'Quick' and doctype = 'Will' and documentstatus = 'Completed' and uId= " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter chk008da22 = new SqlDataAdapter(qchk00822, con);
            DataTable chk008dt22 = new DataTable();
            chk008da22.Fill(chk008dt22);
            con.Close();
            int detailedcount22 = 1;
            int getcount22 = 0;
            string btnwillDetailed22 = "";
            if (chk008dt22.Rows.Count > 0)
            {

                for (int i = 0; i < chk008dt22.Rows.Count; i++)
                {
                    getcount22 = detailedcount22++;
                    try
                    {
                        btnwillDetailed22 = btnwillDetailed22 + "<a href='/page/Report.aspx?NestId=" + chk008dt22.Rows[i]["tid"].ToString() + "&WillType=Quick' id='compdocumentbtn1' ><button type='button' class='btn btn-primary waves-effect waves-lightm-1'> <i class='fa fa-file' style='color:#f7dddd;'></i> <span>Quick-Will-(" + i + ")</span> </button> &nbsp;&nbsp;&nbsp;&nbsp;";
                    }
                    catch (Exception)
                    {


                    }


                }




                ViewBag.WillQuickbtn = btnwillDetailed22;



            }


            //end





            // for POA 

                    con.Open();
                    string qchk0082 = "select a.* from BeneficiaryDetails a INNER JOIN TestatorDetails b on a.tId=b.tId inner join users c on b.uId=c.uId where a.doctype = 'POA' and c.uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter chk008da2 = new SqlDataAdapter(qchk0082, con);
                    DataTable chk008dt2 = new DataTable();
                    chk008da2.Fill(chk008dt2);
                    con.Close();
                    int poacount = 1;
                    int getpoacount = 0;
                    string btnpoa = "";
                if (chk008dt2.Rows.Count > 0)
                        {

                    for (int i = 0; i < chk008dt2.Rows.Count; i++)
                    {
                        getpoacount = poacount++;
                        try
                        {
                            btnpoa = btnpoa + "<a href='/page/Report.aspx?NestId=" + chk008dt2.Rows[i]["tid"].ToString() + "&WillType=POA' id='compdocumentbtn1' ><button type='button' class='btn btn-info waves-effect waves-lightm-1'> <i class='fa fa-file' style='color:#f7dddd;'></i> <span>POA-(" + i + ")</span> </button> &nbsp;&nbsp;&nbsp;&nbsp;";
                        }
                        catch (Exception)
                        {


                        }


                    }




                ViewBag.POAbtn = btnpoa;

            



                    }
                


                    //end
                


              
                   
                    // for Giftdeeds 

                    con.Open();
                    string qchk0083 = "select a.* from BeneficiaryDetails a INNER JOIN TestatorDetails b on a.tId=b.tId inner join users c on b.uId=c.uId where a.doctype = 'GiftDeeds' and c.uId = " + Convert.ToInt32(Session["uuid"]) + "";
                    SqlDataAdapter chk008da3 = new SqlDataAdapter(qchk0083, con);
                    DataTable chk008dt3 = new DataTable();
                    chk008da3.Fill(chk008dt3);
                    con.Close();
            int giftcount = 1;
            int getgiftcount = 0;
            string btngift = "";
            if (chk008dt3.Rows.Count > 0)
            {

                for (int i = 0; i < chk008dt3.Rows.Count; i++)
                {
                    getgiftcount = giftcount++;
                    try
                    {
                        btngift = btngift + "<a href='/page/Report.aspx?NestId=" + chk008dt3.Rows[i]["tid"].ToString() + "&WillType=giftdeeds' id='compdocumentbtn1' ><button type='button' class='btn btn-danger waves-effect waves-lightm-1'> <i class='fa fa-file' style='color:#f7dddd;'></i> <span>GiftDeeds-(" + i + ")</span> </button> &nbsp;&nbsp;&nbsp;&nbsp;";
                    }
                    catch (Exception)
                    {


                    }


                }




                ViewBag.Giftdeedsbtn = btngift;





            }
      



                    
                 


                    //end
                


                
                    ViewBag.PaymentLink = "true";
                    // for living_Will 

                    con.Open();
                    string qchk0084 = "select * from living_Will where documentstatus = 'Completed' or documentstatus ='Incompleted' and tId = " + testatorid + "";
                    SqlDataAdapter chk008da4 = new SqlDataAdapter(qchk0084, con);
                    DataTable chk008dt4 = new DataTable();
                    chk008da4.Fill(chk008dt4);
                    con.Close();

                    if (chk008dt4.Rows.Count > 0)
                    {


                        int detailedcountl = 1;
                        int getcountl = 0;
                        string btnLiving = "";
                        if (chk008dt4.Rows.Count > 0)
                        {
                            
                            for (int i = 0; i < chk008dt4.Rows.Count; i++)
                            {
                                getcountl = detailedcountl++;
                                try
                                {
                                    btnLiving = btnLiving + "<a href='/page/Report.aspx?NestId=" + chk008dt4.Rows[i]["tid"].ToString() + "' id='compdocumentbtn5' ><button type='button' class='btn btn-warning waves-effect waves-lightm-1'> <i class='fa fa-file' style='color:#f7dddd;'></i> <span>LivingWill-(" + getcount + ")</span> </button> &nbsp;&nbsp;&nbsp;&nbsp;";
                                }
                                catch (Exception)
                                {


                                }


                            }




                            ViewBag.LivingWillbtn = btnLiving;






                            ViewBag.PaymentLink = "true";

                        }


                        //end
                    }
                



              

                    // for Codocil 

                    con.Open();
                    string qchk0085 = "select * from Codocil where documentstatus = 'Completed' or documentstatus ='Incompleted' and tId = " + testatorid + " ";
                    SqlDataAdapter chk008da5 = new SqlDataAdapter(qchk0085, con);
                    DataTable chk008dt5 = new DataTable();
                    chk008da5.Fill(chk008dt5);
                    con.Close();

                    if (chk008dt5.Rows.Count > 0)
                    {
                        int detailedcountc = 1;
                        int getcountc = 0;
                        string btnCodocil = "";
                        if (chk008dt5.Rows.Count > 0)
                        {
                            
                            for (int i = 0; i < chk008dt5.Rows.Count; i++)
                            {
                                getcountc = detailedcountc++;
                                try
                                {
                                    btnCodocil = btnCodocil + "<a href='/page/Report.aspx?NestId=" + chk008dt5.Rows[i]["tid"].ToString() + "' id='compdocumentbtn5' ><button type='button' class='btn btn-success waves-effect waves-lightm-1'> <i class='fa fa-file' style='color:#f7dddd;'></i> <span>Codocil-(" + getcount + ")</span> </button> &nbsp;&nbsp;&nbsp;&nbsp;";
                                }
                                catch (Exception)
                                {


                                }


                            }




                            ViewBag.Codocilbtn = btnCodocil;

                     
                            ViewBag.PaymentLink = "true";



                        }


                        //end
                    }
               

            //////////////////////////////////////////////////////  END  ///////////////////////////////////////////////









            return View("~/Views/TestatorHomePage/TestatorHomePageContent.cshtml");
        }





    









  









        public ActionResult getdocumentprice(TestatorFormModel TFM)
        {
            string typeid = "";
            int total = 0;
            int willamt = 0;
            int Codocilamt = 0;
            int POAamt = 0;
            int Giftdeedsamt = 0;
            int LivingWillamt = 0;
            Session["storedocument"] = "";
            Session["storedocument"] = TFM.documenttype;

            Session["typeofwill"] = "";
            Session["typeofwill"] = TFM.typeofwill;
            
         
            con.Open();

            string qry = "select * from documentpricing";
            SqlDataAdapter daa= new SqlDataAdapter(qry, con);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);

            if (dtt.Rows.Count > 0)
            {

                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    if (dtt.Rows[i]["Document_Name"].ToString() == "Will")
                    {
                        willamt = Convert.ToInt32(dtt.Rows[i]["Document_Price"]);
                    }


                    if (dtt.Rows[i]["Document_Name"].ToString() == "Codocil")
                    {
                        Codocilamt = Convert.ToInt32(dtt.Rows[i]["Document_Price"]);
                    }



                    if (dtt.Rows[i]["Document_Name"].ToString() == "POA")
                    {
                        POAamt = Convert.ToInt32(dtt.Rows[i]["Document_Price"]);
                    }



                    if (dtt.Rows[i]["Document_Name"].ToString() == "Gift Deeds")
                    {
                        Giftdeedsamt = Convert.ToInt32(dtt.Rows[i]["Document_Price"]);
                    }


                    if (dtt.Rows[i]["Document_Name"].ToString() == "Living Will")
                    {
                        LivingWillamt = Convert.ToInt32(dtt.Rows[i]["Document_Price"]);
                    }
                }

                

            }



            con.Close();






            // DOCUMENT RULES










                if (TFM.documenttype == "WillCodocilPOA")
                {


                    total = willamt + Codocilamt + POAamt;

                }
                if (TFM.documenttype == "Codocil")
                {


                    total = Codocilamt;


                }
                if (TFM.documenttype == "POA")
                {


                    total = POAamt;

                }
                if (TFM.documenttype == "Will")
                {


                    total = willamt;
                }
                if (TFM.documenttype == "WillCodocil")
                {


                    total = willamt + Codocilamt;

                }
                if (TFM.documenttype == "WillPOA")
                {


                    total = willamt + POAamt;
                }
                if (TFM.documenttype == "CodocilPOA")
                {


                    total = Codocilamt + POAamt;
                }
                if (TFM.documenttype == "CodocilWill")
                {


                    total = willamt + Codocilamt;
                }
                if (TFM.documenttype == "POAWill")
                {


                    total = willamt + POAamt;
                }
                if (TFM.documenttype == "Giftdeeds")
                {


                    total = Giftdeedsamt;
                }
                if (TFM.documenttype == "GiftdeedsCodocil")
                {


                    total = Codocilamt + Giftdeedsamt;
                }

                if (TFM.documenttype == "GiftdeedsWill")
                {


                    total = willamt + Giftdeedsamt;
                }

                if (TFM.documenttype == "GiftdeedsPOA")
                {


                    total = POAamt + Giftdeedsamt;
                }


                if (TFM.documenttype == "WillGiftdeeds")
                {


                    total = willamt + Giftdeedsamt;

                }



                if (TFM.documenttype == "POAGiftdeeds")
                {


                    total = POAamt + Giftdeedsamt;
                }

                if (TFM.documenttype == "CodocilGiftdeeds")
                {


                    total = Codocilamt + Giftdeedsamt;
                }

                if (TFM.documenttype == "CodocilGiftdeedsWill")
                {


                    total = willamt + Codocilamt + Giftdeedsamt;
                }

                if (TFM.documenttype == "CodocilGiftdeedsWillPOA")
                {


                    total = willamt + Codocilamt + POAamt + Giftdeedsamt;
                }

                if (TFM.documenttype == "CodocilWillGiftdeedsPOA")
                {


                    total = willamt + Codocilamt + POAamt + Giftdeedsamt;
                }

                if (TFM.documenttype == "WillCodocilPOAGiftdeeds")
                {


                    total = willamt + Codocilamt + POAamt + Giftdeedsamt;
                }

                if (TFM.documenttype == "WillCodocilPOAGiftdeedsLivingWill")
                {



                    total = willamt + Codocilamt + POAamt + Giftdeedsamt + LivingWillamt;
                }

                if (TFM.documenttype == "LivingWill")
                {


                    total = LivingWillamt;
                }

                if (TFM.documenttype == "LivingWillWillCodocilPOAGiftdeeds")
                {


                    total = willamt + Codocilamt + POAamt + Giftdeedsamt + LivingWillamt;
                }

                if (TFM.documenttype == "CodocilGiftdeedsLivingWillWillPOA")
                {



                    total = willamt + Codocilamt + POAamt + Giftdeedsamt + LivingWillamt;
                }

                if (TFM.documenttype == "LivingWillWillPOA")
                {


                    total = willamt + POAamt + LivingWillamt;
                }

                if (TFM.documenttype == "POALivingWillWill")
                {


                    total = POAamt + LivingWillamt + willamt;
                }

                if (TFM.documenttype == "LivingWillPOAGiftdeeds")
                {



                    total = POAamt + Giftdeedsamt + LivingWillamt;
                }
                if (TFM.documenttype == "POAGiftdeeds")
                {


                    total = POAamt + Giftdeedsamt;
                }
                if (TFM.documenttype == "POAGiftdeedsWill")
                {



                    total = willamt + POAamt + Giftdeedsamt;

                }
                if (TFM.documenttype == "POAWillCodocil")
                {



                    total = willamt + Codocilamt + POAamt;
                }
                if (TFM.documenttype == "CodocilLivingWill")
                {



                    total = Codocilamt + LivingWillamt;
                }
                if (TFM.documenttype == "CodocilGiftdeedsLivingWill")
                {


                    total = Codocilamt + Giftdeedsamt + LivingWillamt;

                }
                if (TFM.documenttype == "POALivingWill")
                {


                    total = POAamt + LivingWillamt;
                }
                if (TFM.documenttype == "GiftdeedsLivingWill")
                {



                    total = Giftdeedsamt + LivingWillamt;
                }
                if (TFM.documenttype == "WillCodocilPOAGiftdeedsLivingWill")
                {



                    total = willamt + Codocilamt + POAamt + Giftdeedsamt + LivingWillamt;
                }

                if (TFM.documenttype == "POAGiftDeedsLivingWill")
                {

                    total = POAamt + Giftdeedsamt + LivingWillamt;
                }

                if (TFM.documenttype == "LivingWillGiftDeedsPOA")
                {


                    total = POAamt + Giftdeedsamt + LivingWillamt;
                }

                if (TFM.documenttype == "GiftDeedsLivingWillPOA")
                {



                    total = POAamt + Giftdeedsamt + LivingWillamt;
                }

                if (TFM.documenttype == "LivingWillCodocil")
                {


                    total = Codocilamt + LivingWillamt;
                }

                if (TFM.documenttype == "LivingWillGiftdeeds")
                {



                    total = Giftdeedsamt + LivingWillamt;
                }


                if (TFM.documenttype == "WillGiftdeeds")
                {



                    total = willamt + Giftdeedsamt;
                }

                if (TFM.documenttype == "GiftdeedsPOA")
                {



                    total = POAamt + Giftdeedsamt;

                }
                if (TFM.documenttype == "LivingWillPOA")
                {



                    total = POAamt + LivingWillamt;
                }
                if (TFM.documenttype == "WillGiftdeedsCodocil")
                {



                    total = willamt + Codocilamt + Giftdeedsamt;
                }

                if (TFM.documenttype == "WillGiftdeedsLivingWill")
                {


                    total = willamt + Giftdeedsamt + LivingWillamt;
                }
                if (TFM.documenttype == "CodocilPOAGiftdeeds")
                {


                    total = Codocilamt + POAamt + Giftdeedsamt;
                }
                if (TFM.documenttype == "WillCodocilGiftdeeds")
                {



                    total = willamt + Codocilamt + Giftdeedsamt;
                }
                if (TFM.documenttype == "WillLivingWill")
                {


                    total = willamt + LivingWillamt;
                }
                if (TFM.documenttype == "LivingWillWill")
                {


                    total = willamt + LivingWillamt;
                }


                if (TFM.documenttype == "WillPOAGiftdeeds")
                {



                    total = willamt + POAamt + Giftdeedsamt;
                }


                if (TFM.documenttype == "POAWillGiftdeeds")
                {



                    total = willamt + POAamt + Giftdeedsamt;
                }



                if (TFM.documenttype == "GiftdeedsPOAWill")
                {



                    total = POAamt + Giftdeedsamt + willamt;
                }

                if (TFM.documenttype == "WillCodocilGiftdeedsPOA")
                {


                    total = willamt + Codocilamt + POAamt + Giftdeedsamt;
                }


                if (TFM.documenttype == "WillCodocilGiftdeedsPOALivingWill")
                {



                    total = willamt + Codocilamt + POAamt + Giftdeedsamt + LivingWillamt;
                }


                if (TFM.documenttype == "WillCodocilLivingWill")
                {



                    total = willamt + Codocilamt + LivingWillamt;
                }
                if (TFM.documenttype == "CodocilLivingWillPOAGiftdeeds")
                {



                    total = Codocilamt + POAamt + Giftdeedsamt + LivingWillamt;
                }

                if (TFM.documenttype == "WillCodocilLivingWillPOA")
                {



                    total = willamt + Codocilamt + POAamt + LivingWillamt;
                }


                if (TFM.documenttype == "WillCodocilLivingWillPOAGiftdeeds")
                {



                    total = willamt + Codocilamt + POAamt + Giftdeedsamt + LivingWillamt;
                }


                if (TFM.documenttype == "WillCodocilGiftdeedsPOAGiftdeeds")
                {

                   total = willamt + Codocilamt + POAamt + Giftdeedsamt + LivingWillamt;

                }


                TempData["status"] = "true";


                TempData["setamount"] = total;



               







            /////////////////////////////////////////////////////end////////////////////////////////////////////











            return RedirectToAction("TestatorHomePageIndex", "TestatorHomePage");

        }





        public ActionResult MakePayment(TestatorFormModel TFM)
        {
            string typeid = "";



            string documenttype = Session["storedocument"].ToString(); 






            // DOCUMENT RULES
            int testatorid = 0;
            con.Open();
            string query1tt = "select top 1 tId from  TestatorDetails where  uId = " + Convert.ToInt32(Session["uuid"]) + " order by tid desc ";
            SqlDataAdapter da1tt = new SqlDataAdapter(query1tt, con);
            DataTable dt1tt = new DataTable();
            da1tt.Fill(dt1tt);
            if (dt1tt.Rows.Count > 0)
            {
                testatorid = Convert.ToInt32(dt1tt.Rows[0]["tId"]);


            }
            con.Close();


            string qchk008 = "";
            con.Open();
            qchk008 = "select * from TestatorDetails where  documentstatus = 'Completed' and tid= " + testatorid + "";
            SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
            DataTable chk008dt = new DataTable();
            chk008da.Fill(chk008dt);
            con.Close();

            if (chk008dt.Rows.Count > 0)
            {

                //////////////////////////////////// for existing/////////////////////////////////////

                con.Open();


                string qrrr = "select * from TestatorDetails where tid = " + testatorid + "";
                SqlDataAdapter chktdar = new SqlDataAdapter(qrrr, con);
                DataTable chk008dtr = new DataTable();
                chktdar.Fill(chk008dtr);

                string dateString = Convert.ToDateTime(chk008dtr.Rows[0]["DOB"]).ToString("dd/MM/yyyy");
                DateTime dd = Convert.ToDateTime(dateString,
                    System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);


                string query3 = "insert into TestatorDetails (First_Name,Middle_Name,Last_Name,Mobile,Email,uid ,DOB,Occupation,maritalStatus,RelationShip,Religion,Identity_Proof,Identity_proof_Value,Alt_Identity_Proof,Alt_Identity_proof_Value,Gender,Address1,Address2,Address3,City ,State,Country ,Pin,active,documentstatus) values ('" + chk008dtr.Rows[0]["First_Name"].ToString() + "' , '" + chk008dtr.Rows[0]["Middle_Name"].ToString() + "' , '" + chk008dtr.Rows[0]["Last_Name"].ToString() + "' , '" + chk008dtr.Rows[0]["Mobile"].ToString() + "' , '" + chk008dtr.Rows[0]["Email"].ToString() + "' , " + Convert.ToInt32(Session["uuid"]) + " , '" + dd + "' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'no' , 'incompleted' )    ";
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd3.ExecuteNonQuery();




                // set document rules

                string getlatesttid = "select top 1 tId  from TestatorDetails order by tId desc";
                SqlDataAdapter ladap = new SqlDataAdapter(getlatesttid,con);
                DataTable ladt = new DataTable();
                ladap.Fill(ladt);


                int identify = 0;

                if (Session["typeofWill"].ToString() == "Quick")
                {
                    identify = 1;
                    string qdr = "insert into documentRules (tid,uid,category) values ( " + Convert.ToInt32(ladt.Rows[0]["tId"]) + " ,   " + Convert.ToInt32(Session["uuid"]) + " , " + identify + ") ";
                    SqlCommand cdr = new SqlCommand(qdr, con);
                    cdr.ExecuteNonQuery();
                }
                if (Session["typeofWill"].ToString() == "Detailed")
                {
                    identify = 2;
                    string qdr = "insert into documentRules (tid,uid,category) values ( " + Convert.ToInt32(ladt.Rows[0]["tId"]) + " ,   " + Convert.ToInt32(Session["uuid"]) + " , " + identify + ") ";
                    SqlCommand cdr = new SqlCommand(qdr, con);
                    cdr.ExecuteNonQuery();
                }

               

                // end





                con.Close();













                if (documenttype == "WillCodocilPOA")
                {
                    typeid = "1,2,3";

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

           

                }
                if (documenttype == "Codocil")
                {
                    typeid = "2";



                    con.Open();
                    string qq1 = "update users set    Codocil = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

         


                }
                if (documenttype == "POA")
                {
                    typeid = "3";

                    con.Open();
                    string qq1 = "update users set  POA = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

             

                }
                if (documenttype == "Will")
                {
                    typeid = "1";
                    con.Open();
                    string qq1 = "update users set Will = '1'   where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                 
                }
                if (documenttype == "WillCodocil")
                {
                    typeid = "1,2";

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1'   where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

     

                }
                if (documenttype == "WillPOA")
                {
                    typeid = "1,3";

                    con.Open();
                    string qq1 = "update users set Will = '1' , POA = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

         
                }
                if (documenttype == "CodocilPOA")
                {
                    typeid = "2,3";

                    con.Open();
                    string qq1 = "update users set   Codocil = '1' , POA = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

               
                }
                if (documenttype == "CodocilWill")
                {
                    typeid = "2,1";

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1'   where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }
                if (documenttype == "POAWill")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1'  , POA = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                    
                }
                if (documenttype == "Giftdeeds")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set  Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }
                if (documenttype == "GiftdeedsCodocil")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set  Codocil = '1' ,  Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                 
                }

                if (documenttype == "GiftdeedsWill")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1'  , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                 
                }

                if (documenttype == "GiftdeedsPOA")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set   POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }


                if (documenttype == "WillGiftdeeds")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

           

                }



                if (documenttype == "POAGiftdeeds")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set   POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                
                }

                if (documenttype == "CodocilGiftdeeds")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Codocil = '1'  , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

              
                }

                if (documenttype == "CodocilGiftdeedsWill")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1'  , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

      
                }

                if (documenttype == "CodocilGiftdeedsWillPOA")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }

                if (documenttype == "CodocilWillGiftdeedsPOA")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                
                }

                if (documenttype == "WillCodocilPOAGiftdeeds")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

           
                }

                if (documenttype == "WillCodocilPOAGiftdeedsLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }

                if (documenttype == "LivingWill")
                {

                    con.Open();
                    string qq1 = "update users set  LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                 
                }

                if (documenttype == "LivingWillWillCodocilPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                  
                }

                if (documenttype == "CodocilGiftdeedsLivingWillWillPOA")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                 
                }

                if (documenttype == "LivingWillWillPOA")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1'  , POA = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }

                if (documenttype == "POALivingWillWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1'  , POA = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

               
                }

                if (documenttype == "LivingWillPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }
                if (documenttype == "POAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set  POA = '1' , Giftdeeds='1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

               
                }
                if (documenttype == "POAGiftdeedsWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' ,  POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                  

                }
                if (documenttype == "POAWillCodocil")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                  
                }
                if (documenttype == "CodocilLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set  Codocil = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }
                if (documenttype == "CodocilGiftdeedsLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set   Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                  

                }
                if (documenttype == "POALivingWill")
                {

                    con.Open();
                    string qq1 = "update users set POA = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                  
                }
                if (documenttype == "GiftdeedsLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set   Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                  
                }
                if (documenttype == "WillCodocilPOAGiftdeedsLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }

                if (documenttype == "POAGiftDeedsLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set   POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();


                   
                }

                if (documenttype == "LivingWillGiftDeedsPOA")
                {

                    con.Open();
                    string qq1 = "update users set  POA = '1' , Giftdeeds='1', LivingWill='1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }

                if (documenttype == "GiftDeedsLivingWillPOA")
                {

                    con.Open();
                    string qq1 = "update users set   POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                  
                }

                if (documenttype == "LivingWillCodocil")
                {

                    con.Open();
                    string qq1 = "update users set  Codocil = '1' ,  LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }

                if (documenttype == "LivingWillGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set  Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                    
                }


                if (documenttype == "WillGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }

                if (documenttype == "GiftdeedsPOA")
                {

                    con.Open();
                    string qq1 = "update users set  POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();


                 

                }
                if (documenttype == "LivingWillPOA")
                {

                    con.Open();
                    string qq1 = "update users set   POA = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }
                if (documenttype == "WillGiftdeedsCodocil")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }

                if (documenttype == "WillGiftdeedsLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' ,  Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                  
                }
                if (documenttype == "CodocilPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set  Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }
                if (documenttype == "WillCodocilGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' ,  Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                
                }
                if (documenttype == "WillLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

               
                }
                if (documenttype == "LivingWillWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

        
                }


                if (documenttype == "WillPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }


                if (documenttype == "POAWillGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }



                if (documenttype == "GiftdeedsPOAWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' ,  POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }

                if (documenttype == "WillCodocilGiftdeedsPOA")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

             
                }


                if (documenttype == "WillCodocilGiftdeedsPOALivingWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

              
                }


                if (documenttype == "WillCodocilLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1'  , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

               
                }
                if (documenttype == "CodocilLivingWillPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set  Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

               
                }

                if (documenttype == "WillCodocilLivingWillPOA")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }


                if (documenttype == "WillCodocilLivingWillPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

               
                }


                if (documenttype == "WillCodocilGiftdeedsPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();
                }






                con.Open();
                string qq1typ = "update users set WillType = '" + Session["typeofwill"].ToString() + "'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1typ = new SqlCommand(qq1typ, con);
                cc1typ.ExecuteNonQuery();

                string qq = "update testatordetails set PaymentStatus = 1 , WillType='" + Session["typeofwill"].ToString() + "'  where uId= " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cmdqq = new SqlCommand(qq, con);
                cmdqq.ExecuteNonQuery();
                con.Close();





                TempData["status"] = "true";






                /////////////////////////////////////////////////////end////////////////////////////////////////////



            }
            else
            {

                // set document rules

                string getlatesttid = "select top 1 tId  from TestatorDetails order by tId desc";
                SqlDataAdapter ladap = new SqlDataAdapter(getlatesttid, con);
                DataTable ladt = new DataTable();
                ladap.Fill(ladt);


                int identify = 0;

                if (Session["typeofWill"].ToString() == "Quick")
                {
                    identify = 1;

                    con.Open();
                    string qdr = "update documentRules set category = " + identify + " where tid = " + Convert.ToInt32(ladt.Rows[0]["tId"]) + " ";
                    SqlCommand cdr = new SqlCommand(qdr, con);
                    cdr.ExecuteNonQuery();
                    con.Close();
                }
                if (Session["typeofWill"].ToString() == "Detailed")
                {
                    identify = 2;

                    con.Open();
                    string qdr = "update documentRules set category = " + identify + " where tid = " + Convert.ToInt32(ladt.Rows[0]["tId"]) + " ";
                    SqlCommand cdr = new SqlCommand(qdr, con);
                    cdr.ExecuteNonQuery();
                    con.Close();
                }
            
                // end


                if (TFM.codocil != null)
                {
                    int codocilid = 0;
                    con.Open();
                    string quer1 = "select top 1 codId from  Codocil order by  codId desc";
                    SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                    DataTable daat = new DataTable();
                    daa1.Fill(daat);
                    if (daat.Rows.Count > 0)
                    {
                        codocilid = Convert.ToInt32(daat.Rows[0]["codId"]);
                    }





                    string qq1 = "update Codocil set documentstatus = 'Completed' where codId = " + codocilid + "";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();






                }





                if (TFM.livingwill != null)
                {
                    int livwillid = 0;
                    con.Open();
                    string quer1 = "select top 1 livwillid from  living_Will order by  livwillid desc";
                    SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                    DataTable daat = new DataTable();
                    daa1.Fill(daat);
                    if (daat.Rows.Count > 0)
                    {
                        livwillid = Convert.ToInt32(daat.Rows[0]["livwillid"]);
                    }





                    string qq1 = "update living_Will set documentstatus = 'Completed' where livwillid = " + livwillid + "";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();






                }






                if (documenttype == "WillCodocilPOA")
                {
                    typeid = "1,2,3";

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();


                }
                if (documenttype == "Codocil")
                {
                    typeid = "2";



                    con.Open();
                    string qq1 = "update users set    Codocil = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();


                }
                if (documenttype == "POA")
                {
                    typeid = "3";

                    con.Open();
                    string qq1 = "update users set  POA = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

          

                }
                if (documenttype == "Will")
                {
                    typeid = "1";
                    con.Open();
                    string qq1 = "update users set Will = '1'   where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

           
                }
                if (documenttype == "WillCodocil")
                {
                    typeid = "1,2";

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1'   where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                

                }
                if (documenttype == "WillPOA")
                {
                    typeid = "1,3";

                    con.Open();
                    string qq1 = "update users set Will = '1' , POA = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

              
                }
                if (documenttype == "CodocilPOA")
                {
                    typeid = "2,3";

                    con.Open();
                    string qq1 = "update users set   Codocil = '1' , POA = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }
                if (documenttype == "CodocilWill")
                {
                    typeid = "2,1";

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1'   where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }
                if (documenttype == "POAWill")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1'  , POA = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

         
                }
                if (documenttype == "Giftdeeds")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set  Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }
                if (documenttype == "GiftdeedsCodocil")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set  Codocil = '1' ,  Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }

                if (documenttype == "GiftdeedsWill")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1'  , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

              
                }

                if (documenttype == "GiftdeedsPOA")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set   POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }


                if (documenttype == "WillGiftdeeds")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

            

                }



                if (documenttype == "POAGiftdeeds")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set   POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }

                if (documenttype == "CodocilGiftdeeds")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Codocil = '1'  , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }

                if (documenttype == "CodocilGiftdeedsWill")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1'  , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }

                if (documenttype == "CodocilGiftdeedsWillPOA")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

               
                }

                if (documenttype == "CodocilWillGiftdeedsPOA")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                  
                }

                if (documenttype == "WillCodocilPOAGiftdeeds")
                {
                    typeid = "3,1";
                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

              
                }

                if (documenttype == "WillCodocilPOAGiftdeedsLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }

                if (documenttype == "LivingWill")
                {

                    con.Open();
                    string qq1 = "update users set  LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

         
                }

                if (documenttype == "LivingWillWillCodocilPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }

                if (documenttype == "CodocilGiftdeedsLivingWillWillPOA")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

          
                }

                if (documenttype == "LivingWillWillPOA")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1'  , POA = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

             
                }

                if (documenttype == "POALivingWillWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1'  , POA = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }

                if (documenttype == "LivingWillPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }
                if (documenttype == "POAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set  POA = '1' , Giftdeeds='1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

         
                }
                if (documenttype == "POAGiftdeedsWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' ,  POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

             

                }
                if (documenttype == "POAWillCodocil")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

     
                }
                if (documenttype == "CodocilLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set  Codocil = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

          
                }
                if (documenttype == "CodocilGiftdeedsLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set   Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

     

                }
                if (documenttype == "POALivingWill")
                {

                    con.Open();
                    string qq1 = "update users set POA = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }
                if (documenttype == "GiftdeedsLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set   Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

 
                }
                if (documenttype == "WillCodocilPOAGiftdeedsLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

     
                }

                if (documenttype == "POAGiftDeedsLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set   POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();


                  
                }

                if (documenttype == "LivingWillGiftDeedsPOA")
                {

                    con.Open();
                    string qq1 = "update users set  POA = '1' , Giftdeeds='1', LivingWill='1'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

           
                }

                if (documenttype == "GiftDeedsLivingWillPOA")
                {

                    con.Open();
                    string qq1 = "update users set   POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                  
                }

                if (documenttype == "LivingWillCodocil")
                {

                    con.Open();
                    string qq1 = "update users set  Codocil = '1' ,  LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }

                if (documenttype == "LivingWillGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set  Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

  
                }


                if (documenttype == "WillGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

               
                }

                if (documenttype == "GiftdeedsPOA")
                {

                    con.Open();
                    string qq1 = "update users set  POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();


            

                }
                if (documenttype == "LivingWillPOA")
                {

                    con.Open();
                    string qq1 = "update users set   POA = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }
                if (documenttype == "WillGiftdeedsCodocil")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                  
                }

                if (documenttype == "WillGiftdeedsLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' ,  Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                    
                }
                if (documenttype == "CodocilPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set  Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }
                if (documenttype == "WillCodocilGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' ,  Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                  
                }
                if (documenttype == "WillLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }
                if (documenttype == "LivingWillWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                    
                }


                if (documenttype == "WillPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }


                if (documenttype == "POAWillGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }



                if (documenttype == "GiftdeedsPOAWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' ,  POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }

                if (documenttype == "WillCodocilGiftdeedsPOA")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                 
                }


                if (documenttype == "WillCodocilGiftdeedsPOALivingWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                
                }


                if (documenttype == "WillCodocilLivingWill")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1'  , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                 
                }
                if (documenttype == "CodocilLivingWillPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set  Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                   
                }

                if (documenttype == "WillCodocilLivingWillPOA")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }


                if (documenttype == "WillCodocilLivingWillPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();

                }


                if (documenttype == "WillCodocilGiftdeedsPOAGiftdeeds")
                {

                    con.Open();
                    string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlCommand cc1 = new SqlCommand(qq1, con);
                    cc1.ExecuteNonQuery();
                    con.Close();
                }






                con.Open();
                string qq1typ = "update users set WillType = '" + Session["typeofwill"].ToString() + "'  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cc1typ = new SqlCommand(qq1typ, con);
                cc1typ.ExecuteNonQuery();

                string qq = "update testatordetails set PaymentStatus = 1  where uId= " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlCommand cmdqq = new SqlCommand(qq,con);
                cmdqq.ExecuteNonQuery();
                con.Close();



                




            }




          



            return RedirectToAction("TestatorHomePageIndex", "TestatorHomePage");

        }


        public string checkwilldocument()
        {
            string status = "";
            string WillType = "";


            con.Open();
            string qtest0012 = "select top 1 WillType from users where uId = " + Convert.ToInt32(Session["uuid"]) + " order by uId Desc";
            SqlDataAdapter test001da2 = new SqlDataAdapter(qtest0012, con);
            DataTable test001dt2 = new DataTable();
            test001da2.Fill(test001dt2);

            if (test001dt2.Rows.Count > 0)
            {
                WillType = test001dt2.Rows[0]["WillType"].ToString();
            }
            con.Close();





            if (WillType == "Quick")
            {

                int NestId = 0;

                int getid = Convert.ToInt32(Session["uuid"]);


                con.Open();
                string identifydoc = "select Will from users where Will = 1 and uId = " + getid + " and WillType = 'Quick' ";
                SqlDataAdapter da = new SqlDataAdapter(identifydoc, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["Will"]) == 1)
                    {



                        string qq26 = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                        SqlDataAdapter daa26 = new SqlDataAdapter(qq26, con);
                        DataTable dtt26 = new DataTable();
                        daa26.Fill(dtt26);
                        if (dtt26.Rows.Count > 0)
                        {
                            NestId = Convert.ToInt32(dtt26.Rows[0]["tId"]);
                        }



                        // check which document is active
                        // for testator family

                        string qchk001 = "select a.fId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Marital_Status , a.Religion , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.tId , a.active , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Is_Informed_Person from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where b.tId =   " + NestId + " and a.WillType = 'Quick' ";
                        SqlDataAdapter chk001da = new SqlDataAdapter(qchk001, con);
                        DataTable chk001dt = new DataTable();
                        chk001da.Fill(chk001dt);


                        if (chk001dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }
                        //end


                        // for beneficiary

                        string qchk002 = "select a.bpId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_proof , a.Identity_proof_value , a.Alt_Identity_proof , a.Alt_Identity_proof_value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.beneficiary_type from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId where b.tId = " + NestId + "  and a.doctype='Will' and a.WillType='Quick'";
                        SqlDataAdapter chk002da = new SqlDataAdapter(qchk002, con);
                        DataTable chk002dt = new DataTable();
                        chk002da.Fill(chk002dt);
                        con.Close();
                        if (chk002dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }
                        //end


                        // for beneficiary institution
                        con.Open();
                        string qchk0020 = "select * from [BeneficiaryInstitutions] where tid = " + NestId + "  and WillType='Quick'";
                        SqlDataAdapter chk002da0 = new SqlDataAdapter(qchk0020, con);
                        DataTable chk002dt0 = new DataTable();
                        chk002da0.Fill(chk002dt0);
                        con.Close();
                        if (chk002dt0.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }
                        //end




                        // for appointees 

                        con.Open();
                        string qchk008 = "select * from Appointees where tid = " + NestId + " and Type='Executor' and WillType='Quick' ";
                        SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                        DataTable chk008dt = new DataTable();
                        chk008da.Fill(chk008dt);
                        con.Close();

                        if (chk008dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }

                        //end






                        // for Addwitness 

                        con.Open();
                        string qchk0082 = "select * from Appointees where tid = " + NestId + " and Type='Witness' and WillType='Quick' ";
                        SqlDataAdapter chk008da2 = new SqlDataAdapter(qchk0082, con);
                        DataTable chk008dt2 = new DataTable();
                        chk008da2.Fill(chk008dt2);
                        con.Close();

                        if (chk008dt2.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }

                        //end



                        // for asset mapping 


                        string qchk006 = "select a.Beneficiary_Asset_ID , a.AssetType_ID , a.AssetCategory_ID ,  a.Beneficiary_ID , a.Proportion , a.tid from BeneficiaryAssets a inner join TestatorDetails b on a.tid=b.tId where b.tId = " + NestId + "  and a.doctype='Will'  and a.WillType='Quick'";
                        SqlDataAdapter chk006da = new SqlDataAdapter(qchk006, con);
                        DataTable chk006dt = new DataTable();
                        chk006da.Fill(chk006dt);
                        con.Close();

                        if (chk006dt.Rows.Count > 0)
                        {
                            status = "true";
                        }
                        else
                        {
                            status = "false";
                        }

                        //end

















                    }
                }

                con.Close();






            }



            if (WillType == "Detailed")
            {

                int NestId = 0;

                int getid = Convert.ToInt32(Session["uuid"]);


                con.Open();
                string identifydoc = "select Will from users where Will = 1 and uId = " + getid + " and WillType = 'Detailed' ";
                SqlDataAdapter da = new SqlDataAdapter(identifydoc, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["Will"]) == 1)
                    {



                        string qq26 = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                        SqlDataAdapter daa26 = new SqlDataAdapter(qq26, con);
                        DataTable dtt26 = new DataTable();
                        daa26.Fill(dtt26);
                        if (dtt26.Rows.Count > 0)
                        {
                            NestId = Convert.ToInt32(dtt26.Rows[0]["tId"]);
                        }



                        // check which document is active
                        // for testator family

                        string qchk001 = "select a.fId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Marital_Status , a.Religion , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.tId , a.active , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Is_Informed_Person from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where b.tId =   " + NestId + " and a.WillType = 'Detailed' ";
                        SqlDataAdapter chk001da = new SqlDataAdapter(qchk001, con);
                        DataTable chk001dt = new DataTable();
                        chk001da.Fill(chk001dt);


                        if (chk001dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }
                        //end


                        // for beneficiary

                        string qchk002 = "select a.bpId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_proof , a.Identity_proof_value , a.Alt_Identity_proof , a.Alt_Identity_proof_value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.beneficiary_type from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId where b.tId = " + NestId + "  and a.doctype='Will' and a.WillType='Detailed'";
                        SqlDataAdapter chk002da = new SqlDataAdapter(qchk002, con);
                        DataTable chk002dt = new DataTable();
                        chk002da.Fill(chk002dt);
                        con.Close();
                        if (chk002dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }
                        //end




                        // for beneficiary institution
                        con.Open();
                        string qchk0020 = "select * from [BeneficiaryInstitutions] where tid = " + NestId + "  and WillType='Detailed'";
                        SqlDataAdapter chk002da0 = new SqlDataAdapter(qchk0020, con);
                        DataTable chk002dt0 = new DataTable();
                        chk002da0.Fill(chk002dt0);
                        con.Close();
                        if (chk002dt0.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }
                        //end




                        // for assetinformation

                        string qchk003 = "select a.aiid , a.atId , a.amId , a.tid , a.docid , a.Json from AssetInformation a inner join TestatorDetails b on a.tid=b.tId where b.tId = " + NestId + "  and a.doctype='Will'  and a.WillType='Detailed'  ";
                        SqlDataAdapter chk003da = new SqlDataAdapter(qchk003, con);
                        DataTable chk003dt = new DataTable();
                        chk003da.Fill(chk003dt);
                        con.Close();
                        if (chk003dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }

                        //end







                        // for asset mapping 


                        string qchk006 = "select a.Beneficiary_Asset_ID , a.AssetType_ID , a.AssetCategory_ID ,  a.Beneficiary_ID , a.Proportion , a.tid from BeneficiaryAssets a inner join TestatorDetails b on a.tid=b.tId where b.tId = " + NestId + "  and a.doctype='Will'  and a.WillType='Detailed'";
                        SqlDataAdapter chk006da = new SqlDataAdapter(qchk006, con);
                        DataTable chk006dt = new DataTable();
                        chk006da.Fill(chk006dt);
                        con.Close();

                        if (chk006dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }

                        //end








                        // for appointees 

                        con.Open();
                        string qchk008 = "select * from Appointees where tid = " + NestId + " and Type='Executor' and WillType='Detailed' ";
                        SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                        DataTable chk008dt = new DataTable();
                        chk008da.Fill(chk008dt);
                        con.Close();

                        if (chk008dt.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }

                        //end






                        // for Addwitness 

                        con.Open();
                        string qchk0082 = "select * from Appointees where tid = " + NestId + " and Type='Witness' and WillType='Detailed' ";
                        SqlDataAdapter chk008da2 = new SqlDataAdapter(qchk0082, con);
                        DataTable chk008dt2 = new DataTable();
                        chk008da2.Fill(chk008dt2);
                        con.Close();

                        if (chk008dt2.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            status = "false";
                        }

                        //end











                    }
                }

                con.Close();







            }











            return status;
        }





        public string checkcodocildocument()
        {
                string status = "";


                int NestId = 0;

                int getid = Convert.ToInt32(Session["uuid"]);


                con.Open();
                string identifydoc = "select Codocil from users where Codocil = 1 and uId = " + getid + "  ";
                SqlDataAdapter da = new SqlDataAdapter(identifydoc, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["Codocil"]) == 1)
                    {



                        string qq26 = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";


                        SqlDataAdapter daa26 = new SqlDataAdapter(qq26, con);
                        DataTable dtt26 = new DataTable();
                        daa26.Fill(dtt26);
                        if (dtt26.Rows.Count > 0)
                        {
                            NestId = Convert.ToInt32(dtt26.Rows[0]["tId"]);
                        }




                    // for Codocil 

                    
                    string qchk0082 = "select * from Codocil where tid = " + NestId + " and documentstatus='Incompleted'  ";
                    SqlDataAdapter chk008da2 = new SqlDataAdapter(qchk0082, con);
                    DataTable chk008dt2 = new DataTable();
                    chk008da2.Fill(chk008dt2);
                    con.Close();

                    if (chk008dt2.Rows.Count > 0)
                    {
                        
                        status = "false";
                    }
                    else
                    {
                        status = "true";
                    }

                    //end






                }
            }
              



                        return status;
        }







        public string checklivindocument()
        {
            string status = "";


            int NestId = 0;

            int getid = Convert.ToInt32(Session["uuid"]);


            con.Open();
            string identifydoc = "select LivingWill from users where LivingWill = 1 and uId = " + getid + "  ";
            SqlDataAdapter da = new SqlDataAdapter(identifydoc, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["LivingWill"]) == 1)
                {



                    string qq26 = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";


                    SqlDataAdapter daa26 = new SqlDataAdapter(qq26, con);
                    DataTable dtt26 = new DataTable();
                    daa26.Fill(dtt26);
                    if (dtt26.Rows.Count > 0)
                    {
                        NestId = Convert.ToInt32(dtt26.Rows[0]["tId"]);
                    }




                    // for living will 


                    string qchk0082 = "select * from living_Will where tid = " + NestId + " and documentstatus='Incompleted'  ";
                    SqlDataAdapter chk008da2 = new SqlDataAdapter(qchk0082, con);
                    DataTable chk008dt2 = new DataTable();
                    chk008da2.Fill(chk008dt2);
                    con.Close();

                    if (chk008dt2.Rows.Count > 0)
                    {
                       
                        status = "false";
                    }
                    else
                    {
                        status = "true";
                    }

                    //end






                }
            }




            return status;
        }





       




    











    }
}