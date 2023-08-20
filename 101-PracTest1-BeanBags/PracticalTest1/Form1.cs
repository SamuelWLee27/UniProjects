using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticalTest1
{
    public partial class Form1 : Form
    {
        //Name: Samuel Lee
        //ID  : 1595395

        //Amount of beans required for a small beanbag in litres
        const double SMALL_BAG_SIZE = 2.5;
        //Amount of beans required for a large beanbag in litres
        const double LARGE_BAG_SIZE = 5.5;
        //cost of buying 1 litre of beans is $3.50
        const decimal BEANS_COST = 3.50m;
        //Amount of beans in a carton (for bonus task)
        const int CARTON_VOLUME = 100;
        //Cost of a carton of beans (for bonus task)
        const decimal CARTON_COST = 200.00m;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ///Clear text boxs with button
            textBoxSmallBean.Clear();
            textBoxLargeBean.Clear();
            textBoxBeansSmallBag.Clear();
            textBoxBeansLargeBag.Clear();
            textBoxTotalBeans.Clear();
            textBoxTotalCost.Clear();
            ///Focus mouse to small bean bags text box
            textBoxSmallBean.Focus();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                ///Varibles for values
                int smallBeanBags = 0;
                int largeBeanBags = 0;
                double smallBeansNeeded;
                double largeBeansNeeded;
                double totalBeansNeeded;
                decimal totalCost;
                int numberCartons;
                decimal cartonTotalCost;
                ///Collect user input values
                smallBeanBags = int.Parse(textBoxSmallBean.Text);
                largeBeanBags = int.Parse(textBoxLargeBean.Text);
                ///Calculate small beans needed
                smallBeansNeeded = (double)smallBeanBags * SMALL_BAG_SIZE;
                ///Calculate large beans needed
                largeBeansNeeded = (double)largeBeanBags * LARGE_BAG_SIZE;
                ///Calculate total beans needed
                totalBeansNeeded = smallBeansNeeded + largeBeansNeeded;
                ///Calculate total cost
                totalCost = (decimal)totalBeansNeeded * BEANS_COST;
                ///Calculate number of cartons
                numberCartons = (int)Math.Ceiling(totalBeansNeeded / CARTON_VOLUME);
                ///Calculate cost of cartoons
                cartonTotalCost = numberCartons * CARTON_COST;
                ///Display calculations
                textBoxBeansSmallBag.Text = smallBeansNeeded.ToString();
                textBoxBeansLargeBag.Text = largeBeansNeeded.ToString();
                textBoxTotalBeans.Text = totalBeansNeeded.ToString();
                textBoxTotalCost.Text = totalCost.ToString("c");
                textBoxCartons.Text = numberCartons.ToString();
                textBoxCartonCost.Text = cartonTotalCost.ToString("c");

            }
            catch (Exception ex)
            { 
                ///Error message
                MessageBox.Show(ex.Message);
                ///Clear text boxs with button
                textBoxSmallBean.Clear();
                textBoxLargeBean.Clear();
                textBoxBeansSmallBag.Clear();
                textBoxBeansLargeBag.Clear();
                textBoxTotalBeans.Clear();
                textBoxTotalCost.Clear();
                ///Focus mouse to small bean bags text box
                textBoxSmallBean.Focus();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
