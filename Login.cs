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

namespace hardwareapp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Your connection string here. Update with your actual database connection string.
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True";

            // SQL query to check if the username and password exist in the register table
            string query = "SELECT COUNT(*) FROM register WHERE username = @username AND password = @password";

            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command with the query and the connection
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters to the command to prevent SQL injection
                command.Parameters.AddWithValue("@username", textBox1.Text);
                command.Parameters.AddWithValue("@password", textBox2.Text);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query and get the count of matching records
                    int count = (int)command.ExecuteScalar();

                    // Check if any records were found
                    if (count > 0)
                    {
                        // If credentials are valid, show the Item form
                        Item item = new Item();
                        item.Show();
                        this.Hide(); // Optionally hide the login form
                    }
                    else
                    {
                        // If credentials are invalid, show an error message
                        MessageBox.Show("Invalid Credentials");
                    }
                }
                catch (Exception ex)
                {
                    // Show any errors that occur during the database operation
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
