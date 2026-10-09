using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LessonStatusList:List<LessonStatus>
    {
        public LessonStatusList() { }
        public LessonStatusList(IEnumerable<LessonStatus> list) : base(list) { }
        public LessonStatusList(IEnumerable<BaseEntity> list) : base(list.Cast<LessonStatus>().ToList()) { }
    }
}
