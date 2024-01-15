using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
///  The purpose of this document is to create a Cube shape as a 3D shape
///  
/// Name: Braeden
/// Student Number: 000370695
/// File: Cube.cs

namespace Lab2A
{
    /// <summary>
    ///  Is to create a cube shape and inherit the properties of a ThreeDShape
    /// </summary>
    public class Cube : ThreeDShape
    {
        // Length of the cube
        public double Length { get; set; }
        
        // Width of the cube
        public double Width { get; set; }
        
        // Height of the cube
        public double Height { get; set; }

        /// <summary>
        ///  Cube Constructor tells what type of shape it is.
        /// </summary>
        public Cube()
        {
            Type = "Cube";
        }

        /// <summary>
        /// CalculateArea method is to calculate the surface area of the cube
        /// </summary>
        /// <returns> Calculated Surface Area </returns>
        public override double CalculateArea()
        {
            return (2 * (Length * Length)) + (2 * (Length * Length)) + (2 * (Length * Length));
        }

        /// <summary>
        /// CalculateVolumne method is to calculate the volume of the cube
        /// </summary>
        /// <returns> Calculated Volume </returns>
        public override double CalculateVolume()
        {
            return Length * Length * Length;
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
        /// <returns> A organized string of the cube shape </returns>
        public override string ToString()
        {
            return $"{Type} {CalculateArea(),21:F2} {CalculateVolume(), 13:F2} {Length,5} - Length";
        }
    }
}