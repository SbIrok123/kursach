﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace practical
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProducStore"].ConnectionString);
            sqlConnection.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            tasks tasks = new tasks();
            tasks.Show();
        }
    }
}
