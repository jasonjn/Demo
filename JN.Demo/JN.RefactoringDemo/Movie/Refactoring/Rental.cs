using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.RefactoringDemo.RefactoringGood
{
   public class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }


        public Movie Movie { get; private set; }

        public int DaysRented { get; private set; }


        public double GetCharge()
        {
            return Movie.GetCharge(DaysRented);
        }

        public int GetFrequentRenterPoints()
        {
            return Movie.GetFrequentRenterPoints(DaysRented);
        }
    }
}
