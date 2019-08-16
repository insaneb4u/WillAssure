using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using WillAssure.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CrystalDecisions.CrystalReports;
using WillAssure.CrystalReports;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace WillAssure.Views.ViewDocument
{
    
    public partial class Report : System.Web.UI.Page
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        protected void Page_Load(object sender, EventArgs e)
       {

            int documentId = Convert.ToInt32(Request.QueryString["NestId"]);
            string WillType = Request.QueryString["WillType"].ToString();
            ViewState["tid"] = documentId;

            con.Open();

           
            string docstatus = "select adminVerification from documentMaster where tId =" + documentId + "";
            SqlDataAdapter checkverify = new SqlDataAdapter(docstatus, con);
            DataTable checkverifydt = new DataTable();
            checkverify.Fill(checkverifydt);

            if (checkverifydt.Rows.Count > 0)
            {
                if (Convert.ToInt32(checkverifydt.Rows[0]["adminVerification"]) == 1)
                {
                    btnverify.Visible = false;
                }
            }

            con.Close();



            //check document matches with rules
            con.Open();
            string checkquery = "select b.templateId , b.tId , a.documentType , a.category , a.guardian , a.executors_category , a.AlternateBenficiaries , a.AlternateGaurdian , a.AlternateExecutors from documentRules a inner join documentMaster b on a.tid=b.tId where a.tid =" + documentId+"";
            SqlDataAdapter checkda = new SqlDataAdapter(checkquery, con);
            DataTable checkdt = new DataTable();
            checkda.Fill(checkdt);







            int documentType1 = 0;
            int category = 0;
            int guardian = 0;
            int executors_category = 0;
            int AlternateBenficiaries = 0;
            int AlternateGaurdian = 0;
            int AlternateExecutors = 0;
            int Dmtemplateid = 0;
            
            if (checkdt.Rows.Count > 0)
            {

                Dmtemplateid = Convert.ToInt32(checkdt.Rows[0]["templateId"]);


                if (checkdt.Rows[0]["documentType"].ToString() == "Will")
                {
                    documentType1 = 1;
                }
                if (checkdt.Rows[0]["documentType"].ToString() == "Codocil")
                {
                    documentType1 = 2;
                }
                if (checkdt.Rows[0]["documentType"].ToString() == "POA")
                {
                    documentType1 = 3;
                }
                if (checkdt.Rows[0]["documentType"].ToString() == "Giftdeeds")
                {
                    documentType1 = 4;
                }
                if (checkdt.Rows[0]["documentType"].ToString() == "LivingWill")
                {
                    documentType1 = 5;
                }
                else
                {
                    documentType1 = 1;
                }


              



                category = Convert.ToInt32(checkdt.Rows[0]["category"]);
                guardian = Convert.ToInt32(checkdt.Rows[0]["guardian"]);

                if (Convert.ToInt32(checkdt.Rows[0]["executors_category"]) == 0)
                {
                    executors_category = 1;
                }
                else
                {
                    executors_category = Convert.ToInt32(checkdt.Rows[0]["executors_category"]);
                }
                


                AlternateBenficiaries = Convert.ToInt32(checkdt.Rows[0]["AlternateBenficiaries"]);
                AlternateGaurdian = Convert.ToInt32(checkdt.Rows[0]["AlternateGaurdian"]);
                AlternateExecutors = Convert.ToInt32(checkdt.Rows[0]["AlternateExecutors"]);
              
            }




            con.Close();


            // document string

            string testator = "";
            string tdgender = "";
            string tdmaritalstatus = "";
            int Age = 0;
            string TestatorAddress = "";
            string AppointeesGender = "";
            string AppointeesName = "";
            string AlternateAppointeesGender = "";
            string TestatorFamily1 = "";
            string TestatorFamily2 = "";
            string TestatorFamily3 = "";
            string SystemDay = "";
            string SytemMonth = "";
            string SystemYear = "";
            string TestatorCity = "";
            string Witness1 = "";
            string AlternateAppointeesName = "";
            string TestatorRelationShip1 = "";
            string TestatorRelationShip2 = "";
            string AlternateBeneficiaryName = "";
            string TestatorGender = "";
            string Witness2 = "";
            string FatherHusband = "";
            string SonDaughterWife = "";

            //end


            //find match

            con.Open();
            string matchquery = "select TemplateID from DocumentIdentifier where DocumentType = " + documentType1 + " and TypeOfWill = " + category + " and AppointmentOfGuardian = " + guardian + " and NumberOfExecutors = " + executors_category + "  and AppointmentOfAltBeneficiary = " + AlternateBenficiaries + " and AppointmentOfAltGuardian = " + AlternateGaurdian + "  and AppointmentOfAltExecutor = " + AlternateExecutors + " ";
            SqlDataAdapter matchda = new SqlDataAdapter(matchquery, con);
            DataTable matchdt = new DataTable();
            matchda.Fill(matchdt);

            if (matchdt.Rows.Count > 0)
            {




               // update documentmaster with match template id

                ViewState["TemplateID"] = Convert.ToInt32(matchdt.Rows[0]["TemplateID"]);
                string query = "update documentMaster set templateId = " + Convert.ToInt32(matchdt.Rows[0]["TemplateID"]) + " where tId= " + documentId + "  ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();






                ViewState["tid"] = documentId;
               









            }


            if (WillType == "Quick")
            {

                // document query for quick will


                string docquery = " select td.First_Name as 'testator' , td.Gender as 'gender'  , td.maritalStatus as 'maritalstatus' , td.SpouseName as 'spousename' , ";
                docquery += " td.DOB as 'age' ,  td.Address1 as 'testatoraddress'  ,  appexe.Gender as 'appointeesgender' , appexe.Name as 'appointeesname'  , ";
                docquery += " DATENAME(weekday, td.dateCreated) AS 'systemday' ,  DATENAME(MONTH, td.dateCreated) AS 'systemmonth' , DATENAME(YEAR, td.dateCreated) ";
                docquery += " AS 'systemyear' , td.City as testatorcity  from TestatorDetails as td inner join BeneficiaryDetails as bd  on td.tId = bd.tId  inner join ";
                docquery += " testatorFamily tf on td.tId = tf.tId inner join Appointees as appexe on appexe.tid = td.tId  inner join Appointees as appwit on  ";
                docquery += " appwit.tid = td.tId inner join BeneficiaryAssets as ba on td.tId = ba.tid where td.tId = " + documentId + " and td.WillType = '" + WillType + "' and td.doctype = 'Will'   ";
                docquery += " and td.documentstatus = 'Completed'";

                SqlDataAdapter docda = new SqlDataAdapter(docquery, con);
                DataTable docdt = new DataTable();
                docda.Fill(docdt);




                testator = docdt.Rows[0]["testator"].ToString();
                tdgender = docdt.Rows[0]["gender"].ToString();

                tdgender = tdgender.TrimEnd();

                tdmaritalstatus = docdt.Rows[0]["maritalstatus"].ToString();


                DateTime dateOfBirth = Convert.ToDateTime(docdt.Rows[0]["age"].ToString());
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(dateOfBirth.ToString("yyyyMMdd"));
                Age = (now - dob) / 10000;






                TestatorAddress = docdt.Rows[0]["testatoraddress"].ToString();
                AppointeesGender = docdt.Rows[0]["appointeesgender"].ToString();

                AppointeesName = docdt.Rows[0]["appointeesname"].ToString();

                SystemDay = docdt.Rows[0]["systemday"].ToString();
                SytemMonth = docdt.Rows[0]["systemmonth"].ToString();
                SystemYear = docdt.Rows[0]["systemyear"].ToString();
                TestatorCity = docdt.Rows[0]["testatorcity"].ToString();

                TestatorGender = docdt.Rows[0]["gender"].ToString();

                FatherHusband = docdt.Rows[0]["testator"].ToString();



                if (tdgender == "Male")
                {
                    SonDaughterWife = "Son";
                }

                if (tdgender == "Female")
                {
                    SonDaughterWife = "Daughter";


                    if (tdmaritalstatus != "")
                    {
                        SonDaughterWife = "Wife";
                    }


                }


                ////////////////////////////////// alternate //////////////////////////


                string alterdocquery = "select Name , Gender from alternate_Appointees where tid = " + documentId + " ";
                SqlDataAdapter alterdocda = new SqlDataAdapter(alterdocquery, con);
                DataTable alterdocdt = new DataTable();
                alterdocda.Fill(alterdocdt);
                if (alterdocdt.Rows.Count > 0)
                {
                    if (alterdocdt.Rows[0]["Gender"].ToString() == "Male")
                    {
                        AlternateAppointeesGender = "Mr.";
                    }


                    if (alterdocdt.Rows[0]["Gender"].ToString() == "Female")
                    {
                        AlternateAppointeesGender = "Ms.";
                    }


                    AlternateAppointeesName = alterdocdt.Rows[0]["Name"].ToString();
                }




                ///////////////////////////////////


                string alterdocquery2 = "select top 3 First_Name  from testatorFamily where tId = " + documentId + " and WillType='" + WillType + "'";
                SqlDataAdapter alterdocda2 = new SqlDataAdapter(alterdocquery2, con);
                DataTable alterdocdt2 = new DataTable();
                alterdocda2.Fill(alterdocdt2);
                int count = 0;
                if (alterdocdt2.Rows.Count > 0)
                {


                    for (int i = 0; i < alterdocdt2.Rows.Count; i++)
                    {
                        count++;

                        if (count == 1)
                        {
                            TestatorFamily1 = alterdocdt2.Rows[i]["First_Name"].ToString();
                        }

                        if (count == 2)
                        {
                            TestatorFamily2 = alterdocdt2.Rows[i]["First_Name"].ToString();
                        }


                        if (count == 3)
                        {
                            TestatorFamily3 = alterdocdt2.Rows[i]["First_Name"].ToString();
                        }


                    }



                }




                ////////////////////////////////////





                string alterdocquery3 = "select bd.First_Name from Alternate_BeneficiaryAssets ab inner join BeneficiaryDetails bd on ab.alternatebenefciaryid = bd.bpId where bd.tId = " + documentId + " and bd.doctype = 'Will' and bd.WillType = '" + WillType + "' ";
                SqlDataAdapter alterdocda3 = new SqlDataAdapter(alterdocquery3, con);
                DataTable alterdocdt3 = new DataTable();
                alterdocda3.Fill(alterdocdt3);
                if (alterdocdt3.Rows.Count > 0)
                {



                    AlternateBeneficiaryName = alterdocdt3.Rows[0]["First_Name"].ToString();


                }









                /////////////////////////////////




                ////////////////////////////////////





                string alterdocquery4 = "select top 3 Name from Appointees where Type = 'Witness' and doctype='Will' and WillType = '" + WillType + "' and tid = " + documentId + " ";
                SqlDataAdapter alterdocda4 = new SqlDataAdapter(alterdocquery4, con);
                DataTable alterdocdt4 = new DataTable();
                alterdocda4.Fill(alterdocdt4);
                int count2 = 0;
                if (alterdocdt4.Rows.Count > 0)
                {



                    for (int i = 0; i < alterdocdt4.Rows.Count; i++)
                    {
                        count2++;

                        if (count2 == 1)
                        {
                            Witness1 = alterdocdt4.Rows[i]["Name"].ToString();
                        }

                        if (count2 == 2)
                        {
                            Witness2 = alterdocdt4.Rows[i]["Name"].ToString();
                        }




                    }


                }









                /////////////////////////////////













                //TestatorRelationShip1 = docdt.Rows[0][""].ToString();
                //TestatorRelationShip2 = docdt.Rows[0][""].ToString();





                //Witness1 = docdt.Rows[0][""].ToString();
                //Witness2 = docdt.Rows[0][""].ToString();





                ///////////////////////////////////end////////////////////////////////










                //end






                // load template





                if (Convert.ToInt32(ViewState["TemplateID"]) == 1)
                {



                    QuickWill1 rpt = new QuickWill1();
                    rpt.SetParameterValue("TestatorName", testator);
                    rpt.SetParameterValue("Son-Daughter-Wife", SonDaughterWife);   // check gender and marital status 
                    rpt.SetParameterValue("Father-Husband", FatherHusband);
                    rpt.SetParameterValue("Age", Age);
                    rpt.SetParameterValue("TestatorAddress", TestatorAddress);
                    rpt.SetParameterValue("AppointeesGender", AppointeesGender);
                    rpt.SetParameterValue("AppointeesName", AppointeesName);
                    rpt.SetParameterValue("AlternateAppointeesGender", AlternateAppointeesGender);
                    rpt.SetParameterValue("TestatorFamily1", TestatorFamily1);
                    rpt.SetParameterValue("TestatorFamily2", TestatorFamily2);
                    rpt.SetParameterValue("TestatorFamily3", TestatorFamily3);
                    rpt.SetParameterValue("SystemDay", SystemDay);
                    rpt.SetParameterValue("SytemMonth", SytemMonth);
                    rpt.SetParameterValue("SystemYear", SystemYear);
                    rpt.SetParameterValue("TestatorCity", TestatorCity);
                    rpt.SetParameterValue("Witness1", Witness1);
                    rpt.SetParameterValue("AlternateAppointeesName", AlternateAppointeesName);
                    rpt.SetParameterValue("TestatorRelationShip1", TestatorRelationShip1);
                    rpt.SetParameterValue("TestatorRelationShip2", TestatorRelationShip2);
                    rpt.SetParameterValue("AlternateBeneficiaryName", AlternateBeneficiaryName);
                    rpt.SetParameterValue("TestatorGender", TestatorGender);
                    rpt.SetParameterValue("Witness2", Witness2);



                    CrystalReportViewer1.ReportSource = rpt;

                    CrystalReportViewer1.Zoom(125);
                    var path3 = Server.MapPath("~/GeneratedPdf/file.pdf");

                    try
                    {
                        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path3);
                    }
                    catch (Exception)
                    {


                    }



                }



                if (Convert.ToInt32(ViewState["TemplateID"]) == 2)
                {
                    QuickWill3 rpt2 = new QuickWill3();
                    rpt2.SetParameterValue("testator", testator);
                    rpt2.SetParameterValue("Son-Daughter-Wife", SonDaughterWife);   // check gender and marital status 
                    rpt2.SetParameterValue("Father-Husband", FatherHusband);
                    rpt2.SetParameterValue("Age", Age);
                    rpt2.SetParameterValue("TestatorAddress", TestatorAddress);
                    rpt2.SetParameterValue("AppointeesGender", AppointeesGender);
                    rpt2.SetParameterValue("AppointeesName", AppointeesName);
                    rpt2.SetParameterValue("AlternateAppointeesGender", AlternateAppointeesGender);
                    rpt2.SetParameterValue("TestatorFamily1", TestatorFamily1);
                    rpt2.SetParameterValue("TestatorFamily2", TestatorFamily2);
                    rpt2.SetParameterValue("TestatorFamily3", TestatorFamily3);
                    rpt2.SetParameterValue("SystemDay", SystemDay);
                    rpt2.SetParameterValue("SytemMonth", SytemMonth);
                    rpt2.SetParameterValue("SystemYear", SystemYear);
                    rpt2.SetParameterValue("TestatorCity", TestatorCity);
                    rpt2.SetParameterValue("Witness1", Witness1);
                    rpt2.SetParameterValue("AlternateAppointeesName", AlternateAppointeesName);
                    rpt2.SetParameterValue("TestatorRelationShip1", TestatorRelationShip1);
                    rpt2.SetParameterValue("TestatorRelationShip2", TestatorRelationShip2);
                    rpt2.SetParameterValue("AlternateBeneficiaryName", AlternateBeneficiaryName);
                    rpt2.SetParameterValue("TestatorGender", TestatorGender);
                    rpt2.SetParameterValue("Witness2", Witness2);



                    CrystalReportViewer1.ReportSource = rpt2;
                    CrystalReportViewer1.Zoom(125);
                    var path = Server.MapPath("~/GeneratedPdf/file.pdf");



                    try
                    {
                        rpt2.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                    }
                    catch (Exception)
                    {


                    }





                }


                if (Convert.ToInt32(ViewState["TemplateID"]) == 3)
                {
                    QuickWill44 rpt6 = new QuickWill44();
                    rpt6.SetParameterValue("testator", testator);
                    rpt6.SetParameterValue("Son-Daughter-Wife", SonDaughterWife);   // check gender and marital status 
                    rpt6.SetParameterValue("Father-Husband", FatherHusband);
                    rpt6.SetParameterValue("Age", Age);
                    rpt6.SetParameterValue("TestatorAddress", TestatorAddress);
                    rpt6.SetParameterValue("AppointeesGender", AppointeesGender);
                    rpt6.SetParameterValue("AppointeesName", AppointeesName);
                    rpt6.SetParameterValue("AlternateAppointeesGender", AlternateAppointeesGender);
                    rpt6.SetParameterValue("TestatorFamily1", TestatorFamily1);
                    rpt6.SetParameterValue("TestatorFamily2", TestatorFamily2);
                    rpt6.SetParameterValue("TestatorFamily3", TestatorFamily3);
                    rpt6.SetParameterValue("SystemDay", SystemDay);
                    rpt6.SetParameterValue("SytemMonth", SytemMonth);
                    rpt6.SetParameterValue("SystemYear", SystemYear);
                    rpt6.SetParameterValue("TestatorCity", TestatorCity);
                    rpt6.SetParameterValue("Witness1", Witness1);
                    rpt6.SetParameterValue("AlternateAppointeesName", AlternateAppointeesName);
                    rpt6.SetParameterValue("TestatorRelationShip1", TestatorRelationShip1);
                    rpt6.SetParameterValue("TestatorRelationShip2", TestatorRelationShip2);
                    rpt6.SetParameterValue("AlternateBeneficiaryName", AlternateBeneficiaryName);
                    rpt6.SetParameterValue("TestatorGender", TestatorGender);
                    rpt6.SetParameterValue("Witness2", Witness2);



                    CrystalReportViewer1.ReportSource = rpt6;
                    CrystalReportViewer1.Zoom(125);
                    var path = Server.MapPath("~/GeneratedPdf/file.pdf");


                    try
                    {
                        rpt6.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                    }
                    catch (Exception)
                    {


                    }
                }




                if (Convert.ToInt32(ViewState["TemplateID"]) == 4)
                {
                    QuickWill46 rpt4 = new QuickWill46();
                    rpt4.SetParameterValue("testator", testator);
                    rpt4.SetParameterValue("Son-Daughter-Wife", SonDaughterWife);   // check gender and marital status 
                    rpt4.SetParameterValue("Father-Husband", FatherHusband);
                    rpt4.SetParameterValue("Age", Age);
                    rpt4.SetParameterValue("TestatorAddress", TestatorAddress);
                    rpt4.SetParameterValue("AppointeesGender", AppointeesGender);
                    rpt4.SetParameterValue("AppointeesName", AppointeesName);
                    rpt4.SetParameterValue("AlternateAppointeesGender", AlternateAppointeesGender);
                    rpt4.SetParameterValue("TestatorFamily1", TestatorFamily1);
                    rpt4.SetParameterValue("TestatorFamily2", TestatorFamily2);
                    rpt4.SetParameterValue("TestatorFamily3", TestatorFamily3);
                    rpt4.SetParameterValue("SystemDay", SystemDay);
                    rpt4.SetParameterValue("SytemMonth", SytemMonth);
                    rpt4.SetParameterValue("SystemYear", SystemYear);
                    rpt4.SetParameterValue("TestatorCity", TestatorCity);
                    rpt4.SetParameterValue("Witness1", Witness1);
                    rpt4.SetParameterValue("AlternateAppointeesName", AlternateAppointeesName);
                    rpt4.SetParameterValue("TestatorRelationShip1", TestatorRelationShip1);
                    rpt4.SetParameterValue("TestatorRelationShip2", TestatorRelationShip2);
                    rpt4.SetParameterValue("AlternateBeneficiaryName", AlternateBeneficiaryName);
                    rpt4.SetParameterValue("TestatorGender", TestatorGender);
                    rpt4.SetParameterValue("Witness2", Witness2);


                    ViewState["getreportdata"] = rpt4;
                    CrystalReportViewer1.ReportSource = rpt4;
                    CrystalReportViewer1.Zoom(125);
                    var path = Server.MapPath("~/GeneratedPdf/file.pdf");



                    try
                    {
                        rpt4.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                    }
                    catch (Exception)
                    {


                    }
                }



                if (Convert.ToInt32(ViewState["TemplateID"]) == 5)
                {
                    QuickWill48 rpt5 = new QuickWill48();
                    rpt5.SetParameterValue("testator", testator);
                    rpt5.SetParameterValue("Son-Daughter-Wife", SonDaughterWife);   // check gender and marital status 
                    rpt5.SetParameterValue("Father-Husband", FatherHusband);
                    rpt5.SetParameterValue("Age", Age);
                    rpt5.SetParameterValue("TestatorAddress", TestatorAddress);
                    rpt5.SetParameterValue("AppointeesGender", AppointeesGender);
                    rpt5.SetParameterValue("AppointeesName", AppointeesName);
                    rpt5.SetParameterValue("AlternateAppointeesGender", AlternateAppointeesGender);
                    rpt5.SetParameterValue("TestatorFamily1", TestatorFamily1);
                    rpt5.SetParameterValue("TestatorFamily2", TestatorFamily2);
                    rpt5.SetParameterValue("TestatorFamily3", TestatorFamily3);
                    rpt5.SetParameterValue("SystemDay", SystemDay);
                    rpt5.SetParameterValue("SytemMonth", SytemMonth);
                    rpt5.SetParameterValue("SystemYear", SystemYear);
                    rpt5.SetParameterValue("TestatorCity", TestatorCity);
                    rpt5.SetParameterValue("Witness1", Witness1);
                    rpt5.SetParameterValue("AlternateAppointeesName", AlternateAppointeesName);
                    rpt5.SetParameterValue("TestatorRelationShip1", TestatorRelationShip1);
                    rpt5.SetParameterValue("TestatorRelationShip2", TestatorRelationShip2);
                    rpt5.SetParameterValue("AlternateBeneficiaryName", AlternateBeneficiaryName);
                    rpt5.SetParameterValue("TestatorGender", TestatorGender);
                    rpt5.SetParameterValue("Witness2", Witness2);




                    CrystalReportViewer1.ReportSource = rpt5;
                    CrystalReportViewer1.Zoom(125);
                    var path = Server.MapPath("~/GeneratedPdf/file.pdf");




                    try
                    {
                        rpt5.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                    }
                    catch (Exception)
                    {


                    }


                }





                if (Convert.ToInt32(ViewState["TemplateID"]) == 6)
                {
                    QuickWill5 rpt6 = new QuickWill5();
                    rpt6.SetParameterValue("testator", testator);
                    rpt6.SetParameterValue("Son-Daughter-Wife", SonDaughterWife);   // check gender and marital status 
                    rpt6.SetParameterValue("Father-Husband", FatherHusband);
                    rpt6.SetParameterValue("Age", Age);
                    rpt6.SetParameterValue("TestatorAddress", TestatorAddress);
                    rpt6.SetParameterValue("AppointeesGender", AppointeesGender);
                    rpt6.SetParameterValue("AppointeesName", AppointeesName);
                    rpt6.SetParameterValue("AlternateAppointeesGender", AlternateAppointeesGender);
                    rpt6.SetParameterValue("TestatorFamily1", TestatorFamily1);
                    rpt6.SetParameterValue("TestatorFamily2", TestatorFamily2);
                    rpt6.SetParameterValue("TestatorFamily3", TestatorFamily3);
                    rpt6.SetParameterValue("SystemDay", SystemDay);
                    rpt6.SetParameterValue("SytemMonth", SytemMonth);
                    rpt6.SetParameterValue("SystemYear", SystemYear);
                    rpt6.SetParameterValue("TestatorCity", TestatorCity);
                    rpt6.SetParameterValue("Witness1", Witness1);
                    rpt6.SetParameterValue("AlternateAppointeesName", AlternateAppointeesName);
                    rpt6.SetParameterValue("TestatorRelationShip1", TestatorRelationShip1);
                    rpt6.SetParameterValue("TestatorRelationShip2", TestatorRelationShip2);
                    rpt6.SetParameterValue("AlternateBeneficiaryName", AlternateBeneficiaryName);
                    rpt6.SetParameterValue("TestatorGender", TestatorGender);
                    rpt6.SetParameterValue("Witness2", Witness2);


                    CrystalReportViewer1.ReportSource = rpt6;
                    CrystalReportViewer1.Zoom(125);
                    var path = Server.MapPath("~/GeneratedPdf/file.pdf");


                    try
                    {
                        rpt6.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                    }
                    catch (Exception)
                    {


                    }

                }
















                //end
            }
            else
            {

                Response.Write("<script>alert('Select Quick Will Currently Quick Will Only Available....!')</script>");

            }







        }

        protected void btnverify_Click(object sender, EventArgs e)
        {

            //ClientScript.RegisterStartupScript(this.GetType(),"randomtext","alertme()",true);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string query = "update DocumentVerification set Verification_Status = 'Active' where Tid= " + Convert.ToInt32(ViewState["tid"]) + "  ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();


            con.Open();
            string query2 = "update documentMaster set adminVerification = 1 where tId =  " + Convert.ToInt32(ViewState["tid"]) + "  ";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.ExecuteNonQuery();
            con.Close();








            // new mail code

            con.Open();
            string query3 = "select Email  from testatordetails where tId =  " + Convert.ToInt32(ViewState["tid"]) + "  ";
            SqlDataAdapter da = new SqlDataAdapter(query3, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string mailto = "";
            if (dt.Rows.Count > 0)
            {
                mailto = dt.Rows[0]["Email"].ToString();
            }




            string subject = "Will Assure";

            string body = "As Per Your Details Will Has Been Generated Please Check The Attachment Below";

            var path = Server.MapPath("~/GeneratedPdf/file.pdf");
            MailMessage msg = new MailMessage();
            Attachment data = new Attachment(path, MediaTypeNames.Application.Octet);

            msg.Attachments.Add(data);
            msg.From = new MailAddress("info@drinco.in");
            msg.To.Add(mailto);
            msg.Subject = subject;
            msg.Body = body;

            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
            smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
            smtp.EnableSsl = false;
            smtp.Send(msg);
            smtp.Dispose();



            Response.Write("<script>alert('Mail has been Send Please Check The Email')</script>");

            //end


            //btnverify.Visible = false;


        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            string query = "update DocumentVerification set Verification_Status = 'InActive' where Tid= " + Convert.ToInt32(ViewState["tid"]) + "  ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();




            con.Open();
            string query2 = "update documentMaster set adminVerification = 2 where tId =  " + Convert.ToInt32(ViewState["tid"]) + "  ";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.ExecuteNonQuery();
            con.Close();

           
        }

        protected void btnChangeTemplate_Click(object sender, EventArgs e)
        {
            int tempid = Convert.ToInt32(ViewState["tid"]);
            Response.Redirect("/ChangeTemplate/ChangeTemplateIndex?tempid=" + tempid+"");
        }

        protected void btnback_Click(object sender, EventArgs e)
        {

            int testatorid = Convert.ToInt32(ViewState["tid"]);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            
            
            con.Open();
            string query3 = "select uId from TestatorDetails where tId = "+ testatorid + " ";
            SqlDataAdapter da = new SqlDataAdapter(query3, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
               Session["uuid"]  = Convert.ToInt32(dt.Rows[0]["uId"]);

            }



            string type = Session["Type"].ToString();

            if (type == "SuperAdmin" || type == "Distributor")
            {
                Response.Redirect("/ViewDocument/ViewDocumentIndex/");
            }
            else
            {
                Response.Redirect("/TestatorHomePage/TestatorHomePageIndex/");
            }

          


        }
    }
}