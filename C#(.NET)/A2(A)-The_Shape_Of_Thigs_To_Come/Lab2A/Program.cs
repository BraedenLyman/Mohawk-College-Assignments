using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Lab2;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The purpose of this document is to ask the user for an input. Based on users input,
/// the program will prompt user for more commands based on which shape they choose (their 
/// input). There is a part where if the user selects the letter "L" the program will display
/// the list of shapes the user made by choosing numbers.
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Program.cs

namespace Lab2A
{
    class Program
    {
        /// <summary>
        /// This is the main program that displays the interface with a title, 
        /// option menu and displays the results to the user.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            

            List<Lab2.Shape> shapes = new List<Lab2.Shape>();

            string option;
            // while-loop for showing the menu and perform a task based on input
            while ((option = OptionMenu()) != "x")
            { 

                switch (option)
                {
                    // User chooses Rectangle
                    case "a":
                        TwoDShape rectangle = new Rectangle();
                        rectangle.SetData();
                        shapes.Add(rectangle);
                        TwoDShape.GetCount();
                        Console.Clear();
                        break;

                    // User chooses Square
                    case "b":
                        TwoDShape square = new Square(); 
                        square.SetData();   
                        shapes.Add(square);
                        TwoDShape.GetCount();
                        Console.Clear();
                        break;

                    // User chooses Box
                    case "c":
                        ThreeDShape box = new Box();
                        box.SetData();
                        shapes.Add(box);
                        ThreeDShape.GetCount();
                        Console.Clear();
                        break;

                    // User chooses Cube
                    case "d":
                        ThreeDShape cube = new Cube();
                        cube.SetData();
                        shapes.Add(cube);
                        ThreeDShape.GetCount();
                        Console.Clear();
                        break;
                    
                    // User chooses Ellipse
                    case "e":
                        TwoDShape ellipse = new Ellipse();
                        ellipse.SetData();
                        shapes.Add(ellipse);
                        TwoDShape.GetCount();
                        Console.Clear();
                        break;

                    // User chooses Circle
                    case "f":
                        TwoDShape circle = new Circle();
                        circle.SetData();
                        shapes.Add(circle);
                        TwoDShape.GetCount();
                        Console.Clear();
                        break;

                    // User chooses Cylinder
                    case "g":
                        ThreeDShape cyclinder = new Cylinder();
                        cyclinder.SetData();
                        shapes.Add(cyclinder);
                        ThreeDShape.GetCount();
                        Console.Clear();
                        break;

                    // User chooses Sphere
                    case "h":
                        ThreeDShape sphere = new Sphere();
                        sphere.SetData();
                        shapes.Add(sphere);
                        ThreeDShape.GetCount();
                        Console.Clear();
                        break;

                    // User chooses Triangle
                    case "i":
                        TwoDShape triangle = new Triangle();
                        triangle.SetData();
                        shapes.Add(triangle);
                        TwoDShape.GetCount();
                        Console.Clear();
                        break;

                    // User chooses Tetrahedron
                    case "j":
                        ThreeDShape tetrahedron = new Tetrahedron();
                        tetrahedron.SetData();
                        shapes.Add(tetrahedron);
                        ThreeDShape.GetCount();
                        Console.Clear();
                        break;

                    // User chooses to display the list and program exits
                    case "0":
                        Console.Clear();
                        // for-loop stores the list of shapes
                        Console.WriteLine(ItemsList());
                        foreach (var shape in shapes)
                        {
                            Console.WriteLine(shape.ToString());
                        }
                        Environment.Exit(0);
                        break; 
                }
            }
        }

        /// <summary>
        ///  MainTitle method is to display the title of the project
        /// </summary>
        /// <returns> A string displaying the title </returns>
        private static string MainTitle()
        {
            return ("     Braeden's Geometry Lab \n" +
                "    ------------------------");
        }

        private static String ItemsList()
        {
            return ("Shape            Area          Volume        Deatils \n") +
                    "============     =========     =========     =============================================";
        }

        /// <summary>
        /// OptionMenu method is to display a menu of options for the 
        /// user to choose from
        /// </summary>
        /// <returns> 
        /// A string displaying the menu as well as the users choise
        /// - prompting for further action based on choice
        /// Also displays the number of shapes that have been created in the list
        /// </returns>
        private static String OptionMenu()
        {
            Console.WriteLine(MainTitle());
            // Printing out options to the user
            Console.WriteLine("\n     Make a selection below:");
            Console.WriteLine("     -----------------------");
            Console.WriteLine("|A| Rectangle         |B| Square");
            Console.WriteLine("|C| Box               |D| Cube");
            Console.WriteLine("|E| Ellipse           |F| Circle");
            Console.WriteLine("|G| Cylinder          |H| Sphere");
            Console.WriteLine("|I| Triangle          |J| Tetrahedron");
            Console.WriteLine();
            Console.WriteLine("|0| List All Shapes & Exit Program");
            Console.WriteLine("-----------------------------------");

            // Letter choices the user can choose from 
            string[] choice = { "a", "b", "c", "d", "e", "f","g", "h", "i", "j", "0" };

            // while-loop for users choice, making sure they choose a letter from the choice string array
            while (true)
            {

                Console.WriteLine("Enter your choice: " + "     (Shapes in List: " + Shape.GetCount() + ")");  // GetCount() displays the amount of shpaes created in the list
                string input = Console.ReadLine().ToLower(); // converting all inputs to lowercase
                if (choice.Contains(input))
                { 
                    return input;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid Input. Please enter a letter between A and  L");
                }
            }
        }
    }
}