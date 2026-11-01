using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();



        }

        static void Menu()
        {
            Console.WriteLine("Choose one of the options below: ");
            Console.WriteLine("1. Add a new book" +
                "2. Other");
            int selectedOption = Convert.ToInt32(Console.ReadLine());
            switch (selectedOption)
            {
                case 1:
                    Console.WriteLine("Enter these details in order and comma-seperated : 1.Title 2.Author 3.Number of pages 4.cover type");
                    String[] inputs = Console.ReadLine()!.Trim().Split(',');
                    int pages = Convert.ToInt32(inputs[2]);
                    Guid id =Functionality.AddBookToLib(inputs[0], inputs[1],pages, inputs[3]);
                    Console.WriteLine($"The generated id of the book is {id}");
                    break;
                case 2:
                    Console.WriteLine("Unfortunately there are no other availabe features right now!!");
                    break;
                default:
                    Console.WriteLine("Choose a valid option from the list above!!!");
                    break;
            }
            ;

        }
    }
}
