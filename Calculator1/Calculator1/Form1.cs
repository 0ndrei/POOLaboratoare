﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator1
{
    public partial class Form1 : Form
    {
        double memory;
        public Form1()
        {
            InitializeComponent();
        }

        private void button22_Click(object sender, EventArgs e)                     //Adaugarea butoanelor (0-9) in textbox, scoaterea zeroului din text 
        {
            Button n = (Button)sender;
            if (textBox1.Text == "0")
                textBox1.Text = n.Text;
            else
                textBox1.Text = textBox1.Text + n.Text;
        }

        private void button23_Click(object sender, EventArgs e)                   //Adaugam virgula si nu permitem ca sa se puie mai mult de o data 
        {
            if(!textBox1.Text.Contains(","))                                        
            textBox1.Text += (sender as Button).Text;
        }

        private void button5_Click(object sender, EventArgs e)                    //Adaugarea butonul de stergere a tuturor elementelor
        {
            textBox1.Clear();
        }

        private void button21_Click(object sender, EventArgs e)                 //Adaugarea butonului +-
        {
            if (textBox1.Text != "") {
                if (textBox1.Text[0] == '-')
                {
                    textBox1.Text = textBox1.Text.Remove(0, 1);
                }
                else textBox1.Text = '-' + textBox1.Text;
            }
        }

        private void button7_Click(object sender, EventArgs e)                //Adaugarea butonul de stergere a unui element 
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
        }

        private void button32_Click(object sender, EventArgs e)                 //Adaugarea butonului /
        {
            a = Convert.ToDouble(textBox1.Text);
            semn = (sender as Button).Text[0];
            textBox1.Clear();
        }

        private void button36_Click(object sender, EventArgs e)                 //Adaugarea butonului *
        {
            a = Convert.ToDouble(textBox1.Text);
            semn = (sender as Button).Text[0];
            textBox1.Clear();
        }

        private void button40_Click(object sender, EventArgs e)                 //Adaugarea butonului -
        {
            a = Convert.ToDouble(textBox1.Text);
            semn = (sender as Button).Text[0];
            textBox1.Clear();
        }

        private void button20_Click(object sender, EventArgs e)                 //Adaugarea butonului +
        {
            a = Convert.ToDouble(textBox1.Text);
            semn = (sender as Button).Text[0];
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)                        //Adaugarea butonului cosinus 
        {
            f = Convert.ToDouble(textBox1.Text);
            d = Math.Cos(f);
            textBox1.Text = Convert.ToString(d);
        }

        private void button4_Click(object sender, EventArgs e)                      //Adaugarea butonului sinus
        {
            f = Convert.ToDouble(textBox1.Text);
            d = Math.Sin(f);
            textBox1.Text = Convert.ToString(d);
        }

        private void button6_Click(object sender, EventArgs e)                      //Adaugarea butonului tangenta
        {
            f = Convert.ToDouble(textBox1.Text);
            d = Math.Tan(f);
            textBox1.Text = Convert.ToString(d);
        }

        private void button26_Click(object sender, EventArgs e)                       //Adaugarea butonului radical
        {
            f = Convert.ToDouble(textBox1.Text);
            d = Math.Sqrt(f);
            textBox1.Text = Convert.ToString(d);
        }

        private void button3_Click(object sender, EventArgs e)                      //Adaugarea butonului x^2
        {
            f = Convert.ToDouble(textBox1.Text);
            d = f * f;
            textBox1.Text = Convert.ToString(d);
        }

        private void button28_Click(object sender, EventArgs e)                     //Adaugarea butonului 1/x
        {
            f = Convert.ToDouble(textBox1.Text);
            d = 1/f;
            textBox1.Text = Convert.ToString(d);
        }
        double a = 0, b = 0, c = 0;
        char semn = '+';
        double f, d;

        private void button24_Click(object sender, EventArgs e)                     //Adaugarea butonului egal
        {
            b = Convert.ToDouble(textBox1.Text);
            switch (semn)
            {
                case '+':
                    c = a + b;
                    break;
                case '-':
                    c = a - b;
                    break;
                case '/':
                    c = a / b;
                    if (b == 0)
                    {
                        MessageBox.Show("Nu se poate imparti la 0!!!");
                        textBox1.Text = "Eroare";
                    }
                    break;
                case '*':
                    c = a * b;
                    break;
            }
            textBox1.Text = c.ToString();
        }
        private void button11_Click(object sender, EventArgs e)     //Memorarea datelor
        {
            Button m = (Button)sender;
            switch (m.Text)
            {
                case "MC":
                    memory = 0;
                    textBox2.Text = "";
                    textBox1.Text = "0";
                    break;
                case "MR":
                    textBox1.Text = Convert.ToString(memory);
                    break;
                case "MS":
                    memory = Convert.ToDouble(textBox1.Text);
                    textBox2.Text = textBox1.Text;
                    textBox1.Text = "0";
                    break;
                case "M+":
                    memory += Convert.ToDouble(textBox1.Text);
                    textBox2.Text = Convert.ToString(memory);
                    textBox1.Text = "0";
                    break;
                case "M-":
                    memory -= Convert.ToDouble(textBox1.Text);
                    textBox2.Text = Convert.ToString(memory);
                    textBox1.Text = "0";
                    break;
            }
        }
    }
}
