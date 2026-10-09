using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TopicsList:List<Topics>
    {
        public TopicsList() { }
        public TopicsList(IEnumerable<Topics> list) : base(list) { }
        public TopicsList(IEnumerable<BaseEntity> list) : base(list.Cast<Topics>().ToList()) { }
    }
}
