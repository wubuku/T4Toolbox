using EnvDTE;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class ConfigurationLite : Configuration
    {
        private Properties _properties;

        private ConfigurationManager _collection;

        private DTE _dte;

        public ConfigurationLite(Properties properties, ConfigurationManager collection, DTE dte)
        {
            if (properties == null) { throw new ArgumentNullException("properties"); }
            this._properties = properties;
            this._collection = collection;
            this._dte = dte;
        }

        public ConfigurationManager Collection
        {
            //get { throw new NotImplementedException("Configuration.Collection"); }
            get { return _collection; }
        }

        public string ConfigurationName
        {
            get { throw new NotImplementedException("Configuration.ConfigurationName"); }
        }

        public DTE DTE
        {
            //get { throw new NotImplementedException("Configuration.DTE"); }
            get { return _dte; }
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
                return _properties;
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
