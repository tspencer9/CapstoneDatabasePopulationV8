using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneDatabasePopulation
{
    class Salary
    {
        public int SalaryId { get; set; }
        public double Amount { get; set; } // maybe set it to an autoraise upon the endDate expiring?
        public DateTime StartDate { get; set; }

        public int EmployeeId { get; set; }

        public Salary(int employeeId, double money)
        {
            this.EmployeeId = employeeId;
            this.Amount = money;
            this.StartDate = new DateTime(2017, CapstoneUtilities.random.Next(1, 13), CapstoneUtilities.random.Next(1, 29));
        }

        public void InsertIntoSalaryTable()
        {
            string insertStatement = string.Format("INSERT INTO Salary (Amount, StartDate, EmployeeId) VALUES ({0}, '{1}', " +
                "{2})", this.Amount, this.StartDate, this.EmployeeId);

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
