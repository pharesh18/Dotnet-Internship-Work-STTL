using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid() {
        string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        string query = "SELECT USER_ID, USER_FNAME, USER_LNAME, USER_EMAIL, USER_PASSWORD, USER_CONTACT, CASE WHEN USER_GENDER = 1 then 'Male' else 'Female' end as USER_GENDER FROM Users";
        using (SqlConnection con = new SqlConnection(constr)) {
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
            if (!checkValidation())
            {
                return;
            }
            string USER_FNAME = txtFname.Text;
            string USER_LNAME = txtLname.Text;
            string USER_EMAIL = txtEmail.Text;
            string USER_PASSWORD = txtPass.Text;
            string USER_CONTACT = txtContact.Text;
            string USER_GENDER = radioBtnGender.SelectedValue;

            string query = "INSERT INTO Users(USER_FNAME, USER_LNAME, USER_EMAIL, USER_PASSWORD, USER_CONTACT, USER_GENDER) VALUES(@USER_FNAME, @USER_LNAME, @USER_EMAIL, @USER_PASSWORD, @USER_CONTACT, @USER_GENDER)";
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
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
            resetData();
            this.BindGrid();
        }
        catch (Exception err) {
            Response.Write("Error in Adding Data <br><br>");
            Response.Write(err);
        }
    }

    protected void EditData(object sender, GridViewEditEventArgs e){
        int selectedIndex = e.NewEditIndex;
        string id = GridView1.Rows[selectedIndex].Cells[1].Text;

        Response.Redirect("~/Update.aspx?Id=" + id);
    }

    protected void BoundData(object sender, GridViewRowEventArgs e)
    {
    }

    protected void DeleteData(object sender, GridViewDeleteEventArgs e) {
        int selectedIndex = e.RowIndex;
        int USER_ID = Convert.ToInt32(GridView1.Rows[selectedIndex].Cells[1].Text.ToString());
        string query = "DELETE FROM Users WHERE USER_ID=@USER_ID";
        string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
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
        txtFname.Text = "";
        txtLname.Text = "";
        txtEmail.Text = "";
        txtPass.Text = "";
        txtContact.Text = "";
        radioBtnGender.Items[0].Selected = false;
        radioBtnGender.Items[1].Selected = false;
        chkBox.Items[0].Selected = false;
        chkValidate.Visible = false;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        resetData();
    }

    protected bool checkValidation() {
        if (!chkBox.Items[0].Selected)
        {
            chkValidate.Visible = true;
            return false;
        }
        else
        {
            return true;
        }
    }

    protected void chkBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!chkBox.Items[0].Selected)
        {
            chkValidate.Visible = true;
        }
        else
        {
            chkValidate.Visible = false;
        }
    }
}