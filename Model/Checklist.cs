using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Checklist:BaseEntity
    {
        private Student idStudent;
        private Topics topic;
        private bool isDone;

        public Student IdStudent { get => idStudent; set => idStudent = value; }
        public Topics Topic { get => topic; set => topic = value; }
        public bool IsDone { get => isDone; set => isDone = value; }
    }
}
