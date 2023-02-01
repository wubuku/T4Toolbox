using EnvDTE;
using Microsoft.Build.Construction;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class ConfigurationManagerLite : ConfigurationManager
    {
        private ProjectRootElement _projectRootElement;

        private Project _project;

        /*
        * string outDir = project.ConfigurationManager.ActiveConfiguration
        *    .Properties.Item("OutputPath").Value.ToString();
        */
        private Configuration _activeConfiguration;

        private DTE _dte;

        public ConfigurationManagerLite(Project project, DTE dte)
        {
            //if (projectRootElement == null) { throw new ArgumentNullException("projectRootElement"); }
            this._projectRootElement = ((ProjectLite)project).ProjectRootElement;
            this._project = project;
            this._dte = dte;
        }

        public Configuration ActiveConfiguration
        {
            //get { throw new NotImplementedException("ConfigurationManager.ActiveConfiguration"); }
            get
            {
                if (this._activeConfiguration == null)
                {
                    /*
                     * <PropertyGroup>
                     *   <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
                     * ...
                     * <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|Net45' ">
                     *   <PlatformTarget>AnyCPU</PlatformTarget>
                     */
                    var ps = new Dictionary<string, ProjectPropertyElement>();
                    //todo how to fill this active config. ProjectPropertyElement dict.?
                    string activeConfigValue = Convert.ToString(this._project.Properties.Item("Configuration").Value);
                    if (activeConfigValue == null) { activeConfigValue = String.Empty; }
                    foreach (var pG in this._projectRootElement.PropertyGroups)
                    {
                        if (pG.Condition.Contains(activeConfigValue))
                        {
                            foreach (var p in pG.Properties)
                            {
                                ps.Add(p.Name, p);
                            }
                            break;
                        }
                    }
                    var properties = new PropertiesLite(ps, _dte);
                    this._activeConfiguration = new ConfigurationLite(properties, this, _dte);
                }
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
