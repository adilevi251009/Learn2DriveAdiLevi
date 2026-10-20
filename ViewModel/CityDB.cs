using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;

namespace ViewModel
{
    public class CityDB : BaseDB
    {
        public CityList SelectAll()
        {
            string sql = "SELECT * FROM City";
            return new CityList(base.Select(sql));
        }

        protected override BaseEntity CreateModel(BaseEntity entity, OleDbDataReader reader)
        {
            City ct = entity as City;
            if (ct != null)
            {
                base.CreateModel(entity, reader);
                ct.CityName = reader["CityName"] != DBNull.Value ? reader["CityName"].ToString() : string.Empty;
            }
            return ct;
        }

        public override BaseEntity NewEntity()
        {
            return new City();
        }

        public static City SelectById(int id)
        {
            CityDB db = new CityDB();
            CityList list = db.SelectAll();
            return list.Find(item => item.Id == id);
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City c = entity as City;
            if (c != null)
            {
                cmd.CommandText = "DELETE FROM City WHERE Id=@id";
                cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City c = entity as City;
            if (c != null)
            {
                cmd.CommandText = "INSERT INTO City (CityName) VALUES (@cityName)";
                cmd.Parameters.Add(new OleDbParameter("@cityName", c.CityName));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City c = entity as City;
            if (c != null)
            {
                cmd.CommandText = "UPDATE City SET CityName=@cityName WHERE Id=@id";
                cmd.Parameters.Add(new OleDbParameter("@cityName", c.CityName));
                cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }
    }
}
//using Model;
//using System;
//using System.Collections.Generic;
//using System.Data.OleDb;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ViewModel
//{
//    public class CityDB : BaseDB
//    {
//        public CityList SelectAll()
//        {
//            command.CommandText = $"SELECT * FROM City";
//            CityList cityList = new CityList(base.Select());
//            return cityList;
//        }

//        protected override BaseEntity CreateModel(BaseEntity entity)
//        {
//            City ct = entity as City;
//            ct.CityName = reader["CityName"].ToString();
//            base.CreateModel(entity);
//            return ct;
//        }

//        public override BaseEntity NewEntity()
//        {
//            return new City();
//        }

//        static private CityList list = new CityList();


//        public static City SelectById(int id)
//        {
//            CityDB db = new CityDB();
//            list = db.SelectAll();

//            City g = list.Find(item => item.Id == id);
//            return g;
//        }


//        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
//        {
//            City c = entity as City;
//            if (c != null)
//            {
//                string sqlStr = $"DELETE FROM City where Id=@id";

//                command.CommandText = sqlStr;
//                command.Parameters.Add(new OleDbParameter("@id", c.Id));
//            }
//        }
//        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
//        {
//            City c = entity as City;
//            if (c != null)
//            {
//                string sqlStr = $"Insert INTO City (CityName) VALUES (@cityName)";

//                command.CommandText = sqlStr;
//                command.Parameters.Add(new OleDbParameter("@cityName", c.CityName));
//            }
//        }

//        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
//        {
//            City c = entity as City;
//            if (c != null)
//            {
//                string sqlStr = $"UPDATE City SET CityName=@cityName WHERE Id=@id";

//                command.CommandText = sqlStr;
//                command.Parameters.Add(new OleDbParameter("@cityName", c.CityName));
//                command.Parameters.Add(new OleDbParameter("@id", c.Id));
//            }
//        }
//    }
//}
