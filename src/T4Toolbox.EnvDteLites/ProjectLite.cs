using EnvDTE;
using System;
using Microsoft.Build.Construction;

namespace T4Toolbox.EnvDteLites
{
    public class ProjectLite : Project
    {
        private ProjectRootElement _projectRootElement;

        private DTE _dte;

        private ProjectItems _projectItems;

        private ConfigurationManager _configurationManager;

        private Properties _properties;

        public ProjectLite(ProjectRootElement projectRootElement, DTE dte)
        {
            if (projectRootElement == null) { throw new ArgumentNullException("projectRootElement"); }
            this._projectRootElement = projectRootElement;
            this._dte = dte;
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
                if (this._configurationManager == null)
                {
                    return new ConfigurationManagerLite(this._projectRootElement, _dte);
                }
                return this._configurationManager;
            }
        }

        public DTE DTE
        {
            //get { throw new NotImplementedException("Project.DTE"); }
            get { return this._dte; }
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
            get { return this._projectRootElement.FullPath; }
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
            get { throw new NotImplementedException("Project.Kind"); }
            //todo new NotImplementedException("Project.Kind")
            //get { return this._projectRootElement.Kind; }
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
                if (this._projectItems == null)
                {
                    var ieList = new List<ProjectItemElement>();
                    foreach (var iG in this._projectRootElement.ItemGroups)
                    {
                        foreach (var ie in iG.Items)
                        {
                            ieList.Add(ie);
                        }
                    }
                    this._projectItems = new ProjectItemsLite(ieList, this);
                }
                return this._projectItems;
            }
        }

        public Properties Properties
        {
            //get { throw new NotImplementedException("Project.Properties"); }
            get
            {
                if (this._properties == null)
                {
                    var ps = new Dictionary<string, ProjectPropertyElement>();
                    //todo fill ProjectPropertyElement dict....
                    this._properties = new PropertiesLite(ps, _dte);
                }
                return this._properties;
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
