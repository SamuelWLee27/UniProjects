using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Practest2
{

    //Samuel Lee (sl408)
    //1595395
    public partial class Form1 : Form
    {
        const string CSVFILTER = "CSV files|*.csv|All files|*.*";

        
        Night night; //the current night of entertainment being recorded

        Consumed currentSelect; //the currently selected drink

        public Form1()
        {
            InitializeComponent();
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            night = new Night();
            UpdateListbox(); //rewrite listbox with all drinks
       }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            night = new Night();
            try
            {
                openFileDialog1.Filter = CSVFILTER;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamReader infile = new StreamReader(openFileDialog1.FileName);

                    // read list of drinks
                    while (!infile.EndOfStream)
                    {
                        //data is "name,volume,alcohol,time"
                        string line = infile.ReadLine();
                        string[] data = line.Split(',');

                        if (data.Length == 4)
                        {
                            string name = data[0]; //first data is name
                            double volume = double.Parse(data[1]); //second data is volume of liquid
                            double alcohol = double.Parse(data[2]); //third data is alcohol percentage
                            double time = double.Parse(data[3]); //fourth data is time since start of night
                            Drink drink = new Drink(name, volume, alcohol, time);
                            night.AddDrink(drink);
                        }
                        else if(data.Length == 3)
                        {
                            string name = data[0]; //first data is name
                            double weight = double.Parse(data[1]); //second data is grams of food
                            double time = double.Parse(data[2]); //third data is time since start of night
                            Food food = new Food(name, weight, time);
                            night.AddDrink(food);
                        }
                        else //incorrect length for a drink
                        {
                            MessageBox.Show("Invalid data on line:" + line);
                        }

                    }
                    infile.Close(); //be a tidy kiwi
                    UpdateListbox(); //rewrite listbox with all drinks
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = CSVFILTER;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter outfile = new StreamWriter(saveFileDialog1.FileName);

                    // write list of drinks
                    foreach (Consumed c in night.consumedList)
                    {
                        outfile.WriteLine(c.ToCSV());  //ToCSV method gives CSV format
                    }
                    outfile.Close(); //be a tidy kiwi
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

               /// <summary>
        /// Initialises the wall variable if it has not already been initialised
        /// </summary>
        private void Initialise()
        {
            if (night == null)
            {
                night = new Night();
            }
        }

        /// <summary>
        /// Resets all input controls that control adding new drinks
        /// </summary>
        private void ResetInputParams()
        {
            txtName.Clear();
            txtTime.Clear();
            txtVolume.Clear();
            txtAlcohol.Clear();
        }

        /// <summary>
        /// Populate input controls from selected drink
        /// </summary>
        private void SetInputParams()
        {
            txtName.Text = currentSelect.Name;
            txtTime.Text = currentSelect.Time.ToString();
            if (currentSelect is Drink)//check if drink
            {
                Drink d = (Drink)currentSelect;
                txtVolume.Text = d.Volume.ToString();
                txtAlcohol.Text = d.Alcohol.ToString();
            }
            else if (currentSelect is Food)//check if food
            {
                Food f = (Food)currentSelect;
                txtVolume.Text = f.Weight.ToString();
                txtAlcohol.Text = "0";
            }
        }

        /// <summary>
        /// Display list of drinks in the listbox
        /// Also, display total standard drinks and hours until sober
        /// </summary>
        private void UpdateListbox()
        {
            listBoxDrinks.Items.Clear();
            foreach(Consumed c in night.consumedList)//loop through list
            {
                listBoxDrinks.Items.Add(c); //subclass .ToString()
            }
            txtTotal.Text = night.TotalDrinks().ToString() + " Standard Drinks";
            txtHours.Text = night.HoursTillSober().ToString() + " hours";
        }

        /// <summary>
        /// validates if appropriate input is in the textboxes
        /// </summary>
        /// <returns></returns>
        private bool ValidateInput()
        {
            try
            {
                return txtName.Text != "" &&
                       double.Parse(txtTime.Text) >= 0 &&
                       double.Parse(txtVolume.Text) > 0 &&
                       double.Parse(txtAlcohol.Text) >= 0;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            return false; //try-catch has caught 'not a number' error
        }

         
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string name = txtName.Text;
                double time = double.Parse(txtTime.Text);
                double volume = double.Parse(txtVolume.Text);
                double alcohol = double.Parse(txtAlcohol.Text);
                if (currentSelect == null)
                {
                    Drink newDrink = new Drink(name, volume, alcohol, time);
                    Initialise(); //in case they did not create a new night first
                    night.AddDrink(newDrink);
                    ResetInputParams();
                }
                else //updating an existing painting
                {
                    currentSelect.Name = name;
                    currentSelect.Time = time;
                    if (currentSelect is Drink)//check if drink
                    {
                        Drink drink = (Drink)currentSelect;
                        drink.Volume = volume;
                        drink.Alcohol = alcohol;
                    }
                }
                UpdateListbox(); //rewrite listbox with all drinks
             }
            else
            {
                MessageBox.Show("Invalid input parameters");
            }
        }

        private void listBoxDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = listBoxDrinks.SelectedIndex;
            
                currentSelect = night.SelectDrink(pos);
           
            
            if (currentSelect != null)
                SetInputParams();
            else //no drink selected
                ResetInputParams();
        }
        /// <summary>
        /// adds food to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddUpdateFood_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string name = txtName.Text;
                double weight = double.Parse(txtVolume.Text);
                double time = double.Parse(txtTime.Text);
                if (currentSelect == null)
                {
                    Food newFood = new Food(name, weight, time);
                    Initialise(); //in case they did not create a new night first
                    night.AddDrink(newFood);
                    ResetInputParams();
                }
                else //updating an existing painting
                {
                    if (currentSelect is Food)//check if food
                    {
                        Food f = (Food)currentSelect;
                        f.Weight = weight;
                    }
                    currentSelect.Name = name;
                    currentSelect.Time = time;
                   
                }
                UpdateListbox(); //rewrite listbox with all drinks
            }
            else
            {
                MessageBox.Show("Invalid input parameters");
            }
        }
    }
}
