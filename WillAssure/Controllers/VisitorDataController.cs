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
    public class VisitorDataController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: VisitorData
        public string VisitorDataIndex(string displayname)
        {
            ViewBag.name = displayname;
           
          
            string response = Request["send"].ToString();

            string name = response.Split('~')[0];
            string middlename = response.Split('~')[1];
            string lastname = response.Split('~')[2];
            string contactno = response.Split('~')[3];
            string emailid = response.Split('~')[4];
            string refdistributor = response.Split('~')[5];
           
            string dateofbirth = response.Split('~')[6];
            //string willtype = response.Split('~')[7];





            if (refdistributor == null)
            {
                refdistributor = "0";
            }
          

                con.Open();

                string query = "insert into VisitorInfo (First_Name,Middle_Name,Last_Name,Mobile,Email,RefDist,uid,paymentstatus) values ('" + name + "' , '" + middlename + "' , '" + lastname + "' , '" + contactno + "' , '" + emailid + "' , '" + refdistributor + "' , 0 , 0)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();




            //    // create visitor as testator and credentials testing
            string msg1 = "";

            if (dateofbirth != "")
            {
                msg1 = "true";
                con.Open();
                string query2 = "insert into users (First_Name , Last_Name , Middle_Name , eMail , Mobile  , Type , active, rId , compId , Linked_user , Designation , Address1 , Address2 , Address3 , City , State , Pin , DOB , userID , userPwd) values ('" + name + "' , '" + lastname + "' , '" + middlename + "' , '" + emailid + "' , '" + contactno + "'  , 'Testator','Active' , 5 , 0 , '" + refdistributor + "' , 2 , 'none' , 'none' , 'none' , 'none', 'none' , 'none' , '" + Convert.ToDateTime(dateofbirth).ToString("yyyy-MM-dd") + "' , 'none' , 'none' )";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.ExecuteNonQuery();
                con.Close();


                con.Open();
                string getuid = "select top 1 uId from users order by uId desc";
                SqlDataAdapter datuid = new SqlDataAdapter(getuid, con);
                DataTable dtuid = new DataTable();
                datuid.Fill(dtuid);
                int userid = 0;
                if (dtuid.Rows.Count > 0)
                {
                    userid = Convert.ToInt32(dtuid.Rows[0]["uId"]);
                }
                con.Close();


                // get laster visitor id
                con.Open();
                string getvid = "select top 1 vid from visitorinfo order by vid desc";
                SqlDataAdapter datvid = new SqlDataAdapter(getvid, con);
                DataTable dtvid = new DataTable();
                datvid.Fill(dtvid);
                int vid = 0;
                if (dtvid.Rows.Count > 0)
                {
                    vid = Convert.ToInt32(dtvid.Rows[0]["vid"]);
                }
                con.Close();


                con.Open();
                string qqt = "update visitorinfo set uid = " + userid + " where vid = " + vid + " ";
                SqlCommand qqcmd = new SqlCommand(qqt, con);
                qqcmd.ExecuteNonQuery();
                con.Close();




                con.Open();
                string query3 = "insert into TestatorDetails (First_Name,Middle_Name,Last_Name,Mobile,Email,uid ,DOB,Occupation,maritalStatus,RelationShip,Religion,Identity_Proof,Identity_proof_Value,Alt_Identity_Proof,Alt_Identity_proof_Value,Gender,Address1,Address2,Address3,City ,State,Country ,Pin,active,documentstatus) values ('" + name + "' , '" + middlename + "' , '" + lastname + "' , '" + contactno + "' , '" + emailid + "' , " + userid + " , '" + Convert.ToDateTime(dateofbirth).ToString("yyyy-MM-dd") + "' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'no' , 'incompleted' )    ";
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd3.ExecuteNonQuery();
                con.Close();












                //generate MOBILE OTP
                string MobileOTP = "";
                MobileOTP = String.Empty;
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                int iOTPLength = 5;

                string sTempChars = String.Empty;
                Random rand = new Random();

                for (int i = 0; i < iOTPLength; i++)

                {

                    int p = rand.Next(0, saAllowedCharacters.Length);

                    sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                    MobileOTP += sTempChars;

                }
                //END




                //generate EMAIL OTP
                string EmailOTP = "";
                EmailOTP = String.Empty;
                string[] saAllowedCharacters2 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                int iOTPLength2 = 5;

                string sTempChars2 = String.Empty;
                Random rand2 = new Random();

                for (int i = 0; i < iOTPLength2; i++)

                {

                    int p = rand.Next(0, saAllowedCharacters2.Length);

                    sTempChars2 = saAllowedCharacters2[rand.Next(0, saAllowedCharacters2.Length)];

                    EmailOTP += sTempChars2;

                }
                //END



                if (emailid != "")
                {
                    // new mail code
                    string mailto = emailid;
                    string Userid = emailid;

                    Session["userid"] = Userid;
                    string subject = "Testing Mail Sending";
                    string OTP = "<font color='Green' style='font-size=3em;'>" + EmailOTP + "</font>";
                    string text = "Your OTP for Verification Is " + OTP + "";
                    string body = "<font color='red'>" + text + "</font>";


                    MailMessage msg = new MailMessage();
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



                    //end
                }



                int testatorid = 0;



                con.Open();
                string gettid = "select top 1 tId from TestatorDetails order by tId desc";
                SqlDataAdapter datid = new SqlDataAdapter(gettid, con);
                DataTable dttid = new DataTable();
                datid.Fill(dttid);
                if (dttid.Rows.Count > 0)
                {
                    testatorid = Convert.ToInt32(dttid.Rows[0]["tId"]);
                }
                con.Close();



                // document master



                con.Open();
                string q1 = "insert into documentMaster (tId,templateId,IsUpdatetable,uId,pId,created_by,testator_type,couponId,adminVerification) values (" + testatorid + " , 0 ,  'Yes' ,   " + userid + " , 1 , 0 , 0 , 0  , 2)";
                SqlCommand c = new SqlCommand(q1, con);
                c.ExecuteNonQuery();
                con.Close();

                con.Close();





                //end








                int ruleid = 0;

                con.Open();
                string getrule = "select top 1 wdId from documentRules order by wdId desc";
                SqlDataAdapter daruleid = new SqlDataAdapter(getrule, con);
                DataTable dtruleid = new DataTable();
                daruleid.Fill(dtruleid);
                if (dtruleid.Rows.Count > 0)
                {
                    ruleid = Convert.ToInt32(dtruleid.Rows[0]["wdId"]);
                }
                con.Close();


                con.Open();
                string qq2 = "update documentRules set tid =" + testatorid + " where wdId=" + ruleid + "  ";
                SqlCommand cmddd2 = new SqlCommand(qq2, con);
                cmddd2.ExecuteNonQuery();
                con.Close();



                // update otp for email and mobile

                con.Open();
                string qq = "update TestatorDetails set Contact_Verification = 0 ,Email_Verification = 0 , Mobile_Verification_Status = 0 , Email_OTP = '" + EmailOTP + "' , Mobile_OTP = '" + MobileOTP + "' where  tId = " + testatorid + " ";
                SqlCommand cmddd = new SqlCommand(qq, con);
                cmddd.ExecuteNonQuery();
                con.Close();





                //end



                //con.Open();
                //string qq22 = "insert into documentRules (tid) values (" + testatorid + ")";
                //SqlCommand cmddd22 = new SqlCommand(qq22, con);
                //cmddd22.ExecuteNonQuery();
                //con.Close();




                //end


                //mobile OTP

                //HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("http://167.86.89.78:7412/api/mt/SendSMS?user=rnarvadeempire&password=microlan@123&senderid=RNDEVE&channel=Trans&DCS=0&flashsms=0&number=" + contactno + "&text=OTP for Will Assure Verification is : " + MobileOTP + "+sms&route=1051");
                //HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();
                //System.IO.StreamReader respStreamReader = new System.IO.StreamReader(Resp.GetResponseStream());
                //string responseString = respStreamReader.ReadToEnd();
                //respStreamReader.Close();
                //Resp.Close();






                //END









                
            }
            else
            {
                msg1 = "false";
            }

            return msg1;


        }





        public string binddocument()
        {
            con.Open();
            string query = "select * from documentpricing";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            string data = "";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + " <label class='checkbox-inline'><input type='checkbox' id='checklist"+dt.Rows[i]["prid"].ToString()+"' value='" + dt.Rows[i]["Document_Price"].ToString()+"'>"+dt.Rows[i]["Document_Name"].ToString()+"</label> ";
                }
               

            }

            con.Close();

            return data;
        }



        public JsonResult checkOTP()
        {
            string message = "";
            int response = 0;
            if (Request["send"] != "")
            {
                response = Convert.ToInt32(Request["send"]);
                
            }
            else
            {
                message = "Empty";
            }
            
            string email = "";
            int userid = 0;
            if (response != 0)
            {

                string query = "select top 1 Email_OTP , Mobile_OTP , email from testatordetails order by tId desc";
                SqlDataAdapter da = new SqlDataAdapter(query,con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    email = dt.Rows[0]["email"].ToString();

                    if (Convert.ToInt32(dt.Rows[0]["Email_OTP"]) == response || Convert.ToInt32(dt.Rows[0]["Mobile_OTP"]) == response)
                    {

                        con.Open();
                        string query2 = "update TestatorDetails set Contact_Verification =1 , Email_Verification = 1 , Mobile_Verification_Status = 1 where Email_OTP = '" + response + "'";
                        SqlCommand cmd2 = new SqlCommand(query2, con);
                        cmd2.ExecuteNonQuery();
                        con.Close();



                        string quer = "select max(uId) as uId from users";
                        SqlDataAdapter daq = new SqlDataAdapter(quer, con);
                        DataTable dtq = new DataTable();
                        daq.Fill(dtq);
                        userid = Convert.ToInt32(dtq.Rows[0]["uId"]);




                        con.Open();
                        string updateotp = "update users set Designation = 1 where uid = " + userid + "  ";
                        SqlCommand cmdot = new SqlCommand(updateotp, con);
                        cmdot.ExecuteNonQuery();
                        con.Close();

                        con.Open();

                        string qq = "select a.Amt_Paid_By from Authorization_Rules a inner join TestatorDetails b on  a.Testator_Id=b.tId where b.Email_OTP = " +response+ " ";
                        SqlDataAdapter dda = new SqlDataAdapter(qq, con);
                        DataTable ddt = new DataTable();
                        dda.Fill(ddt);
                        string amtpaidby = "";
                        if (ddt.Rows.Count > 0)
                        {
                            amtpaidby = ddt.Rows[0]["Amt_Paid_By"].ToString();
                        }
                        con.Close();



                        //generate Password OTP

                        string userPassword = "";

                        userPassword = String.Empty;
                        string[] saAllowedCharacters3 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                        int iOTPLength3 = 5;

                        string sTempChars3 = String.Empty;
                        Random rand3 = new Random();

                        for (int i = 0; i < iOTPLength3; i++)

                        {

                            int p = rand3.Next(0, saAllowedCharacters3.Length);

                            sTempChars3 = saAllowedCharacters3[rand3.Next(0, saAllowedCharacters3.Length)];

                            userPassword += sTempChars3;

                        }
                        //END





                        if (email != "")
                        {
                            //generate Mail
                            string mailto2 = email;
                            string userlogin = email;


                            string subject = "Will Assure Login Credentials";

                            string text = "<font color='Green' style='font-size=3em;'>Your UserId And Password For Logging In Is <br> UserID : " + userlogin + " <br> Password : " + userPassword + "</font>";
                            string body = "<font color='red'>" + text + "</font>";


                            MailMessage msg = new MailMessage();
                            msg.From = new MailAddress("info@drinco.in");
                            msg.To.Add(mailto2);
                            msg.Subject = subject;
                            msg.Body = body;

                            msg.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
                            smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
                            smtp.EnableSsl = false;
                            smtp.Send(msg);
                            smtp.Dispose();


                            //end

                        }



                      



                        con.Open();
                        string query4 = "update users set userID = '" + email + "' , userPwd = '"+userPassword+"' where uId = " + userid + "";
                        SqlCommand cmd4 = new SqlCommand(query4, con);
                        cmd4.ExecuteNonQuery();
                        con.Close();



                         message = "true";
                    }
                    else
                    {
                        con.Open();
                        string query3 = "update TestatorDetails set Contact_Verification =2 , Email_Verification = 2 , Mobile_Verification_Status = 2 where Email_OTP = '" + response + "'";
                        SqlCommand cmd3 = new SqlCommand(query3, con);
                        cmd3.ExecuteNonQuery();
                        con.Close();
                        message = "false";
                        
                    }



                }



          }























           
            








            return Json(message);

        }




        public string BindDistributorDDL()
        {
            string data = "<option value=''>--Select Distributor--</option>";

                con.Open();
                string query2 = "select * from users where Type='DistributorAdmin'  ";
                SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                con.Close();


                if (dt2.Rows.Count > 0)
                {


                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {




                        data = data + "<option value=" + dt2.Rows[i]["uId"].ToString() + " >" + dt2.Rows[i]["First_Name"].ToString() + "</option>";



                    }
                }

            

            return data;
        }




        public string checkemailduplicate()
        {
            string response = Request["send"].ToString();
            string msg = "";
            con.Open();
            string querychk = "select count(*) from VisitorInfo  where Email = '" + response + "'  ";
            SqlCommand cmdchk = new SqlCommand(querychk, con);
            int count = (int)cmdchk.ExecuteScalar();
            con.Close();
            if (count > 0)
            {

                msg = "false";
            }
            else
            {
                msg = "true";
            }

                return msg;
        }




        public string checkenteredOTP()
        {
            int userid = 0;
            string quer = "select max(uId) as uId from users";
            SqlDataAdapter daq = new SqlDataAdapter(quer, con);
            DataTable dtq = new DataTable();
            daq.Fill(dtq);
            userid = Convert.ToInt32(dtq.Rows[0]["uId"]);

            string response = Request["send"].ToString();
            string status = "";
            con.Open();
            string chk = "select Email_OTP , Mobile_OTP  from TestatorDetails where uId = " + userid + " ";
            SqlDataAdapter da = new SqlDataAdapter(chk,con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Email_OTP"].ToString() == response || dt.Rows[0]["Mobile_OTP"].ToString() == response)
                {
                    status = "true";
                    
                }
                else
                {
                    status = "false";
                }

            }

            con.Close();



            return status;
        }



        public ActionResult  getdisplayname()
        {
            string getname = ViewBag.name;

            return View("");
        }




        public string validatedate()
        {
            string date = Convert.ToDateTime(Request["send"]).ToString("dd-MM-yyyy");
            string msg = "";
            date = date.Substring(6, date.Length - 6);
            var today = DateTime.Now.Year;
            int age = today - int.Parse(date);
           
                if (age == 0)
                {
                    msg = "false";
                }
                if (age >= 18)
                {
                    msg = "true";
                }
                else
                {
                    msg = "false";
                }
            


            return msg;
        }






    }
}