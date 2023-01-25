using EnvDTE;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class SolutionLite : Solution
    {
        private Solution _solution;

        public SolutionLite(Solution solution)
        {
            if (solution == null) { throw new ArgumentNullException("solution"); }
            this._solution = solution;
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
            var projectItem = this._solution.FindProjectItem(FileName);
            if (projectItem == null)
            {
                return null;
            }
            return new ProjectItemLite(projectItem);
        }

        public string FullName
        {
            //get { throw new NotImplementedException("Solution.FullName"); }
            get { return this._solution.FullName; }
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
            get { throw new NotImplementedException("Solution.IsOpen"); }
        }

        public Project Item(object index)
        {
            throw new NotImplementedException("Solution.Item");
        }

        public void Open(string FileName)
        {
            //throw new NotImplementedException("Solution.Open");
            this._solution.Open(FileName);
        }

        public DTE Parent
        {
            get { throw new NotImplementedException("Solution.Parent"); }
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
                return this._solution.Projects == null ? null : new ProjectsLite(this._solution.Projects);
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
