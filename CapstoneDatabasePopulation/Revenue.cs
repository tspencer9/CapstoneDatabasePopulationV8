using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneDatabasePopulation
{
    class Revenue
    {
        public int RevenueId { get; set; }
        public double Amount { get; set; }
        public string Details { get; set; }
        public DateTime RevenueDate { get; set; }
        public int CategoryId { get; set; }

        public Revenue(double income, string details, DateTime revenueDate)
        {
            this.Amount = income;
            this.Details = details;
            this.RevenueDate = revenueDate;
            this.CategoryId = 6; // so far only rent income from leased out spaces
        }

        public void InsertIntoRevenueTable()
        {
            string insertStatement = string.Format("INSERT INTO Revenue (Amount, Details, RevenueDate, CategoryId)" +
                $"VALUES ({this.Amount}, '{this.Details}', '{this.RevenueDate}', {this.CategoryId})");

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
