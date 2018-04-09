using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Need to figure out how to keep the current DateTime object stable and uniform throughout application. the GetIsCurrent() compares
 * the expiration date of the membership to the current dateTime object. Need to figure out how to keep that object alive throughout
 * the whole application
 */

namespace CapstoneDatabasePopulation
{
    class Membership
    {
        static DateTime currentDate = DateTime.Now; // how to keep date current in main application?
        public int MembershipId { get; set; } // autoincremented in SQL
        public int GymUserId { get; set; } // needs to match the MembershipId
        public int MembershipTypeId { get; set; }

        DateTime startDate;

        public DateTime GetStartDate()
        {
            startDate = new DateTime(CapstoneUtilities.random.Next(2017, DateTime.Now.Year + 1),
                CapstoneUtilities.random.Next(1, 13), CapstoneUtilities.random.Next(1, 29));

            if (startDate > DateTime.Now)
                return new DateTime(startDate.Year - 1, startDate.Month, startDate.Day);
            else
                return startDate;
        }

        public DateTime GetEndDate()
        {
            return new DateTime(startDate.Year + 1, startDate.Month, startDate.Day);
        }

        public Membership(int gymUserId)
        {
            this.GymUserId = gymUserId;
            this.MembershipTypeId = CapstoneUtilities.random.Next(1, 4);
        }

        public void InsertIntoMembershipTable()
        {
            string insertStatement = string.Format("INSERT INTO Membership (GymUserId, MembershipTypeId, StartDate, EndDate) VALUES " +
                "({0}, {1}, '{2}', '{3}')", this. GymUserId, this.MembershipTypeId, this.GetStartDate(), this.GetEndDate());

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
