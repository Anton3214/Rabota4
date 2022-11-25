﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void openchild(Panel pen, Form emptyF)
        {
            emptyF.TopLevel = false;
            emptyF.FormBorderStyle = FormBorderStyle.None;
            emptyF.Dock = DockStyle.Fill;
            pen.Controls.Add(emptyF);
            emptyF.BringToFront();
            emptyF.Show();
        }

            private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openchild(panel2, new lessons());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openchild(panel2, new Schedule());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openchild(panel2, new Teacher());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openchild(panel2, new Auth());
        }
    }
}
