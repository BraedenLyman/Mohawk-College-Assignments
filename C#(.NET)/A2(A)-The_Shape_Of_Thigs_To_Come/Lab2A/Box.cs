using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The Purpose of this document is to create a Box shape as a 3D Shape
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Box.cs

namespace Lab2A
{
    /// <summary>
    /// Is to create a box shape and inherit the properties of a ThreeDShape
    /// </summary>
    public class Box: ThreeDShape
    {
        // Length of the box
        public double Length { get; set; }
        
        // Width of the box
        public double Width { get; set; }
        
        // Height of the box
        public double Height { get; set; }

        /// <summary>
        ///  Box Constructor tells what type of shape it is.
        /// </summary>
        public Box()
        {
            Type = "Box";
        }

        /// <summary>
        /// CalculateArea method is to calculate the surface area of the box
        /// </summary>
        /// <returns> Calculated Surface Area </returns>
        public override double CalculateArea()
        {
            return (2 * (Length * Width)) + (2 * (Length * Height)) + (2 * (Width * Height));
        }

        /// <summary>
        /// CalculateVolumne method is to calculate the volume of the box
        /// </summary>
        /// <returns> Calculated Volume </returns>
        public override double CalculateVolume()
        {
            return Length * Width * Height;
        }

        /// <summary>
        /// SetData method is to set the data of the shape by asking 
        /// users to enter length, width and height. If user does not
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
            if (double.TryParse(Console.ReadLine(), out double width))
            {
                Width = width;
            }
            else
            {
                Console.WriteLine("Invalid input for width. Defaulting to 5.");
                Width = 5;
            }

            // Getting users input for the height
            Console.Write("Enter height: ");
            if (double.TryParse(Console.ReadLine(), out double height))
            {
                Height = height;
            }
            else
            {
                Console.WriteLine("Invalid input for height. Defaulting to 5.");
                Height = 5;
            }
        }

        /// <summary>
        ///  ToString method is for displaying the results in a neatly 
        ///  organized way
        /// </summary>
        /// <returns> A organized string of the box shape </returns>
        public override string ToString()
        {
            return $"{Type} {CalculateArea(),22:F2} {CalculateVolume(),13:F2} {Length,5} - Length, {Width} - Width, {Height} - Height";
        }
    }
}
