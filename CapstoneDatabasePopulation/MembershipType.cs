using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneDatabasePopulation
{
    class MembershipType
    {
        public int MembershipTypeId { get; set; } // set through autoincrementing in SQL
        public string MembershipTypeName { get; set; }

        public bool AccessClass { get; set; }
        public bool AccessTrainer { get; set; }

        public MembershipType(string name, bool accessClass, bool accessTrainer)
        {
            this.MembershipTypeName = name;
            this.AccessClass = accessClass;
            this.AccessTrainer = accessTrainer;
        }

        public void InsertIntoMembershipTypeTable()
        {
            string insertStatement = string.Format("INSERT INTO MembershipType (MembershipTypeName, AccessClass," +
                " AccessTrainer) VALUES ('{0}', '{1}', '{2}')", this.MembershipTypeName, this.AccessClass, this.AccessTrainer);

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
