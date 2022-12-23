using System;
using System.Collections.Generic;

namespace miniprojekt_MVC.Models.Entities;

public partial class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Created { get; set; }

    public virtual ICollection<ProjectGroup> ProjectGroups { get; } = new List<ProjectGroup>();
}
