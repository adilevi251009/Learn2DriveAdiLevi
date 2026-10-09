using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TopicsDB:BaseDB
    {
        public TopicsList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Topics";
            TopicsList topicsList = new TopicsList(base.Select());
            return topicsList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Topics t = entity as Topics;

            t.TopicName = reader["TopicName"].ToString();

            base.CreateModel(entity);
            return t;
        }

        public override BaseEntity NewEntity()
        {
            return new Topics();
        }

        static private TopicsList list = new TopicsList();

        public static Topics SelectById(int id)
        {
            TopicsDB db = new TopicsDB();
            list = db.SelectAll();

            Topics t = list.Find(item => item.Id == id);
            return t;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Topics t = entity as Topics;

            if (t != null)
            {
                string sqlStr = $"DELETE FROM Topics WHERE id=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", t.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Topics t = entity as Topics;

            if (t != null)
            {
                string sqlStr = $"INSERT INTO Topics (TopicName) VALUES (@topicName)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@topicName", t.TopicName));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Topics t = entity as Topics;

            if (t != null)
            {
                string sqlStr = $"UPDATE Topics SET TopicName=@topicName WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@topicName", t.TopicName));
                command.Parameters.Add(new OleDbParameter("@id", t.Id));
            }
        }
    }
}
