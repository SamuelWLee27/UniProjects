using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace PracP3_Task3
{
    public class Forest
    {
        private Random _rand;
        private List<Tree> _forestList;
        /// <summary>
        /// Initialises the object to the values passed in.
        /// </summary>
        public Forest()
        {
            _rand = new Random();
            _forestList = new List<Tree>();
        }
        /// <summary>
        /// adds tree to list
        /// </summary>
        /// <param name="x"> x pos of tree</param>
        /// <param name="y">y pos of tree</param>
        /// <param name="size">size of tree</param>
        public void AddTree(int x, int y, int size)
        {
            _forestList.Add(new Tree(x, y, size));
        }
        /// <summary>
        /// Draws trees in forest
        /// </summary>
        /// <param name="paper"> canvas drawing on</param>
        public void DrawTrees(Graphics paper)
        {
            
            foreach(Tree t in _forestList)
            {
                t.DrawTree(paper);
            }
        }
        /// <summary>
        /// save forest trees to file
        /// </summary>
        /// <param name="filename"></param>
        public void SaveFile(string filename)
        {
            StreamWriter writer;
            //create file
            writer = File.CreateText(filename);

            foreach(Tree t in _forestList)
            {
                writer.WriteLine(t.ToCsvString());
            }


            writer.Close();
        }
        /// <summary>
        /// opens files and adds trees to list
        /// </summary>
        /// <param name="filename"></param>
        public void OpenFile(string filename)
        {
            string line = "";
            StreamReader reader;
            
            //open file
            reader = File.OpenText(filename);
           
            while (!reader.EndOfStream)
            {
                try
                {
                    line = reader.ReadLine();
                    string[] csvArray = line.Split(',');
                    //add tree to list
                    _forestList.Add(new Tree(int.Parse(csvArray[0]), int.Parse(csvArray[1]), int.Parse(csvArray[2])));
                }
                catch 
                {
                    Console.WriteLine("Error: " + line);
                }
            }

            reader.Close();
        }
        /// <summary>
        /// makes random tree grow
        /// </summary>
        /// <param name="growth"> size tree grows by</param>
        public void GrowForest(int growth)
        {
            //check if there is a tree in tree list
            if (!(_forestList.Count == 0))
            {
                int index = _rand.Next(0, _forestList.Count);
                //get tree at random index
                Tree t = _forestList[index];
                //Grow tree
                t.GrowTree(growth);
                //remove tree then replace by grown tree
                _forestList.RemoveAt(index);
                _forestList.Insert(index, t);

            }
        }
    }
}
