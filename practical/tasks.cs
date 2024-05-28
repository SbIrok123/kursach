using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practical
{
    public partial class tasks : Form
    {
        private SqlConnection sqlConnection = null;
        public tasks()
        {
            InitializeComponent();
        }

        private void tasks_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProducStore"].ConnectionString);
            sqlConnection.Open();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT p.Name, SUM(o.Quantity) AS TotalVegetables FROM Productt p JOIN Ordersss o ON p.ID = o.Product_ID WHERE o.DateOrder = '{textBox1.Text}' GROUP BY p.Name;", sqlConnection);


            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
            $"SELECT p.Name, SUM(o.Quantity * p.BuyPrice) as buyPrice, SUM(o.Quantity * p.Price) AS TotalProfit, (p.Quantity - SUM(o.Quantity)) AS ProductLeft from Productt p JOIN Ordersss o ON p.ID = o.Product_ID WHERE (o.DateOrder BETWEEN '2024-03-27' AND '2024-03-30') AND p.Name = N'{textBox2.Text}' GROUP BY p.Name, p.Quantity;",
            sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
    $"SELECT p.Name, SUM(o.Quantity * p.Price) - SUM(o.Quantity * p.BuyPrice) AS TotalProfit FROM Productt p JOIN Ordersss o ON p.ID = o.Product_ID WHERE (o.DateOrder BETWEEN '{textBox6.Text}' AND '{textBox5.Text}') and p.Name = N'{textBox3.Text}' GROUP BY p.Name;",
    sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }


        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
$"SELECT p.Name, SUM(o.Quantity) AS TotalSold FROM Productt p JOIN Ordersss o ON p.ID = o.Product_ID WHERE (o.DateOrder BETWEEN '{textBox7.Text}' AND '{textBox4.Text}')",
sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }
    }
}
