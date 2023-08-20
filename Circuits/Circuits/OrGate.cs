using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements an OR gate with two inputs
    /// and one output.
    /// </summary>
    public class OrGate : Gate
    {
        public OrGate(int x, int y) : base(x, y)
        {
            //Add the two input pins to the gate
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }

        public override void Draw(Graphics paper)
        {
            Brush brush;
            //Check if the gate has been selected
            if (selected)
            {
                brush = selectedBrush;
            }
            else
            {
                brush = normalBrush;
            }
            //Draw each of the pins
            foreach (Pin p in pins)
                p.Draw(paper);
            

            //draw or gate
            paper.FillEllipse(brush, left, top, WIDTH, HEIGHT);
            paper.FillRectangle(brush, left, top, WIDTH / 2, HEIGHT);
            paper.FillRectangle(brush, Left - 5, Top, WIDTH / 2, 5);
            paper.FillRectangle(brush, Left - 5, Top + HEIGHT - 5, WIDTH / 2, 5);



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
            pins[0].Y = y + GAP;
            pins[1].X = x - GAP;
            pins[1].Y = y + HEIGHT - GAP;
            pins[2].X = x + WIDTH + GAP;
            pins[2].Y = y + HEIGHT / 2;
        }

        public override bool Evaluate()
        {
            try
            {
                //get output from last gates 
                Gate gateA = pins[0].InputWire.FromPin.Owner;
                Gate gateB = pins[1].InputWire.FromPin.Owner;
                

                    return gateA.Evaluate() || gateB.Evaluate();
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
                Gate gate = new OrGate(x, y);
                return gate;
            }
            else
            {
                return null;
            }
        }
    }
}
