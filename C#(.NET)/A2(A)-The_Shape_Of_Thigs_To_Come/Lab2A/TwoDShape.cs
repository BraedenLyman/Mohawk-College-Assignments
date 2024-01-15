using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The purpose of this document is to create an abstract class that all 2D shapes have
/// to create an inheritance and have a proper hierarchy system
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: TwoDShape.cs

namespace Lab2A
{
    /// <summary>
    /// Is to create a TwoDShape class and inherit from Shape
    /// </summary>
    public abstract class TwoDShape : Shape
    {
        /// <summary>
        /// CalculateArea method is to calculate the area of a 2D shape
        /// </summary>
        /// <returns> Calculated Area of the 2D shape used from the child class </returns>
        public override double CalculateArea()
        {
            return CalculateArea();
        }

        /// <summary>
        /// CalculateVolumne method is to calculate the volume of a 2D shape
        /// </summary>
        /// <returns> 0 as 2D shapes do not have a volume </returns>
        public override double CalculateVolume()
        {
            return 0; // 2D shapes don't have a volumne
        }
    }
}