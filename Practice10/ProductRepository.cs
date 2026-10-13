using System.Data.SQLite;

namespace _10_practice
{
    public class ProductRepository
    {
        SQLiteConnection conn;
        public ProductRepository(SQLiteConnection connection)
        {
            conn = connection;
        }
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Products;", conn);
            conn.Open();
            SQLiteDataReader reader = cmd.ExecuteReader();
            
            while(reader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name =  Convert.ToString(reader["Name"]),
                    Price = Convert.ToDecimal(reader["Price"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                };
                products.Add(product);
            }

            conn.Close();
            return products;
        }
        public void Add(Product product)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "INSERT INTO Products(Name, Price, Quantity) VALUES (@name, @price, @quantity);",
                conn
            );
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@quantity", product.Quantity);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Update(Product product)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                @"UPDATE Products 
                SET NAME = @name,
                PRICE = @price,
                Quantity = @quantity
                WHERE Id = @id;",
                conn
            );
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@id", product.Id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete(Product product)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                @"DELETE FROM Products
                WHERE Id = @id
                ",
                conn
            );
            cmd.Parameters.AddWithValue("@id", product.Id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
