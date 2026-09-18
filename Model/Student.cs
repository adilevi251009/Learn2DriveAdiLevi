using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student:Person
    {
        private DateTime startDate;
        private DateTime birthDate;
        private Status status;
        private Teacher idTeacher;

        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public Status Status { get => status; set => status = value; }
        public Teacher IdTeacher { get => idTeacher; set => idTeacher = value; }
    }
}
