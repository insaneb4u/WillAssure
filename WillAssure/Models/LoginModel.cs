using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class LoginModel
    {

        public string UserID { get; set; }

        public string Password{ get; set; }



        public string PageStatus { get; set; }
        public string Action { get; set; }
        public string PageName { get; set; }
        public string Nav1 { get; set; }
        public string Nav2 { get; set; }

        public string EmailID { get; set; }

        [Required(ErrorMessage = "OTP is Required")]
        public string OTP { get; set; }



       public int Beneficiary_Asset_ID { get; set; }
       public int assettypeid { get; set; }
       public string AssetsType { get; set; }
       public int assetcatid { get; set; }
       public string AssetsCategory { get; set; }
       public int Beneficiaryid { get; set; }
       public string Beneficiarytxt { get; set; }
       public string SchemeName { get; set; }
       public int InstrumentId { get; set; }
       public string InstrumentName { get; set; }
       public string Proportion { get; set; }
        public int atId { get; set; }
        public string htmlcontent { get; set; }
        public int AssetsCategoryId { get; set; }

        public int prid { get; set; }
        public int documentprice { get; set; }

        public string documentname { get; set; }

      public string DDLbeneficiarycontent { get; set; }


    }
}