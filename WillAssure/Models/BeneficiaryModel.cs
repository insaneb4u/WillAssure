using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class BeneficiaryModel
    {
        public int bpId { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Middle_Name { get; set; }

        public string Dob { get; set; }

        public string Mobile { get; set; }

        public string Relationship { get; set; }
        public int RelationshipId { get; set; }
        public string RelationshipTxt { get; set; }

        public string Marital_Status { get; set; }
        public string Marital_Status_TXT { get; set; }
        public int Marital_Status_ID { get; set; }

        public string Religion { get; set; }
        public string Religion_txt { get; set; }
        public int Religion_id { get; set; }

        public string Identity_proof { get; set; }
        public string Identity_proof_txt { get; set; }
        public int Identity_proof_id { get; set; }


        public string Identity_proof_value { get; set; }

        public string Alt_Identity_proof { get; set; }

        public string Alt_Identity_proof_value { get; set;}

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }


        public string City { get; set; }
        public string City_txt { get; set; }
        public int City_id { get; set; }



        public string State { get; set; }
        public string State_txt { get; set; }
        public int State_id { get; set; }


        public string country_txt { get; set; }
        public int country_id { get; set; }




        public string Pin { get; set; }

        public int aid { get; set; }

        public int tid { get; set; }

        public string dateCreated { get; set; }

        public int createdBy  { get; set; }
        public string createdBy_txt { get; set; }
        public int createdBy_id { get; set; }

        public int documentId { get; set; }

        public string beneficiary_type { get; set; }
        public string beneficiary_type_txt { get; set; }
        public int beneficiary_type_id { get; set; }



        public int ddltid { get; set; }
        public string ddltestatorname { get; set; }




        // alternate beneficiary property

        public int altlnk_bd_id { get; set; }
        public int altbpId { get; set; }
        public string altFirst_Name { get; set; }
        public string altLast_Name { get; set; }
        public string altMiddle_Name { get; set; }
        public string altDob { get; set; }
        public string altMobile { get; set; }
        public string altRelationship { get; set; }
        public string altMarital_Status { get; set; }
        public string altReligion { get; set; }
        public string altIdentity_Proof { get; set; }
        public string altIdentity_Proof_Value { get; set; }
        public string altAlt_Identity_Proof { get; set; }
        public string altAlt_Identity_Proof_Value { get; set; }
        public string altAddress1 { get; set; }
        public string altAddress2 { get; set; }
        public string altAddress3 { get; set; }
        public string altCity { get; set; }
        public string altState { get; set; }
        public string altPin { get; set; }

        public int altRelationshipId { get; set; }
        public string altRelationshipTxt { get; set; }


        public int altstateid { get; set; }
        public string altstatetext { get; set; }

        public int altcityid { get; set; }
        public string altcitytext { get; set; }


        public int altMarital_Status_Id { get; set; }
        public string altMarital_Status_Txt { get; set; }


        public int altReligion_ID { get; set; }
        public string altReligion_TXT { get; set; }



        public string check { get; set; }

    }
}