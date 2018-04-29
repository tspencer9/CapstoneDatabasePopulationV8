using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneDatabasePopulation
{
    class Purchase
    {
        static int customerNumber = FindCustomerNumber();

        public int PurchaseId { get; set; } // autoincremented by SQL - primary key
        public int CustomerId { get; set; } // foreign key

        DateTime GetPurchaseDate()
        {
            DateTime purchaseDate = new DateTime(2018,
                CapstoneUtilities.random.Next(1, DateTime.Now.Month + 1), CapstoneUtilities.random.Next(1, 29));
            if (purchaseDate > DateTime.Now)
                return new DateTime(2018, purchaseDate.Month, purchaseDate.Day);
            else
                return purchaseDate;
        }
        
        public Purchase()
        {
            this.CustomerId = CapstoneUtilities.random.Next(1, customerNumber + 1);
        }

        static int FindCustomerNumber()
        {
            string queryStatement = string.Format($"SELECT COUNT(*) FROM GymUser");
            CapstoneUtilities.command = new SqlCommand(queryStatement, CapstoneUtilities.connection);
            return (int)CapstoneUtilities.command.ExecuteScalar();
        }

        public void InsertIntoPurchaseTable()
        {
            string insertStatement = string.Format("INSERT INTO Purchase (CustomerId, PurchaseDate) " +
                "VALUES ({0}, '{1}')", this.CustomerId, this.GetPurchaseDate());

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
