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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace practical
{
    
    public partial class Form3 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProducStore"].ConnectionString);
            sqlConnection.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
            $"INSERT INTO [Productt] (Name, Price, BuyPrice,Quantity) values(N'{textBox1.Text}', N'{textBox2.Text}','{textBox3.Text}',N'{textBox4.Text}')",
    sqlConnection);
            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
    "select * from Productt",
    sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE [Productt] SET Name = @NewName WHERE ID = @StoreID";
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@NewName", textBox12.Text);
            command.Parameters.AddWithValue("@StoreID", textBox13.Text);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Изменено!");
            }
            else
            {
                MessageBox.Show("Ошибка при выполнении запроса!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE [Productt] SET Quantity = @NewName WHERE ID = @StoreID";
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@NewName", textBox8.Text);
            command.Parameters.AddWithValue("@StoreID", textBox13.Text);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Изменено!");
            }
            else
            {
                MessageBox.Show("Ошибка при выполнении запроса!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE [Productt] SET Price = @NewName WHERE ID = @StoreID";
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@NewName", textBox10.Text);
            command.Parameters.AddWithValue("@StoreID", textBox13.Text);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Изменено!");
            }
            else
            {
                MessageBox.Show("Ошибка при выполнении запроса!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE [Productt] SET BuyPrice = @NewName WHERE ID = @StoreID";
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@NewName", textBox7.Text);
            command.Parameters.AddWithValue("@StoreID", textBox13.Text);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Изменено!");
            }
            else
            {
                MessageBox.Show("Ошибка при выполнении запроса!");
            }
        }
    }
}
