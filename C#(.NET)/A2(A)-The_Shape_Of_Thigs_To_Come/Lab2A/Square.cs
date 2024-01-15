using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The Purpose of this document is to create a Square shape as a 2D Shape
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Square.cs

namespace Lab2A
{
    /// <summary>
    /// Is to create a square shape and inherit the properties of a TwoDShape
    /// </summary>
    public class Square : TwoDShape
    {
        // Length of the Square
        public double Length { get; set; }

        /// <summary>
        /// Square Constructor tells what type of shape it is.
        /// </summary>
        public Square()
        {
            Type = "Square";
        }

        /// <summary>
        /// CalculateArea method is to calculate the surface area of the square
        /// </summary>
        /// <returns> Calculated Area </returns>
        public override double CalculateArea()
        {
            return Length * Length;
        }

        /// <summary>
        /// SetData method is to set the data of the shape by asking 
        /// users to enter the length. If user does not
        /// give a valid number, the program defaults to 5
        /// </summary>
        public override void SetData()
        {
            // Getting users input for the length
            Console.Write("Enter length: ");
            if (double.TryParse(Console.ReadLine(), out double length))
            {
                Length = length;
            }
            else
            {
                Console.WriteLine("Invalid input for length. Defaulting to 5.");
                Length = 5;
            }
        }

        /// <summary>
        ///  ToString method is for displaying the results in a neatly 
        ///  organized way
        /// </summary>
        /// <returns> A organized string of the square shape </returns>
        public override string ToString()
        {
            return $"{Type} {CalculateArea(),19:F2} {Length,19} - Length";
        }
    }
}