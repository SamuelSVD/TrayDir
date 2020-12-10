using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TrayDir
{
    public class OptionGroup
    {
        [XmlAttribute]
        public string name;
        public List<Option> options;
        public List<OptionGroup> childGroups;

        public OptionGroup() : this("") { }
        public OptionGroup(string name)
        {
            this.name = name;
            options = new List<Option>();
            childGroups = new List<OptionGroup>();
        }
        public Option setOption(string optionName, bool value)
        {
            return setOption(optionName, value ? "1" : "0");
        }
        public Option setOption(string optionName, string value)
        {
            Option option = findOption(optionName);
            if (option == null)
            {
                string[] optionLevels = optionName.Split('|');
                if (optionLevels[0].Length == 0)
                {
                    throw new ArgumentException("Invalid parameter name provided", "optionName");
                }
                if (optionLevels.Length > 1)
                {
                    OptionGroup optionGroup = childGroups.Find(x => x.name == optionLevels[0]);
                    if (optionGroup == null)
                    {
                        optionGroup = new OptionGroup(optionLevels[0]);
                        childGroups.Add(optionGroup);
                    }
                    option = optionGroup.setOption(optionName.Substring(optionLevels[0].Length + 1, optionName.Length - (optionLevels[0].Length + 1)), value);
                }
                else
                {
                    option = new Option(optionLevels[0], value);
                    options.Add(option);
                }
            }
            option.setValue(value);
            return option;
        }
        public string getOptionValue_string(string optionName)
        {
            Option option = findOption(optionName);
            if (option != null)
            {
                return option.getValue_string();
            }
            else
            {
                throw new Exception("Option Name Not Found");
            }
        }
        public bool getOptionValue_bool(string optionName)
        {
            Option option = findOption(optionName);
            if (option != null)
            {
                return option.getValue_bool();
            }
            else
            {
                throw new Exception("Option Name Not Found");
            }
        }
        public Option findOption(string optionName)
        {
            string[] optionLevels = optionName.Split('|');
            if (optionLevels[0].Length == 0)
            {
                throw new Exception("Option Name Not Found");
            }
            if (optionLevels.Length > 1)
            {
                OptionGroup optionGroup = childGroups.Find(x => x.name == optionLevels[0]);
                if (optionGroup == null)
                {
                    return null;
                }
                return optionGroup.findOption(optionName.Substring(optionLevels[0].Length + 1, optionName.Length - (optionLevels[0].Length + 1)));
            }
            else
            {
                Option option = options.Find(x => x.name == optionLevels[0]);
                return option;
            }
        }
        public List<Option> asOptionList()
        {
            return asOptionList("");
        }
        public List<Option> asOptionList(string prefix)
        {
            List<Option> optionList = new List<Option>();
            for (int i = 0; i < options.Count; i++)
            {
                Option option = new Option(prefix + options[i].name, options[i].getValue_string());
                optionList.Add(option);
            }
            for (int i = 0; i < childGroups.Count; i++)
            {
                optionList.AddRange(childGroups[i].asOptionList(prefix + childGroups[i].name + "|"));
            }
            return optionList;
        }
        public int getCategoryCount()
        {
            return childGroups.Count;
        }
        public OptionGroup getChild(string childName)
        {
            return childGroups.Find(x => x.name == childName);
        }
        public int OptionCount { get { return this.options.Count; } }
        public int ChildCount { get { return this.childGroups.Count; } }
        public int TotalCount { get { return this.options.Count + childGroups.Sum(x => x.TotalCount); } }
    }
}
