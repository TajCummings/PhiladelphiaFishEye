namespace TacoTracker.Models;

public class Guess
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public DateTime GuessedDate { get; set; }
    public DateTime? ActualDate { get; set; }

    public Guess(string name, DateTime guessedDate)
    {
        UserName = name;
        GuessedDate = guessedDate;
    }
}
