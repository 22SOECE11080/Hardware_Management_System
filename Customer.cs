using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hardwareapp
{
    public partial class Customer : Form
    {
        private int customerId;

        public Customer()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void Customer_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (customerId > 0)
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM customer WHERE customer_id = @id", con);
                cmd.Parameters.AddWithValue("@id", customerId);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data deleted successfully from the customer table");

                LoadCustomerData();

                // Clear the fields after deletion
                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Please select a record to delete");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO customer(customer_name, gender, phone) VALUES(@c_name, @gender, @phone)", con);
            cmd.Parameters.AddWithValue("@c_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data inserted successfully into the customer table");

            LoadCustomerData();

            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            textBox3.Clear();
        }

        private void LoadCustomerData()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM customer", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (customerId > 0)
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE customer SET customer_name=@c_name, gender=@gender, phone=@phone WHERE customer_id=@id", con);
                cmd.Parameters.AddWithValue("@c_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                cmd.Parameters.AddWithValue("@id", customerId);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data updated successfully in the customer table");

                LoadCustomerData();

                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Please select a record to update");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                customerId = Convert.ToInt32(row.Cells["customer_id"].Value);
                textBox1.Text = row.Cells["customer_name"].Value.ToString();
                comboBox1.Text = row.Cells["gender"].Value.ToString();
                textBox3.Text = row.Cells["phone"].Value.ToString();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Show();
            this.Hide(); // Optionally hide the login form
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Categories item = new Categories();
            item.Show();
            this.Hide(); // Optionally hide the login form
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Customer item = new Customer();
            item.Show();
            this.Hide(); // Optionally hide the login form
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Billing item = new Billing();
            item.Show();
            this.Hide(); // Optionally hide the login form
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Dashboard item = new Dashboard();
            item.Show();
            this.Hide(); // Optionally hide the login form
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide(); // Optionally hide the login form
        }
    }
}
