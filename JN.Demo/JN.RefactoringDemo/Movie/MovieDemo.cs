using JN.RefactoringDemo.RefactoringGood;
using JN.RefactoringDemo.SourceBad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.RefactoringDemo
{
    class MovieDemo  
    {
        public static void Show()
        {
            Console.WriteLine("Source");
            ExcuteSource();
            Console.WriteLine("=======================================================================");
            Console.WriteLine("Refactoring");
            ExcuteRefactoring();
        }

        private static void ExcuteRefactoring()
        {
            var customer = new RefactoringGood.Customer("JN");  
            customer.AddRental(new RefactoringGood.Rental(new RefactoringGood.Movie("movie1", new ChildrenPrice()), 3));
            customer.AddRental(new RefactoringGood.Rental(new RefactoringGood.Movie("movie2", new NewReleasePrice()), 1));
            customer.AddRental(new RefactoringGood.Rental(new RefactoringGood.Movie("movie3", new RegularPrice()), 2));

            var stateMent = customer.Statement();

            Console.WriteLine(stateMent);
        }

        private static void ExcuteSource()
        {
            var customer = new SourceBad.Customer("JN");
            customer.AddRental(new SourceBad.Rental(new SourceBad.Movie("movie1", SourceBad.Movie.CHILDRENS), 3));
            customer.AddRental(new SourceBad.Rental(new SourceBad.Movie("movie2", SourceBad.Movie.NEW_RELEASE), 1));
            customer.AddRental(new SourceBad.Rental(new SourceBad.Movie("movie3", SourceBad.Movie.REGULAR), 2));

           var stateMent= customer.Statement();

            Console.WriteLine(stateMent);
        }
    }
}
