using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFromAFile
{
    public class CarOwner
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Make {get;set;}
        public string Model {get;set;}
        public int Year {get;set;}
        public string Color { get; set; }


        public CarOwner()
        {
            FirstName = "";
            LastName = "";
            Make = "";
            Model = "";
            Year = 0;
            Color = "";
        }

        public override string ToString()
        {
            return $"{Make} {Model} {Year.ToString("G0")} {Color}";
        }

    }
}






