using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.CalcClass
{
    internal class Calculate
    {
        public Double result = 0;
        public string cur_operator = null;

        public void CalcResult(Calculate cal, double val, string expr)
        {
            if (cur_operator == null)
            {
                cal.result = val;
            }
            else
            {
                switch (cur_operator)
                {
                    case "+":
                        cal.result = Math.Round(cal.result + val, 2);
                        break;

                    case "-":
                        cal.result = Math.Round(cal.result - val, 2); ;
                        break;

                    case "*":
                        cal.result = Math.Round(cal.result * val, 2);
                        break;

                    case "/":
                        cal.result = Math.Round(cal.result / val, 2);
                        break;

                    default:
                        MessageBox.Show("Invalid Input");
                        break;
                }
            }
            cur_operator = expr;
            if(expr == "=")
            {
                cur_operator = null;
            }
        }
    }
}
