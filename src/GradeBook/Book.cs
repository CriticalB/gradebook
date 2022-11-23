namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }
        public List<double> Grades 
        { 
            get {return grades;}
            set {grades = value;}            
        }

        public string Name
        {
            get;
            set;
        }
        
        public List<double> GetGrades()
        {
            return grades;
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90.0);
                    break;
                case 'B':
                    AddGrade(80.0);
                    break;
                case 'C':
                    AddGrade(70.0);
                    break;
                case 'D':
                    AddGrade(60.0);
                    break;
                default:
                    AddGrade(0.0);
                    break;
            }
        }
        public void AddGrade(double grade)
        {
            if (0 <= grade && 100 >= grade)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid grade");
            }
            
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (double grade in grades)
            {
                result.High = Math.Max(result.High, grade);
                result.Low = Math.Min(result.Low, grade);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
            
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;

            }
            return result;
        }

        readonly string category = "Science";
        private List<double> grades;
        public string name;
    }
}
