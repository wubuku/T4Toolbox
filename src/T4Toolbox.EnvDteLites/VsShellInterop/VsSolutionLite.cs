using System;
using Microsoft.VisualStudio.Shell.Interop;

namespace T4Toolbox.EnvDteLites.VsShellInterop
{
	public class VsSolutionLite : IVsSolution
	{
		private SolutionLite _solution;

		public VsSolutionLite(SolutionLite solution)
		{
			this._solution = solution;
		}

        public int GetProjectOfUniqueName(string pszUniqueName, out IVsHierarchy ppHierarchy)
        {
            throw new NotImplementedException();
        }
    }
}

