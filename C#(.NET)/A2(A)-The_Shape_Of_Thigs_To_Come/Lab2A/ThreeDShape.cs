using Lab2;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The purpose of this document is to create an abstract class that all 3D shapes have
/// to create an inheritance and have a proper hierarchy system
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: ThreeDShape.cs

namespace Lab2A
{
    /// <summary>
    /// Is to create a ThreeDShape class and inherit from Shape
    /// </summary>
    public abstract class ThreeDShape : Shape
    {
        /// <summary>
        /// CalculateArea method is to calculate the surface area of a 3D shape
        /// </summary>
        /// <returns> Calculated Surface Area of the 3D shape used from the child class </returns>
        public override double CalculateArea()
        {
            return CalculateArea();
        }

        /// <summary>
        /// CalculateVolumne method is to calculate the volume of a 3D shape
        /// </summary>
        /// <returns> Calculated Volume of the 3D shape used from the child class </returns>
        public override double CalculateVolume()
        {
            return CalculateVolume();
        }
    }
}