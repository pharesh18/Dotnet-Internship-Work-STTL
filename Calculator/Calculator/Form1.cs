using Calculator.CalcClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Calculate cal1 = new Calculate();
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     adds input value one by one 
        /// </summary>
        /// <param name="val"></param>
        private void addExpr(string val)
        {
            if (InputRichTxtBox.Text.Length < 10)
            {
                InputRichTxtBox.Text += val;
            }
        }
        /// <summary>
        /// To add 1 to the previous input value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OneBtn_Click(object sender, EventArgs e)
        {
            addExpr("1");
        }

        private void TwoBtn_Click(object sender, EventArgs e)
        {
            addExpr("2");
        }

        private void ThreeBtn_Click(object sender, EventArgs e)
        {
            addExpr("3");
        }

        private void FourBtn_Click(object sender, EventArgs e)
        {
            addExpr("4");
        }

        private void FiveBtn_Click(object sender, EventArgs e)
        {
            addExpr("5");
        }

        private void SixBtn_Click(object sender, EventArgs e)
        {
            addExpr("6");
        }

        private void SevenBtn_Click(object sender, EventArgs e)
        {
            addExpr("7");
        }

        private void EightBtn_Click(object sender, EventArgs e)
        {
            addExpr("8");
        }

        private void NineBtn_Click(object sender, EventArgs e)
        {
            addExpr("9");
        }

        private void ZeroBtn_Click(object sender, EventArgs e)
        {
            addExpr("0");
        }

        private void DoubleZeroBtn_Click(object sender, EventArgs e)
        {
            addExpr("00");
        }

        private void DotBtn_Click(object sender, EventArgs e)
        {
            performDecimal();
        }

        /// <summary>
        /// Function to perform addition of the previous expression and new input value 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusBtn_Click(object sender, EventArgs e)
        {
            performAddition();
        }

        /// <summary>
        /// Function to perform subtraction of the previous expression and new input value 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinusBtn_Click(object sender, EventArgs e)
        {
            performSub();
        }

        /// <summary>
        /// Function to perform multiplication of the previous expression and new input value 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MulBtn_Click(object sender, EventArgs e)
        {
            performMul();
        }

        /// <summary>
        /// Function to perform division of the previous expression and new input value 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DivBtn_Click(object sender, EventArgs e)
        {
            performDiv();
        }

        /// <summary>
        /// Function to perform square of the input value 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SquareBtn_Click(object sender, EventArgs e)
        {
            performSquare();
        }

        /// <summary>
        /// Function to perform square root of the input value 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RootBtn_Click(object sender, EventArgs e)
        {
            performRoot();
        }

        /// <summary>
        /// Function to perform 1 divide by the input value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /// <summary>
        /// Function to show output of the expression to display box. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EqualBtn_Click(object sender, EventArgs e)
        {
            performEqualTo();
        }

        /// <summary>
        /// To cancel all the input and previous expression from the calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelAllBtn_Click(object sender, EventArgs e)
        {
            performClearAll();
        }

        /// <summary>
        /// To cancel input text from the input box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelTextBtn_Click(object sender, EventArgs e)
        {
            performClearText();
        }

        /// <summary>
        /// Function to cancel last input value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelOneBtn_Click(object sender, EventArgs e)
        {
            performCancelOne();
        }

        private void performDecimal()
        {
            if (!(Convert.ToString(InputRichTxtBox.Text).Contains(".")))
            {
                addExpr(".");
            }
        }
        private void performAddition()
        {
            try
            {

                if (InputRichTxtBox.Text == "" && cal1.cur_operator != null)
                {
                    cal1.cur_operator = "+";
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + '+';
                }
                else if (InputRichTxtBox.Text == "" && cal1.cur_operator == null)
                {
                    cal1.CalcResult(cal1, Convert.ToDouble("0"), "+");
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + '+';
                    InputRichTxtBox.Text = "";
                }
                else
                {
                    cal1.CalcResult(cal1, Convert.ToDouble(InputRichTxtBox.Text), "+");
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + '+';
                    InputRichTxtBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.Message);
            }
        }

        private void performSub()
        {
            try
            {
                if (InputRichTxtBox.Text == "" && cal1.cur_operator != null)
                {
                    cal1.cur_operator = "-";
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + '-';
                }
                else if (InputRichTxtBox.Text == "" && cal1.cur_operator == null)
                {
                    cal1.CalcResult(cal1, Convert.ToDouble("0"), "-");
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + '-';
                    InputRichTxtBox.Text = "";
                }
                else
                {
                    cal1.CalcResult(cal1, Convert.ToDouble(InputRichTxtBox.Text), "-");
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + '-';
                    InputRichTxtBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.Message);
            }
        }

        private void performMul()
        {
            try
            {

                if (InputRichTxtBox.Text == "" && cal1.cur_operator != null)
                {
                    cal1.cur_operator = "*";
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + '*';
                }
                else if (InputRichTxtBox.Text == "" && cal1.cur_operator == null)
                {
                    cal1.CalcResult(cal1, Convert.ToDouble("0"), "*");
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + '*';
                    InputRichTxtBox.Text = "";
                }
                else
                {

                    cal1.CalcResult(cal1, Convert.ToDouble(InputRichTxtBox.Text), "*");
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + '*';
                    InputRichTxtBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.Message);
            }
        }

        private void performDiv()
        {
            try
            {

                if (InputRichTxtBox.Text == "" && cal1.cur_operator != null)
                {
                    cal1.cur_operator = "/";
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + '/';
                }
                else if (InputRichTxtBox.Text == "" && cal1.cur_operator == null)
                {
                    cal1.CalcResult(cal1, Convert.ToDouble("0"), "/");
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + '/';
                    InputRichTxtBox.Text = "";
                }
                else
                {
                    cal1.CalcResult(cal1, Convert.ToDouble(InputRichTxtBox.Text), "/");
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + '/';
                    InputRichTxtBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.Message);
            }
        }

        private void performSquare()
        {
            try
            {

                if (Convert.ToString(cal1.result) == "0")
                {
                    ExpRichTxtBox.Text = "square(" + Convert.ToString(InputRichTxtBox.Text) + ")";
                    InputRichTxtBox.Text = Convert.ToString(Math.Round(Math.Pow(Convert.ToDouble(InputRichTxtBox.Text), 2), 2));
                }
                else
                {
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + Convert.ToString(cal1.cur_operator) + "square(" + Convert.ToString(InputRichTxtBox.Text) + ")";
                    InputRichTxtBox.Text = Convert.ToString(Math.Round(Math.Pow(Convert.ToDouble(InputRichTxtBox.Text), 2), 2));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.Message);
            }
        }

        private void performRoot()
        {
            try
            {

                if (Convert.ToString(cal1.result) == "0")
                {
                    ExpRichTxtBox.Text = "sqrt(" + Convert.ToString(InputRichTxtBox.Text) + ")";
                    InputRichTxtBox.Text = Convert.ToString(Math.Round(Math.Sqrt(Math.Abs(Convert.ToDouble(InputRichTxtBox.Text))), 2));
                }
                else
                {
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result) + Convert.ToString(cal1.cur_operator) + "sqrt(" + Convert.ToString(InputRichTxtBox.Text) + ")";
                    InputRichTxtBox.Text = Convert.ToString(Math.Round(Math.Sqrt(Math.Abs(Convert.ToDouble(InputRichTxtBox.Text))), 2));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.Message);
            }
        }

        private void performEqualTo()
        {
            try
            {

                if (InputRichTxtBox.Text != "")
                {
                    cal1.CalcResult(cal1, Convert.ToDouble(InputRichTxtBox.Text), "=");  // it takes three argument, one - class object, two - input value, third - operator
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result);
                    InputRichTxtBox.Text = "";
                }
                else
                {
                    cal1.CalcResult(cal1, Convert.ToDouble("0"), "=");
                    ExpRichTxtBox.Text = Convert.ToString(cal1.result);
                    InputRichTxtBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.Message);
            }
        }

        private void performClearText()
        {
            InputRichTxtBox.Text = "";
        }

        private void performClearAll()
        {
            cal1.result = 0;
            cal1.cur_operator = null;
            ExpRichTxtBox.Text = "";
            InputRichTxtBox.Text = "";
        }

        private void performCancelOne()
        {
            if (Convert.ToString(InputRichTxtBox.Text).Length > 0)
            {
                InputRichTxtBox.Text = Convert.ToString(InputRichTxtBox.Text).Remove(Convert.ToString(InputRichTxtBox.Text).Length - 1, 1);
            }
        }

        private void InputRichTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    addExpr("0");
                    break;

                case Keys.D1:
                case Keys.NumPad1:
                    addExpr("1");
                    break;

                case Keys.D2:
                case Keys.NumPad2:
                    addExpr("2");
                    break;

                case Keys.D3:
                case Keys.NumPad3:
                    addExpr("3");
                    break;

                case Keys.D4:
                case Keys.NumPad4:
                    addExpr("4");
                    break;

                case Keys.D5:
                case Keys.NumPad5:
                    addExpr("5");
                    break;

                case Keys.D6:
                case Keys.NumPad6:
                    addExpr("6");
                    break;

                case Keys.D7:
                case Keys.NumPad7:
                    addExpr("7");
                    break;

                case Keys.D8:
                case Keys.NumPad8:
                    addExpr("8");
                    break;

                case Keys.D9:
                case Keys.NumPad9:
                    addExpr("9");
                    break;

                case Keys.Decimal:
                    performDecimal();
                    break;

                case Keys.Add:
                    performAddition();
                    break;

                case Keys.Subtract:
                    performSub();
                    break;

                case Keys.Multiply:
                    performMul();
                    break;

                case Keys.Divide:
                    performDiv();
                    break;

                case Keys.OemOpenBrackets:
                    performSquare();
                    break;

                case Keys.Enter:
                    performEqualTo();
                    break;

                case Keys.Back:
                    performCancelOne();
                    break;

                case Keys.C:
                    performClearText();
                    break;

                case Keys.K:
                    performClearAll();
                    break;

                default:
                    MessageBox.Show("Invalid Key");
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.KeyDown += new KeyEventHandler(this.InputRichTxtBox_KeyDown);
            this.ActiveControl = InputRichTxtBox;
        }
    }
}
