using System;
using System.Collections.Generic;
using System.IO;

/// I, Braeden Lyman, 000370695 certify that this material is my original work.  
/// No other person's work has been used without due acknowledgement.
/// 
/// *** This document is altered per the assignment instructions. We are to take the employee 
/// sort application from Lab Assignment 1 (either your own, or using Nicholas Corkigian's version of Lab 1)
/// and to edit this class, eliminating Get()/Set() methods by using properties instead and using 
/// the build in sort method for the List collection as well as behaving and looking identical to 
/// Lab Assignment 1 ***
/// 
/// The purpose of this program reads the employee.txt data file and stores the 
/// information in an array of Employee objects. The user is then presented with 
/// a menu that allows them to select which of five fields to sort the resultant 
/// table by: Employee name, ID, rate, hours, or gross pay. The program ends when 
/// the user selects the exit option from the menu.
/// 
///  ** This document is **
/// Created by: Nicholas Corkigian
/// 
/// Altered by: Braeden Lyman 
/// Student Number: 000370695
/// Altered Date: Nov 15, 2023
/// File Name: Lab4a.cs

/// <summary>
/// This is the main tester class that the program starts at
/// </summary>
class Lab4a
{
    /// <summary>
    /// The main method reads the data file, populates the Employee array and provides a menu of sort options.
    /// </summary>
    /// <param name="args">Command line arguments are not used in this program</param>
    static void Main(string[] args)
    {
        int count;                                                      // Keep track of how many employees are instantiated
        bool loop = true;                                               // A loop control variable
        string input;                                                   // The user's menu option pick as a string
        int choice;                                                     // The user's menu option pick as an integer
        List<Employee> employeeList = new List<Employee>();             // The list of Employee objects
       
        // Read the data file to build the Employee list and find out how many there are
        Read(out employeeList, out count);

        // Keep the menu loop running so the user can sort several times
        while (loop)
        {
            // Display the menu and retrieve the user's choice
            input = Menu();

            // Based on the user's entry, sort using the appropriate option
            if (Int32.TryParse(input, out choice))
            {
                switch (choice)
                {
                    // Sort by employee name - ascending
                    case 1:
                        employeeList.Sort((emp1, emp2) => string.Compare(emp1.GetName(), emp2.GetName()));
                        break;

                    // Sort by employee ID number - ascending
                    case 2:
                        employeeList.Sort((emp1, emp2) => emp1.GetNumber().CompareTo(emp2.GetNumber()));
                        break;

                    // Sort by hourly rate - descending
                    case 3:
                        employeeList.Sort((emp1, emp2) => emp2.GetRate().CompareTo(emp1.GetRate()));
                        break;

                    // Sort by weekly hours - descending
                    case 4:
                        employeeList.Sort((emp1, emp2) => emp2.GetHours().CompareTo(emp1.GetHours()));
                        break;

                    // Sort by gross pay - descending
                    case 5:
                        employeeList.Sort((emp1, emp2) => emp2.GetGross().CompareTo(emp1.GetGross()));
                        break;

                    // Exit the program
                    case 6:
                        loop = false;
                        break;

                    // Trap invalid selections to try again
                    default:
                        Console.WriteLine("\n*** Invalid Choice - Try Again ***\n");
                        break;
                }

                // Display the table when a valid choice is made, otherwise display an error
                if (choice >= 0 && choice <= 5)
                    DisplayTable(employeeList);
            }
            else
                Console.WriteLine("\n*** Invalid Choice - Try Again ***\n");
        }
    }

    /// <summary>
    /// This method displays the entire table, including column headers
    /// </summary>
    /// <param name="employees">The list of employees</param>
    /// <param name="count">How many employees are in use</param>
    private static void DisplayTable(List<Employee> employees)
    {
        Console.Clear();
        Console.WriteLine("Employee              Number    Rate  Hours  Gross Pay           Braes's Company");
        Console.WriteLine("====================  ======  ======  =====  =========           ---------------");

        // Display each employee in the array
        foreach (Employee employee in employees)
        {
            Console.WriteLine(employee);
        }
            Console.WriteLine();
    }

    /// <summary>
    /// This method displays the menu options to the user and returns their selection
    /// </summary>
    /// <returns>The user's menu selection</returns>
    private static string Menu()
    {
        Console.WriteLine("1. Sort by Employee Name");
        Console.WriteLine("2. Sort by Employee Number");
        Console.WriteLine("3. Sort by Employee Pay Rate");
        Console.WriteLine("4. Sort by Employee Hours");
        Console.WriteLine("5. Sort by Employee Gross Pay");
        Console.WriteLine("\n6. Exit");
        Console.Write("\nEnter choice: ");

        return Console.ReadLine();
    }

    /// <summary>
    /// This method reads the data file and stores all of the employee information in an array of Employees
    /// </summary>
    /// <param name="employees">The list of employees</param>
    /// <param name="count">How many employees are in use</param>
    private static void Read(out List<Employee> employees, out int count)
    {
        count = 0;                                    // The current number of employees
        string input;                                 // One line of data read from the file
        employees = new List<Employee>();             // The Employee list

        try
        {
            // Open the file for reading purposes
            FileStream file = new FileStream("employees.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            // As long as there is data in the file, keep processing 
            // Each employee record is comma separated, so explode each piece into an array,
            // create a new employee object and increment the count
            while ((input = reader.ReadLine()) != null)
            {
                string[] exploded = input.Split(',');
                employees.Add(new Employee(exploded[0], int.Parse(exploded[1]), decimal.Parse(exploded[2]), double.Parse(exploded[3])));
                count++;
            }

            reader.Close();                             // Always good form to close the file
        }

        // Just in case the file can't be found - graceful exit
        catch (IOException)
        {
            Console.WriteLine("*** File is empty - Program Aborting ***\n");
            Environment.Exit(1);
        }
    }
}