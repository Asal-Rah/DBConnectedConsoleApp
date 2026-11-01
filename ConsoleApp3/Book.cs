using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Library.Book;

namespace Library
{
    public class Book
    {
        public Guid Id = Guid.NewGuid();

        public record bookInfo(string Title, string Author, int NumberOfPages, string CoverType);
        public bookInfo Info { get; }

        public int Available {  get; set; }


        public Book(string Title, string Author, int NumberOfPages, string CoverType)
        {

            if (string.IsNullOrEmpty(Title))
            {
                throw new Exception("You must enter the title of the book!");

            }
            if (string.IsNullOrEmpty(Author))
            {
                throw new Exception("You must enter the name of the author");
            }

            Info = new bookInfo(Title, Author, NumberOfPages, CoverType);
            Available = 1;


        }


    }
}
