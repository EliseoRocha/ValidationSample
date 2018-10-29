using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidationSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ValidateDataButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                MessageBox.Show("All good!");
            }
        }

        private bool IsValid()
        {
            string name = FullNameTextBox.Text;
            //Flag variable/boolean
            bool isDataValid = true;
            string errorMessages = "";

            if (!IsPresent(name))
            {
                isDataValid = false;
                errorMessages += "Name is required!\n"; // \n is a line break
            }
            if (!IsPresent(AgeTextBox) || !IsByte(AgeTextBox.Text))
            {
                isDataValid = false;
                errorMessages += "Age is required and should be a number!\n";
            }

            if (IsByte(AgeTextBox.Text))
            {
                const byte minAge = 5;
                const byte maxAge = 130;
                byte age = Convert.ToByte(AgeTextBox.Text);
                if (!IsWithinRange(minAge, maxAge, age))
                {
                    isDataValid = false;
                    errorMessages += $"Age must be {minAge} - {maxAge}!";
                }
            }

            if (!isDataValid)
            {
                MessageBox.Show(errorMessages);
            }

            return isDataValid;
        }

        /// <summary>
        /// Checks to see if there is data in a texbox
        /// </summary>
        /// <returns></returns>
        //private bool IsPresent(TextBox box)
        //{
        //    if (string.IsNullOrWhiteSpace(box.Text))
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //Same as above, use this so it isn't redundant with below
        private bool IsPresent(TextBox box)
        {
            return IsPresent(box.Text);
        }

        private bool IsPresent(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Tests to ensure a number is within a range
        /// </summary>
        /// <param name="minValue">The inclusive lower bound</param>
        /// <param name="maxValue">The inclusive upper bound</param>
        /// <param name="numToTest">Number to test in the range</param>
        /// <returns></returns>
        private bool IsWithinRange(int minValue, int maxValue, int numToTest)
        {
            if (numToTest >= minValue && numToTest <= maxValue)
            {
                return true;
            }
            return false;
        }
        
        private bool IsByte(string input)
        {
            //Exception handling same as bellow
            byte test;
            if (byte.TryParse(input, out test))
            {
                return true;
            }
            return false;

            //Excetption handling
            //try
            //{
            //    Convert.ToByte(input);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}

        }
    }
}
