using System;
using System.Collections.Generic;

namespace TacoTracker.Models;

public partial class RolesType
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string? RoleDescription { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
