using MyWindowForm.DataClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyWindowForm
{
    public partial class Form1 : Form
    {
        int emp_id = -1;
        bool flag = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.EMP_NAME = TxtName.Text;
            emp.EMP_EMAIL = TxtEmail.Text;
            emp.EMP_PHONE = Convert.ToInt64(Convert.ToString(TxtBoxPhone.Text));
            emp.EMP_DEPT = Convert.ToString(ListBoxDept.SelectedItem);
            string interest = "";
            for (int i = 0; i < CheckListBoxInterest.CheckedItems.Count; i++)
            {
                interest += CheckListBoxInterest.CheckedItems[i] + ",";
            }
            emp.EMP_INTEREST = interest;
            string gender = "";
            if (RadioBtnMale.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            emp.EMP_GENDER = gender;
            emp.EMP_DOB = Convert.ToDateTime(DateTimePickerDob.Text.ToString().Split(' ')[0]);
            emp.EMP_SALARY = Convert.ToDouble(Convert.ToString(TxtBoxSalary.Text));
            emp.EMP_STATE = ComboBoxState.Text;
            emp.EMP_CITY = ComboBoxCity.Text;
            emp.EMP_ADDRESS = RichTxtBoxAddress.Text;

            if (Employee.insertEmployee(emp))
            {
                MessageBox.Show("Record Inserted Successfully!!");
                bindData();
                clearData();
            }
            else
            {
                MessageBox.Show("Error in inserting");
            }
        }

        private void bindData()
        {
            try
            {
                DataTable dataTable = new DataTable();
                Employee emp = new Employee();
                dataTable = Employee.loadData();
                DataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindData();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            emp_id = e.RowIndex;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (emp_id < 0)
                {
                    MessageBox.Show("Please Select any record!!");
                    return;
                }
                flag = false;
                Employee emp = new Employee();
                emp.EMP_ID = Convert.ToInt32(DataGridView1.Rows[emp_id].Cells[0].Value.ToString());
                Employee.deleteData(emp);
                bindData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillData()
        {
            try
            {
                //resetData();
                TxtName.Text = DataGridView1.Rows[emp_id].Cells[1].Value.ToString();
                TxtEmail.Text = DataGridView1.Rows[emp_id].Cells[2].Value.ToString();
                TxtBoxPhone.Text = DataGridView1.Rows[emp_id].Cells[3].Value.ToString();
                ListBoxDept.SelectedItem = DataGridView1.Rows[emp_id].Cells[4].Value.ToString();
                string interest = DataGridView1.Rows[emp_id].Cells[5].Value.ToString();
                string gender = DataGridView1.Rows[emp_id].Cells[6].Value.ToString();

                string[] interestArr = interest.Split(',');
                for (int i = 0; i < CheckListBoxInterest.Items.Count; i++)
                {
                    if (interestArr.Contains(CheckListBoxInterest.Items[i].ToString()))
                    {
                        CheckListBoxInterest.SetItemChecked(i, true);
                    }
                }

                if (gender == "Male")
                {
                    RadioBtnMale.Checked = true;
                }
                else
                {
                    RadioBtnFemale.Checked = true;
                }

                DateTimePickerDob.Text = DataGridView1.Rows[emp_id].Cells[7].Value.ToString();
                TxtBoxSalary.Text = DataGridView1.Rows[emp_id].Cells[8].Value.ToString();
                ComboBoxState.SelectedText = DataGridView1.Rows[emp_id].Cells[9].Value.ToString();
                ComboBoxCity.SelectedText = DataGridView1.Rows[emp_id].Cells[10].Value.ToString();
                RichTxtBoxAddress.Text = DataGridView1.Rows[emp_id].Cells[11].Value.ToString();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearData()
        {
            TxtName.Text = "";
            TxtEmail.Text = "";
            TxtBoxPhone.Text = "";
            for (int i = 0; i < ListBoxDept.Items.Count; i++)
            {
                ListBoxDept.SelectedIndices.Clear();
            }
            for (int i = 0; i < CheckListBoxInterest.Items.Count; i++)
            {
                CheckListBoxInterest.SetItemChecked(i, false);
            }
            RadioBtnMale.Checked = false;
            RadioBtnFemale.Checked = false;
            DateTimePickerDob.Value = DateTime.Now;
            TxtBoxSalary.Text = "";
            ComboBoxState.SelectedIndex = 0;
            ComboBoxCity.SelectedIndex = 0;
            RichTxtBoxAddress.Text = "";
            flag = false;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (emp_id < 0)
                {
                    MessageBox.Show("Please Select any record!!");
                    return;
                }

                if (flag == false)
                {
                    fillData();
                    flag = true;
                }
                else
                {
                    Employee emp = new Employee();
                    emp.EMP_ID = Convert.ToInt32(DataGridView1.Rows[emp_id].Cells[0].Value.ToString());
                    emp.EMP_NAME = TxtName.Text;
                    emp.EMP_EMAIL = TxtEmail.Text;
                    emp.EMP_PHONE = Convert.ToInt64(Convert.ToString(TxtBoxPhone.Text));
                    emp.EMP_DEPT = Convert.ToString(ListBoxDept.SelectedItem);
                    string interest = "";
                    for (int i = 0; i < CheckListBoxInterest.CheckedItems.Count; i++)
                    {
                        interest += CheckListBoxInterest.CheckedItems[i] + ",";
                    }
                    emp.EMP_INTEREST = interest;
                    string gender = "";
                    if (RadioBtnMale.Checked)
                    {
                        gender = "Male";
                    }
                    else
                    {
                        gender = "Female";
                    }
                    emp.EMP_GENDER = gender;
                    emp.EMP_DOB = Convert.ToDateTime(DateTimePickerDob.Text.ToString().Split(' ')[0]);
                    emp.EMP_SALARY = Convert.ToDouble(Convert.ToString(TxtBoxSalary.Text));
                    emp.EMP_STATE = ComboBoxState.Text;
                    emp.EMP_CITY = ComboBoxCity.Text;
                    emp.EMP_ADDRESS = RichTxtBoxAddress.Text;

                    if (Employee.updateEmployee(emp))
                    {
                        MessageBox.Show("Record Updated Successfully!!");
                        flag = false;
                        clearData();
                        bindData();
                    }
                    else
                    {
                        MessageBox.Show("Error in Updating");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
