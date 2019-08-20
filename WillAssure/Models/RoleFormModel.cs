using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class RoleFormModel
    {
        public int RoleID { get; set; }

        public string Role { get; set; }



        public int svid { get; set; }

        public string documenttype { get; set; }

        public string value { get; set; }


        public string EmailId { get; set; }
        public string Password { get; set; }



        public string oldpassword { get; set; }
        public string newpassword { get; set; }
        public string confirmpassword { get; set; }


    }
}