using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The Purpose of this document is to create a Sphere shape as a 3D Shape
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Sphere.cs

namespace Lab2A
{
    /// <summary>
    /// Is to create a sphere shape and inherit the properties of a ThreeDShape
    /// </summary>
    public class Sphere : ThreeDShape
    {
        // Radius of the sphere
        public double Radius { get; set; }

        /// <summary>
        /// Sphere Constructor tells what type of shape it is.
        /// </summary>
        public Sphere()
        {
            Type = "Sphere";
        }

        /// <summary>
        /// CalculateArea method is to calculate the surface area of the sphere
        /// </summary>
        /// <returns> Calculated Surface Area </returns>
        public override double CalculateArea()
        {
            return 4 * ThreeDShape.PI * (Radius * Radius);
        }

        /// <summary>
        /// CalculateVolumne method is to calculate the volume of the sphere
        /// </summary>
        /// <returns> Calculated Volume </returns>
        public override double CalculateVolume()
        {
            return (4.0 / 3.0) * ThreeDShape.PI * (Radius * Radius * Radius);
        }

        /// <summary>
        /// SetData method is to set the data of the shape by asking 
        /// users to enter the radius. If user does not
        /// give a valid number, the program defaults to 5
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
        ///  ToString method is for displaying the results in a neatly 
        ///  organized way
        /// </summary>
        /// <returns> A organized string of the sphere shape </returns>
        public override string ToString()
        {
            return $"{Type} {CalculateArea(),19:F2} {CalculateVolume(),13:F2} {Radius, 5} - Radius";
        }
    }
}