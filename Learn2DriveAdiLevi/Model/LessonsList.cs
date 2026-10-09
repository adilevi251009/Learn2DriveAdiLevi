using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LessonsList:List<Lessons>
    {
        public LessonsList() { }
        public LessonsList(IEnumerable<Lessons> list) : base(list) { }
        public LessonsList(IEnumerable<BaseEntity> list) : base(list.Cast<Lessons>().ToList()) { }
    }
}
