using System.Data.SQLite;

namespace _10_practice
{
    public partial class Form1 : Form
    {
        SQLiteConnection conn;
        ProductRepository productRepository;

        public Form1()
        {
            InitializeComponent();
            Text = "Catalgue";
            string path_database = Application.StartupPath + "\\data.db";
            conn = new SQLiteConnection("Data Source=" + path_database + "; Version=3;");
            productRepository = new ProductRepository(conn);
            LoadProducts();
        }
        private void LoadProducts()
        {
            var products = productRepository.GetAll();
            dataGridView1.DataSource = products;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists("data.db"))
            {
                SQLiteConnection.CreateFile("data.db");
                MessageBox.Show("DB created");
            }
            else
            {
                MessageBox.Show("DB exists");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = @"CREATE TABLE Products (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name TEXT NOT NULL,
                                Price REAL NOT NULL,
                                Quantity INTEGER NOT NULL
                            );
                            ";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Table created");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }
            if (!decimal.TryParse(textBox2.Text, out decimal price))
            {
                MessageBox.Show("Invalid price");
                return;
            }
            if (!int.TryParse(textBox3.Text, out int quantity))
            {
                MessageBox.Show("Invalid quantity");
                return;
            }
            Product product = new Product
            {
                Name = textBox1.Text,
                Price = price,
                Quantity = quantity,
            };
            productRepository.Add(product);
            LoadProducts();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Product product = (Product)dataGridView1.CurrentRow.DataBoundItem;
            productRepository.Delete(product);
            LoadProducts();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            Product oldProduct = (Product)dataGridView1.CurrentRow.DataBoundItem;
            Product newProduct = new Product
            {
                Id = oldProduct.Id,
                Name = textBox1.Text,
                Price = Convert.ToDecimal(textBox2.Text),
                Quantity = Convert.ToInt32(textBox3.Text),
            };
            productRepository.Update(newProduct);
            LoadProducts();
        }
    }
}
