using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StatusList:List<Status>
    {
        public StatusList() { }
        public StatusList(IEnumerable<Status> list) : base(list) { }
        public StatusList(IEnumerable<BaseEntity> list) : base(list.Cast<Status>().ToList()) { }
    }
}
