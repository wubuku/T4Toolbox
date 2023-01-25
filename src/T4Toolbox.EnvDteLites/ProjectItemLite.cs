using EnvDTE;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class ProjectItemLite : ProjectItem
    {
        private ProjectItem _projectItem;

        public ProjectItemLite(ProjectItem projectItem)
        {
            if (projectItem == null) { throw new ArgumentNullException("projectItem"); }
            this._projectItem = projectItem;
        }

        public ProjectItems Collection
        {
            get { throw new NotImplementedException("ProjectItem.Collection"); }
        }

        public ConfigurationManager ConfigurationManager
        {
            get { throw new NotImplementedException("ProjectItem.ConfigurationManager"); }
        }

        public Project ContainingProject
        {
            //get { throw new NotImplementedException("ProjectItem.ContainingProject"); }
            get
            {
                if (this._projectItem.ContainingProject == null)
                {
                    return null;
                }
                return new ProjectLite(this._projectItem.ContainingProject);
            }
        }

        public DTE DTE
        {
            get { throw new NotImplementedException("ProjectItem.DTE"); }
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
            get { throw new NotImplementedException("ProjectItem.FileCount"); }
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
                throw new NotImplementedException("ProjectItem.Name");
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
            get { throw new NotImplementedException("ProjectItem.ProjectItems"); }
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
                if (this._projectItem.SubProject == null)
                {
                    return null;
                }
                return new ProjectLite(this._projectItem.SubProject); 
            }
        }

        public object get_Extender(string ExtenderName)
        {
            throw new NotImplementedException("ProjectItem.get_Extender");
        }

        public string get_FileNames(short index)
        {
            throw new NotImplementedException("ProjectItem.get_FileNames");
        }

        public bool get_IsOpen(string ViewKind = "{FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF}")
        {
            throw new NotImplementedException("ProjectItem.get_IsOpen");
        }
    }
}
