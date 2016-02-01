using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.RefactoringDemo.RefactoringGood
{
   public class Customer
    {
        public Customer(string name)
        {
            Name = name;
            Rentals = new List<Rental>();
        }

        public List<Rental> Rentals { get; set; }

        public string Name { get; private set; }

        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
        }

        public String Statement()
        {        
            var result = "Rental Record for " + Name + "\n";
            foreach (var rental in Rentals)
            {                     
                result += "\t" + rental.Movie.Title + "\t" + rental.Movie.GetCharge(rental.DaysRented).ToString() + "\n";              
            }
            result += "Amount owed is " + GetTotalCharge() + "\n";
            result += "You earned " + GetFrequentRenterPoints() + " frequent renter points";
            return result;
        }


        public double GetFrequentRenterPoints()
        {
            var frequentRenterPoints = 0;
            foreach (var rental in Rentals)
            {
                frequentRenterPoints += rental.GetFrequentRenterPoints();
            }
            return frequentRenterPoints;
        }


        public double GetTotalCharge()
        {
            double totalAmount = 0;
            foreach (var rental in Rentals)
            {            
                totalAmount += rental.Movie.GetCharge(rental.DaysRented);
            }

            return totalAmount;
        }

    }
}
