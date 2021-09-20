using System;

namespace Student
{
    public class Student
    {
        public int Id { get; init; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public Status Status
        {
            get => GetStatus();
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime GraduationDate { get; set; }

        public Student()
        {
        }

        private Status GetStatus()
        {
            var now = DateTime.Now;
            if (now < StartDate.AddMonths(3) && now < EndDate) return Status.New;
            if (StartDate < now && now < EndDate) return Status.Active;
            if (EndDate == GraduationDate) return Status.Graduated;
            return Status.Dropout;
        }

        public override string ToString()
        {
            return $"Student with id: {Id}, named {GivenName} {Surname} has status {Status}\nStart: {StartDate.ToString()}\nEnd: {EndDate.ToString()}\nGraduation: {GraduationDate.ToString()}";
        }
    }

    public enum Status
    {
        New,
        Active,
        Dropout,
        Graduated
    }
}
