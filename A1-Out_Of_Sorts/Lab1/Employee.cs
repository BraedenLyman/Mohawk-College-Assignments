using System;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// Name: Braeden
/// Student Number: 000370695
/// File: Employee.cs
///
/// Purpose: The purpose of this file is to create an Employee class for the main 
/// Program.cs to create an array of Employee objects that reads the data that's 
/// on the Employees.csv file.

namespace Lab1
{
    /// <summary>
    ///  Employee class creates an employee object that stores
    ///  name, ID number, pay rate, hours, and gross pay.
    /// </summary>
    class Employee
    {
        // Name of the Employee
        private String name;

        //Employee ID number
        private int number;

        //Employee pay rate in dollars
        private decimal rate;

        //Employee hours worked
        private double hours;

        //Employees gross pay
        private decimal gross;

        /// <summary>
        /// Employee constructor is called when a new Employee object is created
        /// It initializes the properties of the employee object with the values 
        /// passed as parameters.
        /// </summary>
        /// <param name="name">A string representing the name of the employee</param>
        /// <param name="number">An integer representing the employee's ID number</param>
        /// <param name="rate"> A decimal representing the employee's pay rate in dollars</param>
        /// <param name="hours">A double representing the number of hours worked by the employee</param>
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
        }

        /// <summary>
        /// GetGross function calculates the gross pay of the employee
        /// based on their pay rate and hours worked, taking overtime 
        /// pay into account as well.
        /// </summary>
        /// <returns>The gross amount an employee is paid for</returns>
        public decimal GetGross() {
            decimal grossPay;
            decimal regPay; // Regular Pay
            decimal leftOverOT; // Over Time hours
            decimal overTime; // Over Time hours * pay rate

            if (this.hours > 40)
            {
                regPay = this.rate * 40; // Calculate reg pay up to 40 hours
                leftOverOT = (decimal)this.hours - 40; // Calculate left over overtime hours (after 40 hours) to be paid for
                overTime = this.rate * (decimal)leftOverOT * (decimal)1.5; // Calculate overtime hours paid for in dollars
                grossPay = regPay + overTime; // Calculate reg pay + overtime pay to get final gross amount in dollars
            } else
            {
                grossPay = this.rate * (decimal)hours; // Calculate reg pay for hours <= 40 hours
            }
            return grossPay;
        }

        /// <summary>
        /// GetHours function gets the hours of the employee
        /// </summary>
        /// <returns>Hours the employee worked</returns>
        public double GetHours() { return hours; }

        /// <summary>
        /// GetName function gets the name of the employee
        /// </summary>
        /// <returns>Name of the employee</returns>
        public String GetName() { return name; }

        /// <summary>
        /// GetNumber function gets the employee's ID number
        /// </summary>
        /// <returns>Employee's ID number</returns>
        public int GetNumber() { return number; }

        /// <summary>
        /// GetRate function gets the pay rate of the employee
        /// </summary>
        /// <returns>Pay rate the employee is paid at</returns>
        public decimal GetRate() { return rate; }

        /// <summary>
        /// SetHours function sets the hours an employee has worked for
        /// </summary>
        /// <param name="hours">Hours the employee worked</param>
        /// <returns>Hours the employee worked</returns>
        public double SetHours(double hours) {  return hours; }

        /// <summary>
        /// SetName function sets the name of the employee
        /// </summary>
        /// <param name="name">Name of the employee</param>
        /// <returns>Name of the employee </returns>
        public String SetName(String name) {  return name; }

        /// <summary>
        /// SetNumber function is used to set the employee's ID number
        /// </summary>
        /// <param name="number">Employee's ID number</param>
        /// <returns>Employee's ID number</returns>
        public int SetNumber(int number) { return number; }

        /// <summary>
        /// ToString function is to display the data in a string formated
        /// to look proper
        /// </summary>
        /// <returns>A string formated to look proper</returns>
        public override String ToString() 
        {
            return String.Format($" {name, -16}| {number, -7}| ${Math.Round(rate,2),-6}| {hours.ToString("0.00"), -6}| ${Math.Round(GetGross(),2)}");
        }
    }
}
