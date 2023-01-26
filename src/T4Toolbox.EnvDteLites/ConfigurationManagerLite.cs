using EnvDTE;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class ConfigurationManagerLite : ConfigurationManager
    {
        private Configuration _activeConfiguration;

        private DTE _dte;

        public ConfigurationManagerLite(Configuration activeConfiguration, DTE dte)
        {
            if (activeConfiguration == null) { throw new ArgumentNullException("activeConfiguration"); }
            this._activeConfiguration = activeConfiguration;
            this._dte = dte;
        }

        public Configuration ActiveConfiguration
        {
            //get { throw new NotImplementedException("ConfigurationManager.ActiveConfiguration"); }
            get
            {
                return this._activeConfiguration;
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
            //get { throw new NotImplementedException("ConfigurationManager.DTE"); }
            get { return _dte; }
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
