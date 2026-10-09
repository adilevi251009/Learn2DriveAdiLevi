using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PaymentMethodsList:List<PaymentMethods>
    {
        public PaymentMethodsList() { }
        public PaymentMethodsList(IEnumerable<PaymentMethods> list) : base(list) { }
        public PaymentMethodsList(IEnumerable<BaseEntity> list) : base(list.Cast<PaymentMethods>().ToList()) { }
    }
}
