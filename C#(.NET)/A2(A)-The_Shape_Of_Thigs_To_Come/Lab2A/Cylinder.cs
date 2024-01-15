using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The Purpose of this document is to create a Cylinder shape as a 3D Shape
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Cylinder.cs

namespace Lab2A
{
    /// <summary>
    ///  Is to create a cylinder shape and inherit the properties of a ThreeDShape
    /// </summary>
    public class Cylinder : ThreeDShape
    {
        // Radius of the cylinder
        public double Radius { get; set; }
        
        // Height of the cylinder
        public double Height { get; set; }

        /// <summary>
        /// Cylinder Constructor tells what type of shape it is.
        /// </summary>
        public Cylinder()
        {
            Type = "Cylinder";
        }

        /// <summary>
        /// CalculateArea method is to calculate the surface area of the cylinder
        /// </summary>
        /// <returns> Calculated Surface Area </returns>
        public override double CalculateArea()
        {
            return (2 * Shape.PI * (Radius * Radius)) + (2 * Shape.PI * Radius * Height); 
        }

        /// <summary>
        /// CalculateVolumne method is to calculate the volume of the cylinder
        /// </summary>
        /// <returns> Calculated Volume </returns>
        public override double CalculateVolume()
        {
            return (Shape.PI * (Radius * Radius)) * Height;
        }

        /// <summary>
        /// SetData method is to set the data of the shape by asking 
        /// users to enter radius and height. If user does not
        /// give a valid number, the program defaults to 5
        /// </summary>
        public override void SetData()
        {
            // Getting the users input for the radius
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

            // Getting the users input for the height
            Console.Write("Enter Height: ");
            if (double.TryParse(Console.ReadLine(), out double height))
            {
                Height = height;
            }
            else
            {
                Console.WriteLine("Invalid input for Height. Defaulting to 5.");
                Height = 5;
            }
        }

        /// <summary>
        ///  ToString method is for displaying the results in a neatly 
        ///  organized way
        /// </summary>
        /// <returns> A organized string of the cylinder shape </returns>
        public override string ToString()
        {
            return $"{Type} {CalculateArea(),17:F2} {CalculateVolume(),13:F2} {Radius, 5} - Radius, {Height} - Height";
        }
    }
}