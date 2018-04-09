using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* need to also keep track of time for comparison to whether or not the pricing for the sale items is current.
 * At the moment pricing for items is static and generated through writing it in via hard coding.
 */

namespace CapstoneDatabasePopulation
{
    class ProductPrice
    {
        public int ProductPriceId { get; set; } // autoincremented in SQL
        public double WholesalePrice { get; set; }
        
        public double GetRetailPrice() // can be manually set by administrators in actual application
        {
            return WholesalePrice * 2;
        }

        public int ProductId { get; set; } // foreign key

        public ProductPrice(double wholesalePrice, int id)
        {
            this.WholesalePrice = wholesalePrice;
            this.ProductId = id;
        }

        public DateTime GetStartDate()
        {
            DateTime startDate = new DateTime(CapstoneUtilities.random.Next(2017, DateTime.Now.Year + 1),
                CapstoneUtilities.random.Next(1, 13), CapstoneUtilities.random.Next(1, 29));

            if (startDate > DateTime.Now)
                return new DateTime(startDate.Year - 1,
                    startDate.Month, startDate.Day);
            else
                return startDate;
        }

        public void InsertIntoProductPriceTable()
        {
            string insertStatement = string.Format("INSERT INTO ProductPrice (WholesalePrice, RetailPrice, StartDate, ProductId) VALUES " +
                "({0}, {1}, '{2}', {3})", this.WholesalePrice, this.GetRetailPrice(), this.GetStartDate(), this.ProductId);

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
