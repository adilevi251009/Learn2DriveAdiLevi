using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CarTypeDB:BaseDB
    {
        public CarTypeList SelectAll()
        {
            command.CommandText = $"SELECT * FROM CarTypes";
            CarTypeList carTypeList = new CarTypeList(base.Select());
            return carTypeList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            CarType ct = entity as CarType;
            ct.CarTypeName = reader["CarTypeName"].ToString();
            base.CreateModel(entity);
            return ct;
        }

        public override BaseEntity NewEntity()
        {
            return new CarType();
        }

        static private CarTypeList list = new CarTypeList();

        public static CarType SelectById(int id)
        {
            CarTypeDB db = new CarTypeDB();
            list = db.SelectAll();

            CarType c = list.Find(item => item.Id == id);
            return c;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            CarType c = entity as CarType;
            if (c != null)
            {
                string sqlStr = $"DELETE FROM CarTypes WHERE Id=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            CarType c = entity as CarType;
            if (c != null)
            {
                string sqlStr = $"INSERT INTO CarTypes (CarTypeName) VALUES (@carTypeName)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@carTypeName", c.CarTypeName));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            CarType c = entity as CarType;
            if (c != null)
            {
                string sqlStr = $"UPDATE CarTypes SET CarTypeName=@carTypeName WHERE Id=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@carTypeName", c.CarTypeName));
                command.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }
    }
}