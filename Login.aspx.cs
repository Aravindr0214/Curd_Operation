using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_Operation
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static string mainconnection = System.Configuration.ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
        SqlConnection con = new SqlConnection(mainconnection);

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Login_id != null && txt_Password != null)
                {
                    SqlDataReader dr = null;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from login where LoginId='" + txt_Login_id.Text + "'and Password='" + txt_Password.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if ((string)dr["LoginId"] == txt_Login_id.Text && (string)dr["Password"] == txt_Password.Text)
                        {
                            Response.Write("<script LANGUAGE='JavaScript' >alert('Login Successfully');</script>");
                            Response.Redirect("CRUD_Form.aspx");
                        }
                        else
                        {
                            Response.Write("<script LANGUAGE='JavaScript' >alert('User Id and Password is incorrect');</script>");
                            txt_Login_id.Text = "";
                            txt_Password.Text = "";
                        }
                    }
                }

            }
            catch (Exception)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('User Id and Password is incorrect');</script>");
                txt_Login_id.Text = "";
                txt_Password.Text = "";
            }
        }
    }
}