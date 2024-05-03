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

namespace CSProject
{
    public partial class dataform : Form
    {
        public dataform()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection();
        public SqlDataReader dr;

        // CREATE
        private void insertbtn_Click(object sender, EventArgs e)
        {
            //attaching connection string
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\.Net\Z.Projects\Student.mdf;Integrated Security=True;Connect Timeout=30";

            //open connection
            con.Open();

            string query = "Insert into Student values('" + idtextBox.Text + "', '" + nametextBox.Text + "', '" + rollnotextBox.Text + "', '" + depttextBox.Text + "', '" + mobiletextBox.Text + "', '" + addresstextBox.Text + "')";
            SqlCommand cmdInsert = new SqlCommand(query, con);
            cmdInsert.ExecuteNonQuery();

            MessageBox.Show("Record Added...");

            //closing connection
            con.Close();
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            //attaching connection string
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\.Net\Z.Projects\Student.mdf;Integrated Security=True;Connect Timeout=30";

            //open connection
            con.Open();

            SqlCommand cmdEdit = new SqlCommand("select Stud_Name from Student", con);
            dr = cmdEdit.ExecuteReader();

            comboBox1.Items.Clear();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            comboBox1.Visible = true;

            //closing connection
            con.Close();
        }

        // READ
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //attaching connection string
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\.Net\Z.Projects\Student.mdf;Integrated Security=True;Connect Timeout=30";

            //open connection
            con.Open();

            SqlCommand cmdCombo = new SqlCommand(" select * from Student where Stud_Name =  '" + (comboBox1.Text) + "'    ", con);
            dr = cmdCombo.ExecuteReader();

            while (dr.Read())
            {
                idtextBox.Text = dr[0].ToString();
                nametextBox.Text = dr[1].ToString();
                rollnotextBox.Text = dr[2].ToString();
                depttextBox.Text = dr[3].ToString();
                mobiletextBox.Text = dr[4].ToString();
                addresstextBox.Text = dr[5].ToString();
            }
            dr.Close();
            comboBox1.Visible = false;

            //closing connection
            con.Close();
        }

        // UPDATE
        private void updatebtn_Click(object sender, EventArgs e)
        {
            //attaching connection string
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\.Net\Z.Projects\Student.mdf;Integrated Security=True;Connect Timeout=30";

            //open connection
            con.Open();

            SqlCommand cmdUpdate = new SqlCommand(" update Student set Stud_Name = '" + (nametextBox.Text) + "', Roll_No = " + (rollnotextBox.Text) + ", Department = '" + (depttextBox.Text) + "', Mobile = " + (mobiletextBox.Text) + ", Address = '" + (addresstextBox.Text) + "' where Stud_Id = " + (idtextBox.Text) + " ", con);
            cmdUpdate.ExecuteNonQuery();

            MessageBox.Show("Record Updated...");

            //closing connection
            con.Close();
        }

        // DELETE
        private void deletebtn_Click(object sender, EventArgs e)
        {
            //attaching connection string
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\.Net\Z.Projects\Student.mdf;Integrated Security=True;Connect Timeout=30";

            //open connection
            con.Open();

            //string query = "Delete from Student where('" + textid.Text + "', '" + textname.Text + "', '" + textrollno.Text + "', '" + textmobile.Text + "', '" + textaddress.Text + "')";
            SqlCommand cmdDelete = new SqlCommand(" delete from Student where Roll_No = " + (rollnotextBox.Text) + " ", con);
            cmdDelete.ExecuteNonQuery();

            MessageBox.Show("Record Deleted...");

            //closing connection
            con.Close();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform lgfm = new loginform();
            lgfm.Show();
        }
    }
}
