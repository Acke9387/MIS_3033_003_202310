using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Class_Examples
{
    public class Equation
    {
        public double Left { get; set; }

        public double Right { get; set; }

        public string name { get; set; }

        /// <summary>
        /// Default/empty constructor
        /// </summary>
        public Equation()
        {
            Left = 0;
            Right = 0;
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        public Equation(double left, double right)
        {
            Left = left;
            Right = right;
            name = "";
        }

        public double Add()
        {
            return Left + Right;
        }

        public double Divide()
        {
            if (Right == 0)
            {
                return -99999;
            }
            return Left / Right;
        }

        public double LeftToThePower(int power)
        {
            double answer = 0;
            answer = Math.Pow(Left, power);
            return answer;
        }

    }
}
