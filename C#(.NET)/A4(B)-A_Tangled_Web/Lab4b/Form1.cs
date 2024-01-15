using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/// I, Braeden Lyman, 000370695 certify that this material is my original work.  
/// No other person's work has been used without due acknowledgement.
/// 
/// The purpose of this document is to create a form application that proccesses
/// an HTML file and checks to see if the file is balanced or not with an even amount
/// of opening and closing tags using a stack. Depending on what the outcome is, the 
/// labbel will change to its corisponding output. The code is also indented following best 
/// HTML practices.
/// 
/// File: Form1.cs
/// Author: Braeden Lyman
/// Student Number: 000370695
/// Date: Nov 15, 2023

namespace Lab4b
{
    /// <summary>
    /// This is the form application that contains all information to do with the form
    /// </summary>
    public partial class BraedensFileCheckerApp : Form
    {
        private string fileContent;                 // stores the file content
        private string selectedFileName;            // declares the selected file name

        /// <summary>
        /// This is what initalizes the components of the form
        /// </summary>
        public BraedensFileCheckerApp()
        {
            InitializeComponent();
            checkTagsProcess.Enabled = false;       // disables the process check tags button
        }

        /// <summary>
        /// exitFile_Click event method is used to close (exit) the program
        /// </summary>
        /// <param name="sender">triggers the event</param>
        /// <param name="e">event data</param>
        private void exitFile_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// loadFile_Click event method is used to load a file when a user clicks
        /// on the File Load File button. Clicking on the button pops up and Open
        /// File Dialog window where a user can only choose an HTML file. Once the
        /// user has chosen a file, it is then loaded into the form and shows which 
        /// file is loaded in the label. If it was unsuccessful, it will display an
        /// error in the label
        /// </summary>
        /// <param name="sender">triggers the event</param>
        /// <param name="e">event data</param>
        private void loadFile_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "No File Loaded";
            OpenFileDialog ofd = new OpenFileDialog();
            checkTagListBox.Items.Clear();
            ofd.Filter = "HTML Files (*.html, *htm) | *html; *.htm";            // sets the filter to allow only HTML files
            DialogResult result = ofd.ShowDialog();                             // shows the file dialog and captures the result

            // checks for if user clicked OK and stores it as result
            if (result == DialogResult.OK)
            {
                selectedFileName = ofd.FileName;                                // gets the selected file name
                string selectedShortPathFile = Path.GetFileName(ofd.FileName);  // gets the selected HTML file name without the full path
                statusLabel.Text = "Loaded: " + selectedShortPathFile;
                checkTagsProcess.Enabled = true;                                // enables the check tags button now that a file is loaded

                try
                {
                    fileContent = File.ReadAllText(selectedFileName);           // reads file contents
                }
                catch (IOException ex)
                {
                    statusLabel.Text = "Error reading the file: " + ex.Message; // sets status label if error
                }
            }
            else
            {
                statusLabel.Text = "No File Loaded";
            } 
        }

        /// <summary>
        /// checkTagsProcess_Click event method is used to proccess the tags within the 
        /// file the user chose, once the check tags button is clicked. Once the button is 
        /// clicked it then goes through the file and finds every open html tag found and pushes 
        /// it to a stack called htmlStack. From there it peeks and checks to see if there is a 
        /// corisponding closing tag with the open tag. If there is, the opening tag thats on the 
        /// stack is popped off. It goes through ever tag thats on the stack (which would be all 
        /// the open tags) and if the stack is empty, it results in a balanced stack. If not empty, 
        /// it results in an unballanced stack and causes the program to stop running and display a 
        /// message in the label.
        /// </summary>
        /// <param name="sender">triggers the event</param>
        /// <param name="e">event data</param>
        private void checkTagsProcess_Click(object sender, EventArgs e)
        {
            Stack<string> htmlStack = new Stack<string>();                                              // creates a stack of strings
            string[] singleTags = {"<img>", "<br>", "<hr>", "<meta>", "<link>", "<input>", "<col>"};    // common single string tags
            bool success = true;                                                                        // flag to track matching tag status
            string[] lines = fileContent.ToLower().Split('\n');                                         // file contents converted to lowercase and stored as lines to be read splitting by lines
            string selectedShortPathFile = Path.GetFileName(selectedFileName);                          // gets the selected HTML file name without the full path
            int indexLevel = 0;                                                                         // index level for nesting html code

            // gets file contents
            foreach (string line in lines)
            {
                int startindex = 0;                                                                     // initiates the starting index

                // gets the starting and ending index of the "<" and ">" to create a substring for comparing
                while ((startindex = line.IndexOf("<", startindex)) != -1) 
                {
                    int endIndex = line.IndexOf(">", startindex);                                       // gets the endding index
 
                    if (endIndex != -1)
                    {
                        string tags = line.Substring(startindex, endIndex - startindex).Split(' ')[0] + ">"; // creates a substring starting at "<" and ends at ">" removing the attributes from the tag

                        // gets the opening tags and pushes to stack if not a single tag
                        if (tags[1] != '/') 
                        {
                            // check to see if tag is a single tag
                            if (!singleTags.Contains(tags.ToLower()))
                            {
                                htmlStack.Push(tags);
                                checkTagListBox.Items.Add($"{new string(' ', indexLevel)}Found Opening Tag: {tags}");
                                indexLevel ++;                      
                            }
                            else 
                            {
                                checkTagListBox.Items.Add($"{new string(' ', indexLevel)}Found Non-Container Tag: {tags}");
                            }
                        }
                        // gets the closing tags
                        else if (tags[1] == '/')
                        {
                            // checks stack status
                            if (htmlStack.Count > 0)
                            {  
                                string openTag = htmlStack.Peek();                                  // peeks at the stacks top item
                                string closeTag = "<" + tags.Substring(2);                          // gets closing tag minus the '/'

                                // comparing to see if opening tag has a closing tag
                                if (openTag == closeTag) 
                                {
                                    htmlStack.Pop();              
                                    indexLevel--;                   
                                    checkTagListBox.Items.Add($"{new string(' ', indexLevel)}Found Closing Tag: {tags}");
                                }
                                // error - no match - breaks loop
                                else
                                {   
                                    indexLevel-- ;
                                    checkTagListBox.Items.Add($"{new string(' ', indexLevel)}Found Closing Tag: {tags}"); // displays last found tag
                                    success = false;
                                    break;
                                }
                            }
                        }
                        // if no opening tag or closing tag - report error
                        else
                        {
                            checkTagListBox.Items.Add($"Error: Unexpected Closing Tag: {tags}");
                            success = false;
                            break;
                        }
                        startindex = endIndex + 1;                                                  // gets the new starting index point after creating the first substring 
                    }
                }
                // check to see if stack is empty - resulting in success
                if (htmlStack.Count() == 0)
                {
                    success = true;
                    statusLabel.Text = selectedShortPathFile + " has balanced tags";
                }
                // if success flag false - results in failure
                else if (!success)
                {
                    statusLabel.Text = selectedShortPathFile + " does not have balanced tags";
                    break;
                }
                // if anything else - results in error
                else
                {
                    statusLabel.Text = "There is an error reading the file";
                }
            }
        }
    }
}