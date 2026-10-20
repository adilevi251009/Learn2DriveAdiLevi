using System.Data;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public abstract class BaseDB
    {
        protected static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                    + System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location
                    + "/../../../../../ViewModel/Learn2Drive.accdb");

        protected static OleDbConnection connection;

        public static string Path()
        {
            String[] args = Environment.GetCommandLineArgs();
            string s;
            if (args.Length == 1)
            {
                s = args[0];
            }
            else
            {
                s = args[1];
                s = s.Replace("/service:", "");
            }
            string[] st = s.Split('\\');
            int x = st.Length - 6;
            st[x] = "VViewModel";
            Array.Resize(ref st, x + 1);
            string str = String.Join('\\', st);
            return str;
        }

        public BaseDB()
        {
            connection ??= new OleDbConnection(connectionString);
        }

        public abstract BaseEntity NewEntity();

        // שיטת Select אחת ויחידה, בטוחה שמונעת התנגשויות באמצעות Reader מקומי
        protected List<BaseEntity> Select(string sqlText)
        {
            List<BaseEntity> list = new List<BaseEntity>();

            using (OleDbConnection localConn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand localCmd = new OleDbCommand(sqlText, localConn))
                {
                    try
                    {
                        localConn.Open();
                        using (OleDbDataReader localReader = localCmd.ExecuteReader())
                        {
                            while (localReader.Read())
                            {
                                BaseEntity entity = NewEntity();
                                list.Add(CreateModel(entity, localReader));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + localCmd.CommandText);
                    }
                }
            }
            return list;
        }

        // שיטת עזר וירטואלית לקבלת הנתונים מה-Reader המקומי
        protected virtual BaseEntity CreateModel(BaseEntity entity, OleDbDataReader reader)
        {
            entity.Id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0;
            return entity;
        }

        //// Insert, Update, Delete
        protected abstract void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd);
        public static List<ChangeEntity> deleted = new List<ChangeEntity>();

        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }
        }

        protected abstract void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd);
        public static List<ChangeEntity> inserted = new List<ChangeEntity>();

        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
            }
        }

        protected abstract void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd);
        public static List<ChangeEntity> updated = new List<ChangeEntity>();

        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
            }
        }

        public int SaveChanges()
        {
            int records_affected = 0;

            using (OleDbConnection localConn = new OleDbConnection(connectionString))
            {
                localConn.Open();
                using (OleDbTransaction trans = localConn.BeginTransaction())
                {
                    using (OleDbCommand localCmd = new OleDbCommand())
                    {
                        localCmd.Connection = localConn;
                        localCmd.Transaction = trans;

                        try
                        {
                            foreach (var entity in inserted)
                            {
                                localCmd.Parameters.Clear();
                                entity.CreateSql(entity.Entity, localCmd);
                                records_affected += localCmd.ExecuteNonQuery();

                                localCmd.Parameters.Clear();
                                localCmd.CommandText = "Select @@Identity";
                                entity.Entity.Id = (int)localCmd.ExecuteScalar();
                            }

                            foreach (var entity in updated)
                            {
                                localCmd.Parameters.Clear();
                                entity.CreateSql(entity.Entity, localCmd);
                                records_affected += localCmd.ExecuteNonQuery();
                            }

                            foreach (var entity in deleted)
                            {
                                localCmd.Parameters.Clear();
                                entity.CreateSql(entity.Entity, localCmd);
                                records_affected += localCmd.ExecuteNonQuery();
                            }

                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw new Exception(ex.Message + "\n SQL:" + localCmd.CommandText);
                        }
                        finally
                        {
                            inserted.Clear();
                            updated.Clear();
                            deleted.Clear();
                        }
                    }
                }
            }

            return records_affected;
        }
    }
}




//using static ViewModel.BaseDB;
//using System.Data;
//using System.Data.OleDb;
//using Model;

//namespace ViewModel
//{
//    public abstract class BaseDB
//    {

//        protected static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
//                      + System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location
//                      + "/../../../../../ViewModel/Learn2Drive.accdb");

//        protected static OleDbConnection connection;
//        protected OleDbCommand command;
//        protected OleDbDataReader reader;
//        public static string Path()
//        {
//            String[] args = Environment.GetCommandLineArgs();
//            string s;
//            if (args.Length == 1)
//            {
//                s = args[0];
//            }
//            else
//            {
//                s = args[1];
//                s = s.Replace("/service:", "");
//            }
//            string[] st = s.Split('\\');
//            int x = st.Length - 6;
//            st[x] = "VViewModel";
//            Array.Resize(ref st, x + 1);
//            string str = String.Join('\\', st);
//            return str;
//        }
//        public BaseDB()
//        {

//            connection ??= new OleDbConnection(connectionString);
//            command = new OleDbCommand();
//            command.Connection = connection;
//        }

//        public abstract BaseEntity NewEntity();



//        protected List<BaseEntity> Select()
//        {
//            List<BaseEntity> list = new List<BaseEntity>();

//            // יצירת חיבור ופקודה מקומיים כדי למנוע התנגשויות גלובליות
//            using (OleDbConnection localConn = new OleDbConnection(connection.ConnectionString))
//            {
//                using (OleDbCommand localCmd = new OleDbCommand(command.CommandText, localConn))
//                {
//                    try
//                    {
//                        localConn.Open();
//                        using (OleDbDataReader localReader = localCmd.ExecuteReader())
//                        {
//                            while (localReader.Read())
//                            {
//                                BaseEntity entity = NewEntity();

//                                // קריאה ישירה ובטוחה מתוך ה-Reader המקומי
//                                if (entity is Checklist c)
//                                {
//                                    c.Id = localReader[0] != DBNull.Value ? Convert.ToInt32(localReader[0]) : 0;
//                                    // שאר השדות שלך...
//                                }

//                                list.Add(CreateModel(entity));
//                            }
//                        }
//                    }
//                    catch (Exception e)
//                    {
//                        System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + localCmd.CommandText);
//                    }
//                }
//            }
//            return list;
//        }
//        protected List<BaseEntity> Select()
//        {

//            List<BaseEntity> list = new List<BaseEntity>();
//            try
//            {
//                connection.Close();
//                command.Connection = connection;
//                if (connection.State != ConnectionState.Open)
//                {
//                    connection.Open();
//                }

//                reader = command.ExecuteReader();

//                while (reader.Read())
//                {
//                    BaseEntity entity = NewEntity();
//                    list.Add(CreateModel(entity));
//                }
//            }
//            catch (Exception e)
//            {

//                System.Diagnostics.Debug.WriteLine(
//                    e.Message + "\nSQL:" + command.CommandText);
//            }
//            finally
//            {
//                if (reader != null) reader.Close();
//                if (connection.State == ConnectionState.Open) connection.Close();
//            }
//            return list;
//        }

//        protected virtual BaseEntity CreateModel(BaseEntity entity)
//        {
//            entity.Id = (int)reader["id"];
//            return entity;
//        }


//        //// Insert, Update, Delete
//        protected abstract void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd);
//        public static List<ChangeEntity> deleted = new List<ChangeEntity>();


//        public virtual void Delete(BaseEntity entity)
//        {
//            BaseEntity reqEntity = this.NewEntity();
//            if (entity != null & entity.GetType() == reqEntity.GetType())
//            {
//                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
//            }
//        }

//        protected abstract void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd);
//        public static List<ChangeEntity> inserted = new List<ChangeEntity>();


//        public virtual void Insert(BaseEntity entity)
//        {
//            BaseEntity reqEntity = this.NewEntity();
//            if (entity != null & entity.GetType() == reqEntity.GetType())
//            {
//                inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
//            }
//        }

//        protected abstract void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd);
//        public static List<ChangeEntity> updated = new List<ChangeEntity>();


//        public virtual void Update(BaseEntity entity)
//        {
//            BaseEntity reqEntity = this.NewEntity();
//            if (entity != null & entity.GetType() == reqEntity.GetType())
//            {
//                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
//            }
//        }



//        public int SaveChanges()
//        {
//            OleDbTransaction trans = null;
//            int records_affected = 0;

//            try
//            {
//                command.Connection = connection;

//                if (connection.State != ConnectionState.Open)
//                {
//                    connection.Open();
//                }

//                trans = connection.BeginTransaction();
//                command.Transaction = trans;

//                foreach (var entity in inserted)
//                {
//                    command.Parameters.Clear();
//                    entity.CreateSql(entity.Entity, command); //cmd.CommandText = CreateInsertSQL(entity.Entity);
//                    records_affected += command.ExecuteNonQuery();

//                    command.CommandText = "Select @@Identity";
//                    entity.Entity.Id = (int)command.ExecuteScalar();
//                }

//                foreach (var entity in updated)
//                {
//                    command.Parameters.Clear();
//                    entity.CreateSql(entity.Entity, command);        //cmd.CommandText = CreateUpdateSQL(entity.Entity);
//                    records_affected += command.ExecuteNonQuery();
//                }

//                foreach (var entity in deleted)
//                {
//                    command.Parameters.Clear();
//                    entity.CreateSql(entity.Entity, command);

//                    records_affected += command.ExecuteNonQuery();
//                }

//                trans.Commit();
//            }
//            catch (Exception ex)
//            {
//                trans.Rollback();
//                throw new Exception(ex.Message + "\n SQL:" + command.CommandText);
//            }
//            finally
//            {
//                inserted.Clear();

//                updated.Clear();

//                deleted.Clear();

//                if (connection.State == System.Data.ConnectionState.Open)
//                    connection.Close();
//            }

//            return records_affected;
//        }
//    }
//}
