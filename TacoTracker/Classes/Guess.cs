namespace Classes;

public class Guess
{
    public string UserName { get; set; }
    //public DateTime GuessedDate { get;set;}
    //public GUID ID { get ; set;}
    //public DateTime ActualDate { get ; set;}
    public string GuessDate {get; set;}


    public Guess(string name, string date)
    {
        this.UserName = name;
        this.GuessDate = date;
    }

    //public void MakeGuess(DateTime date,  string reasoning)
    //{

    //}
  

}


 