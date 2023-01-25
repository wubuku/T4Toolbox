using EnvDTE;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class ProjectLite : Project
    {
        private Project _project;

        public ProjectLite(Project project)
        {
            if (project == null) { throw new ArgumentNullException("project"); }
            this._project = project;
        }

        public CodeModel CodeModel
        {
            get { throw new NotImplementedException("Project.CodeModel"); }
        }

        public Projects Collection
        {
            get { throw new NotImplementedException("Project.Collection"); }
        }

        public ConfigurationManager ConfigurationManager
        {
            //get { throw new NotImplementedException("Project.ConfigurationManager"); }
            get
            {
                if (this._project.ConfigurationManager == null)
                {
                    return null;
                }
                return new ConfigurationManagerLite(this._project.ConfigurationManager);
            }
        }

        public DTE DTE
        {
            //get { throw new NotImplementedException("Project.DTE"); }
            get { return new DTELite((EnvDTE80.DTE2)this._project.DTE); }
        }

        public void Delete()
        {
            throw new NotImplementedException("Project.Delete");
        }

        public string ExtenderCATID
        {
            get { throw new NotImplementedException("Project.ExtenderCATID"); }
        }

        public object ExtenderNames
        {
            get { throw new NotImplementedException("Project.ExtenderNames"); }
        }

        public string FileName
        {
            get { throw new NotImplementedException("Project.FileName"); }
        }

        public string FullName
        {
            //get { throw new NotImplementedException("Project.FullName"); }
            get { return this._project.FullName; }
        }

        public Globals Globals
        {
            get { throw new NotImplementedException("Project.Globals"); }
        }

        public bool IsDirty
        {
            get
            {
                throw new NotImplementedException("Project.IsDirty");
            }
            set
            {
                throw new NotImplementedException("set Project.IsDirty");
            }
        }

        public string Kind
        {
            //get { throw new NotImplementedException("Project.Kind"); }
            get { return this._project.Kind; }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException("Project.Name");
            }
            set
            {
                throw new NotImplementedException("set Project.Name");
            }
        }

        public new object Object
        {
            get { throw new NotImplementedException("Project.Object"); }
        }

        public ProjectItem ParentProjectItem
        {
            get { throw new NotImplementedException("Project.ParentProjectItem"); }
        }

        public ProjectItems ProjectItems
        {
            //get { throw new NotImplementedException("Project.ProjectItems"); }
            get
            {
                if (this._project.ProjectItems == null)
                {
                    return null;
                }
                return new ProjectItemsLite(this._project.ProjectItems);
            }
        }

        public EnvDTE.Properties Properties
        {
            //get { throw new NotImplementedException("Project.Properties"); }
            get
            {
                if (this._project.Properties == null)
                {
                    return null;
                }
                return new EnvDTEPropertiesLite(this._project.Properties);
            }
        }

        public void Save(string FileName = "")
        {
            throw new NotImplementedException("Project.Save");
        }

        public void SaveAs(string NewFileName)
        {
            throw new NotImplementedException("Project.SaveAs");
        }

        public bool Saved
        {
            get
            {
                throw new NotImplementedException("Project.Saved");
            }
            set
            {
                throw new NotImplementedException("set Project.Saved");
            }
        }

        public string UniqueName
        {
            get { throw new NotImplementedException("Project.UniqueName"); }
        }

        public object get_Extender(string ExtenderName)
        {
            throw new NotImplementedException("Project.get_Extender");
        }
    }
}
