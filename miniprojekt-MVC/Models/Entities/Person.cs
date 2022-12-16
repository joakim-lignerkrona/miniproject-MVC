using System;
using System.Collections.Generic;

namespace miniprojekt_MVC.Models.Entities;

public partial class Person
{
    public int Id { get; set; }

    public string? DiscordId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string? CustomDisplayName { get; set; }

    public int IndividualPresentations { get; set; }

    public int GroupPresentatons { get; set; }

    public virtual ICollection<PeopleInGroupProject> PeopleInGroupProjects { get; } = new List<PeopleInGroupProject>();
}
