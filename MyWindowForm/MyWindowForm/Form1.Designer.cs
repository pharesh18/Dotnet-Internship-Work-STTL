namespace MyWindowForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.LblAddress = new System.Windows.Forms.Label();
            this.LblCity = new System.Windows.Forms.Label();
            this.LblInterest = new System.Windows.Forms.Label();
            this.LblState = new System.Windows.Forms.Label();
            this.LblSalary = new System.Windows.Forms.Label();
            this.LblGender = new System.Windows.Forms.Label();
            this.LblDept = new System.Windows.Forms.Label();
            this.LblDob = new System.Windows.Forms.Label();
            this.LblPhone = new System.Windows.Forms.Label();
            this.LblEmail = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.CheckListBoxInterest = new System.Windows.Forms.CheckedListBox();
            this.DateTimePickerDob = new System.Windows.Forms.DateTimePicker();
            this.GroupBoxGender = new System.Windows.Forms.GroupBox();
            this.RadioBtnFemale = new System.Windows.Forms.RadioButton();
            this.RadioBtnMale = new System.Windows.Forms.RadioButton();
            this.ListBoxDept = new System.Windows.Forms.ListBox();
            this.ComboBoxState = new System.Windows.Forms.ComboBox();
            this.ComboBoxCity = new System.Windows.Forms.ComboBox();
            this.RichTxtBoxAddress = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TxtBoxSalary = new System.Windows.Forms.TextBox();
            this.TxtBoxPhone = new System.Windows.Forms.TextBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.GroupBoxGender.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F);
            this.label1.Location = new System.Drawing.Point(541, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Data Form";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.LblName.Location = new System.Drawing.Point(99, 111);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(64, 23);
            this.LblName.TabIndex = 1;
            this.LblName.Text = "Name";
            // 
            // LblAddress
            // 
            this.LblAddress.AutoSize = true;
            this.LblAddress.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.LblAddress.Location = new System.Drawing.Point(99, 447);
            this.LblAddress.Name = "LblAddress";
            this.LblAddress.Size = new System.Drawing.Size(86, 23);
            this.LblAddress.TabIndex = 3;
            this.LblAddress.Text = "Address";
            // 
            // LblCity
            // 
            this.LblCity.AutoSize = true;
            this.LblCity.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.LblCity.Location = new System.Drawing.Point(1206, 352);
            this.LblCity.Name = "LblCity";
            this.LblCity.Size = new System.Drawing.Size(47, 23);
            this.LblCity.TabIndex = 4;
            this.LblCity.Text = "City";
            // 
            // LblInterest
            // 
            this.LblInterest.AutoSize = true;
            this.LblInterest.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.LblInterest.Location = new System.Drawing.Point(679, 173);
            this.LblInterest.Name = "LblInterest";
            this.LblInterest.Size = new System.Drawing.Size(84, 23);
            this.LblInterest.TabIndex = 5;
            this.LblInterest.Text = "Interest";
            // 
            // LblState
            // 
            this.LblState.AutoSize = true;
            this.LblState.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.LblState.Location = new System.Drawing.Point(679, 355);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(59, 23);
            this.LblState.TabIndex = 6;
            this.LblState.Text = "State";
            // 
            // LblSalary
            // 
            this.LblSalary.AutoSize = true;
            this.LblSalary.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.LblSalary.Location = new System.Drawing.Point(99, 341);
            this.LblSalary.Name = "LblSalary";
            this.LblSalary.Size = new System.Drawing.Size(70, 23);
            this.LblSalary.TabIndex = 7;
            this.LblSalary.Text = "Salary";
            // 
            // LblGender
            // 
            this.LblGender.AutoSize = true;
            this.LblGender.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.LblGender.Location = new System.Drawing.Point(1206, 174);
            this.LblGender.Name = "LblGender";
            this.LblGender.Size = new System.Drawing.Size(79, 23);
            this.LblGender.TabIndex = 8;
            this.LblGender.Text = "Gender";
            // 
            // LblDept
            // 
            this.LblDept.AutoSize = true;
            this.LblDept.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.LblDept.Location = new System.Drawing.Point(99, 173);
            this.LblDept.Name = "LblDept";
            this.LblDept.Size = new System.Drawing.Size(122, 23);
            this.LblDept.TabIndex = 9;
            this.LblDept.Text = "Department";
            // 
            // LblDob
            // 
            this.LblDob.AutoSize = true;
            this.LblDob.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.LblDob.Location = new System.Drawing.Point(1206, 281);
            this.LblDob.Name = "LblDob";
            this.LblDob.Size = new System.Drawing.Size(136, 23);
            this.LblDob.TabIndex = 10;
            this.LblDob.Text = "Date Of Birth";
            // 
            // LblPhone
            // 
            this.LblPhone.AutoSize = true;
            this.LblPhone.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.LblPhone.Location = new System.Drawing.Point(1206, 111);
            this.LblPhone.Name = "LblPhone";
            this.LblPhone.Size = new System.Drawing.Size(150, 23);
            this.LblPhone.TabIndex = 11;
            this.LblPhone.Text = "Phone Number";
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.LblEmail.Location = new System.Drawing.Point(679, 111);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(63, 23);
            this.LblEmail.TabIndex = 12;
            this.LblEmail.Text = "Email";
            // 
            // TxtName
            // 
            this.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtName.Font = new System.Drawing.Font("Gadugi", 8.25F);
            this.TxtName.Location = new System.Drawing.Point(263, 114);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(241, 22);
            this.TxtName.TabIndex = 0;
            // 
            // TxtEmail
            // 
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmail.Location = new System.Drawing.Point(851, 114);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(241, 20);
            this.TxtEmail.TabIndex = 1;
            // 
            // CheckListBoxInterest
            // 
            this.CheckListBoxInterest.CheckOnClick = true;
            this.CheckListBoxInterest.Font = new System.Drawing.Font("Verdana", 12F);
            this.CheckListBoxInterest.FormattingEnabled = true;
            this.CheckListBoxInterest.Items.AddRange(new object[] {
            "Reading",
            "Sports",
            "Writing",
            "Singing",
            "Dancing"});
            this.CheckListBoxInterest.Location = new System.Drawing.Point(851, 173);
            this.CheckListBoxInterest.Name = "CheckListBoxInterest";
            this.CheckListBoxInterest.Size = new System.Drawing.Size(241, 114);
            this.CheckListBoxInterest.TabIndex = 4;
            // 
            // DateTimePickerDob
            // 
            this.DateTimePickerDob.Font = new System.Drawing.Font("Verdana", 12F);
            this.DateTimePickerDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePickerDob.Location = new System.Drawing.Point(1388, 277);
            this.DateTimePickerDob.Name = "DateTimePickerDob";
            this.DateTimePickerDob.Size = new System.Drawing.Size(241, 27);
            this.DateTimePickerDob.TabIndex = 8;
            // 
            // GroupBoxGender
            // 
            this.GroupBoxGender.Controls.Add(this.RadioBtnFemale);
            this.GroupBoxGender.Controls.Add(this.RadioBtnMale);
            this.GroupBoxGender.Location = new System.Drawing.Point(1388, 174);
            this.GroupBoxGender.Name = "GroupBoxGender";
            this.GroupBoxGender.Size = new System.Drawing.Size(241, 62);
            this.GroupBoxGender.TabIndex = 5;
            this.GroupBoxGender.TabStop = false;
            // 
            // RadioBtnFemale
            // 
            this.RadioBtnFemale.AutoSize = true;
            this.RadioBtnFemale.Font = new System.Drawing.Font("Verdana", 12.25F);
            this.RadioBtnFemale.Location = new System.Drawing.Point(120, 22);
            this.RadioBtnFemale.Name = "RadioBtnFemale";
            this.RadioBtnFemale.Size = new System.Drawing.Size(89, 24);
            this.RadioBtnFemale.TabIndex = 7;
            this.RadioBtnFemale.TabStop = true;
            this.RadioBtnFemale.Text = "Female";
            this.RadioBtnFemale.UseVisualStyleBackColor = true;
            // 
            // RadioBtnMale
            // 
            this.RadioBtnMale.AutoSize = true;
            this.RadioBtnMale.Font = new System.Drawing.Font("Verdana", 12.25F);
            this.RadioBtnMale.Location = new System.Drawing.Point(28, 22);
            this.RadioBtnMale.Name = "RadioBtnMale";
            this.RadioBtnMale.Size = new System.Drawing.Size(66, 24);
            this.RadioBtnMale.TabIndex = 6;
            this.RadioBtnMale.TabStop = true;
            this.RadioBtnMale.Text = "Male";
            this.RadioBtnMale.UseVisualStyleBackColor = true;
            // 
            // ListBoxDept
            // 
            this.ListBoxDept.Font = new System.Drawing.Font("Verdana", 12F);
            this.ListBoxDept.FormattingEnabled = true;
            this.ListBoxDept.ItemHeight = 18;
            this.ListBoxDept.Items.AddRange(new object[] {
            "Technical",
            "Sales",
            "Marketing",
            "Finance"});
            this.ListBoxDept.Location = new System.Drawing.Point(263, 173);
            this.ListBoxDept.Name = "ListBoxDept";
            this.ListBoxDept.Size = new System.Drawing.Size(241, 94);
            this.ListBoxDept.TabIndex = 3;
            // 
            // ComboBoxState
            // 
            this.ComboBoxState.FormattingEnabled = true;
            this.ComboBoxState.Items.AddRange(new object[] {
            "Gujarat",
            "Madhya Pradesh",
            "Uttar Pradesh",
            "Karnataka",
            "Kerala"});
            this.ComboBoxState.Location = new System.Drawing.Point(851, 357);
            this.ComboBoxState.Name = "ComboBoxState";
            this.ComboBoxState.Size = new System.Drawing.Size(241, 21);
            this.ComboBoxState.TabIndex = 11;
            // 
            // ComboBoxCity
            // 
            this.ComboBoxCity.FormattingEnabled = true;
            this.ComboBoxCity.Items.AddRange(new object[] {
            "Ahmedabad",
            "Surat",
            "Palanpur",
            "Rajkot"});
            this.ComboBoxCity.Location = new System.Drawing.Point(1370, 357);
            this.ComboBoxCity.Name = "ComboBoxCity";
            this.ComboBoxCity.Size = new System.Drawing.Size(241, 21);
            this.ComboBoxCity.TabIndex = 12;
            this.ComboBoxCity.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // RichTxtBoxAddress
            // 
            this.RichTxtBoxAddress.Location = new System.Drawing.Point(263, 435);
            this.RichTxtBoxAddress.Name = "RichTxtBoxAddress";
            this.RichTxtBoxAddress.Size = new System.Drawing.Size(829, 79);
            this.RichTxtBoxAddress.TabIndex = 13;
            this.RichTxtBoxAddress.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnClear);
            this.panel1.Controls.Add(this.BtnDelete);
            this.panel1.Controls.Add(this.BtnEdit);
            this.panel1.Controls.Add(this.BtnAdd);
            this.panel1.Location = new System.Drawing.Point(263, 571);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 80);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BtnClear
            // 
            this.BtnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BtnClear.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.BtnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnClear.Location = new System.Drawing.Point(729, 21);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(126, 41);
            this.BtnClear.TabIndex = 20;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.Red;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.BtnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnDelete.Location = new System.Drawing.Point(514, 21);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(126, 41);
            this.BtnDelete.TabIndex = 19;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnEdit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.BtnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnEdit.Location = new System.Drawing.Point(295, 21);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(126, 41);
            this.BtnEdit.TabIndex = 18;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnAdd.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.BtnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAdd.Location = new System.Drawing.Point(71, 21);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(126, 41);
            this.BtnAdd.TabIndex = 17;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TxtBoxSalary
            // 
            this.TxtBoxSalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBoxSalary.Location = new System.Drawing.Point(263, 358);
            this.TxtBoxSalary.Name = "TxtBoxSalary";
            this.TxtBoxSalary.Size = new System.Drawing.Size(241, 20);
            this.TxtBoxSalary.TabIndex = 10;
            // 
            // TxtBoxPhone
            // 
            this.TxtBoxPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBoxPhone.Location = new System.Drawing.Point(1388, 114);
            this.TxtBoxPhone.Name = "TxtBoxPhone";
            this.TxtBoxPhone.Size = new System.Drawing.Size(241, 20);
            this.TxtBoxPhone.TabIndex = 2;
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(263, 698);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(1261, 142);
            this.DataGridView1.TabIndex = 27;
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1784, 1061);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.TxtBoxPhone);
            this.Controls.Add(this.TxtBoxSalary);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RichTxtBoxAddress);
            this.Controls.Add(this.ComboBoxCity);
            this.Controls.Add(this.ComboBoxState);
            this.Controls.Add(this.ListBoxDept);
            this.Controls.Add(this.GroupBoxGender);
            this.Controls.Add(this.DateTimePickerDob);
            this.Controls.Add(this.CheckListBoxInterest);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.LblEmail);
            this.Controls.Add(this.LblPhone);
            this.Controls.Add(this.LblDob);
            this.Controls.Add(this.LblDept);
            this.Controls.Add(this.LblGender);
            this.Controls.Add(this.LblSalary);
            this.Controls.Add(this.LblState);
            this.Controls.Add(this.LblInterest);
            this.Controls.Add(this.LblCity);
            this.Controls.Add(this.LblAddress);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBoxGender.ResumeLayout(false);
            this.GroupBoxGender.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblAddress;
        private System.Windows.Forms.Label LblCity;
        private System.Windows.Forms.Label LblInterest;
        private System.Windows.Forms.Label LblState;
        private System.Windows.Forms.Label LblSalary;
        private System.Windows.Forms.Label LblGender;
        private System.Windows.Forms.Label LblDept;
        private System.Windows.Forms.Label LblDob;
        private System.Windows.Forms.Label LblPhone;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.CheckedListBox CheckListBoxInterest;
        private System.Windows.Forms.DateTimePicker DateTimePickerDob;
        private System.Windows.Forms.GroupBox GroupBoxGender;
        private System.Windows.Forms.RadioButton RadioBtnFemale;
        private System.Windows.Forms.RadioButton RadioBtnMale;
        private System.Windows.Forms.ListBox ListBoxDept;
        private System.Windows.Forms.ComboBox ComboBoxState;
        private System.Windows.Forms.ComboBox ComboBoxCity;
        private System.Windows.Forms.RichTextBox RichTxtBoxAddress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.TextBox TxtBoxSalary;
        private System.Windows.Forms.TextBox TxtBoxPhone;
        private System.Windows.Forms.DataGridView DataGridView1;
    }
}

