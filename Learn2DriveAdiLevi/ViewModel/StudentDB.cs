using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public class StudentDB:PersonDB
    {
        public StudentList SelectAll()
        {
            command.CommandText = $"SELECT Person.Id, Person.FirstName, Person.LastName, Person.Email, Person.PhoneNumber, " +
                                  $"Person.Pass, Student.StartDate, Student.BirthDate, Student.Status, Student.IdTeacher " +
                                  $"FROM (Person INNER JOIN Student ON Person.Id = Student.Id)";

            StudentList sList = new StudentList(base.Select());
            return sList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Student s = entity as Student;

            s.StartDate = Convert.ToDateTime(reader["StartDate"]);
            s.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
            s.Status = StatusDB.SelectById((int)reader["Status"]);
            s.IdTeacher = TeacherDB.SelectById((int)reader["IdTeacher"]);

            base.CreateModel(entity);
            return s;
        }

        public override BaseEntity NewEntity()
        {
            return new Student();
        }

        static private StudentList list = new StudentList();

        public static Student SelectById(int id)
        {
            StudentDB db = new StudentDB();
            list = db.SelectAll();

            Student s = list.Find(item => item.Id == id);
            return s;
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Student s = entity as Student;

            if (s != null)
            {
                string sqlStr = $"INSERT INTO Student (ID, StartDate, BirthDate, Status, IdTeacher) " +
                                $"VALUES (@id, @startDate, @birthDate, @status, @idTeacher)";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@id", s.Id));
                command.Parameters.Add(new OleDbParameter("@startDate", s.StartDate));
                command.Parameters.Add(new OleDbParameter("@birthDate", s.BirthDate));
                command.Parameters.Add(new OleDbParameter("@status", s.Status.Id));
                command.Parameters.Add(new OleDbParameter("@idTeacher", s.IdTeacher.Id));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Student s = entity as Student;

            if (s != null)
            {
                string sqlStr = $"UPDATE Student SET StartDate=@startDate, BirthDate=@birthDate, " +
                                $"Status=@status, IdTeacher=@idTeacher WHERE ID=@id";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@startDate", s.StartDate));
                command.Parameters.Add(new OleDbParameter("@birthDate", s.BirthDate));
                command.Parameters.Add(new OleDbParameter("@status", s.Status.Id));
                command.Parameters.Add(new OleDbParameter("@idTeacher", s.IdTeacher.Id));
                command.Parameters.Add(new OleDbParameter("@id", s.Id));
            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Student s = entity as Student;

            if (s != null)
            {
                string sqlStr = $"DELETE FROM Student WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", s.Id));
            }
        }

        //public override void Insert(BaseEntity entity)
        //{
        //    BaseEntity reqEntity = this.NewEntity();

        //    if (entity != null && entity.GetType() == reqEntity.GetType())
        //    {
        //        inserted.Add(new ChangeEntity(base.CreateInsertdSQL, entity));
        //        inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
        //    }
        //}

        //public override void Update(BaseEntity entity)
        //{
        //    BaseEntity reqEntity = this.NewEntity();

        //    if (entity != null && entity.GetType() == reqEntity.GetType())
        //    {
        //        updated.Add(new ChangeEntity(base.CreateUpdatedSQL, entity));
        //        updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
        //    }
        //}

        //public override void Delete(BaseEntity entity)
        //{
        //    BaseEntity reqEntity = this.NewEntity();

        //    if (entity != null && entity.GetType() == reqEntity.GetType())
        //    {
        //        deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
        //        deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
        //    }
        //}
    }
}
