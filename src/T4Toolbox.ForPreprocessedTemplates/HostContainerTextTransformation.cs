using System.Text.RegularExpressions;
using T4Toolbox;
using Microsoft.VisualStudio.TextTemplating;
using System.Text;
using System.Diagnostics;
using Mono.TextTemplating;

namespace T4Toolbox.ForPreprocessedTemplates
{

    public class HostContainerTextTransformation : TextTransformation
    {
        public ITextTemplatingEngineHost Host { get; set; }

        public HostContainerTextTransformation(ITextTemplatingEngineHost host)
        {
            this.Host = host;
        }

        internal StringBuilder GetInternalGenerationEnvironment()
        {
            return GenerationEnvironment;
        }

        public override string TransformText()
        {
            return GenerationEnvironment.ToString();
        }
    }

}