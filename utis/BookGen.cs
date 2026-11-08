using practice12.models;

namespace practice12.utis;

public enum Genre
{
    Romance,
    Fantasy,
    ScienceFiction,
    Thriller,
    Mystery,
    Detective,
    Adventure,
    Drama,
    ClassicLiterature,
    ChildrensLiterature,
    Horror,
    Poetry
}

public static class BookGen
{
    private static string[] titles =
    {
        "To Kill a Mockingbird",
        "The Hunger Games",
        "The Alchemist",
        "The Fault in Our Stars",
        "The Book Thief",
        "1984",
        "Pride and Prejudice",
        "The Da Vinci Code",
        "Harry Potter and the Philosopher's Stone",
        "The Great Gatsby",
        "The Handmaid's Tale",
        "Fahrenheit 451",
        "Twilight",
        "The Little Prince",
        "The Girl With the Dragon Tattoo",
        "Memoirs of a Geisha",
        "Divergent",
        "Little Women",
        "Gone Girl"
    };
    private static string[] authors =
    {
        "Harper Lee",
        "Suzanne Collins",
        "Paulo Coelho",
        "John Green",
        "Markus Zusak",
        "George Orwell",
        "Jane Austen",
        "Dan Brown",
        "J.K. Rowling",
        "F. Scott Fitzgerald",
        "Margaret Atwood",
        "Ray Bradbury",
        "Stephenie Meyer",
        "Antoine de Saint-Exupéry",
        "Stieg Larsson",
        "Arthur Golden",
        "Veronica Roth",
        "Louisa May Alcott",
        "Gillian Flynn"
    };
    private const int minYear = 1814;
    private const int maxYear = 2020;
    static Random random = new();

    public static string GenTitle()
    {
        return titles[random.Next(0,titles.Length)];
    }

    public static string GenAuthor()
    {
        return authors[random.Next(0,authors.Length)];
    }

    public static int GenYear()
    {
        return random.Next(minYear, maxYear);
    }

    public static Genre GenGenre()
    {
        return (Genre)random.Next(Enum.GetValues(typeof(Genre)).Length);
    }

    public static Book GenBook()
    {
        return new Book(GenTitle(), GenAuthor(), GenGenre(), GenYear());
    }

    public static LinkedList<Book> GenBooks(int count)
    {
        LinkedList<Book> list = new();
        for (int i = 0; i < count; i++)
        {
            list.AddLast(GenBook());
        }
        return list;
    }
}
