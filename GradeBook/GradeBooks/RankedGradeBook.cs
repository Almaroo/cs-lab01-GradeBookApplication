using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            var twentyPercent = Students.Count * 20 / 100;

            var moreThanAvg = Students.Count(x => x.AverageGrade > averageGrade);

            if (moreThanAvg >= 4 * twentyPercent)
                return 'F';
            else if (moreThanAvg >= 3 * twentyPercent)
                return 'D';
            else if (moreThanAvg >= 2 * twentyPercent)
                return 'C';
            else if (moreThanAvg >= twentyPercent)
                return 'B';
            else
                return 'A';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            
            base.CalculateStudentStatistics(name);
        }
    }
}