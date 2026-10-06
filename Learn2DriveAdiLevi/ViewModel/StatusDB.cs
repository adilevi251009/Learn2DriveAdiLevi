using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class StatusDB:BaseDB
    {
        public StatusList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Status";
            StatusList statusList = new StatusList(base.Select());
            return statusList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Status s = entity as Status;
            s.StatusName = reader["StatusName"].ToString();
            base.CreateModel(entity);
            return s;
        }

        public override BaseEntity NewEntity()
        {
            return new Status();
        }

        static private StatusList list = new StatusList();

        public static Status SelectById(int id)
        {
            StatusDB db = new StatusDB();
            list = db.SelectAll();

            Status s = list.Find(item => item.Id == id);
            return s;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Status s = entity as Status;

            if (s != null)
            {
                string sqlStr = $"DELETE FROM Status WHERE id=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", s.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Status s = entity as Status;

            if (s != null)
            {
                string sqlStr = $"INSERT INTO Status (StatusName) VALUES (@statusName)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@statusName", s.StatusName));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Status s = entity as Status;

            if (s != null)
            {
                string sqlStr = $"UPDATE Status SET StatusName=@statusName WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@statusName", s.StatusName));
                command.Parameters.Add(new OleDbParameter("@id", s.Id));
            }
        }
    }
}