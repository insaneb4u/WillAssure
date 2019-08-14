using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class TestatorFamilyModel
    {
        public string alternateguardiancheck { get; set; }
        public string guardiancheck { get; set; }
        public int fId { get; set;}
      public string First_Name{ get; set; }
      public string Last_Name{ get; set; }
      public string Middle_Name{ get; set; }
      public string Dob{ get; set; }
      public string Marital_Status{ get; set; }
      public string Religion{ get; set; }
      public string Relationship{ get; set; }
      public string Address1{ get; set; }
      public string Address2{ get; set; }
      public string Address3{ get; set; }

    public string Identity_Proof_txt { get; set; }
    public string guaIdentity_Proof_txt { get; set; }
    public string altguaIdentity_Proof_txt { get; set; }


        public string City{ get; set; }
        public int City_id { get; set; }
        public string City_txt { get; set; }

        public string samecountry { get; set; }
        public string samecity { get; set; }
        public string samestate { get; set; }

        public string State{ get; set; }
        public int State_id { get; set; }
        public string State_txt { get; set; }


        public int RelationshipId { get; set; }
        public string RelationshipTxt { get; set; }

      public string Pin{ get; set; }
      public int tId{ get; set; }
      public string active{ get; set; }
      public string Identity_Proof{ get; set; }
      public string Identity_Proof_Value{ get; set; }
      public string Alt_Identity_Proof{ get; set; }
      public string Alt_Identity_Proof_Value{ get; set; }
      public string Is_Informed_Person{ get; set; }

        public string country_txt { get; set; }
        public int country_id { get; set; }

        public int ddltid { get; set; }

        public string ddltestatorname { get; set; }



        public string chek { get; set; }





        // alternate testator family
        public int altfId { get; set; }
        public string altFirst_Name { get; set; }
        public string altLast_Name { get; set; }
        public string altMiddle_Name { get; set; }
        public string altDob { get; set; }
        public string altMarital_Status { get; set; }
        public string altReligion { get; set; }
        public string altRelationship { get; set; }
        public string altAddress1 { get; set; }
        public string altAddress2 { get; set; }
        public string altAddress3 { get; set; }

        public string altCity { get; set; }
        public int altCity_id { get; set; }
        public string altCity_txt { get; set; }


        public string altState { get; set; }
        public int altState_id { get; set; }
        public string altState_txt { get; set; }


        public int altRelationshipId { get; set; }
        public string altRelationshipTxt { get; set; }

        public string altPin { get; set; }
        public int alttId { get; set; }
        public string altactive { get; set; }
        public string altIdentity_Proof { get; set; }
        public string altIdentity_Proof_Value { get; set; }
        public string altAlt_Identity_Proof { get; set; }
        public string altAlt_Identity_Proof_Value { get; set; }
        public string altIs_Informed_Person { get; set; }



        public int altddltid { get; set; }

        public string altddltestatorname { get; set; }



        public string altchek { get; set; }










        //end









        // beneficiary property



        public int benebpId { get; set; }

        public string beneFirst_Name { get; set; }

        public string beneLast_Name { get; set; }

        public string beneMiddle_Name { get; set; }

        public string beneDob { get; set; }

        public string beneMobile { get; set; }

        public string beneRelationship { get; set; }
        public int beneRelationshipId { get; set; }
        public string beneRelationshipTxt { get; set; }

        public string beneMarital_Status { get; set; }
        public string beneMarital_Status_TXT { get; set; }
        public int beneMarital_Status_ID { get; set; }

        public string beneReligion { get; set; }
        public string beneReligion_txt { get; set; }
        public int beneReligion_id { get; set; }

        public string beneIdentity_proof { get; set; }
        public string beneIdentity_proof_txt { get; set; }
        public int beneIdentity_proof_id { get; set; }


        public string beneIdentity_proof_value { get; set; }

        public string beneAlt_Identity_proof { get; set; }

        public string beneAlt_Identity_proof_value { get; set; }

        public string beneAddress1 { get; set; }

        public string beneAddress2 { get; set; }

        public string beneAddress3 { get; set; }


        public string beneCity { get; set; }
        public string beneCity_txt { get; set; }
        public int beneCity_id { get; set; }



        public string beneState { get; set; }
        public string beneState_txt { get; set; }
        public int beneState_id { get; set; }




        public string benePin { get; set; }

        public int beneaid { get; set; }

        public int benetid { get; set; }

        public string benedateCreated { get; set; }

        public int benecreatedBy { get; set; }
        public string benecreatedBy_txt { get; set; }
        public int benecreatedBy_id { get; set; }

        public int benedocumentId { get; set; }

        public string benebeneficiary_type { get; set; }
        public string benebeneficiary_type_txt { get; set; }
        public int benebeneficiary_type_id { get; set; }



        public int beneddltid { get; set; }
        public string beneddltestatorname { get; set; }








        //guardian property


        public int guaapId { get; set; }
        public int guadocumentId { get; set; }
        public string gauType { get; set; }
        public int guaTypeId { get; set; }
        public string guaTypetxt { get; set; }
        public string guasubType { get; set; }
        public int guasubTypeId { get; set; }
        public string guasubTypetxt { get; set; }
        public string guaName { get; set; }
        public string guamiddleName { get; set; }
        public string guaSurname { get; set; }
        public string guaIdentity_Proof { get; set; }
        public string guaIdentity_Proof_Value { get; set; }
        public string guaAlt_Identity_Proof { get; set; }
        public string guaAlt_Identity_Proof_Value { get; set; }
        public string guaDob { get; set; }
        public string guaGender { get; set; }
        public string guaOccupation { get; set; }

        public string guaRelationship { get; set; }
        public int guaRelationshipId { get; set; }
        public string guaRelationshipTxt { get; set; }

        public string guaAddress1 { get; set; }
        public string guaAddress2 { get; set; }
        public string guaAddress3 { get; set; }

        public string guaCity { get; set; }
        public int guacityid { get; set; }
        public string guacitytext { get; set; }

        public string guaState { get; set; }
        public int guastateid { get; set; }
        public string guastatetext { get; set; }



        public int guacountryid { get; set; }
        public string guacountrytext { get; set; }

        public string guaPin { get; set; }
        public int guarid { get; set; }













        public int altguaapId { get; set; }
        public int altguadocumentId { get; set; }
        public string altgauType { get; set; }
        public int altguaTypeId { get; set; }
        public string altguaTypetxt { get; set; }
        public string altguasubType { get; set; }
        public int altguasubTypeId { get; set; }
        public string altguasubTypetxt { get; set; }
        public string altguaName { get; set; }
        public string altguamiddleName { get; set; }
        public string altguaSurname { get; set; }
        public string altguaIdentity_Proof { get; set; }
        public string altguaIdentity_Proof_Value { get; set; }
        public string altguaAlt_Identity_Proof { get; set; }
        public string altguaAlt_Identity_Proof_Value { get; set; }
        public string altguaDob { get; set; }
        public string altguaGender { get; set; }
        public string altguaOccupation { get; set; }

        public string altguaRelationship { get; set; }
        public int altguaRelationshipId { get; set; }
        public string altguaRelationshipTxt { get; set; }

        public string altguaAddress1 { get; set; }
        public string altguaAddress2 { get; set; }
        public string altguaAddress3 { get; set; }

        public string altguaCity { get; set; }
        public int altguacityid { get; set; }
        public string altguacitytext { get; set; }

        public string altguaState { get; set; }
        public int altguastateid { get; set; }
        public string altguastatetext { get; set; }



        public int altguacountryid { get; set; }
        public string altguacountrytext { get; set; }

        public string altguaPin { get; set; }
        public int altguarid { get; set; }





        //end






    };
};