using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The purpose of this document is to ask the user for an input from the menu choice. 
/// Based on users input, the program will run that switch case and display data from 
/// the Data.txt file. If the user chooses to enter 6, it will close the program.
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Program.cs
/// Date: Oct 26th, 2023

namespace Lab3A
{
    class Program
    {
        /// <summary>
        /// Main method is to display a menu to the user and have the user input a
        /// choice from 1 to 6. Depending on what the users chooses the program will
        /// run that swithc case and display either data from the Data.txt file or 
        /// the application will close.
        /// </summary>
        /// <param name="args">runs the main program</param>
        static void Main(string[] args)
        {
            Media[] media = ReadData(@"..\..\Data.txt"); //retrieves the data from Data.txt and stores it in media as an array
            
            string choice; // users choice 

            // while loop that displays the menu and gets user to make a choice
            while ((choice = Menu()) != "6")
            {
                // switch case displays case 1 through 6 based on users choice
                switch (choice)
                {
                    // Lists all the books
                    case "1":
                        Console.Clear();
                        Console.WriteLine(MediaDataBook());
                        // foreach-loop for displaying all book data
                        foreach (Media mediaType in media)
                        {
                            if (mediaType is Book book)
                            {
                                Console.WriteLine(book.ToString());
                            }
                        }
                        break;

                    // Lists all the movies
                    case "2":
                        Console.Clear();
                        Console.WriteLine(MediaDataMovie());
                        // foreach-loop for displaying all movie data
                        foreach (Media mediaType in media)
                        {
                            if (mediaType is Movie movie)
                            {
                                Console.WriteLine(movie.ToString());
                            }
                        }
                        break;

                    // Lists all the songs
                    case "3":
                        Console.Clear();
                        Console.WriteLine(MediaDataSong());
                        // foreach-loop for displaying all song data
                        foreach (Media mediaType in media)
                        {
                            if (mediaType is Song song)
                            {
                                Console.WriteLine(song.ToString());
                            }
                        }
                        break;

                    // Lists all media
                    case "4":
                        Console.Clear();
                        Console.WriteLine(MediaDataAll());
                        // for-loop for displaying all media data
                        foreach (Media mediaType in media)
                        {
                            if (mediaType is Media allMedia)
                            {
                                Console.WriteLine(allMedia.ToString());
                            }
                        }
                        break;

                    // Searches all media by titlle
                    case "5":
                        Console.Clear();
                        Console.Write("Enter a search string: ");
                        string search = Console.ReadLine(); // string input from user
                        Console.WriteLine(MediaDataAll());
                        // foreach loop to see if user input is in each media type
                        foreach (Media mediaType in media)
                        {
                            if (mediaType is Book book)
                            {
                                bool searching = book.Search(search); // searches for book objects that contain users input
                                if (searching)
                                {
                                    Console.WriteLine(book.ToString() + "\n\n Summary: \n" + book.Decrypt() + MediaDataLine()); // displays the books that contain user input as well as a decoded book summary
                                }
                            } else if (mediaType is Movie movie)
                            {
                                bool searcing = movie.Search(search); // searches for movie objects that contain users input
                                if (searcing)
                                {
                                    Console.WriteLine(movie.ToString() + "\n\n Summary: \n" + movie.Decrypt() + MediaDataLine()); // displays the movies that contain user input as well as a decoded movie summary
                                }
                            } else if (mediaType is Song song)
                            {
                                bool searching = song.Search(search); // searches for song objects that contain users input
                                if (searching)
                                {
                                    Console.WriteLine(song.ToString() + MediaDataLine());
                                }
                            }
                        }
                        break;

                    // Closes the application
                    case "6":
                        Environment.Exit(0);
                        break;

                    // default case 
                    default:
                        Console.Clear();
                        Console.WriteLine("Option Error: Please choose an option between 1 and 6.");
                        break;
                }
            }
        }

        /// <summary>
        /// MediaDataAll method displays a title for when all the 
        /// data types are displaed 
        /// </summary>
        /// <returns>string title for when all data types are displayed</returns>
        public static string MediaDataAll()
        {
            return "Media  Title                                                        Year     Additional Info\n" +
                   "=====  ===============================                              =======  ===========================================";               
        }

        /// <summary>
        /// MediaDataBook method displays a title for when the
        /// data type is a book
        /// </summary>
        /// <returns>string title for when the data type book is displayed</returns>
        public static string MediaDataBook()
        {
            return "Media  Title                                                        Year     Author\n" +
                   "=====  ====================================                         =======  ===================";
        }

        /// <summary>
        /// MediaDataMovie method displays a title for when the
        /// data type is a movie
        /// </summary>
        /// <returns>string title for when the data type movie is displayed</returns>
        public static string MediaDataMovie()
        {
            return "Media  Title                                                        Year     Director\n" +
                   "=====  ====================================                         =======  ===========================";
        }

        /// <summary>
        /// MediaDataSong method displays a title for when the
        /// data type is a song
        /// </summary>
        /// <returns>string title for when the data type song is displayed</returns>
        public static string MediaDataSong()
        {
            return "Media  Title                                                        Year     Album                        Artist\n" +
                   "=====  ===============================                              =======  =========================    ==============";
        }

        /// <summary>
        /// MediaDataLine method displays a line after each section 
        /// of data when the user chooses to search all media by title 
        /// </summary>
        /// <returns>string line after each section of data</returns>
        public static string MediaDataLine()
        {
            return "\n----------------------------------------------------------------------------";
        }

        /// <summary>
        /// Menu method is to dispaly a menu screen to the 
        /// user to make a choice between 1 and 6.
        /// </summary>
        /// <returns> Users input choice </returns>
        public static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("1. List All Books");
            Console.WriteLine("2. List All Movies");
            Console.WriteLine("3. List All Songs");
            Console.WriteLine("4. List All Media");
            Console.WriteLine("5. Search All Media by Title");
            Console.WriteLine(); // To add a space
            Console.WriteLine("6. Exit Program");
            Console.WriteLine(); // To add a spce
            Console.Write("Enter Choice: ");
            string userInput = Console.ReadLine(); // gets user input
            return userInput.ToString();
        }

        /// <summary>
        /// ReadData method is to read the data from the Data.txt file
        /// and display it into an array that is shown to the user based 
        /// on their input choice.
        /// </summary>
        /// <param name="filename"> is the Data.txt file </param>
        /// <returns> mediaList array of data from the Data.txt file </returns>
        public static Media[] ReadData(String filename)
        {
            string[] readLines = File.ReadAllLines(filename); // reads all the lines in the file
            Media[] mediaList = new Media[readLines.Length]; // gets the length of file

            // for-loop for displaying the data from the Data.txt
            for (int i = 0; i < readLines.Length; i++)
            {
                string[] explode = readLines[i].Split('|'); // splits the data by the "|" symbol

                if (explode.Length >= 4)
                {
                    string type = explode[0]; // declairs string type (media type) at index 0
                    string title = explode[1]; // declairs string title (title of media type) at index 1
                    int year = int.Parse(explode[2]); // declairs int year (year of meida) at index 2 by parsing it to a string
                    string addInfo = explode[3]; // declairs string addInfo (additional information for media type) at index 3
                    string summary = ""; // declairs string summary to an empty string unless summary is present 

                    // to check if there is a summary on the next line
                    if (i + 1 < readLines.Length)
                    {
                        summary = readLines[i + 1];
                        i++;
                    }
                    // switch case to determine how to display the string data based on what media type it is
                    switch (type)
                    {
                        // media type: Book
                        case "BOOK":
                            string author = addInfo; // initializes author to addInfo
                            mediaList[i] = new Book(title, year, author, summary);  // creates new Book object and stores it into mediaList array i
                            break;

                        // media type: Movie
                        case "MOVIE":
                            string director = addInfo; // initalizes director to addInfo
                            mediaList[i] = new Movie(title, year, director, summary); // creates new Movie object and stores it into mediaList array i
                            break;

                        // media type: Song
                        case "SONG": 
                            string artist = addInfo; // initalizes album to addInfo
                            string album = explode[4]; // intializes artist to index 4
                            mediaList[i] = new Song(title, year, artist, album); // creates new Song object and stores it into mediaList array i
                            break;
                    }
                }
            }
                return mediaList;
        }
    }
}