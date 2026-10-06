using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PaymentMethods:BaseEntity
    {
        private string methodName;

        public string MethodName { get => methodName; set => methodName = value; }
    }
}
