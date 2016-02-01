using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.RefactoringDemo.SourceBad
{
  public  class Movie
    {
        public Movie(string title,int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }    
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        public const int CHILDRENS = 2;

        public string Title { get; private set; }

        public int PriceCode { get; set; }
    }
}
