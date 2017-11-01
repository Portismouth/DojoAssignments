using System;
using DbConnection;
using System.Collections.Generic;

namespace simpleCRUD
{
    class Program
    {
        // STATIC FUNCTION TO SHOW ALL USERS IN TABLE
        public static void show()
            {
                var allUsers = DbConnector.Query(@"
                SELECT * FROM Users
                ");
                Console.WriteLine("First Name    Last Name    Favorite Number");
                foreach (var user in allUsers)
                {
                Console.WriteLine("{0,9}    {1,9}    {2,9}", user["FirstName"], user["LastName"], user["FavoriteNumber"]);
                }
            }
        static void Main(string[] args)
        {

            //SHOW USERS TABLE ON PAGE LOAD AND INITIALIZE CRUD APP (while loop)
            show();
            string cont = "yes";

            while (cont == "yes")
            {
                // ASK USER WHAT THEY WANT TO DO WITH DATABASE (case sensitive)
                Console.Write("What would you like to do? (Create, Read, Update, or Destroy?): ");
                string option = Console.ReadLine();

                // CREATE FUNCTION
                if( option == "Create")
                {
                    //GRAB ALL COLUMN VARIABLES FIRST
                    Console.Write("First Name: ");
                    string first = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string last = Console.ReadLine();
                    Console.Write("Favorite Number: ");
                    int number = Convert.ToInt32(Console.ReadLine());
                    //CHECK IF SQL QUERY WAS VALID IF NOT RETURN INVALID QUERY
                    try
                    {
                        DbConnector.Execute($"INSERT INTO consoleDB.Users (Users.FirstName, Users.LastName, Users.FavoriteNumber) VALUES ('{first}', '{last}', {number})");
                        Console.WriteLine("-------- Success --------");
                    }
                    catch
                    {
                        Console.WriteLine("--------Invalid Query--------");
                    }
                }
                //SHOW SQL TABLE
                else if( option == "Read" )
                {
                    show();
                }
                //UPDATE FUNCTION
                else if( option == "Update" )
                {
                    //ASK FOR ID AND CHECK IF IT IS VALID FROM DATABASE
                    Console.Write("Enter the ID you want to update: ");
                    try
                    {
                        //GRAB VARIABLES FOR UPDATE FUNCTION IF THEY ARE NOT VALID RETURN INVALID INFO
                        int userID = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            Console.Write("First Name: ");
                            string first = Console.ReadLine();
                            Console.Write("Last Name: ");
                            string last = Console.ReadLine();
                            Console.Write("Favorite Number: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            DbConnector.Execute($"UPDATE consoleDB.Users SET Users.FirstName = '{first}', Users.LastName = '{last}', Users.FavoriteNumber = {number}  WHERE idUsers = {userID};");
                            Console.WriteLine("-------- Success --------");
                        }
                        catch
                        {
                            Console.Write("You did not enter valid information");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("You did not enter a Valid ID");
                    }
                    

                }
                //DESTROY FUNCTION
                else if( option == "Destroy" )
                {
                    //GRAB ID AND AND CHECK IF IT IS VALID
                    Console.Write("Enter the ID you want to destroy: ");
                    try
                    {
                        int userID = Convert.ToInt32(Console.ReadLine());
                        DbConnector.Execute($"DELETE FROM consoleDB.Users WHERE idUsers = {userID};");
                        Console.WriteLine("-------- Success --------");
                    }
                    catch
                    {
                        Console.WriteLine("You did not enter a Valid ID");
                    }
                }
                //IF USER DID NOT TYPE IN CREATE READ UPDATE OR DESTROY
                else
                {
                    Console.WriteLine("You did not input a valid option");
                }

                //CONTINUE RUNNING THE APP?
                Console.Write("Continue (yes/no)? ");
                cont = Console.ReadLine();

                //USER HAS TO INPUT YES OR NO -- Commented out because its not working :/
                // while (cont != "yes" || cont != "no")
                // {
                //     Console.Write("Please enter yes or no: ");
                //     cont = Console.ReadLine();
                // }
            }
            
        }
    }
}
