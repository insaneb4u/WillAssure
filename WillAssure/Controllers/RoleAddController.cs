﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WillAssure.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace WillAssure.Controllers
{
    public class RoleAddController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: RoleAdd
        public ActionResult RoleAddIndex()
        {
            return View("~/Views/RoleAdd/AddRoleContentPage.cshtml");
        }

        public ActionResult InsertRoleFormData(RoleFormModel RFM)
        {
            int roles = 0;
            roles = Convert.ToInt32(Session["rId"]); 
            if (roles != 1)
            {
                //main Roles
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Roles", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@role ", RFM.Role);
                cmd.ExecuteNonQuery();
                con.Close();

                ViewBag.Message = "Verified";
            }
            else
            {
                //Sub Roles
                con.Open();
                string query = "insert into subroles (SubRolesName,Rid) values ('" + RFM.Role + "' , '" + roles + "')";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.ExecuteNonQuery();
                con.Close();
                ViewBag.Message = "Verified";
            }

            
            return View("~/Views/RoleAdd/AddRoleContentPage.cshtml");
        }


    }
}