using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Lessons:BaseEntity
    {
        private Student idStudent;
        private Teacher idTeacher;
        private DateTime lessonDate;
        private DateTime lessonTime;
        private Topics topics;
        private string notes;
        private LessonStatus lessonStatus;

        public Student IdStudent { get => idStudent; set => idStudent = value; }
        public Teacher IdTeacher { get => idTeacher; set => idTeacher = value; }
        public DateTime LessonDate { get => lessonDate; set => lessonDate = value; }
        public DateTime LessonTime { get => lessonTime; set => lessonTime = value; }
        public Topics Topics { get => topics; set => topics = value; }
        public string Notes { get => notes; set => notes = value; }
        public LessonStatus LessonStatus { get => lessonStatus; set => lessonStatus = value; }
    }
}
