using System.Windows.Forms.VisualStyles;

namespace Calculator
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ExpRichTxtBox = new System.Windows.Forms.RichTextBox();
            this.InputRichTxtBox = new System.Windows.Forms.RichTextBox();
            this.ZeroBtn = new System.Windows.Forms.Button();
            this.DotBtn = new System.Windows.Forms.Button();
            this.EqualBtn = new System.Windows.Forms.Button();
            this.DoubleZeroBtn = new System.Windows.Forms.Button();
            this.TwoBtn = new System.Windows.Forms.Button();
            this.ThreeBtn = new System.Windows.Forms.Button();
            this.PlusBtn = new System.Windows.Forms.Button();
            this.OneBtn = new System.Windows.Forms.Button();
            this.FiveBtn = new System.Windows.Forms.Button();
            this.SixBtn = new System.Windows.Forms.Button();
            this.MinusBtn = new System.Windows.Forms.Button();
            this.FourBtn = new System.Windows.Forms.Button();
            this.EightBtn = new System.Windows.Forms.Button();
            this.NineBtn = new System.Windows.Forms.Button();
            this.MulBtn = new System.Windows.Forms.Button();
            this.SevenBtn = new System.Windows.Forms.Button();
            this.SquareBtn = new System.Windows.Forms.Button();
            this.RootBtn = new System.Windows.Forms.Button();
            this.DivBtn = new System.Windows.Forms.Button();
            this.CancelTextBtn = new System.Windows.Forms.Button();
            this.CancelAllBtn = new System.Windows.Forms.Button();
            this.CancelOneBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ZeroBtn);
            this.panel1.Controls.Add(this.DotBtn);
            this.panel1.Controls.Add(this.EqualBtn);
            this.panel1.Controls.Add(this.DoubleZeroBtn);
            this.panel1.Controls.Add(this.TwoBtn);
            this.panel1.Controls.Add(this.ThreeBtn);
            this.panel1.Controls.Add(this.PlusBtn);
            this.panel1.Controls.Add(this.OneBtn);
            this.panel1.Controls.Add(this.FiveBtn);
            this.panel1.Controls.Add(this.SixBtn);
            this.panel1.Controls.Add(this.MinusBtn);
            this.panel1.Controls.Add(this.FourBtn);
            this.panel1.Controls.Add(this.EightBtn);
            this.panel1.Controls.Add(this.NineBtn);
            this.panel1.Controls.Add(this.MulBtn);
            this.panel1.Controls.Add(this.SevenBtn);
            this.panel1.Controls.Add(this.SquareBtn);
            this.panel1.Controls.Add(this.RootBtn);
            this.panel1.Controls.Add(this.DivBtn);
            this.panel1.Controls.Add(this.CancelTextBtn);
            this.panel1.Controls.Add(this.CancelAllBtn);
            this.panel1.Controls.Add(this.CancelOneBtn);
            this.panel1.Location = new System.Drawing.Point(339, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 526);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ExpRichTxtBox);
            this.panel2.Controls.Add(this.InputRichTxtBox);
            this.panel2.Location = new System.Drawing.Point(11, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 134);
            this.panel2.TabIndex = 25;
            // 
            // ExpRichTxtBox
            // 
            this.ExpRichTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExpRichTxtBox.Font = new System.Drawing.Font("Verdana", 26.25F);
            this.ExpRichTxtBox.Location = new System.Drawing.Point(9, 11);
            this.ExpRichTxtBox.Name = "ExpRichTxtBox";
            this.ExpRichTxtBox.ReadOnly = true;
            this.ExpRichTxtBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ExpRichTxtBox.Size = new System.Drawing.Size(303, 53);
            this.ExpRichTxtBox.TabIndex = 1;
            this.ExpRichTxtBox.Text = "";
            // 
            // InputRichTxtBox
            // 
            this.InputRichTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputRichTxtBox.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputRichTxtBox.Location = new System.Drawing.Point(9, 71);
            this.InputRichTxtBox.Name = "InputRichTxtBox";
            this.InputRichTxtBox.ReadOnly = true;
            this.InputRichTxtBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InputRichTxtBox.Size = new System.Drawing.Size(303, 53);
            this.InputRichTxtBox.TabIndex = 0;
            this.InputRichTxtBox.Text = "";
            this.InputRichTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputRichTxtBox_KeyDown);
            // 
            // ZeroBtn
            // 
            this.ZeroBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroBtn.Location = new System.Drawing.Point(95, 462);
            this.ZeroBtn.Name = "ZeroBtn";
            this.ZeroBtn.Size = new System.Drawing.Size(71, 46);
            this.ZeroBtn.TabIndex = 24;
            this.ZeroBtn.Text = "0";
            this.ZeroBtn.UseVisualStyleBackColor = true;
            this.ZeroBtn.Click += new System.EventHandler(this.ZeroBtn_Click);
            // 
            // DotBtn
            // 
            this.DotBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DotBtn.Location = new System.Drawing.Point(180, 462);
            this.DotBtn.Name = "DotBtn";
            this.DotBtn.Size = new System.Drawing.Size(71, 46);
            this.DotBtn.TabIndex = 23;
            this.DotBtn.Text = ".";
            this.DotBtn.UseVisualStyleBackColor = true;
            this.DotBtn.Click += new System.EventHandler(this.DotBtn_Click);
            // 
            // EqualBtn
            // 
            this.EqualBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EqualBtn.Location = new System.Drawing.Point(265, 462);
            this.EqualBtn.Name = "EqualBtn";
            this.EqualBtn.Size = new System.Drawing.Size(71, 46);
            this.EqualBtn.TabIndex = 22;
            this.EqualBtn.Text = "=";
            this.EqualBtn.UseVisualStyleBackColor = true;
            this.EqualBtn.Click += new System.EventHandler(this.EqualBtn_Click);
            // 
            // DoubleZeroBtn
            // 
            this.DoubleZeroBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoubleZeroBtn.Location = new System.Drawing.Point(11, 462);
            this.DoubleZeroBtn.Name = "DoubleZeroBtn";
            this.DoubleZeroBtn.Size = new System.Drawing.Size(71, 46);
            this.DoubleZeroBtn.TabIndex = 21;
            this.DoubleZeroBtn.Text = "00";
            this.DoubleZeroBtn.UseVisualStyleBackColor = true;
            this.DoubleZeroBtn.Click += new System.EventHandler(this.DoubleZeroBtn_Click);
            // 
            // TwoBtn
            // 
            this.TwoBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TwoBtn.Location = new System.Drawing.Point(95, 404);
            this.TwoBtn.Name = "TwoBtn";
            this.TwoBtn.Size = new System.Drawing.Size(71, 46);
            this.TwoBtn.TabIndex = 20;
            this.TwoBtn.Text = "2";
            this.TwoBtn.UseVisualStyleBackColor = true;
            this.TwoBtn.Click += new System.EventHandler(this.TwoBtn_Click);
            // 
            // ThreeBtn
            // 
            this.ThreeBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreeBtn.Location = new System.Drawing.Point(180, 404);
            this.ThreeBtn.Name = "ThreeBtn";
            this.ThreeBtn.Size = new System.Drawing.Size(71, 46);
            this.ThreeBtn.TabIndex = 19;
            this.ThreeBtn.Text = "3";
            this.ThreeBtn.UseVisualStyleBackColor = true;
            this.ThreeBtn.Click += new System.EventHandler(this.ThreeBtn_Click);
            // 
            // PlusBtn
            // 
            this.PlusBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlusBtn.Location = new System.Drawing.Point(265, 404);
            this.PlusBtn.Name = "PlusBtn";
            this.PlusBtn.Size = new System.Drawing.Size(71, 46);
            this.PlusBtn.TabIndex = 18;
            this.PlusBtn.Text = "+";
            this.PlusBtn.UseVisualStyleBackColor = true;
            this.PlusBtn.Click += new System.EventHandler(this.PlusBtn_Click);
            // 
            // OneBtn
            // 
            this.OneBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OneBtn.Location = new System.Drawing.Point(11, 404);
            this.OneBtn.Name = "OneBtn";
            this.OneBtn.Size = new System.Drawing.Size(71, 46);
            this.OneBtn.TabIndex = 17;
            this.OneBtn.Text = "1";
            this.OneBtn.UseVisualStyleBackColor = true;
            this.OneBtn.Click += new System.EventHandler(this.OneBtn_Click);
            // 
            // FiveBtn
            // 
            this.FiveBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiveBtn.Location = new System.Drawing.Point(95, 344);
            this.FiveBtn.Name = "FiveBtn";
            this.FiveBtn.Size = new System.Drawing.Size(71, 46);
            this.FiveBtn.TabIndex = 16;
            this.FiveBtn.Text = "5";
            this.FiveBtn.UseVisualStyleBackColor = true;
            this.FiveBtn.Click += new System.EventHandler(this.FiveBtn_Click);
            // 
            // SixBtn
            // 
            this.SixBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SixBtn.Location = new System.Drawing.Point(180, 344);
            this.SixBtn.Name = "SixBtn";
            this.SixBtn.Size = new System.Drawing.Size(71, 46);
            this.SixBtn.TabIndex = 15;
            this.SixBtn.Text = "6";
            this.SixBtn.UseVisualStyleBackColor = true;
            this.SixBtn.Click += new System.EventHandler(this.SixBtn_Click);
            // 
            // MinusBtn
            // 
            this.MinusBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinusBtn.Location = new System.Drawing.Point(265, 344);
            this.MinusBtn.Name = "MinusBtn";
            this.MinusBtn.Size = new System.Drawing.Size(71, 46);
            this.MinusBtn.TabIndex = 14;
            this.MinusBtn.Text = "-";
            this.MinusBtn.UseVisualStyleBackColor = true;
            this.MinusBtn.Click += new System.EventHandler(this.MinusBtn_Click);
            // 
            // FourBtn
            // 
            this.FourBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourBtn.Location = new System.Drawing.Point(11, 344);
            this.FourBtn.Name = "FourBtn";
            this.FourBtn.Size = new System.Drawing.Size(71, 46);
            this.FourBtn.TabIndex = 13;
            this.FourBtn.Text = "4";
            this.FourBtn.UseVisualStyleBackColor = true;
            this.FourBtn.Click += new System.EventHandler(this.FourBtn_Click);
            // 
            // EightBtn
            // 
            this.EightBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EightBtn.Location = new System.Drawing.Point(95, 287);
            this.EightBtn.Name = "EightBtn";
            this.EightBtn.Size = new System.Drawing.Size(71, 46);
            this.EightBtn.TabIndex = 12;
            this.EightBtn.Text = "8";
            this.EightBtn.UseVisualStyleBackColor = true;
            this.EightBtn.Click += new System.EventHandler(this.EightBtn_Click);
            // 
            // NineBtn
            // 
            this.NineBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NineBtn.Location = new System.Drawing.Point(180, 287);
            this.NineBtn.Name = "NineBtn";
            this.NineBtn.Size = new System.Drawing.Size(71, 46);
            this.NineBtn.TabIndex = 11;
            this.NineBtn.Text = "9";
            this.NineBtn.UseVisualStyleBackColor = true;
            this.NineBtn.Click += new System.EventHandler(this.NineBtn_Click);
            // 
            // MulBtn
            // 
            this.MulBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MulBtn.Location = new System.Drawing.Point(265, 287);
            this.MulBtn.Name = "MulBtn";
            this.MulBtn.Size = new System.Drawing.Size(71, 46);
            this.MulBtn.TabIndex = 10;
            this.MulBtn.Text = "*";
            this.MulBtn.UseVisualStyleBackColor = true;
            this.MulBtn.Click += new System.EventHandler(this.MulBtn_Click);
            // 
            // SevenBtn
            // 
            this.SevenBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SevenBtn.Location = new System.Drawing.Point(11, 287);
            this.SevenBtn.Name = "SevenBtn";
            this.SevenBtn.Size = new System.Drawing.Size(71, 46);
            this.SevenBtn.TabIndex = 9;
            this.SevenBtn.Text = "7";
            this.SevenBtn.UseVisualStyleBackColor = true;
            this.SevenBtn.Click += new System.EventHandler(this.SevenBtn_Click);
            // 
            // SquareBtn
            // 
            this.SquareBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SquareBtn.Location = new System.Drawing.Point(95, 231);
            this.SquareBtn.Name = "SquareBtn";
            this.SquareBtn.Size = new System.Drawing.Size(71, 46);
            this.SquareBtn.TabIndex = 8;
            this.SquareBtn.Text = "x^2";
            this.SquareBtn.UseVisualStyleBackColor = true;
            this.SquareBtn.Click += new System.EventHandler(this.SquareBtn_Click);
            // 
            // RootBtn
            // 
            this.RootBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RootBtn.Location = new System.Drawing.Point(180, 231);
            this.RootBtn.Name = "RootBtn";
            this.RootBtn.Size = new System.Drawing.Size(71, 46);
            this.RootBtn.TabIndex = 7;
            this.RootBtn.Text = "2√x";
            this.RootBtn.UseVisualStyleBackColor = true;
            this.RootBtn.Click += new System.EventHandler(this.RootBtn_Click);
            // 
            // DivBtn
            // 
            this.DivBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DivBtn.Location = new System.Drawing.Point(265, 231);
            this.DivBtn.Name = "DivBtn";
            this.DivBtn.Size = new System.Drawing.Size(71, 46);
            this.DivBtn.TabIndex = 6;
            this.DivBtn.Text = "/";
            this.DivBtn.UseVisualStyleBackColor = true;
            this.DivBtn.Click += new System.EventHandler(this.DivBtn_Click);
            // 
            // CancelTextBtn
            // 
            this.CancelTextBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelTextBtn.Location = new System.Drawing.Point(11, 231);
            this.CancelTextBtn.Name = "CancelTextBtn";
            this.CancelTextBtn.Size = new System.Drawing.Size(71, 46);
            this.CancelTextBtn.TabIndex = 4;
            this.CancelTextBtn.Text = "CE";
            this.CancelTextBtn.UseVisualStyleBackColor = true;
            this.CancelTextBtn.Click += new System.EventHandler(this.CancelTextBtn_Click);
            // 
            // CancelAllBtn
            // 
            this.CancelAllBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelAllBtn.Location = new System.Drawing.Point(178, 173);
            this.CancelAllBtn.Name = "CancelAllBtn";
            this.CancelAllBtn.Size = new System.Drawing.Size(71, 46);
            this.CancelAllBtn.TabIndex = 3;
            this.CancelAllBtn.Text = "C";
            this.CancelAllBtn.UseVisualStyleBackColor = true;
            this.CancelAllBtn.Click += new System.EventHandler(this.CancelAllBtn_Click);
            // 
            // CancelOneBtn
            // 
            this.CancelOneBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelOneBtn.Location = new System.Drawing.Point(263, 173);
            this.CancelOneBtn.Name = "CancelOneBtn";
            this.CancelOneBtn.Size = new System.Drawing.Size(71, 46);
            this.CancelOneBtn.TabIndex = 2;
            this.CancelOneBtn.Text = "X";
            this.CancelOneBtn.UseVisualStyleBackColor = true;
            this.CancelOneBtn.Click += new System.EventHandler(this.CancelOneBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 769);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CancelTextBtn;
        private System.Windows.Forms.Button CancelAllBtn;
        private System.Windows.Forms.Button CancelOneBtn;
        private System.Windows.Forms.Button EightBtn;
        private System.Windows.Forms.Button NineBtn;
        private System.Windows.Forms.Button MulBtn;
        private System.Windows.Forms.Button SevenBtn;
        private System.Windows.Forms.Button SquareBtn;
        private System.Windows.Forms.Button RootBtn;
        private System.Windows.Forms.Button DivBtn;
        private System.Windows.Forms.Button ZeroBtn;
        private System.Windows.Forms.Button DotBtn;
        private System.Windows.Forms.Button EqualBtn;
        private System.Windows.Forms.Button DoubleZeroBtn;
        private System.Windows.Forms.Button TwoBtn;
        private System.Windows.Forms.Button ThreeBtn;
        private System.Windows.Forms.Button PlusBtn;
        private System.Windows.Forms.Button OneBtn;
        private System.Windows.Forms.Button FiveBtn;
        private System.Windows.Forms.Button SixBtn;
        private System.Windows.Forms.Button MinusBtn;
        private System.Windows.Forms.Button FourBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox ExpRichTxtBox;
        private System.Windows.Forms.RichTextBox InputRichTxtBox;
    }
}

