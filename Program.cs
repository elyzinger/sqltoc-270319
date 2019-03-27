using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqlite270319
{
    class Employee
    {

 
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64 Age { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        
        public override string ToString()
        {
            return $"id {Id} Name {Name} Age {Age} Address  {Address} Salary {Salary}";
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            using (SQLiteConnection con =
           new SQLiteConnection("Data Source = C:\\Users\\HackerU\\.nuget\\ely.db; Version = 3;"))
            {
                List<Employee> employees = new List<Employee>();
                // open the connection
                con.Open();

                // create a query (suign the connection)
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * From COMPANY ", con))
                {

                    // execut4e the query into the reader
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        // use the reader to read all of the results of the query
                        while (reader.Read() )
                        {
                            //var Id = (Int64)reader["ID"];
                            //var Name = (string)reader["NAME"];
                            //var Age = (Int64)reader["AGE"];
                            //var Address = (string)reader["ADDRESS"];
                            //var Salary = (float)reader["SALARY"];
                            Employee e = new Employee
                            {
                                Id = (Int64)reader["ID"],
                                Name = (string)reader["NAME"],
                                Age = (Int64)reader["AGE"],
                                Address = (string)reader["ADDRESS"],
                                Salary = (double)reader["SALARY"],
                            };
                            employees.Add(e);
                      
                        }
                    }

                }

                Console.WriteLine();
            }
            Console.ReadLine();
        }
        
    }
}
