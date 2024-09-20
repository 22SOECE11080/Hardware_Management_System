using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hardwareapp
{
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
            LoadCategories();
            LoadItems();
        }

        private void LoadCategories()
        {
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM catogary", con);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "catogary_name";
                comboBox1.ValueMember = "catogary_id";
            }
        }

        private void LoadItems()
        {
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM item", con);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO item (item_name, item_catogary, price, manufacture, stock) VALUES (@item_name, @item_catogary, @price, @manufacture, @stock)", con);
                cmd.Parameters.AddWithValue("@item_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@item_catogary", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@price", textBox3.Text);
                cmd.Parameters.AddWithValue("@manufacture", textBox5.Text);
                cmd.Parameters.AddWithValue("@stock", textBox4.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data inserted successfully");

                LoadItems();
                ClearFields();
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE item SET item_name=@item_name, item_catogary=@item_catogary, price=@price, manufacture=@manufacture, stock=@stock WHERE item_id=@item_id", con);
                cmd.Parameters.AddWithValue("@item_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@item_catogary", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@price", textBox3.Text);
                cmd.Parameters.AddWithValue("@manufacture", textBox5.Text);
                cmd.Parameters.AddWithValue("@stock", textBox4.Text);
                cmd.Parameters.AddWithValue("@item_id", textBox3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data updated successfully");

                LoadItems();
                ClearFields();
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM item WHERE item_id=@item_id", con);
                cmd.Parameters.AddWithValue("@item_id", textBox3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data deleted successfully");

                LoadItems();
                ClearFields();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox3.Text = row.Cells["item_id"].Value.ToString();
                textBox1.Text = row.Cells["item_name"].Value.ToString();
                comboBox1.SelectedValue = row.Cells["item_catogary"].Value;
                textBox3.Text = row.Cells["price"].Value.ToString();
                textBox4.Text = row.Cells["stock"].Value.ToString();
                textBox5.Text = row.Cells["manufacture"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = -1;
        }

        // Optional: Handle other events if needed
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide(); // Optionally hide the login form
        }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Show();
            this.Hide(); // Optionally hide the login form
        }
        private void Item_Load(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.Show();
            this.Hide(); // Optionally hide the login form
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
            this.Hide(); // Optionally hide the login form
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();
            this.Hide(); // Optionally hide the login form
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Dashboard billing = new Dashboard();
            billing.Show();
            this.Hide(); // Optionally hide the login form
        }
    }
}
