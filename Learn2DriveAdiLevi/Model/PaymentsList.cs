using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PaymentsList:List<Payments>
    {
        public PaymentsList() { }
        public PaymentsList(IEnumerable<Payments> list) : base(list) { }
        public PaymentsList(IEnumerable<BaseEntity> list) : base(list.Cast<Payments>().ToList()) { }
    }
}
