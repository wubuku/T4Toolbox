using EnvDTE;
using System;
using Microsoft.Build.Construction;

namespace T4Toolbox.EnvDteLites
{
    public class ProjectsLite : Projects
    {
        private IList<ProjectRootElement> _projectRootElements;
        private DTE _dte;

        public ProjectsLite(IList<ProjectRootElement> projectRootElements, DTE dte)
        {
            if (projectRootElements == null) { throw new ArgumentNullException("projectRootElements"); }
            this._projectRootElements = projectRootElements;
            this._dte = dte;
        }

        public int Count
        {
            //get { throw new NotImplementedException("Projects.Count"); }
            get { return this._projectRootElements.Count; }
        }

        public DTE DTE
        {
            //get { throw new NotImplementedException("Projects.DTE"); }
            get { return this._dte; }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            //throw new NotImplementedException("Projects.");
            foreach (ProjectRootElement projectEle in this._projectRootElements)
            {
                yield return new ProjectLite(projectEle, this._dte);
            }
        }

        public Project Item(object index)
        {
            throw new NotImplementedException("Projects.GetEnumerator");
        }

        public string Kind
        {
            get { throw new NotImplementedException("Projects.Kind"); }
        }

        public DTE Parent
        {
            //get { throw new NotImplementedException("Projects.Parent"); }
            get { return this._dte; }
        }

        public EnvDTE.Properties Properties
        {
            get { throw new NotImplementedException("Projects.Properties"); }
        }
    }
}
