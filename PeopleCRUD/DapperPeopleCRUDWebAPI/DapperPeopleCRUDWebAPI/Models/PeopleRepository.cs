using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPeopleCRUDWebAPI.Models
{
    public class PeopleRepository
    {
        private string connectionString = "";

        public PeopleRepository()
        {
            connectionString = @"Server=DESKTOP-R37CV9V\SQLEXPRESS;Database=DapperDb;Trusted_Connection=True;";
        }

        public IDbConnection connection 
        {
            get { return new SqlConnection(connectionString);  }
        }

        public void Add(People person)
        {
            using (IDbConnection db = connection)
            {
                string insertQuery = @"Insert into People(Name, Age) Values (@Name, @Age);";
                db.Open();
                db.Execute(insertQuery, person);
            }
        }

        //GET ALL
        public IEnumerable<People> GetAll()
        {
            using (IDbConnection db = connection)
            {
                string selectQuery = @"Select * from People;";
                db.Open();
                return db.Query<People>(selectQuery);
            }
        }

        //GET ONE 
        public People GetOne(int id)
        {
            using (IDbConnection db = connection)
            {
                string selectQueryOne = @"Select * from People where PersonId = @Id;";
                db.Open();
                return db.Query<People>(selectQueryOne, new { Id = id }).FirstOrDefault();
            }
        }

        //DELETE
        public void Delete(int id)
        {
            using (IDbConnection db = connection)
            {
                string deleteQuery = @"DELETE FROM People where PersonId = @Id;";
                db.Open();
                db.Execute(deleteQuery, new { Id = id });
            }
        }

        //DELETE
        public void UPDATE(People Person)
        {
            using (IDbConnection db = connection)
            {
                string updateQuery = @"UPDATE People SET Name=@Name,Age=@Age Where PersonId = @PersonId";
                db.Open();
                db.Query(updateQuery,Person);
            }
        }
    }
}
