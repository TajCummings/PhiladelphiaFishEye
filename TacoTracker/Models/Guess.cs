using System;
using System.Collections.Generic;

namespace TacoTracker.Models;

public partial class Guess
{
    public int Id { get; set; }

    public Guid Userid { get; set; }

    public DateTime GuessedDate { get; set; }

    public DateTime? ActualDate { get; set; }

    public virtual User User { get; set; } = null!;
}
