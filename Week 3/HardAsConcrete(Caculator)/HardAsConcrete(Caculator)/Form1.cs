using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardAsConcrete_Caculator_
{
    public partial class Form1 : Form
    {
        ///the depth of every driveway
        const double DRIVEWAY_DEPTH = 0.5;
        ///Amount of concrete created from 1 kg of cement;
        const double CONCRETE_PER_KG = 1.5;
        ///Weight of a bag of cement
        const double BAG_WEIGHT = 2.0;
        ///cost of bag of cement
        const decimal BAG_COST = 15.5m;
        ///declear veriables
        double drivewayLength = 0.0;
        double drivewayWidth = 0.0;
        double volume = 0.0;
        double kgRequired = 0.0;
        int bags = 0;
        decimal cost = 0m;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ///clear text boxs
            textBoxLength.Clear();
            textBoxWidth.Clear();
            textBoxCement.Clear();
            textBoxBags.Clear();
            textBoxCost.Clear();
            textBoxVolume.Clear();
            ///Focus to length text box
            textBoxLength.Focus();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                /// Get length and width and make double
                drivewayLength = double.Parse(textBoxLength.Text);
                drivewayWidth = double.Parse(textBoxWidth.Text);
                ///Calculate volume
                volume = drivewayLength * drivewayWidth * DRIVEWAY_DEPTH;
                ///Caluculate  kgs of cement
                kgRequired = volume / CONCRETE_PER_KG;
                ///calculate Bags of cement
                bags = (int)Math.Ceiling(kgRequired / BAG_WEIGHT);
                ///calculate total cost
                cost = (decimal)bags * (decimal)BAG_COST;
                ///Display calculations
                textBoxVolume.Text = volume.ToString("n3");
                textBoxCement.Text = kgRequired.ToString("n3");
                textBoxBags.Text = bags.ToString();
                textBoxCost.Text = cost.ToString("c");
            }
            catch (Exception ex)
            {
                ///Error message
                MessageBox.Show(ex.Message);
                ///Clear text boxs
                textBoxLength.Clear();
                textBoxWidth.Clear();
                textBoxCement.Clear();
                textBoxBags.Clear();
                textBoxCost.Clear();
                textBoxVolume.Clear();
                ///Focus to length text box
                textBoxLength.Focus();

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLength_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
