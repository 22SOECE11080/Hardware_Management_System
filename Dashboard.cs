using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hardwareapp
{
    public partial class Dashboard : Form
    {
        // Your connection string to the SQL Server
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True";

        public Dashboard()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // Load data for each DataGridView
            LoadTableData1("Table1", dataGridView1);
            LoadTableData2("Table2", dataGridView2);
            LoadTableData3("Table3", dataGridView3);
            LoadTableData4("Table4", dataGridView4);
        }

        private void LoadTableData1(string tableName, DataGridView gridView)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Query to select all data from the specified table
                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM item", connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Bind data to the DataGridView
                    gridView.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data from {tableName}: {ex.Message}");
                }
            }
        }

        private void LoadTableData2(string tableName, DataGridView gridView)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Query to select all data from the specified table
                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Billing", connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Bind data to the DataGridView
                    gridView.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data from {tableName}: {ex.Message}");
                }
            }
        }

        private void LoadTableData3(string tableName, DataGridView gridView)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Query to select all data from the specified table
                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Customer", connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Bind data to the DataGridView
                    gridView.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data from {tableName}: {ex.Message}");
                }
            }
        }

        private void LoadTableData4(string tableName, DataGridView gridView)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Query to select all data from the specified table
                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM catogary", connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Bind data to the DataGridView
                    gridView.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data from {tableName}: {ex.Message}");
                }
            }
        }

        // Event handlers for label clicks (unchanged)
        private void label7_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Categories item = new Categories();
            item.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customer item = new Customer();
            item.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Billing item = new Billing();
            item.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Dashboard item = new Dashboard();
            item.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide(); // Optionally hide the login form
        }

        // DataGridView cell content click events (unchanged)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
