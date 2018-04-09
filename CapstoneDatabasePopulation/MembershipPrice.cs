using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneDatabasePopulation
{
    class MembershipPrice
    {
        public int MembershipPriceId { get; set; } // autoincremented by SQL
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public int MembershipTypeId { get; set; }

        public MembershipPrice(double price, int membershipTypeId)
        {
            this.Price = price;
            this.StartDate = new DateTime(2017, CapstoneUtilities.random.Next(1, 13), CapstoneUtilities.random.Next(1, 29));
            this.MembershipTypeId = membershipTypeId;
        }

        public void InsertIntoMembershipPriceTable()
        {
            string insertStatement = string.Format("INSERT INTO MembershipPrice (Price, StartDate, MembershipId)" +
                " VALUES ({0}, '{1}', {2})", this.Price, this.StartDate, this.MembershipTypeId);

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
