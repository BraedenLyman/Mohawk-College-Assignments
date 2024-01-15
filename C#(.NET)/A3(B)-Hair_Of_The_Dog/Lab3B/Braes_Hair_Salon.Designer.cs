namespace Lab3B
{
    partial class Braes_Hair_Salon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hairdresserComboBox = new System.Windows.Forms.ComboBox();
            this.hairdresserLabel = new System.Windows.Forms.Label();
            this.chargedItemsListBox = new System.Windows.Forms.ListBox();
            this.serviceLabel = new System.Windows.Forms.Label();
            this.chargedItemsLabel = new System.Windows.Forms.Label();
            this.serviceListBox = new System.Windows.Forms.ListBox();
            this.priceListBox = new System.Windows.Forms.ListBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.addServiceButton = new System.Windows.Forms.Button();
            this.calculateTotalButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hairdresserComboBox
            // 
            this.hairdresserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hairdresserComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.hairdresserComboBox.FormattingEnabled = true;
            this.hairdresserComboBox.Items.AddRange(new object[] {
            "Jane Samley",
            "Pat Johnson",
            "Ron Chambers",
            "Sue Pallon",
            "Laura Renkins"});
            this.hairdresserComboBox.Location = new System.Drawing.Point(22, 43);
            this.hairdresserComboBox.Name = "hairdresserComboBox";
            this.hairdresserComboBox.Size = new System.Drawing.Size(138, 24);
            this.hairdresserComboBox.TabIndex = 0;
            // 
            // hairdresserLabel
            // 
            this.hairdresserLabel.AutoSize = true;
            this.hairdresserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.hairdresserLabel.Location = new System.Drawing.Point(19, 23);
            this.hairdresserLabel.Name = "hairdresserLabel";
            this.hairdresserLabel.Size = new System.Drawing.Size(141, 17);
            this.hairdresserLabel.TabIndex = 1;
            this.hairdresserLabel.Text = "Select a Hairdresser:";
            // 
            // chargedItemsListBox
            // 
            this.chargedItemsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chargedItemsListBox.FormattingEnabled = true;
            this.chargedItemsListBox.ItemHeight = 16;
            this.chargedItemsListBox.Location = new System.Drawing.Point(376, 43);
            this.chargedItemsListBox.Name = "chargedItemsListBox";
            this.chargedItemsListBox.Size = new System.Drawing.Size(167, 116);
            this.chargedItemsListBox.TabIndex = 2;
            // 
            // serviceLabel
            // 
            this.serviceLabel.AutoSize = true;
            this.serviceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.serviceLabel.Location = new System.Drawing.Point(175, 23);
            this.serviceLabel.Name = "serviceLabel";
            this.serviceLabel.Size = new System.Drawing.Size(114, 17);
            this.serviceLabel.TabIndex = 3;
            this.serviceLabel.Text = "Select a Service:";
            // 
            // chargedItemsLabel
            // 
            this.chargedItemsLabel.AutoSize = true;
            this.chargedItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chargedItemsLabel.Location = new System.Drawing.Point(373, 23);
            this.chargedItemsLabel.Name = "chargedItemsLabel";
            this.chargedItemsLabel.Size = new System.Drawing.Size(103, 17);
            this.chargedItemsLabel.TabIndex = 4;
            this.chargedItemsLabel.Text = "Charged Items:";
            // 
            // serviceListBox
            // 
            this.serviceListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.serviceListBox.FormattingEnabled = true;
            this.serviceListBox.ItemHeight = 16;
            this.serviceListBox.Items.AddRange(new object[] {
            "Cut",
            "Wash, blow-dry & style",
            "Colour",
            "Highlights",
            "Extension",
            "Up-do"});
            this.serviceListBox.Location = new System.Drawing.Point(178, 43);
            this.serviceListBox.Name = "serviceListBox";
            this.serviceListBox.Size = new System.Drawing.Size(171, 116);
            this.serviceListBox.TabIndex = 5;
            // 
            // priceListBox
            // 
            this.priceListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.priceListBox.FormattingEnabled = true;
            this.priceListBox.ItemHeight = 16;
            this.priceListBox.Location = new System.Drawing.Point(568, 43);
            this.priceListBox.Name = "priceListBox";
            this.priceListBox.Size = new System.Drawing.Size(84, 116);
            this.priceListBox.TabIndex = 6;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.priceLabel.Location = new System.Drawing.Point(565, 23);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(48, 17);
            this.priceLabel.TabIndex = 7;
            this.priceLabel.Text = "Price: ";
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.totalPriceLabel.Location = new System.Drawing.Point(478, 177);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(84, 17);
            this.totalPriceLabel.TabIndex = 8;
            this.totalPriceLabel.Text = "Total Price: ";
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.totalPriceTextBox.Location = new System.Drawing.Point(568, 174);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.Size = new System.Drawing.Size(84, 23);
            this.totalPriceTextBox.TabIndex = 9;
            // 
            // addServiceButton
            // 
            this.addServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addServiceButton.Location = new System.Drawing.Point(10, 215);
            this.addServiceButton.Name = "addServiceButton";
            this.addServiceButton.Size = new System.Drawing.Size(156, 26);
            this.addServiceButton.TabIndex = 10;
            this.addServiceButton.Text = "Add Service";
            this.addServiceButton.UseVisualStyleBackColor = true;
            this.addServiceButton.Click += new System.EventHandler(this.addServiceButton_Click);
            // 
            // calculateTotalButton
            // 
            this.calculateTotalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.calculateTotalButton.Location = new System.Drawing.Point(172, 215);
            this.calculateTotalButton.Name = "calculateTotalButton";
            this.calculateTotalButton.Size = new System.Drawing.Size(156, 26);
            this.calculateTotalButton.TabIndex = 11;
            this.calculateTotalButton.Text = "Calculate Total Price";
            this.calculateTotalButton.UseVisualStyleBackColor = true;
            this.calculateTotalButton.Click += new System.EventHandler(this.calculateTotalButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.resetButton.Location = new System.Drawing.Point(334, 215);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(156, 26);
            this.resetButton.TabIndex = 12;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.exitButton.Location = new System.Drawing.Point(496, 215);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(156, 26);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Braes_Hair_Salon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 260);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.calculateTotalButton);
            this.Controls.Add(this.addServiceButton);
            this.Controls.Add(this.totalPriceTextBox);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.priceListBox);
            this.Controls.Add(this.serviceListBox);
            this.Controls.Add(this.chargedItemsLabel);
            this.Controls.Add(this.serviceLabel);
            this.Controls.Add(this.chargedItemsListBox);
            this.Controls.Add(this.hairdresserLabel);
            this.Controls.Add(this.hairdresserComboBox);
            this.Name = "Braes_Hair_Salon";
            this.Text = "Brae\'s Hair Salon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox hairdresserComboBox;
        private System.Windows.Forms.Label hairdresserLabel;
        private System.Windows.Forms.ListBox chargedItemsListBox;
        private System.Windows.Forms.Label serviceLabel;
        private System.Windows.Forms.Label chargedItemsLabel;
        private System.Windows.Forms.ListBox serviceListBox;
        private System.Windows.Forms.ListBox priceListBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.TextBox totalPriceTextBox;
        private System.Windows.Forms.Button addServiceButton;
        private System.Windows.Forms.Button calculateTotalButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button exitButton;
    }
}

