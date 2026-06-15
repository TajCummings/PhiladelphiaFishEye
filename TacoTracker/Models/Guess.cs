namespace TacoTracker.Models;

public class Guess
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public DateTime GuessedDate { get; set; }
    public DateTime? ActualDate { get; set; }

    // Parameterless constructor for EF to use to map database rows
    public Guess() { } //Constructor overloading

    // Constructor for when app tracks a new guess
    public Guess(string name, DateTime guessedDate)
    {
        UserName = name;
        GuessedDate = guessedDate;
    }
}
