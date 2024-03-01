using Newtonsoft.Json.Linq;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        string query = "SELECT PRODUCT_ID, PRODUCT_NAME, PRODUCT_DETAILS, PRODUCT_PRICE, PRODUCT_QUANTITY, FORMAT(PRODUCT_MAN_DATE, 'dd-MM-yyyy') AS PRODUCT_MAN_DATE, FORMAT(PRODUCT_EXP_DATE, 'dd-MM-yyyy hh:mm:ss') PRODUCT_EXP_DATE, PRODUCT_TYPE, CASE WHEN PRODUCT_QUANTITY > 0 then 'Available' else 'Not Available' end as PROUDCT_AVAILABILLITY FROM Products";
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlDataAdapter sqlada = new SqlDataAdapter(query, con))
            {
                using (DataTable dt = new DataTable())
                {
                    sqlada.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            //if (!checkValidation())
            //{
            //    return;
            //}
            string PRODUCT_NAME = txtPname.Text;
            string PRODUCT_DETAILS = txtPdetails.Text;
            string PRODUCT_PRICE = txtPrice.Text;
            string PRODUCT_QUANTITY = txtQty.Text;
            DateTime PRODUCT_MAN_DATE = DateTime.ParseExact(calManDate.SelectedDate.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime PRODUCT_EXP_DATE = DateTime.ParseExact(calExpDate.SelectedDate.ToString("dd-MM-yyyy HH:mm:ss"), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            string PRODUCT_TYPE = dropDownProductType.SelectedValue;

            string query = "INSERT INTO Products(PRODUCT_NAME, PRODUCT_DETAILS, PRODUCT_PRICE, PRODUCT_QUANTITY, PRODUCT_MAN_DATE, PRODUCT_EXP_DATE, PRODUCT_TYPE) VALUES(@PRODUCT_NAME, @PRODUCT_DETAILS, @PRODUCT_PRICE, @PRODUCT_QUANTITY, @PRODUCT_MAN_DATE, @PRODUCT_EXP_DATE, @PRODUCT_TYPE)";
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
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
            resetData();
            this.BindGrid();
        }
        catch (Exception err)
        {
            Response.Write("Error in Adding Data <br><br>");
            Response.Write(err);
        }
    }

    protected void EditData(object sender, GridViewEditEventArgs e)
    {
        int selectedIndex = e.NewEditIndex;
        string id = GridView1.Rows[selectedIndex].Cells[1].Text;

        Response.Redirect("~/UpdateProduct.aspx?Id=" + id);
    }

    protected void BoundData(object sender, GridViewRowEventArgs e)
    {
    }

    protected void DeleteData(object sender, GridViewDeleteEventArgs e)
    {
        int selectedIndex = e.RowIndex;
        int USER_ID = Convert.ToInt32(GridView1.Rows[selectedIndex].Cells[1].Text.ToString());
        string query = "DELETE FROM Products WHERE PRODUCT_ID=@PRODUCT_ID";
        string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@PRODUCT_ID", USER_ID);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        this.BindGrid();
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

    //protected bool checkValidation()
    //{
    //    if (!chkBox.Items[0].Selected)
    //    {
    //        chkValidate.Visible = true;
    //        return false;
    //    }
    //    else
    //    {
    //        return true;
    //    }
    //}

    //protected void chkBox_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (!chkBox.Items[0].Selected)
    //    {
    //        chkValidate.Visible = true;
    //    }
    //    else
    //    {
    //        chkValidate.Visible = false;
    //    }
    //}

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}