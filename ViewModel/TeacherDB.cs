using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TeacherDB:PersonDB
    {
        public TeacherList SelectAll()
        {
            command.CommandText = $"SELECT Person.Id, Person.FirstName, Person.LastName, Person.Email, " +
                                  $"Person.PhoneNumber, Person.Pass, Teacher.City, Teacher.CarType, Teacher.PricePerLesson, Teacher.IdManager " +
                                  $"FROM (Person INNER JOIN Teacher ON Person.Id = Teacher.Id)";
            TeacherList tList = new TeacherList(base.Select());
            return tList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Teacher t = entity as Teacher;

            t.City = CityDB.SelectById((int)reader["City"]);
            t.CarType = CarTypeDB.SelectById((int)reader["CarType"]);
            t.PricePerLesson = Convert.ToInt32(reader["PricePerLesson"]);
            t.IdManager = ManagerDB.SelectById((int)reader["IdManager"]);

            base.CreateModel(entity);
            return t;
        }

        public override BaseEntity NewEntity()
        {
            return new Teacher();
        }

        static private TeacherList list = new TeacherList();

        public static Teacher SelectById(int id)
        {
            TeacherDB db = new TeacherDB();
            list = db.SelectAll();

            Teacher t = list.Find(item => item.Id == id);
            return t;
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Teacher t = entity as Teacher;

            if (t != null)
            {
                string sqlStr = $"INSERT INTO Teacher (Id, City, CarType, PricePerLesson, IdManager) " +
                                $"VALUES (@id, @city, @carType, @pricePerLesson, @idManager)";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@id", t.Id));
                command.Parameters.Add(new OleDbParameter("@city", t.City.Id));
                command.Parameters.Add(new OleDbParameter("@carType", t.CarType.Id));
                command.Parameters.Add(new OleDbParameter("@pricePerLesson", t.PricePerLesson));
                command.Parameters.Add(new OleDbParameter("@idManager", t.IdManager.Id));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Teacher t = entity as Teacher;

            if (t != null)
            {
                string sqlStr = $"UPDATE Teacher SET City=@city, CarType=@carType, " +
                                $"PricePerLesson=@pricePerLesson, IdManager=@idManager WHERE Id=@id";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@city", t.City.Id));
                command.Parameters.Add(new OleDbParameter("@carType", t.CarType.Id));
                command.Parameters.Add(new OleDbParameter("@pricePerLesson", t.PricePerLesson));
                command.Parameters.Add(new OleDbParameter("@idManager", t.IdManager.Id));
                command.Parameters.Add(new OleDbParameter("@id", t.Id));
            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Teacher t = entity as Teacher;

            if (t != null)
            {
                string sqlStr = $"DELETE FROM Teacher WHERE Id=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", t.Id));
            }
        }

        public override void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();

            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(base.CreateInsertdSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
            }
        }

        public override void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();

            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(base.CreateUpdatedSQL, entity));
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
            }
        }

        public override void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();

            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
            }
        }
    }
}