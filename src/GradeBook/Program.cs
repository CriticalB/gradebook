// See https://aka.ms/new-console-template for more information
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Test2");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += book.stats.OnGradeAddedDoStats;
            EnterGrades(book);

            var stats = book.stats;

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.Write("The grades are: ");
            //Console.Write(string.Join(", ", grades));
            /*Console.Write($"The grades are: ");
            foreach(double grade in grades)
            {
                Console.Write($"{grade}, ");
            }   */

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {

                Console.WriteLine("Please enter a grade between 0 and 100 or press \"q\" to quit.");
                var input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    if (input == "q")
                    {
                        break;
                    }
                
                bool isNumber = Double.TryParse(input, out double grade);
                bool isChar = Char.TryParse(input, out char letterGrade);

                    if (isChar || isNumber)
                    {
                        book.AddGrade(letterGrade);
                    }
                    else
                    {
                        Console.WriteLine($"Please enter a valid {nameof(grade)}.");
                    }
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }

    }
}