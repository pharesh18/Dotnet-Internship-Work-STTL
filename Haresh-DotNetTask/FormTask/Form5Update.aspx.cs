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
using System.Globalization;

public partial class Form5Update : System.Web.UI.Page
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
            int STU_ID = Convert.ToInt32(Session["id"]);
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "SELECT * FROM Student WHERE STU_ID = " + STU_ID;
                //string query = "SELECT * FROM Users WHERE USER_ID = @USER_ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@STU_ID", STU_ID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TxtName.Text = reader["STU_NAME"].ToString(); ;
                            TxtEmail.Text = reader["STU_EMAIL"].ToString();
                            DropDownListYear.SelectedValue = reader["STU_YEAR"].ToString(); ;
                            string hb = reader["STU_INTEREST"].ToString();
                            string[] hbArr = hb.Split(',');
                            foreach (ListItem item in CheckBoxListInterest.Items)
                            {
                                for (int i = 0; i < hbArr.Length; i++)
                                {
                                    if (item.Value.ToString() == hbArr[i].ToString())
                                    {
                                        item.Selected = true;
                                    }
                                }
                            }
                            RadioBtnDivision.SelectedValue = reader["STU_DIVISION"].ToString();
                            string dbDateStr = Convert.ToString((DateTime)reader["STU_DOB"]);
                            DateTime dbDate = DateTime.ParseExact(dbDateStr, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            string formattedDate = dbDate.ToString("yyyy-MM-dd");
                            txtDob.Text = formattedDate;
                            txtAddress.Text = reader["STU_ADDRESS"].ToString();

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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int STU_ID = Convert.ToInt32(Session["id"]);
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

            string query = "UPDATE Student SET STU_NAME=@STU_NAME, STU_EMAIL=@STU_EMAIL, STU_YEAR=@STU_YEAR, STU_INTEREST=@STU_INTEREST, STU_DIVISION=@STU_DIVISION, STU_DOB=@STU_DOB, STU_ADDRESS=@STU_ADDRESS WHERE STU_ID=@STU_ID";
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@STU_ID", STU_ID);
                    cmd.Parameters.AddWithValue("@STU_NAME", STU_NAME);
                    cmd.Parameters.AddWithValue("@STU_EMAIL", STU_EMAIL);
                    cmd.Parameters.AddWithValue("@STU_YEAR", STU_YEAR);
                    cmd.Parameters.AddWithValue("@STU_INTEREST", STU_INTEREST);
                    cmd.Parameters.AddWithValue("@STU_DOB", STU_DOB);
                    cmd.Parameters.AddWithValue("@STU_DIVISION", STU_DIVISION);
                    cmd.Parameters.AddWithValue("@STU_ADDRESS", STU_ADDRESS);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("~/Form5.aspx");
        }
        catch (Exception err)
        {
            Response.Write("Error in Adding Data <br><br>");
            Response.Write(err);
        }
    }
}