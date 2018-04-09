using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneDatabasePopulation
{
    class Expense
    {
        public int ExpenseId { get; set; }
        public double Amount { get; set; }
        public string Details { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int CategoryId { get; set; }

        public Expense(double amount, string details, DateTime expenseDate, int categoryId)
        {
            this.Amount = amount;
            this.Details = details;
            this.ExpenseDate = expenseDate;
            this.CategoryId = categoryId; // so far only rent income from leased out spaces
        }

        public void InsertIntoExpenseTable()
        {
            string insertStatement = string.Format("INSERT INTO Expense (Amount, Details, ExpenseDate, CategoryId)" +
                $"VALUES ({this.Amount}, '{this.Details}', '{this.ExpenseDate}', {this.CategoryId})");

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
