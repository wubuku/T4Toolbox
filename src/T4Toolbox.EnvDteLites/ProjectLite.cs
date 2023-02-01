using EnvDTE;
using System;
using Microsoft.Build.Construction;
using VSLangProj;
using System.Collections;

namespace T4Toolbox.EnvDteLites
{
    public class ProjectLite : Project, VSProject
    {
        private ProjectRootElement _projectRootElement;
        private ProjectInSolution _projectInSolution;
        private string _uniqueName;

        private DTE _dte;

        private ProjectItems _projectItems;

        private ConfigurationManager _configurationManager;

        private Properties _properties;

        private string _name;
        private string _fullName;
        private string _fileName;

        internal ProjectRootElement ProjectRootElement
        {
            get { return _projectRootElement; }
        }

        public ProjectLite(ProjectRootElement projectRootElement, ProjectInSolution projectInSolution, string uniqueName, DTE dte)
        {
            if (projectRootElement == null) { throw new ArgumentNullException("projectRootElement"); }
            this._projectRootElement = projectRootElement;
            this._projectInSolution = projectInSolution;
            this._uniqueName = uniqueName;
            this._dte = dte;

            this._fullName = this._projectInSolution.AbsolutePath;
            this._fileName = this._fullName;
            this._name = this._projectInSolution.ProjectName;
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
                    return new ConfigurationManagerLite(this, _dte);
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
            get
            {
                //throw new NotImplementedException("Project.FileName");
                return _fileName;
            }
        }

        public string FullName
        {
            //get { throw new NotImplementedException("Project.FullName"); }
            get { return _fullName; }
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

        private const string _PROJECT_KIND_NORMAL = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";

        public string Kind
        {
            //get { throw new NotImplementedException("Project.Kind"); }
            //todo just return a static Project.Kind?
            get { return _PROJECT_KIND_NORMAL; }
        }

        public string Name
        {
            get
            {
                //throw new NotImplementedException("Project.Name");
                return _name;
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
                //todo only project is a soluction folder, goto here
                if (this._projectItems == null)
                {
                    this._projectItems = new ProjectItemsLite(this);
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
                    //todo how to fill this ProjectPropertyElement dict.?
                    foreach (var pG in this._projectRootElement.PropertyGroups)
                    {
                        if (String.IsNullOrWhiteSpace(pG.Condition))
                        {
                            foreach (var p in pG.Properties)
                            {
                                ps.Add(p.Name, p);
                            }
                        }
                    }
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
            //get { throw new NotImplementedException("Project.UniqueName"); }
            get
            {
                return _uniqueName;
            }
        }

        public object get_Extender(string ExtenderName)
        {
            throw new NotImplementedException("Project.get_Extender");
        }

        References VSProject.References
        {
            get
            {
                //throw new NotImplementedException("VSProject.References");
                return new VsReferencesLite();
            }
        }

    }

    internal class VsReferencesLite : References
    {
        public Reference Add(string bstrPath)
        {
            //throw new NotImplementedException();
            //todo implements References.Add method
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            //throw new NotImplementedException();
            return new Reference[0].GetEnumerator();
        }
    }
}
