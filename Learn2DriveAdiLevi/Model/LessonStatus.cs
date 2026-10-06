using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LessonStatus:BaseEntity
    {
        private string lessonStatusName;

        public string LessonStatusName { get => lessonStatusName; set => lessonStatusName = value; }
    }
}
