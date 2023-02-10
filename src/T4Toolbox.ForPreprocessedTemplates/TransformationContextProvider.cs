using T4Toolbox;
using Microsoft.VisualStudio.TextTemplating;
using System.Text;

namespace T4Toolbox.ForPreprocessedTemplates
{

    public class TransformationContextProvider : ITransformationContextProvider
    {
        private OutputFile[] _outputFiles;

        public OutputFile[] OutputFiles { get => _outputFiles; }

        public void Cleanup()
        {
            this._outputFiles = null;
        }

        string ITransformationContextProvider.GetMetadataValue(object hierarchy, string fileName, string metadataName)
        {
            return null;
        }

        string ITransformationContextProvider.GetPropertyValue(object hierarchy, string propertyName)
        {
            throw new NotImplementedException();
        }

        void ITransformationContextProvider.UpdateOutputFiles(string inputFile, OutputFile[] outputFiles)
        {
            this._outputFiles = outputFiles;
        }
    }

}