using System;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;

namespace T4Toolbox.EnvDteLites.VsShellInterop
{
	public class ServiceProvider : IServiceProvider, IDisposable
	{
        private DTELite _dte;

		public ServiceProvider(DTE dte)
		{
            this._dte = (DTELite?)dte;
		}

        public virtual object? GetService(Type serviceType)
        {
            if (serviceType == typeof(IVsSolution))
            {
                return new VsSolutionLite((SolutionLite)_dte.Solution);
            }

            throw new NotImplementedException();
        }


        public void Dispose()
        {
            //
        }
    }
}

