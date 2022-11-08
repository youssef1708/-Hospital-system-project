using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace database_projectt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-6TTOEPKJ;Initial Catalog=Hospital System DATABASE;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = " Insert Into DOCTOR VALUES('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox1.Text.ToString() + "', '" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')";
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Doctor information added successufully ");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_System_DATABASEDataSet.DOCTOR' table. You can move, or remove it, as needed.
            this.dOCTORTableAdapter.Fill(this.hospital_System_DATABASEDataSet.DOCTOR);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dOCTORTableAdapter.Fill(this.hospital_System_DATABASEDataSet.DOCTOR);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-6TTOEPKJ;Initial Catalog=Hospital System DATABASE;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "DELETE FROM DOCTOR WHERE DOCTOR_ID = '"+textBox1.Text.ToString()+"' ";
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Doctor information Deleted successufully ");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("TEXT BOX IS EMPTY");
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-6TTOEPKJ;Initial Catalog=Hospital System DATABASE;Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "UPDATE DOCTOR SET PHONE_NUMBER = '" + textBox2.Text.ToString() + "' WHERE DOCTOR_ID = '" + textBox1.Text.ToString() + "'  ";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = "UPDATE DOCTOR SET DEPARTMENT_NAME_ = '" + comboBox1.Text.ToString() + "' WHERE DOCTOR_ID = '" + textBox1.Text.ToString() + "'  ";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = "UPDATE DOCTOR SET DRNAME = '" + textBox4.Text.ToString() + "' WHERE DOCTOR_ID = '" + textBox1.Text.ToString() + "'  ";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = "UPDATE DOCTOR SET AGE = '" + textBox5.Text.ToString() + "' WHERE DOCTOR_ID = '" + textBox1.Text.ToString() + "'  ";
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                MessageBox.Show("Doctor information Updated successufully ");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
