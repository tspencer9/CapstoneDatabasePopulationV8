using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneDatabasePopulation
{
    class FinanceCategory
    {
        public int CategoryId { get; set; }
        public string FinanceName { get; set; }

        public FinanceCategory(string name)
        {
            this.FinanceName = name;
        }

        public void InsertIntoFinanceCategoryTable()
        {
            string insertStatement = string.Format($"INSERT INTO FinanceCategory (CategoryName) VALUES ('{this.FinanceName}')");

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
