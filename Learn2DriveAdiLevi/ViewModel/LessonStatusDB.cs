using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LessonStatusDB:BaseDB
    {
        public LessonStatusList SelectAll()
        {
            command.CommandText = $"SELECT * FROM LessonStatus";
            LessonStatusList lessonStatusList = new LessonStatusList(base.Select());
            return lessonStatusList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            LessonStatus ls = entity as LessonStatus;
            ls.LessonStatusName = reader["LessonStatusName"].ToString();
            base.CreateModel(entity);
            return ls;
        }

        public override BaseEntity NewEntity()
        {
            return new LessonStatus();
        }

        static private LessonStatusList list = new LessonStatusList();

        public static LessonStatus SelectById(int id)
        {
            LessonStatusDB db = new LessonStatusDB();
            list = db.SelectAll();

            LessonStatus ls = list.Find(item => item.Id == id);
            return ls;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            LessonStatus ls = entity as LessonStatus;
            if (ls != null)
            {
                string sqlStr = $"DELETE FROM LessonStatus WHERE Id=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", ls.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            LessonStatus ls = entity as LessonStatus;
            if (ls != null)
            {
                string sqlStr = $"INSERT INTO LessonStatus (LessonStatus) VALUES (@lessonStatus)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@lessonStatus", ls.LessonStatusName));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            LessonStatus ls = entity as LessonStatus;
            if (ls != null)
            {
                string sqlStr = $"UPDATE LessonStatus SET LessonStatus=@lessonStatus WHERE Id=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@lessonStatus", ls.LessonStatusName));
                command.Parameters.Add(new OleDbParameter("@id", ls.Id));
            }
        }
    }
}