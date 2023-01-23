using System;

namespace Microsoft.VisualStudio.TextTemplating.VSHost
{
    using Microsoft.VisualStudio.TextTemplating;

    public interface ITextTemplatingComponents
	{
        ITextTemplatingEngineHost Host { get; }

        object Hierarchy { get; set; }
    }
}
    
