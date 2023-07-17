using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermDepositCalculator
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            
            try
            {
                ///Declear varibles
                decimal deposit = 0;
                double interestRate = 0;
                int years = 0;
                int investYears = 1;
                decimal interest = 0;
                ///get user input varibles
                deposit = decimal.Parse(textBoxDeposit.Text);
                interestRate = double.Parse(textBoxInterestRate.Text) / 100.0;
                years = int.Parse(textBoxYears.Text);
                ///test if values are valid
                if (deposit > 0 || interestRate > 0 || years >= 1)
                {
                    ///loop for number of years that user input
                    while (years >= investYears)
                    {
                        ///Calulate interest and deposit
                        interest = deposit * (decimal)interestRate;
                        deposit = deposit + interest;
                        ///display calculations
                        Console.WriteLine("Year " + investYears + ": interest = " + interest.ToString("c") + " and deposit = " + deposit.ToString("c"));
                        /// add one to counter for loop
                        investYears++;
                    }
                    ///clear textboxs and focus first textbox
                    textBoxDeposit.Clear();
                    textBoxInterestRate.Clear();
                    textBoxYears.Clear();
                    textBoxDeposit.Focus();
                }
                else
                {
                    ///if not valid display error, clear textboxs and focus first textbox
                    Console.WriteLine("Please enter valid numbers");
                    textBoxDeposit.Clear();
                    textBoxInterestRate.Clear();
                    textBoxYears.Clear();
                    textBoxDeposit.Focus();

                }
            }
            catch (Exception ex)
            {
                ///display error and clear textboxs and focus first textbox
                Console.WriteLine(ex.Message);
                textBoxDeposit.Clear();
                textBoxInterestRate.Clear();
                textBoxYears.Clear();
                textBoxDeposit.Focus();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ///clear textboxs and focus first textbox
            textBoxDeposit.Clear();
            textBoxInterestRate.Clear();
            textBoxYears.Clear();
            textBoxDeposit.Focus();
        }
    }
}
