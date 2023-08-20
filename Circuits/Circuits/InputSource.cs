using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements an input source
    /// with one output.
    /// </summary>
    public class InputSource : Gate
    {
        private Boolean _voltage = false;

        public InputSource(int x, int y) : base(x, y)
        {
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
            
        }

       

        public override void Draw(Graphics paper)
        {
            Brush brush;
            //Check if the gate has been selected

            if (Selected)
            {
                _voltage = !_voltage;
            }

            //Check voltage value
            if (_voltage == true)
            {
                brush = new SolidBrush(Color.Green);
            }
            else
            {
                brush = new SolidBrush(Color.Purple);
            }
            //Draw each of the pins
            foreach (Pin p in pins)
                p.Draw(paper);


            //draw or gate
            paper.FillRectangle(brush, left, top, WIDTH, HEIGHT);
            



        }

        public override void MoveTo(int x, int y)
        {
            //Debugging message
            Console.WriteLine("pins = " + pins.Count);
            //Set the position of the gate to the values passed in
            left = x;
            top = y;
            // must move the pins too
            pins[0].X = x + WIDTH + GAP;
            pins[0].Y = y + HEIGHT / 2;


        }

        public override bool Evaluate()
        {
            //check if it is supplying a voltage
            if (_voltage == true)
            {
                return true;
            }
            
                return false;
            
        }

        public override Gate Clone(int x, int y)
        {
            //if selected
            if (selected)
            {
                Gate gate = new InputSource(x, y);
                return gate;
            }
            else
            {
                return null;
            }
        }
    }
}
