using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class WillDetailModel
    {
        public int VerifyId { get; set; }
        public int Tid { get; set; }
        public string TestatorName { get; set; }
        public string TestatorLastName { get; set; }
        public string TestatorMiddleName { get; set; }
        public string TestatorDOB { get; set; }
        public string TestatorOccupation { get; set; }
        public string TestatorMobile { get; set; }
        public string TestatorEmail { get; set; }
        public string TestatorMaritalStatus { get; set; }
        public string TestatorRelationship { get; set; }
        public string TestatorReligion { get; set; }
        public string TestatorIdentityProof { get; set; }
        public string TestatorIdentityProofValue { get; set; }
        public string TestatorAltIdentityProof { get; set; }
        public string TestatorAltIdentityProofValue { get; set; }
        public string TestatorGender { get; set; }
        public string TestatorAddress1 { get; set; }
        public string TestatorAddress2 { get; set; }
        public string TestatorAddress3 { get; set; }
        public string TestatorCity { get; set; }
        public string TestatorState { get; set; }
        public string TestatorCountry { get; set; }
        public string TestatorPin { get; set; }


        public string BeneficiaryName { get; set; }
        public string BeneficiaryLastName { get; set; }
        public string BeneficiaryMiddleName { get; set; }
        public string BeneficiaryDOB { get; set; }
        public string BeneficiaryMobile { get; set; }
        public string BeneficiaryRelationship { get; set; }
        public string BeneficiaryMartialStatus { get; set; }
        public string BeneficiaryReligion { get; set; }
        public string BeneficiaryIdentityProof { get; set; }
        public string BeneficiaryIdentityProofValue { get; set; }
        public string BeneficiaryaltidentityProof { get; set; }
        public string beneficiaryaltidentityproofvalue { get; set; }
        public string beneficiaryaddress1 { get; set; }
        public string beneficiaryaddress2 { get; set; }
        public string beneficiaryaddress3 { get; set; }
        public string beneficiarycity { get; set; }
        public string beneficiarystate { get; set; }
        public string beneficiarypin { get; set; }


        public string appointeesType { get; set; }
        public string appointeesSubtype { get; set; }
        public string appointeesName { get; set; }
        public string appointeesmiddle { get; set; }
        public string appointeessurname { get; set; }
        public string appointeesidentityproof { get; set; }
        public string appointeesIdentityproofvalue { get; set; }
        public string appointeesaltidentityproof { get; set; }
        public string appointeesaltidentityproofvalue { get; set; }
        public string appointeesDOB { get; set; }
        public string appointeesGender { get; set; }
        public string appointeesOccupation { get; set; }
        public string appointeesrelationship { get; set; }
        public string appointeesaddress1 { get; set; }
        public string appointeesaddress2 { get; set; }
        public string appointeesaddress3 { get; set; }
        public string appointeescity { get; set; }
        public string appointeesstate { get; set; }
        public string appointeespin { get; set; }



        public string tffirstname { get; set; }
        public string tflastname { get; set; }
        public string tfmiddlename { get; set; }
        public string tfdob { get; set; }
        public string tfmaritalstatus { get; set; }
        public string tfreligion { get; set; }
        public string tfrelationship { get; set; }
        public string tfaddress1 { get; set; }
        public string tfaddress2 { get; set; }
        public string tfaddress3 { get; set; }
        public string tfcity { get; set; }
        public string tfstate { get; set; }
        public string tfpin { get; set; }
        public string tfidentityproof { get; set; }
        public string tfidentityproofvalue { get; set; }
        public string tfaltidentityproof { get; set; }
        public string tfaltidentityproofvalue { get; set; }
        public string tfisinformedperson { get; set; }


        public string bmassettype { get; set; }
        public string bmassetcat { get; set; }
        public string bmschemename { get; set; }
        public string bminstrumentname { get; set; }
        public string bmproportion { get; set; }


        public string altbenefirstname { get; set; }
        public string altbenelastname { get; set; }
        public string altbenemiddlename { get; set; }
        public string altbenedob { get; set; }
        public string altbenemobile { get; set; }
        public string altbenerelationship { get; set; }
        public string altbenemaritalstatus { get; set; }
        public string altbenereligion { get; set; }
        public string altbeneidentityproof { get; set; }
        public string altbeneidentityproofvalue { get; set; }
        public string altbenealtidentityproof { get; set; }
        public string altbenealtidentityproofvalue { get; set; }
        public string altbeneaddress1 { get; set; }
        public string altbeneaddress2 { get; set; }
        public string altbeneaddress3 { get; set; }
        public string altbenecity { get; set; }
        public string altbenestate { get; set; }
        public string altbenepin { get; set; }



        public string waltappointeesType { get; set; }
        public string waltappointeesSubtype { get; set; }
        public string waltappname { get; set; }
        public string waltappmiddlename { get; set; }
        public string waltappsurname { get; set; }
        public string waltappidentityproof { get; set; }
        public string waltappidentityproofvalue { get; set; }
        public string waltappaltidentityproof { get; set; }
        public string waltappaltidentityproofvalue { get; set; }
        public string waltappdob { get; set; }
        public string waltappgender { get; set; }
        public string waltappoccupation { get; set; }
        public string waltapprelationship { get; set; }
        public string waltappaddress1 { get; set; }
        public string waltappaddress2 { get; set; }
        public string waltappaddress3 { get; set; }
        public string waltappcity { get; set; }
        public string waltappstate { get; set; }
        public string wltapppin { get; set; }
        public string waltappaltguardian { get; set; }
        public string waltappaltexec { get; set; }



        public string nomfirstname { get; set; }
        public string nomlastname { get; set; }
        public string nommiddlename { get; set; }
        public string nomdob { get; set; }
        public string nommobile { get; set; }
        public string nomrelationship { get; set; }
        public string nommaritalstatus { get; set; }
        public string nomreligion { get; set; }
        public string nomidentityproof { get; set; }
        public string nomidentityproofvalue { get; set; }
        public string nomaltidentityproof { get; set; }
        public string nomaltidentityproofvalue { get; set; }
        public string nomaddress1 { get; set; }
        public string nomaddress2 { get; set; }
        public string nomaddress3 { get; set; }
        public string nomcity { get; set; }
        public string nomstate { get; set; }
        public string nompin { get; set; }




        
        public string insFirstName { get; set; }
        public string insTypeText { get; set; }
        public string insRegistrationNo { get; set; }
        public string insAddress { get; set; }
        public string insStateText { get; set; }
        public string insCityText { get; set; }
        public string inscountry_txt { get; set; }
       


    }
}