namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, GradeAddedEventArgs args);

    public class GradeAddedEventArgs : EventArgs
    {
        public GradeAddedEventArgs(double grade)
        {
            Grade = grade;
        }
        public double Grade { get; set; }
    }

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            Name = name;
        }
        public Statistics stats = new Statistics();
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                using(StreamWriter writer = File.AppendText($"{Name}.txt"))
                {
                    writer.WriteLine(grade.ToString());
                    if(GradeAdded != null)
                    {                       
                        GradeAdded(this, new GradeAddedEventArgs(grade));
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid grade.");
            }
        }
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
 
        public Statistics stats = new Statistics();
        public List<double> Grades 
        { 
            get {return grades;}
            set {grades = value;}            
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
        public override void AddGrade(double grade)
        {
            if (0 <= grade && 100 >= grade)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new GradeAddedEventArgs(grade));
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid grade");
            }
            
        }

        public override event GradeAddedDelegate GradeAdded;

        private List<double> grades;
    }
}
