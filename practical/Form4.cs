using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace practical
{
    public partial class Form4 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProducStore"].ConnectionString);
            sqlConnection.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
$"INSERT INTO [Ordersss] (Store_ID, Product_ID, Quantity, DateOrder) values(N'{textBox1.Text}', N'{textBox2.Text}','{textBox3.Text}',N'{textBox4.Text}')",
sqlConnection);
            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
    "SELECT ID,(SELECT Name FROM Storee WHERE Store_ID = IDStore) AS Store,(SELECT Name FROM Productt WHERE Product_ID = ID) AS Product, Quantity,(SELECT Price FROM Productt WHERE Product_ID = ID) AS BuyPrice,DateOrder, DateDone,Quantity * (SELECT Price FROM Productt WHERE Product_ID = ID) AS TotalGain FROM Ordersss;",
    sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
$"update [Ordersss] set Quantity = {textBox6.Text} where ID = {textBox13.Text}",
sqlConnection);
            if (command.ExecuteNonQuery().ToString() == "1")
            {
                MessageBox.Show("Изменено!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"UPDATE Ordersss SET DateOrder = '{textBox5.Text}' WHERE ID = {textBox13.Text}",
                sqlConnection);

            if (command.ExecuteNonQuery().ToString() == "1")
            {
                MessageBox.Show("Изменено!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
                        SqlCommand command = new SqlCommand(
                $"UPDATE Ordersss SET DateDone = '{textBox7.Text}' WHERE ID = {textBox13.Text}",
                sqlConnection);

            if (command.ExecuteNonQuery().ToString() == "1")
            {
                MessageBox.Show("Изменено!");
            }
        }
    }
}
