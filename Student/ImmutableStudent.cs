using System;

namespace Student
{
    public record ImmutableStudent
    {
        public int Id { get; init; }
        public string GivenName { get; init; }
        public string Surname { get; init; }
        public Status Status
        {
            get => GetStatus();
        }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public DateTime GraduationDate { get; init; }
        private Status GetStatus()
        {
            var now = DateTime.Now;
            if (now < StartDate.AddMonths(3) && now < EndDate) return Status.New;
            if (StartDate < now && now < EndDate) return Status.Active;
            if (EndDate == GraduationDate) return Status.Graduated;
            return Status.Dropout;
        }

        public ImmutableStudent(int Id, string GivenName, string Surname, DateTime StartDate, DateTime EndDate, DateTime GraduationDate)
        {
            this.Id = Id;
            this.GivenName = GivenName;
            this.Surname = Surname;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.GraduationDate = GraduationDate;
        }
    }
}