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
            return context.Projects.OrderByDescending(p => p.Created).ToArray();
        }



        internal Person[] GetPeople()
        {
            var model = context.People
                .OrderBy(p => p.DisplayName)
                .ToArray();
            return model;
        }
        internal PeopleInGroup RandomizeGroups(int groupSize, int projectId, Person[] people)
        {
            int numberOfGroups = GetNumberOfGroups(groupSize, people);

            List<PeopleInGroup> groups = new List<PeopleInGroup>();
            var names = context.GroupNames.Take(numberOfGroups).ToList();

            names.ForEach(n => groups.Add(
                new PeopleInGroup()
                {
                    Group = new ProjectGroup
                    {
                        GroupnameNavigation = n,
                        Project = context.Projects.FirstOrDefault(p => p.Id == projectId)
                    }
                }
                ));


            throw new NotImplementedException();

        }

        private int GetNumberOfGroups(int groupSize, Person[] people)
        {
            int numberOfGroups = people.Count() / groupSize;
            if(context.People.Count() % groupSize > ((groupSize / 3) * 2))
            {
                numberOfGroups++;
            }

            return numberOfGroups;
        }

        internal object GetProjectGroups(int projectId)
        {
            var groups = context.PersonInGroups
                .Where(pig => pig.ProjectGroup.ProjectId == projectId)
                .GroupBy(pig => pig.ProjectGroup);

            return null;
        }
    }
}
