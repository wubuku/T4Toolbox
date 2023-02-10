using EnvDTE;
using Microsoft.Build.Construction;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class ProjectItemsLite : ProjectItems
    {
        //private IList<ProjectItemElement> _projectItemElements = new List<ProjectItemElement>();

        private Project _containingProject;

        private IList<ProjectItem> _projectItems;

        //private ProjectItem _parent;
        private object _parent; // ProjectItem or Project?


        public ProjectItemsLite(Project containingProject) //: this(containingProject, null, null)
        {
            this._containingProject = containingProject;
            this._parent = containingProject;
        }

        public ProjectItemsLite(Project containingProject, ProjectItem parent, IList<ProjectItem> projectItems)
        {
            //if (projectItemElements == null) { throw new ArgumentNullException("projectItemElements"); }
            //this._projectItemElements = projectItemElements;
            this._containingProject = containingProject;
            this._parent = parent;
            this._projectItems = projectItems;
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
            get
            {
                //throw new NotImplementedException("ProjectItems.Count");
                if (this._projectItems != null)
                {
                    return this._projectItems.Count;
                }
                return 0;
            }
        }

        public DTE DTE
        {
            //get { throw new NotImplementedException("ProjectItems.DTE"); }
            get { return this.ContainingProject.DTE; }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            //throw new NotImplementedException("ProjectItems.GetEnumerator");
            //foreach (ProjectItemElement projectItemEle in this._projectItemElements)
            //{
            //    yield return projectItemEle == null ? null : new ProjectItemLite(projectItemEle, this._containingProject);
            //}
            if (this._projectItems != null)
            {
                return this._projectItems.GetEnumerator();
            }
            return new ProjectItem[0].GetEnumerator();
        }

        public ProjectItem Item(object index)
        {
            //throw new NotImplementedException("ProjectItems.Item");
            if (this._projectItems != null)
            {
                int i = Convert.ToInt32(index);
                if (i >= 1 && i <= this._projectItems.Count)
                {
                    return this._projectItems[i - 1];
                }
            }
            throw new IndexOutOfRangeException("ProjectItems.Item index: " + index);
        }

        public string Kind
        {
            get { throw new NotImplementedException("ProjectItems.Kind"); }
        }

        public object Parent
        {
            get
            {
                //throw new NotImplementedException("ProjectItems.Parent");
                return _parent;
                //if (this._parent != null) { return this._parent; }
                //throw new InvalidOperationException("ProjectItems.Parent");
            }
        }
    }
}
