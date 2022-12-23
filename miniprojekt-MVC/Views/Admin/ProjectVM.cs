using Microsoft.AspNetCore.Mvc;
using miniprojekt_MVC.Models.Entities;

namespace miniprojekt_MVC.Views.Admin
{
    public class ProjectVM
    {
        public FormView[] form { get; set; }
        public GroupView[] groups { get; set; }


        [Bind(Prefix = nameof(ProjectVM.FormView))]
        public class FormView
        {
            public Person People { get; set; }
            public bool IsSelected { get; set; }
        }

        public class GroupView
        {
            public ProjectGroup group { get; set; }
            public Person[] people { get; set; }
        }
    }
}
