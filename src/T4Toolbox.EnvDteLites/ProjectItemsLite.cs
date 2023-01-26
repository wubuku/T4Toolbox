using EnvDTE;
using Microsoft.Build.Construction;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class ProjectItemsLite : ProjectItems
    {
        private IList<ProjectItemElement> _projectItemElements;

        private Project _containingProject;


        public ProjectItemsLite(IList<ProjectItemElement> projectItemElements, Project containingProject)
        {
            if (projectItemElements == null) { throw new ArgumentNullException("projectItemElements"); }
            this._projectItemElements = projectItemElements;
            this._containingProject = containingProject;
        }

        public ProjectItem AddFolder(string Name, string Kind = "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}")
        {
            throw new NotImplementedException("ProjectItems.AddFolder");
        }

        public ProjectItem AddFromDirectory(string Directory)
        {
            throw new NotImplementedException("ProjectItems.AddFromDirectory");
        }

        public ProjectItem AddFromFile(string FileName)
        {
            throw new NotImplementedException("ProjectItems.AddFromFile");
        }

        public ProjectItem AddFromFileCopy(string FilePath)
        {
            throw new NotImplementedException("ProjectItems.AddFromFileCopy");
        }

        public ProjectItem AddFromTemplate(string FileName, string Name)
        {
            throw new NotImplementedException("ProjectItems.AddFromTemplate");
        }

        public Project ContainingProject
        {
            //get { throw new NotImplementedException("ProjectItems.ContainingProject"); }
            get { return this._containingProject; }
        }

        public int Count
        {
            get { throw new NotImplementedException("ProjectItems.Count"); }
        }

        public DTE DTE
        {
            //get { throw new NotImplementedException("ProjectItems.DTE"); }
            get { return this.ContainingProject.DTE; }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            //throw new NotImplementedException("ProjectItems.GetEnumerator");
            foreach (ProjectItemElement projectItemEle in this._projectItemElements)
            {
                yield return projectItemEle == null ? null : new ProjectItemLite(projectItemEle, this._containingProject);
            }
        }

        public ProjectItem Item(object index)
        {
            throw new NotImplementedException("ProjectItems.Item");
        }

        public string Kind
        {
            get { throw new NotImplementedException("ProjectItems.Kind"); }
        }

        public object Parent
        {
            get { throw new NotImplementedException("ProjectItems.Parent"); }
        }
    }
}
