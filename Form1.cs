using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {   
        //makes the form dragable when user clicks on the form.
        #region form drag
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender,
        System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    #endregion

        public Form1()
        {
            InitializeComponent();
            lblResult.Text = "0";
            lblHistory.Text = "";
            this.Width = 334;
        }

        double firstNumber;
        double secondNumber;
        double reset;
        Boolean firstNumFlag = false;
        string Operator;
        double answer;
        
        //Outputs the result to the result label.
        private void calculate()
        {
            secondNumber = Convert.ToDouble(lblResult.Text);
            switch (Operator)
            {
                case "+":
                    answer = basicMath.Arithmetic.Add(firstNumber, secondNumber);
                    break;
                case "-":
                    answer = basicMath.Arithmetic.Sub(firstNumber,secondNumber);
                    break;
                case "×":
                    answer = basicMath.Arithmetic.mult(firstNumber, secondNumber);
                    break;
                case "÷":
                    answer = basicMath.Arithmetic.Div(firstNumber, secondNumber);
                    break;
                    //has to be second Number when caluclating 
                case "Sin":
                    answer = trigonometric.trig.Sine(secondNumber);
                    break;
                case "Cos":
                    answer = trigonometric.trig.Cosine(secondNumber);
                    break;
                case "Tan":
                    answer = trigonometric.trig.Tan(secondNumber);
                    break;
                case "sqRoot":
                    answer = Alebraic.ale.squareRoot(secondNumber);
                    break;
                case "CubeRoot":
                    answer = Alebraic.ale.squareRoot(secondNumber);
                    break;
            }
            lblResult.Text = answer.ToString();
        }

        private void setOperator(string gsOperator)
        {
         
            //if not the first number then calculate 
            if (firstNumFlag == true)
            {
                secondNumber = Convert.ToDouble(lblResult.Text);
                lblHistory.Text += " " + Convert.ToString(secondNumber);
                calculate();
                firstNumFlag = false;
            }
            else
            {
                Operator = gsOperator;
                firstNumber = Convert.ToDouble(lblResult.Text);
                lblResult.Text = "";
                lblHistory.Text = Convert.ToString(firstNumber) + " " + Operator;
                firstNumFlag = true;
            }

        }

        


        //Region also contains decimal point, Delete and Clear
        #region Operators 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var temp = lblResult.Text;
            if (temp.Length > 0)
            {
                lblResult.Text = temp.TrimEnd().Substring(0, temp.Length - 1);
            } else
            {
                lblResult.Text = "0";
            }
            
        }

        private void btnAddition_Click(object sender, EventArgs e)
        {
            setOperator("+");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            setOperator("-");
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            setOperator("×");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            setOperator("÷");
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblResult.Text += ".";
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            Operator = "Sin";
            calculate();
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            Operator = "Cos";
            calculate();
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            Operator = "Tan";
            calculate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            firstNumber = reset;
            secondNumber = reset;
            lblResult.Text = "0";
        }

        private void btnSqRoot_Click(object sender, EventArgs e)
        {
            Operator = "sqRoot";
            calculate();
        }

        //Cube Root
        private void button1_Click(object sender, EventArgs e)
        {
            Operator = "cubeRoot";
            calculate();
        }

        private void btnEquals_Click_1(object sender, EventArgs e)
        {

            calculate();
            lblHistory.Text = "";
            firstNumber = reset;
            secondNumber = reset;
            firstNumFlag = false;
        }

        #endregion

        private void addNumber(string i)
        {
            if (lblResult.Text == "0")
            {

                lblResult.Text = i;
            }
            else
            {
                lblResult.Text += i;
            }
        }
        #region numbers 


        private void btnZero_Click(object sender, EventArgs e)
        {
            lblResult.Text += "0";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            addNumber("1");

        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            addNumber("2");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            addNumber("3");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            addNumber("4");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            addNumber("5");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            addNumber("6");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            addNumber("7");
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            addNumber("8");
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            addNumber("9");
        }

        #endregion

        //adjusts the width of the form to display extra buttons.
        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (mnuScientific.Checked == false)
            {
                mnuScientific.Checked = true;
                this.Width = 415;
            } else
            {
                this.Width = 334;
                mnuScientific.Checked = false;
            }
            
        }

        //Closes Application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }






    }
}
