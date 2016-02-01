using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.RefactoringDemo.RefactoringGood
{
   public abstract class Price
    {
       public abstract int PriceCode { get; }

       public abstract double GetCharge(int daysRented);

       public virtual int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
       
    }
}
