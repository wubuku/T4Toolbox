using EnvDTE;
using System;
using Microsoft.Build.Construction;

namespace T4Toolbox.EnvDteLites
{
    public class ProjectItemLite : ProjectItem
    {
        private ProjectItemElement _projectItemElement;

        private string _name;

        private IList<string> _fileNames;

        internal ProjectItemElement ProjectItemElement
        {
            get { return this._projectItemElement; }
        }

        private Project _containingProject;

        private ProjectItems _collection;

        private ProjectItems _projectItems;

        public ProjectItemLite(ProjectItemElement projectItemElement, Project containingProject)
            : this (projectItemElement, containingProject, null) 
            // Let this._collection to be lazy loaded.
        {
        }

        public ProjectItemLite(ProjectItemElement projectItemElement, Project containingProject, ProjectItems collection)
        {
            if (projectItemElement == null) { throw new ArgumentNullException("projectItemElement"); }
            this._projectItemElement = projectItemElement;
            this._containingProject = containingProject;
            this._name = Path.GetFileName(projectItemElement.Include);
            this._fileNames = new string[]
            {
                GetProjectItemFullName(projectItemElement, containingProject)
            };
            this._collection = collection;
        }

        internal static string GetProjectItemFullName(ProjectItemElement projectItemElement, Project containingProject)
        {
            var projDir = Path.GetDirectoryName(containingProject.FileName);
            //Console.WriteLine("proj. dir.: " + projDir); //debug
            //Console.WriteLine("inlucded item: " + projectItemElement.Include); 
            //var fullName = Path.Combine(projDir, projectItemElement.Include);           
            var fullName = Path.GetFullPath(
                projectItemElement.Include.Replace("\\", Path.DirectorySeparatorChar.ToString()), //todo is this replace ok?
                projDir);
            //Console.WriteLine("GetProjectItemFullName: " + fullName);// for debug
            return fullName;
        }

        public ProjectItems Collection
        {
            get 
            {
                if (_collection == null) 
                {
                    string parentName = null;
                    foreach (var e in _projectItemElement.Children) 
                    {
                        if (e.ElementName == "DependentUpon" && (e is ProjectMetadataElement me))
                        {
                            parentName = me.Value;
                            break;
                        }
                    }
                    if (parentName != null)
                    {
                        var containingProject = (ProjectLite)_containingProject;
                        foreach (var e in (containingProject.ProjectRootElement.Items))
                        {
                            var fullName = GetProjectItemFullName(e, containingProject);
                            if (parentName == Path.GetFileName(fullName))
                            {
                                var parentProjectItem = new ProjectItemLite(e, containingProject);
                                _collection = GetProjectItemsDependentUpon(parentProjectItem, containingProject);                                
                            }
                        }
                    }
                    if (_collection == null) //return empty collection?
                    {
                        _collection = new ProjectItemsLite(_containingProject);
                    }
                }
                return _collection;
            }
        }

        public ConfigurationManager ConfigurationManager
        {
            get { throw new NotImplementedException("ProjectItem.ConfigurationManager"); }
        }

        public Project ContainingProject
        {
            //get { throw new NotImplementedException("ProjectItem.ContainingProject"); }
            /*
             * var project = templateFileItem.ContainingProject;
             * var projectDir = Path.GetDirectoryName(project.FullName);
             * Debug.Assert(projectDir != null, "projectDir != null, don't expect project.FullName to be a root directory.");
             * string defaultNamespace = project.Properties.Item("DefaultNamespace").Value.ToString();
             */
            get
            {
                return this._containingProject;
            }
        }

        public DTE DTE
        {
            //get { throw new NotImplementedException("ProjectItem.DTE"); }
            get { return this._containingProject.DTE; }
        }

        public void Delete()
        {
            throw new NotImplementedException("ProjectItem.Delete");
        }

        public Document Document
        {
            get { throw new NotImplementedException("ProjectItem.Document"); }
        }

        public void ExpandView()
        {
            throw new NotImplementedException("ProjectItem.ExpandView");
        }

        public string ExtenderCATID
        {
            get { throw new NotImplementedException("ProjectItem.ExtenderCATID"); }
        }

        public object ExtenderNames
        {
            get { throw new NotImplementedException("ProjectItem.ExtenderNames"); }
        }

        public FileCodeModel FileCodeModel
        {
            get { throw new NotImplementedException("ProjectItem.FileCodeModel"); }
        }

        public short FileCount
        {
            get {
                //throw new NotImplementedException("ProjectItem.FileCount");
                if (_fileNames == null) { return 0; }
                return (short)_fileNames.Count;
            }
        }

        public bool IsDirty
        {
            get
            {
                throw new NotImplementedException("ProjectItem.IsDirty");
            }
            set
            {
                throw new NotImplementedException("set ProjectItem.IsDirty");
            }
        }

        public string Kind
        {
            get { throw new NotImplementedException("ProjectItem.Kind"); }
        }

        public string Name
        {
            get
            {
                //throw new NotImplementedException("ProjectItem.Name");
                return _name;
            }
            set
            {
                throw new NotImplementedException("set ProjectItem.Name");
            }
        }

        public new object Object
        {
            get { throw new NotImplementedException("ProjectItem.Object"); }
        }

        public Window Open(string ViewKind = "{00000000-0000-0000-0000-000000000000}")
        {
            throw new NotImplementedException("ProjectItem.Open");
        }

        public ProjectItems ProjectItems
        {
            get 
            {
                // throw new NotImplementedException("ProjectItem.ProjectItems"); 
                if (this._projectItems == null)
                {
                    var containingProject = (ProjectLite)_containingProject;
                    ProjectItemsLite projectItems = GetProjectItemsDependentUpon(this, containingProject);

                    this._projectItems = projectItems;
                }
                return this._projectItems;
            }
        }

        internal static ProjectItemsLite GetProjectItemsDependentUpon(ProjectItemLite parentProjectItem, ProjectLite containingProject)
        {
            var parentName = Path.GetFileName(parentProjectItem.Name.Replace("\\", Path.DirectorySeparatorChar.ToString()));
            var projItemList = new List<ProjectItem>();
            var projectItems = new ProjectItemsLite(containingProject, parentProjectItem, projItemList);
            foreach (var projEle in containingProject.ProjectRootElement.Items)
            {
                foreach (var e in projEle.Children)
                {
                    if (e.ElementName == "DependentUpon" && (e is ProjectMetadataElement me))
                    {
                        if (me.Value == parentName)
                        {
                            projItemList.Add(new ProjectItemLite(projEle, containingProject, projectItems));
                        }
                    }
                }
            }
            return projectItems;
        }

        public EnvDTE.Properties Properties
        {
            get { throw new NotImplementedException("ProjectItem.Properties"); }
        }

        public void Remove()
        {
            throw new NotImplementedException("ProjectItem.Remove");
        }

        public void Save(string FileName = "")
        {
            throw new NotImplementedException("ProjectItem.Save");
        }

        public bool SaveAs(string NewFileName)
        {
            throw new NotImplementedException("ProjectItem.SaveAs");
        }

        public bool Saved
        {
            get
            {
                throw new NotImplementedException("ProjectItem.Saved");
            }
            set
            {
                throw new NotImplementedException("set ProjectItem.Saved");
            }
        }

        public Project SubProject
        {
            //get { throw new NotImplementedException("ProjectItem.SubProject"); }
            get 
            {
                return null;//todo always return null SubProject?
            }
        }

        public object get_Extender(string ExtenderName)
        {
            throw new NotImplementedException("ProjectItem.get_Extender");
        }

        public string get_FileNames(short index)
        {
            //throw new NotImplementedException("ProjectItem.get_FileNames");
            // Is index from 1??
            if (index >= 1 && index <= this._fileNames.Count)
            {
                return this._fileNames[index - 1];
            }
            return this._fileNames[0];
        }

        public bool get_IsOpen(string ViewKind = "{FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF}")
        {
            throw new NotImplementedException("ProjectItem.get_IsOpen");
        }
    }
}
