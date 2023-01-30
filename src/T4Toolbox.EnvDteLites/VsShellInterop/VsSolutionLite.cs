using System;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;

namespace T4Toolbox.EnvDteLites.VsShellInterop
{
	public class VsSolutionLite : IVsSolution
	{
		private Solution _solution;

		public VsSolutionLite(Solution solution)
		{
			this._solution = solution;
		}

        public int GetProjectOfUniqueName(string pszUniqueName, out IVsHierarchy ppHierarchy)
        {
			foreach (Project p in _solution.Projects)
			{
				if (p.UniqueName.Equals(pszUniqueName))
				{
					ppHierarchy = new VsHierarchyLite(p);
					return 0;
                }
			}
			ppHierarchy = null;
			return 0;
        }
    }
}

