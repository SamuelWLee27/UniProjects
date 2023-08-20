using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Circuits
{
    public class OutputLamp : Gate
    {
        private Boolean _lamp = false;

        public OutputLamp(int x, int y) : base(x, y)
        {
            //Add the input pin to the gate
            pins.Add(new Pin(this, true, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);

        }



        public override void Draw(Graphics paper)
        {
            Brush brush;
            //Check lamp value
            if (_lamp == true)
            {
                brush = new SolidBrush(Color.Yellow);
            }
            else
            {
                brush = new SolidBrush(Color.DarkOrange);
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
            pins[0].X = x - GAP;
            pins[0].Y = y + HEIGHT / 2;


        }

        public override bool Evaluate()
        {
            try
            {
                //get output from last gate
                Gate gateA = pins[0].InputWire.FromPin.Owner;

                if (gateA.Evaluate() == true)
                {
                    _lamp = true;
                    
                    return _lamp;
                }
                else
                {
                    _lamp = false;
                    return _lamp;
                }
            }
            catch
            {
                _lamp = false;
                return _lamp;
            }
        }

        public override Gate Clone(int x, int y)
        {
            //if selected
            if (selected)
            {
                Gate gate = new OutputLamp(x, y);
                return gate;
            }
            else
            {
                return null;
            }
        }
    }
}
