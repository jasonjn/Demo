using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.Demo
{
    class DateTimeToStringDemo
    {
        public static void test1()
        {
            DateTime time = DateTime.Now;

            // DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();

            //string timeStr = time.ToString("dddd - MM/dd/yyyy" );
            // timeStr = time.ToString("dddd, MMMM dd, yyyy");
            //string pattern=@"\b\d{1,2}\b";

            //string result=  Regex.Replace(timeStr,pattern,"th");









        }




        public static void test2()
        {
            DateTime time = DateTime.Now;



            string timeStr = time.ToString("r");




            Console.WriteLine(timeStr);
        }

        public static void test3()
        {
            Console.WriteLine(DateTime.Now.ToString("D"));
        }


        public static void test4()
        {
            Console.WriteLine(DateTime.Now.ToString("hh:mm tt"));
        }

        public static void test5()
        {


            var electionDate = DateTime.Parse("2015.8.24");
            var person1 = DateTime.Parse("1992.8.23");
            var person2 = DateTime.Parse("1992.8.25");

            Func<DateTime, DateTime, int> getAgeMethod = (ed, dob) =>
            {
                var age = ed.Year - dob.Year;

                if (ed.Month > dob.Month || (ed.Month == dob.Month && ed.Day > dob.Day))
                {
                    age++;
                }
                return age;
            };

            if (getAgeMethod(electionDate, person1) > getAgeMethod(electionDate, person2))
            {
                Console.WriteLine("true");
            }
        }


    }




}
