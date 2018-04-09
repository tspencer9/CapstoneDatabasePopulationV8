using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

/* Need to figure out how and where to keep the application accessing the current DateTime for validation of memberships.
 * Membership class and table have a comparison method to see if the end date of the membership is greater than the DateTime object representing
 * the current DateTime. But how to keep that DateTime object current?
 * 
 * will also need to keep track of the quantity of items in the Product table which will be dependent upon quantity sold and how much are
 * inserted into through inventory management.
 * 
 * version 7 of population tables script
 */

namespace CapstoneDatabasePopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t*** Capstone Database Population Script ***\n");
            Console.WriteLine("This program will populate the Capstone database with sample data.\n");

            CapstoneUtilities.ConnectToDatabase();

            try
            {
                PopulateGymUserTable();
                PopulateEmployeeRoleTable();
                PopulateEmployeeTable();
                PopulateSalaryTable();
                PopulateMembershipTypeTable();
                PopulateMembershipPriceTable();
                PopulateMembershipTable();
                PopulateProductTable();
                PopulateProductPriceTable();
                PopulatePurchaseTable();
                PopulateProductQuantityTable();
                PopulateFinanceCategoryTable();
                PopulateRevenueTable();
                PopulateExpenseTable();

                CapstoneUtilities.connection.Close();

                Console.WriteLine("\nConnection to database closed.\n");
                Console.WriteLine("Population of tables successfull...");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Closing connection...");
                CapstoneUtilities.connection.Close();
                Console.WriteLine("Connection closed.");
            }

            Console.ReadLine();
        }

        static void PopulateGymUserTable()
        {
            for (int i = 0; i < 1000; i++)
            {
                new GymUser().InsertIntoGymUserTable();
            }

            Console.WriteLine("GymUser table population successful.");
        }

        static void PopulateEmployeeRoleTable()
        {
            new EmployeeRole("Administrator", false, false, true, true, true).InsertIntoEmployeeRoleTable();
            new EmployeeRole("Sales Associate", true, true, false, false, false).InsertIntoEmployeeRoleTable();

            Console.WriteLine("EmployeeRole table population successful.");
        }

        static void PopulateEmployeeTable()
        {
            for (int i = 0; i < 5; i++)
            {
                new Employee(1).InsertIntoEmployeeTable();
            }

            for (int i = 0; i < 20; i++)
            {
                new Employee(2).InsertIntoEmployeeTable();
            }

            Console.WriteLine("Employee table population successful.");
        }

        static void PopulateMembershipTypeTable()
        {
            new MembershipType("Bronze", false, false).InsertIntoMembershipTypeTable();
            new MembershipType("Silver", true, false).InsertIntoMembershipTypeTable();
            new MembershipType("Gold", true, true).InsertIntoMembershipTypeTable();

            Console.WriteLine("MembershipType table population successful.");
        }

        static void PopulateMembershipPriceTable()
        {
            new MembershipPrice(40.00, 1).InsertIntoMembershipPriceTable();
            new MembershipPrice(70.00, 2).InsertIntoMembershipPriceTable();
            new MembershipPrice(100.00, 3).InsertIntoMembershipPriceTable();

            Console.WriteLine("MembershipPrice table population successful.");
        }

        static void PopulateMembershipTable()
        {
            for (int i = 0; i < 1000; i++)
                new Membership(i + 1).InsertIntoMembershipTable();

            Console.WriteLine("Membership table population successful.");
        }

        static void PopulateSalaryTable()
        {
            new Salary(1, 100000.00).InsertIntoSalaryTable();

            for (int i = 2; i <= 5; i++)
                new Salary(i, 60000.00).InsertIntoSalaryTable();
            for (int i = 6; i <= 15; i++)
                new Salary(i, 40000.00).InsertIntoSalaryTable();
            for (int i = 16; i <= 25; i++)
                new Salary(i, 20000.00).InsertIntoSalaryTable();
            Console.WriteLine("Salary table population successful.");
        }

        static void PopulateProductTable()
        {
            new Product("Socks", "Apparel", "Athletic socks for working out - sport fabric for wicking", 100).InsertIntoProductTable();
            new Product("Shorts", "Apparel", 
                "Athletic shorts for working out - cotton shorts for elasticity", 100).InsertIntoProductTable();
            new Product("Athletic Shorts", "Apparel",
                "Athletic shorts for working out - sport fabric for wicking and elasticity", 100).InsertIntoProductTable();
            new Product("Sweatpants", "Apparel",
                "Sweatpants for working out - cotton for elasticity", 100).InsertIntoProductTable();
            new Product("Athletic Pants", "Apparel",
                "Athletic pants for working out - sport fabric for wicking and elasticity", 100).InsertIntoProductTable();
            new Product("Logo T-shirt", "Apparel",
                "PWF logo t-shirt", 100).InsertIntoProductTable();
            new Product("Logo Sport Shirt", "Apparel",
                "Athletic Logo sport shirt for working out - sport fabric for wicking and elasticity", 100).InsertIntoProductTable();
            new Product("Logo Long Sleeve T-shirt", "Apparel",
                "Logo long sleeve t-shirt", 100).InsertIntoProductTable();
            new Product("Logo Long Sleeve Athletic Shirt", "Apparel",
                "Athletic long sleeve shirt for working out - sport fabric for wicking and elasticity", 100).InsertIntoProductTable();
            new Product("Tank Top Logo Shirt", "Apparel",
                "Logo tank top shirt - cotton", 100).InsertIntoProductTable();
            new Product("Athletic Logo Tank Top Shirt", "Apparel",
                "Athletic logo tank top for working out - sport fabric for wicking and elasticity", 100).InsertIntoProductTable();
            new Product("Logo Sweatshirt - Hooded", "Apparel",
                "Hooded logo sweatshirt - cotton", 100).InsertIntoProductTable();
            new Product("Logo Plain Sweatshirt", "Apparel",
                "Non-hooded logo sweatshirt - cotton", 100).InsertIntoProductTable();
            new Product("Logo Jacket", "Apparel",
                "Warm winter jacket with logo for keeping warm in and out of the gym", 100).InsertIntoProductTable();
            new Product("Logo Cap", "Apparel",
                "Logo cap", 100).InsertIntoProductTable();
            new Product("Logo Beanie", "Apparel",
                "Logo beanie for keeping warm in and out of the gym", 100).InsertIntoProductTable();
            new Product("Energy Bar", "Nutrition",
                "Energy bar with carbs and protien to stay active", 100).InsertIntoProductTable();
            new Product("Protien Power", "Nutrition",
                "Protien poweder to build muscle drink mix", 100).InsertIntoProductTable();
            new Product("Sports Drink", "Nutrition",
                "Electrolyte sports drink with sugars to stay active and hydrated", 100).InsertIntoProductTable();
            new Product("Beef Jerky", "Nutrition",
                "Beef jerky package for protein to build muscle and stay active", 100).InsertIntoProductTable();

            Console.WriteLine("Product table population successful.");
        }

        public static void PopulateProductPriceTable()
        {
            new ProductPrice(5, 1).InsertIntoProductPriceTable();
            new ProductPrice(10, 2).InsertIntoProductPriceTable();
            new ProductPrice(20, 3).InsertIntoProductPriceTable();
            new ProductPrice(15, 4).InsertIntoProductPriceTable();
            new ProductPrice(30, 5).InsertIntoProductPriceTable();
            new ProductPrice(10, 6).InsertIntoProductPriceTable();
            new ProductPrice(20, 7).InsertIntoProductPriceTable();
            new ProductPrice(15, 8).InsertIntoProductPriceTable();
            new ProductPrice(30, 9).InsertIntoProductPriceTable();
            new ProductPrice(7.5, 10).InsertIntoProductPriceTable();
            new ProductPrice(10, 11).InsertIntoProductPriceTable();
            new ProductPrice(20, 12).InsertIntoProductPriceTable();
            new ProductPrice(15, 13).InsertIntoProductPriceTable();
            new ProductPrice(60, 14).InsertIntoProductPriceTable();
            new ProductPrice(10, 15).InsertIntoProductPriceTable();
            new ProductPrice(10, 16).InsertIntoProductPriceTable();
            new ProductPrice(1, 17).InsertIntoProductPriceTable();
            new ProductPrice(15, 18).InsertIntoProductPriceTable();
            new ProductPrice(1, 19).InsertIntoProductPriceTable();
            new ProductPrice(2, 20).InsertIntoProductPriceTable();

            Console.WriteLine("ProductPrice table population successful.");
        }

        static void PopulatePurchaseTable()
        {
            for (int i = 0; i < 3000; i++)
                new Purchase().InsertIntoPurchaseTable();

            Console.WriteLine("Purchase table population successful.");
        }

        static void PopulateProductQuantityTable()
        {
            for (int i = 1; i <= 3000; i++)
            {
                if (CapstoneUtilities.random.Next(0, 5) < 1)
                {
                    for (int j = 1; j <= 20; j++) // loop through each product; there are 20 total
                    {
                        if (CapstoneUtilities.random.Next(0, 5) < 1)
                        {
                            new ProductQuantity(i, j, CapstoneUtilities.random.Next(1, 6)).InsertIntoProductQuantityTable();
                        }
                    }
                }
                else
                    new ProductQuantity(i,
                        CapstoneUtilities.random.Next(1, 21), 
                        CapstoneUtilities.random.Next(1, 6)).InsertIntoProductQuantityTable();
            }

            Console.WriteLine("ProductQuantity table population successful.");
        }

        static void PopulateFinanceCategoryTable()
        {
            new FinanceCategory("Electricity").InsertIntoFinanceCategoryTable();
            new FinanceCategory("Insurance").InsertIntoFinanceCategoryTable();
            new FinanceCategory("Maintenance").InsertIntoFinanceCategoryTable();
            new FinanceCategory("Security").InsertIntoFinanceCategoryTable();
            new FinanceCategory("Water").InsertIntoFinanceCategoryTable();
            new FinanceCategory("Rent").InsertIntoFinanceCategoryTable();

            Console.WriteLine("FinanceCategory table population successful.");
        }

        static void PopulateRevenueTable()
        {
            for (int i = 1; i <= DateTime.Now.Month; i++)
            {
                new Revenue(4000, "Rent from Jazzersize for Dublin", new DateTime(2018, i, 15)).InsertIntoRevenueTable();
                new Revenue(4500, "Rent from Personal Training Studio for Grove City", new DateTime(2018, i, 15)).InsertIntoRevenueTable();
                new Revenue(1750, "Rent from Crew Winter Rowing Facility for Grove City", new DateTime(2018, i, 15)).InsertIntoRevenueTable();
            }

            Console.WriteLine("Revenue table population successful (only rent is manually entered).");
        }

        static void PopulateExpenseTable() // some bills are for each location, and some bills are for both locations
        {
            for (int i = 1; i <= DateTime.Now.Month; i++)
            {
                new Expense(1000, "Electricity for Dublin", new DateTime(2018, i, 15), 1).InsertIntoExpenseTable();
                new Expense(1000, "Electricity for Grove City", new DateTime(2018, i, 15), 1).InsertIntoExpenseTable();
                new Expense(2500, "Insurance for both locations", new DateTime(2018, i, 15), 2).InsertIntoExpenseTable();
                new Expense(1500, "Replacement parts for lifting machines", new DateTime(2018, i, 15), 3).InsertIntoExpenseTable();
                new Expense(60, "Security for both locations", new DateTime(2018, i, 15), 4).InsertIntoExpenseTable();
                new Expense(1000, "Water for Dublin", new DateTime(2018, i, 15), 5).InsertIntoExpenseTable();
                new Expense(1000, "Water for Grove City", new DateTime(2018, i, 15), 5).InsertIntoExpenseTable();
            }

            Console.WriteLine("Expense table population successful.");
        }
    }
}

// breakpoint here for newer version
// version 7
