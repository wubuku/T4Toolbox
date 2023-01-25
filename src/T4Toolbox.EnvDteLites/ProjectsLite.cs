using EnvDTE;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class ProjectsLite : Projects
    {
        private Projects _projects;

        public ProjectsLite(Projects projects)
        {
            if (projects == null) { throw new ArgumentNullException("projects"); }
            this._projects = projects;
        }

        public int Count
        {
            get { throw new NotImplementedException("Projects.Count"); }
        }

        public DTE DTE
        {
            get { throw new NotImplementedException("Projects.DTE"); }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            //throw new NotImplementedException("Projects.");
            foreach (Project project in this._projects)
            {
                yield return new ProjectLite(project);
            }
        }

        public Project Item(object index)
        {
            throw new NotImplementedException("Projects.GetEnumerator");
        }

        public string Kind
        {
            get { throw new NotImplementedException("Projects.Kind"); }
        }

        public DTE Parent
        {
            get { throw new NotImplementedException("Projects.Parent"); }
        }

        public EnvDTE.Properties Properties
        {
            get { throw new NotImplementedException("Projects.Properties"); }
        }
    }
}
