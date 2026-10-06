using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChecklistList:List<Checklist>
    {
        public ChecklistList() { }
        public ChecklistList(IEnumerable<Checklist> list) : base(list) { }
        public ChecklistList(IEnumerable<BaseEntity> list) : base(list.Cast<Checklist>().ToList()) { }
    }
}
