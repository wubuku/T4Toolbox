using EnvDTE;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class ConfigurationLite : Configuration
    {
        private Configuration _configuration;

        public ConfigurationLite(Configuration configuration)
        {
            if (configuration == null) { throw new ArgumentNullException("configuration"); }
            this._configuration = configuration;
        }

        public ConfigurationManager Collection
        {
            get { throw new NotImplementedException("Configuration.Collection"); }
        }

        public string ConfigurationName
        {
            get { throw new NotImplementedException("Configuration.ConfigurationName"); }
        }

        public DTE DTE
        {
            get { throw new NotImplementedException("Configuration.DTE"); }
        }

        public string ExtenderCATID
        {
            get { throw new NotImplementedException("Configuration.ExtenderCATID"); }
        }

        public object ExtenderNames
        {
            get { throw new NotImplementedException("Configuration.ExtenderNames"); }
        }

        public bool IsBuildable
        {
            get { throw new NotImplementedException("Configuration.IsBuildable"); }
        }

        public bool IsDeployable
        {
            get { throw new NotImplementedException("Configuration.IsDeployable"); }
        }

        public bool IsRunable
        {
            get { throw new NotImplementedException("Configuration.IsRunable"); }
        }

        public new object Object
        {
            get { throw new NotImplementedException("Configuration.Object"); }
        }

        public OutputGroups OutputGroups
        {
            get { throw new NotImplementedException("Configuration.OutputGroups"); }
        }

        public object Owner
        {
            get { throw new NotImplementedException("Configuration.Owner"); }
        }

        public string PlatformName
        {
            get { throw new NotImplementedException("Configuration.PlatformName"); }
        }

        public EnvDTE.Properties Properties
        {
            //get { throw new NotImplementedException("Configuration.Properties"); }
            get
            {
                if (this._configuration.Properties == null)
                {
                    return null;
                }
                return new PropertiesLite(this._configuration.Properties);
            }
        }

        public vsConfigurationType Type
        {
            get { throw new NotImplementedException("Configuration.Type"); }
        }

        public object get_Extender(string ExtenderName)
        {
            throw new NotImplementedException("Configuration.get_Extender");
        }
    }
}
