using System;

namespace Microsoft.VisualStudio.TextTemplating.VSHost
{
    public interface ITextTemplatingCallback
    {
        void ErrorCallback(bool warning, string message, int line, int column);

        void SetFileExtension(string extension);

        void SetOutputEncoding(System.Text.Encoding encoding, bool fromOutputDirective);
    }

    //todo add a TextTemplatingCallback implements ITextTemplatingCallback??
}

