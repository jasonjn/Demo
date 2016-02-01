using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.RefactoringDemo.RefactoringGood
{
    public class Movie
    {
        public Movie(string title,Price price)
        {
            Title = title;
            Price = price;  
        }
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        public const int CHILDRENS = 2;

        public string Title { get; private set; }

        
       public Price Price { get; set; }

        public double GetCharge(int daysRented)
        {
            return Price.GetCharge(daysRented);
        }


        public int GetFrequentRenterPoints(int daysRented)
        {
            return Price.GetFrequentRenterPoints(daysRented);

          
        }
    }
    
}
