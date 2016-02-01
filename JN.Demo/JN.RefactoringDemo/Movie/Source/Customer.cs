using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.RefactoringDemo.SourceBad
{
  public  class Customer
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

        public String Statement() {
            double totalAmount = 0;
            int frequentRenterPoints = 0;

            var result = "Rental Record for " + Name + "\n";
            foreach (var rental in Rentals)
            {
                double thisAmount = 0;
                switch (rental.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                        {
                            thisAmount += (rental.DaysRented - 2) * 1.5;
                        }
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += rental.DaysRented * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (rental.DaysRented > 3)
                        {
                            thisAmount += (rental.DaysRented - 3) * 1.5;
                        }
                        break;
                }

                frequentRenterPoints++;

                if (rental.Movie.PriceCode == Movie.NEW_RELEASE && rental.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }

                result += "\t" + rental.Movie.Title + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }



            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}
