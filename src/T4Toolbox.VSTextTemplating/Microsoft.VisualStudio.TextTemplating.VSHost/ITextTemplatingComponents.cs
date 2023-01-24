using System;

namespace Microsoft.VisualStudio.TextTemplating.VSHost
{
    using Microsoft.VisualStudio.TextTemplating;

    public interface ITextTemplatingComponents
	{
        ITextTemplatingEngineHost Host { get; }

        object Hierarchy { get; set; }

        ITextTemplatingCallback Callback { get; set; }

        ITextTemplatingEngine Engine { get; }

        string InputFile { get; set; }
    }

}
    
