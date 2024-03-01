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

public partial class Form4 : System.Web.UI.Page
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
        string query = "SELECT * FROM Employee";
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
            string EMP_NAME = TxtName.Text;
            string EMP_PHONE = TxtPhone.Text;
            string EMP_CITY = DropDownListCity.SelectedValue;
            string EMP_IMAGE = Convert.ToString(ViewState["filename"]);
            string EMP_INTEREST = "";
            foreach (ListItem item in CheckBoxListInterest.Items)
            {
                if (item.Selected == true)
                {
                    EMP_INTEREST += item.Text + ",";
                }
            }
            string EMP_DEPT = RadioBtnDept.SelectedValue;
            double EMP_SALARY = Convert.ToDouble(Convert.ToString(TxtSalary.Text));
            DateTime EMP_START_DATE = Convert.ToDateTime(txtDate.Text);

            string query = "INSERT INTO Employee(EMP_NAME, EMP_PHONE, EMP_CITY, EMP_IMAGE, EMP_INTEREST, EMP_DEPT, EMP_SALARY, EMP_START_DATE) VALUES(@EMP_NAME, @EMP_PHONE, @EMP_CITY, @EMP_IMAGE, @EMP_INTEREST, @EMP_DEPT, @EMP_SALARY, @EMP_START_DATE)";
            string constr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@EMP_NAME", EMP_NAME);
                    cmd.Parameters.AddWithValue("@EMP_PHONE", EMP_PHONE);
                    cmd.Parameters.AddWithValue("@EMP_CITY", EMP_CITY);
                    cmd.Parameters.AddWithValue("@EMP_IMAGE", EMP_IMAGE);
                    cmd.Parameters.AddWithValue("@EMP_INTEREST", EMP_INTEREST);
                    cmd.Parameters.AddWithValue("@EMP_DEPT", EMP_DEPT);
                    cmd.Parameters.AddWithValue("@EMP_SALARY", EMP_SALARY);
                    cmd.Parameters.AddWithValue("@EMP_START_DATE", EMP_START_DATE);

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

    protected void resetFields()
    {
        TxtName.Text = "";
        TxtPhone.Text = "";
        foreach (ListItem item in DropDownListCity.Items)
        {
            item.Selected = false;
        }

        DropDownListCity.Items[0].Selected = true;

        foreach (ListItem item in CheckBoxListInterest.Items)
        {
            item.Selected = false;
        }

        foreach (ListItem item in RadioBtnDept.Items)
        {
            item.Selected = false;
        }

        TxtSalary.Text = "";
        txtDate.Text = "";
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        resetFields();
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}