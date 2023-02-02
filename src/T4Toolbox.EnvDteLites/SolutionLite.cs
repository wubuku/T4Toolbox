using EnvDTE;
using System;
using Microsoft.Build.Construction;

namespace T4Toolbox.EnvDteLites
{
    public class SolutionLite : Solution
    {
        private SolutionFile _solutionFile;

        private string _solutionFileFullName;

        private IDictionary<string, ProjectRootElement> _projectRootElements = new Dictionary<string, ProjectRootElement>();
        private IDictionary<string, ProjectInSolution> _projectsInSolution = new Dictionary<string, ProjectInSolution>();

        private Projects _projects;

        private DTE _dte;

        public SolutionLite(DTE dte)
        {
            this._dte = dte;
        }

        public Project AddFromFile(string FileName, bool Exclusive = false)
        {
            throw new NotImplementedException("Solution.AddFromFile");
        }

        public Project AddFromTemplate(string FileName, string Destination, string ProjectName, bool Exclusive = false)
        {
            throw new NotImplementedException("Solution.AddFromTemplate");
        }

        public AddIns AddIns
        {
            get { throw new NotImplementedException("Solution.AddIns"); }
        }

        public void Close(bool SaveFirst = false)
        {
            throw new NotImplementedException("Solution.Close");
        }

        public int Count
        {
            get { throw new NotImplementedException("Solution.Count"); }
        }

        public void Create(string Destination, string Name)
        {
            throw new NotImplementedException("Solution.Create");
        }

        public DTE DTE
        {
            get { throw new NotImplementedException("Solution.DTE"); }
        }

        public string ExtenderCATID
        {
            get { throw new NotImplementedException("Solution.ExtenderCATID"); }
        }

        public object ExtenderNames
        {
            get { throw new NotImplementedException("Solution.ExtenderNames"); }
        }

        public string FileName
        {
            get { throw new NotImplementedException("Solution.FileName"); }
        }

        public ProjectItem FindProjectItem(string FileName)
        {
            //throw new NotImplementedException("Solution.FindProjectItem");
            var itemTypes = new List<string> { ItemType.None, ItemType.Compile, ItemType.Content, ItemType.EmbeddedResource };
            //todo more AvailableItemTypes?
            //todo find in proj. which dir. path inluding FileName's dir. first?
            foreach (ProjectLite proj in this.Projects)
            {
                foreach (var iG in proj.ProjectRootElement.ItemGroups)
                {
                    foreach (var ie in iG.Items)
                    {
                        if (!itemTypes.Contains(ie.ElementName))
                        {
                            continue;
                        }
                        if (ProjectItemLite.GetProjectItemFullName(ie, proj).Equals(FileName))
                        {
                            return new ProjectItemLite(ie, proj);
                        }
                    }
                }                
                return null;
                
                //foreach (ProjectItem projItem in proj.ProjectItems)
                //{
                //    if (projItem is ProjectItemLite)
                //    {
                //        if (projItem.FileCount > 0 && FileName.Equals(projItem.get_FileNames(0)))
                //        {
                //            return projItem;
                //        }
                //    }
                //}
            }
            return null;
        }

        public string FullName
        {
            //get { throw new NotImplementedException("Solution.FullName"); }
            get { return this._solutionFileFullName; }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException("Solution.GetEnumerator");
        }

        public Globals Globals
        {
            get { throw new NotImplementedException("Solution.Globals"); }
        }

        public bool IsDirty
        {
            get
            {
                throw new NotImplementedException("Solution.IsDirty");
            }
            set
            {
                throw new NotImplementedException("set Solution.IsDirty");
            }
        }

        public bool IsOpen
        {
            get
            {
                //throw new NotImplementedException("Solution.IsOpen");
                return this._solutionFile != null;
            }
        }

        public Project Item(object index)
        {
            throw new NotImplementedException("Solution.Item");
        }

        public void Open(string FileName)
        {
            var knownProjExtensions = new List<string> { ".csproj", ".vbproj" }; //todo more proj. types?
            //throw new NotImplementedException("Solution.Open");
            this._solutionFileFullName = FileName;
            this._solutionFile = SolutionFile.Parse(FileName);
            foreach (var proj in _solutionFile.ProjectsInOrder)
            {
                if (!String.IsNullOrWhiteSpace(proj.AbsolutePath)
                    && knownProjExtensions.Contains(Path.GetExtension(proj.AbsolutePath)))
                {
                    var projRootEle = ProjectRootElement.Open(proj.AbsolutePath);
                    var uniqName = proj.RelativePath;
                    this._projectRootElements.Add(uniqName, projRootEle);
                    this._projectsInSolution.Add(uniqName, proj);
                }
            }
        }

        public DTE Parent
        {
            //get { throw new NotImplementedException("Solution.Parent"); }
            get { return this._dte; }
        }

        public string ProjectItemsTemplatePath(string ProjectKind)
        {
            throw new NotImplementedException("Solution.ProjectItemsTemplatePath");
        }

        public Projects Projects
        {
            //get { throw new NotImplementedException("Solution.Projects"); }
            get
            {
                this._projects = this._projects
                    ?? new ProjectsLite(this._projectRootElements, this._projectsInSolution, this._dte);
                return this._projects;
            }
        }

        public EnvDTE.Properties Properties
        {
            get { throw new NotImplementedException("Solution.Properties"); }
        }

        public void Remove(Project proj)
        {
            throw new NotImplementedException("Solution.Remove");
        }

        public void SaveAs(string FileName)
        {
            throw new NotImplementedException("Solution.SaveAs");
        }

        public bool Saved
        {
            get
            {
                throw new NotImplementedException("Solution.Saved");
            }
            set
            {
                throw new NotImplementedException("set Solution.Saved");
            }
        }

        public SolutionBuild SolutionBuild
        {
            get { throw new NotImplementedException("Solution.SolutionBuild"); }
        }

        public object get_Extender(string ExtenderName)
        {
            throw new NotImplementedException("Solution.get_Extender");
        }

        public string get_TemplatePath(string ProjectType)
        {
            throw new NotImplementedException("Solution.get_TemplatePath");
        }
    }
}
