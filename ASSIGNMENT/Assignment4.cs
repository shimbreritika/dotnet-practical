using System.Collections.Generic;

class Collection1
{
    static void Main()
    {
        List<string> bookname= new List<string>();

        bookname.Add("Dr. Babasaheb Ambedkar");
        bookname.Add("The Monk Who Sold His Ferrari");
        bookname.Add("The Alchemist");
        bookname.Add("The Power of Your Subconscious Mind");
        bookname.Add("The Secret");
        bookname.Add("The 7 Habits of Highly Effective People");

        foreach(string n in bookname)
        {
            Console.WriteLine(n);
        }

         // Add one new book
        bookname.Add("Atomic Habits");

        // Remove one old book
        bookname.Remove("The Secret");

        Console.WriteLine("\nUpdated Book List:");
        foreach (string n in bookname)
        {
            Console.WriteLine(n);
        }

        // Total number of books
        Console.WriteLine("\nTotal Books: " + bookname.Count);


    }
}