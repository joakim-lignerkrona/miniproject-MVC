using System;
using System.Collections.Generic;

namespace miniprojekt_MVC.Models.Entities;

public partial class ProjectGroup
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int Groupname { get; set; }

    public virtual GroupName GroupnameNavigation { get; set; } = null!;

    public virtual ICollection<PersonInGroup> PersonInGroups { get; } = new List<PersonInGroup>();

    public virtual Project Project { get; set; } = null!;
}
