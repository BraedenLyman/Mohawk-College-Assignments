using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The Purpose of this document is to create a Traingle shape as a 2D Shape
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Triangle.cs

namespace Lab2A
{
    /// <summary>
    /// Is to create a traingle shape and inherit the properties of a TwoDShape
    /// </summary>
    public class Triangle : TwoDShape
    {
        // Base of the triangle
        public double Tbase { get; set; }
        
        // Height of the triangle
        public double Height {  get; set; }

        /// <summary>
        ///  Traingle Constructor tells what type of shape it is.
        /// </summary>
        public Triangle()
        {
            Type = "Triangle";
        }

        /// <summary>
        /// CalculateArea method is to calculate the area of the traingle
        /// </summary>
        /// <returns> Calculated Area </returns>
        public override double CalculateArea()
        {
            return (Tbase * Height) / 2;
        }

        /// <summary>
        /// SetData method is to set the data of the shape by asking 
        /// users to enter base and height. If user does not
        /// give a valid number, the program defaults to 5
        /// </summary>
        public override void SetData()
        {
            // getting users input for the base
            Console.Write("Enter Base: ");
            if (double.TryParse(Console.ReadLine(), out double tbase))
            {
                Tbase = tbase;
            }
            else
            {
                Console.WriteLine("Invalid input for Base. Defaulting to 5.");
                tbase = 5;
            }
            
            // Getting users input for the height
            Console.Write("Enter Height: ");
            if (double.TryParse(Console.ReadLine(), out double height))
            {
                Height = height;
            }
            else
            {
                Console.WriteLine("Invalid input for Height. Defaulting to 5.");
                tbase = 5;
            }
        }

        /// <summary>
        ///  ToString method is for displaying the results in a neatly 
        ///  organized way
        /// </summary>
        /// <returns> A organized string of the triangle shape </returns>
        public override string ToString()
        {
            return $"{Type} {CalculateArea(),17:F2} {Tbase, 19} - Base, {Height} - Height";
        }
    }
}