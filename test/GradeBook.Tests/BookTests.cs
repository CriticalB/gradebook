using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void OnlyGrades0To100AreValidButWithProperties()
        {
            InMemoryBook book = new InMemoryBook("");
            book.AddGrade(105.0);
            var grades = book.Grades;

            Assert.True(!grades.Any());

        }

        [Fact]
        public void OnlyGrades0To100AreValid()
        {
            InMemoryBook book = new InMemoryBook("");
            book.AddGrade(105.0);
            var grades = book.GetGrades();

            Assert.True(!grades.Any());

        }
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            InMemoryBook book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //npg
            Statistics result = book.GetStatistics();

            //assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);

        }
    }
}