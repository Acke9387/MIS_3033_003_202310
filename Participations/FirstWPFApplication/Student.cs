using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWPFApplication
{
    public class Student
    {

        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }


        /// <summary>
        /// Default constructor
        /// </summary>
        public Student()
        {
            Name = string.Empty;
            Birthdate = null;
        }

        /// <summary>
        /// Calculates the age of the student
        /// </summary>
        /// <returns>The number of years old the student is as a whole number</returns>
        public int CalculateAge()
        {
            if (Birthdate.HasValue)
            {
                DateTime now = DateTime.Today;
                int age = now.Year - Birthdate.Value.Year;
                if (Birthdate.Value > now.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            return $"{Name} was born on {Birthdate.Value.ToShortDateString()}."; 
        }

    }


}
