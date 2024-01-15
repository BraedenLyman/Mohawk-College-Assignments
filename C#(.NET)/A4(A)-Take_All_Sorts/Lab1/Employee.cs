using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

/// I, Braeden Lyman, 000370695 certify that this material is my original work.  
/// No other person's work has been used without due acknowledgement.
/// 
/// *** This document is altered per the assignment instructions. We are to take the employee 
/// class from Lab Assignment 1 (either your own, or using Nicholas Corkigian's version of Lab 1)
/// and to edit this class, eliminating Get()/Set() methods by using properties instead and using 
/// the build in sort method for the List collection as well as behaving and looking identical to 
/// Lab Assignment 1 ***
/// 
/// The purpose of this document is to create an employee class that describes the 
/// employee. The employee has a Name, employee ID, an hourly rate, the amount of hours
/// worked, and their gross pay.
/// 
///  ** This document is **
/// Created by: Nicholas Corkigian
/// 
/// Altered by: Braeden Lyman 
/// Student Number: 000370695
/// Altered Date: Nov 08, 2023
/// File Name: Employee.cs

/// <summary>
/// This class describes the employee
/// </summary>
public class Employee
{
    private string Name { get; }         // The employee name
    private int Number { get; }          // The employee ID
    private decimal Rate { get; }        // The hourly rate
    private double Hours { get; }        // The weekly hours
    private decimal Gross { get; }       // The gross pay

    /// <summary>
    /// Default constructor for Employee - used for creating Employee array
    /// </summary>
    public Employee()
    {
    }

    /// <summary>
    /// Four-argument constructor for Employee
    /// </summary>
    /// <param name="name">Employee name</param>
    /// <param name="number">Employee number</param>
    /// <param name="rate">Hourly rate of pay</param>
    /// <param name="hours">Hours worked in a week</param>
    public Employee(string name, int number, decimal rate, double hours)
    {
        this.Name = name;
        this.Number = number;
        this.Rate = rate;
        this.Hours = hours;
        this.Gross = GetGross();
    }

    /// <summary>
    /// Gross pay get method
    /// </summary>
    /// <returns>Gross pay for the week</returns>
    public decimal GetGross() => (Hours < 40) ? (decimal)Hours * Rate : (40.0m * Rate) + (((decimal)Hours - 40.0m) * Rate * 1.5m);

    /// <summary>
    /// Employee display method - in the future, we'll override the ToString method of Object
    /// </summary>
    public override String ToString() => $"{Name,-20}  {Number:D5}  {Rate,6:C}  {Hours:#0.00}  {GetGross(),9:C}";

    /// <summary>
    /// Hours get method
    /// </summary>
    /// <returns>Hours worked this week</returns>
    public double GetHours() => Hours;

    /// <summary>
    /// Name get method
    /// </summary>
    /// <returns>Employee name</returns>
    public string GetName() => Name;

    /// <summary>
    /// Number get method
    /// </summary>
    /// <returns>Employee number</returns>
    public int GetNumber() => Number;

    /// <summary>
    /// Rate get method
    /// </summary>
    /// <returns>Hourly rate of pay</returns>
    public decimal GetRate() => Rate;
}