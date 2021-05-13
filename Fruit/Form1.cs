using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fruit
{
    public partial class Form1 : Form
    {
        double CL=0, GL=0, GP=0, GM=0,Res;


        public Form1()
        {
            InitializeComponent();
            textBox1.BorderStyle = BorderStyle.None;
            textBox2.BorderStyle = BorderStyle.None;
            textBox3.BorderStyle = BorderStyle.None;
            textBox4.BorderStyle = BorderStyle.None;
            textBox5.BorderStyle = BorderStyle.None;
        }

        public double Calc(double CL, double GL, double GP, double GM)
        {
            return GM - CL * GL - GP;
        }

        public void Result()
        {
            Res = Calc(CL, GL, GP, GM);
            if (Res - (int)Res == 0)
            {
                label6.Text = Convert.ToString(Res);
            }
            else
            {
                label6.Text = Convert.ToString(Res.ToString("0.00"));
            }
        }

        private void SelectAll_OnTextBoxEnter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.BeginInvoke(new Action(textBox.SelectAll));
        }

        public void TextReplace(TextBox txt)
        {
            txt.Select(txt.Text.Length, 0);
            txt.Text = Regex.Replace(txt.Text, @"[^0-9.]", "");
        }

        public void TextToDoubleAndResult(TextBox txt, ref double val)
        {
            try
            {
                val = Convert.ToDouble(txt.Text);
                Result();
                label6.ForeColor = Color.White;
                textBox5.ForeColor = Color.White;
                textBox5.Text = "=" + textBox4.Text + "-" + textBox1.Text + "*" + textBox2.Text + "-" + textBox3.Text;
            }
            catch
            {
                label6.ForeColor = Color.Red;
                textBox5.ForeColor = Color.Red;
                label6.Text = "Error";
                textBox5.Text = ":(";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextReplace(textBox1);
            TextToDoubleAndResult(textBox1, ref CL);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextReplace(textBox2);
            TextToDoubleAndResult(textBox2, ref GL);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextReplace(textBox3);
            TextToDoubleAndResult(textBox3, ref GP);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TextReplace(textBox4);
            TextToDoubleAndResult(textBox4, ref GM);
        }
    }
}
