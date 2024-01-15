using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The Purpose of this document is to create a Rectangle shape as a 2D Shape
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Rectangle.cs

namespace Lab2A
{
    /// <summary>
    /// Is to create a rectangle shape and inherit the properties of a TwoDShape
    /// </summary>
    public class Rectangle : TwoDShape
    {
        // Length of the rectangle
        public double Length { get; set; }
       
        // Width of the rectangle
        public double Width { get; set; }

        /// <summary>
        /// Rectangle Constructor tells what type of shape it is.
        /// </summary>
        public Rectangle()
        {
            Type = "Rectangle";
        }

        /// <summary>
        /// CalculateArea method is to calculate the area of the rectangle
        /// </summary>
        /// <returns> Calculated Area </returns>
        public override double CalculateArea()
        {
            return Length * Width;
        }

        /// <summary>
        /// SetData method is to set the data of the shape by asking 
        /// users to enter length and width. If user does not
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

            // Getting users input for the width
            Console.Write("Enter width: ");
            if (double.TryParse(Console.ReadLine(),out double width))
            {
                Width = width;
            }
            else
            {
                Console.WriteLine("Invalid input for width. Defaulting to 5.");
                Width = 5;
            }
        }

        /// <summary>
        ///  ToString method is for displaying the results in a neatly 
        ///  organized way
        /// </summary>
        /// <returns> A organized string of the rectangle shape </returns>
        public override string ToString()
        {
            return $"{Type} {CalculateArea(), 16:F2} {Length, 19} - Length, {Width} - Width";
        }
    }
}