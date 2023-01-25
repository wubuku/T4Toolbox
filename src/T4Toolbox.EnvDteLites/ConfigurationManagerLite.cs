using EnvDTE;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class ConfigurationManagerLite : ConfigurationManager
    {
        private ConfigurationManager _configurationManager;

        public ConfigurationManagerLite(ConfigurationManager configurationManager)
        {
            if (configurationManager == null) { throw new ArgumentNullException("configurationManager"); }
            this._configurationManager = configurationManager;
        }

        public Configuration ActiveConfiguration
        {
            //get { throw new NotImplementedException("ConfigurationManager.ActiveConfiguration"); }
            get
            {
                if (this._configurationManager.ActiveConfiguration == null) { return null; }
                return new ConfigurationLite(this._configurationManager.ActiveConfiguration);
            }
        }

        public Configurations AddConfigurationRow(string NewName, string ExistingName, bool Propagate)
        {
            throw new NotImplementedException("ConfigurationManager.AddConfigurationRow");
        }

        public Configurations AddPlatform(string NewName, string ExistingName, bool Propagate)
        {
            throw new NotImplementedException("ConfigurationManager.AddPlatform");
        }

        public Configurations ConfigurationRow(string Name)
        {
            throw new NotImplementedException("ConfigurationManager.ConfigurationRow");
        }

        public object ConfigurationRowNames
        {
            get { throw new NotImplementedException("ConfigurationManager.ConfigurationRowNames"); }
        }

        public int Count
        {
            get { throw new NotImplementedException("ConfigurationManager.Count"); }
        }

        public DTE DTE
        {
            get { throw new NotImplementedException("ConfigurationManager.DTE"); }
        }

        public void DeleteConfigurationRow(string Name)
        {
            throw new NotImplementedException("ConfigurationManager.DeleteConfigurationRow");
        }

        public void DeletePlatform(string Name)
        {
            throw new NotImplementedException("ConfigurationManager.DeletePlatform");
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException("ConfigurationManager.GetEnumerator");
        }

        public Configuration Item(object index, string Platform = "")
        {
            throw new NotImplementedException("ConfigurationManager.Item");
        }

        public object Parent
        {
            get { throw new NotImplementedException("ConfigurationManager.Parent"); }
        }

        public Configurations Platform(string Name)
        {
            throw new NotImplementedException("ConfigurationManager.Platform");
        }

        public object PlatformNames
        {
            get { throw new NotImplementedException("ConfigurationManager.PlatformNames"); }
        }

        public object SupportedPlatforms
        {
            get { throw new NotImplementedException("ConfigurationManager.SupportedPlatforms"); }
        }
    }
}
