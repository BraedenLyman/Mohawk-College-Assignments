using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The Purpose of this document is to create a Tetrahedron shape as a 3D Shape
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Tetrahedron.cs

namespace Lab2A
{
    /// <summary>
    /// Is to create a tetrahedron shape and inherit the properties of a ThreeDShape
    /// </summary>
    public class Tetrahedron : ThreeDShape
    {
        // Length of the tetrahedron
        public double Length { get; set; }

        /// <summary>
        /// Tetrahedron Constructor tells what type of shape it is.
        /// </summary>
        public Tetrahedron()
        {
            Type = "Tetrahedron";
        }

        /// <summary>
        /// CalculateArea method is to calculate the surface area of the tetrahedron
        /// </summary>
        /// <returns> Calculated Surface Area </returns>
        public override double CalculateArea()
        {
            return Math.Sqrt(3) * (Length * Length);
        }

        /// <summary>
        /// CalculateVolumne method is to calculate the volume of the tetrahedron
        /// </summary>
        /// <returns> Calculated Volume </returns>
        public override double CalculateVolume()
        {
            return (Length * Length * Length) / (6 * (Math.Sqrt(2)));
        }

        /// <summary>
        /// SetData method is to set the data of the shape by asking 
        /// users to enter the lenght. If user does not
        /// give a valid number, the program defaults to 5
        /// </summary>
        public override void SetData()
        {
            // Getting users input for the length
            Console.Write("Enter Length: ");
            if (double.TryParse(Console.ReadLine(), out double length))
            {
                Length = length;
            }
            else
            {
                Console.WriteLine("Invalid input for Radius. Defaulting to 5.");
                Length = 5;
            }
        }

        /// <summary>
        ///  ToString method is for displaying the results in a neatly 
        ///  organized way
        /// </summary>
        /// <returns> A organized string of the tetrahedron shape </returns>
        public override string ToString()
        {
            return $"{Type} {CalculateArea(),14:F2} {CalculateVolume(),13:F2} {Length,5} - Length";
        }
    }
}