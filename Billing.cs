using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hardwareapp
{
    public partial class Billing : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dotnet_Programs\\hardwareapp\\Haedwaredatabase.mdf;Integrated Security=True";

        public Billing()
        {
            InitializeComponent();
            LoadData();
            LoadBillingData();
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadBillingData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"SELECT item.item_id, item.item_name, item.price, item.manufacture, catogary.catogary_name 
                                     FROM item
                                     JOIN catogary ON item.item_catogary = catogary.catogary_id";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns["item_id"].Visible = false; // Hide the item_id column if not needed
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadBillingData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"SELECT * FROM Billing";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("Billing data loaded successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No billing data found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dataGridView2.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading billing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["item_name"].Value.ToString();
                textBox4.Text = row.Cells["price"].Value.ToString();
                textBoxItemId.Text = row.Cells["item_id"].Value.ToString(); // Add a hidden TextBox to store item_id
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                string itemName = textBox1.Text;
                string priceText = textBox4.Text;
                string quantityText = textBox3.Text;
                string c_name = textBox5.Text;
                string itemIdText = textBoxItemId.Text;

                // Output values for debugging
                MessageBox.Show($"Price: {priceText}, Quantity: {quantityText}, Item ID: {itemIdText}, Customer Name: {c_name}", "Debug");

                // Validate and parse values
                if (!decimal.TryParse(priceText, out decimal price))
                {
                    MessageBox.Show("Invalid price value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(quantityText, out int quantity))
                {
                    MessageBox.Show("Invalid quantity value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal amount = price * quantity;

                if (!int.TryParse(itemIdText, out int itemId))
                {
                    MessageBox.Show("Invalid item ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert billing record
                    string insertQuery = @"INSERT INTO Billing (bill_date, amount, item_name, quantity, c_name) 
                                           VALUES (@bill_date, @amount, @item_name, @quantity, @c_name)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@bill_date", DateTime.Now); // or get from a DateTimePicker
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@item_name", itemName);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@c_name", c_name);

                        cmd.ExecuteNonQuery();
                    }

                    // Update item stock
                    string updateQuery = @"UPDATE item SET stock = stock - @quantity WHERE item_id = @item_id";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@item_id", itemId);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Billing record added and stock updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    LoadBillingData();
                    textBox1.Clear();
                    textBox4.Clear();
                    textBox3.Clear();
                    textBox5.Clear();
                    textBoxItemId.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while inserting or updating data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure this method is correctly associated with dataGridView2's CellContentClick event
        }

        private void reset_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox4.Clear();
        }

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

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string itemName = textBox1.Text;
                string priceText = textBox4.Text.Trim(); // Trim any spaces
                string quantityText = textBox3.Text;
                string c_name = textBox5.Text;
                string itemIdText = textBoxItemId.Text;

                // Try parsing the price, allowing for common formatting (like commas)
                if (!decimal.TryParse(priceText, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out decimal price))
                {
                    MessageBox.Show("Invalid price value. Please ensure it's a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(quantityText, out int quantity))
                {
                    MessageBox.Show("Invalid quantity value. Please ensure it's a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal amount = price * quantity;

                // Generate the HTML file for printing after inserting into the database
                string htmlContent = GenerateHTMLContent(c_name, itemName, quantity, price, amount);

                // Save the HTML file
                string filePath = @"D:\Dotnet_Programs\hardwareapp\billing_invoice.html";
                System.IO.File.WriteAllText(filePath, htmlContent);

                MessageBox.Show("Billing record added. HTML file for invoice generated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally, open the HTML file in the default browser
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while inserting or updating data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Method to generate HTML content with JavaScript for printing
        private string GenerateHTMLContent(string customerName, string itemName, int quantity, decimal price, decimal amount)
        {
            return $@"
    <!DOCTYPE html>
    <html lang='en'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>Billing Invoice</title>
        <style>
            body {{
                font-family: Arial, sans-serif;
            }}
            .invoice-box {{
                width: 100%;
                border: 1px solid #eee;
                padding: 20px;
                margin-top: 20px;
            }}
            .invoice-box table {{
                width: 100%;
                line-height: inherit;
                text-align: left;
            }}
            .invoice-box table td {{
                padding: 5px;
                vertical-align: top;
            }}
            .invoice-box table tr td:nth-child(2) {{
                text-align: right;
            }}
            .invoice-box table tr.top table td {{
                padding-bottom: 20px;
            }}
            .invoice-box table tr.item td {{
                border-bottom: 1px solid #eee;
            }}
            .invoice-box table tr.total td:nth-child(2) {{
                border-top: 2px solid #eee;
                font-weight: bold;
            }}
        </style>
    </head>
    <body>
        <div class='invoice-box'>
            <h2>Invoice</h2>
            <p>Customer Name: {customerName}</p>
            <table>
                <tr class='item'>
                    <td>Item</td>
                    <td>{itemName}</td>
                </tr>
                <tr class='item'>
                    <td>Quantity</td>
                    <td>{quantity}</td>
                </tr>
                <tr class='item'>
                    <td>Price</td>
                    <td>{price}</td>
                </tr>
                <tr class='total'>
                    <td>Total</td>
                    <td>{amount}</td>
                </tr>
            </table>
        </div>

        <!-- JavaScript to print the page -->
        <script>
            window.onload = function() {{
                window.print();
            }};
        </script>
    </body>
    </html>
    ";
        }

    }
}
