namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;
        public char Letter;
        public int Count;

        public Statistics()
        {
            Average = 0.0;
            High = 0.0;
            Low = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
            Count = 0;

        }
        public void OnGradeAddedDoStats(object sender, GradeAddedEventArgs gradeAdded)
        {
            double grade = gradeAdded.Grade;
            Count++;
            Average = (Average * (Count - 1) + grade) / Count;
             
            High = Math.Max(grade, High);
            Low = Math.Min(grade, Low);

            switch(Average)
            {
                case var d when d >= 90.0:
                    Letter = 'A';
                    break;
            
                case var d when d >= 80.0:
                    Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    Letter = 'D';
                    break;

                default:
                    Letter = 'F';
                    break;
            }
        } 
    
        
    }
}