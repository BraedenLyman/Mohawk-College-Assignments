using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The purpose of this document is to create a hairdresser form application for a user to choose a hairdresser
/// with the service(s) they want. The user has a discount option based on their age and if they are a student,
/// as well as a discount on the number of vistis to the hairdresser salon.
/// 
/// Name: Braeden
/// Student Number: 000370695
/// File: Braes_hair_salon.cs

namespace Lab2B
{
    /// <summary>
    /// Braes_hair_salon is a form application that asks users to choose
    /// a hairdresserr, service(s) type and if a discount applies to them.
    /// User must choose at least one service as well as number of vistis
    /// must be an integer above 0.
    /// </summary>
    public partial class Braes_hair_salon : Form
    {
        // Jane's Rate
        private const decimal jane_rate = 30.00m;

        // Pat's Rate
        private const decimal pat_rate = 45.00m;

        // Ron's Rate
        private const decimal ron_rate = 40.00m;

        // Sue's Rate
        private const decimal sue_rate = 50.00m;

        // Laura's Rate
        private const decimal laura_rate = 55.00m;

        // Cut Price
        private const decimal cut_price = 30.00m;

        // Colour Price
        private const decimal colour_price = 40.00m;

        // Highlights Price
        private const decimal highlights_price = 50.00m;

        // Extensions Price
        private const decimal extension_price = 200.00m;

        /// <summary>
        /// Brae_hair_salon constructor is to initialize the controls and
        /// components of the form as well as sets up the graphical interface
        /// </summary>
        public Braes_hair_salon()
        {
            InitializeComponent();
        }

        /// <summary>
        /// CalculateButton_Click event handler method is to calculate the total 
        /// price after user chooses a hairdresser, their service(s) type and 
        /// if a discount applies to them.
        /// </summary>
        /// <param name="sender"> triggers the click event </param>
        /// <param name="e"> event information </param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            decimal hairdresser_price = 0;

            // What rate to be applied based on which hairdresser radio button is checked
            if (JaneSRadio.Checked) hairdresser_price = jane_rate;
            else if (PatJRadio.Checked) hairdresser_price = pat_rate;
            else if (RonCRadio.Checked) hairdresser_price = ron_rate;
            else if (SuePRadio.Checked) hairdresser_price = sue_rate;
            else if (LauraRRadio.Checked) hairdresser_price = laura_rate;

            decimal service_price = 0;
            
            // What price is to be applied based on which service(s) are checked
            if (CutCheck.Checked) service_price += cut_price;
            if (ColourCheck.Checked) service_price += colour_price;
            if (HighlightsCheck.Checked) service_price += highlights_price;
            if (ExtensionsCheck.Checked) service_price += extension_price;

            decimal total_amount = hairdresser_price + service_price; // Calculating the total amount by adding the hairdresser and sevice(s) together 

            decimal discount = 0;

            // What discount is to be applied based on what type of client the user is
            if (StandardTypeRadio.Checked) discount = 0;
            else if (ChildTypeRadio.Checked) discount = 0.10m;
            else if (StudentRadio.Checked) discount = 0.05m;
            else if (SeniorRadio.Checked) discount = 0.15m;

            int visits;

            // Checking to see if the user selects at least one service
            if (!CutCheck.Checked && !ColourCheck.Checked && !HighlightsCheck.Checked && !ExtensionsCheck.Checked)
            {
                MessageBox.Show("You must select at least one service", "Missing Service(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Checking to see if the user doesnt enter anything or if the user enters characters (letters0 in the number of visits textbox
            if (string.IsNullOrEmpty(NumVisitsTextbox.Text))
            {
                MessageBox.Show("Number of Visits must be an integer greater than 0", "Incorrect Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NumVisitsTextbox.Focus();
                return;
            }

            // Checking to see if the user enters a postivie integer in the number of visits textbox
            if (!int.TryParse(NumVisitsTextbox.Text, out visits) || visits < 0 || !IsWholeNumber(NumVisitsTextbox.Text))
            {
                MessageBox.Show("Invalid number of visits. Enter a valid positive integer", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NumVisitsTextbox.Focus();
                return;
            }
            else
            {
                // If user enters a positive number - the discounts to be applied based on number entered
                if (visits >= 1 && visits <= 3) discount += 0;
                else if (visits >= 4 && visits <= 8) discount += 0.05m;
                else if (visits >= 9 && visits <= 13) discount += 0.10m;
                else if (visits >= 14) discount += 0.15m;
            }

            decimal discount_amount = total_amount - (total_amount * discount); // Toatl amount * the discount(s)
            TotalPriceTextbox.Text = $"{discount_amount:c}";
        }

        /// <summary>
        /// IsWholeNumber method is a helper method for seeing if 
        /// the user enters a positve number in the number of visits
        /// textbox
        /// </summary>
        /// <param name="inputText"> text that user inputs into the number of visits textbox </param>
        /// <returns></returns>
        private bool IsWholeNumber(string inputText)
        {
            return int.TryParse(inputText, out int num) && num >= 0; // If positive int - returns the number without error message pop-up
        }

        /// <summary>
        /// ClearButton_Click event handler method is for clearing 
        /// the form's data
        /// </summary>
        /// <param name="sender"> triggers the click event </param>
        /// <param name="e"> event information </param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            // Clear hairdresser selection
            JaneSRadio.Checked = true;
            JaneSRadio.Focus();
            PatJRadio.Checked = false;
            RonCRadio.Checked = false;
            SuePRadio.Checked = false;
            LauraRRadio.Checked = false;

            // Clear services selection
            CutCheck.Checked = false;
            ColourCheck.Checked = false;
            HighlightsCheck.Checked = false;
            ExtensionsCheck.Checked = false;

            // Clear client type
            StandardTypeRadio.Checked = true;
            ChildTypeRadio.Checked = false;
            StudentRadio.Checked = false;
            SeniorRadio.Checked = false;

            // Clear visits textbox
            NumVisitsTextbox.Text = string.Empty;

            // Clear total price textbox
            TotalPriceTextbox.Text = string.Empty;
        }

        /// <summary>
        /// ExitButton_Click event handler method is to
        /// close the application
        /// </summary>
        /// <param name="sender"> triggers the click event </param>
        /// <param name="e"> event information </param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }   
}
