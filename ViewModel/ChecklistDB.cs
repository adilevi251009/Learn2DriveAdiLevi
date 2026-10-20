using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ChecklistDB : BaseDB
    {
        public ChecklistList SelectAll()
        {
            string sqlText = "SELECT * FROM Checklist";
            ChecklistList checklistList = new ChecklistList(base.Select(sqlText));
            return checklistList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity, OleDbDataReader reader)
        {
            Checklist c = (Checklist)base.CreateModel(entity, reader);
            c.IdStudent = StudentDB.SelectById(Convert.ToInt32(reader["StudentID"]));
            c.Topic = TopicsDB.SelectById(Convert.ToInt32(reader["Topic"]));
            c.IsDone = Convert.ToBoolean(reader["IsDone"]);
            return c;
        }

        public override BaseEntity NewEntity()
        {
            return new Checklist();
        }

        private static ChecklistList list = new ChecklistList();

        public static Checklist SelectById(int id)
        {
            ChecklistDB db = new ChecklistDB();
            list = db.SelectAll();

            Checklist c = list.Find(item => item.Id == id);
            return c;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Checklist c = (Checklist)entity;

            cmd.CommandText = "DELETE FROM Checklist WHERE Id = @id";
            cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Checklist c = (Checklist)entity;

            cmd.CommandText = "INSERT INTO Checklist (StudentID, Topic, IsDone) " +
                                "VALUES (@idStudent, @topic, @isDone)";

            cmd.Parameters.Add(new OleDbParameter("@idStudent", c.IdStudent.Id));
            cmd.Parameters.Add(new OleDbParameter("@topic", c.Topic.Id));
            cmd.Parameters.Add(new OleDbParameter("@isDone", c.IsDone));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Checklist c = (Checklist)entity;

            cmd.CommandText = "UPDATE Checklist SET StudentID = @idStudent, " +
                "Topic = @topic, IsDone = @isDone WHERE ID = @id";

            cmd.Parameters.Add(new OleDbParameter("@idStudent", c.IdStudent.Id));
            cmd.Parameters.Add(new OleDbParameter("@topic", c.Topic.Id));
            cmd.Parameters.Add(new OleDbParameter("@isDone", c.IsDone));
            cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
        }
    }
}
