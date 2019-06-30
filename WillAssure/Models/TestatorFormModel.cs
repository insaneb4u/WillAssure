using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class TestatorFormModel
    {

        public int tId { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Middle_Name { get; set; }

        public string Dob { get; set; }

        public string Dobb { get; set; }

        public string Occupation { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }
        public string material_status { get; set; }
        public string material_status_id { get; set; }
        public string material_status_txt { get; set; }


        public string Gendertext { get; set; }
        public int GenderId { get; set; }

        public string Religiontext { get; set; }
        public int ReligionId { get; set; }

        public string RelationshipTxt { get; set; }
        public int RelationshipId { get; set; }

        public string Identity_Proof { get; set; }
        public string Identity_Proof_txt { get; set; }
        public int Identity_Proof_ID { get; set; }



        public string Identity_proof_Value { get; set; }

        public string Alt_Identity_Proof { get; set; }

        public string Alt_Identity_proof_Value { get; set; }

   


        public string Address1 { get; set; }


        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string citytext { get; set; }

        public int cityid { get; set; }




        public string statetext { get; set; }

        public int  stateid { get; set; }

        public string countrytext { get; set; }

        public int  countryid { get; set; }

        public string Pin { get; set; }

        public string active { get; set; }

        public int uId { get; set; }

        public int Contact_Verification { get; set; }

        public int Email_Verification { get; set; }

        public int  Mobile_Verification_Status { get; set; }


        public string Document_Created_By { get; set; }
        public string Document_Created_By_txt { get; set; }
        public int Document_Created_By_ID { get; set; }

        public string Amt_Paid_By { get; set; }
        public string Amt_Paid_By_txt { get; set; }
        public int Amt_Paid_By_By_ID { get; set; }

        public int Authentication_Required { get; set; }
        public int Link_Required { get; set; }
        public int Login_Required { get; set; }

        public string password = "admin@1234";


        public string EmailOTP { get; set; }
        public string MobileOTP { get; set; }
        public string userPassword { get; set; }


        public string documenttype { get; set; }
        public string documentcategory { get; set; } 



        public int distributor_id { get; set; }

        public string distributor_txt { get; set; }

        public string txtCoupon { get; set; }

        public string activetxt { get; set; }


        public string tempemailotp { get; set; }
        public string tempmobileotp { get; set; }


        public string successmessage { get; set; }
    }


 



}