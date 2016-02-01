using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.RefactoringDemo.RefactoringGood
{
    public class ChildrenPrice : Price
    {

        public override int PriceCode
        {
            get {
                return Movie.CHILDRENS;
            }
        }

        public override double GetCharge(int daysRented)
        {
            var result = 0d;
            result += 1.5;
            if (daysRented > 3)
            {
                result += (daysRented - 3) * 1.5;
            }
            return result;
        }

        
    }
}
