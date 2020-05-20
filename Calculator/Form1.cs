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
        public Form1()
        {
            InitializeComponent();
        }
        public double ResultNum;
        public bool isOperated;
        public string action;
        private void NumClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string num = Result.Text;
            if (num == "0")
            {
                Result.Text = "";
            }
            if (isOperated == true)
            {
                Result.Text = "";
                isOperated = false;
            }
            Result.Text += b.Text;
        }
        private void OperationsClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (!string.IsNullOrEmpty(action))
            {
                TakeResult(sender, e);
            }
            else
            {
                ResultNum = double.Parse(Result.Text);
            }
            action = b.Text;
            isOperated = true;
        }
        private void DeleteCurrentNum(object sender, EventArgs e)
        {
            Result.Text = "0";
        }
        private void DeleteAll(object sender, EventArgs e)
        {
            Result.Text = "0";
            ResultNum = 0;
        }
        private void DeleteLastNum(object sender, EventArgs e)
        {
            if (Result.TextLength == 1)
            {
                Result.Text = "00";
            }
            Result.Text = Result.Text.Remove(Result.TextLength - 1, 1);
        }
        private void AddDot(object sender, EventArgs e)
        {
            if (isOperated==false)
            {
            Result.Text += ".";
            }
        }
        private void TakeResult(object sender, EventArgs e)
        {
            switch (action)
            {
                case "+": Result.Text = (ResultNum + double.Parse(Result.Text)).ToString(); break;
                case "-": Result.Text = (ResultNum - double.Parse(Result.Text)).ToString(); break;
                case "*": Result.Text = (ResultNum * double.Parse(Result.Text)).ToString(); break;
                case "/": if (Result.Text != "0") { Result.Text = (ResultNum / double.Parse(Result.Text)).ToString(); } else { MessageBox.Show("Common Man from 2 grade everyone knows that you cannot divide by zero"); } break;
            }
            if (Result.Text!="0")
            {
            ResultNum = double.Parse(Result.Text);
            action = "";
            }
        }
        private void ChangeSign(object sender, EventArgs e)
        {
            if (isOperated==false)
            {
            Result.Text = (double.Parse(Result.Text) * -1).ToString();
            }
        }
        private void Leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.FromArgb(22, 22, 22);
        }
        private void Enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.FromArgb(55, 55, 55);
        }
    }
}
