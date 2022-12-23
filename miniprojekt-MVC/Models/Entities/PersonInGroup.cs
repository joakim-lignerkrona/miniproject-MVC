using System;
using System.Collections.Generic;

namespace miniprojekt_MVC.Models.Entities;

public partial class PersonInGroup
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public int ProjectGroupId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual ProjectGroup ProjectGroup { get; set; } = null!;
}
