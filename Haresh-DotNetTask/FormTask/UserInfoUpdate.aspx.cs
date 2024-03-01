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

public partial class UserInfoUpdate : System.Web.UI.Page
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
            int USER_INFO_ID = Convert.ToInt32(Session["id"]);
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "SELECT * FROM UserInfo WHERE USER_INFO_ID = " + USER_INFO_ID;
                //string query = "SELECT * FROM Users WHERE USER_ID = @USER_ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@USER_INFO_ID", USER_INFO_ID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TxtName.Text = reader["USER_NAME"].ToString(); ;
                            TxtEmail.Text = reader["USER_EMAIL"].ToString();
                            DropDownListLang.SelectedValue = reader["USER_LANGUAGE"].ToString(); ;
                            string hb = reader["USER_HOBBY"].ToString();
                            string[] hbArr = hb.Split(',');
                            foreach (ListItem item in ListBoxHobby.Items)
                            {
                                for (int i = 0; i < hbArr.Length; i++)
                                {
                                    if (item.Value.ToString() == hbArr[i].ToString())
                                    {
                                        item.Selected = true;
                                    }
                                }
                            }
                            string dbDateStr = Convert.ToString((DateTime)reader["USER_DOB"]);
                            DateTime dbDate = DateTime.ParseExact(dbDateStr, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            string formattedDate = dbDate.ToString("yyyy-MM-dd");
                            txtDob.Text = formattedDate;
                            txtFeedback.Text = reader["USER_FEEDBACK"].ToString();

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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int USER_INFO_ID = Convert.ToInt32(Session["id"]);
            string USER_NAME = TxtName.Text;
            string USER_EMAIL = TxtEmail.Text;
            string USER_LANGUAGE = DropDownListLang.SelectedValue;
            string USER_HOBBY = "";
            foreach (ListItem item in ListBoxHobby.Items)
            {
                if (item.Selected == true)
                {
                    USER_HOBBY += item.Text + ",";
                }
            }
            string USER_FEEDBACK = txtFeedback.Text;
            DateTime USER_DOB = Convert.ToDateTime(txtDob.Text);

            string query = "UPDATE UserInfo SET USER_NAME=@USER_NAME, USER_EMAIL=@USER_EMAIL, USER_LANGUAGE=@USER_LANGUAGE, USER_HOBBY=@USER_HOBBY, USER_DOB=@USER_DOB, USER_FEEDBACK=@USER_FEEDBACK WHERE USER_INFO_ID=@USER_INFO_ID";
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@USER_INFO_ID", USER_INFO_ID);
                    cmd.Parameters.AddWithValue("@USER_NAME", USER_NAME);
                    cmd.Parameters.AddWithValue("@USER_EMAIL", USER_EMAIL);
                    cmd.Parameters.AddWithValue("@USER_LANGUAGE", USER_LANGUAGE);
                    cmd.Parameters.AddWithValue("@USER_HOBBY", USER_HOBBY);
                    cmd.Parameters.AddWithValue("@USER_FEEDBACK", USER_FEEDBACK);
                    cmd.Parameters.AddWithValue("@USER_DOB", USER_DOB);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("~/UserInfo.aspx");
        }
        catch (Exception err)
        {
            Response.Write("Error in Adding Data <br><br>");
            Response.Write(err);
        }
    }
}