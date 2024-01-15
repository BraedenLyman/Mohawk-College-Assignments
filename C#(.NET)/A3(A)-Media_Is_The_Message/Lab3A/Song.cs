using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The purpose of this document is to create a Song object and display anything that has
/// to do with the Song object, such as: Album and Artist along with its inheritated (super)
/// class Media.cs which also includes title and year.
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Song.cs
/// Date: Oct 26th, 2023

namespace Lab3A
{
    /// <summary>
    /// Song class creates an object Song and
    /// displays information related to the Song
    /// class. Song also inherits Media.
    /// </summary>
    class Song : Media
    {
        // Album the song is from
        public string Album { get; set; }

        // Song artits
        public string Artist { get; set; }

        /// <summary>
        /// Song constructor displays the title and year from the Media.cs super class along
        /// with album and artist.
        /// </summary>
        /// <param name="title">title of the song</param>
        /// <param name="year">year the song was made</param>
        /// <param name="album">album the song is from</param>
        /// <param name="artist">artist of the song</param>
        public Song(string title, int year, string album, string artist) : base (title, year)
        {
            Album = album;
            Artist = artist;
        }

        /// <summary>
        /// ToString method is to display the Song.cs class in a nicely
        /// formated string for displaying to the console.
        /// </summary>
        /// <returns>string that contains title, year, album and artist</returns>
        public override string ToString()
        {
            return $"Song{":", 2} {Title, -60} | {Year} | {Album, - 27} | {Artist}";
        }
    }
}