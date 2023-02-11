using EnvDTE;
using Microsoft.Build.Construction;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class ProjectItemsLite : ProjectItems
    {
        private Project _containingProject;

        private IList<ProjectItem> _projectItems;

        private object _parent; // ProjectItem or Project?

        // Create a ProjectItems which parent is a project.
        public ProjectItemsLite(Project containingProject) //: this(containingProject, null, null)
        {
            this._containingProject = containingProject;
            this._parent = containingProject;
        }

        public ProjectItemsLite(Project containingProject, ProjectItem parent, IList<ProjectItem> projectItems)
        {
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
            get { return this.ContainingProject.DTE; }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            if (this._projectItems == null)
            {
                if (_parent is ProjectLite parentProj)
                {
                    var projItems = new List<ProjectItem>();
                    foreach (var projecItemGroupEle in parentProj.ProjectRootElement.ItemGroups)
                    {
                        foreach (var projectItemEle in projecItemGroupEle.Items) 
                        {
                        var projItemLite = new ProjectItemLite(projectItemEle, this._containingProject);
                        projItems.Add(projItemLite);
                        }
                    }
                    this._projectItems = projItems;
                }
                else 
                {
                    return new ProjectItem[0].GetEnumerator(); //should not goto here?
                }
            }
            return this._projectItems.GetEnumerator();
        }

        public ProjectItem Item(object index)
        {
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
                //if (this._parent != null) { return this._parent; }
                //throw new InvalidOperationException("ProjectItems.Parent");
                return _parent;
            }
        }
    }
}
