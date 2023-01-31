using EnvDTE;
using System;
using Microsoft.Build.Construction;

namespace T4Toolbox.EnvDteLites
{
    public class ProjectsLite : Projects
    {
        private IDictionary<string, ProjectRootElement> _projectRootElements;
        private IDictionary<string, ProjectInSolution> _projectsInSolution;

        private DTE _dte;

        public ProjectsLite(IDictionary<string, ProjectRootElement> projectRootElements, IDictionary<string, ProjectInSolution> projectsInSolution, DTE dte)
        {
            if (projectRootElements == null) { throw new ArgumentNullException("projectRootElements"); }
            this._projectRootElements = projectRootElements;
            this._projectsInSolution = projectsInSolution;
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
            foreach (var p in this._projectRootElements)
            {
                string uniqName = p.Key;
                yield return new ProjectLite(p.Value, this._projectsInSolution[uniqName], uniqName, this._dte);
            }
        }

        public Project Item(object index)
        {
            //throw new NotImplementedException("Projects.GetEnumerator");
            var uniqName = Convert.ToString(index);
            return new ProjectLite(_projectRootElements[uniqName], _projectsInSolution[uniqName], uniqName, this._dte);
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
