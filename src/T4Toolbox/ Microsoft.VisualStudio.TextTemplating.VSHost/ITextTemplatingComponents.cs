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

    
    public interface ITextTemplatingCallback
    {
        void ErrorCallback(bool warning, string message, int line, int column);

        void SetFileExtension(string extension);

        void SetOutputEncoding(System.Text.Encoding encoding, bool fromOutputDirective);
    }
}
    
