using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CarTypeList:List<CarType>
    {
        public CarTypeList() { }
        public CarTypeList(IEnumerable<CarType> list):base(list) { }
        public CarTypeList(IEnumerable<BaseEntity> list) : base(list.Cast<CarType>().ToList()) { }
    }
}
