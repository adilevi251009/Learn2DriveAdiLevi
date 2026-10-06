using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LessonsDB:BaseDB
    {
        public LessonsList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Lessons";
            LessonsList lessonsList = new LessonsList(base.Select());
            return lessonsList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Lessons l = entity as Lessons;

            l.IdStudent = StudentDB.SelectById((int)reader["StudentID"]);
            l.IdTeacher = TeacherDB.SelectById((int)reader["TeacherID"]);
            l.LessonDate = Convert.ToDateTime(reader["LessonDate"]);
            l.LessonTime = Convert.ToDateTime(reader["LessonTime"]);
            l.Topics = TopicsDB.SelectById((int)reader["Topics"]);
            l.Notes = reader["Notes"].ToString();
            l.LessonStatus = LessonStatusDB.SelectById((int)reader["LessonStatus"]);

            base.CreateModel(entity);
            return l;
        }

        public override BaseEntity NewEntity()
        {
            return new Lessons();
        }

        static private LessonsList list = new LessonsList();

        public static Lessons SelectById(int id)
        {
            LessonsDB db = new LessonsDB();
            list = db.SelectAll();

            Lessons l = list.Find(item => item.Id == id);
            return l;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Lessons l = entity as Lessons;

            if (l != null)
            {
                string sqlStr = $"DELETE FROM Lessons WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", l.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Lessons l = entity as Lessons;

            if (l != null)
            {
                string sqlStr = $"INSERT INTO Lessons " +
                                $"(StudentID, TeacherID, LessonDate, LessonTime, Topics, Notes, LessonStatus) " +
                                $"VALUES (@studentID, @teacherID, @lessonDate, @lessonTime, @topics, @notes, @lessonStatus)";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@studentID", l.IdStudent.Id));
                command.Parameters.Add(new OleDbParameter("@teacherID", l.IdTeacher.Id));
                command.Parameters.Add(new OleDbParameter("@lessonDate", l.LessonDate));
                command.Parameters.Add(new OleDbParameter("@lessonTime", l.LessonTime));
                command.Parameters.Add(new OleDbParameter("@topics", l.Topics.Id));
                command.Parameters.Add(new OleDbParameter("@notes", l.Notes));
                command.Parameters.Add(new OleDbParameter("@lessonStatus", l.LessonStatus.Id));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Lessons l = entity as Lessons;

            if (l != null)
            {
                string sqlStr = $"UPDATE Lessons SET " +
                                $"StudentID=@studentID, TeacherID=@teacherID, " +
                                $"LessonDate=@lessonDate, LessonTime=@lessonTime, " +
                                $"Topics=@topics, Notes=@notes, LessonStatus=@lessonStatus " +
                                $"WHERE ID=@id";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@studentID", l.IdStudent.Id));
                command.Parameters.Add(new OleDbParameter("@teacherID", l.IdTeacher.Id));
                command.Parameters.Add(new OleDbParameter("@lessonDate", l.LessonDate));
                command.Parameters.Add(new OleDbParameter("@lessonTime", l.LessonTime));
                command.Parameters.Add(new OleDbParameter("@topics", l.Topics.Id));
                command.Parameters.Add(new OleDbParameter("@notes", l.Notes));
                command.Parameters.Add(new OleDbParameter("@lessonStatus", l.LessonStatus.Id));
                command.Parameters.Add(new OleDbParameter("@id", l.Id));
            }
        }
    }
}
