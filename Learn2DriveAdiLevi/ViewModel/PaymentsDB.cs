using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PaymentsDB:BaseDB
    {
        public PaymentsList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Payments";
            PaymentsList paymentsList = new PaymentsList(base.Select());
            return paymentsList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Payments p = entity as Payments;

            p.IdStudent = StudentDB.SelectById((int)reader["StudentID"]);
            p.Amount = Convert.ToInt32(reader["Amount"]);
            p.PaymentDate = Convert.ToDateTime(reader["PaymentDate"]);
            p.PaymentMethod = PaymentMethodsDB.SelectById((int)(reader["PaymentMethod"]));

            base.CreateModel(entity);
            return p;
        }

        public override BaseEntity NewEntity()
        {
            return new Payments();
        }

        static private PaymentsList list = new PaymentsList();

        public static Payments SelectById(int id)
        {
            PaymentsDB db = new PaymentsDB();
            list = db.SelectAll();

            Payments p = list.Find(item => item.Id == id);
            return p;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Payments p = entity as Payments;

            if (p != null)
            {
                string sqlStr = $"DELETE FROM Payments WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", p.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Payments p = entity as Payments;

            if (p != null)
            {
                string sqlStr = $"INSERT INTO Payments (IdStudent, Amount, PaymentDate, PaymentMethod) " +
                                $"VALUES (@idStudent, @amount, @paymentDate, @paymentMethod)";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@idStudent", p.IdStudent.Id));
                command.Parameters.Add(new OleDbParameter("@amount", p.Amount));
                command.Parameters.Add(new OleDbParameter("@paymentDate", p.PaymentDate));
                command.Parameters.Add(new OleDbParameter("@paymentMethod", p.PaymentMethod.Id));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Payments p = entity as Payments;

            if (p != null)
            {
                string sqlStr = $"UPDATE Payments SET IdStudent=@idStudent, Amount=@amount, " +
                                $"PaymentDate=@paymentDate, PaymentMethod=@paymentMethod WHERE ID=@id";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@idStudent", p.IdStudent.Id));
                command.Parameters.Add(new OleDbParameter("@amount", p.Amount));
                command.Parameters.Add(new OleDbParameter("@paymentDate", p.PaymentDate));
                command.Parameters.Add(new OleDbParameter("@paymentMethod", p.PaymentMethod.Id));
                command.Parameters.Add(new OleDbParameter("@id", p.Id));
            }
        }
    }
}