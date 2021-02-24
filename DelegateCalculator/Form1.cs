using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateCalculator
{
    public partial class Form1 : Form
    {
        private double lastResult = 0;
        private bool isCounted = false;

        private Calculator calc = Add;
        delegate double Calculator(double x, double y);
        private static double Add(double x, double y) => x + y;
        private static double Substract(double x, double y) => x - y;
        private static double Multiply(double x, double y) => x * y;
        private static double Divide(double x, double y) => x / y;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_multiply_Click(object sender, EventArgs e)
        {
            CountReset(lastResult.ToString());
            if (textBox1.Text.Length > 0) if(textBox1.Text[textBox1.Text.Length - 1] != ' ') textBox1.Text += " * ";
        }

        private void button_divide_Click(object sender, EventArgs e)
        {
            CountReset(lastResult.ToString());
            if (textBox1.Text.Length > 0) if (textBox1.Text[textBox1.Text.Length - 1] != ' ') textBox1.Text += " / ";
        }

        private void button_summ_Click(object sender, EventArgs e)
        {
            CountReset(lastResult.ToString());
            if (textBox1.Text.Length > 0) if (textBox1.Text[textBox1.Text.Length - 1] != ' ') textBox1.Text += " + ";
        }

        private void button_subs_Click(object sender, EventArgs e)
        {
            CountReset(lastResult.ToString());
            if (textBox1.Text.Length > 0) if (textBox1.Text[textBox1.Text.Length - 1] != ' ') textBox1.Text += " - ";
        }

        private void button_one_Click(object sender, EventArgs e)
        {
            CountReset();
            textBox1.Text += '1';
        }

        private void button_two_Click(object sender, EventArgs e)
        {
            CountReset();
            textBox1.Text += '2';
        }

        private void button_three_Click(object sender, EventArgs e)
        {
            CountReset();
            textBox1.Text += '3';
        }

        private void button_four_Click(object sender, EventArgs e)
        {
            CountReset();
            textBox1.Text += '4';
        }

        private void button_five_Click(object sender, EventArgs e)
        {
            CountReset();
            textBox1.Text += '5';
        }

        private void button_six_Click(object sender, EventArgs e)
        {
            CountReset();
            textBox1.Text += '6';
        }

        private void button_seven_Click(object sender, EventArgs e)
        {
            CountReset();
            textBox1.Text += '7';
        }

        private void button_eight_Click(object sender, EventArgs e)
        {
            CountReset();
            textBox1.Text += '8';
        }

        private void button_nine_Click(object sender, EventArgs e)
        {
            CountReset();
            textBox1.Text += '9';
        }

        private void button_zero_Click(object sender, EventArgs e)
        {
            CountReset();
            textBox1.Text += '0';
        }

        private void button_result_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] != ' ')
            {
                double temp = CountResult(textBox1.Text);
                textBox1.Text += $" = {temp}";
            }
        }

        private double CountResult(string text)
        {
            string[] arrayString = text.Split(' ');
            lastResult = double.Parse(arrayString[0]);
            for(int i = 0; i < arrayString.Length; i++)
            {
                switch(arrayString[i])
                {
                    case "+":
                        calc = Add;
                        lastResult = calc(lastResult, double.Parse(arrayString[i + 1]));
                        break;
                    case "-":
                        calc = Substract;
                        lastResult = calc(lastResult, double.Parse(arrayString[i + 1]));
                        break;
                    case "*":
                        calc = Multiply;
                        lastResult = calc(lastResult, double.Parse(arrayString[i + 1]));
                        break;
                    case "/":
                        calc = Divide;
                        lastResult = calc(lastResult, double.Parse(arrayString[i + 1]));
                        break;
                }
            }
            isCounted = true;
            return lastResult;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                CountReset();
                if (textBox1.Text[textBox1.Text.Length - 1] == ' ')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                }
                else textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void CountReset(string text = "")
        {
            if (isCounted == true) 
            { 
                textBox1.Text = text;
                isCounted = false; 
            }
        }
    }
}
