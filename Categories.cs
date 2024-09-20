using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hardwareapp
{
    public partial class Categories : Form
    {
        private int categoryId;

        public Categories()
        {
            InitializeComponent();
            LoadCategoryData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (categoryId > 0)
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM catogary WHERE catogary_id = @id", con);
                cmd.Parameters.AddWithValue("@id", categoryId);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data deleted successfully from the category table");

                LoadCategoryData();

                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Please select a record to delete");
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO catogary(Catogary_name) VALUES(@c_name)", con);
            cmd.Parameters.AddWithValue("@c_name", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data inserted successfully into the category table");

            LoadCategoryData();

            textBox1.Clear();
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (categoryId > 0)
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE catogary SET Catogary_name=@c_name WHERE catogary_id=@id", con);
                cmd.Parameters.AddWithValue("@c_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@id", categoryId);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data updated successfully in the category table");

                LoadCategoryData();

                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Please select a record to update");
            }
        }

        private void LoadCategoryData()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM catogary", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                categoryId = Convert.ToInt32(row.Cells["catogary_id"].Value);
                textBox1.Text = row.Cells["Catogary_name"].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
            // Navigate to AnotherPage
            Item anotherPage = new Item();
            anotherPage.Show();
            this.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.Show();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();   
            billing.Show();
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Dashboard item = new Dashboard();
            item.Show();
            this.Hide(); // Optionally hide the login form
            this.Close();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide(); // Optionally hide the login form
        }
    }
}
