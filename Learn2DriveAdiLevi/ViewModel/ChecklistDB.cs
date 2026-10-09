using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ChecklistDB:BaseDB
    {
        public ChecklistList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Checklist";
            ChecklistList checklistList = new ChecklistList(base.Select());
            return checklistList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Checklist c = entity as Checklist;

            c.IdStudent = StudentDB.SelectById((int)reader["StudentID"]);
            c.Topic = TopicsDB.SelectById((int)reader["Topic"]);
            c.IsDone = (bool)reader["IsDone"];

            base.CreateModel(entity);
            return c;
        }

        public override BaseEntity NewEntity()
        {
            return new Checklist();
        }

        static private ChecklistList list = new ChecklistList();

        public static Checklist SelectById(int id)
        {
            ChecklistDB db = new ChecklistDB();
            list = db.SelectAll();

            Checklist c = list.Find(item => item.Id == id);
            return c;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Checklist c = entity as Checklist;

            if (c != null)
            {
                string sqlStr = $"DELETE FROM Checklist WHERE id=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Checklist c = entity as Checklist;

            if (c != null)
            {
                string sqlStr = $"INSERT INTO Checklist (IdStudent, Topic, IsDone) VALUES (@idStudent, @topic, @isDone)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@idStudent", c.IdStudent.Id));
                command.Parameters.Add(new OleDbParameter("@topic", c.Topic.Id));
                command.Parameters.Add(new OleDbParameter("@isDone", c.IsDone));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Checklist c = entity as Checklist;

            if (c != null)
            {
                string sqlStr = $"UPDATE Checklist SET IdStudent=@idStudent, Topic=@topic, IsDone=@isDone WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@idStudent", c.IdStudent.Id));
                command.Parameters.Add(new OleDbParameter("@topic", c.Topic.Id));
                command.Parameters.Add(new OleDbParameter("@isDone", c.IsDone));
                command.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }
    }
}
