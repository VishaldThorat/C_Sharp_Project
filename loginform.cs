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
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Validate username and password
            if (IsValid(username, password))
            {
                MessageBox.Show("Login successful!");
                // Redirect to main application or perform other actions
                dataform dtfm = new dataform();
                dtfm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
                // Clear password field
                textBox1.Clear();
                textBox2.Clear();
            }  
        }
        private bool IsValid(string username, string password)
        {
            // To validate the credentials from the database
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\.Net\Z.Projects\Student.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                string query = "SELECT password FROM Credentials WHERE username = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string storedpassword = reader["password"].ToString();
                        // Here you would use your password hashing algorithm (e.g., bcrypt) to compare password hashes
                        // For simplicity, I'll compare plaintext passwords for demonstration purposes
                        if (password == storedpassword)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    // Handle the exception as needed
                }
            }
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            signupform sgup = new signupform();
            sgup.Show();
            this.Hide();
        }

    }
}
