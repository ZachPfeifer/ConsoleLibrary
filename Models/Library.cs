using System.Collections.Generic;
using System;

namespace console_library.Models
{
  public class Library
  {
    public string Location { get; set; }
    public string Name { get; set; }
    private List<Book> Books { get; set; }
    private List<Book> CheckedOut { set; get; }


    public Library(string name, string location) //Constructor
    {
      Name = name;
      Location = location;
      Books = new List<Book>();
      CheckedOut = new List<Book>();
      // List<Book> strings = new List<Book>()

    }

    //Printed Books
    public void PrintBooks()
    {
      Console.WriteLine(@"Choose a Book by Typing a Number. ");
      Console.WriteLine(" Available Books: ");
      for (int i = 0; i < Books.Count; i++)
      {
        Console.WriteLine($"{i + 1} {Books[i].Title} - {Books[i].Author}");
      }
      Console.WriteLine("");
      Console.WriteLine(" Select a book number to checkout (Q)uit, or (R)eturn a book ");

    }

    // Printed Returned Books
    public void PrintCheckedOut()
    {
      Console.WriteLine(@"Choose a Book by Typing a Number. ");
      Console.WriteLine(" Checked Out Books: ");
      for (int i = 0; i < CheckedOut.Count; i++)
      {
        Console.WriteLine($"{i + 1} {Books[i].Title} - {Books[i].Author}");
      }
      Console.WriteLine("");
      Console.WriteLine(@" Select a book number to return the book, (Q)uit, or (A)valible to see available a books ");

    }


    public void AddBook(Book book)
    {
      Books.Add(book);
    }

    //Checkout
    public void Checkout(string input)
    {
      Book selectBook = ValidateBook(input, Books);
      if (selectBook == null)
      {
        Console.Clear();
        Console.WriteLine("Not a Book in the collection");
      }
      selectBook.Available = false;
      CheckedOut.Add(selectBook);
      Books.Remove(selectBook);
      Console.Clear();
      Console.WriteLine("Checked out Book");

    }

    //Return
    public void Return(string input)
    {
      Book selectBook = ValidateBook(input, CheckedOut);
      if (selectBook == null)
      {
        Console.Clear();
        Console.WriteLine("Not a Book in the collection");
      }
      selectBook.Available = true;
      Books.Add(selectBook);
      CheckedOut.Remove(selectBook);
      Console.Clear();
      Console.WriteLine("Returned checked out Book");

    }


    private Book ValidateBook(string input, List<Book> booksList)
    {
      //Is a Number
      int bookIndex;
      if (Int32.TryParse(input, out bookIndex) && bookIndex > 0 && bookIndex <= booksList.Count)
      {
        return booksList[bookIndex - 1]; //Offset the number by 1 
      }
      return null;
    }

  }
}