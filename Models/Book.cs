using System;

namespace console_library.Models
{
  public class Book
  {
    public string Title { get; set; }
    public string Author { get; set; }
    public bool Available { get; set; }
    public Book(string title, string author, bool available = true)
    {
      Title = title;
      Author = author;
      Available = available;
    }
  }
}