using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// I, Braeden Lyman, Student Number 000370695 certify that this material is
/// my original work. No other person's work has been used without due acknowledgement.
/// 
/// The purpose of this document is to create a hairdresser form application for a user to choose a hairdresser
/// with the service(s) they want. After user chooses a hairdresser and service(s), the applciation will allow them 
/// to calculate the total amount it will cost them. 
/// 
/// Name: Braeden Lyman
/// Student Number: 000370695
/// File: Braes_hair_salon.cs
/// Date: Oct 27th, 2023


namespace Lab3B
{
    /// <summary>
    /// Braes_Hair_Salon is a form application that asks users to choose 
    /// a hairdresser and services they would like. Users must choose a hairdresser
    /// and at least one service. The application will then calculate the total amount
    /// it will cost for the selected hairdresser and selected services once the user
    /// clicks the Calculate Total button. If the user wants to reset the application,
    /// the can simply click the Reset Button.
    /// </summary>
    public partial class Braes_Hair_Salon : Form
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

        //Wash, blow-dry and style Price
        private const decimal wash_blow_style_price = 20.00m;

        // Colour Price
        private const decimal colour_price = 40.00m;

        // Highlights Price
        private const decimal highlights_price = 50.00m;

        // Extensions Price
        private const decimal extension_price = 200.00m;

        // Up-do Price
        private const decimal up_do_price = 60.00m;

        // Total Cost
        private decimal totalCost = 0m;

        /// <summary>
        /// Braes_hiar_salon constructor is to intialize the controls 
        /// and components of the form as well as sets up the graphical interface
        /// </summary>
        public Braes_Hair_Salon()
        {
            InitializeComponent();
            chargedItemsListBox.Enabled = false;
            priceListBox.Enabled = false;
            hairdresserComboBox.SelectedIndex = 0;
            addServiceButton.Enabled = false;
            calculateTotalButton.Enabled = false;

            serviceListBox.SelectedIndexChanged += serviceListBoxIndexChangeEvent; // setting up an event for when user selects a service
        }

        /// <summary>
        /// serviceListBoxIndexChnageEvent event handler is for when the user clicks on 
        /// a service it will allow the user to clcik the add service button 
        /// and add the service to the charged items listbox
        /// </summary>
        /// <param name="sender">triggers the event - click on a service</param>
        /// <param name="e">event information - add service button becomes enabled</param>
        private void serviceListBoxIndexChangeEvent(object sender, EventArgs e)
        {
            addServiceButton.Enabled = serviceListBox.SelectedItems.Count > 0;
        }

        /// <summary>
        /// exitButton_Click event handler is when the user clicks the exit
        /// button it will close the application
        /// </summary>
        /// <param name="sender">triggers the click event exit</param>
        /// <param name="e">event information - closes the application</param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// addServiceButton_Click event handler is for when the user clicks the 
        /// add service button. It will disable the hairdresser combobox, add the
        /// hairdresser's name and rate to the charged items and price listbox as
        /// well as add the service to the charged items and price listbox. If no
        /// hairdresser or service is choosen, an error message box will pop up
        /// </summary>
        /// <param name="sender">triggers the click event addServiceButton</param>
        /// <param name="e">
        ///     event information - adds multiple services and one 
        ///     hairdresser to the charged items and price listbox
        /// </param>
        private void addServiceButton_Click(object sender, EventArgs e)
        {
            // if-statment for displaying error message
            if (hairdresserComboBox.SelectedItem == null)
            {
                MessageBox.Show("Must choose one of the hairdressers.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hairdresserComboBox.Focus();
                return;
            }

            // if-statment for displaying error message
            if (serviceListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Must choose one or more service", "Service Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serviceListBox.Focus();
                return;
            }

            string selectedHairdresser = hairdresserComboBox.SelectedItem.ToString(); // assigning selected item from the hairdresser combobox to string selectedHairdresser

            // if the selected hairdresser is not already in the charged items listbox
            if (!chargedItemsListBox.Items.Contains(selectedHairdresser))
            {
                chargedItemsListBox.Items.Add(selectedHairdresser.ToString());
                hairdresserComboBox.Enabled = false;
                decimal hairdresserPrice = GetHairdresserRate(selectedHairdresser.ToString()); // assigning selected hairdresser's rate to local decmail variable hairdresserPrice - to convert toString to currency 
                priceListBox.Items.Add(hairdresserPrice.ToString("C")); // adds hairdresserPrice to priceListBox as well as changes toString to currency
                totalCost += GetHairdresserRate(selectedHairdresser);
            }

            // foreach-loop for checking to see which item is selected in the service comboBox
            foreach (string selectedService in serviceListBox.SelectedItems)
            {
                chargedItemsListBox.Items.Add(selectedService.ToString());
                decimal servicePrice = GetServicePrice(selectedService.ToString()); // assigning selected service price to local decimal variable servicePrice - to convert toString to currency 
                priceListBox.Items.Add(servicePrice.ToString("C")); // adds servicePrice to priceListBox as well as changes toString to currency
                totalCost += GetServicePrice(selectedService.ToString());
            }

            calculateTotalButton.Enabled = true;
        }

        /// <summary>
        /// GetHairdresserRate function is for getting the hairdresser's
        /// pay rate
        /// </summary>
        /// <param name="hairdresser"> hairdresser from hairdresser comboBox</param>
        /// <returns>hairdresser's pay rate</returns>
        private decimal GetHairdresserRate(string hairdresser)
        {
            // switch case for getting hairdresser's pay rate
            switch (hairdresser)
            {
                case "Jane Samley":
                    return jane_rate;
                case "Pat Johnson":
                    return pat_rate;
                case "Ron Chambers":
                    return ron_rate;
                case "Sue Pallon":
                    return sue_rate;
                case "Laura Renkins":
                    return laura_rate;
                default:
                    return 0;
            }
        }
        
        /// <summary>
        /// GetServicePrice function is for getting the service rate
        /// </summary>
        /// <param name="service">service from service listBox</param>
        /// <returns>service rate</returns>
        private decimal GetServicePrice(string service)
        {
            // switch case for getting service rate
            switch (service)
            {
                case "Cut":
                    return cut_price;
                case "Wash, blow-dry & style":
                    return wash_blow_style_price;
                case "Colour":
                    return colour_price;
                case "Highlights":
                    return highlights_price;
                case "Extension":
                    return extension_price;
                case "Up-do":
                    return up_do_price;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// calculateTotalButton_Click event is for when the user clicks
        /// on the calculate total button. It calculates the total amount
        /// that is in the price listBox.
        /// </summary>
        /// <param name="sender">triggers the click event calculateToatlButton</param>
        /// <param name="e">event information - calculates the total amount in the price listBox</param>
        private void calculateTotalButton_Click(object sender, EventArgs e)
        {
            totalPriceTextBox.Text = totalCost.ToString("C"); // returns total amount as well as currency format
        }

        /// <summary>
        /// resetButton_Click event is for when the user wants to clear 
        /// all the information on the application. The reset button also 
        /// defaults to the first hairdresser in the comboBox as well as
        /// disables the add service and calculateTotal button until user 
        /// selects a hairdresser and service.
        /// </summary>
        /// <param name="sender">triggers the click event resetButton</param>
        /// <param name="e">event information - resets everything on the application</param>
        private void resetButton_Click(object sender, EventArgs e)
        {
            chargedItemsListBox.Items.Clear();
            hairdresserComboBox.Enabled = true;
            hairdresserComboBox.SelectedIndex = 0;
            priceListBox.Items.Clear();
            totalCost = 0.00m;
            totalPriceTextBox.Text = string.Empty;
            serviceListBox.ClearSelected();
            addServiceButton.Enabled = false;
            calculateTotalButton.Enabled = false;
            hairdresserComboBox.Focus();
        }
    }
}