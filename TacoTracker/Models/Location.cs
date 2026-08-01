using System;
using System.Collections.Generic;

namespace TacoTracker.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string? LocationName { get; set; }

    /// <summary>
    /// location would never have leading zero
    /// </summary>
    public string? LocationZip { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
