using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PersonDB: BaseDB
    {
        public PersonList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Person";
            PersonList personList = new PersonList(base.Select());
            return personList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Person p = entity as Person;

            p.FirstName = reader["FirstName"].ToString();
            p.LastName = reader["LastName"].ToString();
            p.PhoneNumber = reader["PhoneNumber"].ToString();
            p.Email = reader["Email"].ToString();
            p.Pass = reader["Pass"].ToString();

            base.CreateModel(entity);
            return p;
        }

        public override BaseEntity NewEntity()
        {
            return new Person();
        }

        static private PersonList list = new PersonList();

        public static Person SelectById(int id)
        {
            PersonDB db = new PersonDB();
            list = db.SelectAll();

            Person p = list.Find(item => item.Id == id);
            return p;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Person p = entity as Person;

            if (p != null)
            {
                string sqlStr = $"DELETE FROM Person WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", p.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Person p = entity as Person;

            if (p != null)
            {
                string sqlStr = $"INSERT INTO Person (FirstName, LastName, PhoneNumber, Email, Pass) VALUES (@firstName, @lastName, @phoneNumber, @email, @pass)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@firstName", p.FirstName));
                command.Parameters.Add(new OleDbParameter("@lastName", p.LastName));
                command.Parameters.Add(new OleDbParameter("@phoneNumber", p.PhoneNumber));
                command.Parameters.Add(new OleDbParameter("@email", p.Email));
                command.Parameters.Add(new OleDbParameter("@pass", p.Pass));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Person p = entity as Person;

            if (p != null)
            {
                string sqlStr = $"UPDATE Person SET FirstName=@firstName, LastName=@lastName, PhoneNumber=@phoneNumber, Email=@email, Pass=@pass WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@firstName", p.FirstName));
                command.Parameters.Add(new OleDbParameter("@lastName", p.LastName));
                command.Parameters.Add(new OleDbParameter("@phoneNumber", p.PhoneNumber));
                command.Parameters.Add(new OleDbParameter("@email", p.Email));
                command.Parameters.Add(new OleDbParameter("@id", p.Id));
                command.Parameters.Add(new OleDbParameter("@pass", p.Pass));
            }
        }
    }
}
