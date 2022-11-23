// See https://aka.ms/new-console-template for more information
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Test");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            while (true)
            {

                 Console.WriteLine("Please enter a grade between 0 and 100 or press \"q\" to quit.");
                 var input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    double grade;
                    bool isNumber = Double.TryParse(input, out grade);
                    if (isNumber)
                    {
                        book.AddGrade(grade);
                    }
                    else if (input == "q")
                    {
                        break;
                    }
                    else
                    {
                        throw new ArgumentException($"Please enter a valid grade.");   
                    } 
                }
            } 


            var stats = book.GetStatistics();
            var grades = book.GetGrades();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.Write("The grades are: ");
            Console.Write(string.Join(", ", grades));
            /*Console.Write($"The grades are: ");
            foreach(double grade in grades)
            {
                Console.Write($"{grade}, ");
            }   */

        }


    }
}