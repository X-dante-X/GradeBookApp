using GradeBook.Enums;
using System.Linq;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires a minimum of 5 students to work");
            }

            int rank = Students.OrderByDescending(s => s.AverageGrade)
                                           .Select((s, i) => new { Grade = s.AverageGrade, Rank = i + 1 })
                                           .Where(s => s.Grade > averageGrade)
                                           .Count();

            double percentage = (double)rank / Students.Count;

            if (percentage < 0.2)
            {
                return 'A';
            }
            else if (percentage < 0.4)
            {
                return 'B';
            }
            else if (percentage < 0.6)
            {
                return 'C';
            }
            else if (percentage < 0.8)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
