namespace practice12.models;
using practice12.utis;

public record Book(string Title, string Author, Genre Genre, int Year)
{
    public override string ToString()
    {
        return $"<<{Title}>> {Author}, {Year}.\n({Genre})";
    }
}