using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The purpose of this document is to create a Book object and display anything that has
/// to do with the Book object, such as: Author and Summary along with its inheritated (super)
/// class Media.cs which also includes title and year.
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Book.cs
/// Date: Oct 26th, 2023

namespace Lab3A
{
    /// <summary>
    /// Book class creates an object Book and
    /// displays information related to the Book
    /// class. Book also inherits Media as well 
    /// as IEncryptable.
    /// </summary>
    class Book : Media, IEncryptable
    {
        // Author of the book
        public string Author { get; set; }

        // Summary of the book
        public string Summary { get; set; }

        /// <summary>
        /// Book constructor displays the title and year from the Media.cs super class along
        /// with author and summary.
        /// </summary>
        /// <param name="title">title of the book</param>
        /// <param name="year">year the book was published</param>
        /// <param name="author">author of the book</param>
        /// <param name="summary">summary of the book</param>
        public Book(string title, int year, string author, string summary) : base(title, year)
        {
            this.Author = author;
            this.Summary = summary;
        }

        /// <summary>
        /// Book constructor displays the title and year from the Media.cs super class along
        /// with the author. This is an overloaded constructor that only displays the title 
        /// year and author when the user chooses option 1 from the menu.
        /// </summary>
        /// <param name="title">title of the book</param>
        /// <param name="year">year the book was published</param>
        /// <param name="author">author of the book</param>
        public Book(string title, int year, string author) : base(title, year)
        {
           Author = author;
        }

        /// <summary>
        /// ToString method is to display the Book.cs class in a nicely
        /// formated string for displaying to the console.
        /// </summary>
        /// <returns>string that contains title, year and author</returns>
        public override string ToString()
        {
            return $"Book{":", 2} {Title, -60} | {Year} | {Author}" ;
        }

        /// <summary>
        /// Encrypt method is to use the Rot13 algorythem to encrypt the Summary
        /// of the book object.
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
                    encryptArray[i] = (char) (((letter - 'A' + 13) % 26) + 'A'); // rot13 algorythem for letter
                    
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
        /// of the book object by calling the Encrypt method
        /// </summary>
        /// <returns>Encrypt method</returns>
        public string Decrypt()
        {
           return Encrypt();
        }
    }
}