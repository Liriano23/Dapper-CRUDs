using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCRUDWebAPI.Models
{
    public class ProductRepository
    {
        private string connectinString = "";

        public ProductRepository()
        {
            connectinString = @"Server=DESKTOP-R37CV9V\SQLEXPRESS;Database=DapperDb;Trusted_Connection=True;"; ;
        }

        public IDbConnection Connection 
        {
            get { return new SqlConnection(connectinString); }
        }

        //GET ALL 
        public IEnumerable<Products> GetAll()
        {
            using (IDbConnection db = Connection)
            {
                string selectQuery = @"Select * from Products;";
                db.Open();
                return db.Query<Products>(selectQuery);
            }
        }

        //GET ONE PRODUCT
        public Products GetOne(int id)
        {
            using (IDbConnection db = Connection)
            {
                string selectOneQuery = @"Select * from Products where ProductId = @Id;";
                db.Open();

                return db.Query<Products>(selectOneQuery, new { Id = id })
                    .FirstOrDefault();
            }
        }

        //INSERT
        public void Insert(Products product)
        {
            using (IDbConnection db = Connection)
            {
                string insertQuery = @"INSERT INTO Products(Name,Quantity,Price) Values (@Name, @Quantity, @Price);";
                db.Open();
                db.Execute(insertQuery, product);

            }
        }

        //UPDATE
        public void Update(Products products)
        {
            using (IDbConnection db = Connection )
            {
                string updateQuery = @"Update Products SET Name=@Name, Quantity=@Quantity, Price=@Price where ProductId = @ProductId; ";
                db.Open();
                db.Query(updateQuery, products);
            }
        }

        //Delete
        public void Delete(int id)
        {
            using (IDbConnection db = Connection)
            {
                string deleteQuery = @"Delete from Products where ProductId = @Id";
                db.Open();
                db.Execute(deleteQuery, new { Id = id });
            }
        }


    }
}
