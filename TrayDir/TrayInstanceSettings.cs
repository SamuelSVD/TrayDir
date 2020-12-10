using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TrayDir
{
    class TrayInstanceSettings
    {
        private OptionGroup instanceSettings;
        private List<string> _paths;
        public List<string> paths { get { return new List<string>(_paths.AsReadOnly()); } }
        public bool RunAsAdmin
        {
            get { return instanceSettings.getOptionValue_bool("RunAsAdmin"); }
            set { instanceSettings.setOption("RunAsAdmin", value); }
        }
        public bool ShowFileExtensions
        {
            get { return instanceSettings.getOptionValue_bool("ShowFileExtensions"); }
            set { instanceSettings.setOption("ShowFileExtensions", value); }
        }
        public bool ExploreFoldersInTrayMenu
        {
            get { return instanceSettings.getOptionValue_bool("ExploreFoldersInTrayMenu"); }
            set { instanceSettings.setOption("ExploreFoldersInTrayMenu", value); }
        }
        public string iconPath
        {
            get { return instanceSettings.getOptionValue_string("RunAsAdmin"); }
            set { instanceSettings.setOption("RunAsAdmin", value); }
        }
        public string iconText
        {
            get { return instanceSettings.getOptionValue_string("iconText"); }
            set { instanceSettings.setOption("iconPath", value); }
        }
        public string instanceName
        {
            get { return instanceSettings.name; }
            set { instanceSettings.name = value; }
        }
        public TrayInstanceSettings(string instanceName)
        {
            instanceSettings = Settings.getInstanceOptions(instanceName);
            if (instanceSettings == null) Instantiate(instanceName);
            LoadPaths();
            LoadOptions();
        }
        private void Instantiate(string instanceName)
        {
            Settings.setIOption(instanceName + "|RunAsAdmin", false);
            Settings.setIOption(instanceName + "|ShowFileExtensions", true);
            Settings.setIOption(instanceName + "|ExploreFoldersInTrayMenu", false);
            Settings.setIOption(instanceName + "|paths.1", ".");
            Settings.setIOption(instanceName + "|iconPath", System.Reflection.Assembly.GetEntryAssembly().Location);
            Settings.setIOption(instanceName + "|iconText", "TrayDir");
            instanceSettings = Settings.getInstanceOptions(instanceName);
        }
        private void LoadPaths()
        {
            _paths = new List<string>();
            OptionGroup pathsOptions = instanceSettings.getChild("paths");
            for (int i = 1; i <= pathsOptions.OptionCount; i++)
            {
                try
                {
                    string path = pathsOptions.getOptionValue_string(i.ToString());
                    _paths.Add(path);
                }
                catch 
                {
                };
            }
        }
        private void LoadOptions()
        {
        }
    }
}
