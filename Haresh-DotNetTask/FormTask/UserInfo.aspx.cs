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

public partial class UserInfo : System.Web.UI.Page
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
        string query = "SELECT * FROM UserInfo";
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
            string USER_NAME = TxtName.Text;
            string USER_EMAIL = TxtEmail.Text;
            string USER_LANGUAGE = DropDownListLang.SelectedValue;
            string USER_HOBBY = "";
            string USER_IMAGE = Convert.ToString(ViewState["filename"]);
            foreach (ListItem item in ListBoxHobby.Items)
            {
                if (item.Selected == true)
                {
                    USER_HOBBY += item.Text + ",";
                }
            }
            DateTime USER_DOB = Convert.ToDateTime(txtDob.Text);
            string USER_FEEDBACK = txtFeedback.Text;

            //Response.Write(USER_NAME + " " + USER_EMAIL + " " + USER_LANGUAGE + " " + USER_HOBBY + " " + USER_DOB + " " + USER_FEEDBACK + " " + USER_IMAGE);
            string query = "INSERT INTO UserInfo(USER_NAME, USER_EMAIL, USER_LANGUAGE, USER_HOBBY, USER_IMAGE, USER_DOB, USER_FEEDBACK) VALUES(@USER_NAME, @USER_EMAIL, @USER_LANGUAGE, @USER_HOBBY, @USER_IMAGE, @USER_DOB, @USER_FEEDBACK)";
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@USER_NAME", USER_NAME);
                    cmd.Parameters.AddWithValue("@USER_EMAIL", USER_EMAIL);
                    cmd.Parameters.AddWithValue("@USER_LANGUAGE", USER_LANGUAGE);
                    cmd.Parameters.AddWithValue("@USER_HOBBY", USER_HOBBY);
                    cmd.Parameters.AddWithValue("@USER_IMAGE", USER_IMAGE);
                    cmd.Parameters.AddWithValue("@USER_DOB", USER_DOB);
                    cmd.Parameters.AddWithValue("@USER_FEEDBACK", USER_FEEDBACK);
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

    protected void BtnUpload_Click(object sender, EventArgs e)
    {

        if (FileUploadPhoto.HasFile)
        {
            try
            {
                string fileName = Path.GetFileName(FileUploadPhoto.FileName);
                ViewState["filename"] = fileName.ToString();
                string filePath = Server.MapPath("~/Images/" + fileName);
                FileUploadPhoto.SaveAs(filePath);

                LblMsg.Visible = true;
                LblMsg.Text = "File Uploaded Successfully";
                BtnUpload.Visible = false;
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
        else
        {
            Response.Write("Please select a file to upload.");
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
        foreach (ListItem item in DropDownListLang.Items)
        {
            item.Selected = false;
        }

        DropDownListLang.Items[0].Selected = true;

        foreach (ListItem item in ListBoxHobby.Items)
        {
            item.Selected = false;
        }

        txtDob.Text = "";
        txtFeedback.Text = "";
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        resetFields();
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        Session["id"] = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
        Response.Redirect("~/UserInfoUpdate.aspx");
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        Label lblUserInfoId = row.FindControl("lblUSER_INFO_ID") as Label;
        if (lblUserInfoId != null)
        {
            int USER_INFO_ID = Convert.ToInt32(lblUserInfoId.Text);
            string query = "DELETE FROM UserInfo WHERE USER_INFO_ID=@USER_INFO_ID";
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@USER_INFO_ID", USER_INFO_ID);
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