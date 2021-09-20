using System;
using Student;
using Xunit;

namespace Student.Tests
{
    public class StudentTests
    {
        [Fact]
        public void Student_enrolled_1_month_ago_status_new()
        {
            var student = new Student();
            student.StartDate = DateTime.Now.AddMonths(-1);
            student.EndDate = DateTime.Now.AddYears(3);
            student.GraduationDate = student.EndDate;
            Assert.Equal(Status.New, student.Status);
        }

        [Fact]
        public void Student_enrolled_4_month_ago_status_active()
        {
            var student = new Student();
            student.StartDate = DateTime.Now.AddMonths(-4);
            student.EndDate = DateTime.Now.AddYears(3);
            student.GraduationDate = student.EndDate;
            Assert.Equal(Status.Active, student.Status);
        }

        [Fact]
        public void Student_enrolled_2_month_ago_stopped_1_month_ago_status_dropout()
        {
            var student = new Student();
            student.StartDate = DateTime.Now.AddMonths(-2);
            student.EndDate = DateTime.Now.AddMonths(-1);
            student.GraduationDate = DateTime.Now.AddYears(3);
            Assert.Equal(Status.Dropout, student.Status);
        }

        [Fact]
        public void Student_graduation_date_equals_end_date_status_graduated()
        {
            var student = new Student();
            student.StartDate = DateTime.Now.AddYears(-6);
            student.EndDate = DateTime.Now.AddYears(-3);
            student.GraduationDate = student.EndDate;
            Assert.Equal(Status.Graduated, student.Status);
        }

        [Fact]
        public void Student_ToString_prints_information()
        {
            var student = new Student();
            student.GivenName = "Philip";
            student.Surname = "Stender";

            var expected = $"Student with id: 0, named Philip Stender has status Graduated{Environment.NewLine}Start: 01/01/0001 00:00:00{Environment.NewLine}End: 01/01/0001 00:00:00{Environment.NewLine}Graduation: 01/01/0001 00:00:00";
            var output = student.ToString();

            Assert.Equal(expected, output);
        }


    }
}
