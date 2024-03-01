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
using System.Globalization;

public partial class UpdateProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetData();
        }
    }

    protected void GetData()
    {
        try
        {
            int PRODUCT_ID = Convert.ToInt32(Request.QueryString["Id"]);
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "SELECT * FROM Products WHERE PRODUCT_ID = " + PRODUCT_ID;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_ID", PRODUCT_ID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtPname.Text = reader["PRODUCT_NAME"].ToString();
                            txtPdetails.Text = reader["PRODUCT_DETAILS"].ToString();
                            txtPrice.Text = reader["PRODUCT_PRICE"].ToString();
                            txtQty.Text = reader["PRODUCT_QUANTITY"].ToString();
                            dropDownProductType.SelectedValue = reader["PRODUCT_TYPE"].ToString();
                            Response.Write(reader["PRODUCT_TYPE"].ToString());
                            calManDate.SelectedDate = (DateTime)reader["PRODUCT_MAN_DATE"];
                            calManDate.VisibleDate = (DateTime)reader["PRODUCT_MAN_DATE"];
                            calExpDate.SelectedDate = (DateTime)reader["PRODUCT_EXP_DATE"];
                            calExpDate.VisibleDate = (DateTime)reader["PRODUCT_EXP_DATE"];
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
            int PRODUCT_ID = Convert.ToInt32(Request.QueryString["Id"]);
            string PRODUCT_NAME = txtPname.Text;
            string PRODUCT_DETAILS = txtPdetails.Text;
            string PRODUCT_PRICE = txtPrice.Text;
            string PRODUCT_QUANTITY = txtQty.Text;
            DateTime PRODUCT_MAN_DATE = DateTime.ParseExact(calManDate.SelectedDate.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime PRODUCT_EXP_DATE = DateTime.ParseExact(calManDate.SelectedDate.ToString("dd-MM-yyyy HH:mm:ss"), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            string PRODUCT_TYPE = dropDownProductType.SelectedValue;


            string query = "UPDATE Products SET PRODUCT_NAME=@PRODUCT_NAME, PRODUCT_DETAILS=@PRODUCT_DETAILS, PRODUCT_PRICE=@PRODUCT_PRICE,  PRODUCT_QUANTITY=@PRODUCT_QUANTITY, PRODUCT_MAN_DATE=@PRODUCT_MAN_DATE, PRODUCT_EXP_DATE=@PRODUCT_EXP_DATE, PRODUCT_TYPE=@PRODUCT_TYPE WHERE PRODUCT_ID=@PRODUCT_ID";
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_ID", PRODUCT_ID);
                    cmd.Parameters.AddWithValue("@PRODUCT_NAME", PRODUCT_NAME);
                    cmd.Parameters.AddWithValue("@PRODUCT_DETAILS", PRODUCT_DETAILS);
                    cmd.Parameters.AddWithValue("@PRODUCT_PRICE", PRODUCT_PRICE);
                    cmd.Parameters.AddWithValue("@PRODUCT_QUANTITY", PRODUCT_QUANTITY);
                    cmd.Parameters.AddWithValue("@PRODUCT_MAN_DATE", PRODUCT_MAN_DATE);
                    cmd.Parameters.AddWithValue("@PRODUCT_EXP_DATE", PRODUCT_EXP_DATE);
                    cmd.Parameters.AddWithValue("@PRODUCT_TYPE", PRODUCT_TYPE);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("~/Products.aspx");
        }
        catch (Exception err)
        {
            Response.Write("Error in Adding Data <br><br>");
            Response.Write(err);
        }
    }

    protected void resetData()
    {
        txtPname.Text = "";
        txtPdetails.Text = "";
        txtPrice.Text = "";
        txtQty.Text = "";
        chkManDate.Visible = false;
        chkExpDate.Visible = false;
        calManDate.SelectedDate = new DateTime();
        calExpDate.SelectedDate = new DateTime();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        resetData();
    }
}