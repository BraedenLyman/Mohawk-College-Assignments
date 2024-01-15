using System;
using System.IO;
using System.Linq.Expressions;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// Name: Braeden
/// Student Number: 000370695
/// File: Program.cs
/// 
/// Purpose: The purpose of this file is to show a menu for the user to make
/// a selection between 6 options.
/// Each option from 1-5 performs a QuickSort depending on the users choice. 
/// 
/// Referecnes for QuickSort Algorithm:
/// https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-9.php
/// https://www.alphacodingskills.com/cs/pages/cs-program-for-quick-sort.php

namespace Lab1
{
    class Program
    {   /// <summary>
    ///  Main Method to exectute the program
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            Employee[] employees = Read(@"..\..\Employees.csv"); // employee array read from Employees.csv

            Console.WriteLine("   BRAEDEN'S SORTING ALGORITHM");
            Console.WriteLine("=================================");

            String option;
            while ((option = OptionMenu()) != "6")
            {
                Console.WriteLine();

                // Switch Case for user option
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(MainTitle());
                        Console.WriteLine(Title());
                        QuickSort(employees, CompareByName);
                        foreach (Employee emp in employees)
                            Console.WriteLine(emp);
                        Console.WriteLine(BottomBorder());
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine(MainTitle());
                        Console.WriteLine(Title());
                        QuickSort(employees, CompareByNumber);
                        foreach (Employee emp in employees)
                            Console.WriteLine(emp);
                        Console.WriteLine(BottomBorder());
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine(MainTitle());
                        Console.WriteLine(Title());
                        QuickSort(employees, CompareByRate);
                        foreach (Employee emp in employees)
                            Console.WriteLine(emp);
                        Console.WriteLine(BottomBorder());
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine(MainTitle());
                        Console.WriteLine(Title());
                        QuickSort(employees, CompareByHours);
                        foreach (Employee emp in employees)
                            Console.WriteLine(emp);
                        Console.WriteLine(BottomBorder());
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine(MainTitle());
                        Console.WriteLine(Title());
                        QuickSort(employees, CompareByGrossPay);
                        foreach (Employee emp in employees)
                            Console.WriteLine(emp);
                        Console.WriteLine(BottomBorder());
                        break;

                    case "6":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        /// <summary>
        /// MainTitle displays the main title of the application.
        /// </summary>
        /// <returns>A string that represents the main title of the application</returns>
        private static String MainTitle()
        {
            return "            BRAEDEN'S SORTING ALGORITHM\n" +
                     " =====================================================";
        }

        /// <summary>
        /// BottomBorder displays a border on the bottom of the data for organization.
        /// </summary>
        /// <returns>A string for the bottom border of the data</returns>
        private static String BottomBorder()
        {
            return " =====================================================";
        }

        /// <summary>
        /// OptionMenu displays options for the user to choose from.
        /// </summary>
        /// <returns>User input selection</returns>
        private static String OptionMenu()
        {
            Console.WriteLine("\n      Make A Selection Below:");
            Console.WriteLine(" --------------------------------");
            Console.WriteLine("| |1| Sort By Employee Name      |");
            Console.WriteLine("| |2| Sort By Employee Number    |");
            Console.WriteLine("| |3| Sort By Employee Pay Rate  |");
            Console.WriteLine("| |4| Sort By Employee Hours     |");
            Console.WriteLine("| |5| Sort By Employee Gross Pay |");
            Console.WriteLine(" --------------------------------");
            Console.WriteLine("| |6| Exit the Application       |");
            Console.WriteLine(" --------------------------------");

            int userInput;

            //while loop for exception handling
            while (true)
            {
                Console.Write("\nEnter Option (Select an nteger from 1 - 6): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out userInput) && userInput >= 1 && userInput <= 6){
                    {
                        return userInput.ToString(); // Converts the valid user input back to a string
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Please enter a valid integer between 1 and 6");
                }
            }
        }

        /// <summary>
        /// Title displays titles for what the data is for organization.
        /// </summary>
        /// <returns>A string that represents titles for the data</returns>
        private static String Title()
        {
            return " Employee          Number     Pay    Hours  Gross Pay\n" +
                   " =====================================================";
        }

        /// <summary>
        ///  Read function is used to read the employee data from the CSV file.
        ///  It used a StreamReader to read the file, parse the CSV data, and 
        ///  store it in an array of Employee objects.
        /// </summary>
        /// <param name="filename">The employee data from the CSV</param>
        /// <returns>
        /// If any exception occurs during file reading, it returns null.
        /// If no exceptions occur and the file reads, it displays
        /// he data in the CSV file.
        /// </returns>
        private static Employee[] Read(String filename)
        {
            try
            {
                StreamReader reader = new StreamReader(filename);
                Employee[] employees = new Employee[13];
                int count = 0;

                while (!reader.EndOfStream)
                {
                    String line = reader.ReadLine();
                    String[] exploded = line.Split(','); //removes the "," in the data as well as a seperating data point
                    Employee emp = new Employee(exploded[0], int.Parse(exploded[1]), decimal.Parse(exploded[2]), double.Parse(exploded[3]));  //Splits the data into 4 columns
                    employees[count] = emp;
                    count++;
                }
                return employees;
            }
            catch (Exception) { }
            return null;
        }

        /// <summary>
        /// CompareByName method is used to sort the data by the employee names.
        /// </summary>
        /// <param name="emp1">employee one</param>
        /// <param name="emp2">employee two</param>
        /// <returns>A ascending sorted array by the employees firs name</returns>
        static int CompareByName(Employee emp1, Employee emp2)
        {
            return emp1.GetName().CompareTo(emp2.GetName());
        }

        /// <summary>
        /// CompareByNumber method is used to sort the data by the employee ID number.
        /// </summary>
        /// <param name="emp1">employee one</param>
        /// <param name="emp2">employee two</param>
        /// <returns>A ascedning sorted array by the employees ID number</returns>
        static int CompareByNumber(Employee emp1, Employee emp2)
        {
            return emp1.GetNumber().CompareTo(emp2.GetNumber()); 
        }

        /// <summary>
        /// CompareByRate method is used to sort the data by the employee Pay Rate.
        /// </summary>
        /// <param name="emp1">employee one</param>
        /// <param name="emp2">employee two</param>
        /// <returns>A descending sorted array by the employees pay rate</returns>
        static int CompareByRate(Employee emp1, Employee emp2)
        {
            return emp2.GetRate().CompareTo(emp1.GetRate());
        }

        /// <summary>
        /// CompareByHours method is used to sort the data by the employee Hours.
        /// </summary>
        /// <param name="emp1">employee one</param>
        /// <param name="emp2">employee two</param>
        /// <returns>A decending sorted array by the employees hours</returns>
        static int CompareByHours(Employee emp1, Employee emp2)
        {
            return emp2.GetHours().CompareTo(emp1.GetHours()); 
        }

        /// <summary>
        /// CompareByGroosPay method is used to sort the data by the employee gross pay.
        /// </summary>
        /// <param name="emp1">employee one</param>
        /// <param name="emp2">employee two</param>
        /// <returns>A decending sorted array by the employees gross pay</returns>
        static int CompareByGrossPay(Employee emp1, Employee emp2)
        {
            return emp2.GetGross().CompareTo(emp1.GetGross());
        }

        /// <summary>
        /// QuickSort function is a wrapper for the QuickSort algoritm.
        /// </summary>
        /// <param name="empArr">employee one</param>
        /// <param name="comparison">employee two</param>
        static void QuickSort(Employee[] empArr, Comparison<Employee> comparison)
        {
            QuickSort(empArr, comparison, 0, empArr.Length - 1);
        }

        /// <summary>
        /// QuickSort function is the core QuickSort function that partitions the array
        /// around a pivot element and recursively sorts the subarrays before and after 
        /// the pivot.
        /// </summary>
        /// <param name="empArr">employee array</param>
        /// <param name="comparison">comparison of how the two employee objects should be ordered</param>
        /// <param name="start">index of where the sorting proccess begins</param>
        /// <param name="end">index of where the sorting proccess ends</param>
        static void QuickSort(Employee[] empArr, Comparison<Employee> comparison, int start, int end)
        {
            if (start < end)
            {
                int pIndex = Partition(empArr, comparison, start, end);

                QuickSort(empArr, comparison, start, pIndex - 1);
                QuickSort(empArr, comparison, pIndex + 1, end);
            }
        }

        /// <summary>
        /// Parition function is used by the QuickSort function to partition the array.
        /// It selects a pivot element and rearranges the array so the elements smaller
        /// than the pivot come before it and the elements larger than the pivot 
        /// come after it.
        /// </summary>
        /// <param name="empArr">employee array</param>
        /// <param name="comparison">comparison of how the two employee objects should be ordered</param>
        /// <param name="start">index of where the sorting proccess begins</param>
        /// <param name="end">index of where the sorting proccess ends</param>
        /// <returns>The index of the pivot element </returns>
        static int Partition(Employee[] empArr, Comparison<Employee> comparison, int start, int end)
        {
            Employee piv = empArr[end]; //Pivot
            int i = start - 1; 

            for (int j = start; j < end; j++)
            {
                if (comparison(empArr[j], piv) < 0)
                {
                    i++;
                    Swap(empArr, i, j);
                }
            }
            Swap(empArr, i + 1, end);
            return i + 1;
        }

        /// <summary>
        /// Swap method is used to rearrange two elements in an array
        /// of Employee objects during the sorting proccess.
        /// </summary>
        /// <param name="empArr">employee array</param>
        /// <param name="i">index of the first element that needs to be swaped</param>
        /// <param name="j">index of the second element that needs to be swapped</param>
        static void Swap(Employee[] empArr, int i, int j)
        {
            Employee temp = empArr[i];
            empArr[i] = empArr[j];
            empArr[j] = temp;
        }
    }
}