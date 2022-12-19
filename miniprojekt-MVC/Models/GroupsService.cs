using miniprojekt_MVC.Models.Entities;

namespace miniprojekt_MVC.Models
{
    public class GroupsService
    {
        private readonly ConsultantContext context;

        public GroupsService(ConsultantContext context)
        {
            this.context = context;
        }

        public void CreateProject(string projectName)
        {
            context.Projects.Add(new Project() { Name = projectName });
            context.SaveChanges();
        }

        public Project[] GetProjects()
        {
            return new Project[1];
        }

        internal Group[] GetGroups()
        {

            return context.Groups.ToArray();
        }
    }
}
