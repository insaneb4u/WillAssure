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
    public class AddAssetCategoryController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: AddAssetCategory
        public ActionResult AddAssetCategoryIndex()
        {
            return View("~/Views/AddAssetCategory/AddAssetCategoryPageContent.cshtml");
        }


        public ActionResult InsertAssetCategoryFormData(AssetCategoryModel ACM)
        {

           
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_AssetsCategoryCRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@atid", ACM.assettypeid);
                cmd.Parameters.AddWithValue("@assetcategory", ACM.assetcategory);
                cmd.Parameters.AddWithValue("@assetcode", ACM.assetcode);
                cmd.ExecuteNonQuery();
                con.Close();


                con.Open();
                string query = "select top 1 * from AssetsCategory order by amId desc";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string i = dt.Rows[0]["atId"].ToString();
                    string j = dt.Rows[0]["assetsCode"].ToString();
                    Session["assetCodes"] = j;
                    Session["amId"] = i;
                }


                con.Close();

                ViewBag.Message = "Verified";
            
          
              
            

          



            return View("~/Views/AddAssetCategory/AddAssetCategoryPageContent.cshtml");
        }


        public String BindAssetTypeDDL()
        {

            con.Open();
            string query = "select * from AssetsType";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["atId"].ToString() + " >" + dt.Rows[i]["AssetsType"].ToString() + "</option> ";



                }



            }

            return data;

        }



    }
}