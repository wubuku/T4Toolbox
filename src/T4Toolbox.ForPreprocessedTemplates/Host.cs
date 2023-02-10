using System.Text.RegularExpressions;
using T4Toolbox;
using Microsoft.VisualStudio.TextTemplating;
using System.Text;
using System.Diagnostics;
using Mono.TextTemplating;
using Microsoft.VisualStudio.TextTemplating.VSHost;

namespace T4Toolbox.ForPreprocessedTemplates
{

    public class Host : TemplateGenerator, IServiceProvider, ITextTemplatingComponents
    {
        TransformationContextProvider _transformationContextProvider;

        TransformationContextProvider TransformationContextProvider { get => _transformationContextProvider; }

        public OutputFile[] ContextOutputFiles
        {
            get => TransformationContextProvider != null ? TransformationContextProvider.OutputFiles : null;
        }

        public Host()
        {
            _transformationContextProvider = new TransformationContextProvider();
        }

        public void Cleanup()
        {
            _transformationContextProvider.Cleanup();
        }

        object? IServiceProvider.GetService(Type serviceType)
        {
            if (serviceType == typeof(ITransformationContextProvider))
            {
                return _transformationContextProvider;
            }
            throw new InvalidOperationException("GetService type: " + serviceType);
        }

        ITextTemplatingEngineHost ITextTemplatingComponents.Host => throw new NotImplementedException();

        object ITextTemplatingComponents.Hierarchy
        {
            get => null;//throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }

        ITextTemplatingCallback ITextTemplatingComponents.Callback { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        ITextTemplatingEngine ITextTemplatingComponents.Engine => throw new NotImplementedException();

        string ITextTemplatingComponents.InputFile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }

}