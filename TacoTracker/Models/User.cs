using System;
using System.Collections.Generic;

namespace TacoTracker.Models;

public partial class User
{
    public Guid Userid { get; set; }

    public int? RoleId { get; set; }

    public int? PreferredLocationId { get; set; }

    public string Username { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? ZipCode { get; set; }

    public virtual ICollection<Guess> Guesses { get; set; } = new List<Guess>();

    public virtual Location? PreferredLocation { get; set; }

    public virtual RolesType? Role { get; set; }
}
