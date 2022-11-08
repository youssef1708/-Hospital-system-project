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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-6TTOEPKJ;Initial Catalog=Hospital System DATABASE;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "SELECT   ROOM.ROOM_ID AS Expr1, ROOM.TYPE, ROOM.STATUS, PATIENT.PATIENT_ID_ AS Expr2, PATIENT.PNAME AS Expr3, PATIENT.GENDER AS Expr4, PATIENT.AGE AS Expr5 FROM      ROOM INNER JOIN PATIENT ON PATIENT.ROOM_ID = ROOM.ROOM_ID ";
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
         
        }

        

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-6TTOEPKJ;Initial Catalog=Hospital System DATABASE;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "SELECT   ROOM.ROOM_ID AS ROOM_ID, ROOM.TYPE, ROOM.STATUS, PATIENT.PATIENT_ID_ AS PATIENT_ID_, PATIENT.PNAME AS PNAME, PATIENT.GENDER AS GENDER, PATIENT.AGE AS AGE FROM      ROOM INNER JOIN PATIENT ON PATIENT.ROOM_ID = ROOM.ROOM_ID ";
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
