using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class BeneficiaryInstitutionModel
    {
        public int BiId { get; set; }

        public string FirstName { get; set; }

        public int TypeId { get; set; }

        public string TypeText { get; set; }

        public int RegistrationNo { get; set; }

        public string Address { get; set; }

        public string StateText { get; set; }
        public int StateId { get; set; }


        public string CityText { get; set; }
        public int CityId { get; set; }





        /////////////////////////////////////////////////////////////
        // alternate institution


        public int altBiId { get; set; }

        public string altFirstName { get; set; }

        public int altTypeId { get; set; }

        public string altTypeText { get; set; }

        public int altRegistrationNo { get; set; }

        public string altAddress { get; set; }

        public string altStateText { get; set; }
        public int altStateId { get; set; }


        public string altCityText { get; set; }
        public int altCityId { get; set; }



        public string altchek { get; set; }


        //end






    }
}