using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_Operation
{
    /// <summary>
    /// Summary description for CRUD_Operation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class CRUD_Operation : System.Web.Services.WebService
    {
        static string mainconnection = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
        SqlConnection con = new SqlConnection(mainconnection);
        [WebMethod]
        public string Insert(int Pid, string PName, int PPrice)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into ProductList values('" + Pid + "','" + PName + "','" + PPrice + "')", con);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return "Inserted Succesfully";
                }
                con.Close();
            }
            catch (Exception)
            {
            }
            return "Not Done";
        }
        [WebMethod]
        public string Update(int Pid, string PName, int PPrice)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update ProductList set Prod_Name='" + PName + "',Prod_Price='" + PPrice + "'where Prod_Id='" + Pid + "'", con);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return "Update Succesfully";
                }
                con.Close();
            }
            catch (Exception)
            {
            }
            return "Not Done";
        }
        [WebMethod]
        public string Select(int Pid)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from ProductList where Prod_Id=" + Pid + "", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string pname = dt.Rows[0]["Prod_Name"].ToString();
                    string pprice = dt.Rows[0]["Prod_Price"].ToString();
                    return pname + "^" + pprice;
                }
                return "Data^NotPresent";
            }
            catch (Exception)
            {
            }
            return "Not Done";
        }
        [WebMethod]
        public string Delete(int Pid)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from ProductList where Prod_Id=" + Pid + "", con);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return "Deleted Succesfully";
                }
                con.Close();
            }
            catch (Exception)
            {
            }
            return "Not Done";
        }
        [WebMethod]
        public string ReportDB()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from ProductList", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.GetXml();
            }
            catch (Exception)
            {
            }
            return "Not Done";
        }
    }
}
