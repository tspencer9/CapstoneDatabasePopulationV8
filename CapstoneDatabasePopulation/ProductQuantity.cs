using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneDatabasePopulation
{
    class ProductQuantity
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int ProdQty { get; set; }

        public double GetWholesaleTotal()
        {
            string queryString = string.Format($"SELECT WholesalePrice FROM ProductPrice WHERE ProductId = {ProductId} AND EndDate IS NULL");
            CapstoneUtilities.command = new SqlCommand(queryString, CapstoneUtilities.connection);

            using (SqlDataReader reader = CapstoneUtilities.command.ExecuteReader())
            {
                if (reader.Read())
                    return Convert.ToDouble(reader["WholesalePrice"]) * ProdQty;
                else
                    throw new Exception("Data not successfully retrieved...");
            }
        }

        public double GetRetailTotal()
        {
            string queryString = string.Format($"SELECT RetailPrice FROM ProductPrice WHERE ProductId = {ProductId} AND EndDate IS NULL");
            CapstoneUtilities.command = new SqlCommand(queryString, CapstoneUtilities.connection);

            using (SqlDataReader reader = CapstoneUtilities.command.ExecuteReader())
            {
                if (reader.Read())
                    return Convert.ToDouble(reader["RetailPrice"]) * ProdQty;
                else
                    throw new Exception("Data not successfully retrieved...");
            }
        }

        public ProductQuantity(int purchaseId, int productId, int productQuantity)
        {
            this.PurchaseId = purchaseId;
            this.ProductId = productId;
            this.ProdQty = productQuantity;
            UpdateProductInventory();
        }

        public void InsertIntoProductQuantityTable()
        {
            string insertStatement = string.Format("INSERT INTO ProdQty (PurchaseId, ProductId, ProdQty, WholesaleTotal, Retailtotal) " +
                "VALUES ({0}, {1}, {2}, {3}, {4})", this.PurchaseId, this.ProductId, this.ProdQty, GetWholesaleTotal(), GetRetailTotal());

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }

        private void UpdateProductInventory()
        {
            int currentQuantity,
                updatedQuantity;

            string queryStatement = string.Format($"SELECT Quantity FROM Product WHERE ProductId = {ProductId};");
            CapstoneUtilities.command = new SqlCommand(queryStatement, CapstoneUtilities.connection);

            using (SqlDataReader reader = CapstoneUtilities.command.ExecuteReader())
            {
                if (reader.Read())
                    currentQuantity = Convert.ToInt32(reader["Quantity"]);
                else
                    throw new Exception("Data not successfully retrieved...");
            }

            updatedQuantity = currentQuantity - ProdQty;

            string updateStatement = string.Format($"UPDATE Product SET Quantity = {updatedQuantity} WHERE ProductId = {ProductId};");
            new SqlCommand(updateStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
