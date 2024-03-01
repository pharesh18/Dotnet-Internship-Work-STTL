using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Linq;

public partial class Form5 : System.Web.UI.Page
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
        string query = "SELECT * FROM Student";
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
            string STU_NAME = TxtName.Text;
            string STU_EMAIL = TxtEmail.Text;
            string STU_YEAR = DropDownListYear.SelectedValue;
            string STU_INTEREST = "";
            foreach (ListItem item in CheckBoxListInterest.Items)
            {
                if (item.Selected == true)
                {
                    STU_INTEREST += item.Text + ",";
                }
            }
            string STU_DIVISION = RadioBtnDivision.SelectedValue;
            DateTime STU_DOB = Convert.ToDateTime(txtDob.Text);
            string STU_ADDRESS = txtAddress.Text;

            string query = "INSERT INTO Student(STU_NAME, STU_EMAIL, STU_YEAR, STU_INTEREST, STU_DIVISION, STU_DOB, STU_ADDRESS) VALUES(@STU_NAME, @STU_EMAIL, @STU_YEAR, @STU_INTEREST, @STU_DIVISION, @STU_DOB, @STU_ADDRESS)";
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@STU_NAME", STU_NAME);
                    cmd.Parameters.AddWithValue("@STU_EMAIL", STU_EMAIL);
                    cmd.Parameters.AddWithValue("@STU_YEAR", STU_YEAR);
                    cmd.Parameters.AddWithValue("@STU_INTEREST", STU_INTEREST);
                    cmd.Parameters.AddWithValue("@STU_DIVISION", STU_DIVISION);
                    cmd.Parameters.AddWithValue("@STU_DOB", STU_DOB);
                    cmd.Parameters.AddWithValue("@STU_ADDRESS", STU_ADDRESS);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            resetFields();
            this.BindGrid();
        }
        catch (Exception err)
        {
            Response.Write("Error in Adding Data <br><br>");
            Response.Write(err);
        }
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            (e.Row.Cells[8].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        }
    }

    protected void resetFields()
    {
        TxtName.Text = "";
        TxtEmail.Text = "";
        foreach (ListItem item in DropDownListYear.Items)
        {
            item.Selected = false;
        }

        DropDownListYear.Items[0].Selected = true;

        foreach (ListItem item in CheckBoxListInterest.Items)
        {
            item.Selected = false;
        }

        foreach (ListItem item in RadioBtnDivision.Items)
        {
            item.Selected = false;
        }

        txtDob.Text = "";
        txtAddress.Text = "";
    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        resetFields();
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        Session["id"] = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
        Response.Redirect("~/Form5Update.aspx");
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        Label lblUserInfoId = row.FindControl("lblSTU_ID") as Label;
        if (lblUserInfoId != null)
        {
            int STU_ID = Convert.ToInt32(lblUserInfoId.Text);
            string query = "DELETE FROM Student WHERE STU_ID=@STU_ID";
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@STU_ID", STU_ID);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            this.BindGrid();
        }
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}