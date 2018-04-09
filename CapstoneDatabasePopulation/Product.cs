using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// the quantity of the product will vary depending on inventory management as well as the quantity sold in purchases

namespace CapstoneDatabasePopulation
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; } // will be affected by the quantity purchased. this is dependent upon other tables and queries.

        public Product(string name, string category, string description, int quantity)
        {
            this.ProductName = name;
            this.Category = category;
            this.Description = description;
            this.Quantity = quantity;
        }

        public void InsertIntoProductTable()
        {
            string insertStatement = string.Format("INSERT INTO Product (ProductName, Category, ProductDescription, Quantity) VALUES " +
                "('{0}', '{1}', '{2}', {3})", this.ProductName, this.Category, this.Description, this.Quantity);

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
