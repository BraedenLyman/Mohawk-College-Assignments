using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The Purpose of this document is to create a Ellipse shape as a 2D Shape
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Ellipse.cs

namespace Lab2A
{
    /// <summary>
    /// Is to create a ellipse shape and inherit the properties of a TwoDShape
    /// </summary>
    public class Ellipse : TwoDShape
    {
        // Semi-major of the ellipse
        public double Semi_major { get; set; }
        
        // Semi-minor of the ellipse
        public double Semi_minor { get; set; }

        /// <summary>
        /// Ellipse Constructor tells what type of shape it is.
        /// </summary>
        public Ellipse()
        {
            Type = "Ellipse";
        }

        /// <summary>
        /// CalculateArea method is to calculate the area of the ellipse
        /// </summary>
        /// <returns> Calculated Area </returns>
        public override double CalculateArea()
        {
            return Shape.PI * Semi_major * Semi_minor;
        }

        /// <summary>
        /// CalculateVolumne method is to calculate the volume of the elipse
        /// </summary>
        /// <returns> Calculated Volume </returns>
        public override void SetData()
        {
            // Getting users input for the semi-major
            Console.Write("Enter Semi-Major: ");
            if (double.TryParse(Console.ReadLine(), out double semi_major))
            {
               Semi_major = semi_major;
            }
            else
            {
                Console.WriteLine("Invalid input for Semi-Major. Defaulting to 5.");
                Semi_major = 5;
            }

            // Getting users input for the semi-minor
            Console.Write("Enter Semi-Minor: ");
            if (double.TryParse(Console.ReadLine(), out double semi_minor))
            {
                Semi_minor = semi_minor;
            }
            else
            {
                Console.WriteLine("Invalid input for Semi-Minor. Defaulting to 5.");
                Semi_minor = 5;
            }
        }

        /// <summary>
        ///  ToString method is for displaying the results in a neatly 
        ///  organized way
        /// </summary>
        /// <returns> A organized string of the ellipse shape </returns>
        public override string ToString()
        {
            return $"{Type} {CalculateArea(),18:F2} {Semi_minor,19} - Semi-Minor Axis, {Semi_major} - Semi-Major Axis";
        }
    }
}