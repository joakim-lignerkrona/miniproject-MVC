using miniprojekt_MVC.Models.Entities;

namespace miniprojekt_MVC.Models
{
    public class PeopleInGroup
    {
        public ProjectGroup Group { get; set; }
        public Person[] people { get; set; }
    }
}
