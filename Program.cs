using System;
using console_library.Models;


namespace console_library
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      Console.WriteLine(@"
  
  _             ____    _   _       _   _           _                         
 | |           |  _ \  (_) | |     | | (_)         | |                        
 | |   __ _    | |_) |  _  | |__   | |  _    ___   | |_    ___    ___    __ _ 
 | |  / _` |   |  _ <  | | | '_ \  | | | |  / _ \  | __|  / _ \  / __|  / _` |
 | | | (_| |   | |_) | | | | |_) | | | | | | (_) | | |_  |  __/ | (__  | (_| |
 |_|  \__,_|   |____/  |_| |_.__/  |_| |_|  \___/   \__|  \___|  \___|  \__,_|
                                                                              
                                                                              
");
      Console.WriteLine("Welcome to The Library!");
      Library myLibrary = new Library("Boise", "LA BIBOLECA");

      //Books 
      Console.WriteLine("  ");
      Book whereTheSidewalkEnds = new Book("Where the Sidewalk Ends", "Shel Silverstein");
      Book Book2 = new Book("Book 2 Title", "Book 2 Author");
      Book Book3 = new Book("Book 3 Title", "Book 3 Author");
      Book Book4 = new Book("Book 4 Title", "Book 4 Author");


      //Added Books to Library
      myLibrary.AddBook(whereTheSidewalkEnds);
      myLibrary.AddBook(Book2);
      myLibrary.AddBook(Book3);
      myLibrary.AddBook(Book4);


      //Enum Menus
      Enum activeMenu = Menus.CheckoutBook;
      bool inLibrary = true;
      while (inLibrary)
      {
        switch (activeMenu)
        {
          case Menus.CheckoutBook:
            myLibrary.PrintBooks();
            break;
          case Menus.ReturnBook:
            myLibrary.PrintCheckedOut();
            break;
        }

        string input = Console.ReadLine();
        switch (input.ToUpper()[0])
        {
          case 'Q':
            inLibrary = false;
            break;
          case 'R':
            activeMenu = Menus.ReturnBook;
            Console.Clear();
            break;
          case 'A':
            activeMenu = Menus.CheckoutBook;
            Console.Clear();
            break;
          default:
            if (activeMenu.Equals(Menus.CheckoutBook))
            {
              myLibrary.Checkout(input);
            }
            else
            {
              myLibrary.Return(input);
            }
            break;
        }

      }
      Console.WriteLine("See ya Later Space Cowboy");
    }
    public enum Menus
    {
      CheckoutBook,
      ReturnBook
    }
  }
}
