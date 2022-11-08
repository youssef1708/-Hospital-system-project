using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace database_projectt
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_System_DATABASEDataSet.PATIENT' table. You can move, or remove it, as needed.
            this.pATIENTTableAdapter.Fill(this.hospital_System_DATABASEDataSet.PATIENT);
            // TODO: This line of code loads data into the 'hospital_System_DATABASEDataSet.ROOM' table. You can move, or remove it, as needed.
            this.rOOMTableAdapter.Fill(this.hospital_System_DATABASEDataSet.ROOM);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-6TTOEPKJ;Initial Catalog=Hospital System DATABASE;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            string occ = "OCCUPIED";
            string room = textBox2.Text.ToString();
            string roomS;
            sqlCommand.CommandText = " SELECT STATUS FROM ROOM WHERE ROOM_ID = +'" + room + "' ";
            roomS = sqlCommand.ExecuteScalar().ToString();
            if (occ == roomS)
            {
                MessageBox.Show("this room is occupied ");

            }
            else
            {
                sqlCommand.CommandText = " Insert Into PATIENT VALUES('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "', '" + comboBox1.Text.ToString() + "','" + textBox5.Text.ToString() + "')";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = " Update ROOM SET STATUS =  '" + occ + "' WHERE ROOM_ID = '" + room + "'";
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Patient information added successufully ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.pATIENTTableAdapter.Fill(this.hospital_System_DATABASEDataSet.PATIENT);
            this.rOOMTableAdapter.Fill(this.hospital_System_DATABASEDataSet.ROOM);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-6TTOEPKJ;Initial Catalog=Hospital System DATABASE;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            string roomS;
            string room = textBox2.Text.ToString();
            sqlConnection.Open();
            string empty = "empty";
            sqlCommand.CommandText = " SELECT STATUS FROM ROOM WHERE ROOM_ID = +'" + room + "' ";
            roomS = sqlCommand.ExecuteScalar().ToString();

            if (roomS != empty)
            {
                sqlCommand.CommandText = "DELETE FROM PATIENT WHERE PATIENT_ID_= '" + textBox1.Text.ToString() + "'";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = " Update ROOM SET STATUS =  '" + empty + "' WHERE ROOM_ID = '" + room + "'";
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Patient information Deleted successufully ");
            }
            else
            {
                MessageBox.Show("Invalid ROOM ID ");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-6TTOEPKJ;Initial Catalog=Hospital System DATABASE;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            string occ = "OCCUPIED";
            string room = textBox2.Text.ToString();
            string roomS;
            string empty = "empty";
            string roomID;
            sqlCommand.CommandText = " SELECT ROOM_ID FROM PATIENT WHERE  PATIENT_ID_ = '" + textBox1.Text.ToString() + "' ";
            roomID = sqlCommand.ExecuteScalar().ToString();
            sqlCommand.CommandText = " Update ROOM SET STATUS =  '" + empty + "' WHERE ROOM_ID = '" +roomID+ "'";
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = " SELECT STATUS FROM ROOM WHERE ROOM_ID = +'" + room + "' ";
            roomS = sqlCommand.ExecuteScalar().ToString();
            if (occ == roomS)
            {
                MessageBox.Show("this room is occupied ");

            }
            else
            {
                sqlCommand.CommandText = "UPDATE PATIENT SET ROOM_ID = '" + textBox2.Text.ToString() + "' WHERE PATIENT_ID_ = '" + textBox1.Text.ToString() + "'  ";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = "UPDATE PATIENT SET PNAME = '" + textBox3.Text.ToString() + "' WHERE PATIENT_ID_ = '" + textBox1.Text.ToString() + "'  ";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = "UPDATE PATIENT SET GENDER = '" + comboBox1.Text.ToString() + "' WHERE PATIENT_ID_ = '" + textBox1.Text.ToString() + "'  ";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = "UPDATE PATIENT SET AGE = '" + textBox5.Text.ToString() + "' WHERE PATIENT_ID_ = '" + textBox1.Text.ToString() + "'  ";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = " Update ROOM SET STATUS =  '" + occ + "' WHERE ROOM_ID = '" + room + "'";
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Patient information Updated successufully ");
            }





        }
    }
}
