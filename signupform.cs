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
    public partial class signupform : Form
    {
        public signupform()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection();
        public SqlDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //attaching connection string
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\.Net\Z.Projects\Student.mdf;Integrated Security=True;Connect Timeout=30";

                //open connection
                con.Open();

                string query = "Insert into Credentials values('" + usernametext.Text + "', '" + passwordtext.Text + "')";
                SqlCommand cmdInsert = new SqlCommand(query, con);
                cmdInsert.ExecuteNonQuery();

                MessageBox.Show("Credentails Added Successfully !!!");

                usernametext.Clear();
                passwordtext.Clear();

                //closing connection
                con.Close();
            }
            catch
            {
                MessageBox.Show("Please enter valid credentials");
            }
            finally
            {
               //
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            loginform lgfm = new loginform();
            lgfm.Show();
            this.Hide();
        }
    }
}
