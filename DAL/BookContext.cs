using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Library.Helpers;
using Library.Models;

namespace Library.DAL
{   
    public class BookContext
    {
        public List<Book> GetBooks(int Id = 0)
        {
            List<Book> books = new List<Book>();
            using(SqlConnection conn =
                new SqlConnection(ConfigurationSettings.GetConnectionString("BooksContext")))
            {

                SqlCommand command = new SqlCommand("usp_GetBooks", conn);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                command.Parameters[0].Value = Id;

                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        books.Add(new Book
                        {
                            ID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            FileName = reader.GetString(2),
                        });
                    }
                }
                reader.Close();
            }
            return books;
        }

        public string[] SearchResults()
        {
            return new string[] { };
        }

    }
}