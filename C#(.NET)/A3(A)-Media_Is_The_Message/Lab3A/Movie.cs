using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The purpose of this document is to create a Movie object and display anything that has
/// to do with the Movie object, such as: Director and Summary along with its inheritated (super)
/// class Media.cs which also includes title and year.
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Movie.cs
/// Date: Oct 26th, 2023

namespace Lab3A
{
    /// <summary>
    /// Movie class creates an object Movie and
    /// displays information related to the Movie
    /// class. Movie also inherits Media as well 
    /// as IEncryptable.
    /// </summary>
    class Movie : Media, IEncryptable
    { 
        // Director of the movie
        public string Director { get; set; }

        // Movie Summary
        public string Summary { get; set; }

        /// <summary>
        /// Movie constructor displays the title and year from the Media.cs super class along
        /// with director and summary.
        /// </summary>
        /// <param name="title">title of the movie</param>
        /// <param name="year">year the movie was made</param>
        /// <param name="director">director of the movie</param>
        /// <param name="summary">summary of the movie</param>
        public Movie(string title, int year, string director, string summary) : base(title, year)
        {
            Director = director;
            Summary = summary;
        }

        /// <summary>
        /// Movie constructor displays the title and year from the Media.cs super class along
        /// with the director. This is an overloaded constructor that only displays the title 
        /// year and director when the user chooses option 2 from the menu.
        /// </summary>
        /// <param name="title">title of the movie</param>
        /// <param name="year">year the movie was made</param>
        /// <param name="director">director of the movie</param>
        public Movie(string title, int year, string director) : base(title, year)
        {
            Director = director;
        }

        /// <summary>
        /// ToString method is to display the Movie.cs class in a nicely
        /// formated string for displaying to the console.
        /// </summary>
        /// <returns>string that contains title, year and director</returns>
        public override string ToString()
        {
            return $"Movie{":", 1} {Title, -60} | {Year} | {Director}";
        }

        /// <summary>
        /// Encrypt method is to use the Rot13 algorythem to encrypt the Summary
        /// of the movie object.
        /// </summary>
        /// <returns>An encrypted Summary</returns>
        public string Encrypt()
        {
            char[] encryptArray = Summary.ToCharArray(); // converting Summary to a character array

            // for-loop going through the array to apply a rot13 algorythem
            for (int i = 0; i < encryptArray.Length; i++)
            {
                char letter = encryptArray[i]; // index i in the array is assignned to character letter

                // if letter is a letter
                if (char.IsLetter(letter))
                {
                    encryptArray[i] = (char)(((letter - 'A' + 13) % 26) + 'A'); // rot13 algorythem for letter

                    // if letter is a lowercase letter
                    if (char.IsLower(letter))
                    {
                        encryptArray[i] = (char)(((letter - 'a' + 13) % 26) + 'a'); // rot13 algorythem for lowercase letter
                    }
                }
            }
            Summary = new string(encryptArray); // storing the encrypted rot13 array to Summary as a new string
            return Summary;
        }

        /// <summary>
        /// Decrypt method is to use the rot13 algorythem to decrypt the Summary
        /// of the movie object by calling the Encrypt method
        /// </summary>
        /// <returns>Encrypt method</returns>
        public string Decrypt()
        {
            return Encrypt();
        }
    }
}