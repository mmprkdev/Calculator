using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double result = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Generic function for all number button clicks. 
        private void button_click(object sender, EventArgs e)
        {
            // Clear the text box after an operator button is pushed (+, -, *, /),
            // textBox1.Text == "0" is meant to clear the default zero value.
            if ((textBox1.Text == "0") || (isOperationPerformed))
            {
                result = Double.Parse(textBox1.Text);
                textBox1.Clear();
            }

            isOperationPerformed = false;
            Button button = (Button)sender;
            // Check for decimal button press.
            if (button.Text == ".")
            {
                // Ensures that multiple decimals are not allowed.
                if (!textBox1.Text.Contains("."))
                    textBox1.Text += button.Text;
            }
            else
                // Otherwise, append the button text.
                textBox1.Text += button.Text;

        }

        // Generic function for all operator button clicks.
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // Allows the operator buttons to perform the equal button's
            // function when operator buttons are pressed multiple times.
            //
            // E.g., 1+1+... 1 and 1 will be added together and two will
            // be displayed in the text box when the plus button
            // is pressed for the second time. 
            if (result != 0)
            {
                equ.PerformClick();
                operationPerformed = button.Text;
                isOperationPerformed = true;

            }
            else
            {
                operationPerformed = button.Text;
                result = Double.Parse(textBox1.Text);
                isOperationPerformed = true;
            }
        }

        // Function performed when the "C" (clear) button is pressed.
        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        // Function performed when the "CE" (clear entry) button is pressed.
        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            result = 0;
        }

        // Equal button function.
        //
        // NOTE: After changing the names of the buttons through the properties
        // window in design mode, the original names still remain in this script.
        // Manually changing the name of the function to "equ" causes a compiler
        // error.
        private void button12_Click(object sender, EventArgs e)
        {
            // Depending on what operator button was pressed, compute the equation
            // and assign it to the text box text variable.
            switch (operationPerformed)
            {
                case "+":
                    textBox1.Text = (result + Double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (result - Double.Parse(textBox1.Text)).ToString();
                    break;
                case "*":
                    textBox1.Text = (result * Double.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                    textBox1.Text = (result / Double.Parse(textBox1.Text)).ToString();
                    break;
                default:
                    break;
            }
            operationPerformed = "";
        }

        // Handles the possitive/negitive modifier button.
        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Double.Parse(textBox1.Text) * (-1)).ToString();
        }

        // Checks for any keypresses and performs the corrisponding function.
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0":
                    zero.PerformClick();
                    break;
                case "1":
                    one.PerformClick();
                    break;
                case "2":
                    two.PerformClick();
                    break;
                case "3":
                    three.PerformClick();
                    break;
                case "4":
                    four.PerformClick();
                    break;
                case "5":
                    five.PerformClick();
                    break;
                case "6":
                    six.PerformClick();
                    break;
                case "7":
                    seven.PerformClick();
                    break;
                case "8":
                    eight.PerformClick();
                    break;
                case "9":
                    nine.PerformClick();
                    break;
                case "+":
                    plus.PerformClick();
                    break;
                case "-":
                    minus.PerformClick();
                    break;
                case "*":
                    mult.PerformClick();
                    break;
                case "/":
                    div.PerformClick();
                    break;
                case ".":
                    dec.PerformClick();
                    break;
                default:
                    break;
            }
        }
    }   
}
