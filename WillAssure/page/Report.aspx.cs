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
                executors_category = Convert.ToInt32(checkdt.Rows[0]["executors_category"]);
                AlternateBenficiaries = Convert.ToInt32(checkdt.Rows[0]["AlternateBenficiaries"]);
                AlternateGaurdian = Convert.ToInt32(checkdt.Rows[0]["AlternateGaurdian"]);
                AlternateExecutors = Convert.ToInt32(checkdt.Rows[0]["AlternateExecutors"]);
              
            }




            con.Close();




            // find match

            con.Open();
            string matchquery = "select TemplateID from DocumentIdentifier where DocumentType = "+ documentType1 + " and TypeOfWill = "+ category + " and AppointmentOfGuardian = "+ guardian + " and NumberOfExecutors = "+ executors_category + "  and AppointmentOfAltBeneficiary = "+ AlternateBenficiaries + " and AppointmentOfAltGuardian = "+ AlternateGaurdian + "  and AppointmentOfAltExecutor = "+ AlternateExecutors + " ";
            SqlDataAdapter matchda = new SqlDataAdapter(matchquery, con);
            DataTable matchdt = new DataTable();
            matchda.Fill(matchdt);

            if (matchdt.Rows.Count > 0)
            {




                // update documentmaster with match template id 

                ViewState["TemplateID"] = Convert.ToInt32(matchdt.Rows[0]["TemplateID"]);
                //string query = "update documentMaster set templateId = "+ Convert.ToInt32(matchdt.Rows[0]["TemplateID"]) + " where tId= " + documentId + "  ";
                //SqlCommand cmd = new SqlCommand(query, con);
                //cmd.ExecuteNonQuery();
             
                //




                ViewState["tid"] = documentId;
                string TestatorName = "";
                string TestatorRelationShip = "";
                int age = 0;
                string TestatorAge = "";
                string TestatorAddress = "";
                string BeneficiaryName = "";
                string executorname = "";
                string alternateexecutorname = "";
                string Relation = "";
                string assetcategory = "";
                string instrumentname = "";
                string mapbeneficiary = "";
                string proportion = "";
                string testatorsirname = "";
                string beneficiarysirname = "";
                string documenttype = "";

                string query1 = "select   a.First_Name as TestatorName , a.Last_Name as Testatorsirname , a.DOB as TestatorAge , a.RelationShip as TestatorRelationship , a.Address1 as TestatorAddress , b.First_Name as BeneficiaryName , b.Last_Name as Beneficiarysirname  , c.Name as executorname , d.Name as alternateexecutorname , e.Relationship as Relation , g.AssetsCategory , f.InstrumentName , b.First_Name as BeneficiaryName , f.Proportion  from TestatorDetails a inner join BeneficiaryDetails b on a.tId=b.tId inner join Appointees c on a.tId = c.tid inner join alternate_Appointees d on a.tId=d.tid   inner join testatorFamily e on a.tId=e.tId inner join BeneficiaryAssets f on a.tId=f.tid  inner join AssetsCategory g on g.amId=f.AssetCategory_ID    where a.tId =   " + documentId + "";
                SqlDataAdapter da = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    TestatorName = dt.Rows[0]["TestatorName"].ToString();

                    testatorsirname = dt.Rows[0]["Testatorsirname"].ToString();



                    DateTime dateOfBirth = Convert.ToDateTime(dt.Rows[0]["TestatorAge"]);
                    int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                    int dob = int.Parse(dateOfBirth.ToString("yyyyMMdd"));
                    age = (now - dob) / 10000;

                    TestatorAge = age.ToString();


                    TestatorRelationShip = dt.Rows[0]["TestatorRelationship"].ToString();


                    TestatorAddress = dt.Rows[0]["TestatorAddress"].ToString();



                    BeneficiaryName = dt.Rows[0]["BeneficiaryName"].ToString();

                    beneficiarysirname = dt.Rows[0]["Beneficiarysirname"].ToString();



                    executorname = dt.Rows[0]["executorname"].ToString();


                    alternateexecutorname = dt.Rows[0]["alternateexecutorname"].ToString();


                    Relation = dt.Rows[0]["Relation"].ToString();



                    assetcategory = dt.Rows[0]["AssetsCategory"].ToString();
                    instrumentname = dt.Rows[0]["InstrumentName"].ToString();
                    mapbeneficiary = dt.Rows[0]["BeneficiaryName"].ToString();
                    proportion = dt.Rows[0]["Proportion"].ToString();



                    con.Close();







                }



                // load template
                

                


                if (Convert.ToInt32(ViewState["TemplateID"]) == 1)
                {
                    WillTestator1 rpt = new WillTestator1();
                    rpt.SetParameterValue("testator", TestatorName);
                    rpt.SetParameterValue("testatorsirname", TestatorName + testatorsirname);
                    rpt.SetParameterValue("testatorrelation", TestatorRelationShip);
                    rpt.SetParameterValue("testatorage", TestatorAge);
                    rpt.SetParameterValue("beneficiaryname", BeneficiaryName);
                    rpt.SetParameterValue("beneficiarysirname", beneficiarysirname);
                    rpt.SetParameterValue("testatoradd", TestatorAddress);
                    rpt.SetParameterValue("appointee1", executorname);
                    rpt.SetParameterValue("appointee2", alternateexecutorname);
                    rpt.SetParameterValue("wifename", Relation);
                    rpt.SetParameterValue("assetcategory", assetcategory);
                    rpt.SetParameterValue("assetname", instrumentname);
                    rpt.SetParameterValue("benefname", mapbeneficiary);
                    rpt.SetParameterValue("percent", proportion);


                   
                    CrystalReportViewer1.ReportSource = rpt;
                    
                    CrystalReportViewer1.Zoom(125);
                    var path = Server.MapPath("~/GeneratedPdf/file.pdf");
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                }
                


                if (Convert.ToInt32(ViewState["TemplateID"]) == 2)
                {
                    WillTestator2 rpt2 = new WillTestator2();
                    rpt2.SetParameterValue("testator", TestatorName);
                    rpt2.SetParameterValue("testatorsirname", TestatorName + testatorsirname);
                    rpt2.SetParameterValue("testatorrelation", TestatorRelationShip);
                    rpt2.SetParameterValue("testatorage", TestatorAge);
                    rpt2.SetParameterValue("beneficiaryname", BeneficiaryName);
                    rpt2.SetParameterValue("beneficiarysirname", beneficiarysirname);
                    rpt2.SetParameterValue("testatoradd", TestatorAddress);
                    rpt2.SetParameterValue("appointee1", executorname);
                    rpt2.SetParameterValue("appointee2", alternateexecutorname);
                    rpt2.SetParameterValue("wifename", Relation);
                    rpt2.SetParameterValue("assetcategory", assetcategory);
                    rpt2.SetParameterValue("assetname", instrumentname);
                    rpt2.SetParameterValue("benefname", mapbeneficiary);
                    rpt2.SetParameterValue("percent", proportion);


                   
                    CrystalReportViewer1.ReportSource = rpt2;
                    CrystalReportViewer1.Zoom(125);
                    var path = Server.MapPath("~/GeneratedPdf/file.pdf");
                    rpt2.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                }
               

                if (Convert.ToInt32(ViewState["TemplateID"]) == 3)
                {
                    WillTestator3 rpt3 = new WillTestator3();
                    rpt3.SetParameterValue("testator", TestatorName);
                    rpt3.SetParameterValue("testatorsirname", TestatorName + testatorsirname);
                    rpt3.SetParameterValue("testatorrelation", TestatorRelationShip);
                    rpt3.SetParameterValue("testatorage", TestatorAge);
                    rpt3.SetParameterValue("beneficiaryname", BeneficiaryName);
                    rpt3.SetParameterValue("beneficiarysirname", beneficiarysirname);
                    rpt3.SetParameterValue("testatoradd", TestatorAddress);
                    rpt3.SetParameterValue("appointee1", executorname);
                    rpt3.SetParameterValue("appointee2", alternateexecutorname);
                    rpt3.SetParameterValue("wifename", Relation);
                    rpt3.SetParameterValue("assetcategory", assetcategory);
                    rpt3.SetParameterValue("assetname", instrumentname);
                    rpt3.SetParameterValue("benefname", mapbeneficiary);
                    rpt3.SetParameterValue("percent", proportion);


                    
                    CrystalReportViewer1.ReportSource = rpt3;
                    CrystalReportViewer1.Zoom(125);
                    var path = Server.MapPath("~/GeneratedPdf/file.pdf");
                    rpt3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                }
                



                if (Convert.ToInt32(ViewState["TemplateID"]) == 4)
                {
                    WillTestator4 rpt4 = new WillTestator4();
                    rpt4.SetParameterValue("testator", TestatorName);
                    rpt4.SetParameterValue("testatorsirname", TestatorName + testatorsirname);
                    rpt4.SetParameterValue("testatorrelation", TestatorRelationShip);
                    rpt4.SetParameterValue("testatorage", TestatorAge);
                    rpt4.SetParameterValue("beneficiaryname", BeneficiaryName);
                    rpt4.SetParameterValue("beneficiarysirname", beneficiarysirname);
                    rpt4.SetParameterValue("testatoradd", TestatorAddress);
                    rpt4.SetParameterValue("appointee1", executorname);
                    rpt4.SetParameterValue("appointee2", alternateexecutorname);
                    rpt4.SetParameterValue("wifename", Relation);
                    rpt4.SetParameterValue("assetcategory", assetcategory);
                    rpt4.SetParameterValue("assetname", instrumentname);
                    rpt4.SetParameterValue("benefname", mapbeneficiary);
                    rpt4.SetParameterValue("percent", proportion);


                  
                    CrystalReportViewer1.ReportSource = rpt4;
                    CrystalReportViewer1.Zoom(125);
                    var path = Server.MapPath("~/GeneratedPdf/file.pdf");
                    rpt4.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                }
               


                if (Convert.ToInt32(ViewState["TemplateID"]) == 5)
                {
                    WillTestator5 rpt5 = new WillTestator5();
                    rpt5.SetParameterValue("testator", TestatorName);
                    rpt5.SetParameterValue("testatorsirname", TestatorName + testatorsirname);
                    rpt5.SetParameterValue("testatorrelation", TestatorRelationShip);
                    rpt5.SetParameterValue("testatorage", TestatorAge);
                    rpt5.SetParameterValue("beneficiaryname", BeneficiaryName);
                    rpt5.SetParameterValue("beneficiarysirname", beneficiarysirname);
                    rpt5.SetParameterValue("testatoradd", TestatorAddress);
                    rpt5.SetParameterValue("appointee1", executorname);
                    rpt5.SetParameterValue("appointee2", alternateexecutorname);
                    rpt5.SetParameterValue("wifename", Relation);
                    rpt5.SetParameterValue("assetcategory", assetcategory);
                    rpt5.SetParameterValue("assetname", instrumentname);
                    rpt5.SetParameterValue("benefname", mapbeneficiary);
                    rpt5.SetParameterValue("percent", proportion);

                    

                    CrystalReportViewer1.ReportSource = rpt5;
                    CrystalReportViewer1.Zoom(125);
                    var path = Server.MapPath("~/GeneratedPdf/file.pdf");
                    rpt5.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                }



                //ReportDocument rpt = new ReportDocument();



               




            }
            else
            {

                Response.Write("<script>alert('Selected Template Does Not Match With The Rules')</script>");

            }



            //end



          

        }

        protected void btnverify_Click(object sender, EventArgs e)
        {

            ClientScript.RegisterStartupScript(this.GetType(),"randomtext","alertme()",true);


            //con.Open();
            //string query= "update DocumentVerification set Verification_Status = 'Active' where Tid= "+ Convert.ToInt32(ViewState["tid"]) + "  ";
            //SqlCommand cmd = new SqlCommand(query,con);
            //cmd.ExecuteNonQuery();
            //con.Close();


            //con.Open();
            //string query2 = "update documentMaster set adminVerification = 1 where tId =  " + Convert.ToInt32(ViewState["tid"]) + "  ";
            //SqlCommand cmd2 = new SqlCommand(query2, con);
            //cmd2.ExecuteNonQuery();
            //con.Close();








            // new mail code

            //con.Open();
            //string query3 = "select Email  from testatordetails where tId =  " + Convert.ToInt32(ViewState["tid"]) + "  ";
            //SqlDataAdapter da = new SqlDataAdapter(query3,con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //con.Close();
            //string mailto = "";
            //if (dt.Rows.Count > 0)
            //{
            //    mailto = dt.Rows[0]["Email"].ToString();
            //}


            
           
            //string subject = "Will Assure";
           
            //string body = "As Per Your Details Will Has Been Generated Please Check The Attachment Below";

            //var path = Server.MapPath("~/GeneratedPdf/file.pdf");
            //MailMessage msg = new MailMessage();
            //Attachment data = new Attachment(path, MediaTypeNames.Application.Octet);

            //msg.Attachments.Add(data);
            //msg.From = new MailAddress("info@drinco.in");
            //msg.To.Add(mailto);
            //msg.Subject = subject;
            //msg.Body = body;

            //msg.IsBodyHtml = true;
            //SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
            //smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
            //smtp.EnableSsl = false;
            //smtp.Send(msg);
            //smtp.Dispose();



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