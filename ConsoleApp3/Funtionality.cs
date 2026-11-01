using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public class Functionality
    {
        

        public static Guid AddBookToLib(string Title, string Author, int NumberOfPages, string CoverType)
        {
            if (!CheckForExistence(Title, Author, NumberOfPages, CoverType))
            {
                Book newBook = new Book(Title, Author, NumberOfPages, CoverType);
                string connectionString = "Data Source=.;Initial Catalog=Library;Integrated Security=True;TrustServerCertificate=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = @"
                                INSERT INTO Books
                                (Id, Title, Author, NumberOfPages, Available, CoverType)
                                VALUES
                                (@Id, @Title, @Author, @NumberOfPages, @Available, @CoverType)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = newBook.Id;
                cmd.Parameters.Add("@Title", SqlDbType.VarChar, 100).Value = Title;
                cmd.Parameters.Add("@Author", SqlDbType.VarChar, 100).Value = Author;
                cmd.Parameters.Add("@NumberOfPages", SqlDbType.Int).Value = NumberOfPages;
                cmd.Parameters.Add("@CoverType", SqlDbType.VarChar, 100).Value = CoverType;
                cmd.Parameters.Add("@Available", SqlDbType.Int).Value= newBook.Available;
                cmd.ExecuteNonQuery();
                con.Close();
                return newBook.Id;

            }
            throw new Exception("This book already exists in the library!!");

        }

        public static bool CheckForExistence(string Title, string Author, int NumberOfPages, string CoverType)
        {
           
            //string query = "Select id from Books where title = " + Title + " and author = " + Author + " and covertype = " + CoverType + "";
             string query = @"
                            SELECT Id FROM Books
                            WHERE Title = @Title
                            AND Author = @Author
                            AND CoverType = @CoverType";
            string connectionString = "Data Source=.;Initial Catalog=Library;Integrated Security=True;Trust Server Certificate=True";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@Title", SqlDbType.VarChar, 100).Value = Title;
            cmd.Parameters.Add("@Author", SqlDbType.VarChar, 100).Value = Author;
            cmd.Parameters.Add("@NumberOfPages", SqlDbType.Int).Value = NumberOfPages;
            cmd.Parameters.Add("@CoverType", SqlDbType.VarChar, 100).Value = CoverType;
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            return false;

            con.Close();

        }

    }
}
