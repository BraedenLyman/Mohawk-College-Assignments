using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The purpose of this document is to create a Circle shape as a 2D shape
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Circle.cs

namespace Lab2A
{
    /// <summary>
    /// Is to create a box shape and inherit the properties of a TwoDShape
    /// </summary>
    public class Circle : TwoDShape
    {
        // Radius of the circle
        public double Radius { get; set; }

        /// <summary>
        /// Circle Constructor tells what type of shape it is.
        /// </summary>
        public Circle()
        {
            Type = "Circle";
        }

        /// <summary>
        /// CalculateArea method is to calculate the area of the circle
        /// </summary>
        /// <returns> Calculated Area </returns>
        public override double CalculateArea()
        {
            return Shape.PI * (Radius * Radius);
        }

        /// <summary>
        /// SetData method is to set the data of the shape by asking 
        /// users to enter radius. If user does not give a valid number, 
        /// the program defaults to 5
        /// </summary>
        public override void SetData()
        {
            // Getting users input for the radius
            Console.Write("Enter Radius: ");
            if (double.TryParse(Console.ReadLine(), out double radius))
            {
                Radius = radius;
            }
            else
            {
                Console.WriteLine("Invalid input for Radius. Defaulting to 5.");
                Radius = 5;
            }
        }

        /// <summary>
        /// ToString method is for displaying the results in a neatly 
        ///  organized way
        /// </summary>
        /// <returns>  A organized string of the circle shape </returns>
        public override string ToString()
        {
            return $"{Type} {CalculateArea(),19:F2} {Radius, 19} - Radius";
        }
    }
}