#region 程序集 Microsoft.VisualStudio.TextTemplating.VSHost.12.0, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// 未知的位置
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion

using System;
using System.Text;

namespace Microsoft.VisualStudio.TextTemplating.VSHost
{
    public class TextTemplatingCallback : ITextTemplatingCallback
    {
        private string extension = ".cs";

        private Encoding outputEncoding;

        private bool encodingSetFromOutputDirective;

        private bool errors;

        public string Extension
        {
            get
            {
                return extension;
            }
            set
            {
                extension = value;
            }
        }

        public Encoding OutputEncoding
        {
            get
            {
                return outputEncoding;
            }
            set
            {
                outputEncoding = value;
            }
        }

        public bool Errors
        {
            get
            {
                return errors;
            }
            set
            {
                errors = value;
            }
        }

        public void Initialize()
        {
            errors = false;
            encodingSetFromOutputDirective = false;
            outputEncoding = null;
            extension = ".cs";
        }

        public TextTemplatingCallback DeepCopy()
        {
            TextTemplatingCallback textTemplatingCallback = (TextTemplatingCallback)MemberwiseClone();
            if (extension != null)
            {
                textTemplatingCallback.extension = (string)extension.Clone();
            }

            if (outputEncoding != null)
            {
                textTemplatingCallback.outputEncoding = (Encoding)outputEncoding.Clone();
            }

            return textTemplatingCallback;
        }

        public void ErrorCallback(bool warning, string message, int line, int column)
        {
            errors = true;
        }

        public void SetFileExtension(string extension)
        {
            if (string.IsNullOrEmpty(extension))
            {
                throw new ArgumentNullException("extension");
            }

            this.extension = extension;
        }

        public virtual void SetOutputEncoding(Encoding encoding, bool fromOutputDirective)
        {
            if (encodingSetFromOutputDirective)
            {
                return;
            }

            if (fromOutputDirective)
            {
                encodingSetFromOutputDirective = true;
                outputEncoding = encoding;
                return;
            }

            if (outputEncoding != null && encoding != outputEncoding)
            {
                outputEncoding = Encoding.UTF8;
            }

            outputEncoding = encoding;
        }
    }
}