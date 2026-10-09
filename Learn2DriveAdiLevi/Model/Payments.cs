using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Payments:BaseEntity
    {
        private Student idStudent;
        private int amount;
        private DateTime paymentDate;
        private PaymentMethods paymentMethod;

        public Student IdStudent { get => idStudent; set => idStudent = value; }
        public int Amount { get => amount; set => amount = value; }
        public DateTime PaymentDate { get => paymentDate; set => paymentDate = value; }
        public PaymentMethods PaymentMethod { get => paymentMethod; set => paymentMethod = value; }
    }
}
