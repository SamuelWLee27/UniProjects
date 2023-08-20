using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// Compounds gates together
    /// </summary>
    public class Compound : Gate
    {
        private List<Gate> gatesList;

        public Compound(int x, int y) : base(x, y)
        {
            gatesList = new List<Gate>();
        }

        /// <summary>
        /// add gate to list
        /// </summary>
        /// <param name="gate"></param>
        public void AddGate(Gate gate)
        {
            //add gate to the list
            gatesList.Add(gate);
        }

        /// <summary>
        /// select all gates in compound
        /// </summary>
        public override bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                //loop through all gates and check if any are selected
                foreach (Gate gate in gatesList)
                {
                    gate.Selected = value;
                    if (gate.Selected)
                    {
                        selected = true;
                    }
                    else if(selected != true)
                    {
                        selected = false;
                    }
                }
                //if selected make all selected
                if (selected)
                {
                    foreach(Gate gate in gatesList)
                    {
                        gate.Selected = true;
                    }
                }//if not selected make all false
                else
                {
                    foreach (Gate gate in gatesList)
                    {
                        gate.Selected = false;
                    }
                }
            }
        }

        public override void Draw(Graphics paper)
        {
            //loops through and draws gates
            foreach(Gate gates in gatesList)
            {
                gates.Draw(paper);
            }
        }

        public override void MoveTo(int x, int y)
        {
            
            //loops through each gate and calls MoveTo method
            foreach(Gate gates in gatesList)
            {
                gates.MoveTo(x, y);
            }
        }

        public override Gate Clone(int x, int y)
        {
           Compound newCompound = new Compound(0, 0);
            //copies gates to new compound
            foreach (Gate gates in gatesList)
            {
                newCompound.AddGate(gates);

            }
            return newCompound;
        }

    }
}
