using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    //name: Samuel Lee
    //ID:159395
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //declear balance varible
        decimal currentBalance = 0;
        /// <summary>
        /// Check if deposit amount is valid then return true or false
        /// </summary>
        /// <param name="deposit"></param>
        /// <returns></returns>
        private bool CheckDeposit(decimal deposit)
        {
            //check if deposit amount is valid
            if (deposit >= 20 && deposit <= 200)
            {
                //return true to where method was called from
                return true;
            }
            else
            {
                //show error message
                MessageBox.Show("invalid deposit amount must be with in $200 and $20 inclusive");
                //return false to where method was called from
                return false;
                
            }

        }
        /// <summary>
        /// check if withdraw amount is valid and return true or false
        /// </summary>
        /// <param name="withdraw"></param>
        /// <returns></returns>
        private bool CheckWithdraw(decimal withdraw)
        {
            //check if withdraw amount is valid
            if (withdraw >= 20 && withdraw <= currentBalance)
            {
                //return true to where method was called from
                return true;
            }
            else
            {
                //show error message
                MessageBox.Show("invalid withdraw amount must be with in max account balance and $20 inclusive");
                //return false to where the method was called from
                return false;
            }
        }
        /// <summary>
        /// deposits money entered when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                //get deposit number
                decimal deposit = decimal.Parse(textBoxDeposit.Text);
                //call method and return if deposit is valid or not
                bool valid = CheckDeposit(deposit);
                //check if return from method is valid
                if(valid == true)
                {
                    //add deposit to account balance
                    currentBalance += deposit;
                    //display new account balance
                    textBoxBalance.Text = currentBalance.ToString("c");
                    //clear deposit textbox 
                    textBoxDeposit.Clear();
                    //focus deposit textbox
                    textBoxDeposit.Focus();
                }
                else
                {
                    //clear deposit textbox 
                    textBoxDeposit.Clear();
                    //focus deposit textbox
                    textBoxDeposit.Focus();
                }
             
            }
            catch (Exception ex)
            {
                //show error
                MessageBox.Show(ex.Message);
                //clear deposit textbox 
                textBoxDeposit.Clear();
                //focus deposit textbox
                textBoxDeposit.Focus();
            }
        }
        /// <summary>
        /// Withdraw money from account when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                //get user withdraw number
                decimal withdraw = decimal.Parse(textBoxWithdraw.Text);
                //call CheckWithdraw method to check if withdraw number is valid or not
                bool valid = CheckWithdraw(withdraw);
                //check if return for withdraw method was valid
                if (valid == true)
                {
                    //minus withdraw amount off of the current balance
                    currentBalance -= withdraw;
                    //display new account balance
                    textBoxBalance.Text = currentBalance.ToString("c");
                    //Clear withdraw textbox
                    textBoxWithdraw.Clear();
                    //focus withdraw textbox
                    textBoxWithdraw.Focus();
                }
                else
                {
                    //Clear withdraw textbox
                    textBoxWithdraw.Clear();
                    //focus withdraw textbox
                    textBoxWithdraw.Focus();
                }
            }
            catch (Exception ex)
            {
                //error message
                MessageBox.Show(ex.Message);
                //Clear withdraw textbox
                textBoxWithdraw.Clear();
                //focus withdraw textbox
                textBoxWithdraw.Focus();
            }
        }
        /// <summary>
        /// Exit program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
