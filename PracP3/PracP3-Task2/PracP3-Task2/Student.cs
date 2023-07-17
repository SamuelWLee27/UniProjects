using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracP3_Task2
{
    /// <summary>
    /// Holds a student
    /// </summary>
    public class Student
    {
        /// <summary>
        /// name of student
        /// </summary>
        private string _name;
        /// <summary>
        /// id of student
        /// </summary>
        private int _id;
        /// <summary>
        /// has the student paid
        /// </summary>
        private bool _hasPaid;
       
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool HasPaid
        {
            get { return _hasPaid; }
            set { _hasPaid = value; }
        }

        /// <summary>
        /// Initialises the object to the values passed in.
        /// </summary>
        /// <param name="name">Name of stdents</param>
        /// <param name="id">id of students</param>
        /// <param name="hasPaid">has student paid</param>
        public Student(string name, int id, bool hasPaid)
        {
            Name = name;
            Id = id;
            HasPaid = hasPaid;
        }
        /// <summary>
        /// overwrite to string so spits out info needed
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name.ToString().PadRight(15) + Id.ToString().PadRight(15) + HasPaid;
        }
    }
}
