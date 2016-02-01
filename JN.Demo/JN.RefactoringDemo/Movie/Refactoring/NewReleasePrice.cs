using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.RefactoringDemo.RefactoringGood
{
    public class NewReleasePrice : Price
    {

        public override int PriceCode
        {
            get
            {
                return Movie.NEW_RELEASE;
            }
        }

        public override double GetCharge(int daysRented)
        {
            
            return daysRented * 3;
        }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }
    }
}
