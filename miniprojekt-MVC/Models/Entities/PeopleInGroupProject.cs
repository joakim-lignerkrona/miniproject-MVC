using System;
using System.Collections.Generic;

namespace miniprojekt_MVC.Models.Entities;

public partial class PeopleInGroupProject
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public int ProjectId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
