using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace CapstoneDatabasePopulation
{
    class CapstoneUtilities
    {
        public static string[] firstNames = { "Timothy", "Takafumi", "Jason", "Daniel", "Frog", "Amanda", "Bilan", "Adam",
                "Bob", "Cathy", "David", "Erin", "Frank", "Grant", "Henry", "Iris", "Jacob", "Karen", "Larry",
                "Michelle" },
            lastNames = { "Abercrombie", "McCarthy", "Casterly", "Davidson", "Endres", "Franklinton", "Graves",
                "Hellcat", "Insipia", "Jacobs", "Killjoy", "Marion", "Naruto", "Oppenheimer", "Quihote", "Tower", "Spencer",
                "Fenton", "Uzawa", "Packard" },
            streetNames = { "Attica", "Beverly", "Carlson", "Devon", "Einhart", "Fortuitous", "Gantt", "Hilltop", "Jackson",
                "Kilbourne", "Kildaire", "Clybourne", "Harper", "Greenview", "Bermuda Bay", "Winwood", "Rushwood", "Guardian", "Bismark",
                "Udemy" },
            streetTypes = { "Lane", "Road", "Court", "Avenue", "Boulevard", "Street" },
            cities = { "Columbus", "Westerville", "Grandview", "Dublin", "Grove City", "Canal Winchester", "Polaris", "Hiliard",
                "Worthington", "Galloway", "New Albany", "Gahanna", "Reynoldsburg" },
            states = { "OH", "MI", "KY", "IN", "PA" },
            zipcodes = { "43235", "43017", "43081", "43015", "43082" },
            emailCompanies = { "gmail", "hotmail", "outlook", "yahoo", "student.cscc", "cscc" },
            emailEndings = { "com", "net", "edu", "org" };

        public static SqlConnection connection;
        public static SqlCommand command;

        public static void ConnectToDatabase()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnStr"].ConnectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Connection successfull...\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Closing connection...");
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }

        public static Random random = new Random();

        public static string FindRandomValue(string[] array)
        {
            return array[random.Next(0, array.Length)];
        }
    }
}
