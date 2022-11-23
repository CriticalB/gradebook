// See https://aka.ms/new-console-template for more information
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Test");
            book.GradeAdded += OnGradeAdded; 
            while (true)
            {

                 Console.WriteLine("Please enter a grade between 0 and 100 or press \"q\" to quit.");
                 var input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    bool isNumber = Double.TryParse(input, out double grade);
                    if (input == "q")
                    {
                        break;
                    }
                    if (!isNumber)
                    {
                        book.AddGrade(char.Parse(input));
                    }
                    else
                    {

                        try
                        {
                            book.AddGrade(grade);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);   
                            Console.WriteLine($"Please enter a valid {nameof(grade)}.");   

                        }
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

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }

    }
}