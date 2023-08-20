using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements an Not gate with one input
    /// and one output.
    /// </summary>
    public class NotGate : Gate
    {

        public NotGate(int x, int y) : base(x, y)
        {
            //Add one input pin to the gate
            pins.Add(new Pin(this, true, 20));
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }

        public override void Draw(Graphics paper)
        {
            Pen pen;
            //Check if the gate has been selected
            if (selected)
            {
                pen = selectedPen;
            }
            else
            {
                pen = normalPen;
            }
            //Draw each of the pins
            foreach (Pin p in pins)
                p.Draw(paper);


            //draw Not gate
            paper.DrawLine(pen, Left, Top, Left, Top + HEIGHT);
            paper.DrawLine(pen, Left, Top, Left + WIDTH, Top + HEIGHT/2);
            paper.DrawLine(pen, Left, Top + HEIGHT, Left + WIDTH, Top + HEIGHT / 2);
        }

        public override void MoveTo(int x, int y)
        {
            //Debugging message
            Console.WriteLine("pins = " + pins.Count);
            //Set the position of the gate to the values passed in
            left = x;
            top = y;
            // must move the pins too
            pins[0].X = x - GAP;
            pins[0].Y = y + HEIGHT / 2;
            pins[1].X = x + WIDTH + GAP;
            pins[1].Y = y + HEIGHT / 2;

        }

        public override bool Evaluate()
        {
            try
            {
                //get output from last gate 
                Gate gateA = pins[0].InputWire.FromPin.Owner;

                if (!gateA.Evaluate())
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public override Gate Clone(int x, int y)
        {
            //if selected
            if (selected)
            {
                Gate gate = new NotGate(x, y);
                return gate;
            }
            else
            {
                return null;
            }
        }

    }
}
