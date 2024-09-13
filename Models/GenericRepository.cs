using Dapper;
using Medi_Connect.Models;
using Medi_Connect.Models.Interfaces;
using Microsoft.Data.SqlClient;

namespace Generic_Medi_Connect.Models.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly string _connectionString;

        public GenericRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(TEntity entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var tableName = typeof(TEntity).Name;
                var properties = typeof(TEntity).GetProperties().Where(p => p.Name != "Id");

                var columnNames = string.Join(",", properties.Select(p => p.Name));
                var parameterNames = string.Join(",", properties.Select(p => "@" + p.Name));

                var query = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames});";
                
                // dapper
                connection.Execute(query, entity);

                //using (var command = new SqlCommand(query, connection))
                //{

                //    //foreach (var property in properties)
                //    //{
                //    //    command.Parameters.AddWithValue("@" + property.Name, property.GetValue(entity));
                //    //}

                //    //command.ExecuteNonQuery();
                //}
            }
        }

        public TEntity GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var tableName = typeof(TEntity).Name;
                var primaryKey = "Id";

                var query = $"SELECT * FROM {tableName} WHERE {primaryKey} = @Id;";

                return connection.QuerySingleOrDefault<TEntity>(query, new { Id = id });

                //using (var command = new SqlCommand(query, connection))
                //{
                //    command.Parameters.AddWithValue("@Id", id);
                //    var reader = command.ExecuteReader();
                //    if (reader.Read())
                //    {
                //        return MapReaderToObject(reader);
                //    }
                //    return null;
                //}
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var tableName = typeof(TEntity).Name;

                var query = $"SELECT * FROM {tableName};";

                return connection.Query<TEntity>(query);
                //using (var command = new SqlCommand(query, connection))
                //{
                //    var reader = command.ExecuteReader();
                //    var entities = new List<TEntity>();
                //    while (reader.Read())
                //    {
                //        entities.Add(MapReaderToObject(reader));
                //    }
                //    return entities;
                //}
            }
        }

        public void Update(TEntity entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var tableName = typeof(TEntity).Name;
                var primaryKey = "Id";

                var properties = typeof(TEntity).GetProperties().Where(p => p.Name != primaryKey);

                var setClause = string.Join(",", properties.Select(p => $"{p.Name} = @{p.Name}"));
                var query = $"UPDATE {tableName} SET {setClause} WHERE {primaryKey} = @{primaryKey};";
                
                connection.Execute(query, entity);
                //using (var command = new SqlCommand(query, connection))
                //{
                //    foreach (var property in properties)
                //    {
                //        command.Parameters.AddWithValue("@" + property.Name, property.GetValue(entity));
                //    }
                //    command.Parameters.AddWithValue("@" + primaryKey, typeof(TEntity).GetProperty(primaryKey).GetValue(entity));

                //    command.ExecuteNonQuery();
                //}
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var tableName = typeof(TEntity).Name;
                var primaryKey = "Id";

                var query = $"DELETE FROM {tableName} WHERE {primaryKey} = @Id;";
                connection.Execute(query, new { Id = id });
                //using (var command = new SqlCommand(query, connection))
                //{
                //    command.Parameters.AddWithValue("@Id", id);
                //    command.ExecuteNonQuery();
                //}
            }
        }

        //private TEntity MapReaderToObject(SqlDataReader reader)
        //{
        //    var entity = Activator.CreateInstance<TEntity>();
        //    foreach (var property in typeof(TEntity).GetProperties())
        //    {
        //        property.SetValue(entity, reader[property.Name]);
        //        //if (property.Name != "Id")
        //        //{
        //        //    property.SetValue(entity, reader[property.Name]);
        //        //}
        //    }
        //    return entity;
        //}


        //public void Add(Laboratorian l)
        //{
        //    throw new NotImplementedException();
        //}
    }

}




//using Medi_Connect.Models.Interfaces;
//using Microsoft.Data.SqlClient;

//namespace Medi_Connect.Models
//{
//    public class GenericRepository<TEntity> : IRepository<TEntity>
//    {
//        private readonly string connectionString;

//        public GenericRepository(string c)
//        {
//            connectionString = c;
//        }

//        public void Add(TEntity entity)
//        {
//            //get table anme
//            var tablename = typeof(TEntity).Name;

//            var properties =
//                typeof(TEntity).GetProperties().Where(p => p.Name != "Id");
//            var columnNames = string.Join(",", properties.Select(x => x.Name));
//            var parameterName =
//                string.Join(",", properties.Select(y => "@" + y.Name));

//            var query = $"insert into {tablename} ({columnNames}) values({parameterName}) ";

//            using (var connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                var comm = new SqlCommand(query, connection);
//                foreach (var prop in properties)
//                {
//                    comm.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(entity));
//                }
//                comm.ExecuteNonQuery();
//            }
//        }

//        public void Update(TEntity entity)
//        {
//            var tableName = typeof(TEntity).Name;
//            var primaryKey = "Id";
//            var properties = typeof(TEntity).GetProperties().Where(x => x.Name != primaryKey);

//            var setClause = string.Join(",", properties.Select(a => $"{a.Name}=@{a.Name}"));

//            var query = $"update {tableName} set {setClause} where {primaryKey}=@{primaryKey} ";

//            using (var connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                var comm = new SqlCommand(query, connection);
//                foreach (var prop in properties)
//                {
//                    comm.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(entity));
//                }
//                comm.Parameters.AddWithValue("@" + primaryKey, typeof(TEntity).GetProperty(primaryKey).GetValue(entity));
//                comm.ExecuteNonQuery();
//            }
//        }

//        public void Delete(int id)
//        {
//            var tablename = typeof(TEntity).Name;

//            var query = $"delete from {tablename} where id = @id";

//            using (var connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                SqlCommand cmd = new SqlCommand(query, connection);
//                cmd.Parameters.AddWithValue("@id", id);
//                cmd.ExecuteNonQuery();
//            }
//        }

//        public TEntity? Get(int id)
//        {
//            var tablename = typeof(TEntity).Name;

//            var query = $"select * from {tablename} where id = @id";

//            using (var connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                SqlCommand cmd = new SqlCommand(query, connection);
//                cmd.Parameters.AddWithValue("@id", id);
//                var reader = cmd.ExecuteReader();
//                if (reader.Read())
//                {
//                    var entity = Activator.CreateInstance<TEntity>();
//                    foreach (var prop in typeof(TEntity).GetProperties())
//                    {
//                        prop.SetValue(entity, reader[prop.Name]);
//                    }
//                    return entity;
//                }
//            }
//            return default;
//        }

//        public List<TEntity> Get()
//        {
//            var tablename = typeof(TEntity).Name;

//            var query = $"select * from {tablename}";

//            using (var connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                SqlCommand cmd = new SqlCommand(query, connection);
//                var reader = cmd.ExecuteReader();
//                var entities = new List<TEntity>();
//                while (reader.Read())
//                {
//                    var entity = Activator.CreateInstance<TEntity>();
//                    foreach (var prop in typeof(TEntity).GetProperties())
//                    {
//                        prop.SetValue(entity, reader[prop.Name]);
//                    }
//                    entities.Add(entity);
//                }
//                return entities;
//            }
//        }
//    }
//}
