using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

/* Needs its own userName generation components so that userNames aren't based off of the customer table.
 * Needs its own constructor because of the overriden methods. Cannot inherit from GymUser class because it needs
 * it's own separate constructor for it's own methods? Ask professor...
 */

namespace CapstoneDatabasePopulation
{
    class Employee
    {
        public int EmployeeId { get; set; } // autoincremented in database via inserts of new records
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetUserNameBase()
        {
            return char.ToLower(FirstName[0]) + LastName.ToLower();
        }

        public string GetUserNameFinal()
        {
            return GetUserNameBase() + CountUserNameBase(GetUserNameBase()).ToString() + ".fit";
        }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string PhoneBegin { get; set; }
        public string PhoneMiddle { get; set; }
        public string PhoneEnd { get; set; }

        public string GetPhoneNumberWhole()
        {
            return string.Format($"({PhoneBegin}) {PhoneMiddle}-{PhoneEnd}");
        }

        public string EmailCompany { get; set; }
        public string EmailDomain { get; set; }

        public string GetEmail()
        {
            return GetUserNameFinal() + "@" + EmailCompany + "." + EmailDomain;
        }

        public string GetPassword()
        {
            return GetUserNameFinal();
        }

        public DateTime GetHireDate()
        {
            DateTime hireDate = new DateTime(CapstoneUtilities.random.Next(1995, DateTime.Now.Year + 1), 
                CapstoneUtilities.random.Next(1, 13), CapstoneUtilities.random.Next(1, 29));

            if (hireDate > DateTime.Now)
                return new DateTime(hireDate.Year - 1, hireDate.Month, hireDate.Day);
            else
                return hireDate;
        }

        public int RoleId { get; set; }

        public Employee(int role)
        {
            this.FirstName = CapstoneUtilities.FindRandomValue(CapstoneUtilities.firstNames);
            this.LastName = CapstoneUtilities.FindRandomValue(CapstoneUtilities.lastNames);
            this.StreetAddress = CapstoneUtilities.random.Next(100, 10000).ToString() + " "
                + CapstoneUtilities.FindRandomValue(CapstoneUtilities.streetNames) + " " + 
                CapstoneUtilities.FindRandomValue(CapstoneUtilities.streetTypes);
            this.City = CapstoneUtilities.FindRandomValue(CapstoneUtilities.cities);
            this.State = CapstoneUtilities.FindRandomValue(CapstoneUtilities.states);
            this.Zipcode = CapstoneUtilities.FindRandomValue(CapstoneUtilities.zipcodes);
            this.PhoneBegin = CapstoneUtilities.random.Next(100, 1000).ToString();
            this.PhoneMiddle = CapstoneUtilities.random.Next(100, 1000).ToString();
            this.PhoneEnd = CapstoneUtilities.random.Next(1000, 10000).ToString();
            this.EmailCompany = CapstoneUtilities.FindRandomValue(CapstoneUtilities.emailCompanies);
            this.EmailDomain = CapstoneUtilities.FindRandomValue(CapstoneUtilities.emailEndings);
            this.RoleId = role;
        }

        public int CountUserNameBase(string userNameBase)
        {
            string queryStatement = string.Format($"SELECT COUNT(*) FROM Employee WHERE UserNameBase = '{userNameBase}'");
            CapstoneUtilities.command = new SqlCommand(queryStatement, CapstoneUtilities.connection);
            return (int)CapstoneUtilities.command.ExecuteScalar() + 1;
        }

        public void InsertIntoEmployeeTable()
        {
            string insertStatement = string.Format("INSERT INTO Employee (FirstName, LastName, UserNameBase, UserName,"
                + " StreetAddress, City, USState, Zip, PhoneBegin, PhoneMiddle, PhoneEnd, PhoneNo, Email, UserPass, DateJoined, RoleId) VALUES ('{0}', " +
                "'{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', {15})", this.FirstName, 
                this.LastName, this.GetUserNameBase(), this.GetUserNameFinal(), this.StreetAddress, this.City, this.State, this.Zipcode, 
                this.PhoneBegin, this.PhoneMiddle, this.PhoneEnd, this.GetPhoneNumberWhole(), this.GetEmail(), this.GetPassword(), this.GetHireDate(), this.RoleId);

            new SqlCommand(insertStatement, CapstoneUtilities.connection).ExecuteNonQuery();
        }
    }
}
