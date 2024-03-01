using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Providers.Entities;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

public partial class Update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetData();
        }
    }

    protected void GetData() {
        try {
            int USER_ID = Convert.ToInt32(Request.QueryString["Id"]);
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "SELECT * FROM Users WHERE USER_ID = " + USER_ID;
                //string query = "SELECT * FROM Users WHERE USER_ID = @USER_ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFname.Text = reader["USER_FNAME"].ToString();
                            txtLname.Text = reader["USER_LNAME"].ToString();
                            txtEmail.Text = reader["USER_EMAIL"].ToString();
                            txtPass.Text = reader["USER_PASSWORD"].ToString();
                            txtContact.Text = reader["USER_CONTACT"].ToString();
                            if (Convert.ToInt32(reader["USER_GENDER"]) == 1)
                            {
                                radioBtnGender.Items[0].Selected = true;
                            }
                            else
                            {
                                radioBtnGender.Items[1].Selected = true;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("Something Broken");
            Response.Write(ex);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int USER_ID = Convert.ToInt32(Request.QueryString["Id"]);
            string USER_FNAME = txtFname.Text;
            string USER_LNAME = txtLname.Text;
            string USER_EMAIL = txtEmail.Text;
            string USER_PASSWORD = txtPass.Text;
            string USER_CONTACT = txtContact.Text;
            string USER_GENDER = radioBtnGender.SelectedValue;
            string query = "UPDATE Users SET USER_FNAME=@USER_FNAME, USER_LNAME=@USER_LNAME, USER_EMAIL=@USER_EMAIL,  USER_PASSWORD=@USER_PASSWORD, USER_CONTACT=@USER_CONTACT, USER_GENDER=@USER_GENDER WHERE USER_ID=@USER_ID";
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
                    cmd.Parameters.AddWithValue("@USER_FNAME", USER_FNAME);
                    cmd.Parameters.AddWithValue("@USER_LNAME", USER_LNAME);
                    cmd.Parameters.AddWithValue("@USER_EMAIL", USER_EMAIL);
                    cmd.Parameters.AddWithValue("@USER_PASSWORD", USER_PASSWORD);
                    cmd.Parameters.AddWithValue("@USER_CONTACT", USER_CONTACT);
                    cmd.Parameters.AddWithValue("@USER_GENDER", USER_GENDER);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("~/Default.aspx");
            //BindGrid();
        }
        catch (Exception err)
        {
            Response.Write("Error in Adding Data <br><br>");
            Response.Write(err);
        }
    }
    protected void resetData()
    {
        txtFname.Text = "";
        txtLname.Text = "";
        txtEmail.Text = "";
        txtPass.Text = "";
        txtContact.Text = "";
        radioBtnGender.Items[0].Selected = false;
        radioBtnGender.Items[1].Selected = false;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        resetData();
    }
}