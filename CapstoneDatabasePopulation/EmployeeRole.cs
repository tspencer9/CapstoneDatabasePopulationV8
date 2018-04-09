using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapstoneDatabasePopulation
{
    class EmployeeRole
    {
        public int RoleId { get; set; }// RoleId is set by autoincrement in SQL
        public string RoleName { get; set; }
        public bool ManageCustomer { get; set; }
        public bool ManageClass { get; set; }
        public bool ManageEmployee { get; set; }
        public bool ManageInventory { get; set; }
        public bool ManageFinancials { get; set; }

        public EmployeeRole(string roleName, bool manageCustomer, bool manageClass, bool manageEmployee, bool manageInventory, bool manageFinancials)
        {
            this.RoleName = roleName;
            this.ManageCustomer = manageCustomer;
            this.ManageClass = manageClass;
            this.ManageEmployee = manageEmployee;
            this.ManageInventory = manageInventory;
            this.ManageFinancials = manageFinancials;
        }

        public void InsertIntoEmployeeRoleTable()
        {
            string insertStatement = string.Format("INSERT INTO EmployeeRole (RoleName, ManageCustomer, ManageClass, ManageEmployee," +
                " ManageInventory, ManageFinancials) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", this.RoleName, this.ManageCustomer,
                this.ManageClass, this.ManageEmployee, this.ManageInventory, this.ManageFinancials);

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
